using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTool.Common.WindowsForm
{
    public class EnhancedTextBox:TextBox
    {
        public EnhancedTextBox()
        {
            this.KeyDown += SelectAllTextWhenCtrl_A;
        }

        public static void SelectAllTextWhenCtrl_A(object sender, KeyEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox != null && e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                txtBox.SelectAll();
            }
        }
    }
}
