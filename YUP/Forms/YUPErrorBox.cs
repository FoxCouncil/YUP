using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup.Forms
{
    public partial class YUPErrorBox : Form
    {
        private Size DetailsClosedSize = new Size(469, 218);
        private Size DetailsOpenSize = new Size(469, 436);
        private bool _isDetailsOpen = false;
        private Exception _exception;

        public YUPErrorBox(Exception e)
        {
            InitializeComponent();

            this.errorDetails.Text = e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;

            _exception = e;
        }

        private void YUPErrorBox_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Magrathean_Technologies_Logo;
            this.Size = DetailsClosedSize;
        }

        private void detailsToggleButton_Click(object sender, EventArgs e)
        {
            _isDetailsOpen = !_isDetailsOpen;

            if (_isDetailsOpen)
            {
                this.detailsToggleButton.Text = "Hide Details";
                this.Size = DetailsOpenSize;
            }
            else
            {
                this.detailsToggleButton.Text = "Show Details";
                this.Size = DetailsClosedSize;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
