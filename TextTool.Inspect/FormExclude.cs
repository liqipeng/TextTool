using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextTool.Common;

namespace TextTool.Inspect
{
    public partial class FormExclude : Form
    {
        public FormExclude()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            if (oDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(oDialog.FileName))
            {
                Task task = new Task(() =>
                {
                    string file = oDialog.FileName;
                    Encoding encoding = TextFileEncodingDetector.DetectTextFileEncoding(file);
                    string[] lines = File.ReadAllLines(file, encoding);
                    List<string> lstResult = new List<string>();

                    foreach (string line in lines)
                    {
                        string[] arrLine = line.Split(new string[] { "):        " }, StringSplitOptions.RemoveEmptyEntries);
                        if (arrLine.Length < 2)
                        {
                            continue;
                        }

                        //不处理部分文件类型
                        string fileName = arrLine[0].Substring(0, arrLine[0].LastIndexOf("("));
                        string fileExtension = new FileInfo(fileName).Extension.ToLower();
                        if (new List<string>() { ".js", ".css", ".xsd", ".xml" }.Contains(fileExtension))
                        {
                            continue;
                        }

                        //忽略的关键字
                        string trimedLine = arrLine[1].Trim().ToLower();
                        trimedLine = trimedLine
                            .Replace("something", "")
                            ;

                        //排除注释
                        trimedLine = Regex.Replace(trimedLine, @"^([^/]+)//[^/]+$", "");

                        if (trimedLine.StartsWith("//")
                            || trimedLine.StartsWith("border-")
                            || trimedLine.EndsWith("aaa".ToLower())
                            || trimedLine.EndsWith("bbb".ToLower())
                            || trimedLine.EndsWith("ccc".ToLower())
                            || trimedLine.Contains("ddd".ToLower())
                            || !trimedLine.Contains("eee")
                            || !trimedLine.Contains("fff"))
                        {
                            continue;
                        }

                        if (trimedLine.Contains("aa")
                            && trimedLine.Contains("bb"))
                        {
                            lstResult.Add(line);
                        }
                    }

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            SaveTextForm form = new SaveTextForm(lstResult.ToArray());
                            form.ShowDialog();
                            this.progressBar1.Visible = false;
                        }));
                    }
                    else
                    {
                        SaveTextForm form = new SaveTextForm(lstResult.ToArray());
                        form.ShowDialog();
                        this.progressBar1.Visible = false;
                    }
                });

                task.Start();
                this.progressBar1.Visible = true;
            }
        }
    }
}
