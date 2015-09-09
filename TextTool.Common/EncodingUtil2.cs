using href.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public static class EncodingUtil2
    {
        public static Encoding GetFileEncoding(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
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
                    //return Encoding.UTF8;
                    return new UTF8Encoding(true);
                }
                else if (IsUTF8Bytes(ss))
                {
                    return new UTF8Encoding(true);
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

        public static bool IsUTF8Bytes(byte[] data)
        {

            int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数

            byte curByte; //当前分析的字节.

            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];

                if (charByteCounter == 1)
                {

                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {

                            charByteCounter++;
                        }

                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }

                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }

            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式");
            }

            return true;
        }
    }
}
