using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common.Example.BackgroundProcess
{
    public class DetectiveFileEncodingUtil : BackgroundProcess<RegexReplaceTextFileItem>
    {
        protected override void TaskItemExecuted(RegexReplaceTextFileItem taskItem)
        {
            //Thread.Sleep(1000);
        }
    }
}
