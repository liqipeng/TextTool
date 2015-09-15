using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public interface ITasksFactory<T> where T:ITask
    {
        List<T> GetTasks();
    }
}
