namespace TextTool.ViewSqlServerObject
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
            this.txtContent = new ICSharpCode.TextEditor.TextEditorControl();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.txtSPName = new TextTool.Common.WindowsForm.EnhancedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startAndStopButton1 = new TextTool.Common.WindowsForm.StartAndStopButton();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.IsReadOnly = false;
            this.txtContent.Location = new System.Drawing.Point(10, 92);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(754, 428);
            this.txtContent.TabIndex = 0;
            // 
            // cmbDB
            // 
            this.cmbDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(65, 12);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(691, 20);
            this.cmbDB.TabIndex = 1;
            // 
            // txtSPName
            // 
            this.txtSPName.Location = new System.Drawing.Point(65, 37);
            this.txtSPName.Name = "txtSPName";
            this.txtSPName.Size = new System.Drawing.Size(691, 21);
            this.txtSPName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Object:";
            // 
            // startAndStopButton1
            // 
            this.startAndStopButton1.BusyText = "正在查找...";
            this.startAndStopButton1.Location = new System.Drawing.Point(612, 63);
            this.startAndStopButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startAndStopButton1.Name = "startAndStopButton1";
            this.startAndStopButton1.NormalText = "开始查找";
            this.startAndStopButton1.Size = new System.Drawing.Size(152, 24);
            this.startAndStopButton1.TabIndex = 4;
            this.startAndStopButton1.OnStartButtonClick += new System.Action(this.startAndStopButton1_OnStartButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 525);
            this.Controls.Add(this.startAndStopButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSPName);
            this.Controls.Add(this.cmbDB);
            this.Controls.Add(this.txtContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl txtContent;
        private System.Windows.Forms.ComboBox cmbDB;
        private Common.WindowsForm.EnhancedTextBox txtSPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Common.WindowsForm.StartAndStopButton startAndStopButton1;
    }
}

