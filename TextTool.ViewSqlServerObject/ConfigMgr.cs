using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextTool.ViewSqlServerObject
{
    public class ConfigMgr
    {
        private static readonly string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConnectionStrings.txt");

        public List<ConnectString> GetAllConnStrs() 
        {
            List<ConnectString> lstConns = new List<ConnectString>();
            if (!File.Exists(xmlPath)) 
            {
                return lstConns;
            }

            XDocument xDoc = XDocument.Load(xmlPath);
            lstConns = (from node in xDoc.Root.Elements("ConnectionString")
                        select new ConnectString() 
                        { 
                            Name = node.Attribute("name").Value,
                            Value = node.Attribute("value").Value
                        }).ToList();

            return lstConns;
        }

        public void SaveAllConnStrs() 
        {
            //ToDo: 实现配置编辑
        }
    }

    public class ConnectString 
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            if (this.Name != null) 
            {
                return this.Name;
            }

            return "Empty Value";
        }
    }
}
