namespace WorldGIS
{
    partial class CtrlExtrudePage
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseBodyPartStyle = new System.Windows.Forms.CheckBox();
            this.buttonBodyPartStyle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbExtrudeType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxExtrudeValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseTailPartStyle = new System.Windows.Forms.CheckBox();
            this.buttonTailPartStyle = new System.Windows.Forms.Button();
            this.checkBoxBodyPartVisible = new System.Windows.Forms.CheckBox();
            this.checkBoxTailPartVisible = new System.Windows.Forms.CheckBox();
            this.checkBoxHeadPartVisible = new System.Windows.Forms.CheckBox();
            this.checkBoxUseExturde = new System.Windows.Forms.CheckBox();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.checkBoxBodyPartVisible);
            this.groupBox5.Controls.Add(this.checkBoxTailPartVisible);
            this.groupBox5.Controls.Add(this.checkBoxHeadPartVisible);
            this.groupBox5.Controls.Add(this.checkBoxUseExturde);
            this.groupBox5.Location = new System.Drawing.Point(24, 17);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(283, 300);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxUseBodyPartStyle);
            this.groupBox3.Controls.Add(this.buttonBodyPartStyle);
            this.groupBox3.Location = new System.Drawing.Point(19, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 71);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "立面风格";
            // 
            // checkBoxUseBodyPartStyle
            // 
            this.checkBoxUseBodyPartStyle.AutoSize = true;
            this.checkBoxUseBodyPartStyle.Location = new System.Drawing.Point(114, 0);
            this.checkBoxUseBodyPartStyle.Name = "checkBoxUseBodyPartStyle";
            this.checkBoxUseBodyPartStyle.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseBodyPartStyle.TabIndex = 6;
            this.checkBoxUseBodyPartStyle.Text = "使用自定义风格";
            this.checkBoxUseBodyPartStyle.UseVisualStyleBackColor = true;
            this.checkBoxUseBodyPartStyle.CheckedChanged += new System.EventHandler(this.checkBoxUseBodyPartStyle_CheckedChanged);
            // 
            // buttonBodyPartStyle
            // 
            this.buttonBodyPartStyle.Location = new System.Drawing.Point(27, 30);
            this.buttonBodyPartStyle.Name = "buttonBodyPartStyle";
            this.buttonBodyPartStyle.Size = new System.Drawing.Size(192, 23);
            this.buttonBodyPartStyle.TabIndex = 5;
            this.buttonBodyPartStyle.Text = "定义面风格";
            this.buttonBodyPartStyle.UseVisualStyleBackColor = true;
            this.buttonBodyPartStyle.Click += new System.EventHandler(this.buttonBodyPartStyle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbbExtrudeType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tboxExtrudeValue);
            this.groupBox2.Location = new System.Drawing.Point(19, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 76);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拉伸设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "米";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "拉伸方式：";
            // 
            // cbbExtrudeType
            // 
            this.cbbExtrudeType.FormattingEnabled = true;
            this.cbbExtrudeType.Items.AddRange(new object[] {
            "拉伸多少米",
            "拉伸到海拔多少米",
            "拉伸到地表"});
            this.cbbExtrudeType.Location = new System.Drawing.Point(90, 44);
            this.cbbExtrudeType.Name = "cbbExtrudeType";
            this.cbbExtrudeType.Size = new System.Drawing.Size(126, 20);
            this.cbbExtrudeType.TabIndex = 3;
            this.cbbExtrudeType.Text = "拉伸";
            this.cbbExtrudeType.SelectedIndexChanged += new System.EventHandler(this.cbbExtrudeType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "拉伸值：";
            // 
            // tboxExtrudeValue
            // 
            this.tboxExtrudeValue.Location = new System.Drawing.Point(90, 17);
            this.tboxExtrudeValue.Name = "tboxExtrudeValue";
            this.tboxExtrudeValue.Size = new System.Drawing.Size(126, 21);
            this.tboxExtrudeValue.TabIndex = 1;
            this.tboxExtrudeValue.TextChanged += new System.EventHandler(this.tboxExtrudeValue_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxUseTailPartStyle);
            this.groupBox1.Controls.Add(this.buttonTailPartStyle);
            this.groupBox1.Location = new System.Drawing.Point(20, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "末端风格";
            // 
            // checkBoxUseTailPartStyle
            // 
            this.checkBoxUseTailPartStyle.AutoSize = true;
            this.checkBoxUseTailPartStyle.Location = new System.Drawing.Point(114, 0);
            this.checkBoxUseTailPartStyle.Name = "checkBoxUseTailPartStyle";
            this.checkBoxUseTailPartStyle.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseTailPartStyle.TabIndex = 6;
            this.checkBoxUseTailPartStyle.Text = "使用自定义风格";
            this.checkBoxUseTailPartStyle.UseVisualStyleBackColor = true;
            this.checkBoxUseTailPartStyle.CheckedChanged += new System.EventHandler(this.checkBoxUseTailPartStyle_CheckedChanged);
            // 
            // buttonTailPartStyle
            // 
            this.buttonTailPartStyle.Location = new System.Drawing.Point(27, 30);
            this.buttonTailPartStyle.Name = "buttonTailPartStyle";
            this.buttonTailPartStyle.Size = new System.Drawing.Size(192, 23);
            this.buttonTailPartStyle.TabIndex = 5;
            this.buttonTailPartStyle.Text = "定义面风格";
            this.buttonTailPartStyle.UseVisualStyleBackColor = true;
            this.buttonTailPartStyle.Click += new System.EventHandler(this.buttonTailPartStyle_Click);
            // 
            // checkBoxBodyPartVisible
            // 
            this.checkBoxBodyPartVisible.AutoSize = true;
            this.checkBoxBodyPartVisible.Location = new System.Drawing.Point(193, 267);
            this.checkBoxBodyPartVisible.Name = "checkBoxBodyPartVisible";
            this.checkBoxBodyPartVisible.Size = new System.Drawing.Size(72, 16);
            this.checkBoxBodyPartVisible.TabIndex = 9;
            this.checkBoxBodyPartVisible.Text = "立面可见";
            this.checkBoxBodyPartVisible.UseVisualStyleBackColor = true;
            this.checkBoxBodyPartVisible.CheckedChanged += new System.EventHandler(this.checkBoxBodyPartVisible_CheckedChanged);
            // 
            // checkBoxTailPartVisible
            // 
            this.checkBoxTailPartVisible.AutoSize = true;
            this.checkBoxTailPartVisible.Location = new System.Drawing.Point(107, 267);
            this.checkBoxTailPartVisible.Name = "checkBoxTailPartVisible";
            this.checkBoxTailPartVisible.Size = new System.Drawing.Size(72, 16);
            this.checkBoxTailPartVisible.TabIndex = 8;
            this.checkBoxTailPartVisible.Text = "末端可见";
            this.checkBoxTailPartVisible.UseVisualStyleBackColor = true;
            this.checkBoxTailPartVisible.CheckedChanged += new System.EventHandler(this.checkBoxTailPartVisible_CheckedChanged);
            // 
            // checkBoxHeadPartVisible
            // 
            this.checkBoxHeadPartVisible.AutoSize = true;
            this.checkBoxHeadPartVisible.Location = new System.Drawing.Point(19, 267);
            this.checkBoxHeadPartVisible.Name = "checkBoxHeadPartVisible";
            this.checkBoxHeadPartVisible.Size = new System.Drawing.Size(72, 16);
            this.checkBoxHeadPartVisible.TabIndex = 7;
            this.checkBoxHeadPartVisible.Text = "前端可见";
            this.checkBoxHeadPartVisible.UseVisualStyleBackColor = true;
            this.checkBoxHeadPartVisible.CheckedChanged += new System.EventHandler(this.checkBoxHeadPartVisible_CheckedChanged);
            // 
            // checkBoxUseExturde
            // 
            this.checkBoxUseExturde.AutoSize = true;
            this.checkBoxUseExturde.Location = new System.Drawing.Point(193, 0);
            this.checkBoxUseExturde.Name = "checkBoxUseExturde";
            this.checkBoxUseExturde.Size = new System.Drawing.Size(72, 16);
            this.checkBoxUseExturde.TabIndex = 0;
            this.checkBoxUseExturde.Text = "启用拉伸";
            this.checkBoxUseExturde.UseVisualStyleBackColor = true;
            this.checkBoxUseExturde.CheckedChanged += new System.EventHandler(this.checkBoxUseExturde_CheckedChanged);
            // 
            // CtrlExtrudePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox5);
            this.Name = "CtrlExtrudePage";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlExtrudePage_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonTailPartStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbExtrudeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboxExtrudeValue;
        private System.Windows.Forms.CheckBox checkBoxUseExturde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxBodyPartVisible;
        private System.Windows.Forms.CheckBox checkBoxTailPartVisible;
        private System.Windows.Forms.CheckBox checkBoxHeadPartVisible;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxUseTailPartStyle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxUseBodyPartStyle;
        private System.Windows.Forms.Button buttonBodyPartStyle;
    }
}
