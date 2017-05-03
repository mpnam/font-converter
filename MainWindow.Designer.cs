namespace font_converter
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.fileInput = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fontList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancleButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.dataGridUsedFonts = new System.Windows.Forms.DataGridView();
            this.colCurrentFont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConvertTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.directoryInput = new System.Windows.Forms.TextBox();
            this.DirectoryBrowse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsedFonts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            // 
            // fileInput
            // 
            this.fileInput.Enabled = false;
            this.fileInput.Location = new System.Drawing.Point(133, 23);
            this.fileInput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.fileInput.Name = "fileInput";
            this.fileInput.Size = new System.Drawing.Size(817, 31);
            this.fileInput.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(966, 17);
            this.browseButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(150, 44);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Detected Font:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 570);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Convert All To:";
            // 
            // fontList
            // 
            this.fontList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.fontList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.fontList.FormattingEnabled = true;
            this.fontList.Location = new System.Drawing.Point(614, 562);
            this.fontList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.fontList.Name = "fontList";
            this.fontList.Size = new System.Drawing.Size(498, 33);
            this.fontList.TabIndex = 5;
            this.fontList.SelectedIndexChanged += new System.EventHandler(this.fontList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(16, 624);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1108, 4);
            this.label4.TabIndex = 6;
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(966, 633);
            this.cancleButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(150, 44);
            this.cancleButton.TabIndex = 2;
            this.cancleButton.Text = "Cancel";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(804, 633);
            this.convertButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(150, 44);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // dataGridUsedFonts
            // 
            this.dataGridUsedFonts.AllowUserToAddRows = false;
            this.dataGridUsedFonts.AllowUserToDeleteRows = false;
            this.dataGridUsedFonts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridUsedFonts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsedFonts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCurrentFont,
            this.colConvertTo});
            this.dataGridUsedFonts.Location = new System.Drawing.Point(30, 199);
            this.dataGridUsedFonts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridUsedFonts.Name = "dataGridUsedFonts";
            this.dataGridUsedFonts.Size = new System.Drawing.Size(1086, 342);
            this.dataGridUsedFonts.TabIndex = 7;
            // 
            // colCurrentFont
            // 
            this.colCurrentFont.DataPropertyName = "currentfont";
            this.colCurrentFont.HeaderText = "Current Font";
            this.colCurrentFont.Name = "colCurrentFont";
            this.colCurrentFont.ReadOnly = true;
            this.colCurrentFont.Width = 200;
            // 
            // colConvertTo
            // 
            this.colConvertTo.DataPropertyName = "convertto";
            this.colConvertTo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colConvertTo.HeaderText = "Convert To";
            this.colConvertTo.Name = "colConvertTo";
            this.colConvertTo.Width = 300;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(16, 639);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(121, 25);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "Version 1.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Directory";
            // 
            // directoryInput
            // 
            this.directoryInput.Enabled = false;
            this.directoryInput.Location = new System.Drawing.Point(134, 66);
            this.directoryInput.Margin = new System.Windows.Forms.Padding(6);
            this.directoryInput.Name = "directoryInput";
            this.directoryInput.Size = new System.Drawing.Size(817, 31);
            this.directoryInput.TabIndex = 1;
            // 
            // DirectoryBrowse
            // 
            this.DirectoryBrowse.Location = new System.Drawing.Point(966, 63);
            this.DirectoryBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.DirectoryBrowse.Name = "DirectoryBrowse";
            this.DirectoryBrowse.Size = new System.Drawing.Size(150, 44);
            this.DirectoryBrowse.TabIndex = 2;
            this.DirectoryBrowse.Text = "Browse";
            this.DirectoryBrowse.UseVisualStyleBackColor = true;
            this.DirectoryBrowse.Click += new System.EventHandler(this.DirectoryBrowse_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 688);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.dataGridUsedFonts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fontList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.DirectoryBrowse);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.directoryInput);
            this.Controls.Add(this.fileInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainWindow";
            this.Text = "Font Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsedFonts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileInput;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fontList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.DataGridView dataGridUsedFonts;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentFont;
        private System.Windows.Forms.DataGridViewComboBoxColumn colConvertTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox directoryInput;
        private System.Windows.Forms.Button DirectoryBrowse;
    }
}

