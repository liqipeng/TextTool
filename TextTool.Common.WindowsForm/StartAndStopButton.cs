using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TextTool.Common.WindowsForm
{
    public partial class StartAndStopButton : UserControl
    {
        private const string defalult_normal_text = "开始处理";
        private const string defalult_busy_text = "正在处理......";

        private CancellationTokenSource cancelTokenSource;
        private string normalText = defalult_normal_text;
        private string busyText = defalult_busy_text;

        public StartAndStopButton()
        {
            InitializeComponent();

            this.btnStart.Text = this.NormalText;
        }

        [Description("正常状态的文本")]
        public string NormalText
        {
            get
            {
                return normalText;
            }
            set
            {
                normalText = value;
            }
        }

        [Description("忙碌状态的文本")]
        public string BusyText
        {
            get
            {
                return this.busyText;
            }
            set
            {
                this.busyText = value;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (OnStartButtonClick != null)
            {
                SetButtonsStateWhenStart();
                cancelTokenSource = new CancellationTokenSource();
                Task.Factory.StartNew(() =>
                {
                    Thread workThread = new Thread(() =>
                    {
                        OnStartButtonClick();
                    })
                    {
                        IsBackground = true
                    };
                    workThread.Start();

                    while (workThread.IsAlive)
                    {
                        try
                        {
                            if (cancelTokenSource.IsCancellationRequested)
                            {
                                workThread.Abort();
                            }
                        }
                        catch (ThreadAbortException)
                        {
                            break;
                        }
                    }

                    SetButtonsStateWhenStop();
                }, cancelTokenSource.Token);
            }
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            SetButtonsStateWhenStop();
            if (!cancelTokenSource.IsCancellationRequested)
            {
                cancelTokenSource.Cancel();
            }

            if (OnCancelButtonClick != null)
            {
                OnCancelButtonClick();
            }
        }

        private void SetButtonsStateWhenStart()
        {
            Action setState = () =>
            {
                this.btnStart.Enabled = false;
                this.btnStart.Text = this.BusyText ?? defalult_busy_text;
                this.btnStop.Enabled = true;
            };

            this.InvokeAction(setState);
        }

        private void SetButtonsStateWhenStop()
        {
            Action setState = () =>
            {
                this.btnStart.Enabled = true;
                this.btnStart.Text = this.NormalText ?? defalult_normal_text;
                this.btnStop.Enabled = false;
            };

            this.InvokeAction(setState);
        }

        /// <summary>
        /// 点击开始按钮事件，使用后台后台线程处理
        /// </summary>
        public event Action OnStartButtonClick;

        /// <summary>
        /// 点击取消按钮事件，使用后台后台线程处理
        /// </summary>
        public event Action OnCancelButtonClick;
    }
}
