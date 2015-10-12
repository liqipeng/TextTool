namespace TextTool.InvokeEXE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPath = new TextTool.Common.WindowsForm.EnhancedTextBox();
            this.startAndStopButton1 = new TextTool.Common.WindowsForm.StartAndStopButton();
            this.txtLog = new TextTool.Common.WindowsForm.EnhancedTextBox();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 26);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(609, 21);
            this.txtPath.TabIndex = 0;
            // 
            // startAndStopButton1
            // 
            this.startAndStopButton1.Location = new System.Drawing.Point(13, 54);
            this.startAndStopButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startAndStopButton1.Name = "startAndStopButton1";
            this.startAndStopButton1.Size = new System.Drawing.Size(237, 24);
            this.startAndStopButton1.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(13, 92);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(634, 559);
            this.txtLog.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 663);
            this.Controls.Add(this.startAndStopButton1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.WindowsForm.EnhancedTextBox txtPath;
        private Common.WindowsForm.StartAndStopButton startAndStopButton1;
        private Common.WindowsForm.EnhancedTextBox txtLog;
    }
}

