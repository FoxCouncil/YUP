using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup.Forms.PlaylistForms
{
    public partial class NewPlaylistForm : Form
    {
        public NewPlaylistForm()
        {
            InitializeComponent();
        }

        private void NewPlaylistForm_Load(object sender, EventArgs e)
        {
            newNameTextBox.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void newNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (newNameTextBox.Text.Length != 0)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

        public string NewPlaylistName
        {
            get
            {
                return newNameTextBox.Text;
            }
        }

        private void newNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && newNameTextBox.Text != string.Empty)
            {
                okButton.PerformClick();
            }
        }
    }
}
