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

            util = new InspectUtil(folder);
            util.Log += AppendLog;
            util.CheckCompleted += () => {
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

            List<SearchItem> lstSearchItems = new List<SearchItem>()
            {
                new SearchItem("查找类似于xxxxx", @"aabbcc(xxxxxx)")
            };
            util.BeginCheck(lstSearchItems);
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
    }
}
