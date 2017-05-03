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
    public partial class MainWindow : Form
    {
        private WordHandler wordHandler;
        private DataTable dtFonts; // mapping information: Old Fonts -> New Fonts

        public MainWindow()
        {
            InitializeComponent();

            wordHandler = null;
            dtFonts = new DataTable();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                wordHandler = new WordHandler(loadDocumentsFinished, fontConvertFinished);

                foreach (FontFamily font in System.Drawing.FontFamily.Families)
                {
                    fontList.Items.Add(font.Name);
                }

                DataGridViewComboBoxColumn fontColumn = dataGridUsedFonts.Columns["colConvertTo"] as DataGridViewComboBoxColumn;
                fontColumn.DataSource = fontList.Items;
                dtFonts.Columns.Add("currentfont");
                dtFonts.Columns.Add("convertto");
                dataGridUsedFonts.AutoGenerateColumns = false;
                dataGridUsedFonts.DataSource = dtFonts;
            }
            catch (Exception ex)
            {
                if (wordHandler != null)
                    wordHandler.Quit();
                MessageBox.Show("Error while loading application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "All Word Documents (*.doc;*.docx) | *.doc;*.docx";
            DialogResult result = openFileDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    fileInput.Text = openFileDlg.FileName;
                    // load document
                    wordHandler.LoadDocument(openFileDlg.FileName, true);

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading document: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DirectoryBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDlg = new FolderBrowserDialog();
            //@todo: handle mutiple documents
        }

        #region Events

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wordHandler != null)
                wordHandler.Quit();
        }

        private void fontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow row in dtFonts.Rows)
                    row["convertto"] = fontList.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                wordHandler.ConvertFont(dtFonts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Show list of current fonts are used in loaded document
        /// </summary>
        /// <param name="usedFonts">{List<string>} list of fonts are used in loaded documents</param>
        private void loadDocumentsFinished(List<string> usedFonts)
        {
            dtFonts.Clear();
            foreach (string font in usedFonts)
            {
                DataRow newRow = dtFonts.NewRow();
                newRow["currentfont"] = font;
                newRow["convertto"] = "";
                dtFonts.Rows.Add(newRow);
            }
            for (int i = 0; i < dataGridUsedFonts.Rows.Count; i++)
                dataGridUsedFonts.Rows[i].HeaderCell.Value = (i + 1).ToString();
        }

        private void fontConvertFinished()
        {
            MessageBox.Show("Done");
        }
        #endregion // end Events
    }
}
