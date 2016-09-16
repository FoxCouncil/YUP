using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.Yum;
using Ca.Magrathean.Yup.Properties;

namespace Ca.Magrathean.Yup.Forms
{
    public partial class YUPVideoInfoForm : Form
    {
        private IFLV _video;

        public YUPVideoInfoForm(IFLV video)
        {
            InitializeComponent();

            _video = video;
        }

        private void YUPVideoInfoForm_Load(object sender, EventArgs e)
        {
            videoTitleLabel.Text = _video.Title;
            videoThumbnail.ImageLocation = _video.ThumbnailImage.ToString();
            videoLengthLabel.Text = _video.Length.ToString();
            videoAuthorLink.Text = _video.Author;
            videoViewsLabel.Text = string.Format("{0:#,#}", _video.ViewCount);

            if (_video.HDEnabled)
            {
                definitionPictureBox.Image = Resources.HD;
            }
            else
            {
                definitionPictureBox.Image = Resources.SD;
            }
        }
    }
}
