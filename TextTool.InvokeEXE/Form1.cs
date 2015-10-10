using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextTool.Common.WindowsForm;

namespace TextTool.InvokeEXE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startAndStopButton1_OnStartButtonClick(object sender, EventArgs e)
        {
            string filename = "ping";
            string arguments = "127.0.0.1";
            bool recordLog = true;

            Task.Factory.StartNew(() => {
                Process proc = new Process();
                proc.StartInfo.FileName = filename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                using (System.IO.StreamReader sr = new System.IO.StreamReader(proc.StandardOutput.BaseStream, Encoding.Default))
                {
                    string txt = sr.ReadToEnd();
                    sr.Close();
                    if (recordLog)
                    {
                        txtLog.SetTextSafe(txt);
                    }
                    if (!proc.HasExited)
                    {
                        proc.Kill();
                    }
                    return txt;
                }
            });
        }

        private void startAndStopButton1_OnCancelButtonClick(object sender, EventArgs e)
        {

        }
    }
}
