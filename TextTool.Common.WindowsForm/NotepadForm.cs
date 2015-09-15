using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTool.Common.WindowsForm
{
    public partial class NotepadForm : Form
    {
        private string fileName;

        public NotepadForm()
        {
            InitializeComponent();

            this.enhancedTextBox1.KeyDown += enhancedTextBox1_KeyDown;
        }

        void enhancedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.O) 
            {
                Open();
            }
        }

        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Open() 
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
            {
                Encoding encoding = TextFileEncodingDetector.DetectTextFileEncoding(ofd.FileName);
                this.enhancedTextBox1.Text = File.ReadAllText(ofd.FileName, encoding);

                this.Text = ofd.FileName;
                fileName = ofd.FileName;
            }
        }

        private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save() 
        {
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
                {
                    File.WriteAllText(sfd.FileName, this.enhancedTextBox1.Text, new UTF8Encoding(true));
                    this.Text = sfd.FileName;
                    fileName = sfd.FileName;
                }
            }
            else 
            {
                File.WriteAllText(fileName, this.enhancedTextBox1.Text, new UTF8Encoding(true));
                this.Text = fileName;
            }
        }

        private void enhancedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.fileName !=null && !string.IsNullOrWhiteSpace(this.Text) && this.Text[this.Text.Length-1]!= '*') 
            {
                this.Text += "*";
            }
        }
    }
}
