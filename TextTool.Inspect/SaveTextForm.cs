using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTool.Inspect
{
    public partial class SaveTextForm : Form
    {
        public SaveTextForm()
        {
            InitializeComponent();
        }

        public SaveTextForm(string txt)
        {
            InitializeComponent();

            textBox1.Text = txt;
        }

        public SaveTextForm(string[] lines)
        {
            InitializeComponent();

            textBox1.Lines = lines;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            FormExtension.SelectAllTextWhenCtrl_A(sender, e);
        }

    }
}
