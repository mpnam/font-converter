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
        private List<string> usedFonts;
        private Microsoft.Office.Interop.Word.Application wordApp;
        private DataTable dtFonts;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();

                foreach (FontFamily font in System.Drawing.FontFamily.Families)
                {
                    fontList.Items.Add(font.Name);
                }

                DataGridViewComboBoxColumn fontColumn = dataGridUsedFonts.Columns["colConvertTo"] as DataGridViewComboBoxColumn;
                fontColumn.DataSource = fontList.Items;
                dtFonts = new DataTable();
                dtFonts.Columns.Add("currentfont");
                dtFonts.Columns.Add("convertto");
                dataGridUsedFonts.AutoGenerateColumns = false;
                dataGridUsedFonts.DataSource = dtFonts;
            }
            catch (Exception ex)
            {
                wordApp.Quit();
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
                InitializeDocument init = new InitializeDocument(wordApp, openFileDlg.FileName);
                init.ShowDialog();

                usedFonts = init.GetUsedFonts();
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
        }

        #region Functions


        #endregion // end Functions

        #region Events

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // try to close word application
            if (wordApp != null)
                wordApp.Quit();
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
                ConvertFont convert = new ConvertFont(wordApp, dtFonts);
                convert.ShowDialog();
                MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion // end Events
    }
}
