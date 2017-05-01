namespace font_converter
{
    partial class ConvertFont
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(56, 44);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(192, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            // 
            // progressStatus
            // 
            this.progressStatus.AutoSize = true;
            this.progressStatus.Location = new System.Drawing.Point(39, 19);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(68, 13);
            this.progressStatus.TabIndex = 2;
            this.progressStatus.Text = "Processing...";
            // 
            // ConvertFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 101);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.progressStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConvertFont";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConvertFont";
            this.Load += new System.EventHandler(this.ConvertFont_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressStatus;
    }
}