using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextTool.Common;

namespace TextTool.Inspect
{
    public class InspectItem : ITask
    {
        public String FilePath { get; set; }

        /// <summary>
        /// key is regex exp, and value is a example for this regex expression.
        /// </summary>
        public Dictionary<string, string> Regexes { get; set; }

        private Action<string> outputInfo;

        public InspectItem(Action<string> outputInfo)
        {
            this.outputInfo = outputInfo;
        }

        public void Execute()
        {
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                throw new InvalidOperationException("文件路径尚未初始化。");
            }

            if (Regexes == null)
            {
                throw new InvalidOperationException("正则表达式尚未初始化。");
            }

            var encoding = TextFileEncodingDetector.DetectTextFileEncoding(FilePath, Encoding.Default);
            string content = File.ReadAllText(FilePath, encoding);
            string contains = string.Empty;
            foreach (var key in Regexes.Keys)
            {
                if (Regex.IsMatch(content, key))
                {
                    contains += Regexes[key] + "; ";
                }
            }

            if (contains != string.Empty && outputInfo != null)
            {
                outputInfo(Environment.NewLine + FilePath + "包含：" + contains + Environment.NewLine);
            }
        }
    }
}
