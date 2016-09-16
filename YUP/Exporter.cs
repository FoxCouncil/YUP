using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ca.Magrathean.Yup.Yum;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Ca.Magrathean.Yup
{
    internal delegate void ExporterDownloadProgressDelegate(uint percentComplete);
    internal delegate void ExporterConvertingProgressDelegate(uint percentComplete);
    internal delegate void ExporterCompleteDelegate(Exporter completedExporter);

    internal class Exporter : IDisposable, IEquatable<Exporter>
    {
        private IFLV m_video;
        private FFMPEGSettings m_settings;
        private WebClient m_webClient;
        private Process m_converterProcess;

        // FFMPEG Output Vars
        private TimeSpan m_videoTime;

        private long m_bytesRecieved;
        private long m_bytesTotal;
        private uint m_percentageDownload;

        private bool m_isRunning = false;
        private bool m_downloading = false;
        private bool m_converting = false;
        private bool m_finished = false;

        public event ExporterDownloadProgressDelegate DownloadProgressChanged;
        public event ExporterConvertingProgressDelegate ConvertingProgressChanged;
        public event ExporterCompleteDelegate ExporterComplete;

        public Exporter(IFLV video, FFMPEGSettings settings)
        {
            m_video = video;
            m_settings = settings;

            m_webClient = new WebClient();
            m_webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(m_webClient_DownloadProgressChanged);
            m_webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(m_webClient_DownloadFileCompleted);

            m_converterProcess = new Process();
            m_converterProcess.StartInfo.FileName = YUP.ExporterServices.ExporterPath;
            m_converterProcess.StartInfo.Arguments = m_settings.Arguments;
            m_converterProcess.StartInfo.CreateNoWindow = true;
            m_converterProcess.StartInfo.RedirectStandardError = true;
            m_converterProcess.StartInfo.UseShellExecute = false;
            m_converterProcess.EnableRaisingEvents = true;
            m_converterProcess.ErrorDataReceived += new DataReceivedEventHandler(m_converterProcess_ErrorDataReceived);
            m_converterProcess.Exited += new EventHandler(m_converterProcess_Exited);
        }

        public void Run()
        {
            m_isRunning = true;

            m_downloading = true;
            m_converting = false;

            m_webClient.DownloadFileAsync(m_video.HDURL, m_settings.InputFilename);
        }

        public void Stop()
        {
            if (m_isRunning)
            {
                if (m_downloading)
                {
                    m_webClient.CancelAsync();
                }
                else if (m_converting)
                {
                    m_converterProcess.Close();
                }
            }
        }

        void m_webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            m_bytesRecieved = e.BytesReceived;
            m_bytesTotal = e.TotalBytesToReceive;
            m_percentageDownload = (uint)e.ProgressPercentage;

            if (DownloadProgressChanged != null)
            {
                DownloadProgressChanged(m_percentageDownload);
            }
        }

        void m_webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            m_downloading = false;
            m_converting = true;

            m_converterProcess.Start();
            m_converterProcess.BeginErrorReadLine();

        }

        void m_converterProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // MessageBox.Show(e.Data);
            if (e.Data != null)
            {
                if (e.Data.Contains("  Duration: "))
                {
                    int commaLoc = e.Data.IndexOf(',', 0, 1);

                    string[] timeString = e.Data.Split(',');

                    string[] timeData = timeString[0].Replace("  Duration: ", string.Empty).Replace('.', ':').Split(':');

                    m_videoTime = new TimeSpan(0, int.Parse(timeData[0]), int.Parse(timeData[1]), int.Parse(timeData[2]), int.Parse(timeData[3]));
                }

                if (e.Data.Contains(" time="))
                {
                    string[] videoProcessedTime = e.Data.Split(' ');

                    foreach (string timeCheck in videoProcessedTime)
                    {
                        if (timeCheck.Contains("time="))
                        {
                            string[] split = timeCheck.Split('=');

                            float percentage = float.Parse(split[1]) / (float)m_videoTime.TotalSeconds * 100;

                            if (ConvertingProgressChanged != null)
                            {
                                ConvertingProgressChanged(Convert.ToUInt32(percentage));
                            }
                        }
                    }
                }
            }
        }

        void m_converterProcess_Exited(object sender, EventArgs e)
        {
            m_isRunning = false;
            m_converting = false;
            m_finished = true;

            if (File.Exists(m_settings.InputFilename))
            {
                File.Delete(m_settings.InputFilename);
            }

            if (ExporterComplete != null)
            {
                ExporterComplete(this);
            }
        }

        public IFLV Video
        {
            get { return m_video; }
            set { m_video = value; }
        }

        internal FFMPEGSettings Settings
        {
            get { return m_settings; }
            set { m_settings = value; }
        }

        public bool IsRunning
        {
            get { return m_isRunning; }
        }

        public bool Finished
        {
            get { return m_finished; }
        }

        public void Dispose()
        {
            if (m_webClient != null)
            {
                if (m_webClient.IsBusy)
                {
                    m_webClient.CancelAsync();
                }

                m_webClient.Dispose();
            }

            if (m_converterProcess != null)
            {
                if (!m_converterProcess.HasExited)
                {
                    m_converterProcess.Close();
                }

                m_converterProcess.Dispose();
            }
        }

        #region IEquatable<Exporter> Members
        public bool Equals(Exporter other)
        {
            return (this.m_video.Module.Name == other.Video.Module.Name && this.m_video.VideoID == other.Video.VideoID);
        }
        #endregion
    }
}
