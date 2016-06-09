using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Teditor : Form
    {
        public Teditor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
        }

        private void italicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic);
        }
        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.SelectionColor = fontDialog1.Color;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        // New functions, check to see if document is saved then clears screen

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Make file dialog and set it's settings
            FileDialog openFile1 = new OpenFileDialog();
            openFile1.CheckFileExists = true;
            openFile1.CheckPathExists = true;
            openFile1.RestoreDirectory = true;
            openFile1.Title = "Choose file to import";

            // If the user returned OK, convert the image to Bitmap and set it to clipboard
            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                string originalFile = openFile1.FileName;
                Bitmap myBitmap = new Bitmap(originalFile);
                Clipboard.SetDataObject(myBitmap);
                DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);

                // Check if bitmaps can be pasted and then paste it
                if (this.richTextBox1.CanPaste(format))
                {
                    richTextBox1.Paste(format);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a dialog to choose where it should be saved.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Only allow .rtf files to be opened.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Check if a file was actually selected.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the the file to the specified location.
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
