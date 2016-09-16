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
    public partial class YUPOpenURLForm : Form
    {
        public YUPOpenURLForm()
        {
            InitializeComponent();
        }

        public YUPOpenURLForm(string url)
        {
            InitializeComponent();

            urlTextBox.Text = url;
        }

        private void YUPOpenURLForm_Load(object sender, EventArgs e)
        {
            foreach (Types.AvailablePlugin pluginOn in YUP.PluginServices.AvailablePlugins)
            {
                pluginComboBox.Items.Add(pluginOn.Instance);
            }

            pluginComboBox.SelectedIndex = 0;

            CheckURL();
        }

        private void pluginComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadButton.Enabled = (pluginComboBox.SelectedIndex != 0 && urlTextBox.Text != string.Empty);
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckURL();
        }

        private void CheckURL()
        {
            if (urlTextBox.Text != string.Empty)
            {
                foreach (object pluginItem in pluginComboBox.Items)
                {
                    IModule pluginOn = pluginItem as IModule;

                    if (pluginOn != null)
                    {
                        if (pluginOn.CheckURL(urlTextBox.Text))
                        {
                            pluginComboBox.SelectedItem = pluginOn;
                            urlStatusIcon.Image = (Image)Resources.tick;
                            break;
                        }
                        else
                        {
                            urlStatusIcon.Image = (Image)Resources.cross;
                        }
                    }
                }
            }
            else
            {
                urlStatusIcon.Image = null;
            }

            loadButton.Enabled = (pluginComboBox.SelectedIndex != 0 && urlTextBox.Text != string.Empty);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
