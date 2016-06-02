using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Our_Awesome_Text_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mstExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mstBold_Click(object sender, EventArgs e)
        {
            rtfMain.SelectionFont = new Font(rtfMain.Font,FontStyle.Bold);
        }

        private void mstColor_Click(object sender, EventArgs e)
        {
            dlgColor.ShowDialog();
            rtfMain.SelectionColor = dlgColor.Color;
        }

        private void mstFont_Click(object sender, EventArgs e)
        {
            dlgFont.ShowDialog();
            rtfMain.SelectionFont = dlgFont.Font;
            rtfMain.SelectionColor = dlgFont.Color;
        }

        private void mstCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtfMain.SelectedRtf);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtfMain.SelectedRtf);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rtfMain.Text = rtfMain.Text
        }

        private void mstSave_Click(object sender, EventArgs e)
        {
            dlgSave.ShowDialog();
            rtfMain.SaveFile(dlgSave.FileName);
        }
    }
}
