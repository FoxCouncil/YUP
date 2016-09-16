using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.Yum;
using Ca.Magrathean.Yup.Properties;
using System.IO;

namespace Ca.Magrathean.Yup.Forms.Exporting
{
    public partial class YUPSaveAsForm : Form
    {
        private IFLV m_video;

        private bool m_selectedFolder;
        private bool m_selectedSettings;

        public YUPSaveAsForm(IFLV video)
        {
            InitializeComponent();

            m_video = video;
        }

        private void browseFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = @"Please select the folder you wish your exported video files to be saved to.";
                
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    textBox1.Text = folderDialog.SelectedPath + @"\";
                }

                if (Directory.Exists(textBox1.Text))
                {
                    m_selectedFolder = true;
                }
                else
                {
                    // TODO: Change to a singular fox style of Message Dialogs
                    MessageBox.Show("The folder selected does not exists.\n\nPlease create it!");
                }

                exportButton.Enabled = (m_selectedSettings && m_selectedFolder);
            }
        }

        private void YUPSaveAsForm_Load(object sender, EventArgs e)
        {
            videoTitleLabel.Text = m_video.Title;
            videoThumbnail.ImageLocation = m_video.ThumbnailImage.ToString();
            videoLengthLabel.Text = m_video.Length.ToString();
            videoAuthorLink.Text = m_video.Author;
            videoViewsLabel.Text = string.Format("{0:#,#}", m_video.ViewCount);

            if (m_video.HDEnabled)
            {
                definitionPictureBox.Image = Resources.HD;
            }
            else
            {
                definitionPictureBox.Image = Resources.SD;
            }
        }

        private void quickSettingsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (quickSettingsComboBox.SelectedItem != null)
            {
                m_selectedSettings = true;
            }

            exportButton.Enabled = (m_selectedSettings && m_selectedFolder);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            bool failed = false;
            FFMPEGSettings settings = new FFMPEGSettings(textBox1.Text, m_video.Title);

            /*
             * iPod
             * iPhone/iPod Touch
             * PSP
             * Computer Playback
             * MP3 - Audio Only
             * */
            switch (quickSettingsComboBox.SelectedItem as string)
            {
                case "MP3 - Audio Only":
                {
                    settings.ForceFileFormat = FFMPEGSettings.FileFormat.mp3;
                    settings.ForceAudioCodec = FFMPEGSettings.AudioCodec.libmp3lame;
                    settings.AudioBitrate = 128000;
                }
                break;

                case "Computer Playback":
                {
                    settings.ForceFileFormat = FFMPEGSettings.FileFormat.mpeg;
                    settings.ForceAudioCodec = FFMPEGSettings.AudioCodec.libmp3lame;
                    settings.ForceVideoCodec = FFMPEGSettings.VideoCodec.mpeg2video;
                }
                break;

                default:
                {
                    failed = true;
                }
                break;
            }

            if (!failed)
            {
                YUP.ExporterServices.Export(m_video, settings);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }

            this.Close();
        }
    }
}
