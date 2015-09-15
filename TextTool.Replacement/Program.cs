using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTool.Common;

namespace TextTool.Replacement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showRegexInfo = bool.Parse(ConfigurationManager.AppSettings["showRegexInfo"]);
            //string folderPath = ConfigurationManager.AppSettings["codeFolder"];
            //string filePattern = ConfigurationManager.AppSettings["fileSearchPattern"];

            string folderPath = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "EncodingTestFiles");
            string filePattern = @"*.txt";

            //Directory.GetFiles(folderPath, "*.cs*").ToList().ForEach((f) => {
            //    var fi = new FileInfo(f); 
            //    fi.MoveTo(fi.FullName+".txt");
            //});

            Dictionary<string, string> dictRegex = new Dictionary<string, string>()
            {
                {@"(\()[Ss]tring(\s+?str\))","$1Int32$2"},

            };

            if (showRegexInfo)
            {
                //显示基本信息
                OutputRegexInfo(dictRegex, folderPath, filePattern);
            }

            //处理文本替换
            BackgroundProcess<ReplaceTaskItem> util = new BackgroundProcess<ReplaceTaskItem>();
            util.TasksFactory = new ReplaceTaskItemFactory(folderPath, filePattern, dictRegex);
            util.OnProgressChanged += (progress, sn, taskItem) =>
            {
                Console.WriteLine("第{0}个", sn);
                Console.WriteLine("进度：{0:F2}%", progress * 100);
                Console.WriteLine("文件名：{0}", new FileInfo(taskItem.FilePath).Name);
                Console.WriteLine();
            };
            util.Start();

            Console.ReadKey();
        }

        /// <summary>
        /// 输出文本文件（保存到当前程序所在位置）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="content">内容</param>
        static void OutputFile(string fileName, string content)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            File.WriteAllText(filePath, content);
        }

        static void OutputRegexInfo(Dictionary<string, string> dictRegex, string folderPath, string filePattern)
        {
            //正则表达式信息输出
            string regexInfo = dictRegex.ToString2();
            Console.WriteLine(regexInfo);
            OutputFile("RegexInfo.txt", regexInfo);

            Console.WriteLine("正则表达式信息输出到了本程序所在目录下的RegexInfo.txt");
            Console.WriteLine("将对{0}文件夹下的{1}文件进行替换，按回车键继续。", folderPath, filePattern);
            Console.ReadKey();
        }
    }
}
