namespace WorldGIS
{
    partial class CtrlExtentSectionlineStyleSetting
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCornerSliceAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxThickness = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLineRadius = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownLineOpaque = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxLineColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLineColor)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 73;
            this.label5.Text = "度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "拐弯平滑度：";
            // 
            // textBoxCornerSliceAngle
            // 
            this.textBoxCornerSliceAngle.Location = new System.Drawing.Point(105, 110);
            this.textBoxCornerSliceAngle.Name = "textBoxCornerSliceAngle";
            this.textBoxCornerSliceAngle.Size = new System.Drawing.Size(138, 21);
            this.textBoxCornerSliceAngle.TabIndex = 69;
            this.textBoxCornerSliceAngle.TextChanged += new System.EventHandler(this.textBoxCornerSliceAngle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "沟高：";
            // 
            // textBoxThickness
            // 
            this.textBoxThickness.Location = new System.Drawing.Point(105, 85);
            this.textBoxThickness.Name = "textBoxThickness";
            this.textBoxThickness.Size = new System.Drawing.Size(138, 21);
            this.textBoxThickness.TabIndex = 67;
            this.textBoxThickness.TextChanged += new System.EventHandler(this.textBoxThickness_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 66;
            this.label3.Text = "沟宽：";
            // 
            // textBoxLineRadius
            // 
            this.textBoxLineRadius.Location = new System.Drawing.Point(105, 60);
            this.textBoxLineRadius.Name = "textBoxLineRadius";
            this.textBoxLineRadius.Size = new System.Drawing.Size(138, 21);
            this.textBoxLineRadius.TabIndex = 65;
            this.textBoxLineRadius.TextChanged += new System.EventHandler(this.textBoxLineRadius_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 64;
            this.label20.Text = "不透明度：";
            // 
            // numericUpDownLineOpaque
            // 
            this.numericUpDownLineOpaque.Location = new System.Drawing.Point(105, 34);
            this.numericUpDownLineOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownLineOpaque.Name = "numericUpDownLineOpaque";
            this.numericUpDownLineOpaque.Size = new System.Drawing.Size(138, 21);
            this.numericUpDownLineOpaque.TabIndex = 63;
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
            this.pictureBoxLineColor.Location = new System.Drawing.Point(105, 11);
            this.pictureBoxLineColor.Name = "pictureBoxLineColor";
            this.pictureBoxLineColor.Size = new System.Drawing.Size(138, 18);
            this.pictureBoxLineColor.TabIndex = 62;
            this.pictureBoxLineColor.TabStop = false;
            this.pictureBoxLineColor.Click += new System.EventHandler(this.pictureBoxLineColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 61;
            this.label2.Text = "颜色：";
            // 
            // CtrlExtentSectionlineStyleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCornerSliceAngle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxThickness);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLineRadius);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.numericUpDownLineOpaque);
            this.Controls.Add(this.pictureBoxLineColor);
            this.Controls.Add(this.label2);
            this.Name = "CtrlExtentSectionlineStyleSetting";
            this.Size = new System.Drawing.Size(286, 144);
            this.Load += new System.EventHandler(this.FormPipelineStyleSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLineColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCornerSliceAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxThickness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLineRadius;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownLineOpaque;
        private System.Windows.Forms.PictureBox pictureBoxLineColor;
        private System.Windows.Forms.Label label2;

    }
}