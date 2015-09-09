using href.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public abstract class BackgroundProcess<T> where T : ITask
    {
        protected bool IsStopped { get; set; }
        public BackgroundProcess()
        {
            this.IsStopped = true;
        }

        public void Start(List<T> taskItems)
        {
            if (taskItems == null)
            {
                throw new InvalidOperationException("TaskItems has not initialized.");
            }

            this.IsStopped = false;

            int totalTaskItemsCount = taskItems.Count;
            new Task(() =>
            {
                for (int i = 1; !this.IsStopped && i <= totalTaskItemsCount; i++)
                {
                    DoTaskItem(taskItems[i - 1]);

                    float progress = i / (totalTaskItemsCount + 0.0f);
                    NotifyProgress(progress);
                }

                Complete();
            }).Start();
        }

        public void Stop()
        {
            this.IsStopped = true;
        }

        protected void DoTaskItem(T taksItem) 
        {
            try
            {
                taksItem.Execute();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        protected void AppendLog(string log)
        {
            if (OutputingLog != null)
            {
                OutputingLog(log);
            }
        }

        protected void NotifyProgress(float progress)
        {
            if (OnProgressChanged != null)
            {
                OnProgressChanged(progress);
            }
        }

        protected void Complete()
        {
            if (Completed != null)
            {
                Completed();
            }
        }

        protected void Error(string msg) 
        {
            if (OnError != null) 
            {
                OnError(msg);
            }
        }

        public event Action<float> OnProgressChanged;
        public event Action<string> OutputingLog;
        public event Action Completed;
        public event Action<string> OnError;
    }

    public class InspectUtil : BackgroundProcess<RegexItem> 
    {

    }

    public class RegexItem : ITask
    {
        private string filePath;
        private string regexString = string.Empty;
        private string replacer = string.Empty;

        public RegexItem(string filePath, string regexString, string replacer)
        {
            this.filePath = filePath;
            this.regexString = regexString;
            this.replacer = replacer;
        }

        public void Execute()
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) 
            {
                throw new InvalidOperationException("filePath is invalid.");
            }

            //Encoding encoding = EncodingUtil.GetFileEncoding(filePath);
            Encoding encoding = TextFileEncodingDetector.DetectTextFileEncoding(filePath, Encoding.Default);
            encoding.Print();
            string content = File.ReadAllText(filePath, encoding);
            string replacedContent = new Regex(this.regexString).Replace(content, this.replacer);
            File.WriteAllText(filePath, replacedContent, encoding);

            Console.Write(new FileInfo(filePath).Name + ", ");
            encoding.Print();
        }
    }
}


/*
            var allFiles = Directory.GetFiles(folderPath, filePattern, SearchOption.AllDirectories).ToList();
            List<RegexItem> lstRegexItems = new List<RegexItem>();
            foreach (var strRegex in dictRegex.Keys)
            {
                allFiles.ForEach(file =>
                {
                    lstRegexItems.Add(new RegexItem(file, strRegex, dictRegex[strRegex]));
                });
            }

            Console.WriteLine("Begin");
            InspectUtil u = new InspectUtil();
            //u.OnProgressChanged += (progress) => { Console.Write("."); };
            u.Completed += () => { Console.Write("Completed"); };
            u.Start(lstRegexItems);
 */
