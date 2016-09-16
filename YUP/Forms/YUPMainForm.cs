using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Ca.Magrathean.Yup.Flash;
using Ca.Magrathean.Yup.Interfaces;
using Ca.Magrathean.Yup.Properties;
using Ca.Magrathean.Yup.Forms;
using Ca.Magrathean.Yup.Yum;
using System.Threading;
using Ca.Magrathean.Yup.Forms.Exporting;
using System.IO;

namespace Ca.Magrathean.Yup.Forms
{
    public delegate void EndOfVideoEventDelegate();

    public partial class YUPMainForm : Form, IFormStateSerialize
    {
        #region Constants
        public const string YUPSWF = "YUPplayer.swf";
        public static Size DefaultMainFormSize = new Size(590, 549);
        public static Point ZeroCommaZero = new Point(0, 0);
        #endregion

        #region Private Fields
        /// <summary>
        /// This variable is to support the seekbar functionality.
        /// If the user is 'scrubbing' the seekbar, then do not update.
        /// </summary>
        private bool m_shouldUpdateSeekBar = true;

        /// <summary>
        /// A boolean to keep the fullscreen state at hand at all times.
        /// </summary>
        private bool m_inFullscreen = false;

        /// <summary>
        /// Keep minimized state on hand, to make sure we're coming from
        /// a minimized to a restored state. This way, paused videos wont play
        /// if the window is just maximized then restored.
        /// </summary>
        private bool m_hasBeenMinimized = false;

        /// <summary>
        /// Should we display the status in the status bad.
        /// </summary>
        private bool m_displayStatusString = true;

        /// <summary>
        /// Keep a status of the minimizing to tray feature.
        /// </summary>
        private bool m_isMinimizedToTray = false;

        /// <summary>
        /// The path to the SWF for the Flash OCX to use.
        /// </summary>
        private string m_SWFPath;

        /// <summary>
        /// Keep the currently playing IFLV on hand.  
        /// </summary>
        private static IFLV m_currentlyPlayingVideo;

        /// <summary>
        /// The current status of the video.
        /// </summary>
        private static VideoState m_currentVideoState;

        /// <summary>
        /// Keep the current playback type on hand.
        /// </summary>
        private static bool m_playlistMode = false;

        /// <summary>
        /// Keep the current playlist of IFLV's on hand.
        /// </summary>
        private static IFLV[] m_currentPlaylistVideos;

        /// <summary>
        /// Keep the current position in the array in the playlist.
        /// </summary>
        private static int m_playlistPos;

        /// <summary>
        /// Keep the current total
        /// </summary>
        private static int m_playlistCount;
        #endregion

        #region Public Events
        public event YUPFormMaximized WindowMaximized;
        public event YUPFormMinimized WindowMinimized;
        public event YUPFormRestored WindowRestored;
        public event EndOfVideoEventDelegate EndOfVideoEvent;
        #endregion

        #region Constructor
        /// <summary>
        /// YUPMainForm Class Constructor, singleton from Application.Run
        /// This behavior will change for crossplatform
        /// </summary>
        public YUPMainForm()
        {
            // Bring in the drones, SWF style.
            m_SWFPath = YUP.ExtractResource(YUPSWF);

            // This forms icon.
            this.Icon = Resources.YUP;

            // WinForm's Designer Support
            InitializeComponent();

            // Setup The FlashPlayer control
            SetupFlashPlayer();
            
            // Do Windows
            SetupWindows();

            // Do any additional UI setup here.
            SetupUI();

            // Let's extend WinForms
            this.WindowMinimized += new YUPFormMinimized(YUPMainForm_WindowMinimized);
            this.WindowRestored += new YUPFormRestored(YUPMainForm_WindowRestored);

            this.pluginWorker.DoWork += new DoWorkEventHandler(pluginWorker_DoWork);
            this.pluginWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(pluginWorker_RunWorkerCompleted);

            this.EndOfVideoEvent += new EndOfVideoEventDelegate(YUPMainForm_EndOfVideoEvent);

            Application.Idle += new EventHandler(Application_Idle);
        }
        #endregion

        #region FlashPlayer Event Methods
        void FlashPlayer_VideoStateChanged(VideoState vs)
        {
            m_currentVideoState = vs;

            this.Text = this.systrayIcon.Text = "YUP - " + vs.ToString();

            if (vs == VideoState.Playing ||
                    vs == VideoState.Loaded ||
                    vs == VideoState.Seeking ||
                    vs == VideoState.Buffering ||
                    vs == VideoState.Paused ||
                    vs == VideoState.Rewinding ||
                    vs == VideoState.Stopped)
            {
                if (!spinner.Visible)
                {
                    if (m_displayStatusString)
                    {
                        this.statusBar_Label.Text = vs.ToString() + ": " + m_currentlyPlayingVideo.Title;
                    }
                    else
                    {
                        this.statusBar_Label.Text = m_currentlyPlayingVideo.Title;
                    }
                }

                controlBar_Separator1.Visible = controlBar_Next.Visible = controlBar_Previous.Visible = controlBar_PlaylistStatusText.Visible = m_playlistMode;

                controlBar_PlaylistStatusText.Text = (m_playlistPos + 1).ToString() + "/" + m_playlistCount.ToString();
            }
            else if (vs == VideoState.Loading)
            {
                this.statusBar_Label.Text = vs.ToString();
            }

            switch (vs)
            {
                case VideoState.Playing:
                {
                    controlBar_Play.Checked = true;
                    controlBar_Pause.Checked = false;
                    controlBar_Stop.Checked = false;
                }
                break;

                case VideoState.Paused:
                {
                    controlBar_Play.Checked = false;
                    controlBar_Pause.Checked = true;
                    controlBar_Stop.Checked = false;
                }
                break;

                case VideoState.Stopped:
                {
                    controlBar_Play.Checked = false;
                    controlBar_Pause.Checked = false;
                    controlBar_Stop.Checked = true;
                }
                break;

                case VideoState.Rewinding:
                {
                    // TODO: Rewind Event Handling for Repeat
                    // Note: Make sure to take into account this event is fired if FlashPlayer.Stop() is called as well.
                }
                break;

                case VideoState.Loaded:
                {
                    InterfaceUnPause();
                }
                break;
            }

            if (m_currentlyPlayingVideo != null)
            {
                statusBar_Icon.Image = (Image)m_currentlyPlayingVideo.Module.ModuleIcon.ToBitmap();
            }

            controlBar_VideoInfo.Enabled = (m_currentlyPlayingVideo != null);
        }

        void FlashPlayer_PlayheadUpdate(int currentTime, int totalTime)
        {
            if (m_shouldUpdateSeekBar)
            {
                seekBar.Maximum = totalTime;

                if (currentTime < totalTime)
                {
                    seekBar.Value = currentTime;
                }
                else
                {
                    seekBar.Value = totalTime;
                }
            }

            TimeSpan currentTS = new TimeSpan(0, 0, 0, 0, currentTime);
            TimeSpan totalTS = new TimeSpan(0, 0, 0, 0, totalTime);

            if (totalTS.Hours == 0)
            {
                statusBar_CurrentTime.DigitalDisplay.DigitText = currentTS.Minutes.ToString() + ":" + currentTS.Seconds.ToString("00");
                statusBar_TotalTime.DigitalDisplay.DigitText = totalTS.Minutes.ToString() + ":" + totalTS.Seconds.ToString("00");
            }
            else
            {
                statusBar_CurrentTime.DigitalDisplay.DigitText = currentTS.Hours.ToString() + ":" + currentTS.Minutes.ToString("00") + ":" + currentTS.Seconds.ToString("00");
                statusBar_TotalTime.DigitalDisplay.DigitText = totalTS.Hours.ToString() + ":" + totalTS.Minutes.ToString("00") + ":" + totalTS.Seconds.ToString("00");
            }

            if (currentTime == totalTime)
            {
                if (EndOfVideoEvent != null)
                {
                    EndOfVideoEvent();
                }
            }

        }

        private void FlashPlayer_MouseLeftClick(object sender, EventArgs e)
        {
            FlashPlayer.TogglePause();
        }

        private void FlashPlayer_MouseLeftDoubleClick(object sender, EventArgs e)
        {
            ToggleFullscreen();

            if (FlashPlayer.VideoState == VideoState.Paused)
            {
                FlashPlayer.PlayVideo();
            }
        }

        private void FlashPlayer_MouseRightClick(object sender, EventArgs e)
        {
            playerMenu.Show(Cursor.Position);
        }

        void FlashPlayer_VideoProgress(float bytesLoaded, float bytesTotal)
        {
            // Fix for loading a new video...
            if (!spinner.Visible)
            {
                float percentage = (bytesLoaded / bytesTotal) * 100;

                seekBar.DownloadedPercentage = percentage;
            }
        }
        #endregion

        #region YUP Child Window Methods & Events
        public enum ChildForms
        {
            SearchForm,
            PlaylistForm,
            ExportJobListForm
        }

        private void SetupWindows()
        {
            this.AddOwnedForm(new YUPSearchForm());
            this.AddOwnedForm(new YUPPlaylistForm());
            this.AddOwnedForm(new YUPExportJobsForm());

            foreach (Form yupChildForm in OwnedForms)
            {
                yupChildForm.FormClosing += new FormClosingEventHandler(yupChildForm_FormClosing);
                yupChildForm.KeyDown += new KeyEventHandler(yupChildForm_KeyDown);
            }

            controlBar_Volume.VolumeChanged += new EventHandler(volumeBar_VolumeChanged);
        }

        void yupChildForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ((Form)sender).Hide();
            }
        }

        void yupChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                ((Form)sender).Hide();
            }
        }
        #endregion

        #region Form Setup Methods
        private void SetupUI()
        {
            this.systrayIcon.Icon = Resources.YUP;

            statusBar_Icon.Image = aboutToolStripMenuItem.Image = (Image)Yup.Properties.Resources.YUP.ToBitmap();

            this.spinner.Visible = false;
        }

        private void InitializeSettings()
        {
            statusBar_CurrentTime.DigitColor = Settings.DigitalDisplayColor;
            statusBar_TotalTime.DigitColor = Settings.DigitalDisplayColor;
            seekBar.Color = Settings.DigitalDisplayColor;

            FlashPlayer.MaintainAspectRatio(Settings.MaintainVideoSizeRatio);
            FlashPlayer.RewindVideo(Settings.RewindVideo);

            Settings.YUPDisplayStyle = Settings.YUPDisplayStyle;
            Settings.YUPDisplayStatus = Settings.YUPDisplayStatus;
            Settings.YUPSpinnerSegments = Settings.YUPSpinnerSegments;
            Settings.YUPVolume = controlBar_Volume.VolumeBar.Value = Settings.YUPVolume;
        }
        #endregion

        #region ToolBar Events
        private void playToolBtn_Click(object sender, EventArgs e)
        {
            FlashPlayer.PlayVideo();
        }

        private void pauseToolBtn_Click(object sender, EventArgs e)
        {
            FlashPlayer.TogglePause();
        }

        private void stopToolBtn_Click(object sender, EventArgs e)
        {
            FlashPlayer.StopVideo();
        }

        private void muteToolBtn_Click(object sender, EventArgs e)
        {
            FlashPlayer.ToggleMute();

            if (FlashPlayer.MuteState)
            {
                controlBar_Volume.Enabled = false;
                controlBar_Mute.Image = playerMenu.Items["playerMenu_Mute"].Image = (Image)Yup.Properties.Resources.sound_mute;
                playerMenu.Items["playerMenu_Mute"].Text = "Unmute";
            }
            else
            {
                controlBar_Volume.Enabled = true;
                controlBar_Mute.Image = playerMenu.Items["playerMenu_Mute"].Image = (Image)Yup.Properties.Resources.sound;
                playerMenu.Items["playerMenu_Mute"].Text = "Mute";
            }
        }

        private void volumeBar_VolumeChanged(object sender, EventArgs e)
        {
            Settings.YUPVolume = controlBar_Volume.VolumeBar.Value;
        }

        private void seekBar_MouseDown(object sender, MouseEventArgs e)
        {
            m_shouldUpdateSeekBar = false;
        }

        private void seekBar_ValueChanged(object sender, EventArgs e)
        {
            float time = 0;

            if (seekBar.Value > 0)
            {
                time = seekBar.Value / 1000;
            }

            FlashPlayer.SeekVideo(time);

            m_shouldUpdateSeekBar = true;
        }

        private void ejectButton_Click(object sender, EventArgs e)
        {
            OpenLoadURLForm();
        }

        private void videoInfoButton_Click(object sender, EventArgs e)
        {
            (new YUPVideoInfoForm(m_currentlyPlayingVideo)).Show();
        }

        private void controlBar_Previous_Click(object sender, EventArgs e)
        {
            PlaylistVideoPrevious();
        }

        private void controlBar_Next_Click(object sender, EventArgs e)
        {
            PlaylistVideoNext();
        }
        #endregion

        #region Form Event Methods
        void Application_Idle(object sender, EventArgs e)
        {
            TrackChildWindowStatus();
            TrackExportingAbility();
            TrackUIStatus();
        }

        private void TrackExportingAbility()
        {
            mainMenu_SaveAs.Enabled = (m_currentlyPlayingVideo != null);
        }

        private void YumMainForm_SizeChanged(object sender, EventArgs e)
        {
            DoResize();
        }

        private void YUPMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                {
                    if (m_inFullscreen)
                    {
                        ToggleFullscreen();
                    }
                }
                break;

                case Keys.Space:
                {
                    if (FlashPlayer.VideoState == VideoState.Playing || FlashPlayer.VideoState == VideoState.Paused)
                    {
                        FlashPlayer.TogglePause();
                    }
                    else if (FlashPlayer.VideoState == VideoState.Stopped)
                    {
                        FlashPlayer.Play();
                    }
                }
                break;
            }
        }

        private void YUPMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.systrayIcon.Dispose();
        }

        private void YUPMainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState.Equals(FormWindowState.Maximized) && WindowMaximized != null)
            {
                this.WindowMaximized(this);
            }
            else if (this.WindowState.Equals(FormWindowState.Minimized) && WindowMinimized != null)
            {
                this.WindowMinimized(this);
            }
            else if (this.WindowState.Equals(FormWindowState.Normal) && WindowRestored != null)
            {
                this.WindowRestored(this);
            }
        }

        void YUPMainForm_WindowMinimized(Form formMinimized)
        {
            this.m_hasBeenMinimized = true;

            if (Settings.PauseWhenMinimized)
            {
                FlashPlayer.PauseVideo();
            }

            IconifyWindow(true);
        }

        void YUPMainForm_WindowRestored(Form formRestored)
        {
            if (this.m_hasBeenMinimized)
            {
                this.m_hasBeenMinimized = false;
            }
        }

        private void YUPMainForm_Load(object sender, EventArgs e)
        {
            // Do Settings
            InitializeSettings();

            LoadFormState();

            FlashPlayer.ResetSize(YUPControls.Height);
        }

        private void YUPMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormState();
        }

        void YUPMainForm_EndOfVideoEvent()
        {
            if (m_playlistMode)
            {
                PlaylistVideoNext();
            }
        }

        private void YUPMainForm_DragOver(object sender, DragEventArgs e)
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

        private void YUPMainForm_DragDrop(object sender, DragEventArgs e)
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
                LoadVideo(flv);
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion

        #region Menu Event Methods
        private void singleSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OwnedForms[(int)ChildForms.SearchForm].Visible = !OwnedForms[(int)ChildForms.SearchForm].Visible;

            if (OwnedForms[(int)ChildForms.SearchForm].WindowState == FormWindowState.Minimized)
            {
                OwnedForms[(int)ChildForms.SearchForm].WindowState = FormWindowState.Normal;
            }
        }

        private void playlistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OwnedForms[(int)ChildForms.PlaylistForm].Visible = !OwnedForms[(int)ChildForms.PlaylistForm].Visible;

            if (OwnedForms[(int)ChildForms.PlaylistForm].WindowState == FormWindowState.Minimized)
            {
                OwnedForms[(int)ChildForms.PlaylistForm].WindowState = FormWindowState.Normal;
            }
        }

        private void tasksToolstripButton_Click(object sender, EventArgs e)
        {
            OwnedForms[(int)ChildForms.ExportJobListForm].Visible = !OwnedForms[(int)ChildForms.ExportJobListForm].Visible;

            if (OwnedForms[(int)ChildForms.ExportJobListForm].WindowState == FormWindowState.Minimized)
            {
                OwnedForms[(int)ChildForms.ExportJobListForm].WindowState = FormWindowState.Normal;
            }
        }

        private void mainMenu_Settings_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YUPControls.Visible = !YUPControls.Visible;
            mainMenu_AllControls.Checked = !mainMenu_AllControls.Checked;

            DoResize();
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFullscreen();
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;

            mainMenu_AlwaysOnTop.Checked = this.TopMost;
        }

        private void mainMenu_SaveAs_Click(object sender, EventArgs e)
        {
            using (YUPSaveAsForm saveAsForm = new YUPSaveAsForm(m_currentlyPlayingVideo))
            {
                DialogResult result = saveAsForm.ShowDialog();

                if (result != DialogResult.OK)
                {
                    MessageBox.Show("There was an error with the export process...");
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YUPAboutForm aboutForm = new YUPAboutForm(this.TopMost);
            aboutForm.ShowDialog();
            aboutForm.Dispose();
            aboutForm = null;
        }

        private void seekBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMenu_SeekBar.Checked = seekBar.Visible = !seekBar.Visible;
            DoResize();
        }

        private void playbackControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMenu_PlaybackControls.Checked = controlBar.Visible = !controlBar.Visible;
            DoResize();
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMenu_StatusBar.Checked = statusBar.Visible = !statusBar.Visible;
            DoResize();
        }

        private void openURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLoadURLForm();
        }

        private void maintainRatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.MaintainVideoSizeRatio = true;
        }

        private void exactFitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.MaintainVideoSizeRatio = false;
        }
        #endregion

        #region Notify Context Menu Event Methods
        private void exitYUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yupNotificationIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleIconification();
            }
        }

        private void notificationIconContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                systrayMenu.Items[0].Text = "Hide";
                systrayMenu.Items[0].Image = (Image)Properties.Resources.weather_clouds;
            }
            else
            {
                systrayMenu.Items[0].Text = "Show";
                systrayMenu.Items[0].Image = (Image)Properties.Resources.weather_sun;
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleIconification();
        }
        #endregion

        #region Video Methods
        public void LoadVideo(IFLV flv)
        {
            m_playlistMode = false;

            LoadFLV(flv);
        }

        public void LoadPlaylist(IFLV[] flvs)
        {
            m_playlistMode = true;

            m_currentPlaylistVideos = flvs;
            m_playlistCount = m_currentPlaylistVideos.Length;
            m_playlistPos = 0;

            LoadFLV(m_currentPlaylistVideos[m_playlistPos]);
        }

        public void PlaylistVideoNext()
        {
            if (m_playlistMode)
            {
                m_playlistPos++;

                if (m_playlistPos >= m_playlistCount)
                {
                    m_playlistPos = 0;
                }

                LoadFLV(m_currentPlaylistVideos[m_playlistPos]);
            }
        }

        public void PlaylistVideoPrevious()
        {
            if (m_playlistMode)
            {
                m_playlistPos--;

                if (m_playlistPos < 0)
                {
                    m_playlistPos = m_playlistCount - 1;
                }

                LoadFLV(m_currentPlaylistVideos[m_playlistPos]);
            }
        }

        private void LoadFLV(IFLV flv)
        {
            this.spinner.DisplayString = flv.Module.Name;

            FlashPlayer.StopVideo();

            InterfacePause();            

            this.pluginWorker.RunWorkerAsync(flv);
        }

        #endregion

        #region Background Worker Event Methods
        void pluginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IFLV flv = e.Argument as IFLV;

            if (!flv.Failed)
            {
                m_currentlyPlayingVideo = flv;

                if (Settings.HDEnabled && flv.HDEnabled)
                {
                    e.Result = flv.HDURL;
                }
                else
                {
                    e.Result = flv.URL;
                }
            }
            else
            {
                e.Cancel = true;
                e.Result = flv.FailedReason;
            }
        }

        void pluginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                Uri loadedURL = e.Result as Uri;

                if (loadedURL == null)
                {
                    MessageBox.Show("The video failed to load! \r\n\r\nPlease try again later, or something", "Problem Loading Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    FlashPlayer.LoadVideo(loadedURL.ToString());
                }
            }
            else
            {
                MessageBox.Show("The video failed to load with reason:\r\n\r\n" + e.Result.ToString() + "\r\n\r\nPlease try again later, or something", "Problem Loading Video", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (e.Error is Exception)
            {
                MessageBox.Show(e.Error.ToString());
            }

            pluginWorker.CancelAsync();
        }
        #endregion

        #region Private Methods
        private void TrackUIStatus()
        {
            mainMenu_MaintainRatio.Checked = playerMenu_MaintainRatio.Checked = Settings.MaintainVideoSizeRatio;
            mainMenu_ExactFit.Checked = playerMenu_ExactFit.Checked = !Settings.MaintainVideoSizeRatio;
        }

        private void SetupFlashPlayer()
        {
            FlashPlayer.VideoStateChanged += new PlayerControlVideoStateChanged(FlashPlayer_VideoStateChanged);
            FlashPlayer.PlayheadUpdate += new PlayerControlVideoPlayheadUpdateDelegate(FlashPlayer_PlayheadUpdate);
            FlashPlayer.VideoProgress += new PlayerControlVideoDownloadUpdateDelegate(FlashPlayer_VideoProgress);

            FlashPlayer.Initialize(m_SWFPath);
        }

        private void IconifyWindow(bool shouldIconify)
        {
            if (Settings.YUPDisplayStyle == YUPDisplay.SystemTray || Settings.YUPDisplayStyle == YUPDisplay.Both)
            {
                if (shouldIconify)
                {
                    Visible = false;
                    WindowState = FormWindowState.Minimized;

                    if (Settings.YUPDisplayStyle == YUPDisplay.Both)
                    {
                        ShowInTaskbar = false;
                    }

                    m_isMinimizedToTray = true;
                }
                else
                {
                    Visible = true;
                    WindowState = FormWindowState.Normal;

                    if (Settings.YUPDisplayStyle == YUPDisplay.Both)
                    {
                        ShowInTaskbar = true;
                    }

                    m_isMinimizedToTray = false;
                }
            }
        }

        private void ToggleIconification()
        {
            IconifyWindow(!m_isMinimizedToTray);
        }

        private void ShowSettingsForm()
        {
            using (YUPSettingsForm settingsForm = new YUPSettingsForm(this))
            {
                settingsForm.ShowDialog();
            }
        }

        private void TrackChildWindowStatus()
        {
            singleSearchToolstripButton.Checked = singleSearchToolStripMenuItem.Checked = OwnedForms[(int)ChildForms.SearchForm].Visible;
            playlistsToolstripButton.Checked = playlistsToolStripMenuItem.Checked = OwnedForms[(int)ChildForms.PlaylistForm].Visible;
            tasksToolstripButton.Checked = tasksToolStripMenuItem.Checked = OwnedForms[(int)ChildForms.ExportJobListForm].Visible;

            mainMenu_SeekBar.Checked = seekBar.Visible;
            mainMenu_PlaybackControls.Checked = controlBar.Visible;
            mainMenu_StatusBar.Checked = statusBar.Visible;

            mainMenu_AllControls.Checked = (seekBar.Visible && controlBar.Visible && statusBar.Visible);
        }

        private void ToggleFullscreen()
        {
            m_inFullscreen = !m_inFullscreen;

            mainMenu.Visible = !m_inFullscreen;
            mainMenu.Enabled = !m_inFullscreen;
            YUPControls.Visible = !m_inFullscreen;

            if (m_inFullscreen)
            {
                FormState.Maximize(this);
            }
            else
            {
                FormState.Restore(this);
            }

            DoResize();
        }

        private void DoResize()
        {
            if (!YUPControls.Visible)
            {
                FlashPlayer.ResetSize(0);
            }
            else
            {
                FlashPlayer.ResetSize(YUPControls.Height);
            }
        }

        private void OpenLoadURLForm()
        {
            using (YUPOpenURLForm openURLForm = new YUPOpenURLForm())
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
                        LoadVideo(flv);
                    }
                }
            }
        }

        internal void ActivateChildWindows()
        {
            foreach (Form childForm in OwnedForms)
            {
                if (childForm.Visible)
                {
                    childForm.Activate();
                }
            }

            this.Activate();
        }

        private void InterfacePause()
        {
            this.mainMenu.Enabled = false;
            this.controlBar.Enabled = false;

            this.spinner.Visible = true;
        }

        private void InterfaceUnPause()
        {
            this.mainMenu.Enabled = true;
            this.controlBar.Enabled = true;

            this.spinner.Visible = false;
        }
        #endregion

        #region Public Properties That Are Settings
        public Color DisplaysColor
        {
            get
            {
                return Settings.DigitalDisplayColor;
            }
            set
            {
                statusBar_CurrentTime.DigitColor = value;
                statusBar_TotalTime.DigitColor = value;
                seekBar.Color = value;
            }
        }

        public int DisplaySegments
        {
            get
            {
                return Settings.YUPSpinnerSegments;
            }
            set
            {
                spinner.Segments = value;
            }
        }

        public bool DisplayStatus
        {
            get
            {
                return Settings.YUPDisplayStatus;
            }
            set
            {
                m_displayStatusString = value;

                FlashPlayer_VideoStateChanged(m_currentVideoState);
            }
        }
        #endregion

        #region IFormStateSerialize Members
        public void SaveFormState()
        {
            foreach (Form childForm in OwnedForms)
            {
                ((IFormStateSerialize)childForm).SaveFormState();
            }

            FormWindowState = WindowState;

            FormLocation = (WindowState == FormWindowState.Normal) ? Location : RestoreBounds.Location;
            FormSize = (WindowState == FormWindowState.Normal) ? Size : RestoreBounds.Size;
            FormVisible = Visible;
        }

        public void LoadFormState()
        {
            Point formLocation = FormLocation;

            if (formLocation != ZeroCommaZero)
            {
                StartPosition = FormStartPosition.Manual;
                Location = formLocation;
            }

            if (!FormVisible)
            {
                Hide();
            }

            Size = FormSize;
            WindowState = FormWindowState;
            Visible = FormVisible;

            foreach (Form childForm in OwnedForms)
            {
                ((IFormStateSerialize)childForm).LoadFormState();
            }
        }

        public bool FormVisible
        {
            get
            {
                bool? formVisible = YUP.SettingsDatabase.GetBoolSetting("YUPMainFormVisible");

                if (!formVisible.HasValue)
                {
                    YUP.SettingsDatabase.SetBoolSetting("YUPMainFormVisible", true);
                    return true;
                }
                else
                {
                    return formVisible.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetBoolSetting("YUPMainFormVisible", value);
                
                Visible = value;
            }
        }

        public Point FormLocation
        {
            get
            {
                Point yupMainFormLocation = YUP.SettingsDatabase.GetPointSetting("YUPMainFormLocation");

                if (yupMainFormLocation.IsEmpty)
                {
                    Point defaultPoint = ZeroCommaZero;

                    YUP.SettingsDatabase.SetPointSetting("YUPMainFormLocation", defaultPoint);

                    return defaultPoint;
                }
                else
                {
                    return yupMainFormLocation;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetPointSetting("YUPMainFormLocation", value);

                this.Location = value;
            }
        }

        public Size FormSize
        {
            get
            {
                Size yupMainFormSize = YUP.SettingsDatabase.GetSizeSetting("YUPMainFormSize");

                if (yupMainFormSize.IsEmpty)
                {
                    Size defaultSize = DefaultMainFormSize;

                    YUP.SettingsDatabase.SetSizeSetting("YUPMainFormSize", defaultSize);

                    return defaultSize;
                }
                else
                {
                    return yupMainFormSize;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetSizeSetting("YUPMainFormSize", value);

                this.Size = value;
            }
        }

        public FormWindowState FormWindowState
        {
            get
            {
                string yupMainFormWindowState = YUP.SettingsDatabase.GetStringSetting("YUPMainFormWindowState");

                if (yupMainFormWindowState == string.Empty)
                {
                    YUP.SettingsDatabase.SetStringSetting("YUPMainFormWindowState", FormWindowState.Normal.ToString());

                    return FormWindowState.Normal;
                }
                else
                {
                    return (FormWindowState)Enum.Parse(typeof(FormWindowState), yupMainFormWindowState);
                }
            }
            set
            {
                YUP.SettingsDatabase.SetStringSetting("YUPMainFormWindowState", value.ToString());

                WindowState = value;
            }
        }
        #endregion
    }
}
