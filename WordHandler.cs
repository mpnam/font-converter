using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.ComponentModel;
using System.Data;

namespace font_converter
{
    public class WordHandler
    {
        private Application wordApp;
        private HashSet<string> fonts; // use hashset to maintain unique list
        private WaitingForm waiting;

        private CallBack.DocumentsLoaded documentLoadedEvent;
        private CallBack.FontsConvertFinished fontConvertedEvent;

        public WordHandler(CallBack.DocumentsLoaded documentLoadedCallback, CallBack.FontsConvertFinished fontsConvertedCallback)
        {
            wordApp = new Application();
            fonts = new HashSet<string>();
            documentLoadedEvent = documentLoadedCallback;
            fontConvertedEvent = fontsConvertedCallback;
        }

        public void Quit()
        {
            wordApp.Quit();
        }

        #region Load Documents

        /// <summary>
        /// Load document located in path
        /// </summary>
        /// <param name="path">{string} path to the document</param>
        /// <param name="reset">{bool} if true then close other documents</param>
        public void LoadDocument(string path, bool reset = false)
        {
            try
            {
                waiting = new WaitingForm();
                waiting.SetMessage("Loading document " + path + " ...");
                waiting.Show();
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(doLoadDocument);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadDocumentCompleted);
                backgroundWorker.RunWorkerAsync(new Tuple<string, bool>(path, reset));
            }
            catch (Exception ex)
            {
                waiting.Close();
                throw new Exception(ex.Message);
            }
        }

        private void doLoadDocument(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                Tuple<string, bool> argument = (Tuple<string, bool>)e.Argument;

                // close all opened documents
                if (argument.Item2)
                {
                    while (wordApp.Documents.Count > 0)
                        wordApp.Documents[wordApp.Documents.Count - 1].Close();
                    fonts = new HashSet<string>();
                }

                Document doc = wordApp.Documents.Open(argument.Item1);
                updateFontList(doc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void loadDocumentCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                throw new Exception(e.Error.Message);
            else
                waiting.Close();

            documentLoadedEvent(fonts.ToList<string>());
        }

        #endregion // end Load Documents

        #region Convert Documents

        /// <summary>
        /// Convert font of all opened documents
        /// </summary>
        /// <param name="fontMapping">{DataTable} mapping from current fonts to target fonts</param>
        public void ConvertFont(System.Data.DataTable fontMapping)
        {
            try
            {
                waiting = new WaitingForm();
                waiting.SetMessage("Converting...");
                waiting.Show();
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(doConvertDocuments);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(convertDocumentsCompleted);
                backgroundWorker.RunWorkerAsync(fontMapping);
            }
            catch (Exception ex)
            {
                waiting.Close();
                throw new Exception(ex.Message);
            }
        }

        private void doConvertDocuments(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;

                System.Data.DataTable fontMapping = (System.Data.DataTable)e.Argument;

                // dictionary is faster than data table
                Dictionary<string, string> fontsLookup = new Dictionary<string, string>();
                foreach (DataRow row in fontMapping.Rows)
                    fontsLookup.Add(row["currentfont"].ToString(), row["convertto"].ToString());

                foreach (Document doc in wordApp.Documents)
                {
                    foreach (Paragraph p in doc.Paragraphs)
                    {
                        p.Range.Font.Name = fontsLookup[p.Range.Font.Name];
                        p.Range.Select();
                    }

                    foreach (Shape s in doc.Shapes)
                    {
                        try
                        {
                            s.TextFrame.TextRange.Font.Name = fontsLookup[s.TextFrame.TextRange.Font.Name];
                            s.TextFrame.TextRange.Select();
                        }
                        catch (Exception) { } // quite tricky, some shapes does not allow to edit textframe
                    }

                    doc.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void convertDocumentsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                throw new Exception(e.Error.Message);
            else
                waiting.Close();

            fontConvertedEvent();
        }

        #endregion // end Convert Documents

        #region Helpers

        /// <summary>
        /// Update used fonts each time new document has been added
        /// </summary>
        /// <param name="doc">{Document} document has been added</params>
        private void updateFontList(Document doc)
        {
            foreach (Paragraph p in doc.Paragraphs)
                fonts.Add(p.Range.Font.Name);

            foreach (Shape s in doc.Shapes)
            {
                try
                {
                    fonts.Add(s.TextFrame.TextRange.Font.Name);
                }
                catch (Exception) { } // quite tricky, some shapes does not allow to edit textframe
            }
        }

        #endregion // end Helpers
    }
}
