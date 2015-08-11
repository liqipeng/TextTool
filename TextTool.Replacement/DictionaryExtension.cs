using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Replacement
{
    static class DictionaryExtension
    {
        /// <summary>
        /// Dictionary&lt;string, string>转为字符串
        /// </summary>
        /// <param name="dictRegex"></param>
        /// <returns></returns>
        public static string ToString2(this Dictionary<string, string> dictRegex)
        {
            if (dictRegex == null)
            {
                return string.Empty;
            }

            StringBuilder sbuilder = new StringBuilder();

            foreach (string key in dictRegex.Keys)
            {
                sbuilder.AppendLine(key);
            }

            sbuilder.AppendLine();

            foreach (string key in dictRegex.Keys)
            {
                sbuilder.AppendLine(dictRegex[key]);
            }

            return sbuilder.ToString();
        }
    }
}
