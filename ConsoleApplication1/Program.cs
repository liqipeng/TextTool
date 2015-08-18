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
            string folderPath = @"d:\Users\liqp\Desktop\新建文件夹";
            string filePattern = @"*.txt";

            foreach (string file in Directory.GetFiles(folderPath))
            {
                Console.WriteLine();
                Console.WriteLine(new FileInfo(file).Name);
                Console.WriteLine(EncodingUtil.GetFileEncoding(file));
            }

            Dictionary<string, string> dictRegex = new Dictionary<string, string>() 
            {
                { "aaaa", "bbb" }
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

            Console.Read();
        }
    }
}
