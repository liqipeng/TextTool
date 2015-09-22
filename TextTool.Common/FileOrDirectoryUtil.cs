using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public class FileOrDirectoryUtil
    {
        /// <summary>
        /// 目录是否可写
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>是否可写</returns>
        public static bool DirectoryCanWrite(String path) 
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectorySecurity dirSecurity = new DirectorySecurity(path, AccessControlSections.Access);

            return !dirSecurity.AreAccessRulesProtected;
        }

        /// <summary>
        /// 获取可写的临时目录，
        /// 如果系统temp目录不可写，就使用应用程序当前所在目录
        /// </summary>
        /// <returns>临时目录路径</returns>
        public static String GetTempDirectory()
        {
            String systemTempDir = System.Environment.GetEnvironmentVariable("TEMP");
            if (Directory.Exists(systemTempDir) && DirectoryCanWrite(systemTempDir))
            {
                return systemTempDir;
            }
            else 
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
    }
}
