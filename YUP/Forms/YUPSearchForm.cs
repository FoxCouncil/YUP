using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.Yum;
using Ca.Magrathean.Yup.Controls;
using Ca.Magrathean.Yup.Properties;
using Ca.Magrathean.Yup.Forms.PlaylistForms;
using Ca.Magrathean.Yup.Interfaces;

namespace Ca.Magrathean.Yup.Forms
{
    public partial class YUPSearchForm : Form, IFormStateSerialize
    {
        #region Private Members
        private IFLV[] searchResults;
        #endregion

        #region Constructor
        public YUPSearchForm()
        {
            InitializeComponent();

            this.searchWorker.DoWork += new DoWorkEventHandler(searchWorker_DoWork);
            this.searchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(searchWorker_RunWorkerCompleted);

            queryTextBox.Focus();
        }
        #endregion

        #region Search Bar Event Methods
        private void queryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (queryTextBox.Text != string.Empty)
            {
                searchButton.Enabled = true;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (queryTextBox.Text != string.Empty)
            {
                searchResultsFlow.Controls.Clear();

                searchButton.Enabled = false;

                searchResults = null;

                searchButton.Text = "Searching...";

                spinnerControl.Segments = Settings.YUPSpinnerSegments;

                spinnerControl.Visible = true;

                searchWorker.RunWorkerAsync(queryTextBox.Text);
            }
        }

        private void queryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && queryTextBox.Text != string.Empty)
            {
                e.Handled = true;
                searchButton.PerformClick();
            }
        }

        private void queryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                    // perform necessary action
                    e.Handled = true;
                    break;
            }
        }
        #endregion

        #region Search Result Control Click
        void control_Click(object sender, EventArgs e)
        {
            IFLVControl control = sender as IFLVControl;

            ((YUPMainForm)Owner).LoadVideo(control.FLV);
        }
        #endregion

        #region Form Layout Event Methods
        private void searchResultsFlow_Layout(object sender, LayoutEventArgs e)
        {
            if (searchResultsFlow.Controls.Count != 0)
            {
                searchResultsFlow.Controls[0].Dock = DockStyle.None;

                for (int i = 1; i < searchResultsFlow.Controls.Count; i++)
                {
                    searchResultsFlow.Controls[i].Dock = DockStyle.Top;
                }

                if (searchResultsFlow.HorizontalScroll.Visible)
                {
                    searchResultsFlow.Controls[0].Width = searchResultsFlow.DisplayRectangle.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                }
                else
                {
                    searchResultsFlow.Controls[0].Width = searchResultsFlow.DisplayRectangle.Width;
                }
            }
        }

        private void YUPSearchForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        #endregion

        #region Background Worker Event Methods
        void searchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (Types.AvailablePlugin pluginOn in YUP.PluginServices.AvailablePlugins)
                {
                    IFLV[] videos = pluginOn.Instance.Search(e.Argument.ToString());

                    if (videos != null)
                    {
                        searchResults = videos;
                    }
                    else
                    {
                        MessageBox.Show("No results for: " + queryTextBox.Text, "YouTube Search");
                    }
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message + Environment.NewLine + Environment.NewLine + exp.StackTrace, "Exception");
            }
        }

        void searchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (searchResults != null)
            {
                foreach (IFLV video in searchResults)
                {
                    IFLVControl control = new IFLVControl(video);

                    control.Click += new EventHandler(control_Click);
                    control.ContextMenuStrip = searchResultMenu;

                    searchResultsFlow.Controls.Add(control);
                }
            }

            spinnerControl.Visible = false;
            searchButton.Text = "Search";
            searchButton.Enabled = true;
        }
        #endregion

        #region Context Menu Event Handler
        private void searchResultMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Play Video")
            {
                control_Click(((ContextMenuStrip)sender).SourceControl, new EventArgs());
            }
            else if (e.ClickedItem.Text == "Video Info")
            {
                IFLVControl control = ((ContextMenuStrip)sender).SourceControl as IFLVControl;

                (new YUPVideoInfoForm(control.FLV)).Show();
            }
            else if (e.ClickedItem.Text == "Add To Playlist")
            {
                IFLVControl control = ((ContextMenuStrip)sender).SourceControl as IFLVControl;

                using (AddToPlaylistForm addForm = new AddToPlaylistForm(control.FLV))
                {
                    addForm.ShowDialog(this);
                }
            }
        }
        #endregion

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
                bool? formVisible = YUP.SettingsDatabase.GetBoolSetting("YUPSearchFormVisible");

                if (!formVisible.HasValue)
                {
                    YUP.SettingsDatabase.SetBoolSetting("YUPSearchFormVisible", false);

                    return false;
                }
                else
                {
                    return formVisible.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetBoolSetting("YUPSearchFormVisible", value);

                this.Visible = value;
            }
        }

        public Point FormLocation
        {
            get
            {
                Point yupSearchFormLocation = YUP.SettingsDatabase.GetPointSetting("YUPSearchFormLocation");

                if (yupSearchFormLocation.IsEmpty)
                {
                    Point defaultSearchWindowLocation = new Point(0, 0);

                    YUP.SettingsDatabase.SetPointSetting("YUPSearchFormLocation", defaultSearchWindowLocation);

                    return defaultSearchWindowLocation;
                }
                else
                {
                    return yupSearchFormLocation;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetPointSetting("YUPSearchFormLocation", value);

                Location = value;
            }
        }

        public Size FormSize
        {
            get
            {
                Size formSize = YUP.SettingsDatabase.GetSizeSetting("YUPSearchWindowSize");

                if (formSize == Size.Empty)
                {
                    Size defaultSearchWindowSize = new Size(407, 300);

                    YUP.SettingsDatabase.SetSizeSetting("YUPSearchWindowSize", defaultSearchWindowSize);

                    return defaultSearchWindowSize;
                }
                else
                {
                    return formSize;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetSizeSetting("YUPSearchWindowSize", value);

                Size = value;
            }
        }

        public FormWindowState FormWindowState
        {
            get
            {
                string yupSearchWindowWindowState = YUP.SettingsDatabase.GetStringSetting("YUPSearchWindowWindowState");

                if (yupSearchWindowWindowState == string.Empty)
                {
                    YUP.SettingsDatabase.SetStringSetting("YUPSearchWindowWindowState", FormWindowState.Normal.ToString());

                    return FormWindowState.Normal;
                }
                else
                {
                    return (FormWindowState)Enum.Parse(typeof(FormWindowState), yupSearchWindowWindowState);
                }
            }
            set
            {
                YUP.SettingsDatabase.SetStringSetting("YUPSearchWindowWindowState", value.ToString());

                WindowState = value;
            }
        }
        #endregion        
    }
}
