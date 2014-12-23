namespace WorldGIS
{
    partial class CtrlPolygonStylePage
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
            this.checkBoxUseStyle = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBoxFillColor = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownFillOpaque = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseOutlineStyle = new System.Windows.Forms.CheckBox();
            this.buttonSetLineStyle = new System.Windows.Forms.Button();
            this.checkBoxOutline = new System.Windows.Forms.CheckBox();
            this.checkBoxFill = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFillColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFillOpaque)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxUseStyle
            // 
            this.checkBoxUseStyle.AutoSize = true;
            this.checkBoxUseStyle.Location = new System.Drawing.Point(185, 39);
            this.checkBoxUseStyle.Name = "checkBoxUseStyle";
            this.checkBoxUseStyle.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseStyle.TabIndex = 31;
            this.checkBoxUseStyle.Text = "使用自定义风格";
            this.checkBoxUseStyle.UseVisualStyleBackColor = true;
            this.checkBoxUseStyle.CheckedChanged += new System.EventHandler(this.checkBoxUseStyle_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkBoxOutline);
            this.groupBox1.Controls.Add(this.checkBoxFill);
            this.groupBox1.Location = new System.Drawing.Point(22, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 254);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBoxFillColor);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.numericUpDownFillOpaque);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(40, 29);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(212, 81);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "填充风格";
            // 
            // pictureBoxFillColor
            // 
            this.pictureBoxFillColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFillColor.Location = new System.Drawing.Point(81, 21);
            this.pictureBoxFillColor.Name = "pictureBoxFillColor";
            this.pictureBoxFillColor.Size = new System.Drawing.Size(115, 18);
            this.pictureBoxFillColor.TabIndex = 8;
            this.pictureBoxFillColor.TabStop = false;
            this.pictureBoxFillColor.Click += new System.EventHandler(this.pictureBoxFillColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "不透明度：";
            // 
            // numericUpDownFillOpaque
            // 
            this.numericUpDownFillOpaque.Location = new System.Drawing.Point(81, 43);
            this.numericUpDownFillOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownFillOpaque.Name = "numericUpDownFillOpaque";
            this.numericUpDownFillOpaque.Size = new System.Drawing.Size(115, 21);
            this.numericUpDownFillOpaque.TabIndex = 16;
            this.numericUpDownFillOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownFillOpaque.ValueChanged += new System.EventHandler(this.numericUpDownFillOpaque_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "填充颜色：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxUseOutlineStyle);
            this.groupBox2.Controls.Add(this.buttonSetLineStyle);
            this.groupBox2.Location = new System.Drawing.Point(40, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 78);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轮廓线风格";
            // 
            // checkBoxUseOutlineStyle
            // 
            this.checkBoxUseOutlineStyle.AutoSize = true;
            this.checkBoxUseOutlineStyle.Location = new System.Drawing.Point(81, 0);
            this.checkBoxUseOutlineStyle.Name = "checkBoxUseOutlineStyle";
            this.checkBoxUseOutlineStyle.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseOutlineStyle.TabIndex = 32;
            this.checkBoxUseOutlineStyle.Text = "使用自定义风格";
            this.checkBoxUseOutlineStyle.UseVisualStyleBackColor = true;
            this.checkBoxUseOutlineStyle.CheckedChanged += new System.EventHandler(this.checkBoxUseOutlineStyle_CheckedChanged);
            // 
            // buttonSetLineStyle
            // 
            this.buttonSetLineStyle.Location = new System.Drawing.Point(13, 30);
            this.buttonSetLineStyle.Name = "buttonSetLineStyle";
            this.buttonSetLineStyle.Size = new System.Drawing.Size(183, 24);
            this.buttonSetLineStyle.TabIndex = 29;
            this.buttonSetLineStyle.Text = "定义线风格";
            this.buttonSetLineStyle.UseVisualStyleBackColor = true;
            this.buttonSetLineStyle.Click += new System.EventHandler(this.buttonSetLineStyle_Click);
            // 
            // checkBoxOutline
            // 
            this.checkBoxOutline.AutoSize = true;
            this.checkBoxOutline.Location = new System.Drawing.Point(144, 213);
            this.checkBoxOutline.Name = "checkBoxOutline";
            this.checkBoxOutline.Size = new System.Drawing.Size(108, 16);
            this.checkBoxOutline.TabIndex = 28;
            this.checkBoxOutline.Text = "是否显示轮廓线";
            this.checkBoxOutline.UseVisualStyleBackColor = true;
            this.checkBoxOutline.CheckedChanged += new System.EventHandler(this.checkBoxOutline_CheckedChanged);
            // 
            // checkBoxFill
            // 
            this.checkBoxFill.AutoSize = true;
            this.checkBoxFill.Location = new System.Drawing.Point(40, 213);
            this.checkBoxFill.Name = "checkBoxFill";
            this.checkBoxFill.Size = new System.Drawing.Size(72, 16);
            this.checkBoxFill.TabIndex = 27;
            this.checkBoxFill.Text = "是否填充";
            this.checkBoxFill.UseVisualStyleBackColor = true;
            this.checkBoxFill.CheckedChanged += new System.EventHandler(this.checkBoxFill_CheckedChanged);
            // 
            // CtrlPolygonStylePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.checkBoxUseStyle);
            this.Controls.Add(this.groupBox1);
            this.Name = "CtrlPolygonStylePage";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlPolygonStylePage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFillColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFillOpaque)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxUseStyle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownFillOpaque;
        private System.Windows.Forms.PictureBox pictureBoxFillColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxUseOutlineStyle;
        private System.Windows.Forms.Button buttonSetLineStyle;
        private System.Windows.Forms.CheckBox checkBoxOutline;
        private System.Windows.Forms.CheckBox checkBoxFill;

    }
}
