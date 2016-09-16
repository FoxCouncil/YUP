using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.Yum;

namespace Ca.Magrathean.Yup.Controls
{
    public partial class IFLVControl : UserControl
    {
        private IFLV flv; 

        public IFLVControl(IFLV flvSource)
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.flv = flvSource;

            this.FLVTitle.Text = flvSource.Title;
            this.FLVAuthorLink.Text = flvSource.Author;
            this.FLVThumbnailImage.ImageLocation = flvSource.ThumbnailImage.ToString();

            if (flvSource.Length.TotalHours > 1)
            {
            	this.FLVTime.Text = flvSource.Length.ToString();
            }
            else
            {
                this.FLVTime.Text = flvSource.Length.Minutes.ToString() + ":" + flvSource.Length.Seconds.ToString("D2");
            }
        }

        public IFLV FLV
        {
            get 
            { 
                return flv; 
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            InvokeOnClick(this, new EventArgs());
        }

        private void IFLVControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
        }

        private void IFLVControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}