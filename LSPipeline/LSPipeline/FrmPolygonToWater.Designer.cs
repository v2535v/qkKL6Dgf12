namespace WorldGIS
{
    partial class FrmPolygonToWater
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOk = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.upDownReflectOpaque = new System.Windows.Forms.NumericUpDown();
            this.checkBoxWaveLOD = new System.Windows.Forms.CheckBox();
            this.textBoxDuDvImage = new System.Windows.Forms.TextBox();
            this.buttonDuDvImage = new System.Windows.Forms.Button();
            this.textBoxNormalImage = new System.Windows.Forms.TextBox();
            this.buttonNormalImage = new System.Windows.Forms.Button();
            this.comboBoxLightType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkboxReflectSky = new System.Windows.Forms.CheckBox();
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.upDownReflectOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReflectColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaterColor)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(41, 296);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(48, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 156);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 66;
            this.label20.Text = "不透明度：";
            // 
            // upDownReflectOpaque
            // 
            this.upDownReflectOpaque.Location = new System.Drawing.Point(91, 151);
            this.upDownReflectOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upDownReflectOpaque.Name = "upDownReflectOpaque";
            this.upDownReflectOpaque.Size = new System.Drawing.Size(100, 21);
            this.upDownReflectOpaque.TabIndex = 65;
            this.upDownReflectOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // checkBoxWaveLOD
            // 
            this.checkBoxWaveLOD.AutoSize = true;
            this.checkBoxWaveLOD.Location = new System.Drawing.Point(94, 271);
            this.checkBoxWaveLOD.Name = "checkBoxWaveLOD";
            this.checkBoxWaveLOD.Size = new System.Drawing.Size(96, 16);
            this.checkBoxWaveLOD.TabIndex = 64;
            this.checkBoxWaveLOD.Text = "波纹逐级细化";
            this.checkBoxWaveLOD.UseVisualStyleBackColor = true;
            // 
            // textBoxDuDvImage
            // 
            this.textBoxDuDvImage.Location = new System.Drawing.Point(92, 236);
            this.textBoxDuDvImage.Name = "textBoxDuDvImage";
            this.textBoxDuDvImage.Size = new System.Drawing.Size(100, 21);
            this.textBoxDuDvImage.TabIndex = 61;
            // 
            // buttonDuDvImage
            // 
            this.buttonDuDvImage.Location = new System.Drawing.Point(12, 235);
            this.buttonDuDvImage.Name = "buttonDuDvImage";
            this.buttonDuDvImage.Size = new System.Drawing.Size(77, 23);
            this.buttonDuDvImage.TabIndex = 60;
            this.buttonDuDvImage.Text = "噪声图...";
            this.buttonDuDvImage.UseVisualStyleBackColor = true;
            // 
            // textBoxNormalImage
            // 
            this.textBoxNormalImage.Location = new System.Drawing.Point(92, 208);
            this.textBoxNormalImage.Name = "textBoxNormalImage";
            this.textBoxNormalImage.Size = new System.Drawing.Size(100, 21);
            this.textBoxNormalImage.TabIndex = 59;
            // 
            // buttonNormalImage
            // 
            this.buttonNormalImage.Location = new System.Drawing.Point(12, 207);
            this.buttonNormalImage.Name = "buttonNormalImage";
            this.buttonNormalImage.Size = new System.Drawing.Size(77, 23);
            this.buttonNormalImage.TabIndex = 58;
            this.buttonNormalImage.Text = "向量图...";
            this.buttonNormalImage.UseVisualStyleBackColor = true;
            // 
            // comboBoxLightType
            // 
            this.comboBoxLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLightType.FormattingEnabled = true;
            this.comboBoxLightType.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBoxLightType.Location = new System.Drawing.Point(92, 178);
            this.comboBoxLightType.Name = "comboBoxLightType";
            this.comboBoxLightType.Size = new System.Drawing.Size(100, 20);
            this.comboBoxLightType.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 56;
            this.label2.Text = "光源类型：";
            // 
            // checkboxReflectSky
            // 
            this.checkboxReflectSky.AutoSize = true;
            this.checkboxReflectSky.Location = new System.Drawing.Point(14, 272);
            this.checkboxReflectSky.Name = "checkboxReflectSky";
            this.checkboxReflectSky.Size = new System.Drawing.Size(72, 16);
            this.checkboxReflectSky.TabIndex = 55;
            this.checkboxReflectSky.Text = "天空倒影";
            this.checkboxReflectSky.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 130);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 54;
            this.label23.Text = "反射颜色：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 102);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 53;
            this.label22.Text = "水波颜色：";
            // 
            // textBoxWaveWidth
            // 
            this.textBoxWaveWidth.Location = new System.Drawing.Point(92, 69);
            this.textBoxWaveWidth.Name = "textBoxWaveWidth";
            this.textBoxWaveWidth.Size = new System.Drawing.Size(100, 21);
            this.textBoxWaveWidth.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 51;
            this.label7.Text = "水波宽度：";
            // 
            // textBoxWaveSpeedY
            // 
            this.textBoxWaveSpeedY.Location = new System.Drawing.Point(92, 42);
            this.textBoxWaveSpeedY.Name = "textBoxWaveSpeedY";
            this.textBoxWaveSpeedY.Size = new System.Drawing.Size(100, 21);
            this.textBoxWaveSpeedY.TabIndex = 50;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 49;
            this.label21.Text = "纵向速度：";
            // 
            // textBoxWaveSpeedX
            // 
            this.textBoxWaveSpeedX.Location = new System.Drawing.Point(92, 15);
            this.textBoxWaveSpeedX.Name = "textBoxWaveSpeedX";
            this.textBoxWaveSpeedX.Size = new System.Drawing.Size(100, 21);
            this.textBoxWaveSpeedX.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "横向速度：";
            // 
            // pictureBoxReflectColor
            // 
            this.pictureBoxReflectColor.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pictureBoxReflectColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxReflectColor.Location = new System.Drawing.Point(91, 125);
            this.pictureBoxReflectColor.Name = "pictureBoxReflectColor";
            this.pictureBoxReflectColor.Size = new System.Drawing.Size(100, 20);
            this.pictureBoxReflectColor.TabIndex = 63;
            this.pictureBoxReflectColor.TabStop = false;
            this.pictureBoxReflectColor.Click += new System.EventHandler(this.pictureBoxReflectColor_Click);
            // 
            // pictureBoxWaterColor
            // 
            this.pictureBoxWaterColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxWaterColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWaterColor.Location = new System.Drawing.Point(91, 98);
            this.pictureBoxWaterColor.Name = "pictureBoxWaterColor";
            this.pictureBoxWaterColor.Size = new System.Drawing.Size(100, 20);
            this.pictureBoxWaterColor.TabIndex = 62;
            this.pictureBoxWaterColor.TabStop = false;
            this.pictureBoxWaterColor.Click += new System.EventHandler(this.pictureBoxWaterColor_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(95, 296);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(48, 23);
            this.buttonCancel.TabIndex = 67;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(149, 296);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(48, 23);
            this.buttonApply.TabIndex = 68;
            this.buttonApply.Text = "应用";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // FrmPolygonToWater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 331);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
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
            this.Controls.Add(this.checkboxReflectSky);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBoxWaveWidth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxWaveSpeedY);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBoxWaveSpeedX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPolygonToWater";
            this.ShowIcon = false;
            this.Text = "面转水面";
            this.Load += new System.EventHandler(this.FrmPolygonToWater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upDownReflectOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReflectColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaterColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
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
        private System.Windows.Forms.CheckBox checkboxReflectSky;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxWaveWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxWaveSpeedY;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxWaveSpeedX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
    }
}