using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.Properties;
using Ca.Magrathean.Yup.Controls;
using Ca.Magrathean.Yup.Interfaces;

namespace Ca.Magrathean.Yup.Forms
{
    public partial class YUPExportJobsForm : Form, IFormStateSerialize
    {
        private delegate void ClearFlowPanelDelegate();

        public YUPExportJobsForm()
        {
            this.Icon = Icon.FromHandle(Resources.disk_multiple.GetHicon());

            InitializeComponent();

            YUP.ExporterServices.JobAdded += new ExporterJobAddedDelegate(ExporterServices_JobAdded);
            YUP.ExporterServices.JobRemoved += new ExporterJobRemovedDelegate(ExporterServices_JobRemoved);

            this.Invalidated += new InvalidateEventHandler(YUPExportJobsForm_Invalidated);
        }

        void YUPExportJobsForm_Invalidated(object sender, InvalidateEventArgs e)
        {
            Exporter[] jobArray = YUP.ExporterServices.ExportJobs;

            if (jobArray.Length != 0)
            {
                flowLayoutPanel_Jobs.Controls.Clear();

                foreach (Exporter job in jobArray)
                {
                    flowLayoutPanel_Jobs.Controls.Add(new ExportJobDisplay(job));
                }
            }
            else
            {
                if (flowLayoutPanel_Jobs.InvokeRequired)
                {
                    flowLayoutPanel_Jobs.Invoke(new ClearFlowPanelDelegate(flowLayoutPanel_Jobs.Controls.Clear));
                }
                else
                {
                    flowLayoutPanel_Jobs.Controls.Clear();
                }
            }
        }

        void ExporterServices_JobRemoved(Exporter job)
        {
            this.Invalidate();
        }

        void ExporterServices_JobAdded(Exporter job)
        {
            this.Invalidate();
        }

        #region IFormStateSerialize Members
        public void SaveFormState()
        {
            FormWindowState = WindowState;

            FormLocation = (WindowState == FormWindowState.Normal) ? Location : RestoreBounds.Location;
            FormSize = (WindowState == FormWindowState.Normal) ? Size : RestoreBounds.Size;
            FormVisible = Visible;
        }

        public void LoadFormState()
        {
            Point formLocation = FormLocation;

            if (formLocation != new Point(0, 0))
            {
                StartPosition = FormStartPosition.Manual;
                Location = formLocation;
            }

            Size = FormSize;
            WindowState = FormWindowState;

            if (FormVisible)
            {
                this.Show();
            }
        }

        public bool FormVisible
        {
            get
            {
                bool? formVisible = YUP.SettingsDatabase.GetBoolSetting("YUPExportJobsFormVisible");

                if (!formVisible.HasValue)
                {
                    YUP.SettingsDatabase.SetBoolSetting("YUPExportJobsFormVisible", false);

                    return false;
                }
                else
                {
                    return formVisible.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetBoolSetting("YUPExportJobsFormVisible", value);

                this.Visible = value;
            }
        }

        public Point FormLocation
        {
            get
            {
                Point YUPExportJobsFormLocation = YUP.SettingsDatabase.GetPointSetting("YUPExportJobsFormLocation");

                if (YUPExportJobsFormLocation.IsEmpty)
                {
                    Point defaultSearchWindowLocation = new Point(0, 0);

                    YUP.SettingsDatabase.SetPointSetting("YUPExportJobsFormLocation", defaultSearchWindowLocation);

                    return defaultSearchWindowLocation;
                }
                else
                {
                    return YUPExportJobsFormLocation;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetPointSetting("YUPExportJobsFormLocation", value);

                Location = value;
            }
        }

        public Size FormSize
        {
            get
            {
                Size formSize = YUP.SettingsDatabase.GetSizeSetting("YUPExportJobsSize");

                if (formSize == Size.Empty)
                {
                    Size defaultExportJobsWindowSize = new Size(407, 300);

                    YUP.SettingsDatabase.SetSizeSetting("YUPExportJobsSize", defaultExportJobsWindowSize);

                    return defaultExportJobsWindowSize;
                }
                else
                {
                    return formSize;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetSizeSetting("YUPExportJobsSize", value);

                Size = value;
            }
        }

        public FormWindowState FormWindowState
        {
            get
            {
                string yupExportJobsWindowState = YUP.SettingsDatabase.GetStringSetting("YUPExportJobsWindowState");

                if (yupExportJobsWindowState == string.Empty)
                {
                    YUP.SettingsDatabase.SetStringSetting("YUPExportJobsWindowState", FormWindowState.Normal.ToString());

                    return FormWindowState.Normal;
                }
                else
                {
                    return (FormWindowState)Enum.Parse(typeof(FormWindowState), yupExportJobsWindowState);
                }
            }
            set
            {
                YUP.SettingsDatabase.SetStringSetting("YUPExportJobsWindowState", value.ToString());

                WindowState = value;
            }
        }
        #endregion

        private void flowLayoutPanel_Jobs_Layout(object sender, LayoutEventArgs e)
        {
            if (flowLayoutPanel_Jobs.Controls.Count != 0)
            {
                flowLayoutPanel_Jobs.Controls[0].Dock = DockStyle.None;

                for (int i = 1; i < flowLayoutPanel_Jobs.Controls.Count; i++)
                {
                    flowLayoutPanel_Jobs.Controls[i].Dock = DockStyle.Top;
                }

                if (flowLayoutPanel_Jobs.HorizontalScroll.Visible)
                {
                    flowLayoutPanel_Jobs.Controls[0].Width = flowLayoutPanel_Jobs.DisplayRectangle.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                }
                else
                {
                    flowLayoutPanel_Jobs.Controls[0].Width = flowLayoutPanel_Jobs.DisplayRectangle.Width;
                }
            }
        }
    }
}
