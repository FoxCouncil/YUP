namespace Ca.Magrathean.Yup.Forms
{
    /// <summary>
    /// A form to show information of an IFLV object.
    /// </summary>
    partial class YUPVideoInfoForm
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
            this.videoThumbnail = new System.Windows.Forms.PictureBox();
            this.videoTitleLabel = new System.Windows.Forms.Label();
            this.uploadedByStaticLabel = new System.Windows.Forms.Label();
            this.videoAuthorLink = new System.Windows.Forms.LinkLabel();
            this.lengthStaticLabel = new System.Windows.Forms.Label();
            this.videoLengthLabel = new System.Windows.Forms.Label();
            this.viewsStaticLabel = new System.Windows.Forms.Label();
            this.videoViewsLabel = new System.Windows.Forms.Label();
            this.definitionPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.videoThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // videoThumbnail
            // 
            this.videoThumbnail.Location = new System.Drawing.Point(13, 13);
            this.videoThumbnail.Name = "videoThumbnail";
            this.videoThumbnail.Size = new System.Drawing.Size(100, 100);
            this.videoThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoThumbnail.TabIndex = 0;
            this.videoThumbnail.TabStop = false;
            // 
            // videoTitleLabel
            // 
            this.videoTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoTitleLabel.Location = new System.Drawing.Point(119, 13);
            this.videoTitleLabel.Name = "videoTitleLabel";
            this.videoTitleLabel.Size = new System.Drawing.Size(253, 52);
            this.videoTitleLabel.TabIndex = 1;
            this.videoTitleLabel.Text = "Junkie XL - Zerotonine";
            // 
            // uploadedByStaticLabel
            // 
            this.uploadedByStaticLabel.AutoSize = true;
            this.uploadedByStaticLabel.Location = new System.Drawing.Point(119, 65);
            this.uploadedByStaticLabel.Name = "uploadedByStaticLabel";
            this.uploadedByStaticLabel.Size = new System.Drawing.Size(71, 13);
            this.uploadedByStaticLabel.TabIndex = 2;
            this.uploadedByStaticLabel.Text = "Uploaded By:";
            // 
            // videoAuthorLink
            // 
            this.videoAuthorLink.AutoSize = true;
            this.videoAuthorLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoAuthorLink.Location = new System.Drawing.Point(185, 65);
            this.videoAuthorLink.Name = "videoAuthorLink";
            this.videoAuthorLink.Size = new System.Drawing.Size(47, 13);
            this.videoAuthorLink.TabIndex = 3;
            this.videoAuthorLink.TabStop = true;
            this.videoAuthorLink.Text = "FoxDiller";
            // 
            // lengthStaticLabel
            // 
            this.lengthStaticLabel.AutoSize = true;
            this.lengthStaticLabel.Location = new System.Drawing.Point(120, 82);
            this.lengthStaticLabel.Name = "lengthStaticLabel";
            this.lengthStaticLabel.Size = new System.Drawing.Size(43, 13);
            this.lengthStaticLabel.TabIndex = 4;
            this.lengthStaticLabel.Text = "Length:";
            // 
            // videoLengthLabel
            // 
            this.videoLengthLabel.AutoSize = true;
            this.videoLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoLengthLabel.Location = new System.Drawing.Point(158, 82);
            this.videoLengthLabel.Name = "videoLengthLabel";
            this.videoLengthLabel.Size = new System.Drawing.Size(32, 13);
            this.videoLengthLabel.TabIndex = 5;
            this.videoLengthLabel.Text = "4:20";
            // 
            // viewsStaticLabel
            // 
            this.viewsStaticLabel.AutoSize = true;
            this.viewsStaticLabel.Location = new System.Drawing.Point(120, 99);
            this.viewsStaticLabel.Name = "viewsStaticLabel";
            this.viewsStaticLabel.Size = new System.Drawing.Size(38, 13);
            this.viewsStaticLabel.TabIndex = 6;
            this.viewsStaticLabel.Text = "Views:";
            // 
            // videoViewsLabel
            // 
            this.videoViewsLabel.AutoSize = true;
            this.videoViewsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoViewsLabel.Location = new System.Drawing.Point(153, 99);
            this.videoViewsLabel.Name = "videoViewsLabel";
            this.videoViewsLabel.Size = new System.Drawing.Size(46, 13);
            this.videoViewsLabel.TabIndex = 7;
            this.videoViewsLabel.Text = "42,000";
            // 
            // definitionPictureBox
            // 
            this.definitionPictureBox.Image = global::Ca.Magrathean.Yup.Properties.Resources.SD;
            this.definitionPictureBox.Location = new System.Drawing.Point(302, 72);
            this.definitionPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.definitionPictureBox.Name = "definitionPictureBox";
            this.definitionPictureBox.Size = new System.Drawing.Size(75, 45);
            this.definitionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.definitionPictureBox.TabIndex = 8;
            this.definitionPictureBox.TabStop = false;
            // 
            // YUPVideoInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 124);
            this.Controls.Add(this.definitionPictureBox);
            this.Controls.Add(this.videoViewsLabel);
            this.Controls.Add(this.viewsStaticLabel);
            this.Controls.Add(this.videoLengthLabel);
            this.Controls.Add(this.lengthStaticLabel);
            this.Controls.Add(this.videoAuthorLink);
            this.Controls.Add(this.uploadedByStaticLabel);
            this.Controls.Add(this.videoTitleLabel);
            this.Controls.Add(this.videoThumbnail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "YUPVideoInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Video Info";
            this.Load += new System.EventHandler(this.YUPVideoInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox videoThumbnail;
        private System.Windows.Forms.Label videoTitleLabel;
        private System.Windows.Forms.Label uploadedByStaticLabel;
        private System.Windows.Forms.LinkLabel videoAuthorLink;
        private System.Windows.Forms.Label lengthStaticLabel;
        private System.Windows.Forms.Label videoLengthLabel;
        private System.Windows.Forms.Label viewsStaticLabel;
        private System.Windows.Forms.Label videoViewsLabel;
        private System.Windows.Forms.PictureBox definitionPictureBox;
    }
}