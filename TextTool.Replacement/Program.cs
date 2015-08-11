using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Replacement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showRegexInfo = bool.Parse(ConfigurationManager.AppSettings["showRegexInfo"]);
            string folderPath = ConfigurationManager.AppSettings["codeFolder"];
            string filePattern = ConfigurationManager.AppSettings["fileSearchPattern"];

            Dictionary<string, string> dictRegex = new Dictionary<string, string>()
            {
                {@"(a)c(b)","$1CC$2"},

            };

            if (showRegexInfo)
            {
                //显示基本信息
                OutputRegexInfo(dictRegex, folderPath, filePattern);
            }

            //处理文本替换
            ReplaceHelper replaceHelper = new ReplaceHelper(folderPath, filePattern, dictRegex);
            replaceHelper.Log += (log) => { Console.Write(log); };
            replaceHelper.Run();

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
