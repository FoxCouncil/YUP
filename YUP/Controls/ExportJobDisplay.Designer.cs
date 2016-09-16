namespace Ca.Magrathean.Yup.Controls
{
    partial class ExportJobDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBarJob = new System.Windows.Forms.ProgressBar();
            this.FLVThumbnailImage = new System.Windows.Forms.PictureBox();
            this.labelJobStatus = new System.Windows.Forms.Label();
            this.labelJobInfo = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FLVThumbnailImage)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarJob
            // 
            this.progressBarJob.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarJob.Location = new System.Drawing.Point(0, 47);
            this.progressBarJob.Name = "progressBarJob";
            this.progressBarJob.Size = new System.Drawing.Size(420, 11);
            this.progressBarJob.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarJob.TabIndex = 0;
            // 
            // FLVThumbnailImage
            // 
            this.FLVThumbnailImage.Location = new System.Drawing.Point(3, 3);
            this.FLVThumbnailImage.Margin = new System.Windows.Forms.Padding(0);
            this.FLVThumbnailImage.Name = "FLVThumbnailImage";
            this.FLVThumbnailImage.Size = new System.Drawing.Size(42, 42);
            this.FLVThumbnailImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FLVThumbnailImage.TabIndex = 1;
            this.FLVThumbnailImage.TabStop = false;
            // 
            // labelJobStatus
            // 
            this.labelJobStatus.AutoSize = true;
            this.labelJobStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJobStatus.Location = new System.Drawing.Point(48, 21);
            this.labelJobStatus.Name = "labelJobStatus";
            this.labelJobStatus.Size = new System.Drawing.Size(127, 20);
            this.labelJobStatus.TabIndex = 2;
            this.labelJobStatus.Text = "Downloading...";
            // 
            // labelJobInfo
            // 
            this.labelJobInfo.AutoSize = true;
            this.labelJobInfo.Location = new System.Drawing.Point(49, 4);
            this.labelJobInfo.Name = "labelJobInfo";
            this.labelJobInfo.Size = new System.Drawing.Size(180, 13);
            this.labelJobInfo.TabIndex = 3;
            this.labelJobInfo.Text = "[YouTube] George Michael - Freeek!";
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Image = global::Ca.Magrathean.Yup.Properties.Resources.cross;
            this.buttonStop.Location = new System.Drawing.Point(395, 4);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(22, 22);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // ExportJobDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelJobInfo);
            this.Controls.Add(this.labelJobStatus);
            this.Controls.Add(this.FLVThumbnailImage);
            this.Controls.Add(this.progressBarJob);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.MaximumSize = new System.Drawing.Size(4000, 60);
            this.MinimumSize = new System.Drawing.Size(250, 60);
            this.Name = "ExportJobDisplay";
            this.Size = new System.Drawing.Size(420, 58);
            ((System.ComponentModel.ISupportInitialize)(this.FLVThumbnailImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarJob;
        private System.Windows.Forms.PictureBox FLVThumbnailImage;
        private System.Windows.Forms.Label labelJobStatus;
        private System.Windows.Forms.Label labelJobInfo;
        private System.Windows.Forms.Button buttonStop;
    }
}
