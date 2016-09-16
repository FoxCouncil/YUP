using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using Ca.Magrathean.Yup.Yum;
using System.Diagnostics;
using System.Threading;

namespace Ca.Magrathean.Yup.DB
{
    public delegate void PlaylistUpdatedDelegate(Dictionary<int, Playlist> playlist);

    // TODO: Must change playlists to a Windows's user directory.
    public class PlaylistsDatabase
    {
        #region Constants
        public const string PlaylistFileExtension = ".yip";
        public const string PlaylistDirectory = "Playlists";
        #endregion

        #region Private Members
        private string m_directoryPath;
        private Dictionary<int, Playlist> m_playlists = new Dictionary<int, Playlist>();
        #endregion

        #region Events
        public event PlaylistUpdatedDelegate PlaylistUpdated;
        #endregion

        #region Constructor
        public PlaylistsDatabase()
        {
            m_directoryPath = YUP.UserDocuments + @"\" + PlaylistDirectory;

            if (!Directory.Exists(m_directoryPath))
            {
                Directory.CreateDirectory(m_directoryPath);
            }
            
            ReloadPlaylists();
        }
        #endregion

        #region Public Methods
        public void ReloadPlaylists()
        {
            int i = 0;

            m_playlists.Clear();

            string[] playlistFiles = Directory.GetFiles(m_directoryPath);

            foreach (string playlistFile in playlistFiles)
            {
                FileInfo playlistFileInfo = new FileInfo(playlistFile);

                if (playlistFileInfo.Extension == PlaylistFileExtension)
                {
                    m_playlists.Add(i++, new Playlist(playlistFile));
                }
            }

            if (PlaylistUpdated != null)
            {
                PlaylistUpdated(m_playlists);
            }
        }

        public bool CreateNewPlaylist(string name)
        {
            bool success = true;

            try
            {
                SQLiteConnection.CreateFile(m_directoryPath + @"\" + name + ".yip");
            }
            catch (System.Exception)
            {
                success = false;
            }

            return success;
        }

        public bool RenamePlaylist(int index, string newName)
        {
            return m_playlists[index].Rename(newName);
        }

        internal void Delete(int index)
        {
            m_playlists[index].Delete();
            
            ReloadPlaylists();
        }

        internal int TotalVideos(int index)
        {
            return m_playlists[index].TotalVideos;
        }

        internal string GetFileName(int index)
        {
            return m_playlists[index].FileName;
        }

        internal Playlist GetPlaylist(int index)
        {
            return m_playlists[index];
        }
        #endregion

        #region Public Properties
        public string DirectoryPath
        {
            get
            {
                return m_directoryPath;
            }
        }

        public int PlaylistCount
        {
            get
            {
                return m_playlists.Count;
            }
        }
        #endregion
    }

    public class Playlist
    {
        #region Private Members
        private string m_filename;
        private SQLiteConnection m_sql;
        private bool m_failedLoad = false;
        private Dictionary<int, PlaylistVideo> m_videos = new Dictionary<int, PlaylistVideo>();
        #endregion

        #region Constructor
        public Playlist(string path)
        {
            OpenDatabaseFile(path);
        }
        #endregion

        #region Public Methods
        public void AddVideo(IFLV video)
        {
            string name = video.Title;
            int parent = 0;
            string videoID = video.VideoID;
            string yumFileName = video.Module.Name;

            using(SQLiteCommand query = m_sql.CreateCommand())
            {
                query.CommandText = "INSERT INTO playlist (name, parent, videoID, yumFileName) VALUES(@name, @parent, @videoID, @yumFileName)";
                
                query.Parameters.AddWithValue("@name", name);
                query.Parameters.AddWithValue("@parent", parent);
                query.Parameters.AddWithValue("@videoID", videoID);
                query.Parameters.AddWithValue("@yumFileName", yumFileName);

                query.ExecuteNonQuery();
            }

            LoadVideos();
        }

        public void RemoveVideo(IFLV video)
        {
            RemoveVideo(video.VideoID);
        }

        public void RemoveVideo(string videoID)
        {
            using (SQLiteCommand query = m_sql.CreateCommand())
            {
                query.CommandText = "DELETE FROM playlist WHERE videoID = @videoID";

                query.Parameters.AddWithValue("@videoID", videoID);

                query.ExecuteNonQuery();
            }

            LoadVideos();
        }

        public bool Rename(string newName)
        {
            string newFilePath = m_filename.Replace((new FileInfo(m_filename)).Name, newName + ".yip");

            if (!File.Exists(newFilePath))
            {
                m_sql.Close();
                m_sql.Dispose();
                m_sql = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();

                int i = 0;

                while (YUP.IsFileOpen(m_filename))
                {
                    Debug.WriteLine("File is open, cannot delete. Trying again. Retries: " + (++i).ToString());
                }

                File.Move(m_filename, newFilePath);

                OpenDatabaseFile(newFilePath);

                return true;
            }

            return false;
        }

        public void LoadVideos()
        {
            if (m_sql.State == System.Data.ConnectionState.Open)
            {
	            using (SQLiteCommand query = m_sql.CreateCommand())
	            {
	                query.CommandText = "SELECT * FROM playlist";
	
	                using (SQLiteDataReader results = query.ExecuteReader())
	                {
	                    m_videos.Clear();
	
	                    if (results.HasRows)
	                    {
	                        int i = 0;
	
	                        while (results.Read())
	                        {
	                            m_videos.Add(i++, new PlaylistVideo(results));
	                        }
	                    }
	                }
	            }
            }
            else
            {
                Debug.WriteLine("I tried to load videos while object was closed.");
            }
        }

        internal void Delete()
        {
            m_sql.Close();
            m_sql.Dispose();
            m_sql = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            int i = 0;

            while(YUP.IsFileOpen(m_filename))
            {
                Debug.WriteLine("File is open, cannot delete. Trying again. Retries: " + (++i).ToString());
            }

            File.Delete(m_filename);
        }
        #endregion

        #region Private Methods
        private void CheckDatabaseTables()
        {
            using(SQLiteCommand query = m_sql.CreateCommand())
            {
                query.CommandText = "SELECT name FROM sqlite_master WHERE type='table'";

                using (SQLiteDataReader reader = query.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        CreateTables();
                    }
                }
            }
        }

        private void CreateTables()
        {
            using (SQLiteCommand query = m_sql.CreateCommand())
            {
                query.CommandText = "CREATE TABLE playlist (id INTEGER PRIMARY KEY, name TEXT, parent NUMERIC, videoID TEXT, yumFileName TEXT)";
                query.ExecuteNonQuery();
            }
        }

        private void OpenDatabaseFile(string filename)
        {
            m_filename = filename;
            m_sql = new SQLiteConnection("Data Source=" + m_filename + ";");

            try
            {
                m_sql.Open();
            }
            catch (System.Exception)
            {
                m_failedLoad = true;
                m_sql.Close();
            }

            CheckDatabaseTables();

            LoadVideos();
        }
        #endregion

        #region Public Properties
        public string FileName
        {
            get 
            { 
                return (new FileInfo(m_filename)).Name; 
            }
        }

        public string Name
        {
            get
            {
                return (new FileInfo(m_filename)).Name.Replace(".yip", string.Empty);
            }
        }

        public bool FailedLoad
        {
            get 
            { 
                return m_failedLoad; 
            }
        }

        public int TotalVideos
        {
            get 
            { 
                return m_videos.Count; 
            }
        }

        public Dictionary<int, PlaylistVideo> Videos
        {
            get
            {
                return m_videos;
            }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return this.FileName.Replace(".yip", "");
        }
        #endregion
    }

    public class PlaylistVideo
    {
        #region Private Members
        private int _id;
        private string _name;
        private int _parent;
        private string _videoID;
        private string _yumName;
        #endregion

        #region Constructor
        public PlaylistVideo(SQLiteDataReader result)
        {
            _id = result.GetInt32(0);
            _name = result.GetString(1);
            _parent = result.GetInt32(2);
            _videoID = result.GetString(3);
            _yumName = result.GetString(4);
        }
        #endregion

        #region Public Properties
        public int ID
        {
            get
            { 
                return _id; 
            }
        }

        public string Name
        {
            get
            { 
                return _name; 
            }
        }

        public int Parent
        {
            get 
            { 
                return _parent; 
            }
        }

        public string VideoID
        {
            get 
            { 
                return _videoID; 
            }
        }

        public string YumName
        {
            get 
            {
                return _yumName; 
            }
        }
        #endregion
    }
}
