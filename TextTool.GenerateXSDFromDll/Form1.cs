using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using TextTool.Common;
using TextTool.Common.WindowsForm;

namespace TextTool.GenerateXSDFromDll
{
    public partial class Form1 : EnhancedForm
    {
        public Form1()
        {
            InitializeComponent();

            EnhancedForm.RememberForm = this;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string dllPath = txtPath.Text.Trim();
            string result = ReadEntityInfoFromDll(dllPath, this.txtClassNames.Text.Trim());
            this.txtResult.Text = result;
        }

        private string ReadEntityInfoFromDll(string dllPath, string keywords)
        {
            StringBuilder sBuilder = new StringBuilder();

            keywords.Split(',').ToList().ForEach((keyword) =>
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dllPath);
                    Type type = assembly.GetTypes().Where(t => t.Name == keyword).Single();

                    string xmlDocPath = Regex.Replace(new FileInfo(dllPath).FullName, "\\.[Dd][Ll]{2}$", ".XML");
                    bool hasDoc = false;
                    XDocument xDoc = new XDocument();

                    if (File.Exists(xmlDocPath))
                    {
                        hasDoc = true;
                        xDoc = XDocument.Load(xmlDocPath);
                    }

                    if (type.IsEnum)
                    {
                        sBuilder.AppendFormat(@"<xs:simpleType name=""{0}""><xs:restriction base=""xs:string"">", type.Name);

                        if (hasDoc)
                        {
                            sBuilder.AppendFormat(@"<xs:annotation><xs:documentation>{0}</xs:documentation></xs:annotation>", GetComment(xDoc, CommentType.Type, type.Namespace + "." + type.Name));
                        }

                        Enum.GetNames(type).ToList().ForEach((name) =>
                        {
                            sBuilder.AppendFormat(@"<xs:enumeration value=""{0}""><xs:annotation>", name);

                            if (hasDoc)
                            {
                                sBuilder.AppendFormat(@"<xs:annotation><xs:documentation>{0}</xs:documentation></xs:annotation>", GetComment(xDoc, CommentType.Property, type.Namespace + "." + type.Name + "." + name));
                            }

                            sBuilder.AppendFormat(@"<xs:appinfo>
                                    <EnumerationValue xmlns=""http://schemas.microsoft.com/2003/10/Serialization/"">{1}</EnumerationValue>
                                  </xs:appinfo>
                                </xs:annotation>
                              </xs:enumeration>", (int)Enum.Parse(type, name));
                        });

                        sBuilder.Append(@"</xs:restriction></xs:simpleType>");
                    }
                    else
                    {
                        sBuilder.AppendLine("<xs:complexType name=\"" + type.Name + "\"><xs:sequence>");

                        if (hasDoc)
                        {
                            sBuilder.AppendFormat(@"<xs:annotation>
			                    <xs:documentation>{0}</xs:documentation>
		                    </xs:annotation>", GetComment(xDoc, CommentType.Type, type.Namespace + "." + type.Name));
                        }

                        type.GetProperties().ToList().ForEach((p) =>
                        {
                            sBuilder.AppendLine(string.Format("<xs:element name=\"{0}\" type=\"xs:{1}\">", p.Name, GetXSDTypeByCSharpType(p.PropertyType)));

                            if (hasDoc)
                            {
                                sBuilder.AppendFormat(@"<xs:annotation>
					                <xs:documentation>{0}</xs:documentation>
				                </xs:annotation>", GetComment(xDoc, CommentType.Property, type.Namespace + "." + type.Name + "." + p.Name));
                            }

                            sBuilder.AppendLine("</xs:element>");
                        });

                        sBuilder.Append("</xs:sequence></xs:complexType>");
                    }
                }
                catch (Exception ex)
                {
                    sBuilder.AppendLine(ex.Message);
                }
            });

            return sBuilder.ToString();
        }

        private string GetComment(XDocument xDoc, CommentType type, String name)
        {
            string t = "P";
            if (type == CommentType.Type)
            {
                t = "T";
            }

            var summery = string.Empty;

            try
            {
                summery = (from item in xDoc.Root.Element("members").Elements("member")
                           where item.Attribute("name").Value == t + ":" + name
                           select item.Element("summary").Value).First();
            }
            catch (Exception)
            {
            }

            return summery;
        }

        private string GetXSDTypeByCSharpType(Type type)
        {
            Dictionary<Type, string> dict = new Dictionary<Type, string>() 
            {
                { typeof(byte), "byte" },
                { typeof(decimal), "decimal" },
                { typeof(int), "int" },
                { typeof(long), "long" },
                { typeof(short), "short" },
                { typeof(string), "string" },
                { typeof(DateTime), "dateTime" },
                { typeof(bool), "boolean" },
            };
            if (dict.ContainsKey(type))
            {
                return dict[type];
            }
            else
            {
                return type.FullName;
            }
        }

        protected override List<Control> RememberControls
        {
            get
            {
                return new List<Control>() 
                {
                    this.txtPath,
                    this.txtClassNames
                };
            }
        }
    }

    enum CommentType
    {
        Type,
        Property
    }
}
