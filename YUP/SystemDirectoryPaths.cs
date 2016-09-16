using System;
using System.Collections.Generic;
using System.Text;

namespace Ca.Magrathean.Yup
{
    #region SystemDirectoryPaths
    /// <summary>
    /// Public static properties used to retrieve directory paths to system special folders.
    /// </summary>
    public static class SystemDirectoryPaths
    {
        /// <summary>
        /// The directory that serves as a common repository for application-specific data for the current roaming user.
        /// </summary>
        public static string ApplicationData
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
        }

        /// <summary>
        /// The directory that serves as a common repository for application-specific data that is used by all users.
        /// </summary>
        public static string CommonApplicationData
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            }
        }

        /// <summary>
        /// The directory that serves as a common repository for application-specific data that is used by the current, non-roaming user.
        /// </summary>
        public static string LocalApplicationData
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }
        }

        /// <summary>
        /// The directory that serves as a common repository for Internet cookies.
        /// </summary>
        public static string Cookies
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            }
        }

        /// <summary>
        /// The logical Desktop rather than the physical file system location.
        /// </summary>
        public static string Desktop
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
        }

        /// <summary>
        /// The directory that serves as a common repository for the user's favorite items.
        /// </summary>
        public static string Favorites
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            }
        }

        /// <summary>
        /// The directory that serves as a common repository for Internet history items.
        /// </summary>
        public static string History
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.History);
            }
        }

        /// <summary>
        /// The directory that serves as a common repository for temporary Internet files.
        /// </summary>
        public static string InternetCache
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            }
        }

        /// <summary>
        /// The directory that contains the user's program groups.
        /// </summary>
        public static string Programs
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            }
        }

        /// <summary>
        /// The "My Computer" folder.
        /// </summary>
        public static string MyComputer
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            }
        }

        /// <summary>
        /// The "My Music" folder.
        /// </summary>
        public static string MyMusic
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            }
        }

        /// <summary>
        /// The "My Pictures" folder.
        /// </summary>
        public static string MyPictures
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
        }

        /// <summary>
        /// The directory that contains the user's most recently used documents.
        /// </summary>
        public static string Recent
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            }
        }

        /// <summary>
        /// The directory that contains the Send To menu items.
        /// </summary>
        public static string SentTo
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            }
        }

        /// <summary>
        /// The directory that contains the Start menu items.
        /// </summary>
        public static string StartMenu
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            }
        }

        /// <summary>
        /// The directory that corresponds to the user's Startup program group.
        /// </summary>
        public static string Startup
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            }
        }

        /// <summary>
        /// The System directory.
        /// </summary>
        public static string System
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.System);
            }
        }

        /// <summary>
        /// The directory that serves as a common repository for document templates.
        /// </summary>
        public static string Templates
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Templates);
            }
        }

        /// <summary>
        /// The directory used to physically store file objects on the desktop.
        /// </summary>
        public static string DesktopDirectory
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }
        }

        /// <summary>
        /// The directory that serves as a common repository for documents.
        /// </summary>
        public static string Personal
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
        }

        /// <summary>
        /// The "My Documents" folder.
        /// </summary>
        public static string MyDocuments
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }

        /// <summary>
        /// The program files directory.
        /// </summary>
        public static string ProgramFiles
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }
        }

        /// <summary>
        /// The directory for components that are shared across applications.
        /// </summary>
        public static string CommonProgramFiles
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
            }
        }
    }
    #endregion
}
