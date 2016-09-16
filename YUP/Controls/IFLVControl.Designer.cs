namespace Ca.Magrathean.Yup.Controls
{
    partial class IFLVControl
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
            this.FLVTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FLVAuthorLink = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.FLVTime = new System.Windows.Forms.Label();
            this.FLVThumbnailImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FLVThumbnailImage)).BeginInit();
            this.SuspendLayout();
            // 
            // FLVTitle
            // 
            this.FLVTitle.AutoSize = true;
            this.FLVTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FLVTitle.Location = new System.Drawing.Point(55, 5);
            this.FLVTitle.Name = "FLVTitle";
            this.FLVTitle.Size = new System.Drawing.Size(178, 16);
            this.FLVTitle.TabIndex = 1;
            this.FLVTitle.Text = "Junkie XL - Zero To Nine";
            this.FLVTitle.MouseLeave += new System.EventHandler(this.IFLVControl_MouseLeave);
            this.FLVTitle.Click += new System.EventHandler(this.Control_Click);
            this.FLVTitle.MouseEnter += new System.EventHandler(this.IFLVControl_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Uploaded by:";
            this.label2.MouseLeave += new System.EventHandler(this.IFLVControl_MouseLeave);
            this.label2.Click += new System.EventHandler(this.Control_Click);
            this.label2.MouseEnter += new System.EventHandler(this.IFLVControl_MouseEnter);
            // 
            // FLVAuthorLink
            // 
            this.FLVAuthorLink.ActiveLinkColor = System.Drawing.Color.Blue;
            this.FLVAuthorLink.AutoSize = true;
            this.FLVAuthorLink.Location = new System.Drawing.Point(121, 22);
            this.FLVAuthorLink.Name = "FLVAuthorLink";
            this.FLVAuthorLink.Size = new System.Drawing.Size(47, 13);
            this.FLVAuthorLink.TabIndex = 3;
            this.FLVAuthorLink.TabStop = true;
            this.FLVAuthorLink.Text = "FoxDiller";
            this.FLVAuthorLink.MouseLeave += new System.EventHandler(this.IFLVControl_MouseLeave);
            this.FLVAuthorLink.MouseEnter += new System.EventHandler(this.IFLVControl_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time:";
            this.label3.MouseLeave += new System.EventHandler(this.IFLVControl_MouseLeave);
            this.label3.Click += new System.EventHandler(this.Control_Click);
            this.label3.MouseEnter += new System.EventHandler(this.IFLVControl_MouseEnter);
            // 
            // FLVTime
            // 
            this.FLVTime.AutoSize = true;
            this.FLVTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FLVTime.Location = new System.Drawing.Point(83, 38);
            this.FLVTime.Name = "FLVTime";
            this.FLVTime.Size = new System.Drawing.Size(32, 13);
            this.FLVTime.TabIndex = 5;
            this.FLVTime.Text = "4:20";
            this.FLVTime.MouseLeave += new System.EventHandler(this.IFLVControl_MouseLeave);
            this.FLVTime.Click += new System.EventHandler(this.Control_Click);
            this.FLVTime.MouseEnter += new System.EventHandler(this.IFLVControl_MouseEnter);
            // 
            // FLVThumbnailImage
            // 
            this.FLVThumbnailImage.Location = new System.Drawing.Point(5, 4);
            this.FLVThumbnailImage.Margin = new System.Windows.Forms.Padding(0);
            this.FLVThumbnailImage.Name = "FLVThumbnailImage";
            this.FLVThumbnailImage.Size = new System.Drawing.Size(50, 50);
            this.FLVThumbnailImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FLVThumbnailImage.TabIndex = 0;
            this.FLVThumbnailImage.TabStop = false;
            this.FLVThumbnailImage.MouseLeave += new System.EventHandler(this.IFLVControl_MouseLeave);
            this.FLVThumbnailImage.Click += new System.EventHandler(this.Control_Click);
            this.FLVThumbnailImage.MouseEnter += new System.EventHandler(this.IFLVControl_MouseEnter);
            // 
            // IFLVControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.FLVTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FLVAuthorLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FLVTitle);
            this.Controls.Add(this.FLVThumbnailImage);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.MaximumSize = new System.Drawing.Size(4000, 60);
            this.MinimumSize = new System.Drawing.Size(250, 60);
            this.Name = "IFLVControl";
            this.Size = new System.Drawing.Size(420, 58);
            this.MouseLeave += new System.EventHandler(this.IFLVControl_MouseLeave);
            this.MouseEnter += new System.EventHandler(this.IFLVControl_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.FLVThumbnailImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FLVThumbnailImage;
        private System.Windows.Forms.Label FLVTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel FLVAuthorLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FLVTime;
    }
}
