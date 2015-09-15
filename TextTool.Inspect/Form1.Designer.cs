namespace TextTool.Inspect
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
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtRegexes = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFilePattern = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExclude = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(100, 12);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(876, 25);
            this.txtFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "代码位置：";
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(1131, 10);
            this.btnChooseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(153, 29);
            this.btnChooseFolder.TabIndex = 2;
            this.btnChooseFolder.Text = "选择文件夹";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(3, 405);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(423, 29);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "开始检查";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtRegexes
            // 
            this.txtRegexes.Location = new System.Drawing.Point(3, 49);
            this.txtRegexes.Margin = new System.Windows.Forms.Padding(4);
            this.txtRegexes.Multiline = true;
            this.txtRegexes.Name = "txtRegexes";
            this.txtRegexes.Size = new System.Drawing.Size(1432, 348);
            this.txtRegexes.TabIndex = 4;
            this.txtRegexes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRegexes_KeyDown);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(3, 441);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1432, 295);
            this.txtLog.TabIndex = 4;
            this.txtLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLog_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1384, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFilePattern
            // 
            this.txtFilePattern.Location = new System.Drawing.Point(987, 12);
            this.txtFilePattern.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePattern.Name = "txtFilePattern";
            this.txtFilePattern.Size = new System.Drawing.Size(135, 25);
            this.txtFilePattern.TabIndex = 6;
            this.txtFilePattern.Text = "*.cs";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(435, 405);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(251, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExclude
            // 
            this.btnExclude.Location = new System.Drawing.Point(1235, 405);
            this.btnExclude.Margin = new System.Windows.Forms.Padding(4);
            this.btnExclude.Name = "btnExclude";
            this.btnExclude.Size = new System.Drawing.Size(201, 29);
            this.btnExclude.TabIndex = 8;
            this.btnExclude.Text = "从VS的搜索结果中排除";
            this.btnExclude.UseVisualStyleBackColor = true;
            this.btnExclude.Click += new System.EventHandler(this.btnExclude_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 741);
            this.Controls.Add(this.btnExclude);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFilePattern);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtRegexes);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnChooseFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtRegexes;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFilePattern;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExclude;
    }
}

