using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public abstract class BackgroundProcess<T> where T : TaskItem
    {
        protected bool IsStopped { get; set; }

        public List<T> TaskItems { get; set; }

        public BackgroundProcess()
        {
            this.IsStopped = true;
        }

        public void Start()
        {
            if (TaskItems == null)
            {
                throw new InvalidOperationException("TaskItems has not initialized.");
            }

            this.IsStopped = false;
            Do();
        }

        public void Stop()
        {
            this.IsStopped = true;
        }

        protected virtual void Do() 
        {
        }

        protected void AppendLog(string log)
        {
            if (LogOutputing != null)
            {
                LogOutputing(log);
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
            if (OnProgressChanged != null)
            {
                Completed();
            }
        }

        public event Action<float> OnProgressChanged;
        public event Action<string> LogOutputing;
        public event Action Completed;
    }
}
