using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TextTool.Common;

namespace TextTool.Replacement
{
    //class ReplaceHelper
    //{
    //    private Dictionary<string, string> _dictRegexes;
    //    private string _folderPath;
    //    private string _filePattern;

    //    public ReplaceHelper(string folderPath, string filePattern, Dictionary<string, string> dictRegex)
    //    {
    //        this._dictRegexes = dictRegex;
    //        this._folderPath = folderPath;
    //        this._filePattern = filePattern;
    //    }

    //    public void Run() 
    //    {


    //        Thread thread = new Thread(RunProcess);
    //        thread.Start();
    //    }

    //    private void RunProcess() 
    //    {
    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        int sumAll = 0;

    //        var allFiles = Directory.GetFiles(_folderPath, _filePattern, SearchOption.AllDirectories).ToList();
    //        List<string> matchedFiles;
    //        foreach (var strRegex in _dictRegexes.Keys)
    //        {
    //            Regex regex = new Regex(strRegex);
    //            matchedFiles = allFiles.Where(file => regex.IsMatch(File.ReadAllText(file, TextFileEncodingDetector.DetectTextFileEncoding(file)))).ToList();


    //            if (matchedFiles.Count > 0) 
    //            {
    //                WriteLineToLog(string.Format("开始处理表达式：\n{0}=>{1}。", strRegex, _dictRegexes[strRegex]));
    //                int sum = 0;

    //                matchedFiles.ForEach(file =>
    //                {
    //                    Encoding encoding = TextFileEncodingDetector.DetectTextFileEncoding(file);
    //                    string content = File.ReadAllText(file, encoding);
    //                    sum += regex.Matches(content).Count;
    //                    string replacedContent = regex.Replace(content, _dictRegexes[strRegex]);
    //                    File.WriteAllText(file, replacedContent, encoding);
    //                    WriteToLog(">");
    //                    //Console.WriteLine(file);
    //                });
    //                if (sum > 0)
    //                {
    //                    WriteLineToLog();
    //                }

    //                sumAll += sum;
    //                WriteLineToLog(string.Format("共处理{0}个文件，匹配共计{1}个。", matchedFiles.Count(), sum));
    //                WriteLineToLog();
    //            }


    //        }

    //        sw.Stop();
    //        WriteLineToLog();
    //        WriteLineToLog("____________________________________________");
    //        WriteLineToLog(string.Format("共花费时间{0}秒，匹配总个数{1}。", sw.Elapsed.TotalSeconds, sumAll));
    //    }

    //    private void WriteToLog(string log)
    //    {
    //        if (Log != null)
    //        {
    //            Log(log);
    //        }
    //    }

    //    private void WriteLineToLog(string log = null) 
    //    {
    //        if (Log != null)
    //        {
    //            Log(log + Environment.NewLine);
    //        }
    //        else 
    //        {
    //            Log(Environment.NewLine);
    //        }
    //    }

    //    public event Action<string> Log;
    //}

    //class ReplaceHelper : BackgroundProcess<ReplaceTaskItem>
    //{
    //    public ReplaceHelper(string folderPath, string filePattern, Dictionary<string, string> dictRegex)
    //    {

    //    }
    //}
}
