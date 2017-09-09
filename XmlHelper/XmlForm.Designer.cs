namespace XmlHelper
{
    partial class XmlForm
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
            this.btn_CreateXml = new System.Windows.Forms.Button();
            this.btn_CreateNodes = new System.Windows.Forms.Button();
            this.btn_AlertNodes = new System.Windows.Forms.Button();
            this.btn_AlertNodesVal = new System.Windows.Forms.Button();
            this.btn_DeleteChildrenNodes = new System.Windows.Forms.Button();
            this.btn_DeleteChildrenNodesVal = new System.Windows.Forms.Button();
            this.btn_GetAllNodes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CreateXml
            // 
            this.btn_CreateXml.Location = new System.Drawing.Point(39, 34);
            this.btn_CreateXml.Name = "btn_CreateXml";
            this.btn_CreateXml.Size = new System.Drawing.Size(112, 37);
            this.btn_CreateXml.TabIndex = 0;
            this.btn_CreateXml.Text = "CreateXmlFile";
            this.btn_CreateXml.UseVisualStyleBackColor = true;
            this.btn_CreateXml.Click += new System.EventHandler(this.btn_CreateXml_Click);
            // 
            // btn_CreateNodes
            // 
            this.btn_CreateNodes.Location = new System.Drawing.Point(39, 91);
            this.btn_CreateNodes.Name = "btn_CreateNodes";
            this.btn_CreateNodes.Size = new System.Drawing.Size(91, 37);
            this.btn_CreateNodes.TabIndex = 1;
            this.btn_CreateNodes.Text = "CreateNodes";
            this.btn_CreateNodes.UseVisualStyleBackColor = true;
            this.btn_CreateNodes.Click += new System.EventHandler(this.btn_CreateNodes_Click);
            // 
            // btn_AlertNodes
            // 
            this.btn_AlertNodes.Location = new System.Drawing.Point(39, 220);
            this.btn_AlertNodes.Name = "btn_AlertNodes";
            this.btn_AlertNodes.Size = new System.Drawing.Size(91, 37);
            this.btn_AlertNodes.TabIndex = 2;
            this.btn_AlertNodes.Text = "AlertNodes";
            this.btn_AlertNodes.UseVisualStyleBackColor = true;
            this.btn_AlertNodes.Click += new System.EventHandler(this.btn_DeleteNodes_Click);
            // 
            // btn_AlertNodesVal
            // 
            this.btn_AlertNodesVal.Location = new System.Drawing.Point(39, 159);
            this.btn_AlertNodesVal.Name = "btn_AlertNodesVal";
            this.btn_AlertNodesVal.Size = new System.Drawing.Size(91, 37);
            this.btn_AlertNodesVal.TabIndex = 3;
            this.btn_AlertNodesVal.Text = "AlertNodesVal";
            this.btn_AlertNodesVal.UseVisualStyleBackColor = true;
            this.btn_AlertNodesVal.Click += new System.EventHandler(this.btn_AlertNodesVal_Click);
            // 
            // btn_DeleteChildrenNodes
            // 
            this.btn_DeleteChildrenNodes.Location = new System.Drawing.Point(414, 34);
            this.btn_DeleteChildrenNodes.Name = "btn_DeleteChildrenNodes";
            this.btn_DeleteChildrenNodes.Size = new System.Drawing.Size(137, 37);
            this.btn_DeleteChildrenNodes.TabIndex = 4;
            this.btn_DeleteChildrenNodes.Text = "DeleteChildrenNodes";
            this.btn_DeleteChildrenNodes.UseVisualStyleBackColor = true;
            this.btn_DeleteChildrenNodes.Click += new System.EventHandler(this.btn_DeleteChildrenNodes_Click);
            // 
            // btn_DeleteChildrenNodesVal
            // 
            this.btn_DeleteChildrenNodesVal.Location = new System.Drawing.Point(414, 159);
            this.btn_DeleteChildrenNodesVal.Name = "btn_DeleteChildrenNodesVal";
            this.btn_DeleteChildrenNodesVal.Size = new System.Drawing.Size(137, 37);
            this.btn_DeleteChildrenNodesVal.TabIndex = 5;
            this.btn_DeleteChildrenNodesVal.Text = "DeleteChildrenNodesVal";
            this.btn_DeleteChildrenNodesVal.UseVisualStyleBackColor = true;
            this.btn_DeleteChildrenNodesVal.Click += new System.EventHandler(this.btn_DeleteChildrenNodesVal_Click);
            // 
            // btn_GetAllNodes
            // 
            this.btn_GetAllNodes.Location = new System.Drawing.Point(200, 34);
            this.btn_GetAllNodes.Name = "btn_GetAllNodes";
            this.btn_GetAllNodes.Size = new System.Drawing.Size(91, 37);
            this.btn_GetAllNodes.TabIndex = 6;
            this.btn_GetAllNodes.Text = "GetAllNodes";
            this.btn_GetAllNodes.UseVisualStyleBackColor = true;
            this.btn_GetAllNodes.Click += new System.EventHandler(this.btn_GetAllNodes_Click);
            // 
            // XmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.btn_GetAllNodes);
            this.Controls.Add(this.btn_DeleteChildrenNodesVal);
            this.Controls.Add(this.btn_DeleteChildrenNodes);
            this.Controls.Add(this.btn_AlertNodesVal);
            this.Controls.Add(this.btn_AlertNodes);
            this.Controls.Add(this.btn_CreateNodes);
            this.Controls.Add(this.btn_CreateXml);
            this.Name = "XmlForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateXml;
        private System.Windows.Forms.Button btn_CreateNodes;
        private System.Windows.Forms.Button btn_AlertNodes;
        private System.Windows.Forms.Button btn_AlertNodesVal;
        private System.Windows.Forms.Button btn_DeleteChildrenNodes;
        private System.Windows.Forms.Button btn_DeleteChildrenNodesVal;
        private System.Windows.Forms.Button btn_GetAllNodes;
    }
}

