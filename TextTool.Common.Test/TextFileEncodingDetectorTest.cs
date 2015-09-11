using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace TextTool.Common.Test
{
    [TestClass]
    public class TextFileEncodingDetectorTest
    {
        [TestMethod]
        public void TextFileEncodingDetector22()
        {
            string testFileDir = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "EncodingTestFiles/");
            Encoding encodingUtf8WithBOM = TextFileEncodingDetector.DetectTextFileEncoding(testFileDir + "2. UTF8 with BOM.txt");
            Encoding encodingUtf8WithoutBOM = TextFileEncodingDetector.DetectTextFileEncoding(testFileDir + "3. UTF8 without BOM.txt");
            Encoding encodingANSI = TextFileEncodingDetector.DetectTextFileEncoding(testFileDir + "UserInfo.cs.txt");

            Assert.IsTrue(encodingUtf8WithBOM is UTF8Encoding && (encodingUtf8WithBOM as UTF8Encoding).GetPreamble().Length > 0, "检测uft8 with bom");
            Assert.IsTrue(encodingUtf8WithoutBOM is UTF8Encoding && (encodingUtf8WithoutBOM as UTF8Encoding).GetPreamble().Length == 0, "检测uft8 without bom");
            Assert.IsTrue(encodingANSI == Encoding.Default, "检测ansi");
        }
    }
}
