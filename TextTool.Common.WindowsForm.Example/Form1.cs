using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTool.Common.WindowsForm.Example
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancelTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void startAndStopButton1_OnStartButtonClick(object sender, EventArgs e)
        {
            int startNumber = Convert.ToInt32(this.lblNumber.Text);

            cancelTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(() => {
                while (cancelTokenSource.IsCancellationRequested == false) 
                {
                    startNumber++;
                    this.lblNumber.SetTextSafe(startNumber.ToString());
                    Thread.Sleep(1000);
                }
            }, cancelTokenSource.Token);
        }

        private void startAndStopButton1_OnCancelButtonClick(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotepadForm n = new NotepadForm();
            n.ShowDialog();
        }
    }
}
