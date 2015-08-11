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
            /*byte[] Unicode=new byte[]{0xFF,0xFE};  
            byte[] UnicodeBIG=new byte[]{0xFE,0xFF};  
            byte[] UTF8=new byte[]{0xEF,0xBB,0xBF};*/

            BinaryReader r = new BinaryReader(fileStream, Encoding.Default);
            byte[] ss = r.ReadBytes(4);
            r.Close();
            //编码类型 Coding=编码类型.ASCII;   
            if (ss.Length > 0 && ss[0] <= 0xEF)
            {
                if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
                {
                    return Encoding.UTF8;
                }
                else if (ss[0] == 0xFE && ss[1] == 0xFF)
                {
                    return Encoding.BigEndianUnicode;
                }
                else if (ss[0] == 0xFF && ss[1] == 0xFE)
                {
                    return Encoding.Unicode;
                }
                else
                {
                    return Encoding.Default;
                }
            }
            else
            {
                return Encoding.Default;
            }
        }
    }
}
