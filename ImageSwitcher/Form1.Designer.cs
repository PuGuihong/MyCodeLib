namespace ImageSwitcher
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.saveByteBtn = new System.Windows.Forms.Button();
            this.valTbx = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // saveByteBtn
            // 
            this.saveByteBtn.Location = new System.Drawing.Point(288, 42);
            this.saveByteBtn.Name = "saveByteBtn";
            this.saveByteBtn.Size = new System.Drawing.Size(75, 23);
            this.saveByteBtn.TabIndex = 0;
            this.saveByteBtn.Text = "生成byte";
            this.saveByteBtn.UseVisualStyleBackColor = true;
            this.saveByteBtn.Click += new System.EventHandler(this.saveByteBtn_Click);
            // 
            // valTbx
            // 
            this.valTbx.Location = new System.Drawing.Point(1, 136);
            this.valTbx.Multiline = true;
            this.valTbx.Name = "valTbx";
            this.valTbx.Size = new System.Drawing.Size(433, 174);
            this.valTbx.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 322);
            this.Controls.Add(this.valTbx);
            this.Controls.Add(this.saveByteBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveByteBtn;
        private System.Windows.Forms.TextBox valTbx;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

