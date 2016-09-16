using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ca.Magrathean.Yup.Yum;
using System.Windows.Forms;
using Ca.Magrathean.Yup.DB;
using Ca.Magrathean.Yup.Forms;
using System.IO;
using Microsoft.Win32;

namespace Ca.Magrathean.Yup
{
    static class YUP
    {
        #region Private Member Variables
        private static string m_commonAppDataPath;
        private static string m_userDocuments;
        private static YUPMainForm m_mainForm;
        private static PluginServices m_pluginServices;
        private static ExportServices m_exporterServices;
        private static SettingsDatabase m_settingsDatabase;
        private static PlaylistsDatabase m_playlistsDatabase;
        private static YUMDatabase m_yumDatabase; 
        #endregion

        #region Main()
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initalization();

            if (PluginServices.AvailablePlugins.Count == 0)
            {
                MessageBox.Show("YUP cannot find any plugins in the plugin directory:\n\n" + UserDocuments + @"\Plugins" + "\n\nYUP will now close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        Retry:
            if (!DetectFlashOCX())
            {
                DialogResult errorDialogResult = MessageBox.Show("Flash not detected in the registry.\n\nThis does not mean that Flash ActiveX is not installed, just not available in the registry.\n\nYou can safetly ignore this warning, however, YUP may behave in very interesting ways.", "Warning!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                if (errorDialogResult == DialogResult.Abort)
                {
                    return;
                }
                else if (errorDialogResult == DialogResult.Retry)
                {
                    goto Retry;
                }
            }

            StartYUP();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Let's get YUP started!
        /// </summary>
        private static void StartYUP()
        {
            if (SettingsDatabase.FirstRun)
            {
                MessageBox.Show("Welcome to YUP.\n\nThis is the first time you've run YUP, please take note that this is beta software. This application is likely to fail hard.\n\nAgain, thank you for loving Fox enough to watch him fail...\n...hard.", "YUP Notice");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if !DEBUG
            try
            {
#endif
            m_mainForm = new YUPMainForm();

            Application.Run(m_mainForm);
#if !DEBUG
            }
            catch (System.Exception e)
            {
                YUP.Error(e);
            }
#endif
        }

        /// <summary>
        /// Check and make user and application directories.
        /// </summary>
        private static void Initalization()
        {
            m_commonAppDataPath = SystemDirectoryPaths.CommonApplicationData + @"\YUP";

            if (!Directory.Exists(m_commonAppDataPath))
            {
                Directory.CreateDirectory(m_commonAppDataPath);
            }

            m_userDocuments = SystemDirectoryPaths.MyDocuments + @"\YUP";

            if (!Directory.Exists(m_userDocuments))
            {
                Directory.CreateDirectory(m_userDocuments);
            }

            // Plugin services.
            m_pluginServices = new PluginServices();

            // Settings Database
            m_settingsDatabase = new SettingsDatabase();

            // Playlist Databases
            m_playlistsDatabase = new PlaylistsDatabase();

            // Plugin Databases
            m_yumDatabase = new YUMDatabase();

            // Exporting Services
            m_exporterServices = new ExportServices();
        }

        /// <summary>
        /// This method will discover the Flash OCX via the registry.
        /// </summary>
        /// <returns>True if Flash AX exists; false if Flash AX is possibly not installed.</returns>
        private static bool DetectFlashOCX()
        {
            using (RegistryKey clisdRoot = Registry.ClassesRoot)
            {
                using (RegistryKey clisdMain = clisdRoot.OpenSubKey("CLSID"))
                {
                    using (RegistryKey clisdShockwaveFlash = clisdMain.OpenSubKey("{d27cdb6e-ae6d-11cf-96b8-444553540000}"))
                    {
                        return (clisdShockwaveFlash != null);
                    }
                }
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// YUP Plugins Service
        /// </summary>
        public static PluginServices PluginServices
        {
            get { return YUP.m_pluginServices; }
        }

        /// <summary>
        /// YUP Exporting Service
        /// </summary>
        public static ExportServices ExporterServices
        {
            get { return YUP.m_exporterServices; }
        }

        /// <summary>
        /// YUP Application Settings Service
        /// </summary>
        public static SettingsDatabase SettingsDatabase
        {
            get { return YUP.m_settingsDatabase; }
        }

        /// <summary>
        /// YUP Playlist Services
        /// </summary>
        public static PlaylistsDatabase PlaylistsDatabase
        {
            get { return YUP.m_playlistsDatabase; }
        }

        /// <summary>
        /// YUP Plugin Settings
        /// TODO: Eventually make it an Application Settings Service property
        /// </summary>
        public static YUMDatabase YUMDatabase
        {
            get { return YUP.m_yumDatabase; }
        }

        /// <summary>
        /// The path to user based YUP directory.
        /// </summary>
        public static string UserDocuments
        {
            get
            {
                return m_userDocuments;
            }
        }

        /// <summary>
        /// The common shared YUP directory.
        /// </summary>
        public static string CommonAppDataPath
        {
            get
            {
                return m_commonAppDataPath;
            }
        }

        /// <summary>
        /// Get the mainform for use with settings...
        /// </summary>
        public static YUPMainForm MainForm
        {
            get
            {
                return YUP.m_mainForm; 
            }
        }
        #endregion

        #region Public Helper Methods
        /// <summary>
        /// A general global ErrorBox.
        /// </summary>
        /// <param name="e">The exception that has been thrown.</param>
        public static void Error(System.Exception e)
        {
            YUPErrorBox errorBox = new YUPErrorBox(e);
            errorBox.ShowDialog();

            Application.Exit();
        }

        /// <summary>
        /// Check if a file handle is currently open on the file.
        /// </summary>
        /// <param name="file">The complete path to the file.</param>
        /// <returns>True if the file handle is open; false if the file handle is not in use.</returns>
        public static bool IsFileOpen(string file)
        {
            bool isOpen = false;

            try
            {
                if (!System.IO.File.Exists(file))
                {
                    throw new FileNotFoundException(file + " could not be found!");
                }
                else
                {
                    FileStream stream = System.IO.File.OpenRead(file);
                    stream.Close();
                }
            }
            catch
            {
                isOpen = true;
            }

            return isOpen;
        }



        /// <summary>
        /// Extract a resource stored in this assembly to the local file system.
        /// </summary>
        /// <param name="resourceName">The name of the embedded resource.</param>
        /// <returns>A string of the complete path to the extracted resource.</returns>
        /// <exception cref="Exception">Occurs when resource doesn't exist in this assembly.</exception>
        public static string ExtractResource(string resourceName)
        {
            //look for the resource name
            foreach (string currentResource in System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (currentResource.LastIndexOf(resourceName) != -1)
                {
                    string fqnTempFile = System.IO.Path.GetTempFileName();
                    string path = System.IO.Path.GetDirectoryName(fqnTempFile);
                    string rootName = System.IO.Path.GetFileNameWithoutExtension(fqnTempFile);
                    string destFile = CommonAppDataPath + @"\" + rootName + "." + System.IO.Path.GetExtension(currentResource);

                    System.IO.Stream fs = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(currentResource);

                    byte[] buff = new byte[fs.Length];
                    fs.Read(buff, 0, (int)fs.Length);
                    fs.Close();

                    System.IO.FileStream destStream = new System.IO.FileStream(destFile, FileMode.Create);
                    destStream.Write(buff, 0, buff.Length);
                    destStream.Close();

                    return destFile;
                }
            }

            throw new Exception("Resource not found : " + resourceName);
        }
        #endregion
    }
}
