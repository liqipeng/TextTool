using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextTool.Common.WindowsForm;

namespace TextTool.Cmd
{
    public partial class Form1 : Form
    {
        private Process myProcess;
        private StreamWriter myStreamWriter;

        public Form1()
        {
            InitializeComponent();

            myProcess = new Process();

            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.RedirectStandardError = true;
            myProcess.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            myProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            myProcess.EnableRaisingEvents = true;

            myProcess.Start();

            myStreamWriter = myProcess.StandardInput;
            myProcess.BeginOutputReadLine();
            myProcess.BeginErrorReadLine();

            //myStreamWriter.WriteLine(Environment.NewLine);
        }

        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.enhancedTextBox1.AppendTextByInvoke(e.Data + Environment.NewLine);
        }

        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.enhancedTextBox1.AppendTextByInvoke(e.Data + Environment.NewLine);
        }

        private void enhancedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String[] sourceLines = this.enhancedTextBox1.Lines;
                String inputText = sourceLines[sourceLines.Length - 1];
                if (inputText.Length > 0)
                {
                    //String[] sourceLines = this.enhancedTextBox1.Lines;
                    if (sourceLines.Length >= 1)
                    {
                        String[] targetLines = new String[sourceLines.Length - 1];
                        Array.Copy(sourceLines, targetLines, targetLines.Length);

                        this.enhancedTextBox1.InvokeAction(() => { this.enhancedTextBox1.Lines = targetLines; });
                    }

                    myStreamWriter.WriteLine(inputText);
                }
            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                myProcess.CancelOutputRead();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // End the input stream to the sort command.
            // When the stream closes, the sort command
            // writes the sorted text lines to the 
            // console.
            myStreamWriter.Close();

            //Console.WriteLine(myProcess.StandardOutput.ReadToEnd());

            // Wait for the sort process to write the sorted text lines.
            myProcess.WaitForExit();
            myProcess.Close();
        }

        private void enhancedTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.enhancedTextBox1.SelectionStart = this.enhancedTextBox1.Text.Length;
            this.Text = this.enhancedTextBox1.Lines.Length.ToString();
        }
    }
}
