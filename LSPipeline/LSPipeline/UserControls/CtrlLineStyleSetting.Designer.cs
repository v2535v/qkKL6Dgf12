namespace WorldGIS
{
    partial class CtrlLineStyleSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLineType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLineWidth = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownLineOpaque = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxLineColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLineColor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "样式：";
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
            this.comboBoxLineType.Location = new System.Drawing.Point(139, 108);
            this.comboBoxLineType.Name = "comboBoxLineType";
            this.comboBoxLineType.Size = new System.Drawing.Size(95, 20);
            this.comboBoxLineType.TabIndex = 41;
            this.comboBoxLineType.Text = "Solid";
            this.comboBoxLineType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLineType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "线宽：";
            // 
            // textBoxLineWidth
            // 
            this.textBoxLineWidth.Location = new System.Drawing.Point(139, 76);
            this.textBoxLineWidth.Name = "textBoxLineWidth";
            this.textBoxLineWidth.Size = new System.Drawing.Size(95, 21);
            this.textBoxLineWidth.TabIndex = 39;
            this.textBoxLineWidth.TextChanged += new System.EventHandler(this.textBoxLineWidth_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(53, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 38;
            this.label20.Text = "不透明度：";
            // 
            // numericUpDownLineOpaque
            // 
            this.numericUpDownLineOpaque.Location = new System.Drawing.Point(139, 46);
            this.numericUpDownLineOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownLineOpaque.Name = "numericUpDownLineOpaque";
            this.numericUpDownLineOpaque.Size = new System.Drawing.Size(95, 21);
            this.numericUpDownLineOpaque.TabIndex = 37;
            this.numericUpDownLineOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownLineOpaque.ValueChanged += new System.EventHandler(this.numericUpDownLineOpaque_ValueChanged);
            // 
            // pictureBoxLineColor
            // 
            this.pictureBoxLineColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxLineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLineColor.Location = new System.Drawing.Point(139, 17);
            this.pictureBoxLineColor.Name = "pictureBoxLineColor";
            this.pictureBoxLineColor.Size = new System.Drawing.Size(95, 18);
            this.pictureBoxLineColor.TabIndex = 36;
            this.pictureBoxLineColor.TabStop = false;
            this.pictureBoxLineColor.Click += new System.EventHandler(this.pictureBoxLineColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "颜色：";
            // 
            // CtrlLineStyleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLineType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLineWidth);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.numericUpDownLineOpaque);
            this.Controls.Add(this.pictureBoxLineColor);
            this.Controls.Add(this.label2);
            this.Name = "CtrlLineStyleSetting";
            this.Size = new System.Drawing.Size(286, 144);
            this.Load += new System.EventHandler(this.FrmLineStyleSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLineColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLineType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLineWidth;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownLineOpaque;
        private System.Windows.Forms.PictureBox pictureBoxLineColor;
        private System.Windows.Forms.Label label2;


    }
}