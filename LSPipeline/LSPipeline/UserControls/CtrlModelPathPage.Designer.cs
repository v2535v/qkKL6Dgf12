namespace WorldGIS
{
    partial class CtrlModelPathPage
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxModelPath = new System.Windows.Forms.TextBox();
            this.buttonModelPath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxModelPath
            // 
            this.textBoxModelPath.Location = new System.Drawing.Point(26, 107);
            this.textBoxModelPath.Name = "textBoxModelPath";
            this.textBoxModelPath.Size = new System.Drawing.Size(173, 21);
            this.textBoxModelPath.TabIndex = 8;
            this.textBoxModelPath.TextChanged += new System.EventHandler(this.textBoxModelPath_TextChanged);
            // 
            // buttonModelPath
            // 
            this.buttonModelPath.Location = new System.Drawing.Point(205, 105);
            this.buttonModelPath.Name = "buttonModelPath";
            this.buttonModelPath.Size = new System.Drawing.Size(59, 23);
            this.buttonModelPath.TabIndex = 7;
            this.buttonModelPath.Text = "选择...";
            this.buttonModelPath.UseVisualStyleBackColor = true;
            this.buttonModelPath.Click += new System.EventHandler(this.buttonModelPath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonModelPath);
            this.groupBox1.Controls.Add(this.textBoxModelPath);
            this.groupBox1.Location = new System.Drawing.Point(23, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 257);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模型路径";
            // 
            // CtrlModelPathPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Name = "CtrlModelPathPage";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlModelPathPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxModelPath;
        private System.Windows.Forms.Button buttonModelPath;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
