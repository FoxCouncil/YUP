namespace Ca.Magrathean.Yup.Forms
{
    /// <summary>
    /// This is the main playlist form. This shows each playlist and the videos inside each playlist.
    /// </summary>
    partial class YUPPlaylistForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Playlists");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.playlistSplitContainer = new System.Windows.Forms.SplitContainer();
            this.playlistTreeView = new System.Windows.Forms.TreeView();
            this.playlistTreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.playlistTreeViewToolStrip = new System.Windows.Forms.ToolStrip();
            this.newPlaylistButton = new System.Windows.Forms.ToolStripButton();
            this.editPlaylistButton = new System.Windows.Forms.ToolStripButton();
            this.deletePlaylistButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadPlaylistsButton = new System.Windows.Forms.ToolStripButton();
            this.playlistDataGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plugin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playlistDataGridToolStrip = new System.Windows.Forms.ToolStrip();
            this.videoAddButton = new System.Windows.Forms.ToolStripButton();
            this.videoDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.playPlaylistToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.playPlaylistButton = new System.Windows.Forms.ToolStripButton();
            this.playVideoButtonSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.playVideoButton = new System.Windows.Forms.ToolStripButton();
            this.treeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playThisPlaylistToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.playThisPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playThisVideoToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.playThisVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistStatusStrip = new System.Windows.Forms.StatusStrip();
            this.textInfoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.numberInfoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.playlistSplitContainer.Panel1.SuspendLayout();
            this.playlistSplitContainer.Panel2.SuspendLayout();
            this.playlistSplitContainer.SuspendLayout();
            this.playlistTreeViewToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playlistDataGrid)).BeginInit();
            this.playlistDataGridToolStrip.SuspendLayout();
            this.treeViewContextMenu.SuspendLayout();
            this.dataGridContextMenu.SuspendLayout();
            this.playlistStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // playlistSplitContainer
            // 
            this.playlistSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.playlistSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.playlistSplitContainer.Name = "playlistSplitContainer";
            // 
            // playlistSplitContainer.Panel1
            // 
            this.playlistSplitContainer.Panel1.Controls.Add(this.playlistTreeView);
            this.playlistSplitContainer.Panel1.Controls.Add(this.playlistTreeViewToolStrip);
            this.playlistSplitContainer.Panel1MinSize = 120;
            // 
            // playlistSplitContainer.Panel2
            // 
            this.playlistSplitContainer.Panel2.Controls.Add(this.playlistDataGrid);
            this.playlistSplitContainer.Panel2.Controls.Add(this.playlistDataGridToolStrip);
            this.playlistSplitContainer.Panel2MinSize = 30;
            this.playlistSplitContainer.Size = new System.Drawing.Size(624, 422);
            this.playlistSplitContainer.SplitterDistance = 208;
            this.playlistSplitContainer.TabIndex = 0;
            // 
            // playlistTreeView
            // 
            this.playlistTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistTreeView.FullRowSelect = true;
            this.playlistTreeView.HideSelection = false;
            this.playlistTreeView.ImageIndex = 0;
            this.playlistTreeView.ImageList = this.playlistTreeImageList;
            this.playlistTreeView.LabelEdit = true;
            this.playlistTreeView.Location = new System.Drawing.Point(0, 25);
            this.playlistTreeView.Name = "playlistTreeView";
            treeNode1.Name = "PlaylistNode";
            treeNode1.Text = "Playlists";
            treeNode1.ToolTipText = "Playlist Root";
            this.playlistTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.playlistTreeView.SelectedImageIndex = 0;
            this.playlistTreeView.ShowRootLines = false;
            this.playlistTreeView.Size = new System.Drawing.Size(208, 397);
            this.playlistTreeView.TabIndex = 0;
            this.playlistTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.playlistTreeView_AfterLabelEdit);
            this.playlistTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.playlistTreeView_BeforeCollapse);
            this.playlistTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playlistTreeView_MouseDown);
            this.playlistTreeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.playlistTreeView_BeforeLabelEdit);
            // 
            // playlistTreeImageList
            // 
            this.playlistTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.playlistTreeImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.playlistTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // playlistTreeViewToolStrip
            // 
            this.playlistTreeViewToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.playlistTreeViewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlaylistButton,
            this.editPlaylistButton,
            this.deletePlaylistButton,
            this.toolStripSeparator2,
            this.reloadPlaylistsButton});
            this.playlistTreeViewToolStrip.Location = new System.Drawing.Point(0, 0);
            this.playlistTreeViewToolStrip.Name = "playlistTreeViewToolStrip";
            this.playlistTreeViewToolStrip.Size = new System.Drawing.Size(208, 25);
            this.playlistTreeViewToolStrip.TabIndex = 1;
            this.playlistTreeViewToolStrip.Text = "toolStrip1";
            // 
            // newPlaylistButton
            // 
            this.newPlaylistButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newPlaylistButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.book_add;
            this.newPlaylistButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newPlaylistButton.Name = "newPlaylistButton";
            this.newPlaylistButton.Size = new System.Drawing.Size(23, 22);
            this.newPlaylistButton.Text = "New Playlist";
            this.newPlaylistButton.Click += new System.EventHandler(this.newPlaylistButton_Click);
            // 
            // editPlaylistButton
            // 
            this.editPlaylistButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editPlaylistButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.book_edit;
            this.editPlaylistButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editPlaylistButton.Name = "editPlaylistButton";
            this.editPlaylistButton.Size = new System.Drawing.Size(23, 22);
            this.editPlaylistButton.Text = "Edit Playlist";
            this.editPlaylistButton.Click += new System.EventHandler(this.editPlaylistButton_Click);
            // 
            // deletePlaylistButton
            // 
            this.deletePlaylistButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deletePlaylistButton.Enabled = false;
            this.deletePlaylistButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.book_delete;
            this.deletePlaylistButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deletePlaylistButton.Name = "deletePlaylistButton";
            this.deletePlaylistButton.Size = new System.Drawing.Size(23, 22);
            this.deletePlaylistButton.Text = "Delete Playlist";
            this.deletePlaylistButton.Click += new System.EventHandler(this.deletePlaylistButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // reloadPlaylistsButton
            // 
            this.reloadPlaylistsButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.arrow_refresh_small;
            this.reloadPlaylistsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reloadPlaylistsButton.Name = "reloadPlaylistsButton";
            this.reloadPlaylistsButton.Size = new System.Drawing.Size(108, 22);
            this.reloadPlaylistsButton.Text = "Reload Playlists";
            this.reloadPlaylistsButton.Click += new System.EventHandler(this.reloadPlaylistsButton_Click);
            // 
            // playlistDataGrid
            // 
            this.playlistDataGrid.AllowDrop = true;
            this.playlistDataGrid.AllowUserToAddRows = false;
            this.playlistDataGrid.AllowUserToDeleteRows = false;
            this.playlistDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.playlistDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.playlistDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.playlistDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playlistDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.VideoName,
            this.Plugin});
            this.playlistDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.playlistDataGrid.Location = new System.Drawing.Point(0, 25);
            this.playlistDataGrid.MultiSelect = false;
            this.playlistDataGrid.Name = "playlistDataGrid";
            this.playlistDataGrid.ReadOnly = true;
            this.playlistDataGrid.RowHeadersVisible = false;
            this.playlistDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.playlistDataGrid.ShowEditingIcon = false;
            this.playlistDataGrid.Size = new System.Drawing.Size(412, 397);
            this.playlistDataGrid.TabIndex = 0;
            this.playlistDataGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playlistDataGrid_MouseClick);
            this.playlistDataGrid.DragOver += new System.Windows.Forms.DragEventHandler(this.playlistDataGrid_DragOver);
            this.playlistDataGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.playlistDataGrid_DragDrop);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.id.FillWeight = 46.20025F;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 25;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id.Visible = false;
            this.id.Width = 25;
            // 
            // VideoName
            // 
            this.VideoName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VideoName.FillWeight = 136.2907F;
            this.VideoName.HeaderText = "Name";
            this.VideoName.Name = "VideoName";
            this.VideoName.ReadOnly = true;
            // 
            // Plugin
            // 
            this.Plugin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Plugin.FillWeight = 136.2907F;
            this.Plugin.HeaderText = "Plugin";
            this.Plugin.MinimumWidth = 80;
            this.Plugin.Name = "Plugin";
            this.Plugin.ReadOnly = true;
            this.Plugin.Width = 80;
            // 
            // playlistDataGridToolStrip
            // 
            this.playlistDataGridToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.playlistDataGridToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoAddButton,
            this.videoDeleteButton,
            this.playPlaylistToolStripSeparator,
            this.playPlaylistButton,
            this.playVideoButtonSeparator,
            this.playVideoButton});
            this.playlistDataGridToolStrip.Location = new System.Drawing.Point(0, 0);
            this.playlistDataGridToolStrip.Name = "playlistDataGridToolStrip";
            this.playlistDataGridToolStrip.Size = new System.Drawing.Size(412, 25);
            this.playlistDataGridToolStrip.TabIndex = 1;
            this.playlistDataGridToolStrip.Text = "toolStrip2";
            // 
            // videoAddButton
            // 
            this.videoAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.videoAddButton.Enabled = false;
            this.videoAddButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.film_add;
            this.videoAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.videoAddButton.Name = "videoAddButton";
            this.videoAddButton.Size = new System.Drawing.Size(23, 22);
            this.videoAddButton.Text = "Add Video Entry";
            this.videoAddButton.Click += new System.EventHandler(this.videoAddButton_Click);
            // 
            // videoDeleteButton
            // 
            this.videoDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.videoDeleteButton.Enabled = false;
            this.videoDeleteButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.film_delete;
            this.videoDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.videoDeleteButton.Name = "videoDeleteButton";
            this.videoDeleteButton.Size = new System.Drawing.Size(23, 22);
            this.videoDeleteButton.Text = "Delete Video Entry";
            this.videoDeleteButton.Click += new System.EventHandler(this.videoDeleteButton_Click);
            // 
            // playPlaylistToolStripSeparator
            // 
            this.playPlaylistToolStripSeparator.Name = "playPlaylistToolStripSeparator";
            this.playPlaylistToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // playPlaylistButton
            // 
            this.playPlaylistButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.control_play_blue;
            this.playPlaylistButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playPlaylistButton.Name = "playPlaylistButton";
            this.playPlaylistButton.Size = new System.Drawing.Size(89, 22);
            this.playPlaylistButton.Text = "Play Playlist";
            this.playPlaylistButton.Click += new System.EventHandler(this.playPlaylistButton_Click);
            // 
            // playVideoButtonSeparator
            // 
            this.playVideoButtonSeparator.Name = "playVideoButtonSeparator";
            this.playVideoButtonSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // playVideoButton
            // 
            this.playVideoButton.Image = global::Ca.Magrathean.Yup.Properties.Resources.control_play_blue;
            this.playVideoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playVideoButton.Name = "playVideoButton";
            this.playVideoButton.Size = new System.Drawing.Size(82, 22);
            this.playVideoButton.Text = "Play Video";
            this.playVideoButton.Click += new System.EventHandler(this.playVideoButton_Click);
            // 
            // treeViewContextMenu
            // 
            this.treeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlaylistToolStripMenuItem,
            this.openPlaylistToolStripMenuItem,
            this.editPlaylistToolStripMenuItem,
            this.deletePlaylistToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem1});
            this.treeViewContextMenu.Name = "treeViewContextMenu";
            this.treeViewContextMenu.Size = new System.Drawing.Size(156, 120);
            // 
            // newPlaylistToolStripMenuItem
            // 
            this.newPlaylistToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.book_add;
            this.newPlaylistToolStripMenuItem.Name = "newPlaylistToolStripMenuItem";
            this.newPlaylistToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newPlaylistToolStripMenuItem.Text = "New Playlist";
            this.newPlaylistToolStripMenuItem.Click += new System.EventHandler(this.newPlaylistButton_Click);
            // 
            // openPlaylistToolStripMenuItem
            // 
            this.openPlaylistToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.book_open;
            this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
            this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openPlaylistToolStripMenuItem.Text = "Open Playlist";
            // 
            // editPlaylistToolStripMenuItem
            // 
            this.editPlaylistToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.book_edit;
            this.editPlaylistToolStripMenuItem.Name = "editPlaylistToolStripMenuItem";
            this.editPlaylistToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.editPlaylistToolStripMenuItem.Text = "Edit Playlist";
            this.editPlaylistToolStripMenuItem.Click += new System.EventHandler(this.editPlaylistButton_Click);
            // 
            // deletePlaylistToolStripMenuItem
            // 
            this.deletePlaylistToolStripMenuItem.Enabled = false;
            this.deletePlaylistToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.book_delete;
            this.deletePlaylistToolStripMenuItem.Name = "deletePlaylistToolStripMenuItem";
            this.deletePlaylistToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deletePlaylistToolStripMenuItem.Text = "Delete Playlist";
            this.deletePlaylistToolStripMenuItem.Click += new System.EventHandler(this.deletePlaylistButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Ca.Magrathean.Yup.Properties.Resources.arrow_refresh_small;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem1.Text = "Reload Playlists";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.reloadPlaylistsButton_Click);
            // 
            // dataGridContextMenu
            // 
            this.dataGridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVideoToolStripMenuItem,
            this.deleteVideoToolStripMenuItem,
            this.playThisPlaylistToolStripSeparator,
            this.playThisPlaylistToolStripMenuItem,
            this.playThisVideoToolStripSeparator,
            this.playThisVideoToolStripMenuItem});
            this.dataGridContextMenu.Name = "dataGridContextMenu";
            this.dataGridContextMenu.Size = new System.Drawing.Size(171, 104);
            // 
            // addVideoToolStripMenuItem
            // 
            this.addVideoToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.film_add;
            this.addVideoToolStripMenuItem.Name = "addVideoToolStripMenuItem";
            this.addVideoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addVideoToolStripMenuItem.Text = "Add Video Entry";
            // 
            // deleteVideoToolStripMenuItem
            // 
            this.deleteVideoToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.film_delete;
            this.deleteVideoToolStripMenuItem.Name = "deleteVideoToolStripMenuItem";
            this.deleteVideoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deleteVideoToolStripMenuItem.Text = "Delete Video Entry";
            // 
            // playThisPlaylistToolStripSeparator
            // 
            this.playThisPlaylistToolStripSeparator.Name = "playThisPlaylistToolStripSeparator";
            this.playThisPlaylistToolStripSeparator.Size = new System.Drawing.Size(167, 6);
            // 
            // playThisPlaylistToolStripMenuItem
            // 
            this.playThisPlaylistToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.control_play_blue;
            this.playThisPlaylistToolStripMenuItem.Name = "playThisPlaylistToolStripMenuItem";
            this.playThisPlaylistToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.playThisPlaylistToolStripMenuItem.Text = "Play Playlist";
            // 
            // playThisVideoToolStripSeparator
            // 
            this.playThisVideoToolStripSeparator.Name = "playThisVideoToolStripSeparator";
            this.playThisVideoToolStripSeparator.Size = new System.Drawing.Size(167, 6);
            // 
            // playThisVideoToolStripMenuItem
            // 
            this.playThisVideoToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.control_play_blue;
            this.playThisVideoToolStripMenuItem.Name = "playThisVideoToolStripMenuItem";
            this.playThisVideoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.playThisVideoToolStripMenuItem.Text = "Play Video";
            // 
            // playlistStatusStrip
            // 
            this.playlistStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textInfoStatusLabel,
            this.numberInfoStatusLabel});
            this.playlistStatusStrip.Location = new System.Drawing.Point(0, 422);
            this.playlistStatusStrip.Name = "playlistStatusStrip";
            this.playlistStatusStrip.Size = new System.Drawing.Size(624, 22);
            this.playlistStatusStrip.TabIndex = 1;
            this.playlistStatusStrip.Text = "statusStrip1";
            // 
            // textInfoStatusLabel
            // 
            this.textInfoStatusLabel.Name = "textInfoStatusLabel";
            this.textInfoStatusLabel.Size = new System.Drawing.Size(75, 17);
            this.textInfoStatusLabel.Text = "Total Videos:";
            // 
            // numberInfoStatusLabel
            // 
            this.numberInfoStatusLabel.Name = "numberInfoStatusLabel";
            this.numberInfoStatusLabel.Size = new System.Drawing.Size(13, 17);
            this.numberInfoStatusLabel.Text = "0";
            // 
            // YUPPlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 444);
            this.Controls.Add(this.playlistSplitContainer);
            this.Controls.Add(this.playlistStatusStrip);
            this.Name = "YUPPlaylistForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "YUP Playlists";
            this.Load += new System.EventHandler(this.YUPPlaylistForm_Load);
            this.Resize += new System.EventHandler(this.YUPPlaylistForm_Resize);
            this.playlistSplitContainer.Panel1.ResumeLayout(false);
            this.playlistSplitContainer.Panel1.PerformLayout();
            this.playlistSplitContainer.Panel2.ResumeLayout(false);
            this.playlistSplitContainer.Panel2.PerformLayout();
            this.playlistSplitContainer.ResumeLayout(false);
            this.playlistTreeViewToolStrip.ResumeLayout(false);
            this.playlistTreeViewToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playlistDataGrid)).EndInit();
            this.playlistDataGridToolStrip.ResumeLayout(false);
            this.playlistDataGridToolStrip.PerformLayout();
            this.treeViewContextMenu.ResumeLayout(false);
            this.dataGridContextMenu.ResumeLayout(false);
            this.playlistStatusStrip.ResumeLayout(false);
            this.playlistStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer playlistSplitContainer;
        private System.Windows.Forms.TreeView playlistTreeView;
        private System.Windows.Forms.DataGridView playlistDataGrid;
        private System.Windows.Forms.StatusStrip playlistStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel textInfoStatusLabel;
        private System.Windows.Forms.ContextMenuStrip treeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deletePlaylistToolStripMenuItem;
        private System.Windows.Forms.ImageList playlistTreeImageList;
        private System.Windows.Forms.ToolStripStatusLabel numberInfoStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem editPlaylistToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip dataGridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator playThisPlaylistToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem playThisPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStrip playlistTreeViewToolStrip;
        private System.Windows.Forms.ToolStripButton newPlaylistButton;
        private System.Windows.Forms.ToolStripButton editPlaylistButton;
        private System.Windows.Forms.ToolStripButton deletePlaylistButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton reloadPlaylistsButton;
        private System.Windows.Forms.ToolStrip playlistDataGridToolStrip;
        private System.Windows.Forms.ToolStripButton videoAddButton;
        private System.Windows.Forms.ToolStripButton videoDeleteButton;
        private System.Windows.Forms.ToolStripSeparator playPlaylistToolStripSeparator;
        private System.Windows.Forms.ToolStripButton playPlaylistButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plugin;
        private System.Windows.Forms.ToolStripSeparator playVideoButtonSeparator;
        private System.Windows.Forms.ToolStripButton playVideoButton;
        private System.Windows.Forms.ToolStripSeparator playThisVideoToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem playThisVideoToolStripMenuItem;
    }
}