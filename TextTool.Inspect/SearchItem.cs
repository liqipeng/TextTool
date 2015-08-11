using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Inspect
{
    public class SearchItem
    {
        public SearchItem()
        {

        }

        public SearchItem(string exampleString, string regexString)
        {
            this.RegexString = regexString;
            this.ExampleString = exampleString;
        }

        public string ExampleString { get; set; }
        public string RegexString { get; set; }
        public string ReplaceExp { get; set; }
    }
}
