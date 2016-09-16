namespace Ca.Magrathean.Yup.Forms
{
    partial class YUPExportJobsForm
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
            this.flowLayoutPanel_Jobs = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_Jobs
            // 
            this.flowLayoutPanel_Jobs.AutoScroll = true;
            this.flowLayoutPanel_Jobs.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel_Jobs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel_Jobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_Jobs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_Jobs.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_Jobs.Name = "flowLayoutPanel_Jobs";
            this.flowLayoutPanel_Jobs.Size = new System.Drawing.Size(404, 264);
            this.flowLayoutPanel_Jobs.TabIndex = 0;
            this.flowLayoutPanel_Jobs.WrapContents = false;
            this.flowLayoutPanel_Jobs.Layout += new System.Windows.Forms.LayoutEventHandler(this.flowLayoutPanel_Jobs_Layout);
            // 
            // YUPExportJobsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 264);
            this.Controls.Add(this.flowLayoutPanel_Jobs);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(420, 300);
            this.Name = "YUPExportJobsForm";
            this.ShowInTaskbar = false;
            this.Text = "Export Jobs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Jobs;
    }
}