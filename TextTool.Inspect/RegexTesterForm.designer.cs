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
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(4, 23);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(195, 385);
            this.txtCode.TabIndex = 1;
            this.txtCode.WordWrap = false;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtRegexes
            // 
            this.txtRegexes.Location = new System.Drawing.Point(202, 23);
            this.txtRegexes.Multiline = true;
            this.txtRegexes.Name = "txtRegexes";
            this.txtRegexes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRegexes.Size = new System.Drawing.Size(348, 385);
            this.txtRegexes.TabIndex = 2;
            this.txtRegexes.WordWrap = false;
            this.txtRegexes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "代码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "正则：";
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(4, 414);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(75, 23);
            this.btnMatch.TabIndex = 4;
            this.btnMatch.Text = "测试匹配";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(85, 414);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 5;
            this.btnReplace.Text = "测试替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(795, 23);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(236, 385);
            this.txtResult.TabIndex = 0;
            this.txtResult.WordWrap = false;
            this.txtResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtReplacer
            // 
            this.txtReplacer.Location = new System.Drawing.Point(556, 23);
            this.txtReplacer.Multiline = true;
            this.txtReplacer.Name = "txtReplacer";
            this.txtReplacer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReplacer.Size = new System.Drawing.Size(233, 385);
            this.txtReplacer.TabIndex = 3;
            this.txtReplacer.WordWrap = false;
            this.txtReplacer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(166, 414);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(247, 414);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(75, 23);
            this.btnPaste.TabIndex = 7;
            this.btnPaste.Text = "粘贴";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // RegexTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 442);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtReplacer);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRegexes);
            this.Controls.Add(this.txtCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}