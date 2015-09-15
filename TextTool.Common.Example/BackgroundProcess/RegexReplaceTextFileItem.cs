using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextTool.Common.Example.BackgroundProcess
{
    public class RegexReplaceTextFileItem : ITask
    {
        private string filePath;
        private string regexString = string.Empty;
        private string replacer = string.Empty;
        private Encoding encoding;

        public RegexReplaceTextFileItem(string filePath, string regexString, string replacer)
        {
            this.filePath = filePath;
            this.regexString = regexString;
            this.replacer = replacer;
        }

        public void Execute()
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                throw new InvalidOperationException("filePath is empty or not exists.");
            }

            encoding = TextFileEncodingDetector.DetectTextFileEncoding(filePath, Encoding.Default);
            string content = File.ReadAllText(filePath, encoding);
            string replacedContent = new Regex(this.regexString).Replace(content, this.replacer);
            File.WriteAllText(filePath, replacedContent, encoding);
        }

        public FileInfo FileInfo
        {
            get
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new InvalidOperationException("FileInfo is not initialized.");
                }

                return new FileInfo(filePath);
            }
        }

        public Encoding Encoding
        {
            get
            {
                if (encoding == null)
                {
                    throw new InvalidOperationException("You can get Encoding after Execute().");
                }

                return encoding;
            }
        }
    }
}
