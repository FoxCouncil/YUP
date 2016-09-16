using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.Yum;
using Ca.Magrathean.Yup.Properties;
using System.Diagnostics;

namespace Ca.Magrathean.Yup.Forms
{
    public partial class YUPSettingsForm : Form
    {
        #region Private Members
        private bool carateState = false;
        private YUPMainForm m_mainForm;
        #endregion

        #region Constructor
        public YUPSettingsForm(YUPMainForm mainForm)
        {
            InitializeComponent();

            digitalDisplayExample.DigitText = DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString("D2");

            m_mainForm = mainForm;
        }
        #endregion

        #region Form Event Methods
        private void YUPOptionsForm_Load(object sender, EventArgs e)
        {
            digitalDisplayExample.DigitColor = Settings.DigitalDisplayColor;

            timeTimer.Enabled = true;

            LoadSettings();
            LoadEvents();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region General Settings Event Methods
        private void displayStyleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (displayStyleTaskbarRadioButton.Checked)
            {
                Settings.YUPDisplayStyle = YUPDisplay.Taskbar;
            }
            else if (displayStyleSystemTrayRadioButton.Checked)
            {
                Settings.YUPDisplayStyle = YUPDisplay.SystemTray;
            }
            else if (displayStyleBothRadioButton.Checked)
            {
                Settings.YUPDisplayStyle = YUPDisplay.Both;
            }
        }

        private void digitalDisplayColorSelectButton_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.DigitalDisplayColor;

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                ChangeControlColors(colorPicker.Color);
            }
        }

        private void ChangeControlColors(Color changeColor)
        {
            Settings.DigitalDisplayColor = changeColor;
            digitalDisplayExample.DigitColor = changeColor;
            colorBox.BackColor = changeColor;
            colorHexTextBox.Text = "#" + changeColor.R.ToString("X2") + changeColor.G.ToString("X2") + changeColor.B.ToString("X2");
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            carateState = !carateState;

            if (carateState)
            {
                digitalDisplayExample.DigitText = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString("D2");
            }
            else
            {
                digitalDisplayExample.DigitText = DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString("D2");
            }
        }

        private void displayTitleStatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.YUPDisplayStatus = displayTitleStatusCheckBox.Checked;

            displayStatusPictureBox.Image = (displayTitleStatusCheckBox.Checked) ? (Image)Resources.StatusTitleOn : (Image)Resources.StatusTitleOff;
        }

        private void pauseWhenMinimizedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PauseWhenMinimized = pauseWhenMinimizedCheckBox.Checked;
        }
        #endregion

        #region Output Settings Event Methods
        private void maintainRatioRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.MaintainVideoSizeRatio = maintainRatioRadioButton.Checked;
        }

        private void defStandardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CheckHDStatus();
        }

        private void rewindVideoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.RewindVideo = rewindVideoCheckBox.Checked;
        }

        private void videoGroupBox_Enter(object sender, EventArgs e)
        {
            formFootnoteLabel.Visible = true;
            
            CheckHDStatus();
        }

        private void videoGroupBox_Leave(object sender, EventArgs e)
        {
            formFootnoteLabel.Visible = false;
        }
        #endregion

        #region YUM Setting Events Methods
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                yumInfoButton.Enabled = true;
            }
        }

        private void yumInfoButton_Click(object sender, EventArgs e)
        {
            IModule plugin = checkedListBox1.SelectedItem as IModule;

            MessageBox.Show("Name: " + plugin.Name + Environment.NewLine + "Company: " + plugin.Company + Environment.NewLine + "Version: " + plugin.Version, plugin.Name + " info");
        }
        #endregion

        #region UI Page Event Methods
        private void segmentTrackBar_ValueChanged(object sender, EventArgs e)
        {
            spinner.Segments = segmentTrackBar.Value;
            Settings.YUPSpinnerSegments = spinner.Segments;
        }

        private void colorHexTextBox_TextChanged(object sender, EventArgs e)
        {
            if (colorHexTextBox.Text.Length < 7)
            {
                colorHexTextBox.BackColor = Color.Pink;
                return;
            }

            Color transColor;

            try
            {
                transColor = ColorTranslator.FromHtml(colorHexTextBox.Text);
            }
            catch (Exception)
            {
                colorHexTextBox.BackColor = Color.Pink;
                return;
            }

            colorHexTextBox.BackColor = Color.LightGreen;

            ChangeControlColors(transColor);
        }
        #endregion

        #region Exporting Page Event Methods
        private void ffmpegLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://ffmpeg.org/");
        }
        #endregion

        #region Private Methods
        private void LoadSettings()
        {
            // General Settings
            {
                YUPDisplay displaySetting = Settings.YUPDisplayStyle;

                if (displaySetting == YUPDisplay.Taskbar)
                {
                    displayStyleTaskbarRadioButton.Checked = true;
                }
                else if (displaySetting == YUPDisplay.SystemTray)
                {
                    displayStyleSystemTrayRadioButton.Checked = true;
                }
                else
                {
                    displayStyleBothRadioButton.Checked = true;
                }
            }

            // Video Settings
            {
                maintainRatioRadioButton.Checked = Settings.MaintainVideoSizeRatio;
                exactFitRadioButton.Checked = !Settings.MaintainVideoSizeRatio;

                rewindVideoCheckBox.Checked = Settings.RewindVideo;

                defHighRadioButton.Checked = Settings.HDEnabled;
                defStandardRadioButton.Checked = !Settings.HDEnabled;
            }

            // UI Settings
            {
                displayTitleStatusCheckBox.Checked = Settings.YUPDisplayStatus;

                segmentTrackBar.Value = Settings.YUPSpinnerSegments;
                spinner.Segments = segmentTrackBar.Value;

                colorBox.BackColor = Settings.DigitalDisplayColor;
                colorHexTextBox.Text = ColorTranslator.ToHtml(Settings.DigitalDisplayColor);
            }

            // YUM Settings
            {
                checkedListBox1.Items.Clear();

                foreach (Types.AvailablePlugin pluginOn in YUP.PluginServices.AvailablePlugins)
                {
                    checkedListBox1.Items.Add(pluginOn.Instance);
                }
            }
        }

        private void LoadEvents()
        {
            this.displayStyleSystemTrayRadioButton.CheckedChanged += new System.EventHandler(this.displayStyleRadioButton_CheckedChanged);
            this.displayStyleBothRadioButton.CheckedChanged += new System.EventHandler(this.displayStyleRadioButton_CheckedChanged);
            this.displayStyleTaskbarRadioButton.CheckedChanged += new System.EventHandler(this.displayStyleRadioButton_CheckedChanged);
            this.defStandardRadioButton.CheckedChanged += new System.EventHandler(this.defStandardRadioButton_CheckedChanged);
            this.rewindVideoCheckBox.CheckedChanged += new System.EventHandler(this.rewindVideoCheckBox_CheckedChanged);
            this.maintainRatioRadioButton.CheckedChanged += new System.EventHandler(this.maintainRatioRadioButton_CheckedChanged);
            this.colorHexTextBox.TextChanged += new System.EventHandler(this.colorHexTextBox_TextChanged);
            this.segmentTrackBar.ValueChanged += new System.EventHandler(this.segmentTrackBar_ValueChanged);
            this.displayTitleStatusCheckBox.CheckedChanged += new System.EventHandler(this.displayTitleStatusCheckBox_CheckedChanged);
            this.digitalDisplayColorSelectButton.Click += new System.EventHandler(this.digitalDisplayColorSelectButton_Click);
            this.ffmpegLabelLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ffmpegLabelLink_LinkClicked);
            this.pauseWhenMinimizedCheckBox.CheckedChanged += new System.EventHandler(this.pauseWhenMinimizedCheckBox_CheckedChanged);
        }

        private void CheckHDStatus()
        {
            if (defStandardRadioButton.Checked)
            {
                formFootnoteLabel.Text = string.Empty;
                definitionPictureBox.Image = Ca.Magrathean.Yup.Properties.Resources.SD;
                Settings.HDEnabled = false;
            }
            else
            {
                formFootnoteLabel.Text = "* If available; will default to SD";
                defHighRadioButton.Checked = true;
                definitionPictureBox.Image = Ca.Magrathean.Yup.Properties.Resources.HD;
                Settings.HDEnabled = true;
            }
        }

        private void LoadFFMPEGSettings()
        {
        }
        #endregion
    }
}
