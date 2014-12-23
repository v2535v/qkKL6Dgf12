namespace WorldGIS
{
    partial class FrmSetArrowStyle
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
            this.tboxBodyLen = new System.Windows.Forms.TextBox();
            this.cboxNegDir = new System.Windows.Forms.CheckBox();
            this.cboxAlwaysSee = new System.Windows.Forms.CheckBox();
            this.cboxAlongCenter = new System.Windows.Forms.CheckBox();
            this.cboxPixelLen = new System.Windows.Forms.CheckBox();
            this.cbxOutlineVisible = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboxArrowShape = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.nudArrowOpaque = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pboxArrowColor = new System.Windows.Forms.PictureBox();
            this.grpOutlineStyle = new System.Windows.Forms.GroupBox();
            this.labelOutlineOpaque = new System.Windows.Forms.Label();
            this.nudOutlineOpaque = new System.Windows.Forms.NumericUpDown();
            this.pboxOutlineColor = new System.Windows.Forms.PictureBox();
            this.labelOutlineColor = new System.Windows.Forms.Label();
            this.labelOutlineType = new System.Windows.Forms.Label();
            this.comboxOutlineType = new System.Windows.Forms.ComboBox();
            this.labelOutlineWidth = new System.Windows.Forms.Label();
            this.tboxOutlineWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tboxBodyWidth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxHeadWidth = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tboxHeadLen = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tboxArrowGap = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudArrowOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxArrowColor)).BeginInit();
            this.grpOutlineStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxOutlineColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tboxBodyLen
            // 
            this.tboxBodyLen.Location = new System.Drawing.Point(115, 91);
            this.tboxBodyLen.Name = "tboxBodyLen";
            this.tboxBodyLen.Size = new System.Drawing.Size(115, 21);
            this.tboxBodyLen.TabIndex = 63;
            this.tboxBodyLen.TextChanged += new System.EventHandler(this.tboxBodyLen_TextChanged);
            // 
            // cboxNegDir
            // 
            this.cboxNegDir.AutoSize = true;
            this.cboxNegDir.Location = new System.Drawing.Point(170, 242);
            this.cboxNegDir.Name = "cboxNegDir";
            this.cboxNegDir.Size = new System.Drawing.Size(60, 16);
            this.cboxNegDir.TabIndex = 62;
            this.cboxNegDir.Text = "负方向";
            this.cboxNegDir.UseVisualStyleBackColor = true;
            this.cboxNegDir.CheckedChanged += new System.EventHandler(this.cboxNegDir_CheckedChanged);
            // 
            // cboxAlwaysSee
            // 
            this.cboxAlwaysSee.AutoSize = true;
            this.cboxAlwaysSee.Location = new System.Drawing.Point(19, 242);
            this.cboxAlwaysSee.Name = "cboxAlwaysSee";
            this.cboxAlwaysSee.Size = new System.Drawing.Size(72, 16);
            this.cboxAlwaysSee.TabIndex = 61;
            this.cboxAlwaysSee.Text = "永不遮挡";
            this.cboxAlwaysSee.UseVisualStyleBackColor = true;
            this.cboxAlwaysSee.CheckedChanged += new System.EventHandler(this.cboxAlwaysSee_CheckedChanged);
            // 
            // cboxAlongCenter
            // 
            this.cboxAlongCenter.AutoSize = true;
            this.cboxAlongCenter.Location = new System.Drawing.Point(19, 264);
            this.cboxAlongCenter.Name = "cboxAlongCenter";
            this.cboxAlongCenter.Size = new System.Drawing.Size(72, 16);
            this.cboxAlongCenter.TabIndex = 60;
            this.cboxAlongCenter.Text = "总沿中心";
            this.cboxAlongCenter.UseVisualStyleBackColor = true;
            this.cboxAlongCenter.CheckedChanged += new System.EventHandler(this.cboxAlongCenter_CheckedChanged);
            // 
            // cboxPixelLen
            // 
            this.cboxPixelLen.AutoSize = true;
            this.cboxPixelLen.Location = new System.Drawing.Point(92, 242);
            this.cboxPixelLen.Name = "cboxPixelLen";
            this.cboxPixelLen.Size = new System.Drawing.Size(72, 16);
            this.cboxPixelLen.TabIndex = 59;
            this.cboxPixelLen.Text = "像素尺寸";
            this.cboxPixelLen.UseVisualStyleBackColor = true;
            this.cboxPixelLen.CheckedChanged += new System.EventHandler(this.cboxPixelLen_CheckedChanged);
            // 
            // cbxOutlineVisible
            // 
            this.cbxOutlineVisible.AutoSize = true;
            this.cbxOutlineVisible.Location = new System.Drawing.Point(92, 264);
            this.cbxOutlineVisible.Name = "cbxOutlineVisible";
            this.cbxOutlineVisible.Size = new System.Drawing.Size(72, 16);
            this.cbxOutlineVisible.TabIndex = 57;
            this.cbxOutlineVisible.Text = "显示轮廓";
            this.cbxOutlineVisible.UseVisualStyleBackColor = true;
            this.cbxOutlineVisible.CheckedChanged += new System.EventHandler(this.cbxOutlineVisible_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 58;
            this.label4.Text = "箭头样式：";
            // 
            // comboxArrowShape
            // 
            this.comboxArrowShape.FormattingEnabled = true;
            this.comboxArrowShape.Items.AddRange(new object[] {
            "Shape2D0",
            "Shape2D1",
            "Shape2D2",
            "Shape2D3",
            "Shape3D"});
            this.comboxArrowShape.Location = new System.Drawing.Point(115, 65);
            this.comboxArrowShape.Name = "comboxArrowShape";
            this.comboxArrowShape.Size = new System.Drawing.Size(115, 20);
            this.comboxArrowShape.TabIndex = 56;
            this.comboxArrowShape.Text = "Shape2D0";
            this.comboxArrowShape.SelectedIndexChanged += new System.EventHandler(this.comboxArrowShape_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 55;
            this.label20.Text = "不透明度：";
            // 
            // nudArrowOpaque
            // 
            this.nudArrowOpaque.Location = new System.Drawing.Point(115, 38);
            this.nudArrowOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudArrowOpaque.Name = "nudArrowOpaque";
            this.nudArrowOpaque.Size = new System.Drawing.Size(115, 21);
            this.nudArrowOpaque.TabIndex = 54;
            this.nudArrowOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudArrowOpaque.ValueChanged += new System.EventHandler(this.nudArrowOpaque_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "箭头颜色：";
            // 
            // pboxArrowColor
            // 
            this.pboxArrowColor.BackColor = System.Drawing.Color.White;
            this.pboxArrowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxArrowColor.Location = new System.Drawing.Point(115, 15);
            this.pboxArrowColor.Name = "pboxArrowColor";
            this.pboxArrowColor.Size = new System.Drawing.Size(115, 18);
            this.pboxArrowColor.TabIndex = 53;
            this.pboxArrowColor.TabStop = false;
            this.pboxArrowColor.Click += new System.EventHandler(this.pboxArrowColor_Click);
            // 
            // grpOutlineStyle
            // 
            this.grpOutlineStyle.Controls.Add(this.labelOutlineOpaque);
            this.grpOutlineStyle.Controls.Add(this.nudOutlineOpaque);
            this.grpOutlineStyle.Controls.Add(this.pboxOutlineColor);
            this.grpOutlineStyle.Controls.Add(this.labelOutlineColor);
            this.grpOutlineStyle.Controls.Add(this.labelOutlineType);
            this.grpOutlineStyle.Controls.Add(this.comboxOutlineType);
            this.grpOutlineStyle.Controls.Add(this.labelOutlineWidth);
            this.grpOutlineStyle.Controls.Add(this.tboxOutlineWidth);
            this.grpOutlineStyle.Location = new System.Drawing.Point(19, 299);
            this.grpOutlineStyle.Name = "grpOutlineStyle";
            this.grpOutlineStyle.Size = new System.Drawing.Size(211, 135);
            this.grpOutlineStyle.TabIndex = 64;
            this.grpOutlineStyle.TabStop = false;
            this.grpOutlineStyle.Text = "轮廓风格";
            // 
            // labelOutlineOpaque
            // 
            this.labelOutlineOpaque.AutoSize = true;
            this.labelOutlineOpaque.Location = new System.Drawing.Point(10, 54);
            this.labelOutlineOpaque.Name = "labelOutlineOpaque";
            this.labelOutlineOpaque.Size = new System.Drawing.Size(65, 12);
            this.labelOutlineOpaque.TabIndex = 47;
            this.labelOutlineOpaque.Text = "不透明度：";
            // 
            // nudOutlineOpaque
            // 
            this.nudOutlineOpaque.Location = new System.Drawing.Point(77, 50);
            this.nudOutlineOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOutlineOpaque.Name = "nudOutlineOpaque";
            this.nudOutlineOpaque.Size = new System.Drawing.Size(115, 21);
            this.nudOutlineOpaque.TabIndex = 46;
            this.nudOutlineOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOutlineOpaque.ValueChanged += new System.EventHandler(this.nudOutlineOpaque_ValueChanged);
            // 
            // pboxOutlineColor
            // 
            this.pboxOutlineColor.BackColor = System.Drawing.Color.White;
            this.pboxOutlineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxOutlineColor.Location = new System.Drawing.Point(77, 27);
            this.pboxOutlineColor.Name = "pboxOutlineColor";
            this.pboxOutlineColor.Size = new System.Drawing.Size(115, 18);
            this.pboxOutlineColor.TabIndex = 45;
            this.pboxOutlineColor.TabStop = false;
            this.pboxOutlineColor.Click += new System.EventHandler(this.pboxOutlineColor_Click);
            // 
            // labelOutlineColor
            // 
            this.labelOutlineColor.AutoSize = true;
            this.labelOutlineColor.Location = new System.Drawing.Point(10, 30);
            this.labelOutlineColor.Name = "labelOutlineColor";
            this.labelOutlineColor.Size = new System.Drawing.Size(65, 12);
            this.labelOutlineColor.TabIndex = 44;
            this.labelOutlineColor.Text = "轮廓颜色：";
            // 
            // labelOutlineType
            // 
            this.labelOutlineType.AutoSize = true;
            this.labelOutlineType.Location = new System.Drawing.Point(10, 105);
            this.labelOutlineType.Name = "labelOutlineType";
            this.labelOutlineType.Size = new System.Drawing.Size(65, 12);
            this.labelOutlineType.TabIndex = 42;
            this.labelOutlineType.Text = "轮廓样式：";
            // 
            // comboxOutlineType
            // 
            this.comboxOutlineType.FormattingEnabled = true;
            this.comboxOutlineType.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.comboxOutlineType.Location = new System.Drawing.Point(77, 102);
            this.comboxOutlineType.Name = "comboxOutlineType";
            this.comboxOutlineType.Size = new System.Drawing.Size(115, 20);
            this.comboxOutlineType.TabIndex = 41;
            this.comboxOutlineType.Text = "Solid";
            this.comboxOutlineType.SelectedIndexChanged += new System.EventHandler(this.comboxOutlineType_SelectedIndexChanged);
            // 
            // labelOutlineWidth
            // 
            this.labelOutlineWidth.AutoSize = true;
            this.labelOutlineWidth.Location = new System.Drawing.Point(10, 80);
            this.labelOutlineWidth.Name = "labelOutlineWidth";
            this.labelOutlineWidth.Size = new System.Drawing.Size(65, 12);
            this.labelOutlineWidth.TabIndex = 40;
            this.labelOutlineWidth.Text = "轮廓线宽：";
            // 
            // tboxOutlineWidth
            // 
            this.tboxOutlineWidth.Location = new System.Drawing.Point(77, 77);
            this.tboxOutlineWidth.Name = "tboxOutlineWidth";
            this.tboxOutlineWidth.Size = new System.Drawing.Size(115, 21);
            this.tboxOutlineWidth.TabIndex = 39;
            this.tboxOutlineWidth.TextChanged += new System.EventHandler(this.tboxOutlineWidth_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 65;
            this.label7.Text = "箭头尾部长：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 67;
            this.label8.Text = "箭头尾部宽：";
            // 
            // tboxBodyWidth
            // 
            this.tboxBodyWidth.Location = new System.Drawing.Point(115, 118);
            this.tboxBodyWidth.Name = "tboxBodyWidth";
            this.tboxBodyWidth.Size = new System.Drawing.Size(115, 21);
            this.tboxBodyWidth.TabIndex = 66;
            this.tboxBodyWidth.TextChanged += new System.EventHandler(this.tboxBodyWidth_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 71;
            this.label9.Text = "箭头头部宽：";
            // 
            // tboxHeadWidth
            // 
            this.tboxHeadWidth.Location = new System.Drawing.Point(115, 172);
            this.tboxHeadWidth.Name = "tboxHeadWidth";
            this.tboxHeadWidth.Size = new System.Drawing.Size(115, 21);
            this.tboxHeadWidth.TabIndex = 70;
            this.tboxHeadWidth.TextChanged += new System.EventHandler(this.tboxHeadWidth_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 69;
            this.label10.Text = "箭头头部长：";
            // 
            // tboxHeadLen
            // 
            this.tboxHeadLen.Location = new System.Drawing.Point(115, 145);
            this.tboxHeadLen.Name = "tboxHeadLen";
            this.tboxHeadLen.Size = new System.Drawing.Size(115, 21);
            this.tboxHeadLen.TabIndex = 68;
            this.tboxHeadLen.TextChanged += new System.EventHandler(this.tboxHeadLen_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 73;
            this.label11.Text = "箭头之间间隔：";
            // 
            // tboxArrowGap
            // 
            this.tboxArrowGap.Location = new System.Drawing.Point(115, 199);
            this.tboxArrowGap.Name = "tboxArrowGap";
            this.tboxArrowGap.Size = new System.Drawing.Size(115, 21);
            this.tboxArrowGap.TabIndex = 72;
            this.tboxArrowGap.TextChanged += new System.EventHandler(this.tboxArrowGap_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tboxArrowGap);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tboxHeadWidth);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tboxHeadLen);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tboxBodyWidth);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.grpOutlineStyle);
            this.groupBox1.Controls.Add(this.tboxBodyLen);
            this.groupBox1.Controls.Add(this.cboxNegDir);
            this.groupBox1.Controls.Add(this.cboxAlwaysSee);
            this.groupBox1.Controls.Add(this.cboxAlongCenter);
            this.groupBox1.Controls.Add(this.cboxPixelLen);
            this.groupBox1.Controls.Add(this.cbxOutlineVisible);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboxArrowShape);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.nudArrowOpaque);
            this.groupBox1.Controls.Add(this.pboxArrowColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 449);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(191, 469);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(61, 22);
            this.buttonCancel.TabIndex = 76;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(55, 469);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(61, 22);
            this.buttonOk.TabIndex = 75;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FrmArrowStyleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 499);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmArrowStyleSetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置箭头风格";
            this.Load += new System.EventHandler(this.FrmArrowStyleSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudArrowOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxArrowColor)).EndInit();
            this.grpOutlineStyle.ResumeLayout(false);
            this.grpOutlineStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxOutlineColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tboxBodyLen;
        private System.Windows.Forms.CheckBox cboxNegDir;
        private System.Windows.Forms.CheckBox cboxAlwaysSee;
        private System.Windows.Forms.CheckBox cboxAlongCenter;
        private System.Windows.Forms.CheckBox cboxPixelLen;
        private System.Windows.Forms.CheckBox cbxOutlineVisible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboxArrowShape;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudArrowOpaque;
        private System.Windows.Forms.PictureBox pboxArrowColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpOutlineStyle;
        private System.Windows.Forms.Label labelOutlineOpaque;
        private System.Windows.Forms.NumericUpDown nudOutlineOpaque;
        private System.Windows.Forms.PictureBox pboxOutlineColor;
        private System.Windows.Forms.Label labelOutlineColor;
        private System.Windows.Forms.Label labelOutlineType;
        private System.Windows.Forms.ComboBox comboxOutlineType;
        private System.Windows.Forms.Label labelOutlineWidth;
        private System.Windows.Forms.TextBox tboxOutlineWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tboxBodyWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxHeadWidth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tboxHeadLen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tboxArrowGap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}