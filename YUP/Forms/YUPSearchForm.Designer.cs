namespace Ca.Magrathean.Yup.Forms
{
    partial class YUPSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YUPSearchForm));
            this.searchWorker = new System.ComponentModel.BackgroundWorker();
            this.searchResultsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.searchToolStrip = new System.Windows.Forms.ToolStrip();
            this.queryTextBox = new Ca.Magrathean.Yup.Controls.ToolStripSpringTextBox();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.searchResultMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.videoInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spinnerControl = new Ca.Magrathean.Yup.Controls.Spinner();
            this.searchToolStrip.SuspendLayout();
            this.searchResultMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchWorker
            // 
            this.searchWorker.WorkerReportsProgress = true;
            this.searchWorker.WorkerSupportsCancellation = true;
            // 
            // searchResultsFlow
            // 
            this.searchResultsFlow.AutoScroll = true;
            this.searchResultsFlow.BackColor = System.Drawing.Color.White;
            this.searchResultsFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchResultsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResultsFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.searchResultsFlow.Location = new System.Drawing.Point(0, 27);
            this.searchResultsFlow.Name = "searchResultsFlow";
            this.searchResultsFlow.Size = new System.Drawing.Size(391, 237);
            this.searchResultsFlow.TabIndex = 6;
            this.searchResultsFlow.WrapContents = false;
            this.searchResultsFlow.Layout += new System.Windows.Forms.LayoutEventHandler(this.searchResultsFlow_Layout);
            // 
            // searchToolStrip
            // 
            this.searchToolStrip.AutoSize = false;
            this.searchToolStrip.CanOverflow = false;
            this.searchToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.searchToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryTextBox,
            this.searchButton});
            this.searchToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.searchToolStrip.Location = new System.Drawing.Point(0, 0);
            this.searchToolStrip.Name = "searchToolStrip";
            this.searchToolStrip.Padding = new System.Windows.Forms.Padding(2);
            this.searchToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.searchToolStrip.Size = new System.Drawing.Size(391, 27);
            this.searchToolStrip.Stretch = true;
            this.searchToolStrip.TabIndex = 7;
            this.searchToolStrip.Text = "toolStrip1";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(274, 23);
            this.queryTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.queryTextBox_KeyDown);
            this.queryTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.queryTextBox_KeyPress);
            this.queryTextBox.TextChanged += new System.EventHandler(this.queryTextBox_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.AutoSize = false;
            this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.searchButton.Enabled = false;
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchButton.Margin = new System.Windows.Forms.Padding(0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.searchButton.Size = new System.Drawing.Size(80, 23);
            this.searchButton.Text = "&Search";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchResultMenu
            // 
            this.searchResultMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToPlaylistToolStripMenuItem,
            this.addToFavoritesToolStripMenuItem,
            this.toolStripSeparator2,
            this.videoInfoToolStripMenuItem});
            this.searchResultMenu.Name = "searchResultMenu";
            this.searchResultMenu.ShowItemToolTips = false;
            this.searchResultMenu.Size = new System.Drawing.Size(164, 104);
            this.searchResultMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.searchResultMenu_ItemClicked);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.control_play;
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.playToolStripMenuItem.Text = "Play Video";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // addToPlaylistToolStripMenuItem
            // 
            this.addToPlaylistToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.book_link;
            this.addToPlaylistToolStripMenuItem.Name = "addToPlaylistToolStripMenuItem";
            this.addToPlaylistToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addToPlaylistToolStripMenuItem.Text = "Add To Playlist";
            // 
            // addToFavoritesToolStripMenuItem
            // 
            this.addToFavoritesToolStripMenuItem.Enabled = false;
            this.addToFavoritesToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.heart_add;
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            this.addToFavoritesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addToFavoritesToolStripMenuItem.Text = "Add To Favorites";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // videoInfoToolStripMenuItem
            // 
            this.videoInfoToolStripMenuItem.Image = global::Ca.Magrathean.Yup.Properties.Resources.information;
            this.videoInfoToolStripMenuItem.Name = "videoInfoToolStripMenuItem";
            this.videoInfoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.videoInfoToolStripMenuItem.Text = "Video Info";
            // 
            // spinnerControl
            // 
            this.spinnerControl.BackColor = System.Drawing.Color.Gainsboro;
            this.spinnerControl.DisplaySegmentText = false;
            this.spinnerControl.DisplayString = "";
            this.spinnerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinnerControl.Location = new System.Drawing.Point(0, 27);
            this.spinnerControl.Name = "spinnerControl";
            this.spinnerControl.Segments = 12;
            this.spinnerControl.Size = new System.Drawing.Size(391, 237);
            this.spinnerControl.TabIndex = 8;
            this.spinnerControl.Text = "12";
            this.spinnerControl.Visible = false;
            // 
            // YUPSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(391, 264);
            this.Controls.Add(this.spinnerControl);
            this.Controls.Add(this.searchResultsFlow);
            this.Controls.Add(this.searchToolStrip);
            this.DoubleBuffered = true;
            this.Name = "YUPSearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Single Search";
            this.SizeChanged += new System.EventHandler(this.YUPSearchForm_SizeChanged);
            this.searchToolStrip.ResumeLayout(false);
            this.searchToolStrip.PerformLayout();
            this.searchResultMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker searchWorker;
        private System.Windows.Forms.FlowLayoutPanel searchResultsFlow;
        private System.Windows.Forms.ToolStrip searchToolStrip;
        private Ca.Magrathean.Yup.Controls.ToolStripSpringTextBox queryTextBox;
        private System.Windows.Forms.ToolStripButton searchButton;
        private System.Windows.Forms.ContextMenuStrip searchResultMenu;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToFavoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem videoInfoToolStripMenuItem;
        private Ca.Magrathean.Yup.Controls.Spinner spinnerControl;



    }
}