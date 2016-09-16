namespace Ca.Magrathean.Yup.Forms
{
    partial class YUPErrorBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YUPErrorBox));
            this.errorHeadingLabel = new System.Windows.Forms.Label();
            this.errorSubHeadingLabel = new System.Windows.Forms.Label();
            this.errorSeperator1 = new System.Windows.Forms.Label();
            this.errorPictureBox = new System.Windows.Forms.PictureBox();
            this.errorSeperator2 = new System.Windows.Forms.Label();
            this.errorExplinationLabel = new System.Windows.Forms.Label();
            this.detailsToggleButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.sendReportButton = new System.Windows.Forms.Button();
            this.tasksRemainingLabel = new System.Windows.Forms.Label();
            this.tasksRemainLabel = new System.Windows.Forms.Label();
            this.errorDetails = new System.Windows.Forms.TextBox();
            this.errorSeperator3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // errorHeadingLabel
            // 
            this.errorHeadingLabel.AutoSize = true;
            this.errorHeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorHeadingLabel.Location = new System.Drawing.Point(69, 13);
            this.errorHeadingLabel.Name = "errorHeadingLabel";
            this.errorHeadingLabel.Size = new System.Drawing.Size(245, 24);
            this.errorHeadingLabel.TabIndex = 0;
            this.errorHeadingLabel.Text = "There has been an error.";
            // 
            // errorSubHeadingLabel
            // 
            this.errorSubHeadingLabel.AutoSize = true;
            this.errorSubHeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorSubHeadingLabel.Location = new System.Drawing.Point(69, 41);
            this.errorSubHeadingLabel.Name = "errorSubHeadingLabel";
            this.errorSubHeadingLabel.Size = new System.Drawing.Size(317, 20);
            this.errorSubHeadingLabel.TabIndex = 1;
            this.errorSubHeadingLabel.Text = "YUP needs to close due to an internal error.";
            // 
            // errorSeperator1
            // 
            this.errorSeperator1.BackColor = System.Drawing.Color.Black;
            this.errorSeperator1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errorSeperator1.Location = new System.Drawing.Point(12, 69);
            this.errorSeperator1.Name = "errorSeperator1";
            this.errorSeperator1.Size = new System.Drawing.Size(442, 4);
            this.errorSeperator1.TabIndex = 2;
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Image = global::Ca.Magrathean.Yup.Properties.Resources.error;
            this.errorPictureBox.Location = new System.Drawing.Point(13, 13);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(60, 48);
            this.errorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.errorPictureBox.TabIndex = 3;
            this.errorPictureBox.TabStop = false;
            // 
            // errorSeperator2
            // 
            this.errorSeperator2.BackColor = System.Drawing.Color.Black;
            this.errorSeperator2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errorSeperator2.Location = new System.Drawing.Point(12, 153);
            this.errorSeperator2.Name = "errorSeperator2";
            this.errorSeperator2.Size = new System.Drawing.Size(442, 4);
            this.errorSeperator2.TabIndex = 4;
            // 
            // errorExplinationLabel
            // 
            this.errorExplinationLabel.Location = new System.Drawing.Point(14, 79);
            this.errorExplinationLabel.Name = "errorExplinationLabel";
            this.errorExplinationLabel.Size = new System.Drawing.Size(439, 69);
            this.errorExplinationLabel.TabIndex = 5;
            this.errorExplinationLabel.Text = resources.GetString("errorExplinationLabel.Text");
            // 
            // detailsToggleButton
            // 
            this.detailsToggleButton.Location = new System.Drawing.Point(12, 163);
            this.detailsToggleButton.Name = "detailsToggleButton";
            this.detailsToggleButton.Size = new System.Drawing.Size(82, 23);
            this.detailsToggleButton.TabIndex = 6;
            this.detailsToggleButton.Text = "Show Details";
            this.detailsToggleButton.UseVisualStyleBackColor = true;
            this.detailsToggleButton.Click += new System.EventHandler(this.detailsToggleButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(379, 163);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // sendReportButton
            // 
            this.sendReportButton.Enabled = false;
            this.sendReportButton.Location = new System.Drawing.Point(268, 163);
            this.sendReportButton.Name = "sendReportButton";
            this.sendReportButton.Size = new System.Drawing.Size(105, 23);
            this.sendReportButton.TabIndex = 8;
            this.sendReportButton.Text = "Send Error Report";
            this.sendReportButton.UseVisualStyleBackColor = true;
            // 
            // tasksRemainingLabel
            // 
            this.tasksRemainingLabel.AutoSize = true;
            this.tasksRemainingLabel.Location = new System.Drawing.Point(99, 168);
            this.tasksRemainingLabel.Name = "tasksRemainingLabel";
            this.tasksRemainingLabel.Size = new System.Drawing.Size(92, 13);
            this.tasksRemainingLabel.TabIndex = 9;
            this.tasksRemainingLabel.Text = "Tasks Remaining:";
            // 
            // tasksRemainLabel
            // 
            this.tasksRemainLabel.AutoSize = true;
            this.tasksRemainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksRemainLabel.Location = new System.Drawing.Point(188, 167);
            this.tasksRemainLabel.Name = "tasksRemainLabel";
            this.tasksRemainLabel.Size = new System.Drawing.Size(23, 15);
            this.tasksRemainLabel.TabIndex = 10;
            this.tasksRemainLabel.Text = "42";
            // 
            // errorDetails
            // 
            this.errorDetails.Location = new System.Drawing.Point(12, 206);
            this.errorDetails.Multiline = true;
            this.errorDetails.Name = "errorDetails";
            this.errorDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errorDetails.Size = new System.Drawing.Size(442, 192);
            this.errorDetails.TabIndex = 11;
            this.errorDetails.WordWrap = false;
            // 
            // errorSeperator3
            // 
            this.errorSeperator3.BackColor = System.Drawing.Color.Black;
            this.errorSeperator3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errorSeperator3.Location = new System.Drawing.Point(12, 192);
            this.errorSeperator3.Name = "errorSeperator3";
            this.errorSeperator3.Size = new System.Drawing.Size(442, 4);
            this.errorSeperator3.TabIndex = 12;
            // 
            // YUPErrorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 410);
            this.Controls.Add(this.errorSeperator3);
            this.Controls.Add(this.errorDetails);
            this.Controls.Add(this.tasksRemainLabel);
            this.Controls.Add(this.tasksRemainingLabel);
            this.Controls.Add(this.sendReportButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.detailsToggleButton);
            this.Controls.Add(this.errorExplinationLabel);
            this.Controls.Add(this.errorSeperator2);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.errorSeperator1);
            this.Controls.Add(this.errorSubHeadingLabel);
            this.Controls.Add(this.errorHeadingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "YUPErrorBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YUP Error";
            this.Load += new System.EventHandler(this.YUPErrorBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorHeadingLabel;
        private System.Windows.Forms.Label errorSubHeadingLabel;
        private System.Windows.Forms.Label errorSeperator1;
        private System.Windows.Forms.PictureBox errorPictureBox;
        private System.Windows.Forms.Label errorSeperator2;
        private System.Windows.Forms.Label errorExplinationLabel;
        private System.Windows.Forms.Button detailsToggleButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button sendReportButton;
        private System.Windows.Forms.Label tasksRemainingLabel;
        private System.Windows.Forms.Label tasksRemainLabel;
        private System.Windows.Forms.TextBox errorDetails;
        private System.Windows.Forms.Label errorSeperator3;
    }
}