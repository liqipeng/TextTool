using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTool.Common;

namespace TextTool.Replacement
{
    class ReplaceTaskItemFactory:ITasksFactory<ReplaceTaskItem>
    {
        private Dictionary<string, string> _dictRegexes;
        private string _folderPath;
        private string _filePattern;

        public ReplaceTaskItemFactory(string folderPath, string filePattern, Dictionary<string, string> dictRegex)
        {
            this._dictRegexes = dictRegex;
            this._folderPath = folderPath;
            this._filePattern = filePattern;
        }

        public List<ReplaceTaskItem> GetTasks()
        {
            if (string.IsNullOrWhiteSpace(_folderPath))
            {
                throw new InvalidOperationException("文件夹路径尚未初始化。");
            }

            if (_dictRegexes == null)
            {
                throw new InvalidOperationException("正则表达式尚未初始化。");
            }



            throw new NotImplementedException();
        }
    }
}
