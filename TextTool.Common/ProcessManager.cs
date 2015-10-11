using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public static class ProcessManager
    {
        private static readonly HashSet<int> processIds = new HashSet<int>();
        private static readonly object syncObj = new object();

        public static void Register(int processId) 
        {
            lock (syncObj) 
            {
                processIds.Add(processId);
            }
        }

        public static void Unregister(int processId)
        {
            lock (syncObj)
            {
                processIds.Remove(processId);
            }
        }

        public static void KillAllRegisteredProcesses() 
        {
            foreach (int processId in processIds) 
            {
                try
                {
                    Process.GetProcessById(processId).Kill();
                }
                catch
                {
                }
            }
        }
    }
}
