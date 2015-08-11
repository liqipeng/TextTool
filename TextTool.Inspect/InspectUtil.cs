using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextTool.Common;

namespace TextTool.Inspect
{
    public class InspectUtil
    {
        public string Folder { get; private set; }
        public string FilePattern { get; private set; }

        private Task task;
        private bool isStop = false;
        public InspectUtil(string folder, string filePattern = "*.cs")
        {
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
            {
                throw new ArgumentException("folder");
            }

            this.Folder = folder;
            this.FilePattern = filePattern;
        }

        public void BeginCheck(List<SearchItem> lstSearchItems) 
        {
            if (lstSearchItems == null || lstSearchItems.Count <= 0) 
            {
                return;
            }

            isStop = false;
            task = new Task(() =>
            {
                Process(lstSearchItems);

                if (CheckCompleted != null) 
                {
                    CheckCompleted();
                }
            });
            task.Start();
        }

        private void Process(List<SearchItem> lstSearchItems) 
        {
            var allFiles = Directory.GetFiles(Folder, FilePattern, SearchOption.AllDirectories)
                //.Where(f => !f.Contains(@"bin\Debug") && !f.Contains(@"obj\Debug"))
                .ToList();
            WriteLineToLog(string.Format("文件夹扫描完毕。文件数：{0}。", allFiles.Count));
            List<string> matchedFiles;
            lstSearchItems.ForEach(si =>
            {
                Regex regex = new Regex(si.RegexString);
                matchedFiles = allFiles.Where((file) =>
                {
                    if (!isStop)
                    {
                        WriteToLog(".");
                        return regex.IsMatch(File.ReadAllText(file, EncodingUtil.GetFileEncoding(file)));
                    }
                    else 
                    {
                        return false;
                    }
                }).ToList();
                WriteLineToLog();

                if (matchedFiles.Count > 0)
                {
                    WriteLineToLog(si.RegexString);
                    WriteLineToLog(si.ExampleString);
                    matchedFiles.ForEach(f =>
                    {
                        WriteLineToLog(f);
                    });
                }

                WriteLineToLog();
            });
        }

        public void Stop() 
        {
            isStop = true;
        }

        private void WriteToLog(string log)
        {
            if (Log != null)
            {
                Log(log);
            }
        }

        private void WriteLineToLog(string log = null)
        {
            if (Log != null)
            {
                Log(log + Environment.NewLine);
            }
            else
            {
                Log(Environment.NewLine);
            }
        }

        public event Action<string> Log;
        public event Action CheckCompleted;
    }
}
