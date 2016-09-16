namespace Ca.Magrathean.Yup.Forms.PlaylistForms
{
    partial class AddToPlaylistForm
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
            this.videoViewsLabel = new System.Windows.Forms.Label();
            this.viewsStaticLabel = new System.Windows.Forms.Label();
            this.videoLengthLabel = new System.Windows.Forms.Label();
            this.lengthStaticLabel = new System.Windows.Forms.Label();
            this.videoAuthorLink = new System.Windows.Forms.LinkLabel();
            this.uploadedByStaticLabel = new System.Windows.Forms.Label();
            this.videoTitleLabel = new System.Windows.Forms.Label();
            this.videoThumbnail = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.videoYUMIcon = new System.Windows.Forms.PictureBox();
            this.playlistList = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.videoThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoYUMIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // videoViewsLabel
            // 
            this.videoViewsLabel.AutoSize = true;
            this.videoViewsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoViewsLabel.Location = new System.Drawing.Point(152, 98);
            this.videoViewsLabel.Name = "videoViewsLabel";
            this.videoViewsLabel.Size = new System.Drawing.Size(46, 13);
            this.videoViewsLabel.TabIndex = 15;
            this.videoViewsLabel.Text = "42,000";
            // 
            // viewsStaticLabel
            // 
            this.viewsStaticLabel.AutoSize = true;
            this.viewsStaticLabel.Location = new System.Drawing.Point(119, 98);
            this.viewsStaticLabel.Name = "viewsStaticLabel";
            this.viewsStaticLabel.Size = new System.Drawing.Size(38, 13);
            this.viewsStaticLabel.TabIndex = 14;
            this.viewsStaticLabel.Text = "Views:";
            // 
            // videoLengthLabel
            // 
            this.videoLengthLabel.AutoSize = true;
            this.videoLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoLengthLabel.Location = new System.Drawing.Point(157, 81);
            this.videoLengthLabel.Name = "videoLengthLabel";
            this.videoLengthLabel.Size = new System.Drawing.Size(32, 13);
            this.videoLengthLabel.TabIndex = 13;
            this.videoLengthLabel.Text = "4:20";
            // 
            // lengthStaticLabel
            // 
            this.lengthStaticLabel.AutoSize = true;
            this.lengthStaticLabel.Location = new System.Drawing.Point(119, 81);
            this.lengthStaticLabel.Name = "lengthStaticLabel";
            this.lengthStaticLabel.Size = new System.Drawing.Size(43, 13);
            this.lengthStaticLabel.TabIndex = 12;
            this.lengthStaticLabel.Text = "Length:";
            // 
            // videoAuthorLink
            // 
            this.videoAuthorLink.AutoSize = true;
            this.videoAuthorLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoAuthorLink.Location = new System.Drawing.Point(184, 64);
            this.videoAuthorLink.Name = "videoAuthorLink";
            this.videoAuthorLink.Size = new System.Drawing.Size(47, 13);
            this.videoAuthorLink.TabIndex = 11;
            this.videoAuthorLink.TabStop = true;
            this.videoAuthorLink.Text = "FoxDiller";
            // 
            // uploadedByStaticLabel
            // 
            this.uploadedByStaticLabel.AutoSize = true;
            this.uploadedByStaticLabel.Location = new System.Drawing.Point(118, 64);
            this.uploadedByStaticLabel.Name = "uploadedByStaticLabel";
            this.uploadedByStaticLabel.Size = new System.Drawing.Size(71, 13);
            this.uploadedByStaticLabel.TabIndex = 10;
            this.uploadedByStaticLabel.Text = "Uploaded By:";
            // 
            // videoTitleLabel
            // 
            this.videoTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoTitleLabel.Location = new System.Drawing.Point(118, 12);
            this.videoTitleLabel.Name = "videoTitleLabel";
            this.videoTitleLabel.Size = new System.Drawing.Size(326, 52);
            this.videoTitleLabel.TabIndex = 9;
            this.videoTitleLabel.Text = "Junkie XL - Zerotonine";
            // 
            // videoThumbnail
            // 
            this.videoThumbnail.Location = new System.Drawing.Point(12, 12);
            this.videoThumbnail.Name = "videoThumbnail";
            this.videoThumbnail.Size = new System.Drawing.Size(100, 100);
            this.videoThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoThumbnail.TabIndex = 8;
            this.videoThumbnail.TabStop = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 4);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(368, 245);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(287, 245);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 20;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // videoYUMIcon
            // 
            this.videoYUMIcon.Location = new System.Drawing.Point(412, 81);
            this.videoYUMIcon.Name = "videoYUMIcon";
            this.videoYUMIcon.Size = new System.Drawing.Size(32, 32);
            this.videoYUMIcon.TabIndex = 21;
            this.videoYUMIcon.TabStop = false;
            // 
            // playlistList
            // 
            this.playlistList.CheckOnClick = true;
            this.playlistList.FormattingEnabled = true;
            this.playlistList.Location = new System.Drawing.Point(13, 129);
            this.playlistList.Name = "playlistList";
            this.playlistList.ScrollAlwaysVisible = true;
            this.playlistList.Size = new System.Drawing.Size(431, 109);
            this.playlistList.TabIndex = 22;
            this.playlistList.ThreeDCheckBoxes = true;
            // 
            // AddToPlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 276);
            this.Controls.Add(this.playlistList);
            this.Controls.Add(this.videoYUMIcon);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoViewsLabel);
            this.Controls.Add(this.viewsStaticLabel);
            this.Controls.Add(this.videoLengthLabel);
            this.Controls.Add(this.lengthStaticLabel);
            this.Controls.Add(this.videoAuthorLink);
            this.Controls.Add(this.uploadedByStaticLabel);
            this.Controls.Add(this.videoTitleLabel);
            this.Controls.Add(this.videoThumbnail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddToPlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Video To Playlist";
            this.Load += new System.EventHandler(this.AddToPlaylistForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoYUMIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label videoViewsLabel;
        private System.Windows.Forms.Label viewsStaticLabel;
        private System.Windows.Forms.Label videoLengthLabel;
        private System.Windows.Forms.Label lengthStaticLabel;
        private System.Windows.Forms.LinkLabel videoAuthorLink;
        private System.Windows.Forms.Label uploadedByStaticLabel;
        private System.Windows.Forms.Label videoTitleLabel;
        private System.Windows.Forms.PictureBox videoThumbnail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.PictureBox videoYUMIcon;
        private System.Windows.Forms.CheckedListBox playlistList;
    }
}