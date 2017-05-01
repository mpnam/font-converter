using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace font_converter
{
    public partial class InitializeDocument : Form
    {
        public Microsoft.Office.Interop.Word.Application wordApp;
        private string filePath;
        private Microsoft.Office.Interop.Word.Document openedDocument;
        private HashSet<string> fonts; // use hashset to maintain unique list

        public InitializeDocument(Microsoft.Office.Interop.Word.Application wordApp, string file)
        {
            InitializeComponent();

            this.wordApp = wordApp;
            fonts = new HashSet<string>();
            filePath = file;
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(doWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(runWorkerCompleted);

            backgroundWorker.RunWorkerAsync();
        }

        public List<string> GetUsedFonts()
        {
            return fonts.ToList<string>();
        }
        

        private void doWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            openedDocument = wordApp.Documents.Open(filePath);

            worker.ReportProgress(1, "Detecting fonts are currently used in the document...");
            
            List<string> allFonts = getFontsUsed();
            for (int i = 0;i < allFonts.Count;i++)
            {
                fonts.Add(allFonts[i]);
                worker.ReportProgress(1);
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



        /// <summary>
        /// Return list of fonts are used in the opened document
        /// </summary>
        /// <returns>{List<String>} list of name of fonts are used</returns>
        private List<string> getFontsUsed()
        {
            List<string> result = new List<string>();

            foreach (Microsoft.Office.Interop.Word.Paragraph p in openedDocument.Paragraphs)
            {
                result.Add(p.Range.Font.Name);
            }

            return result;
        }
    }
}
