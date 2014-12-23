namespace WorldGIS
{
    partial class FrmUpdateLayoutColor
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
            this.groupBoxStyle = new System.Windows.Forms.GroupBox();
            this.checkBoxLineStyle = new System.Windows.Forms.CheckBox();
            this.checkBoxPolygonStyle = new System.Windows.Forms.CheckBox();
            this.groupBoxPolygonStyle = new System.Windows.Forms.GroupBox();
            this.checkBoxPolygonFillStyle = new System.Windows.Forms.CheckBox();
            this.groupBoxPolygonFillStyle = new System.Windows.Forms.GroupBox();
            this.pictureBoxPolygonFillColor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numericPolygonFillOpaque = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxPolygonOutlineStyle = new System.Windows.Forms.GroupBox();
            this.pictureBoxPolygonOutlineColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxPolygonOutlineType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPolygonOutlineWidth = new System.Windows.Forms.TextBox();
            this.numericPolygonOutlineOpaque = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxOutline = new System.Windows.Forms.CheckBox();
            this.checkBoxPolygonOutlineStyle = new System.Windows.Forms.CheckBox();
            this.checkBoxFill = new System.Windows.Forms.CheckBox();
            this.groupBoxLineStyle = new System.Windows.Forms.GroupBox();
            this.pictureBoxLineColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLineType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLineWidth = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericLineOpaque = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.groupBoxStyle.SuspendLayout();
            this.groupBoxPolygonStyle.SuspendLayout();
            this.groupBoxPolygonFillStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPolygonFillOpaque)).BeginInit();
            this.groupBoxPolygonOutlineStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPolygonOutlineOpaque)).BeginInit();
            this.groupBoxLineStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLineOpaque)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStyle
            // 
            this.groupBoxStyle.Controls.Add(this.checkBoxLineStyle);
            this.groupBoxStyle.Controls.Add(this.checkBoxPolygonStyle);
            this.groupBoxStyle.Controls.Add(this.groupBoxPolygonStyle);
            this.groupBoxStyle.Controls.Add(this.groupBoxLineStyle);
            this.groupBoxStyle.Location = new System.Drawing.Point(12, 3);
            this.groupBoxStyle.Name = "groupBoxStyle";
            this.groupBoxStyle.Size = new System.Drawing.Size(468, 376);
            this.groupBoxStyle.TabIndex = 30;
            this.groupBoxStyle.TabStop = false;
            // 
            // checkBoxLineStyle
            // 
            this.checkBoxLineStyle.AutoSize = true;
            this.checkBoxLineStyle.Location = new System.Drawing.Point(12, 15);
            this.checkBoxLineStyle.Name = "checkBoxLineStyle";
            this.checkBoxLineStyle.Size = new System.Drawing.Size(96, 16);
            this.checkBoxLineStyle.TabIndex = 36;
            this.checkBoxLineStyle.Text = "自定义线风格";
            this.checkBoxLineStyle.UseVisualStyleBackColor = true;
            this.checkBoxLineStyle.CheckedChanged += new System.EventHandler(this.checkBoxLineStyle_CheckedChanged);
            // 
            // checkBoxPolygonStyle
            // 
            this.checkBoxPolygonStyle.AutoSize = true;
            this.checkBoxPolygonStyle.Location = new System.Drawing.Point(12, 140);
            this.checkBoxPolygonStyle.Name = "checkBoxPolygonStyle";
            this.checkBoxPolygonStyle.Size = new System.Drawing.Size(96, 16);
            this.checkBoxPolygonStyle.TabIndex = 37;
            this.checkBoxPolygonStyle.Text = "自定义面风格";
            this.checkBoxPolygonStyle.UseVisualStyleBackColor = true;
            this.checkBoxPolygonStyle.CheckedChanged += new System.EventHandler(this.checkBoxPolygonStyle_CheckedChanged);
            // 
            // groupBoxPolygonStyle
            // 
            this.groupBoxPolygonStyle.Controls.Add(this.checkBoxPolygonFillStyle);
            this.groupBoxPolygonStyle.Controls.Add(this.groupBoxPolygonFillStyle);
            this.groupBoxPolygonStyle.Controls.Add(this.groupBoxPolygonOutlineStyle);
            this.groupBoxPolygonStyle.Controls.Add(this.checkBoxOutline);
            this.groupBoxPolygonStyle.Controls.Add(this.checkBoxPolygonOutlineStyle);
            this.groupBoxPolygonStyle.Controls.Add(this.checkBoxFill);
            this.groupBoxPolygonStyle.Location = new System.Drawing.Point(12, 161);
            this.groupBoxPolygonStyle.Name = "groupBoxPolygonStyle";
            this.groupBoxPolygonStyle.Size = new System.Drawing.Size(441, 202);
            this.groupBoxPolygonStyle.TabIndex = 32;
            this.groupBoxPolygonStyle.TabStop = false;
            this.groupBoxPolygonStyle.Text = "面";
            // 
            // checkBoxPolygonFillStyle
            // 
            this.checkBoxPolygonFillStyle.AutoSize = true;
            this.checkBoxPolygonFillStyle.Location = new System.Drawing.Point(93, 19);
            this.checkBoxPolygonFillStyle.Name = "checkBoxPolygonFillStyle";
            this.checkBoxPolygonFillStyle.Size = new System.Drawing.Size(120, 16);
            this.checkBoxPolygonFillStyle.TabIndex = 36;
            this.checkBoxPolygonFillStyle.Text = "自定义面填充风格";
            this.checkBoxPolygonFillStyle.UseVisualStyleBackColor = true;
            this.checkBoxPolygonFillStyle.CheckedChanged += new System.EventHandler(this.checkBoxPolygonFillStyle_CheckedChanged);
            // 
            // groupBoxPolygonFillStyle
            // 
            this.groupBoxPolygonFillStyle.Controls.Add(this.pictureBoxPolygonFillColor);
            this.groupBoxPolygonFillStyle.Controls.Add(this.label8);
            this.groupBoxPolygonFillStyle.Controls.Add(this.numericPolygonFillOpaque);
            this.groupBoxPolygonFillStyle.Controls.Add(this.label9);
            this.groupBoxPolygonFillStyle.Location = new System.Drawing.Point(12, 33);
            this.groupBoxPolygonFillStyle.Name = "groupBoxPolygonFillStyle";
            this.groupBoxPolygonFillStyle.Size = new System.Drawing.Size(200, 158);
            this.groupBoxPolygonFillStyle.TabIndex = 35;
            this.groupBoxPolygonFillStyle.TabStop = false;
            this.groupBoxPolygonFillStyle.Text = "填充风格";
            // 
            // pictureBoxPolygonFillColor
            // 
            this.pictureBoxPolygonFillColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBoxPolygonFillColor.Location = new System.Drawing.Point(78, 29);
            this.pictureBoxPolygonFillColor.Name = "pictureBoxPolygonFillColor";
            this.pictureBoxPolygonFillColor.Size = new System.Drawing.Size(115, 23);
            this.pictureBoxPolygonFillColor.TabIndex = 50;
            this.pictureBoxPolygonFillColor.Text = "单击设置颜色";
            this.pictureBoxPolygonFillColor.UseVisualStyleBackColor = false;
            this.pictureBoxPolygonFillColor.Click += new System.EventHandler(this.pictureBoxPolygonFillColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "不透明度：";
            // 
            // numericPolygonFillOpaque
            // 
            this.numericPolygonFillOpaque.Location = new System.Drawing.Point(79, 90);
            this.numericPolygonFillOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericPolygonFillOpaque.Name = "numericPolygonFillOpaque";
            this.numericPolygonFillOpaque.Size = new System.Drawing.Size(115, 21);
            this.numericPolygonFillOpaque.TabIndex = 16;
            this.numericPolygonFillOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "填充颜色：";
            // 
            // groupBoxPolygonOutlineStyle
            // 
            this.groupBoxPolygonOutlineStyle.Controls.Add(this.pictureBoxPolygonOutlineColor);
            this.groupBoxPolygonOutlineStyle.Controls.Add(this.label6);
            this.groupBoxPolygonOutlineStyle.Controls.Add(this.label10);
            this.groupBoxPolygonOutlineStyle.Controls.Add(this.comboBoxPolygonOutlineType);
            this.groupBoxPolygonOutlineStyle.Controls.Add(this.label7);
            this.groupBoxPolygonOutlineStyle.Controls.Add(this.textBoxPolygonOutlineWidth);
            this.groupBoxPolygonOutlineStyle.Controls.Add(this.numericPolygonOutlineOpaque);
            this.groupBoxPolygonOutlineStyle.Controls.Add(this.label11);
            this.groupBoxPolygonOutlineStyle.Location = new System.Drawing.Point(219, 33);
            this.groupBoxPolygonOutlineStyle.Name = "groupBoxPolygonOutlineStyle";
            this.groupBoxPolygonOutlineStyle.Size = new System.Drawing.Size(212, 158);
            this.groupBoxPolygonOutlineStyle.TabIndex = 34;
            this.groupBoxPolygonOutlineStyle.TabStop = false;
            this.groupBoxPolygonOutlineStyle.Text = "轮廓线风格";
            // 
            // pictureBoxPolygonOutlineColor
            // 
            this.pictureBoxPolygonOutlineColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBoxPolygonOutlineColor.Location = new System.Drawing.Point(89, 23);
            this.pictureBoxPolygonOutlineColor.Name = "pictureBoxPolygonOutlineColor";
            this.pictureBoxPolygonOutlineColor.Size = new System.Drawing.Size(115, 23);
            this.pictureBoxPolygonOutlineColor.TabIndex = 51;
            this.pictureBoxPolygonOutlineColor.Text = "单击设置颜色";
            this.pictureBoxPolygonOutlineColor.UseVisualStyleBackColor = false;
            this.pictureBoxPolygonOutlineColor.Click += new System.EventHandler(this.pictureBoxPolygonOutlineColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "轮廓线样式：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 48;
            this.label10.Text = "不透明度：";
            // 
            // comboBoxPolygonOutlineType
            // 
            this.comboBoxPolygonOutlineType.FormattingEnabled = true;
            this.comboBoxPolygonOutlineType.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.comboBoxPolygonOutlineType.Location = new System.Drawing.Point(89, 121);
            this.comboBoxPolygonOutlineType.Name = "comboBoxPolygonOutlineType";
            this.comboBoxPolygonOutlineType.Size = new System.Drawing.Size(115, 20);
            this.comboBoxPolygonOutlineType.TabIndex = 43;
            this.comboBoxPolygonOutlineType.Text = "Solid";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "轮廓线宽：";
            // 
            // textBoxPolygonOutlineWidth
            // 
            this.textBoxPolygonOutlineWidth.Location = new System.Drawing.Point(89, 90);
            this.textBoxPolygonOutlineWidth.Name = "textBoxPolygonOutlineWidth";
            this.textBoxPolygonOutlineWidth.Size = new System.Drawing.Size(115, 21);
            this.textBoxPolygonOutlineWidth.TabIndex = 41;
            this.textBoxPolygonOutlineWidth.TextChanged += new System.EventHandler(this.textBoxPolygonOutlineWidth_TextChanged);
            // 
            // numericPolygonOutlineOpaque
            // 
            this.numericPolygonOutlineOpaque.Location = new System.Drawing.Point(89, 58);
            this.numericPolygonOutlineOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericPolygonOutlineOpaque.Name = "numericPolygonOutlineOpaque";
            this.numericPolygonOutlineOpaque.Size = new System.Drawing.Size(115, 21);
            this.numericPolygonOutlineOpaque.TabIndex = 47;
            this.numericPolygonOutlineOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "轮廓线颜色：";
            // 
            // checkBoxOutline
            // 
            this.checkBoxOutline.AutoSize = true;
            this.checkBoxOutline.Location = new System.Drawing.Point(100, 230);
            this.checkBoxOutline.Name = "checkBoxOutline";
            this.checkBoxOutline.Size = new System.Drawing.Size(108, 16);
            this.checkBoxOutline.TabIndex = 33;
            this.checkBoxOutline.Text = "是否显示轮廓线";
            this.checkBoxOutline.UseVisualStyleBackColor = true;
            // 
            // checkBoxPolygonOutlineStyle
            // 
            this.checkBoxPolygonOutlineStyle.AutoSize = true;
            this.checkBoxPolygonOutlineStyle.Location = new System.Drawing.Point(303, 19);
            this.checkBoxPolygonOutlineStyle.Name = "checkBoxPolygonOutlineStyle";
            this.checkBoxPolygonOutlineStyle.Size = new System.Drawing.Size(132, 16);
            this.checkBoxPolygonOutlineStyle.TabIndex = 32;
            this.checkBoxPolygonOutlineStyle.Text = "自定义面轮廓线风格";
            this.checkBoxPolygonOutlineStyle.UseVisualStyleBackColor = true;
            this.checkBoxPolygonOutlineStyle.CheckedChanged += new System.EventHandler(this.checkBoxPolygonOutlineStyle_CheckedChanged);
            // 
            // checkBoxFill
            // 
            this.checkBoxFill.AutoSize = true;
            this.checkBoxFill.Location = new System.Drawing.Point(6, 230);
            this.checkBoxFill.Name = "checkBoxFill";
            this.checkBoxFill.Size = new System.Drawing.Size(72, 16);
            this.checkBoxFill.TabIndex = 32;
            this.checkBoxFill.Text = "是否填充";
            this.checkBoxFill.UseVisualStyleBackColor = true;
            // 
            // groupBoxLineStyle
            // 
            this.groupBoxLineStyle.Controls.Add(this.pictureBoxLineColor);
            this.groupBoxLineStyle.Controls.Add(this.label3);
            this.groupBoxLineStyle.Controls.Add(this.comboBoxLineType);
            this.groupBoxLineStyle.Controls.Add(this.label4);
            this.groupBoxLineStyle.Controls.Add(this.textBoxLineWidth);
            this.groupBoxLineStyle.Controls.Add(this.label20);
            this.groupBoxLineStyle.Controls.Add(this.numericLineOpaque);
            this.groupBoxLineStyle.Controls.Add(this.label2);
            this.groupBoxLineStyle.Location = new System.Drawing.Point(12, 34);
            this.groupBoxLineStyle.Name = "groupBoxLineStyle";
            this.groupBoxLineStyle.Size = new System.Drawing.Size(441, 97);
            this.groupBoxLineStyle.TabIndex = 31;
            this.groupBoxLineStyle.TabStop = false;
            this.groupBoxLineStyle.Text = "线";
            // 
            // pictureBoxLineColor
            // 
            this.pictureBoxLineColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBoxLineColor.Location = new System.Drawing.Point(90, 25);
            this.pictureBoxLineColor.Name = "pictureBoxLineColor";
            this.pictureBoxLineColor.Size = new System.Drawing.Size(115, 23);
            this.pictureBoxLineColor.TabIndex = 49;
            this.pictureBoxLineColor.Text = "单击设置颜色";
            this.pictureBoxLineColor.UseVisualStyleBackColor = false;
            this.pictureBoxLineColor.Click += new System.EventHandler(this.pictureBoxLineColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 48;
            this.label3.Text = "样式：";
            // 
            // comboBoxLineType
            // 
            this.comboBoxLineType.FormattingEnabled = true;
            this.comboBoxLineType.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.comboBoxLineType.Location = new System.Drawing.Point(300, 58);
            this.comboBoxLineType.Name = "comboBoxLineType";
            this.comboBoxLineType.Size = new System.Drawing.Size(115, 20);
            this.comboBoxLineType.TabIndex = 47;
            this.comboBoxLineType.Text = "Solid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "线宽：";
            // 
            // textBoxLineWidth
            // 
            this.textBoxLineWidth.Location = new System.Drawing.Point(300, 27);
            this.textBoxLineWidth.Name = "textBoxLineWidth";
            this.textBoxLineWidth.Size = new System.Drawing.Size(115, 21);
            this.textBoxLineWidth.TabIndex = 45;
            this.textBoxLineWidth.TextChanged += new System.EventHandler(this.textBoxLineWidth_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 36;
            this.label20.Text = "不透明度：";
            // 
            // numericLineOpaque
            // 
            this.numericLineOpaque.Location = new System.Drawing.Point(90, 57);
            this.numericLineOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericLineOpaque.Name = "numericLineOpaque";
            this.numericLineOpaque.Size = new System.Drawing.Size(115, 21);
            this.numericLineOpaque.TabIndex = 35;
            this.numericLineOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "颜色：";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(324, 387);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 34;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(405, 387);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(75, 23);
            this.buttonNo.TabIndex = 35;
            this.buttonNo.Text = "取消";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // FrmUpdateLayoutColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 422);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxStyle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmUpdateLayoutColor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改图层颜色";
            this.Load += new System.EventHandler(this.FrmUpdateLayoutColor_Load);
            this.groupBoxStyle.ResumeLayout(false);
            this.groupBoxStyle.PerformLayout();
            this.groupBoxPolygonStyle.ResumeLayout(false);
            this.groupBoxPolygonStyle.PerformLayout();
            this.groupBoxPolygonFillStyle.ResumeLayout(false);
            this.groupBoxPolygonFillStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPolygonFillOpaque)).EndInit();
            this.groupBoxPolygonOutlineStyle.ResumeLayout(false);
            this.groupBoxPolygonOutlineStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPolygonOutlineOpaque)).EndInit();
            this.groupBoxLineStyle.ResumeLayout(false);
            this.groupBoxLineStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLineOpaque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStyle;
        private System.Windows.Forms.GroupBox groupBoxPolygonStyle;
        private System.Windows.Forms.GroupBox groupBoxLineStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.CheckBox checkBoxLineStyle;
        private System.Windows.Forms.CheckBox checkBoxPolygonStyle;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericLineOpaque;
        private System.Windows.Forms.GroupBox groupBoxPolygonFillStyle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericPolygonFillOpaque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxPolygonOutlineStyle;
        private System.Windows.Forms.CheckBox checkBoxPolygonOutlineStyle;
        private System.Windows.Forms.CheckBox checkBoxOutline;
        private System.Windows.Forms.CheckBox checkBoxFill;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxPolygonOutlineType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPolygonOutlineWidth;
        private System.Windows.Forms.NumericUpDown numericPolygonOutlineOpaque;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxPolygonFillStyle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxLineType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLineWidth;
        private System.Windows.Forms.Button pictureBoxPolygonFillColor;
        private System.Windows.Forms.Button pictureBoxPolygonOutlineColor;
        private System.Windows.Forms.Button pictureBoxLineColor;
    }
}