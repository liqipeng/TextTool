using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public abstract class BackgroundProcessV2<T> where T : ITask
    {
        private CancellationTokenSource cancelTokenSource;

        public void Start()
        {
            List<T> taskItems = GetTasks();

            cancelTokenSource = new CancellationTokenSource();
            int totalTaskItemsCount = taskItems.Count;

            if (Starting != null) 
            {
                Starting();
            }

            Task.Factory.StartNew(() =>
            {
                for (int i = 1; !cancelTokenSource.IsCancellationRequested && i <= totalTaskItemsCount; i++)
                {
                    T taskItem = taskItems[i - 1];
                    DoTaskItem(taskItem);

                    TaskItemExecuted(taskItem);

                    float progress = i / (totalTaskItemsCount + 0.0f);
                    NotifyProgress(progress, i, taskItem);
                }

                Complete();
            }, cancelTokenSource.Token);
        }

        protected virtual void TaskItemExecuted(T taskItem) 
        {
            
        }

        protected abstract List<T> GetTasks();

        public void Stop()
        {
            if (this.cancelTokenSource != null) 
            {
                this.cancelTokenSource.Cancel();
            }
        }

        protected void DoTaskItem(T taksItem) 
        {
            try
            {
                taksItem.Execute();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        protected void AppendLog(string log)
        {
            if (OutputingLog != null)
            {
                OutputingLog(log);
            }
        }

        protected void NotifyProgress(float progressPercent, int taskItemSequenceNumber, T taskItem)
        {
            if (OnProgressChanged != null)
            {
                OnProgressChanged(progressPercent, taskItemSequenceNumber, taskItem);
            }
        }

        protected void Complete()
        {
            if (Completed != null)
            {
                Completed();
            }
        }

        protected void Error(Exception exception) 
        {
            if (OnError != null) 
            {
                OnError(exception);
            }
        }

        public event Action<float, int, T> OnProgressChanged;
        public event Action<string> OutputingLog;
        public event Action Starting;
        public event Action Completed;
        public event Action<Exception> OnError;
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
