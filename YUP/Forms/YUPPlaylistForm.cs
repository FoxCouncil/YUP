using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.DB;
using Ca.Magrathean.Yup.Properties;
using Ca.Magrathean.Yup.Forms.PlaylistForms;
using Ca.Magrathean.Yup.Interfaces;
using Ca.Magrathean.Yup.Yum;
using Ca.Magrathean.Yup.Types;
using TaskDialog;
using System.IO;

namespace Ca.Magrathean.Yup.Forms
{
    public partial class YUPPlaylistForm : Form, IFormStateSerialize
    {
        #region Private Member Variables
        private DataGridViewRow m_clickedRow;
        private TreeNode m_clickedPlaylist;
        private Playlist m_selectedPlaylist;
        private PlaylistVideo m_selectedPlaylistVideo;
        #endregion

        #region Constructor
        /// <summary>
        /// Create an instance of the YUP Playlist Form.
        /// </summary>
        public YUPPlaylistForm()
        {
            InitializeComponent();

            playlistTreeImageList.Images.Add(Resources.book);
            playlistTreeImageList.Images.Add(Resources.book_open);
            playlistTreeView.SelectedImageIndex = 1;

            YUP.PlaylistsDatabase.PlaylistUpdated += new PlaylistUpdatedDelegate(Playlists_PlaylistUpdated);
        }
        #endregion

        #region Form Event Methods
        /// <summary>
        /// Loads the playlist when the form is first loaded.
        /// </summary>
        /// <param name="sender">The form that triggered the events</param>
        /// <param name="e">The event arguments</param>
        private void YUPPlaylistForm_Load(object sender, EventArgs e)
        {
            YUP.PlaylistsDatabase.ReloadPlaylists();
        }

        private void YUPPlaylistForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        #endregion

        #region TreeView Events
        private void playlistTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            // Handy storage container for mouse position.
            Point mousePosition = new Point(e.X, e.Y);

            // Get a node at mousePosition, null if not over a node.
            m_clickedPlaylist = playlistTreeView.GetNodeAt(mousePosition);

            // Has the user clicked on a area with a node?
            if (m_clickedPlaylist != null)
            {
                // Is root node selected?
                if (m_clickedPlaylist.Level != 0)
                {
                    // A node has been selected.
                    if (playlistTreeView.SelectedNode != m_clickedPlaylist)
                    {
                        TreeNodeSelectedState(true);
                    }
                }
                else
                {
                    // The root node was selected.
                    TreeNodeSelectedState(false);
                }
            }
            else
            {
                // Nothing is selected! :(
                TreeNodeSelectedState(false);
            }

            // Set the selection even if null.
            playlistTreeView.SelectedNode = m_clickedPlaylist;

            // Open context menu.
            if (e.Button == MouseButtons.Right)
            {
                treeViewContextMenu.Show(playlistTreeView, mousePosition);
            }
        }

        private void playlistTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            // This TreeView does not support collapsing of nodes. 
            e.Cancel = true;
        }

        private void playlistTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                e.CancelEdit = true;
            }
        }

        private void playlistTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == string.Empty || e.Label == null)
            {
                e.CancelEdit = true;
                return;
            }

            if (!YUP.PlaylistsDatabase.RenamePlaylist(e.Node.Index, e.Label))
            {
                e.CancelEdit = true;
            }
        }
        #endregion

        #region TreeView ToolStrip Events
        private void newPlaylistButton_Click(object sender, EventArgs e)
        {
            using (NewPlaylistForm newPlaylistForm = new NewPlaylistForm())
            {
                if (newPlaylistForm.ShowDialog() == DialogResult.OK)
                {
                    YUP.PlaylistsDatabase.CreateNewPlaylist(newPlaylistForm.NewPlaylistName);

                    YUP.PlaylistsDatabase.ReloadPlaylists();
                }
            }
        }

        private void reloadPlaylistsButton_Click(object sender, EventArgs e)
        {
            YUP.PlaylistsDatabase.ReloadPlaylists();
        }

        private void videoAddButton_Click(object sender, EventArgs e)
        {
            AddVideoByURL();
        }

        private void AddVideoByURL()
        {
            AddVideoByURL(string.Empty);
        }

        private void AddVideoByURL(string url)
        {
            using (YUPOpenURLForm openURLForm = new YUPOpenURLForm(url))
            {
                if (openURLForm.ShowDialog() == DialogResult.OK)
                {
                    IModule plugin = openURLForm.pluginComboBox.SelectedItem as IModule;
                    IFLV flv = plugin.FetchURL(new Uri(openURLForm.urlTextBox.Text));

                    if (flv.Failed)
                    {
                        MessageBox.Show("This is not a valid " + plugin.Name + " URL.", "Error");
                    }
                    else
                    {
                        m_selectedPlaylist.AddVideo(flv);

                        LoadGrid(m_clickedPlaylist.Index);
                    }
                }
            }
        }

        private void deletePlaylistButton_Click(object sender, EventArgs e)
        {
            if (playlistTreeView.SelectedNode.FullPath != "Playlists")
            {
                int index = playlistTreeView.SelectedNode.Index;

                if (ConfirmDeleteDialog(index) == DialogResult.Yes)
                {
                    YUP.PlaylistsDatabase.Delete(index);
                }
            }
        }

        private void videoDeleteButton_Click(object sender, EventArgs e)
        {
            if (ConfirmDeleteEntryDialog(m_selectedPlaylistVideo.Name, playlistTreeView.SelectedNode.Index) == DialogResult.Yes)
            {
                m_selectedPlaylist.RemoveVideo(m_selectedPlaylistVideo.VideoID);

                LoadGrid(m_clickedPlaylist.Index);
            }
        }

        private void playPlaylistButton_Click(object sender, EventArgs e)
        {
            List<IFLV> playlist = new List<IFLV>();

            foreach (PlaylistVideo pv in m_selectedPlaylist.Videos.Values)
            {
                AvailablePlugin plugin = YUP.PluginServices.AvailablePlugins.Find(pv.YumName);

                playlist.Add(plugin.Instance.FetchVideoByID(pv.VideoID));
            }

            YUP.MainForm.LoadPlaylist(playlist.ToArray());
            
            playlist.Clear();
            playlist = null;
        }

        private void playVideoButton_Click(object sender, EventArgs e)
        {
            AvailablePlugin plugin = YUP.PluginServices.AvailablePlugins.Find(m_selectedPlaylistVideo.YumName);

            YUP.MainForm.LoadVideo(plugin.Instance.FetchVideoByID(m_selectedPlaylistVideo.VideoID));
        }

        private void playlistDataGrid_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("UniformResourceLocator"))
            {
                object data = e.Data.GetData("UniformResourceLocator");
                MemoryStream ms = data as MemoryStream;
                byte[] bytes = ms.ToArray();
                Encoding encod = Encoding.ASCII;
                string str = encod.GetString(bytes);
                string url = str.Substring(0, str.IndexOf('\0'));

                if (YUP.PluginServices.CheckURL(url))
                {
                    e.Effect = DragDropEffects.Link;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void playlistDataGrid_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("UniformResourceLocator"))
            {
                object data = e.Data.GetData("UniformResourceLocator");
                MemoryStream ms = data as MemoryStream;
                byte[] bytes = ms.ToArray();
                Encoding encod = Encoding.ASCII;
                string str = encod.GetString(bytes);
                string url = str.Substring(0, str.IndexOf('\0'));

                IModule plugin;

                if (YUP.PluginServices.CheckURL(url, out plugin))
                {
                    IFLV flv = plugin.FetchURL(new Uri(url));
                    m_selectedPlaylist.AddVideo(flv);
                    LoadGrid(playlistTreeView.SelectedNode.Index);
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void editPlaylistButton_Click(object sender, EventArgs e)
        {
            playlistTreeView.SelectedNode.BeginEdit();
        }
        #endregion

        #region DataGrid Events
        private void playlistDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePosition = new Point(e.X, e.Y);

            DataGridView.HitTestInfo hitInfo = playlistDataGrid.HitTest(e.X, e.Y);

            if (hitInfo.Type == DataGridViewHitTestType.None)
            {
                playlistDataGrid.ClearSelection();

                DataGridSelectedState(false);
            }
            else if (hitInfo.Type == DataGridViewHitTestType.Cell)
            {
                m_clickedRow = playlistDataGrid.Rows[hitInfo.RowIndex];

                playlistDataGrid.Rows[hitInfo.RowIndex].Selected = true;

                m_selectedPlaylistVideo = m_selectedPlaylist.Videos[hitInfo.RowIndex];

                DataGridSelectedState(true);
            }

            if (e.Button == MouseButtons.Right)
            {
                dataGridContextMenu.Show(playlistDataGrid, mousePosition);
            }
        }
        #endregion

        #region Playlist Event Methods
        /// <summary>
        /// When the playlist has finally finished loading, it populates the treeview.
        /// </summary>
        /// <param name="playlists">The Playlist Dictionary</param>
        void Playlists_PlaylistUpdated(Dictionary<int, Playlist> playlists)
        {
            playlistTreeView.Nodes[0].Nodes.Clear();

            foreach (Playlist playlist in playlists.Values)
            {
                playlistTreeView.Nodes[0].Nodes.Add(new TreeNode(playlist.FileName.Replace(".yip", "")));
            }

            playlistTreeView.Nodes[0].Expand();
            playlistTreeView.SelectedNode = playlistTreeView.Nodes[0];

            // Set RootNode Apple Effect
            int playlistCount = YUP.PlaylistsDatabase.PlaylistCount;

            if (playlistCount == 1)
            {
                playlistTreeView.Nodes[0].Text = "Playlist";
            }
            else
            {
                playlistTreeView.Nodes[0].Text = "Playlists (" + YUP.PlaylistsDatabase.PlaylistCount.ToString() + ")";
            }

            TreeNodeSelectedState(false);
        }
        #endregion

        #region Private Methods
        private void TreeNodeSelectedState(bool isSelected)
        {
            // Enable/Disable Buttons On Toolbar and ContextMenu's
            playlistDataGrid.Enabled =
            editPlaylistButton.Enabled =
            editPlaylistToolStripMenuItem.Enabled =
            deletePlaylistButton.Enabled =
            deletePlaylistToolStripMenuItem.Enabled =
            playPlaylistButton.Enabled =
            videoAddButton.Enabled =
            playlistDataGridToolStrip.Visible = isSelected;
            
            if (isSelected)
            {
                // Set Status Info
                textInfoStatusLabel.Text = "Total Videos:";

                numberInfoStatusLabel.Text = YUP.PlaylistsDatabase.TotalVideos(m_clickedPlaylist.Index).ToString();

                LoadGrid(m_clickedPlaylist.Index);
            }
            else
            {
                textInfoStatusLabel.Text = "Total Playlists:";

                numberInfoStatusLabel.Text = YUP.PlaylistsDatabase.PlaylistCount.ToString();

                ClearGrid();
            }
        }

        private void DataGridSelectedState(bool isSelected)
        {
            videoDeleteButton.Enabled =
            deleteVideoToolStripMenuItem.Enabled =
            playVideoButton.Visible =
            playVideoButtonSeparator.Visible = 
            playThisVideoToolStripMenuItem.Visible =
            playThisVideoToolStripSeparator.Visible = isSelected;

            playPlaylistButton.Visible = 
            playPlaylistToolStripSeparator.Visible = 
            playThisPlaylistToolStripMenuItem.Visible =
            playThisPlaylistToolStripSeparator.Visible = (playlistDataGrid.Rows.Count != 0);
        }
        
        private void LoadGrid(int index)
        {
            playlistDataGrid.Enabled = playlistDataGrid.Visible = true;

            m_selectedPlaylist = YUP.PlaylistsDatabase.GetPlaylist(index);

            playlistDataGrid.Rows.Clear();

            foreach (PlaylistVideo pv in m_selectedPlaylist.Videos.Values)
            {
                playlistDataGrid.Rows.Add(new string[]{pv.ID.ToString(), pv.Name, pv.YumName});
            }

            playlistDataGrid.ClearSelection();

            DataGridSelectedState(false);
        }

        private void ClearGrid()
        {
            playlistDataGrid.Enabled = playlistDataGrid.Visible = false;

            DataGridSelectedState(false);
        }
        #endregion

        #region Helper Methods
        private DialogResult ConfirmDeleteDialog(int index)
        {
            return cTaskDialog.ShowTaskDialogBox(this, "Confirmation", "Delete this playlist?", playlistTreeView.SelectedNode.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, eTaskDialogButtons.YesNo, eSysIcons.Warning, eSysIcons.Warning);
        }

        private DialogResult ConfirmDeleteEntryDialog(string entryName, int playlistIndex)
        {
            return cTaskDialog.ShowTaskDialogBox(this, "Confirmation", "Delete this video?", entryName, "Playlist: " + playlistTreeView.SelectedNode.Text, string.Empty, string.Empty, string.Empty, string.Empty, eTaskDialogButtons.YesNo, eSysIcons.Warning, eSysIcons.Warning);
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
                Show();
            }
        }

        public bool FormVisible
        {
            get
            {
                bool? formVisible = YUP.SettingsDatabase.GetBoolSetting("YUPPlaylistFormVisible");

                if (!formVisible.HasValue)
                {
                    YUP.SettingsDatabase.SetBoolSetting("YUPPlaylistFormVisible", false);

                    return false;
                }
                else
                {
                    return formVisible.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetBoolSetting("YUPPlaylistFormVisible", value);

                Visible = value;
            }
        }

        public Point FormLocation
        {
            get
            {
                Point formLocation = YUP.SettingsDatabase.GetPointSetting("YUPPlaylistFormLocation");

                if (formLocation.IsEmpty)
                {
                    Point defaultPoint = new Point(0, 0);

                    YUP.SettingsDatabase.SetPointSetting("YUPPlaylistFormLocation", defaultPoint);

                    return defaultPoint;
                }
                else
                {
                    return formLocation;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetPointSetting("YUPPlaylistFormLocation", value);

                Location = value;
            }
        }

        public Size FormSize
        {
            get
            {
                Size formSize = YUP.SettingsDatabase.GetSizeSetting("YUPPlaylistFormSize");

                if (formSize.IsEmpty)
                {
                    Size defaultSize = new Size(640, 480);

                    YUP.SettingsDatabase.SetSizeSetting("YUPPlaylistFormSize", defaultSize);

                    return defaultSize;
                }
                else
                {
                    return formSize;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetSizeSetting("YUPPlaylistFormSize", value);

                Size = value;
            }
        }

        public FormWindowState FormWindowState
        {
            get
            {
                string formWindowState = YUP.SettingsDatabase.GetStringSetting("YUPPlaylistFormWindowState");

                if (formWindowState == string.Empty)
                {
                    YUP.SettingsDatabase.SetStringSetting("YUPPlaylistFormWindowState", FormWindowState.Normal.ToString());

                    return FormWindowState.Normal;
                }
                else
                {
                    return (FormWindowState)Enum.Parse(typeof(FormWindowState), formWindowState);
                }
            }
            set
            {
                YUP.SettingsDatabase.SetStringSetting("YUPPlaylistFormWindowState", value.ToString());

                WindowState = value;
            }
        }
        #endregion
    }
}
