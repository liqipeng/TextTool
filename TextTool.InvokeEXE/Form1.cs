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
using TextTool.Common;
using TextTool.Common.WindowsForm;

namespace TextTool.InvokeEXE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessManager.KillAllRegisteredProcesses();
        }

        private void startAndStopButton1_OnStartButtonClick()
        {
            string filename = "ping";
            string arguments = "127.0.0.1";
            bool recordLog = true;

            Process proc = new Process();
            proc.StartInfo.FileName = filename;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.Arguments = arguments;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Exited += new EventHandler((obj, args) => {
                ProcessManager.Unregister(proc.Id);
            });          

            if (proc.Start())
            {
                ProcessManager.Register(proc.Id);

                using (System.IO.StreamReader sr = new System.IO.StreamReader(proc.StandardOutput.BaseStream, Encoding.Default))
                {
                    string txt = sr.ReadToEnd();
                    sr.Close();
                    if (recordLog)
                    {
                        txtLog.AppendTextByInvoke(txt);
                    }
                    if (!proc.HasExited)
                    {
                        proc.Kill();
                    }
                }
            }
            else 
            {
                MessageBox.Show("启动失败。");
            }
        }

        private void startAndStopButton1_OnCancelButtonClick()
        {
            txtLog.AppendTextByInvoke("结束了。。。", true);
            txtLog.AppendTextByInvoke("---------------------------------------" + DateTime.Now.ToString("yyMMdd hh:ss:mm"), true);
        }
    }
}
