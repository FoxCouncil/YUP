using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.Yum;
using Ca.Magrathean.Yup.DB;

namespace Ca.Magrathean.Yup.Forms.PlaylistForms
{
    public partial class AddToPlaylistForm : Form
    {
        private IFLV m_video;
        private Dictionary<int, Playlist> m_playlist;

        public AddToPlaylistForm(IFLV video)
        {
            InitializeComponent();

            this.m_video = video;

            YUP.PlaylistsDatabase.PlaylistUpdated += new Ca.Magrathean.Yup.DB.PlaylistUpdatedDelegate(Playlists_PlaylistUpdated);

            playlistList.ItemCheck += new ItemCheckEventHandler(playlistList_ItemCheck);
        }

        private void AddToPlaylistForm_Load(object sender, EventArgs e)
        {
            videoTitleLabel.Text = m_video.Title;
            videoThumbnail.ImageLocation = m_video.ThumbnailImage.ToString();
            videoLengthLabel.Text = m_video.Length.ToString();
            videoAuthorLink.Text = m_video.Author;
            videoViewsLabel.Text = string.Format("{0:#,#}", m_video.ViewCount);
            videoYUMIcon.Image = (Image)m_video.Module.ModuleIcon.ToBitmap();

            YUP.PlaylistsDatabase.ReloadPlaylists();
        }

        void Playlists_PlaylistUpdated(Dictionary<int, Playlist> playlist)
        {
            this.m_playlist = playlist;

            playlistList.Items.Clear();

            foreach (Playlist item in playlist.Values)
            {
                playlistList.Items.Add(item);
            }
        }

        void playlistList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            addButton.Enabled = (playlistList.CheckedItems.Count == 0);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            foreach (Playlist playlist in playlistList.CheckedItems)
            {
                playlist.AddVideo(m_video);
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
