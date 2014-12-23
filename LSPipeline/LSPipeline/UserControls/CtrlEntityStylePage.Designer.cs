namespace WorldGIS
{
    partial class CtrlEntityStylePage
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxTexture = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBoxPolygonMode = new System.Windows.Forms.ComboBox();
            this.checkBoxLight = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownModelOpaque = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxModelColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxUseSingleColor = new System.Windows.Forms.CheckBox();
            this.checkBoxUseStyle = new System.Windows.Forms.CheckBox();
            this.checkBoxBothFace = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModelOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModelColor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxBothFace);
            this.groupBox2.Controls.Add(this.checkBoxTexture);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.checkBoxLight);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.checkBoxUseStyle);
            this.groupBox2.Location = new System.Drawing.Point(29, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 277);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // checkBoxTexture
            // 
            this.checkBoxTexture.AutoSize = true;
            this.checkBoxTexture.Location = new System.Drawing.Point(144, 219);
            this.checkBoxTexture.Name = "checkBoxTexture";
            this.checkBoxTexture.Size = new System.Drawing.Size(96, 16);
            this.checkBoxTexture.TabIndex = 16;
            this.checkBoxTexture.Text = "支持贴图效果";
            this.checkBoxTexture.UseVisualStyleBackColor = true;
            this.checkBoxTexture.CheckedChanged += new System.EventHandler(this.checkBoxTexture_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxPolygonMode);
            this.groupBox6.Location = new System.Drawing.Point(26, 119);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(228, 55);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "绘制方式";
            // 
            // comboBoxPolygonMode
            // 
            this.comboBoxPolygonMode.FormattingEnabled = true;
            this.comboBoxPolygonMode.Items.AddRange(new object[] {
            "实体模式",
            "线框模式",
            "点模式",
            "实体线框模式"});
            this.comboBoxPolygonMode.Location = new System.Drawing.Point(14, 21);
            this.comboBoxPolygonMode.Name = "comboBoxPolygonMode";
            this.comboBoxPolygonMode.Size = new System.Drawing.Size(200, 20);
            this.comboBoxPolygonMode.TabIndex = 26;
            this.comboBoxPolygonMode.Text = "实体模式";
            this.comboBoxPolygonMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxPolygonMode_SelectedIndexChanged);
            // 
            // checkBoxLight
            // 
            this.checkBoxLight.AutoSize = true;
            this.checkBoxLight.Location = new System.Drawing.Point(40, 219);
            this.checkBoxLight.Name = "checkBoxLight";
            this.checkBoxLight.Size = new System.Drawing.Size(96, 16);
            this.checkBoxLight.TabIndex = 15;
            this.checkBoxLight.Text = "支持光照效果";
            this.checkBoxLight.UseVisualStyleBackColor = true;
            this.checkBoxLight.CheckedChanged += new System.EventHandler(this.checkBoxLight_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.numericUpDownModelOpaque);
            this.groupBox5.Controls.Add(this.pictureBoxModelColor);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.checkBoxUseSingleColor);
            this.groupBox5.Location = new System.Drawing.Point(26, 26);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(226, 87);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 10;
            this.label20.Text = "不透明度：";
            // 
            // numericUpDownModelOpaque
            // 
            this.numericUpDownModelOpaque.Location = new System.Drawing.Point(85, 51);
            this.numericUpDownModelOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownModelOpaque.Name = "numericUpDownModelOpaque";
            this.numericUpDownModelOpaque.Size = new System.Drawing.Size(129, 21);
            this.numericUpDownModelOpaque.TabIndex = 9;
            this.numericUpDownModelOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownModelOpaque.ValueChanged += new System.EventHandler(this.numericUpDownModelOpaque_ValueChanged);
            // 
            // pictureBoxModelColor
            // 
            this.pictureBoxModelColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxModelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxModelColor.Location = new System.Drawing.Point(85, 27);
            this.pictureBoxModelColor.Name = "pictureBoxModelColor";
            this.pictureBoxModelColor.Size = new System.Drawing.Size(129, 18);
            this.pictureBoxModelColor.TabIndex = 8;
            this.pictureBoxModelColor.TabStop = false;
            this.pictureBoxModelColor.Click += new System.EventHandler(this.pictureBoxModelColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "颜色：";
            // 
            // checkBoxUseSingleColor
            // 
            this.checkBoxUseSingleColor.AutoSize = true;
            this.checkBoxUseSingleColor.Location = new System.Drawing.Point(14, 0);
            this.checkBoxUseSingleColor.Name = "checkBoxUseSingleColor";
            this.checkBoxUseSingleColor.Size = new System.Drawing.Size(96, 16);
            this.checkBoxUseSingleColor.TabIndex = 14;
            this.checkBoxUseSingleColor.Text = "使用单一颜色";
            this.checkBoxUseSingleColor.UseVisualStyleBackColor = true;
            this.checkBoxUseSingleColor.CheckedChanged += new System.EventHandler(this.checkBoxUseSingleColor_CheckedChanged);
            // 
            // checkBoxUseStyle
            // 
            this.checkBoxUseStyle.AutoSize = true;
            this.checkBoxUseStyle.Location = new System.Drawing.Point(172, 0);
            this.checkBoxUseStyle.Name = "checkBoxUseStyle";
            this.checkBoxUseStyle.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseStyle.TabIndex = 12;
            this.checkBoxUseStyle.Text = "使用自定义风格";
            this.checkBoxUseStyle.UseVisualStyleBackColor = true;
            this.checkBoxUseStyle.CheckedChanged += new System.EventHandler(this.checkBoxUseStyle_CheckedChanged);
            // 
            // checkBoxBothFace
            // 
            this.checkBoxBothFace.AutoSize = true;
            this.checkBoxBothFace.Location = new System.Drawing.Point(40, 197);
            this.checkBoxBothFace.Name = "checkBoxBothFace";
            this.checkBoxBothFace.Size = new System.Drawing.Size(96, 16);
            this.checkBoxBothFace.TabIndex = 29;
            this.checkBoxBothFace.Text = "启用双面渲染";
            this.checkBoxBothFace.UseVisualStyleBackColor = true;
            this.checkBoxBothFace.CheckedChanged += new System.EventHandler(this.checkBoxBothFace_CheckedChanged);
            // 
            // CtrlEntityStylePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox2);
            this.Name = "CtrlEntityStylePage";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlEntityStylePage_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModelOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModelColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxTexture;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBoxPolygonMode;
        private System.Windows.Forms.CheckBox checkBoxLight;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownModelOpaque;
        private System.Windows.Forms.PictureBox pictureBoxModelColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxUseSingleColor;
        private System.Windows.Forms.CheckBox checkBoxUseStyle;
        private System.Windows.Forms.CheckBox checkBoxBothFace;
    }
}
