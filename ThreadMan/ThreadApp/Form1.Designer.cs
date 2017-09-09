namespace ThreadApp
{
    partial class ThreadAppForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.tbTheadCount = new System.Windows.Forms.TextBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(58, 43);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(162, 43);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(257, 43);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // rtbMsg
            // 
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbMsg.Location = new System.Drawing.Point(0, 515);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(584, 47);
            this.rtbMsg.TabIndex = 3;
            this.rtbMsg.Text = "";
            // 
            // tbTheadCount
            // 
            this.tbTheadCount.Location = new System.Drawing.Point(114, 130);
            this.tbTheadCount.Name = "tbTheadCount";
            this.tbTheadCount.Size = new System.Drawing.Size(41, 21);
            this.tbTheadCount.TabIndex = 4;
            this.tbTheadCount.Text = "2";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(43, 134);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(65, 12);
            this.lbCount.TabIndex = 5;
            this.lbCount.Text = "线程个数：";
            // 
            // rtbResult
            // 
            this.rtbResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbResult.Location = new System.Drawing.Point(0, 189);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(584, 326);
            this.rtbResult.TabIndex = 6;
            this.rtbResult.Text = "";
            // 
            // ThreadAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.tbTheadCount);
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Name = "ThreadAppForm";
            this.Text = "ThreadApp";
            this.Load += new System.EventHandler(this.ThreadAppForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.TextBox tbTheadCount;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.RichTextBox rtbResult;
    }
}

