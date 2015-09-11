using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public static class EncodingExtension
    {
        public static void Print(this Encoding encoding)
        {
            if (encoding == null)
            {
                Console.WriteLine("NULL");
            }

            //Console.Write("EncodingName: {0}, BodyName: {1}, WebName:{2}", encoding.EncodingName, encoding.BodyName, encoding.WebName);
            Console.Write("{0}", encoding.WebName);

            UTF8Encoding utf8 = encoding as UTF8Encoding;
            if (utf8 != null)
            {
                var arr = utf8.GetPreamble();
                if (arr != null)
                {
                    Console.Write(", WithBOM: {0}", string.Join("", arr.Select(i => i.ToString("X"))));
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
