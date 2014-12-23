namespace WorldGIS
{
    partial class CtrlMarkerStylePage
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownTextOpaque = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.pictureBoxTextColor = new System.Windows.Forms.PictureBox();
            this.numericUpDownTextScale = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxIconPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxIconPath = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownIconOpaque = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIconScale = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxIconColor = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTextOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTextColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTextScale)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIconOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIconScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconColor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownTextOpaque);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.pictureBoxTextColor);
            this.groupBox3.Controls.Add(this.numericUpDownTextScale);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(25, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 125);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "标签风格";
            // 
            // numericUpDownTextOpaque
            // 
            this.numericUpDownTextOpaque.Location = new System.Drawing.Point(85, 55);
            this.numericUpDownTextOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownTextOpaque.Name = "numericUpDownTextOpaque";
            this.numericUpDownTextOpaque.Size = new System.Drawing.Size(178, 21);
            this.numericUpDownTextOpaque.TabIndex = 8;
            this.numericUpDownTextOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownTextOpaque.ValueChanged += new System.EventHandler(this.numericUpDownTextOpaque_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 63);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 7;
            this.label21.Text = "不透明度：";
            // 
            // pictureBoxTextColor
            // 
            this.pictureBoxTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTextColor.Location = new System.Drawing.Point(85, 31);
            this.pictureBoxTextColor.Name = "pictureBoxTextColor";
            this.pictureBoxTextColor.Size = new System.Drawing.Size(178, 18);
            this.pictureBoxTextColor.TabIndex = 4;
            this.pictureBoxTextColor.TabStop = false;
            this.pictureBoxTextColor.Click += new System.EventHandler(this.pictureBoxTextColor_Click);
            // 
            // numericUpDownTextScale
            // 
            this.numericUpDownTextScale.DecimalPlaces = 1;
            this.numericUpDownTextScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTextScale.Location = new System.Drawing.Point(85, 82);
            this.numericUpDownTextScale.Name = "numericUpDownTextScale";
            this.numericUpDownTextScale.Size = new System.Drawing.Size(178, 21);
            this.numericUpDownTextScale.TabIndex = 3;
            this.numericUpDownTextScale.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownTextScale.ValueChanged += new System.EventHandler(this.numericUpDownTextScale_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "标签缩放：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "标签颜色：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxIconPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBoxIconPath);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.numericUpDownIconOpaque);
            this.groupBox2.Controls.Add(this.numericUpDownIconScale);
            this.groupBox2.Controls.Add(this.pictureBoxIconColor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(25, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 145);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图标风格";
            // 
            // textBoxIconPath
            // 
            this.textBoxIconPath.Location = new System.Drawing.Point(85, 27);
            this.textBoxIconPath.Name = "textBoxIconPath";
            this.textBoxIconPath.Size = new System.Drawing.Size(152, 21);
            this.textBoxIconPath.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "图标路径：";
            // 
            // pictureBoxIconPath
            // 
            this.pictureBoxIconPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIconPath.Image = global::WorldGIS.Properties.Resources.pin_pl;
            this.pictureBoxIconPath.Location = new System.Drawing.Point(239, 27);
            this.pictureBoxIconPath.Name = "pictureBoxIconPath";
            this.pictureBoxIconPath.Size = new System.Drawing.Size(24, 20);
            this.pictureBoxIconPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIconPath.TabIndex = 11;
            this.pictureBoxIconPath.TabStop = false;
            this.pictureBoxIconPath.Click += new System.EventHandler(this.pictureBoxIconPath_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 6;
            this.label20.Text = "不透明度：";
            // 
            // numericUpDownIconOpaque
            // 
            this.numericUpDownIconOpaque.Location = new System.Drawing.Point(85, 78);
            this.numericUpDownIconOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownIconOpaque.Name = "numericUpDownIconOpaque";
            this.numericUpDownIconOpaque.Size = new System.Drawing.Size(178, 21);
            this.numericUpDownIconOpaque.TabIndex = 5;
            this.numericUpDownIconOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownIconOpaque.ValueChanged += new System.EventHandler(this.numericUpDownIconOpaque_ValueChanged);
            // 
            // numericUpDownIconScale
            // 
            this.numericUpDownIconScale.DecimalPlaces = 1;
            this.numericUpDownIconScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownIconScale.Location = new System.Drawing.Point(85, 105);
            this.numericUpDownIconScale.Name = "numericUpDownIconScale";
            this.numericUpDownIconScale.Size = new System.Drawing.Size(178, 21);
            this.numericUpDownIconScale.TabIndex = 4;
            this.numericUpDownIconScale.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownIconScale.ValueChanged += new System.EventHandler(this.numericUpDownIconScale_ValueChanged);
            // 
            // pictureBoxIconColor
            // 
            this.pictureBoxIconColor.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIconColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIconColor.Location = new System.Drawing.Point(85, 54);
            this.pictureBoxIconColor.Name = "pictureBoxIconColor";
            this.pictureBoxIconColor.Size = new System.Drawing.Size(178, 18);
            this.pictureBoxIconColor.TabIndex = 3;
            this.pictureBoxIconColor.TabStop = false;
            this.pictureBoxIconColor.Click += new System.EventHandler(this.pictureBoxIconColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "图标缩放：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "图标颜色：";
            // 
            // CtrlMarkerStylePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "CtrlMarkerStylePage";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlMarkerStylePage_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTextOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTextColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTextScale)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIconOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIconScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownTextOpaque;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.PictureBox pictureBoxTextColor;
        private System.Windows.Forms.NumericUpDown numericUpDownTextScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownIconOpaque;
        private System.Windows.Forms.NumericUpDown numericUpDownIconScale;
        private System.Windows.Forms.PictureBox pictureBoxIconColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxIconPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIconPath;
    }
}
