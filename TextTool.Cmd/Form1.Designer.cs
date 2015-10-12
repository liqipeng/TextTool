namespace TextTool.Cmd
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
            this.enhancedTextBox1 = new TextTool.Common.WindowsForm.EnhancedTextBox();
            this.SuspendLayout();
            // 
            // enhancedTextBox1
            // 
            this.enhancedTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedTextBox1.Location = new System.Drawing.Point(0, 0);
            this.enhancedTextBox1.Multiline = true;
            this.enhancedTextBox1.Name = "enhancedTextBox1";
            this.enhancedTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.enhancedTextBox1.Size = new System.Drawing.Size(718, 552);
            this.enhancedTextBox1.TabIndex = 0;
            this.enhancedTextBox1.TextChanged += new System.EventHandler(this.enhancedTextBox1_TextChanged);
            this.enhancedTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enhancedTextBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 552);
            this.Controls.Add(this.enhancedTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.WindowsForm.EnhancedTextBox enhancedTextBox1;
    }
}

