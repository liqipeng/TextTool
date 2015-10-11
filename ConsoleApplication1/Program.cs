using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready to sort one or more text lines...");

            // Start the Sort.exe process with redirected input.
            // Use the sort command to sort the input text.
            Process myProcess = new Process();

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

            StreamWriter myStreamWriter = myProcess.StandardInput;
            myProcess.BeginOutputReadLine();
            myProcess.BeginErrorReadLine();

            while (true) 
            {
                // Prompt the user for input text lines to sort. 
                // Write each line to the StandardInput stream of
                // the sort command.
                String inputText;
                Console.WriteLine("Enter a line of cmd:");

                inputText = Console.ReadLine();
                if (inputText.Length > 0)
                {
                    if (inputText.Trim() == "exit") 
                    {
                        break;
                    }
                    else
                    {
                        myStreamWriter.WriteLine(inputText);
                    }
                }
            }

            // End the input stream to the sort command.
            // When the stream closes, the sort command
            // writes the sorted text lines to the 
            // console.
            myStreamWriter.Close();

            //Console.WriteLine(myProcess.StandardOutput.ReadToEnd());

            // Wait for the sort process to write the sorted text lines.
            myProcess.WaitForExit();
            myProcess.Close();

            Console.ReadKey();
        }

        private static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            //这里是正常的输出
            Console.WriteLine("ErrorDataReceived: " + e.Data);
        }

        private static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //这里得到的是错误信息
            Console.WriteLine("OutputDataReceived: " + e.Data);
        }
    }
}
