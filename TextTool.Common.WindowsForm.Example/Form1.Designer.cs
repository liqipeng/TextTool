namespace TextTool.Common.WindowsForm.Example
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNumber = new System.Windows.Forms.Label();
            this.startAndStopButton1 = new TextTool.Common.WindowsForm.StartAndStopButton();
            this.enhancedTextBox1 = new TextTool.Common.WindowsForm.EnhancedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(94, 55);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(15, 15);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "0";
            // 
            // startAndStopButton1
            // 
            this.startAndStopButton1.Location = new System.Drawing.Point(12, 12);
            this.startAndStopButton1.Name = "startAndStopButton1";
            this.startAndStopButton1.Size = new System.Drawing.Size(316, 30);
            this.startAndStopButton1.TabIndex = 0;
            this.startAndStopButton1.OnStartButtonClick += this.startAndStopButton1_OnStartButtonClick;
            this.startAndStopButton1.OnCancelButtonClick += this.startAndStopButton1_OnCancelButtonClick;
            // 
            // enhancedTextBox1
            // 
            this.enhancedTextBox1.Location = new System.Drawing.Point(13, 89);
            this.enhancedTextBox1.Multiline = true;
            this.enhancedTextBox1.Name = "enhancedTextBox1";
            this.enhancedTextBox1.Size = new System.Drawing.Size(292, 93);
            this.enhancedTextBox1.TabIndex = 2;
            this.enhancedTextBox1.Text = "按Ctrl+A全选\r\n按Ctrl+A全选\r\n\r\n按Ctrl+A全选\r\n按Ctrl+A全选";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "打开notepad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 332);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.enhancedTextBox1);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.startAndStopButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StartAndStopButton startAndStopButton1;
        private System.Windows.Forms.Label lblNumber;
        private EnhancedTextBox enhancedTextBox1;
        private System.Windows.Forms.Button button1;
    }
}

