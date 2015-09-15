namespace TextTool.Inspect
{
    partial class RegexTesterForm
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtRegexes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtReplacer = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(5, 29);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(259, 480);
            this.txtCode.TabIndex = 1;
            this.txtCode.WordWrap = false;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtRegexes
            // 
            this.txtRegexes.Location = new System.Drawing.Point(269, 29);
            this.txtRegexes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRegexes.Multiline = true;
            this.txtRegexes.Name = "txtRegexes";
            this.txtRegexes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRegexes.Size = new System.Drawing.Size(463, 480);
            this.txtRegexes.TabIndex = 2;
            this.txtRegexes.WordWrap = false;
            this.txtRegexes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "代码示例：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "正则：";
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(5, 518);
            this.btnMatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(100, 29);
            this.btnMatch.TabIndex = 4;
            this.btnMatch.Text = "测试匹配";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(113, 518);
            this.btnReplace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(100, 29);
            this.btnReplace.TabIndex = 5;
            this.btnReplace.Text = "测试替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(1060, 29);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(313, 480);
            this.txtResult.TabIndex = 0;
            this.txtResult.WordWrap = false;
            this.txtResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtReplacer
            // 
            this.txtReplacer.Location = new System.Drawing.Point(741, 29);
            this.txtReplacer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReplacer.Multiline = true;
            this.txtReplacer.Name = "txtReplacer";
            this.txtReplacer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReplacer.Size = new System.Drawing.Size(309, 480);
            this.txtReplacer.TabIndex = 3;
            this.txtReplacer.WordWrap = false;
            this.txtReplacer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(221, 518);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(329, 518);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(100, 29);
            this.btnPaste.TabIndex = 7;
            this.btnPaste.Text = "粘贴";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(738, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "替换符：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1057, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "替换结果：";
            // 
            // RegexTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 552);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtReplacer);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRegexes);
            this.Controls.Add(this.txtCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RegexTesterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegexTesterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtRegexes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtReplacer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}