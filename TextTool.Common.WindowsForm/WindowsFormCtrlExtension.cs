using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static void SetTextSafe(this Control control, String text) 
        {
            control.InvokeAction(() =>
            {
                control.Text = text;
            });
        }

        public static void TrySetValueSafe<T>(this Control control, T value)
        {
            control.InvokeAction(() =>
            {
                PropertyInfo valueProp = control.GetType().GetProperty("Value");
                if (valueProp == null) 
                {
                    throw new InvalidOperationException("未找到Value属性，无法执行赋值操作。");
                }
                if (!valueProp.CanWrite)
                {
                    throw new InvalidOperationException("Value属性是只读属性，无法执行赋值操作。");
                }

                valueProp.SetValue(control, value);
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
