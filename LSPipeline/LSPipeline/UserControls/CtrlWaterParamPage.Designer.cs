namespace WorldGIS
{
    partial class FrmWaterParamPage
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
            this.label20 = new System.Windows.Forms.Label();
            this.upDownReflectOpaque = new System.Windows.Forms.NumericUpDown();
            this.checkBoxWaveLOD = new System.Windows.Forms.CheckBox();
            this.textBoxDuDvImage = new System.Windows.Forms.TextBox();
            this.buttonDuDvImage = new System.Windows.Forms.Button();
            this.textBoxNormalImage = new System.Windows.Forms.TextBox();
            this.buttonNormalImage = new System.Windows.Forms.Button();
            this.comboBoxLightType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxReflectSky = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxWaveWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxWaveSpeedY = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxWaveSpeedX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxReflectColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxWaterColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.upDownReflectOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReflectColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaterColor)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(81, 176);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 46;
            this.label20.Text = "不透明度：";
            // 
            // upDownReflectOpaque
            // 
            this.upDownReflectOpaque.Location = new System.Drawing.Point(160, 171);
            this.upDownReflectOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upDownReflectOpaque.Name = "upDownReflectOpaque";
            this.upDownReflectOpaque.Size = new System.Drawing.Size(100, 21);
            this.upDownReflectOpaque.TabIndex = 45;
            this.upDownReflectOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upDownReflectOpaque.ValueChanged += new System.EventHandler(this.upDownReflectOpaque_ValueChanged);
            // 
            // checkBoxWaveLOD
            // 
            this.checkBoxWaveLOD.AutoSize = true;
            this.checkBoxWaveLOD.Location = new System.Drawing.Point(163, 291);
            this.checkBoxWaveLOD.Name = "checkBoxWaveLOD";
            this.checkBoxWaveLOD.Size = new System.Drawing.Size(96, 16);
            this.checkBoxWaveLOD.TabIndex = 44;
            this.checkBoxWaveLOD.Text = "波纹逐级细化";
            this.checkBoxWaveLOD.UseVisualStyleBackColor = true;
            this.checkBoxWaveLOD.CheckedChanged += new System.EventHandler(this.checkBoxWaveLOD_CheckedChanged);
            // 
            // textBoxDuDvImage
            // 
            this.textBoxDuDvImage.Location = new System.Drawing.Point(161, 256);
            this.textBoxDuDvImage.Name = "textBoxDuDvImage";
            this.textBoxDuDvImage.Size = new System.Drawing.Size(100, 21);
            this.textBoxDuDvImage.TabIndex = 41;
            // 
            // buttonDuDvImage
            // 
            this.buttonDuDvImage.Location = new System.Drawing.Point(81, 255);
            this.buttonDuDvImage.Name = "buttonDuDvImage";
            this.buttonDuDvImage.Size = new System.Drawing.Size(77, 23);
            this.buttonDuDvImage.TabIndex = 40;
            this.buttonDuDvImage.Text = "噪声图...";
            this.buttonDuDvImage.UseVisualStyleBackColor = true;
            this.buttonDuDvImage.Click += new System.EventHandler(this.buttonDuDvImage_Click);
            // 
            // textBoxNormalImage
            // 
            this.textBoxNormalImage.Location = new System.Drawing.Point(161, 228);
            this.textBoxNormalImage.Name = "textBoxNormalImage";
            this.textBoxNormalImage.Size = new System.Drawing.Size(100, 21);
            this.textBoxNormalImage.TabIndex = 39;
            // 
            // buttonNormalImage
            // 
            this.buttonNormalImage.Location = new System.Drawing.Point(81, 227);
            this.buttonNormalImage.Name = "buttonNormalImage";
            this.buttonNormalImage.Size = new System.Drawing.Size(77, 23);
            this.buttonNormalImage.TabIndex = 38;
            this.buttonNormalImage.Text = "向量图...";
            this.buttonNormalImage.UseVisualStyleBackColor = true;
            this.buttonNormalImage.Click += new System.EventHandler(this.buttonNormalImage_Click);
            // 
            // comboBoxLightType
            // 
            this.comboBoxLightType.FormattingEnabled = true;
            this.comboBoxLightType.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBoxLightType.Location = new System.Drawing.Point(161, 198);
            this.comboBoxLightType.Name = "comboBoxLightType";
            this.comboBoxLightType.Size = new System.Drawing.Size(100, 20);
            this.comboBoxLightType.TabIndex = 37;
            this.comboBoxLightType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLightType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "光源类型：";
            // 
            // cboxReflectSky
            // 
            this.cboxReflectSky.AutoSize = true;
            this.cboxReflectSky.Location = new System.Drawing.Point(83, 292);
            this.cboxReflectSky.Name = "cboxReflectSky";
            this.cboxReflectSky.Size = new System.Drawing.Size(72, 16);
            this.cboxReflectSky.TabIndex = 35;
            this.cboxReflectSky.Text = "天空倒影";
            this.cboxReflectSky.UseVisualStyleBackColor = true;
            this.cboxReflectSky.CheckedChanged += new System.EventHandler(this.cboxReflectSky_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(81, 150);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 34;
            this.label23.Text = "反射颜色：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(81, 122);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 33;
            this.label22.Text = "水波颜色：";
            // 
            // textBoxWaveWidth
            // 
            this.textBoxWaveWidth.Location = new System.Drawing.Point(161, 89);
            this.textBoxWaveWidth.Name = "textBoxWaveWidth";
            this.textBoxWaveWidth.Size = new System.Drawing.Size(100, 21);
            this.textBoxWaveWidth.TabIndex = 32;
            this.textBoxWaveWidth.TextChanged += new System.EventHandler(this.textBoxWaveWidth_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "水波宽度：";
            // 
            // textBoxWaveSpeedY
            // 
            this.textBoxWaveSpeedY.Location = new System.Drawing.Point(161, 62);
            this.textBoxWaveSpeedY.Name = "textBoxWaveSpeedY";
            this.textBoxWaveSpeedY.Size = new System.Drawing.Size(100, 21);
            this.textBoxWaveSpeedY.TabIndex = 30;
            this.textBoxWaveSpeedY.TextChanged += new System.EventHandler(this.textBoxWaveSpeedY_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(81, 66);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 29;
            this.label21.Text = "纵向速度：";
            // 
            // textBoxWaveSpeedX
            // 
            this.textBoxWaveSpeedX.Location = new System.Drawing.Point(161, 35);
            this.textBoxWaveSpeedX.Name = "textBoxWaveSpeedX";
            this.textBoxWaveSpeedX.Size = new System.Drawing.Size(100, 21);
            this.textBoxWaveSpeedX.TabIndex = 28;
            this.textBoxWaveSpeedX.TextChanged += new System.EventHandler(this.textBoxWaveSpeedX_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "横向速度：";
            // 
            // pictureBoxReflectColor
            // 
            this.pictureBoxReflectColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxReflectColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxReflectColor.Location = new System.Drawing.Point(160, 145);
            this.pictureBoxReflectColor.Name = "pictureBoxReflectColor";
            this.pictureBoxReflectColor.Size = new System.Drawing.Size(100, 20);
            this.pictureBoxReflectColor.TabIndex = 43;
            this.pictureBoxReflectColor.TabStop = false;
            this.pictureBoxReflectColor.Click += new System.EventHandler(this.pictureBoxReflectColor_Click);
            // 
            // pictureBoxWaterColor
            // 
            this.pictureBoxWaterColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxWaterColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWaterColor.Location = new System.Drawing.Point(160, 118);
            this.pictureBoxWaterColor.Name = "pictureBoxWaterColor";
            this.pictureBoxWaterColor.Size = new System.Drawing.Size(100, 20);
            this.pictureBoxWaterColor.TabIndex = 42;
            this.pictureBoxWaterColor.TabStop = false;
            this.pictureBoxWaterColor.Click += new System.EventHandler(this.pictureBoxWaterColor_Click);
            // 
            // CtrlWaterParamPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label20);
            this.Controls.Add(this.upDownReflectOpaque);
            this.Controls.Add(this.checkBoxWaveLOD);
            this.Controls.Add(this.pictureBoxReflectColor);
            this.Controls.Add(this.pictureBoxWaterColor);
            this.Controls.Add(this.textBoxDuDvImage);
            this.Controls.Add(this.buttonDuDvImage);
            this.Controls.Add(this.textBoxNormalImage);
            this.Controls.Add(this.buttonNormalImage);
            this.Controls.Add(this.comboBoxLightType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxReflectSky);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBoxWaveWidth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxWaveSpeedY);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBoxWaveSpeedX);
            this.Controls.Add(this.label5);
            this.Name = "CtrlWaterParamPage";
            this.Size = new System.Drawing.Size(343, 343);
            this.Load += new System.EventHandler(this.CtrlWaterParamPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upDownReflectOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReflectColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaterColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown upDownReflectOpaque;
        private System.Windows.Forms.CheckBox checkBoxWaveLOD;
        private System.Windows.Forms.PictureBox pictureBoxReflectColor;
        private System.Windows.Forms.PictureBox pictureBoxWaterColor;
        private System.Windows.Forms.TextBox textBoxDuDvImage;
        private System.Windows.Forms.Button buttonDuDvImage;
        private System.Windows.Forms.TextBox textBoxNormalImage;
        private System.Windows.Forms.Button buttonNormalImage;
        private System.Windows.Forms.ComboBox comboBoxLightType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cboxReflectSky;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxWaveWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxWaveSpeedY;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxWaveSpeedX;
        private System.Windows.Forms.Label label5;
    }
}
