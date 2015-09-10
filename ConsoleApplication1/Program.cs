using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTool.Common;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestReplaceText();

            Console.Read();
        }

        private static void TestReplaceText()
        {
            string folderPath = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "EncodingTestFiles");
            string filePattern = @"*.txt";

            //string folderPath = @"D:\TestFiles";
            //string filePattern = "*.cs";

            //foreach (string file in Directory.GetFiles(folderPath))
            //{
            //    Console.WriteLine();
            //    Console.WriteLine(new FileInfo(file).Name);
            //    Console.WriteLine(EncodingUtil.GetFileEncoding(file));
            //}

            Dictionary<string, string> dictRegex = new Dictionary<string, string>() 
            {
                { "aaaafadfa", "bsfafbb" }
            };
            var allFiles = Directory.GetFiles(folderPath, filePattern, SearchOption.AllDirectories).ToList();
            List<RegexItem> lstRegexItems = new List<RegexItem>();
            foreach (var strRegex in dictRegex.Keys)
            {
                allFiles.ForEach(file =>
                {
                    lstRegexItems.Add(new RegexItem(file, strRegex, dictRegex[strRegex]));
                });
            }

            Console.WriteLine("Begin");
            InspectUtil u = new InspectUtil();
            //u.OnProgressChanged += (progress) => { Console.Write("."); };
            u.Completed += () => { Console.Write("Completed"); };
            u.Start(lstRegexItems);
        }
    }
}
