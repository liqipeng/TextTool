using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTool.Inspect
{
    public partial class RegexTesterForm : Form
    {
        public RegexTesterForm()
        {
            InitializeComponent();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox != null && e.Modifiers == Keys.Control && e.KeyCode == Keys.A) 
            {
                txtBox.SelectAll();
            }
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            Do((line, reg, replacer) =>
            {
                return Regex.IsMatch(line, reg).ToString();
            });
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            Do((line, reg, replacer) =>
            {
                return Regex.Replace(line, reg, replacer);
            });
        }

        private void Do(Func<string, string, string, string> func) 
        {
            var linesCode = txtCode.Lines.ToList();
            var linesRegexes = txtRegexes.Lines.ToList();
            var linesReplacer = txtReplacer.Lines.ToList();

            List<string> lstResult = new List<string>();
            Task task = new Task(() =>
            {
                int codeCount = linesCode.Count;
                int regexesCount = linesRegexes.Count;
                int replacCount = linesReplacer.Count;

                for (int i = 0; i < regexesCount; i++)
                {
                    var line = string.Empty;
                    var reg = linesRegexes[i];
                    var replac = string.Empty;

                    if (i <= codeCount - 1)
                    {
                        line = linesCode[i];
                    }

                    if (i <= replacCount - 1)
                    {
                        replac = linesReplacer[i];
                    }

                    lstResult.Add(func(line, reg, replac)); //Regex.IsMatch(line, reg)
                }

                if (txtCode.InvokeRequired)
                {
                    txtCode.Invoke(new Action(() =>
                    {
                        txtResult.Lines = lstResult.ToArray();
                    }));
                }
                else
                {
                    txtResult.Lines = lstResult.ToArray();
                }
            });
            task.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var linesCode = txtCode.Lines.ToList();
            var linesRegexes = txtRegexes.Lines.ToList();
            var linesReplacer = txtReplacer.Lines.ToList();

            var countArr = new int[]{ linesCode.Count, linesRegexes.Count, linesReplacer.Count };

            int maxLineCount = countArr.Max();

            StringBuilder sBuilder = new StringBuilder();
            
            for (int i = 0; i < maxLineCount; i++) 
            {
                string code = string.Empty;
                string regex = string.Empty;
                string repl = string.Empty;

                if (i < linesCode.Count && i <= countArr[0]) 
                {
                    code = linesCode[i];
                }

                if (i < linesRegexes.Count && i <= countArr[1])
                {
                    regex = linesRegexes[i];
                }

                if (i < linesReplacer.Count && i <= countArr[2])
                {
                    repl = linesReplacer[i];
                }

                sBuilder.AppendFormat("{0}\t{1}\t{2}{3}", code, regex, repl, Environment.NewLine);
            }

            SaveTextForm saveDlg = new SaveTextForm(sBuilder.ToString());
            saveDlg.ShowDialog();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string txt = Clipboard.GetText();
            //SaveTextForm saveDlg = new SaveTextForm(txt);
            //saveDlg.ShowDialog();
            ParseClipboard(txt);
        }

        private void ParseClipboard(string clipboardTxt) 
        {
            clipboardTxt = clipboardTxt ?? string.Empty;
            string[] lines = clipboardTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> linesCode = new List<string>();
            List<string> linesRegex = new List<string>();
            List<string> linesRep = new List<string>();

            foreach (string line in lines) 
            {
                string[] arr = line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    linesCode.Add(arr[0]);
                    linesRegex.Add(arr[1]);
                    linesRep.Add(arr[2]);
                }
                catch
                {
                }
            }

            txtCode.Lines = linesCode.ToArray();
            txtRegexes.Lines = linesRegex.ToArray();
            txtReplacer.Lines = linesRep.ToArray();
        }
        
    }
}
