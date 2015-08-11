using System.Windows.Forms;

namespace TextTool.Inspect
{
    public static class FormExtension
    {
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
