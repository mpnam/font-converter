using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace font_converter
{
    public class WordHandler
    {
        private Application wordApp;
        private HashSet<string> fonts; // use hashset to maintain unique list

        public WordHandler()
        {
            wordApp = new Application();
            fonts = new HashSet<string>();
        }

        /// <summary>
        /// Load document located in path
        /// </summary>
        /// <param name="path">{string} path to the document</param>
        /// <param name="reset">{bool} if true then close other documents</param>
        public void LoadDocument(string path, bool reset = false)
        {
            if (reset)
            {
                while (wordApp.Documents.Count > 0)
                    wordApp.Documents[wordApp.Documents.Count - 1].Close();
                fonts = new HashSet<string>();
            }
            Document doc = wordApp.Documents.Open(path);
            updateFontList(doc);
        }

        /// <summary>
        /// Get all used fonts of all opened documents
        /// </summary>
        /// <returns>{List<string>} list of fonts names</returns>
        public List<string> GetAllUsedFonts()
        {
            return fonts.ToList<string>();
        }

        /// <summary>
        /// Convert font of all opened documents
        /// </summary>
        /// <param name="fontMapping">{DataTable} mapping from current fonts to target fonts</param>
        public void ConvertFont(System.Data.DataTable fontMapping)
        {
            ConvertFont converter = new font_converter.ConvertFont(wordApp, fontMapping);
            converter.ShowDialog();
        }

        public void Quit()
        {
            wordApp.Quit();
        }

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
                fonts.Add(s.TextFrame.TextRange.Font.Name);
        }

        #endregion // end Helpers
    }
}
