using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common.Example.BackgroundProcess
{
    class RegexReplaceTextFileItemTasksFactory : ITasksFactory<RegexReplaceTextFileItem>
    {
        private string folderPath;
        private string filePattern;

        public RegexReplaceTextFileItemTasksFactory(string folderPath, string filePattern)
        {
            this.folderPath = folderPath;
            this.filePattern = filePattern;
        }

        public List<RegexReplaceTextFileItem> GetTasks()
        {
            Dictionary<string, string> dictRegex = new Dictionary<string, string>() 
            {
                { "aaaafadfa", "bsfafbb" }
            };
            var allFiles = Directory.GetFiles(folderPath, filePattern, SearchOption.AllDirectories).ToList();
            List<RegexReplaceTextFileItem> lstRegexItems = new List<RegexReplaceTextFileItem>();
            foreach (var strRegex in dictRegex.Keys)
            {
                allFiles.ForEach(file =>
                {
                    lstRegexItems.Add(new RegexReplaceTextFileItem(file, strRegex, dictRegex[strRegex]));
                });
            }

            return lstRegexItems;
        }
    }
}
