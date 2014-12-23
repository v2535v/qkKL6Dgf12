namespace WorldGIS
{
    partial class CtrlFeatureAttribute
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
            this.label22 = new System.Windows.Forms.Label();
            this.tbbHeight = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbbWidth = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbbContentType = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxAttribute = new System.Windows.Forms.TextBox();
            this.cbbShowMode = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(166, 69);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 7;
            this.label22.Text = "气泡高度：";
            // 
            // tbbHeight
            // 
            this.tbbHeight.Location = new System.Drawing.Point(235, 66);
            this.tbbHeight.Name = "tbbHeight";
            this.tbbHeight.Size = new System.Drawing.Size(63, 21);
            this.tbbHeight.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(166, 35);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 5;
            this.label23.Text = "气泡宽度：";
            // 
            // tbbWidth
            // 
            this.tbbWidth.Location = new System.Drawing.Point(235, 32);
            this.tbbWidth.Name = "tbbWidth";
            this.tbbWidth.Size = new System.Drawing.Size(63, 21);
            this.tbbWidth.TabIndex = 4;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(5, 69);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 12);
            this.label24.TabIndex = 3;
            this.label24.Text = "内容类型：";
            // 
            // cbbContentType
            // 
            this.cbbContentType.FormattingEnabled = true;
            this.cbbContentType.Items.AddRange(new object[] {
            "内容",
            "链接",
            ""});
            this.cbbContentType.Location = new System.Drawing.Point(76, 67);
            this.cbbContentType.Name = "cbbContentType";
            this.cbbContentType.Size = new System.Drawing.Size(82, 20);
            this.cbbContentType.TabIndex = 2;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(5, 35);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 12);
            this.label25.TabIndex = 1;
            this.label25.Text = "显示方式：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxAttribute);
            this.groupBox5.Location = new System.Drawing.Point(11, 131);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(311, 187);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "内容";
            // 
            // textBoxAttribute
            // 
            this.textBoxAttribute.Location = new System.Drawing.Point(7, 15);
            this.textBoxAttribute.Multiline = true;
            this.textBoxAttribute.Name = "textBoxAttribute";
            this.textBoxAttribute.Size = new System.Drawing.Size(298, 166);
            this.textBoxAttribute.TabIndex = 0;
            // 
            // cbbShowMode
            // 
            this.cbbShowMode.FormattingEnabled = true;
            this.cbbShowMode.Items.AddRange(new object[] {
            "复杂气泡",
            "普通气泡",
            "ie浏览器"});
            this.cbbShowMode.Location = new System.Drawing.Point(76, 32);
            this.cbbShowMode.Name = "cbbShowMode";
            this.cbbShowMode.Size = new System.Drawing.Size(82, 20);
            this.cbbShowMode.TabIndex = 0;
            this.cbbShowMode.SelectedIndexChanged += new System.EventHandler(this.cbbShowMode_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.tbbHeight);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.tbbWidth);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.cbbContentType);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.cbbShowMode);
            this.groupBox4.Location = new System.Drawing.Point(13, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(311, 112);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "气泡设置";
            // 
            // CtrlFeatureAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Name = "CtrlFeatureAttribute";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlFeatureAttribute_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbbHeight;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbbWidth;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbbContentType;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxAttribute;
        private System.Windows.Forms.ComboBox cbbShowMode;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
