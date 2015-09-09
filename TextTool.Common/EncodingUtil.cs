using href.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public static class EncodingUtil
    {
        public static Encoding GetFileEncoding(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open,

FileAccess.Read);
            System.Text.Encoding r = GetFileEncoding(fs);
            fs.Close();
            return r;
        }

        public static Encoding GetFileEncoding(FileStream fileStream)
        {
            if (fileStream.Length <= 0)
            {
                return Encoding.Default;
            }

            //探测前256个字节
            int detectLength = 256;
            byte[] rawData = new byte[detectLength];
            fileStream.Read(rawData, 0, detectLength);

            if (rawData[0] == 0xEF && rawData[1] == 0xBB && rawData[2] == 0xBF)
            {
                return new UTF8Encoding(true);
            }

            Encoding encoding = EncodingTools.DetectInputCodepage(rawData);

            //区分utf8是否有BOM标记
            if (encoding == Encoding.UTF8 && rawData[0] == 0xEF && rawData[1] == 0xBB && rawData[2] == 0xBF)
            {
                encoding = new UTF8Encoding(true);
            }
            else if (encoding == Encoding.UTF8)
            {
                encoding = new UTF8Encoding(false);
            }

            return encoding;
        }
    }

    public static class EncodingExtension 
    {
        public static void Print(this Encoding encoding) 
        {
            if (encoding == null) 
            {
                Console.WriteLine("NULL");
            }

            Console.Write("EncodingName: {0}, BodyName: {1}, WebName:{2}", encoding.EncodingName, encoding.BodyName, encoding.WebName);

            UTF8Encoding utf8 = encoding as UTF8Encoding;
            if (utf8 != null) 
            {
                var arr = utf8.GetPreamble();
                if (arr != null)
                {
                    Console.Write(", WithBOM: {0}", new string(arr.Select(i => (char)i).ToArray()));
                }
                else 
                {
                    Console.Write(", WithBOM: {0}", "NONE");
                }
            }
            
            Console.WriteLine();
        }
    }
}
