using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTool.Common.WindowsForm
{
    public static class WindowsFormCtrlExtension
    {
        public static void SetNomalInitialProperties(this Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void SetTextByInvoke(this Control control, String text)
        {
            control.InvokeAction(() =>
            {
                control.Text = text;
            });
        }

        public static void AppendTextByInvoke(this Control control, String text, bool newLine = false)
        {
            control.InvokeAction(() =>
            {
                control.Text += text + (newLine ? Environment.NewLine : String.Empty);
            });
        }

        public static void InvokeAction(this Control control, Action action)
        {
            if (action != null)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(action);
                }
                else
                {
                    action();
                }
            }
        }
    }
}
