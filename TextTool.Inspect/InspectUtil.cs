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
    public class InspectUtil : BackgroundProcessV2<InspectItem>
    {
        private Dictionary<string, string> _dictRegexes;
        private string _folderPath;
        private string _filePattern;

        public InspectUtil(string folderPath, string filePattern, Dictionary<string, string> dictRegex)
        {
            this._dictRegexes = dictRegex;
            this._folderPath = folderPath;
            this._filePattern = filePattern;
        }

        protected override List<InspectItem> GetTasks()
        {
            var allFiles = Directory.GetFiles(_folderPath, _filePattern, SearchOption.AllDirectories)
                //.Where(f => !f.Contains(@"bin\Debug") && !f.Contains(@"obj\Debug"))
    .ToList();
            this.AppendLog(string.Format("文件夹扫描完毕。文件数：{0}。{1}", allFiles.Count, Environment.NewLine));

            List<InspectItem> lstInspectItems = new List<InspectItem>();
            allFiles.ToList().ForEach((f)=>{
                lstInspectItems.Add(new InspectItem(base.AppendLog) 
                {
                    FilePath = f,
                    Regexes = this._dictRegexes
                });
            });

            return lstInspectItems;
        }
    }
}
