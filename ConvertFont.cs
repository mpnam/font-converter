using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace font_converter
{
    public partial class ConvertFont : Form
    {
        public Microsoft.Office.Interop.Word.Application wordApp;
        private DataTable dtFonts;

        public ConvertFont(Microsoft.Office.Interop.Word.Application wordApp, DataTable dtFonts)
        {
            InitializeComponent();

            this.wordApp = wordApp;
            this.dtFonts = dtFonts;
        }

        private void ConvertFont_Load(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(doWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(runWorkerCompleted);

            backgroundWorker.RunWorkerAsync();
        }

        private void doWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            // dictionary is faster than data table
            Dictionary<string, string> fontMapping = new Dictionary<string, string>();
            foreach(DataRow row in dtFonts.Rows)
                fontMapping.Add(row["currentfont"].ToString(), row["convertto"].ToString());

            // Convert each document in the list
            foreach(Microsoft.Office.Interop.Word.Document doc in wordApp.Documents)
            {
                worker.ReportProgress(1, "Converting document " + doc.Name + " ...");

                foreach (Microsoft.Office.Interop.Word.Paragraph p in doc.Paragraphs)
                {
                    p.Range.Font.Name = fontMapping[p.Range.Font.Name];
                    p.Range.Select();
                }

                foreach (Microsoft.Office.Interop.Word.Shape s in doc.Shapes)
                {
                    s.TextFrame.TextRange.Font.Name = fontMapping[s.TextFrame.TextRange.Font.Name];
                    s.TextFrame.TextRange.Select();
                }

                doc.Save();
            }

            worker.ReportProgress(100);
        }

        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
                progressStatus.Text = e.UserState.ToString();
        }

        private void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                progressStatus.Text = "Error: " + e.Error.Message;
                throw new Exception(e.Error.Message);
            }
            progressStatus.Text = "Done";
            this.Close();
        }
    }
}
