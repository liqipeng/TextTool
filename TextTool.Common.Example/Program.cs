using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTool.Common.Example.BackgroundProcess;

namespace TextTool.Common.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            RunBackgroundProcessExample();

            Console.ReadKey();
        }

        static void RunBackgroundProcessExample()
        {
            string folderPath = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "EncodingTestFiles");
            string filePattern = @"*.txt";

            DetectiveFileEncodingUtil u = new DetectiveFileEncodingUtil();
            u.TasksFactory = new RegexReplaceTextFileItemTasksFactory(folderPath, filePattern);
            u.Starting += () => { Console.WriteLine("Starting"); };
            u.OnProgressChanged += (progress, sn, taskItem) =>
            {
                Console.WriteLine("第{0}个", sn);
                Console.WriteLine("进度：{0}", progress);
                Console.WriteLine("文件名：{0}", taskItem.FileInfo.Name);
                Console.WriteLine("文件信息：");
                taskItem.Encoding.Print();
                Console.WriteLine();
            };
            u.Completed += () => { Console.Write("Completed"); };
            u.Start();
        }
    }
}
