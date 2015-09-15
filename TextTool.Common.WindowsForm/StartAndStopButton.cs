using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTool.Common.WindowsForm
{
    public partial class StartAndStopButton : UserControl
    {
        public StartAndStopButton()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetButtonsStateWhenStart();

            if (OnStartButtonClick != null) 
            {
                OnStartButtonClick(sender, e);
            }
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            SetButtonsStateWhenStop();

            if (OnCancelButtonClick != null)
            {
                OnCancelButtonClick(sender, e);
            }
        }

        private void SetButtonsStateWhenStart()
        {
            Action setState = () =>
            {
                this.btnStart.Enabled = false;
                this.btnStart.Text = "正在处理......";
                this.btnStop.Enabled = true;
            };

            if (this.InvokeRequired)
            {
                this.Invoke(setState);
            }
            else
            {
                setState();
            }
        }

        private void SetButtonsStateWhenStop()
        {
            Action setState = () =>
            {
                this.btnStart.Enabled = true;
                this.btnStart.Text = "开始处理";
                this.btnStop.Enabled = false;
            };

            if (this.InvokeRequired)
            {
                this.Invoke(setState);
            }
            else
            {
                setState();
            }
        }

        public event EventHandler OnStartButtonClick;
        public event EventHandler OnCancelButtonClick;
    }
}
