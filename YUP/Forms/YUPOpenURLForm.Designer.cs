namespace Ca.Magrathean.Yup.Forms
{
    partial class YUPOpenURLForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.pluginComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.urlStatusIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.urlStatusIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(387, 63);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "&Close";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Enabled = false;
            this.loadButton.Location = new System.Drawing.Point(306, 63);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "&Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(51, 10);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(394, 20);
            this.urlTextBox.TabIndex = 3;
            this.urlTextBox.Text = "http://www.youtube.com/watch?v=ng8K4zPSKQc";
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            // 
            // pluginComboBox
            // 
            this.pluginComboBox.FormattingEnabled = true;
            this.pluginComboBox.Items.AddRange(new object[] {
            "Select a plugin..."});
            this.pluginComboBox.Location = new System.Drawing.Point(51, 36);
            this.pluginComboBox.Name = "pluginComboBox";
            this.pluginComboBox.Size = new System.Drawing.Size(394, 21);
            this.pluginComboBox.TabIndex = 4;
            this.pluginComboBox.SelectedIndexChanged += new System.EventHandler(this.pluginComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plugin:";
            // 
            // urlStatusIcon
            // 
            this.urlStatusIcon.Image = global::Ca.Magrathean.Yup.Properties.Resources.tick;
            this.urlStatusIcon.Location = new System.Drawing.Point(450, 10);
            this.urlStatusIcon.Name = "urlStatusIcon";
            this.urlStatusIcon.Size = new System.Drawing.Size(16, 16);
            this.urlStatusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.urlStatusIcon.TabIndex = 6;
            this.urlStatusIcon.TabStop = false;
            // 
            // YUPOpenURLForm
            // 
            this.AcceptButton = this.loadButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(474, 93);
            this.Controls.Add(this.urlStatusIcon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pluginComboBox);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YUPOpenURLForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open URL...";
            this.Load += new System.EventHandler(this.YUPOpenURLForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.urlStatusIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox urlTextBox;
        internal System.Windows.Forms.ComboBox pluginComboBox;
        private System.Windows.Forms.PictureBox urlStatusIcon;
    }
}