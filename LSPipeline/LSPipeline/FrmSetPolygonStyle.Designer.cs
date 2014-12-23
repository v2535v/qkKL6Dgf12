namespace WorldGIS
{
    partial class FrmSetPolygonStyle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetPolygonStyle));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownFillOpaque = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxFillColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseOutlineStyle = new System.Windows.Forms.CheckBox();
            this.buttonSetLineStyle = new System.Windows.Forms.Button();
            this.checkBoxFill = new System.Windows.Forms.CheckBox();
            this.checkBoxOutline = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFillOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFillColor)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(209, 249);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(61, 22);
            this.buttonCancel.TabIndex = 40;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(73, 249);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(61, 22);
            this.buttonOk.TabIndex = 39;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkBoxFill);
            this.groupBox1.Controls.Add(this.checkBoxOutline);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 235);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.numericUpDownFillOpaque);
            this.groupBox5.Controls.Add(this.pictureBoxFillColor);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(20, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(272, 81);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "填充风格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "不透明度：";
            // 
            // numericUpDownFillOpaque
            // 
            this.numericUpDownFillOpaque.Location = new System.Drawing.Point(110, 44);
            this.numericUpDownFillOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownFillOpaque.Name = "numericUpDownFillOpaque";
            this.numericUpDownFillOpaque.Size = new System.Drawing.Size(122, 21);
            this.numericUpDownFillOpaque.TabIndex = 16;
            this.numericUpDownFillOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownFillOpaque.ValueChanged += new System.EventHandler(this.numericUpDownFillOpaque_ValueChanged);
            // 
            // pictureBoxFillColor
            // 
            this.pictureBoxFillColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFillColor.Location = new System.Drawing.Point(110, 22);
            this.pictureBoxFillColor.Name = "pictureBoxFillColor";
            this.pictureBoxFillColor.Size = new System.Drawing.Size(122, 18);
            this.pictureBoxFillColor.TabIndex = 8;
            this.pictureBoxFillColor.TabStop = false;
            this.pictureBoxFillColor.Click += new System.EventHandler(this.pictureBoxFillColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "填充颜色：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxUseOutlineStyle);
            this.groupBox2.Controls.Add(this.buttonSetLineStyle);
            this.groupBox2.Location = new System.Drawing.Point(20, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 78);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轮廓线风格";
            // 
            // checkBoxUseOutlineStyle
            // 
            this.checkBoxUseOutlineStyle.AutoSize = true;
            this.checkBoxUseOutlineStyle.Location = new System.Drawing.Point(124, 0);
            this.checkBoxUseOutlineStyle.Name = "checkBoxUseOutlineStyle";
            this.checkBoxUseOutlineStyle.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseOutlineStyle.TabIndex = 32;
            this.checkBoxUseOutlineStyle.Text = "使用自定义风格";
            this.checkBoxUseOutlineStyle.UseVisualStyleBackColor = true;
            this.checkBoxUseOutlineStyle.CheckedChanged += new System.EventHandler(this.checkBoxUseOutlineStyle_CheckedChanged);
            // 
            // buttonSetLineStyle
            // 
            this.buttonSetLineStyle.Location = new System.Drawing.Point(41, 33);
            this.buttonSetLineStyle.Name = "buttonSetLineStyle";
            this.buttonSetLineStyle.Size = new System.Drawing.Size(191, 24);
            this.buttonSetLineStyle.TabIndex = 29;
            this.buttonSetLineStyle.Text = "定义线风格";
            this.buttonSetLineStyle.UseVisualStyleBackColor = true;
            this.buttonSetLineStyle.Click += new System.EventHandler(this.buttonSetLineStyle_Click);
            // 
            // checkBoxFill
            // 
            this.checkBoxFill.AutoSize = true;
            this.checkBoxFill.Location = new System.Drawing.Point(50, 203);
            this.checkBoxFill.Name = "checkBoxFill";
            this.checkBoxFill.Size = new System.Drawing.Size(72, 16);
            this.checkBoxFill.TabIndex = 42;
            this.checkBoxFill.Text = "是否填充";
            this.checkBoxFill.UseVisualStyleBackColor = true;
            this.checkBoxFill.CheckedChanged += new System.EventHandler(this.checkBoxFill_CheckedChanged);
            // 
            // checkBoxOutline
            // 
            this.checkBoxOutline.AutoSize = true;
            this.checkBoxOutline.Location = new System.Drawing.Point(160, 203);
            this.checkBoxOutline.Name = "checkBoxOutline";
            this.checkBoxOutline.Size = new System.Drawing.Size(108, 16);
            this.checkBoxOutline.TabIndex = 43;
            this.checkBoxOutline.Text = "是否显示轮廓线";
            this.checkBoxOutline.UseVisualStyleBackColor = true;
            this.checkBoxOutline.CheckedChanged += new System.EventHandler(this.checkBoxOutline_CheckedChanged);
            // 
            // FrmPolygonStyleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 280);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPolygonStyleSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "面风格";
            this.Load += new System.EventHandler(this.FrmPolygonStyleSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFillOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFillColor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownFillOpaque;
        private System.Windows.Forms.PictureBox pictureBoxFillColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxUseOutlineStyle;
        private System.Windows.Forms.Button buttonSetLineStyle;
        private System.Windows.Forms.CheckBox checkBoxFill;
        private System.Windows.Forms.CheckBox checkBoxOutline;
    }
}