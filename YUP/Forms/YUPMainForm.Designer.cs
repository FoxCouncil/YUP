using Ca.Magrathean.Yup.Controls;

namespace Ca.Magrathean.Yup.Forms
{
    /// <summary>
    /// The main YUP Form class. This is the be all and end all for YUP control.
    /// </summary>
    partial class YUPMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YUPMainForm));
            this.YUPControls = new System.Windows.Forms.Panel();
            this.seekBar = new Ca.Magrathean.Yup.Controls.YUPTrackBar();
            this.controlBar = new System.Windows.Forms.ToolStrip();
            this.controlBar_Play = new System.Windows.Forms.ToolStripButton();
            this.controlBar_Pause = new System.Windows.Forms.ToolStripButton();
            this.controlBar_Volume = new Ca.Magrathean.Yup.Controls.ToolStripVolumeBar();
            this.controlBar_Mute = new System.Windows.Forms.ToolStripButton();
            this.controlBar_Stop = new System.Windows.Forms.ToolStripButton();
            this.controlBar_Rewind = new System.Windows.Forms.ToolStripButton();
            this.controlBar_FastForward = new System.Windows.Forms.ToolStripButton();
            this.controlBar_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.controlBar_Previous = new System.Windows.Forms.ToolStripButton();
            this.controlBar_PlaylistStatusText = new System.Windows.Forms.ToolStripLabel();
            this.controlBar_Next = new System.Windows.Forms.ToolStripButton();
            this.controlBar_Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.controlBar_Eject = new System.Windows.Forms.ToolStripButton();
            this.controlBar_Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.singleSearchToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.playlistsToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tasksToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.controlBar_VideoInfo = new System.Windows.Forms.ToolStripButton();
            this.statusBar = new System.Windows.Forms.ToolStrip();
            this.statusBar_Icon = new System.Windows.Forms.ToolStripButton();
            this.statusBar_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusBar_Label = new System.Windows.Forms.ToolStripLabel();
            this.statusBar_TotalTime = new Ca.Magrathean.Yup.Controls.ToolStripDigitalDisplay();
            this.statusBar_Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusBar_CurrentTime = new Ca.Magrathean.Yup.Controls.ToolStripDigitalDisplay();
            this.statusBar_Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mainMenu_FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_OpenURL = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_SeparatorFileMenu1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_SeparatorFileMenu2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu_QuitYUP = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_Fullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_SeparatorViewMenu1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu_AllControls = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_SeparatorViewMenu2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu_SeekBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_PlaybackControls = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_StatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_SeparatorViewMenu3 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu_VideoSizeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_MaintainRatio = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_ExactFit = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_SeparatorViewMenu4 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu_AlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_WindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.singleSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_SeparatorWindowMenu1 = new System.Windows.Forms.ToolStripSeparator();
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_SeparatorHelpMenu1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlashPlayer = new Ca.Magrathean.Yup.Controls.PlayerControl();
            this.playerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playerMenu_Play = new System.Windows.Forms.ToolStripMenuItem();
            this.playerMenu_Pause = new System.Windows.Forms.ToolStripMenuItem();
            this.playerMenu_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.playerMenu_Previous = new System.Windows.Forms.ToolStripMenuItem();
            this.playerMenu_Rewind = new System.Windows.Forms.ToolStripMenuItem();
            this.playerMenu_FastForward = new System.Windows.Forms.ToolStripMenuItem();
            this.playerMenu_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.playerMenu_VideoSizeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.playerMenu_MaintainRatio = new System.Windows.Forms.ToolStripMenuItem();
            this.playerMenu_ExactFit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.playerMenu_Mute = new System.Windows.Forms.ToolStripMenuItem();
            this.systrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.systrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systrayMenu_HideShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.systrayMenu_QuitYUP = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginWorker = new System.ComponentModel.BackgroundWorker();
            this.spinner = new Ca.Magrathean.Yup.Controls.Spinner();
            this.YUPControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).BeginInit();
            this.controlBar.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlashPlayer)).BeginInit();
            this.playerMenu.SuspendLayout();
            this.systrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // YUPControls
            // 
            this.YUPControls.AutoSize = true;
            this.YUPControls.Controls.Add(this.seekBar);
            this.YUPControls.Controls.Add(this.controlBar);
            this.YUPControls.Controls.Add(this.statusBar);
            this.YUPControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YUPControls.Location = new System.Drawing.Point(0, 439);
            this.YUPControls.Name = "YUPControls";
            this.YUPControls.Size = new System.Drawing.Size(574, 74);
            this.YUPControls.TabIndex = 12;
            // 
            // seekBar
            // 
            this.seekBar.BackColor = System.Drawing.Color.White;
            this.seekBar.Color = System.Drawing.Color.LimeGreen;
            this.seekBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.seekBar.DownloadBarColor = System.Drawing.Color.LimeGreen;
            this.seekBar.DownloadedPercentage = 0F;
            this.seekBar.Location = new System.Drawing.Point(0, 0);
            this.seekBar.Margin = new System.Windows.Forms.Padding(0);
            this.seekBar.Maximum = 100;
            this.seekBar.Name = "seekBar";
            this.seekBar.Size = new System.Drawing.Size(574, 22);
            this.seekBar.TabIndex = 15;
            this.seekBar.TabStop = false;
            this.seekBar.Value = 0;
            this.seekBar.ValueChanged += new System.EventHandler(this.seekBar_ValueChanged);
            this.seekBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.seekBar_MouseDown);
            // 
            // controlBar
            // 
            this.controlBar.BackColor = System.Drawing.Color.White;
            this.controlBar.CanOverflow = false;
            this.controlBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.controlBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlBar_Play,
            this.controlBar_Pause,
            this.controlBar_Volume,
            this.controlBar_Mute,
            this.controlBar_Stop,
            this.controlBar_Rewind,
            this.controlBar_FastForward,
            this.controlBar_Separator1,
            this.controlBar_Previous,
            this.controlBar_PlaylistStatusText,
            this.controlBar_Next,
            this.controlBar_Separator2,
            this.controlBar_Eject,
            this.controlBar_Separator3,
            this.singleSearchToolstripButton,
            this.playlistsToolstripButton,
            this.toolStripSeparator2,
            this.tasksToolstripButton,
            this.toolStripSeparator3,
            this.controlBar_VideoInfo});
            this.controlBar.Location = new System.Drawing.Point(0, 22);
            this.controlBar.Name = "controlBar";
            this.controlBar.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.controlBar.Size = new System.Drawing.Size(574, 27);
            this.controlBar.TabIndex = 14;
            this.controlBar.Text = "YUP Control Bar";
            // 
            // controlBar_Play
            // 
            this.controlBar_Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_Play.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_Play.Image")));
            this.controlBar_Play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_Play.Name = "controlBar_Play";
            this.controlBar_Play.Size = new System.Drawing.Size(23, 24);
            this.controlBar_Play.Text = "Play";
            this.controlBar_Play.Click += new System.EventHandler(this.playToolBtn_Click);
            // 
            // controlBar_Pause
            // 
            this.controlBar_Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_Pause.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_Pause.Image")));
            this.controlBar_Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_Pause.Name = "controlBar_Pause";
            this.controlBar_Pause.Size = new System.Drawing.Size(23, 24);
            this.controlBar_Pause.Text = "Pause";
            this.controlBar_Pause.Click += new System.EventHandler(this.pauseToolBtn_Click);
            // 
            // controlBar_Volume
            // 
            this.controlBar_Volume.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.controlBar_Volume.AutoSize = false;
            this.controlBar_Volume.CausesValidation = false;
            this.controlBar_Volume.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlBar_Volume.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar_Volume.Name = "controlBar_Volume";
            this.controlBar_Volume.Size = new System.Drawing.Size(150, 27);
            // 
            // controlBar_Mute
            // 
            this.controlBar_Mute.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.controlBar_Mute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_Mute.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_Mute.Image")));
            this.controlBar_Mute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_Mute.Name = "controlBar_Mute";
            this.controlBar_Mute.Size = new System.Drawing.Size(23, 24);
            this.controlBar_Mute.Text = "Toggle Mute";
            this.controlBar_Mute.Click += new System.EventHandler(this.muteToolBtn_Click);
            // 
            // controlBar_Stop
            // 
            this.controlBar_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_Stop.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_Stop.Image")));
            this.controlBar_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_Stop.Name = "controlBar_Stop";
            this.controlBar_Stop.Size = new System.Drawing.Size(23, 24);
            this.controlBar_Stop.Text = "Stop";
            this.controlBar_Stop.Click += new System.EventHandler(this.stopToolBtn_Click);
            // 
            // controlBar_Rewind
            // 
            this.controlBar_Rewind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_Rewind.Enabled = false;
            this.controlBar_Rewind.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_Rewind.Image")));
            this.controlBar_Rewind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_Rewind.Name = "controlBar_Rewind";
            this.controlBar_Rewind.Size = new System.Drawing.Size(23, 24);
            this.controlBar_Rewind.Text = "Rewind";
            // 
            // controlBar_FastForward
            // 
            this.controlBar_FastForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_FastForward.Enabled = false;
            this.controlBar_FastForward.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_FastForward.Image")));
            this.controlBar_FastForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_FastForward.Name = "controlBar_FastForward";
            this.controlBar_FastForward.Size = new System.Drawing.Size(23, 24);
            this.controlBar_FastForward.Text = "Fast Forward";
            // 
            // controlBar_Separator1
            // 
            this.controlBar_Separator1.Name = "controlBar_Separator1";
            this.controlBar_Separator1.Size = new System.Drawing.Size(6, 27);
            this.controlBar_Separator1.Visible = false;
            // 
            // controlBar_Previous
            // 
            this.controlBar_Previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_Previous.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_Previous.Image")));
            this.controlBar_Previous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_Previous.Name = "controlBar_Previous";
            this.controlBar_Previous.Size = new System.Drawing.Size(23, 24);
            this.controlBar_Previous.Text = "Previous";
            this.controlBar_Previous.Visible = false;
            this.controlBar_Previous.Click += new System.EventHandler(this.controlBar_Previous_Click);
            // 
            // controlBar_PlaylistStatusText
            // 
            this.controlBar_PlaylistStatusText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlBar_PlaylistStatusText.Name = "controlBar_PlaylistStatusText";
            this.controlBar_PlaylistStatusText.Size = new System.Drawing.Size(36, 24);
            this.controlBar_PlaylistStatusText.Text = "1/ 12";
            this.controlBar_PlaylistStatusText.Visible = false;
            // 
            // controlBar_Next
            // 
            this.controlBar_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_Next.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_Next.Image")));
            this.controlBar_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_Next.Name = "controlBar_Next";
            this.controlBar_Next.Size = new System.Drawing.Size(23, 24);
            this.controlBar_Next.Text = "Next";
            this.controlBar_Next.Visible = false;
            this.controlBar_Next.Click += new System.EventHandler(this.controlBar_Next_Click);
            // 
            // controlBar_Separator2
            // 
            this.controlBar_Separator2.Name = "controlBar_Separator2";
            this.controlBar_Separator2.Size = new System.Drawing.Size(6, 27);
            // 
            // controlBar_Eject
            // 
            this.controlBar_Eject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_Eject.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_Eject.Image")));
            this.controlBar_Eject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_Eject.Name = "controlBar_Eject";
            this.controlBar_Eject.Size = new System.Drawing.Size(23, 24);
            this.controlBar_Eject.Text = "Eject";
            this.controlBar_Eject.Click += new System.EventHandler(this.ejectButton_Click);
            // 
            // controlBar_Separator3
            // 
            this.controlBar_Separator3.Name = "controlBar_Separator3";
            this.controlBar_Separator3.Size = new System.Drawing.Size(6, 27);
            // 
            // singleSearchToolstripButton
            // 
            this.singleSearchToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.singleSearchToolstripButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.find;
            this.singleSearchToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.singleSearchToolstripButton.Name = "singleSearchToolstripButton";
            this.singleSearchToolstripButton.Size = new System.Drawing.Size(23, 24);
            this.singleSearchToolstripButton.Text = "Single Search";
            this.singleSearchToolstripButton.Click += new System.EventHandler(this.singleSearchToolStripMenuItem_Click);
            // 
            // playlistsToolstripButton
            // 
            this.playlistsToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playlistsToolstripButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.book;
            this.playlistsToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playlistsToolstripButton.Name = "playlistsToolstripButton";
            this.playlistsToolstripButton.Size = new System.Drawing.Size(23, 24);
            this.playlistsToolstripButton.Text = "Playlists";
            this.playlistsToolstripButton.Click += new System.EventHandler(this.playlistsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tasksToolstripButton
            // 
            this.tasksToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tasksToolstripButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.disk_multiple;
            this.tasksToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tasksToolstripButton.Name = "tasksToolstripButton";
            this.tasksToolstripButton.Size = new System.Drawing.Size(23, 24);
            this.tasksToolstripButton.Text = "Tasks";
            this.tasksToolstripButton.Click += new System.EventHandler(this.tasksToolstripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // controlBar_VideoInfo
            // 
            this.controlBar_VideoInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.controlBar_VideoInfo.Enabled = false;
            this.controlBar_VideoInfo.Image = ((System.Drawing.Image)(resources.GetObject("controlBar_VideoInfo.Image")));
            this.controlBar_VideoInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBar_VideoInfo.Name = "controlBar_VideoInfo";
            this.controlBar_VideoInfo.Size = new System.Drawing.Size(23, 24);
            this.controlBar_VideoInfo.Text = "Video Information";
            this.controlBar_VideoInfo.Click += new System.EventHandler(this.videoInfoButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.AllowMerge = false;
            this.statusBar.BackColor = System.Drawing.Color.Black;
            this.statusBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusBar.BackgroundImage")));
            this.statusBar.CanOverflow = false;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar_Icon,
            this.statusBar_Separator1,
            this.statusBar_Label,
            this.statusBar_TotalTime,
            this.statusBar_Separator3,
            this.statusBar_CurrentTime,
            this.statusBar_Separator2});
            this.statusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusBar.Location = new System.Drawing.Point(0, 49);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(2, 0, 4, 0);
            this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.statusBar.Size = new System.Drawing.Size(574, 25);
            this.statusBar.TabIndex = 12;
            // 
            // statusBar_Icon
            // 
            this.statusBar_Icon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statusBar_Icon.Image = ((System.Drawing.Image)(resources.GetObject("statusBar_Icon.Image")));
            this.statusBar_Icon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statusBar_Icon.Name = "statusBar_Icon";
            this.statusBar_Icon.Size = new System.Drawing.Size(23, 22);
            // 
            // statusBar_Separator1
            // 
            this.statusBar_Separator1.Name = "statusBar_Separator1";
            this.statusBar_Separator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusBar_Label
            // 
            this.statusBar_Label.BackColor = System.Drawing.Color.Transparent;
            this.statusBar_Label.ForeColor = System.Drawing.Color.White;
            this.statusBar_Label.Name = "statusBar_Label";
            this.statusBar_Label.Size = new System.Drawing.Size(48, 22);
            this.statusBar_Label.Text = "Ready...";
            // 
            // statusBar_TotalTime
            // 
            this.statusBar_TotalTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusBar_TotalTime.AutoSize = false;
            this.statusBar_TotalTime.BackColor = System.Drawing.Color.Transparent;
            this.statusBar_TotalTime.DigitColor = System.Drawing.Color.LimeGreen;
            this.statusBar_TotalTime.DigitText = "00:00";
            this.statusBar_TotalTime.ForeColor = System.Drawing.Color.White;
            this.statusBar_TotalTime.Name = "statusBar_TotalTime";
            this.statusBar_TotalTime.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.statusBar_TotalTime.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.statusBar_TotalTime.Size = new System.Drawing.Size(44, 22);
            // 
            // statusBar_Separator3
            // 
            this.statusBar_Separator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusBar_Separator3.Name = "statusBar_Separator3";
            this.statusBar_Separator3.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.statusBar_Separator3.Size = new System.Drawing.Size(6, 25);
            // 
            // statusBar_CurrentTime
            // 
            this.statusBar_CurrentTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusBar_CurrentTime.AutoSize = false;
            this.statusBar_CurrentTime.BackColor = System.Drawing.Color.Transparent;
            this.statusBar_CurrentTime.DigitColor = System.Drawing.Color.LimeGreen;
            this.statusBar_CurrentTime.DigitText = "00:00";
            this.statusBar_CurrentTime.ForeColor = System.Drawing.Color.White;
            this.statusBar_CurrentTime.Name = "statusBar_CurrentTime";
            this.statusBar_CurrentTime.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.statusBar_CurrentTime.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.statusBar_CurrentTime.Size = new System.Drawing.Size(44, 22);
            // 
            // statusBar_Separator2
            // 
            this.statusBar_Separator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusBar_Separator2.Name = "statusBar_Separator2";
            this.statusBar_Separator2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.statusBar_Separator2.Size = new System.Drawing.Size(6, 25);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenu_FileMenu,
            this.mainMenu_ViewMenu,
            this.mainMenu_WindowMenu,
            this.mainMenu_HelpMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainMenu.Size = new System.Drawing.Size(574, 24);
            this.mainMenu.TabIndex = 13;
            this.mainMenu.Text = "menuStrip1";
            // 
            // mainMenu_FileMenu
            // 
            this.mainMenu_FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenu_OpenFile,
            this.mainMenu_OpenURL,
            this.mainMenu_SeparatorFileMenu1,
            this.mainMenu_SaveAs,
            this.mainMenu_SeparatorFileMenu2,
            this.mainMenu_Settings,
            this.toolStripSeparator1,
            this.mainMenu_QuitYUP});
            this.mainMenu_FileMenu.Name = "mainMenu_FileMenu";
            this.mainMenu_FileMenu.Size = new System.Drawing.Size(37, 20);
            this.mainMenu_FileMenu.Text = "&File";
            // 
            // mainMenu_OpenFile
            // 
            this.mainMenu_OpenFile.Enabled = false;
            this.mainMenu_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("mainMenu_OpenFile.Image")));
            this.mainMenu_OpenFile.Name = "mainMenu_OpenFile";
            this.mainMenu_OpenFile.Size = new System.Drawing.Size(169, 22);
            this.mainMenu_OpenFile.Text = "&Open File";
            // 
            // mainMenu_OpenURL
            // 
            this.mainMenu_OpenURL.Image = ((System.Drawing.Image)(resources.GetObject("mainMenu_OpenURL.Image")));
            this.mainMenu_OpenURL.Name = "mainMenu_OpenURL";
            this.mainMenu_OpenURL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mainMenu_OpenURL.Size = new System.Drawing.Size(169, 22);
            this.mainMenu_OpenURL.Text = "Open &URL";
            this.mainMenu_OpenURL.Click += new System.EventHandler(this.openURLToolStripMenuItem_Click);
            // 
            // mainMenu_SeparatorFileMenu1
            // 
            this.mainMenu_SeparatorFileMenu1.Name = "mainMenu_SeparatorFileMenu1";
            this.mainMenu_SeparatorFileMenu1.Size = new System.Drawing.Size(166, 6);
            // 
            // mainMenu_SaveAs
            // 
            this.mainMenu_SaveAs.Enabled = false;
            this.mainMenu_SaveAs.Image = ((System.Drawing.Image)(resources.GetObject("mainMenu_SaveAs.Image")));
            this.mainMenu_SaveAs.Name = "mainMenu_SaveAs";
            this.mainMenu_SaveAs.Size = new System.Drawing.Size(169, 22);
            this.mainMenu_SaveAs.Text = "&Save As";
            this.mainMenu_SaveAs.Click += new System.EventHandler(this.mainMenu_SaveAs_Click);
            // 
            // mainMenu_SeparatorFileMenu2
            // 
            this.mainMenu_SeparatorFileMenu2.Name = "mainMenu_SeparatorFileMenu2";
            this.mainMenu_SeparatorFileMenu2.Size = new System.Drawing.Size(166, 6);
            // 
            // mainMenu_Settings
            // 
            this.mainMenu_Settings.Image = ((System.Drawing.Image)(resources.GetObject("mainMenu_Settings.Image")));
            this.mainMenu_Settings.Name = "mainMenu_Settings";
            this.mainMenu_Settings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.mainMenu_Settings.Size = new System.Drawing.Size(169, 22);
            this.mainMenu_Settings.Text = "&Settings...";
            this.mainMenu_Settings.Click += new System.EventHandler(this.mainMenu_Settings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // mainMenu_QuitYUP
            // 
            this.mainMenu_QuitYUP.Image = ((System.Drawing.Image)(resources.GetObject("mainMenu_QuitYUP.Image")));
            this.mainMenu_QuitYUP.Name = "mainMenu_QuitYUP";
            this.mainMenu_QuitYUP.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.mainMenu_QuitYUP.Size = new System.Drawing.Size(169, 22);
            this.mainMenu_QuitYUP.Text = "&Quit YUP";
            this.mainMenu_QuitYUP.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // mainMenu_ViewMenu
            // 
            this.mainMenu_ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenu_Fullscreen,
            this.mainMenu_SeparatorViewMenu1,
            this.mainMenu_AllControls,
            this.mainMenu_SeparatorViewMenu2,
            this.mainMenu_SeekBar,
            this.mainMenu_PlaybackControls,
            this.mainMenu_StatusBar,
            this.mainMenu_SeparatorViewMenu3,
            this.mainMenu_VideoSizeMenu,
            this.mainMenu_SeparatorViewMenu4,
            this.mainMenu_AlwaysOnTop});
            this.mainMenu_ViewMenu.Name = "mainMenu_ViewMenu";
            this.mainMenu_ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.mainMenu_ViewMenu.Text = "&View";
            // 
            // mainMenu_Fullscreen
            // 
            this.mainMenu_Fullscreen.Image = ((System.Drawing.Image)(resources.GetObject("mainMenu_Fullscreen.Image")));
            this.mainMenu_Fullscreen.Name = "mainMenu_Fullscreen";
            this.mainMenu_Fullscreen.ShortcutKeyDisplayString = "";
            this.mainMenu_Fullscreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Return)));
            this.mainMenu_Fullscreen.Size = new System.Drawing.Size(205, 22);
            this.mainMenu_Fullscreen.Text = "&Fullscreen";
            this.mainMenu_Fullscreen.Click += new System.EventHandler(this.fullscreenToolStripMenuItem_Click);
            // 
            // mainMenu_SeparatorViewMenu1
            // 
            this.mainMenu_SeparatorViewMenu1.Name = "mainMenu_SeparatorViewMenu1";
            this.mainMenu_SeparatorViewMenu1.Size = new System.Drawing.Size(202, 6);
            // 
            // mainMenu_AllControls
            // 
            this.mainMenu_AllControls.Checked = true;
            this.mainMenu_AllControls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mainMenu_AllControls.Name = "mainMenu_AllControls";
            this.mainMenu_AllControls.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.mainMenu_AllControls.Size = new System.Drawing.Size(205, 22);
            this.mainMenu_AllControls.Text = "All &Controls";
            this.mainMenu_AllControls.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // mainMenu_SeparatorViewMenu2
            // 
            this.mainMenu_SeparatorViewMenu2.Name = "mainMenu_SeparatorViewMenu2";
            this.mainMenu_SeparatorViewMenu2.Size = new System.Drawing.Size(202, 6);
            // 
            // mainMenu_SeekBar
            // 
            this.mainMenu_SeekBar.Checked = true;
            this.mainMenu_SeekBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mainMenu_SeekBar.Name = "mainMenu_SeekBar";
            this.mainMenu_SeekBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.mainMenu_SeekBar.Size = new System.Drawing.Size(205, 22);
            this.mainMenu_SeekBar.Text = "&Seek Bar";
            this.mainMenu_SeekBar.Click += new System.EventHandler(this.seekBarToolStripMenuItem_Click);
            // 
            // mainMenu_PlaybackControls
            // 
            this.mainMenu_PlaybackControls.Checked = true;
            this.mainMenu_PlaybackControls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mainMenu_PlaybackControls.Name = "mainMenu_PlaybackControls";
            this.mainMenu_PlaybackControls.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.mainMenu_PlaybackControls.Size = new System.Drawing.Size(205, 22);
            this.mainMenu_PlaybackControls.Text = "Playback Controls";
            this.mainMenu_PlaybackControls.Click += new System.EventHandler(this.playbackControlsToolStripMenuItem_Click);
            // 
            // mainMenu_StatusBar
            // 
            this.mainMenu_StatusBar.Checked = true;
            this.mainMenu_StatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mainMenu_StatusBar.Name = "mainMenu_StatusBar";
            this.mainMenu_StatusBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.mainMenu_StatusBar.Size = new System.Drawing.Size(205, 22);
            this.mainMenu_StatusBar.Text = "Status Bar";
            this.mainMenu_StatusBar.Click += new System.EventHandler(this.statusBarToolStripMenuItem_Click);
            // 
            // mainMenu_SeparatorViewMenu3
            // 
            this.mainMenu_SeparatorViewMenu3.Name = "mainMenu_SeparatorViewMenu3";
            this.mainMenu_SeparatorViewMenu3.Size = new System.Drawing.Size(202, 6);
            // 
            // mainMenu_VideoSizeMenu
            // 
            this.mainMenu_VideoSizeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenu_MaintainRatio,
            this.mainMenu_ExactFit});
            this.mainMenu_VideoSizeMenu.Image = ((System.Drawing.Image)(resources.GetObject("mainMenu_VideoSizeMenu.Image")));
            this.mainMenu_VideoSizeMenu.Name = "mainMenu_VideoSizeMenu";
            this.mainMenu_VideoSizeMenu.Size = new System.Drawing.Size(205, 22);
            this.mainMenu_VideoSizeMenu.Text = "Video Size";
            // 
            // mainMenu_MaintainRatio
            // 
            this.mainMenu_MaintainRatio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mainMenu_MaintainRatio.Name = "mainMenu_MaintainRatio";
            this.mainMenu_MaintainRatio.Size = new System.Drawing.Size(151, 22);
            this.mainMenu_MaintainRatio.Text = "Maintain Ratio";
            this.mainMenu_MaintainRatio.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.mainMenu_MaintainRatio.Click += new System.EventHandler(this.maintainRatioToolStripMenuItem_Click);
            // 
            // mainMenu_ExactFit
            // 
            this.mainMenu_ExactFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mainMenu_ExactFit.Name = "mainMenu_ExactFit";
            this.mainMenu_ExactFit.Size = new System.Drawing.Size(151, 22);
            this.mainMenu_ExactFit.Text = "Exact Fit";
            this.mainMenu_ExactFit.Click += new System.EventHandler(this.exactFitToolStripMenuItem_Click);
            // 
            // mainMenu_SeparatorViewMenu4
            // 
            this.mainMenu_SeparatorViewMenu4.Name = "mainMenu_SeparatorViewMenu4";
            this.mainMenu_SeparatorViewMenu4.Size = new System.Drawing.Size(202, 6);
            // 
            // mainMenu_AlwaysOnTop
            // 
            this.mainMenu_AlwaysOnTop.Image = ((System.Drawing.Image)(resources.GetObject("mainMenu_AlwaysOnTop.Image")));
            this.mainMenu_AlwaysOnTop.Name = "mainMenu_AlwaysOnTop";
            this.mainMenu_AlwaysOnTop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mainMenu_AlwaysOnTop.Size = new System.Drawing.Size(205, 22);
            this.mainMenu_AlwaysOnTop.Text = "&Always On Top";
            this.mainMenu_AlwaysOnTop.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // mainMenu_WindowMenu
            // 
            this.mainMenu_WindowMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleSearchToolStripMenuItem,
            this.playlistsToolStripMenuItem,
            this.mainMenu_SeparatorWindowMenu1,
            this.tasksToolStripMenuItem});
            this.mainMenu_WindowMenu.Name = "mainMenu_WindowMenu";
            this.mainMenu_WindowMenu.Size = new System.Drawing.Size(63, 20);
            this.mainMenu_WindowMenu.Text = "&Window";
            // 
            // singleSearchToolStripMenuItem
            // 
            this.singleSearchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("singleSearchToolStripMenuItem.Image")));
            this.singleSearchToolStripMenuItem.Name = "singleSearchToolStripMenuItem";
            this.singleSearchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.singleSearchToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.singleSearchToolStripMenuItem.Text = "&Single Search";
            this.singleSearchToolStripMenuItem.Click += new System.EventHandler(this.singleSearchToolStripMenuItem_Click);
            // 
            // playlistsToolStripMenuItem
            // 
            this.playlistsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("playlistsToolStripMenuItem.Image")));
            this.playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            this.playlistsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.playlistsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.playlistsToolStripMenuItem.Text = "&Playlists";
            this.playlistsToolStripMenuItem.Click += new System.EventHandler(this.playlistsToolStripMenuItem_Click);
            // 
            // mainMenu_SeparatorWindowMenu1
            // 
            this.mainMenu_SeparatorWindowMenu1.Name = "mainMenu_SeparatorWindowMenu1";
            this.mainMenu_SeparatorWindowMenu1.Size = new System.Drawing.Size(181, 6);
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.disk_multiple;
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.tasksToolStripMenuItem.Text = "&Export Jobs";
            // 
            // mainMenu_HelpMenu
            // 
            this.mainMenu_HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.mainMenu_SeparatorHelpMenu1,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripSeparator6,
            this.aboutToolStripMenuItem});
            this.mainMenu_HelpMenu.Name = "mainMenu_HelpMenu";
            this.mainMenu_HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.mainMenu_HelpMenu.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Enabled = false;
            this.helpToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem1.Image")));
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            // 
            // mainMenu_SeparatorHelpMenu1
            // 
            this.mainMenu_SeparatorHelpMenu1.Name = "mainMenu_SeparatorHelpMenu1";
            this.mainMenu_SeparatorHelpMenu1.Size = new System.Drawing.Size(170, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.bricks;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "&Check For Updates";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(170, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FlashPlayer
            // 
            this.FlashPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlashPlayer.Enabled = true;
            this.FlashPlayer.Location = new System.Drawing.Point(0, 24);
            this.FlashPlayer.Name = "FlashPlayer";
            this.FlashPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FlashPlayer.OcxState")));
            this.FlashPlayer.Size = new System.Drawing.Size(574, 489);
            this.FlashPlayer.TabIndex = 11;
            this.FlashPlayer.VideoState = Ca.Magrathean.Yup.VideoState.NoVideo;
            this.FlashPlayer.Volume = 6;
            this.FlashPlayer.MouseLeftDoubleClick += new System.EventHandler(this.FlashPlayer_MouseLeftDoubleClick);
            this.FlashPlayer.MouseRightClick += new System.EventHandler(this.FlashPlayer_MouseRightClick);
            this.FlashPlayer.MouseLeftClick += new System.EventHandler(this.FlashPlayer_MouseLeftClick);
            // 
            // playerMenu
            // 
            this.playerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerMenu_Play,
            this.playerMenu_Pause,
            this.playerMenu_Stop,
            this.toolStripSeparator4,
            this.playerMenu_Previous,
            this.playerMenu_Rewind,
            this.playerMenu_FastForward,
            this.playerMenu_Next,
            this.toolStripSeparator15,
            this.playerMenu_VideoSizeMenu,
            this.toolStripSeparator16,
            this.playerMenu_Mute});
            this.playerMenu.Name = "flashPlayerContextMenu";
            this.playerMenu.Size = new System.Drawing.Size(142, 220);
            // 
            // playerMenu_Play
            // 
            this.playerMenu_Play.Image = ((System.Drawing.Image)(resources.GetObject("playerMenu_Play.Image")));
            this.playerMenu_Play.Name = "playerMenu_Play";
            this.playerMenu_Play.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_Play.Text = "Play";
            this.playerMenu_Play.Click += new System.EventHandler(this.playToolBtn_Click);
            // 
            // playerMenu_Pause
            // 
            this.playerMenu_Pause.Image = ((System.Drawing.Image)(resources.GetObject("playerMenu_Pause.Image")));
            this.playerMenu_Pause.Name = "playerMenu_Pause";
            this.playerMenu_Pause.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_Pause.Text = "Pause";
            this.playerMenu_Pause.Click += new System.EventHandler(this.pauseToolBtn_Click);
            // 
            // playerMenu_Stop
            // 
            this.playerMenu_Stop.Image = ((System.Drawing.Image)(resources.GetObject("playerMenu_Stop.Image")));
            this.playerMenu_Stop.Name = "playerMenu_Stop";
            this.playerMenu_Stop.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_Stop.Text = "Stop";
            this.playerMenu_Stop.Click += new System.EventHandler(this.stopToolBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(138, 6);
            // 
            // playerMenu_Previous
            // 
            this.playerMenu_Previous.Enabled = false;
            this.playerMenu_Previous.Image = ((System.Drawing.Image)(resources.GetObject("playerMenu_Previous.Image")));
            this.playerMenu_Previous.Name = "playerMenu_Previous";
            this.playerMenu_Previous.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_Previous.Text = "Previous";
            // 
            // playerMenu_Rewind
            // 
            this.playerMenu_Rewind.Enabled = false;
            this.playerMenu_Rewind.Image = ((System.Drawing.Image)(resources.GetObject("playerMenu_Rewind.Image")));
            this.playerMenu_Rewind.Name = "playerMenu_Rewind";
            this.playerMenu_Rewind.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_Rewind.Text = "Rewind";
            // 
            // playerMenu_FastForward
            // 
            this.playerMenu_FastForward.Enabled = false;
            this.playerMenu_FastForward.Image = ((System.Drawing.Image)(resources.GetObject("playerMenu_FastForward.Image")));
            this.playerMenu_FastForward.Name = "playerMenu_FastForward";
            this.playerMenu_FastForward.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_FastForward.Text = "Fast Forward";
            // 
            // playerMenu_Next
            // 
            this.playerMenu_Next.Enabled = false;
            this.playerMenu_Next.Image = ((System.Drawing.Image)(resources.GetObject("playerMenu_Next.Image")));
            this.playerMenu_Next.Name = "playerMenu_Next";
            this.playerMenu_Next.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_Next.Text = "Next";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(138, 6);
            // 
            // playerMenu_VideoSizeMenu
            // 
            this.playerMenu_VideoSizeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerMenu_MaintainRatio,
            this.playerMenu_ExactFit});
            this.playerMenu_VideoSizeMenu.Image = global::Ca.Magrathean.Yup.Properties.Resources.monitor;
            this.playerMenu_VideoSizeMenu.Name = "playerMenu_VideoSizeMenu";
            this.playerMenu_VideoSizeMenu.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_VideoSizeMenu.Text = "Video Size";
            // 
            // playerMenu_MaintainRatio
            // 
            this.playerMenu_MaintainRatio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.playerMenu_MaintainRatio.Name = "playerMenu_MaintainRatio";
            this.playerMenu_MaintainRatio.Size = new System.Drawing.Size(151, 22);
            this.playerMenu_MaintainRatio.Text = "Maintain Ratio";
            this.playerMenu_MaintainRatio.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.playerMenu_MaintainRatio.Click += new System.EventHandler(this.maintainRatioToolStripMenuItem_Click);
            // 
            // playerMenu_ExactFit
            // 
            this.playerMenu_ExactFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.playerMenu_ExactFit.Name = "playerMenu_ExactFit";
            this.playerMenu_ExactFit.Size = new System.Drawing.Size(151, 22);
            this.playerMenu_ExactFit.Text = "Exact Fit";
            this.playerMenu_ExactFit.Click += new System.EventHandler(this.exactFitToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(138, 6);
            // 
            // playerMenu_Mute
            // 
            this.playerMenu_Mute.Image = ((System.Drawing.Image)(resources.GetObject("playerMenu_Mute.Image")));
            this.playerMenu_Mute.Name = "playerMenu_Mute";
            this.playerMenu_Mute.Size = new System.Drawing.Size(141, 22);
            this.playerMenu_Mute.Text = "Mute";
            this.playerMenu_Mute.Click += new System.EventHandler(this.muteToolBtn_Click);
            // 
            // systrayIcon
            // 
            this.systrayIcon.ContextMenuStrip = this.systrayMenu;
            this.systrayIcon.Text = "YUP";
            this.systrayIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yupNotificationIcon_MouseDown);
            // 
            // systrayMenu
            // 
            this.systrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systrayMenu_HideShow,
            this.toolStripSeparator17,
            this.systrayMenu_QuitYUP});
            this.systrayMenu.Name = "notificationIconContextMenu";
            this.systrayMenu.Size = new System.Drawing.Size(123, 54);
            this.systrayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.notificationIconContextMenu_Opening);
            // 
            // systrayMenu_HideShow
            // 
            this.systrayMenu_HideShow.Image = ((System.Drawing.Image)(resources.GetObject("systrayMenu_HideShow.Image")));
            this.systrayMenu_HideShow.Name = "systrayMenu_HideShow";
            this.systrayMenu_HideShow.Size = new System.Drawing.Size(122, 22);
            this.systrayMenu_HideShow.Text = "Hide";
            this.systrayMenu_HideShow.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(119, 6);
            // 
            // systrayMenu_QuitYUP
            // 
            this.systrayMenu_QuitYUP.Image = ((System.Drawing.Image)(resources.GetObject("systrayMenu_QuitYUP.Image")));
            this.systrayMenu_QuitYUP.Name = "systrayMenu_QuitYUP";
            this.systrayMenu_QuitYUP.Size = new System.Drawing.Size(122, 22);
            this.systrayMenu_QuitYUP.Text = "&Quit YUP";
            this.systrayMenu_QuitYUP.Click += new System.EventHandler(this.exitYUPToolStripMenuItem_Click);
            // 
            // pluginWorker
            // 
            this.pluginWorker.WorkerSupportsCancellation = true;
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Black;
            this.spinner.DisplaySegmentText = false;
            this.spinner.DisplayString = "Loading...";
            this.spinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinner.Location = new System.Drawing.Point(0, 24);
            this.spinner.Name = "spinner";
            this.spinner.Segments = 12;
            this.spinner.Size = new System.Drawing.Size(574, 415);
            this.spinner.TabIndex = 14;
            this.spinner.Text = "spinner";
            // 
            // YUPMainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 513);
            this.Controls.Add(this.spinner);
            this.Controls.Add(this.YUPControls);
            this.Controls.Add(this.FlashPlayer);
            this.Controls.Add(this.mainMenu);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(582, 546);
            this.Name = "YUPMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YUP";
            this.Load += new System.EventHandler(this.YUPMainForm_Load);
            this.SizeChanged += new System.EventHandler(this.YumMainForm_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.YUPMainForm_DragDrop);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.YUPMainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YUPMainForm_FormClosing);
            this.Resize += new System.EventHandler(this.YUPMainForm_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YUPMainForm_KeyDown);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.YUPMainForm_DragOver);
            this.YUPControls.ResumeLayout(false);
            this.YUPControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).EndInit();
            this.controlBar.ResumeLayout(false);
            this.controlBar.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlashPlayer)).EndInit();
            this.playerMenu.ResumeLayout(false);
            this.systrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel YUPControls;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_FileMenu;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_QuitYUP;
        private System.Windows.Forms.ToolStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_AllControls;
        private System.Windows.Forms.ToolStripSeparator mainMenu_SeparatorViewMenu4;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_AlwaysOnTop;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_Fullscreen;
        private System.Windows.Forms.ToolStripSeparator mainMenu_SeparatorViewMenu1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator mainMenu_SeparatorHelpMenu1;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_OpenFile;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_OpenURL;
        private System.Windows.Forms.ToolStripSeparator mainMenu_SeparatorFileMenu1;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_SaveAs;
        private System.Windows.Forms.ToolStripSeparator mainMenu_SeparatorFileMenu2;
        private System.Windows.Forms.ToolStrip controlBar;
        private System.Windows.Forms.ToolStripButton controlBar_Play;
        private System.Windows.Forms.ToolStripButton controlBar_Stop;
        private System.Windows.Forms.ToolStripButton controlBar_Pause;
        private System.Windows.Forms.ToolStripButton controlBar_Mute;
        private ToolStripDigitalDisplay statusBar_CurrentTime;
        private System.Windows.Forms.ToolStripSeparator statusBar_Separator3;
        private ToolStripDigitalDisplay statusBar_TotalTime;
        private System.Windows.Forms.ToolStripButton statusBar_Icon;
        private System.Windows.Forms.ToolStripSeparator controlBar_Separator1;
        private System.Windows.Forms.ToolStripButton controlBar_Previous;
        private System.Windows.Forms.ToolStripButton controlBar_Rewind;
        private System.Windows.Forms.ToolStripButton controlBar_FastForward;
        private System.Windows.Forms.ToolStripButton controlBar_Next;
        private System.Windows.Forms.ToolStripSeparator controlBar_Separator2;
        private System.Windows.Forms.ToolStripButton controlBar_Eject;
        private System.Windows.Forms.ToolStripSeparator controlBar_Separator3;
        private System.Windows.Forms.ToolStripSeparator mainMenu_SeparatorViewMenu2;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_SeekBar;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_PlaybackControls;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_StatusBar;
        private System.Windows.Forms.ToolStripSeparator statusBar_Separator1;
        private System.Windows.Forms.ToolStripSeparator statusBar_Separator2;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_WindowMenu;
        private System.Windows.Forms.ToolStripMenuItem singleSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem;
        internal PlayerControl FlashPlayer;
        private System.Windows.Forms.ToolStripLabel statusBar_Label;
        private System.Windows.Forms.ToolStripButton controlBar_VideoInfo;
        private System.Windows.Forms.ContextMenuStrip playerMenu;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_Play;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_Pause;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_Stop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_Previous;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_Rewind;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_FastForward;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_Next;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_VideoSizeMenu;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_MaintainRatio;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_ExactFit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_Mute;
        internal System.Windows.Forms.NotifyIcon systrayIcon;
        private System.Windows.Forms.ContextMenuStrip systrayMenu;
        private System.Windows.Forms.ToolStripMenuItem systrayMenu_HideShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem systrayMenu_QuitYUP;
        private System.Windows.Forms.ToolStripSeparator mainMenu_SeparatorWindowMenu1;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator mainMenu_SeparatorViewMenu3;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_VideoSizeMenu;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_MaintainRatio;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_ExactFit;
        private System.Windows.Forms.ToolStripMenuItem mainMenu_Settings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton singleSearchToolstripButton;
        private System.Windows.Forms.ToolStripButton playlistsToolstripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tasksToolstripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public Yup.Controls.YUPTrackBar seekBar;
        private ToolStripVolumeBar controlBar_Volume;
        private System.ComponentModel.BackgroundWorker pluginWorker;
        private Spinner spinner;
        private System.Windows.Forms.ToolStripLabel controlBar_PlaylistStatusText;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

