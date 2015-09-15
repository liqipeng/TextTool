using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTool.Inspect
{
    public partial class Form1 : Form
    {
        private InspectUtil util;

        public Form1()
        {
            InitializeComponent();

            string folderPath = ConfigurationManager.AppSettings["codeFolder"];
            string filePattern = ConfigurationManager.AppSettings["fileSearchPattern"];

            this.txtFolder.Text = folderPath;
            this.txtFilePattern.Text = filePattern;

#if DEBUG
            this.txtFolder.Text = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "EncodingTestFiles");
            this.txtFilePattern.Text = "*.txt";
#endif
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            string initialFolder = ConfigurationManager.AppSettings["InitialFolder"];
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath)) 
            {
                txtFolder.Text = dialog.SelectedPath;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.txtLog.Clear();

            string folder = txtFolder.Text;
            if (string.IsNullOrWhiteSpace(folder))
            {
                MessageBox.Show("请先选择文件夹。");
                return;
            }
            if (!Directory.Exists(folder)) 
            {
                MessageBox.Show("路径不存在。");
                return;
            }

            var regexInfo = GetRegexInfo(this.txtRegexes.Text);
            util = new InspectUtil(folder, this.txtFilePattern.Text.Trim(), regexInfo);

            //util = new InspectUtil(folder, this.txtFilePattern.Text.Trim(), new Dictionary<string, string>() 
            //{
            //    { @"(\()[Ss]tring(\s+?str\))", "String aaa" }
            //});
            util.OutputingLog += AppendLog;
            util.OnProgressChanged += (progress, sn, item)=>{
                AppendLog(".");
            };
            util.Completed += () => {
                if (this.btnCheck.InvokeRequired)
                {
                    this.btnCheck.Invoke(new Action(() => { 
                        this.btnCheck.Enabled = true;
                        this.btnCheck.Text = "开始检查";
                        this.btnCancel.Enabled = false;
                    }));
                }
                else 
                {
                    this.btnCheck.Enabled = true;
                    this.btnCheck.Text = "开始检查";
                    this.btnCancel.Enabled = false;
                }
            };

            this.btnCheck.Enabled = false;
            this.btnCancel.Enabled = true;
            this.btnCheck.Text += "[正在处理...]";

            util.Start();
        }

        private Dictionary<string, string> GetRegexInfo(string inputRegexInfoData) 
        {
            inputRegexInfoData = inputRegexInfoData ?? string.Empty;
            string[] lines = inputRegexInfoData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> linesCode = new List<string>();
            List<string> linesRegex = new List<string>();
            List<string> linesRep = new List<string>();

            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                if (line == null || line.Trim() == string.Empty)
                {
                    continue;
                }

                string[] arr = line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    //linesCode.Add(arr[0]);
                    //linesRegex.Add(arr[1]);
                    //linesRep.Add(arr[2]);
                    result.Add(arr[1], arr[0]);
                }
                catch(Exception ex)
                {
                    AppendLog(ex.Message);
                }
            }

            return result;
        }

        private List<SearchItem> ParseToSearchItems(string strTable) 
        {
            List<SearchItem> lstSearchItems = new List<SearchItem>();
            
            return lstSearchItems;
        }

        private void AppendLog(string log) 
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    txtLog.AppendText(log);
                }));
            }
            else
            {
                txtLog.AppendText(log);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegexTesterForm tester = new RegexTesterForm();
            tester.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            util.Stop();
        }

        private void btnExclude_Click(object sender, EventArgs e)
        {
            FormExclude formExclude = new FormExclude();
            formExclude.ShowDialog();
        }

        private void txtRegexes_KeyDown(object sender, KeyEventArgs e)
        {
            FormExtension.SelectAllTextWhenCtrl_A(sender, e);
        }

        private void txtLog_KeyDown(object sender, KeyEventArgs e)
        {
            FormExtension.SelectAllTextWhenCtrl_A(sender, e);
        }
    }
}
