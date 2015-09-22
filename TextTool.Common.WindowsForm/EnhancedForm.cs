using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TextTool.Common.WindowsForm
{
    public class EnhancedForm : Form
    {

        private static readonly String rememberControlsFilePath;
        private static EnhancedForm rememberForm;

        static EnhancedForm()
        {
            FileInfo exeFileInfo = new FileInfo(Application.ExecutablePath);
            rememberControlsFilePath = Path.Combine(FileOrDirectoryUtil.GetTempDirectory(), exeFileInfo.Name + ".tmp");
        }

        protected static EnhancedForm RememberForm
        {
            get
            {
                if (rememberForm == null)
                {
                    throw new InvalidOperationException("RememberForm has not setted.");
                }

                return rememberForm;
            }
            set
            {
                if (rememberForm != null)
                {
                    throw new InvalidOperationException("RememberForm has setted. Cannot set twice or more, and only can set one.");
                }
                else
                {
                    rememberForm = value;

                    rememberForm.Load += OnRememberFormLoad;
                    rememberForm.FormClosing += OnRememberFormClosing;
                }
            }
        }

        private static void OnRememberFormClosing(object sender, FormClosingEventArgs e)
        {
            if (RememberForm.RememberControls != null && RememberForm.RememberControls.Count > 0)
            {
                List<String> lstRememberValues = new List<string>();
                RememberForm.RememberControls.ForEach((ctrl) =>
                {
                    lstRememberValues.Add(ctrl.Text);
                });

                using (FileStream fs = new FileStream(rememberControlsFilePath, FileMode.OpenOrCreate))
                {
                    Serializer.SerializeToBinary(lstRememberValues, fs);
                }
            }
        }

        private static void OnRememberFormLoad(object sender, EventArgs e)
        {
            if (RememberForm.RememberControls != null && RememberForm.RememberControls.Count > 0 && File.Exists(rememberControlsFilePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(rememberControlsFilePath, FileMode.Open))
                    {
                        List<String> lstRememberValues = Serializer.DeserializeFromBinary<List<String>>(fs);

                        for (int i = 0; i < lstRememberValues.Count; i++)
                        {
                            RememberForm.RememberControls[i].Text = lstRememberValues[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("载入记住的数据失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 提供一些控件的值可以被记住，在下次启动时载入
        /// </summary>
        protected virtual List<Control> RememberControls
        {
            get
            {
                return new List<Control>();
            }
        }
    }
}
