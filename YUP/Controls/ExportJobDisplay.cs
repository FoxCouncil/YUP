using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup.Controls
{
    internal partial class ExportJobDisplay : UserControl
    {
        private Exporter m_job;
        private delegate void ConvertingDelegate(uint percentage);
        private delegate void SetJobStatusTextDelegate(string text);

        public ExportJobDisplay(Exporter job)
        {
            InitializeComponent();

            m_job = job;
            m_job.DownloadProgressChanged += new ExporterDownloadProgressDelegate(m_job_DownloadProgressChanged);
            m_job.ConvertingProgressChanged += new ExporterConvertingProgressDelegate(m_job_ConvertingProgressChanged);
            m_job.ExporterComplete += new ExporterCompleteDelegate(m_job_ExporterComplete);

            DisplayJobStuff();
        }

        void m_job_DownloadProgressChanged(uint percentComplete)
        {
            progressBarJob.Style = ProgressBarStyle.Blocks;

            SetStatusLabel(string.Format("Downloading... {0}%", percentComplete));

            progressBarJob.Value = (int)percentComplete;
        }

        void m_job_ConvertingProgressChanged(uint percentComplete)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ConvertingDelegate(m_job_ConvertingProgressChanged), new object[] { percentComplete });
            }
            else
            {
                SetStatusLabel(string.Format("Converting... {0}%", percentComplete));

                progressBarJob.Value = (int)percentComplete;
            }

        }

        void m_job_ExporterComplete(Exporter completedExporter)
        {
            if (labelJobStatus.InvokeRequired)
            {
                labelJobStatus.Invoke(new SetJobStatusTextDelegate(SetStatusLabel), new object[] { "Completed!" });
            }
            else
            {
                SetStatusLabel("Completed!");
            }
        }

        private void SetStatusLabel(string text)
        {
            labelJobStatus.Text = text;

            if (text == "Completed!")
            {
                progressBarJob.Value = 100;
            }
        }

        private void DisplayJobStuff()
        {
            labelJobInfo.Text = string.Format("[{0}] {1}", m_job.Video.Module.Name, m_job.Video.Title);
            FLVThumbnailImage.ImageLocation = m_job.Video.ThumbnailImage.ToString();
            labelJobStatus.Text = "Initializing...";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (m_job.IsRunning)
            {
                m_job.DownloadProgressChanged -= m_job_DownloadProgressChanged;
                m_job.ConvertingProgressChanged -= m_job_ConvertingProgressChanged;

                m_job.Stop();

                labelJobStatus.Text = "Canceled!";
            }
            else if (m_job.Finished)
            {
                YUP.ExporterServices.RemoveJob(m_job);
            }
        }

        internal Exporter Job
        {
            get { return m_job; }
        }
    }
}
