using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextTool.Common;

namespace TextTool.Replacement
{
    class ReplaceTaskItem:ITask
    {
        public String FilePath { get; set; }

        /// <summary>
        /// key is regex exp, and value is replacer
        /// </summary>
        public Dictionary<string, string> RegexAndReplacer { get; set; }

        public void Execute()
        {
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                throw new InvalidOperationException("文件路径尚未初始化。");
            }

            if (RegexAndReplacer == null)
            {
                throw new InvalidOperationException("正则表达式尚未初始化。");
            }

            Encoding encoding = TextFileEncodingDetector.DetectTextFileEncoding(this.FilePath);
            String content = File.ReadAllText(this.FilePath, encoding);

            foreach (var strRegex in RegexAndReplacer.Keys)
            {
                Regex regex = new Regex(strRegex);
                content = regex.Replace(content, RegexAndReplacer[strRegex]);
            }

            File.WriteAllText(FilePath, content, encoding);
        }
    }
}
