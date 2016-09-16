using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ca.Magrathean.Yup.Yum;

namespace Ca.Magrathean.Yup
{
    internal delegate void ExporterJobAddedDelegate(Exporter job);
    internal delegate void ExporterJobRemovedDelegate(Exporter job);

    internal class ExportServices
    {
        const string m_exporterPath        = @"c:\";
        const string m_exporterAssembly    = @"ffmpeg.exe";

        private bool m_exporterFound;
        private List<Exporter> m_exportJobs = new List<Exporter>();

        public event ExporterJobAddedDelegate JobAdded;
        public event ExporterJobRemovedDelegate JobRemoved;

        public ExportServices()
        {
            if (YUP.ExporterServices != null)
            {
                throw new ApplicationException("*growl* The exporting service has already been instantiated! Um...why are you trying to create a new instance?");
            }

            m_exporterFound = File.Exists(m_exporterPath + m_exporterAssembly);
        }

        public bool Export(IFLV video, FFMPEGSettings settings)
        {
            if (m_exporterFound)
            {
                Exporter job = new Exporter(video, settings);

                m_exportJobs.Add(job);

                job.Run();

                if (JobAdded != null)
                {
                    JobAdded(job);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveJob(Exporter exporterToRemove)
        {
            m_exportJobs.Remove(exporterToRemove);

            if (JobRemoved != null)
            {
                JobRemoved(exporterToRemove);
            }
        }

        #region Private Event Methods
        #endregion

        #region Public and Internal Properties
        internal Exporter[] ExportJobs
        {
            get { return m_exportJobs.ToArray(); }
        }

        public bool ExporterFound
        {
            get { return m_exporterFound; }
        }

        public string ExporterPath
        {
            get { return m_exporterPath + m_exporterAssembly; }
        }

        public uint TotalExportJobs
        {
            get { return (uint)m_exportJobs.Count; }
        }
        #endregion
    }
}
