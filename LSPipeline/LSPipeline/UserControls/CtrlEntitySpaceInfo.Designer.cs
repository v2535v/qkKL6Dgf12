namespace WorldGIS
{
    partial class CtrlEntitySpaceInfo
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
            this.labelAlign = new System.Windows.Forms.Label();
            this.comboBoxAlign = new System.Windows.Forms.ComboBox();
            this.labelLat = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            this.labelLon = new System.Windows.Forms.Label();
            this.textBoxAlt = new System.Windows.Forms.TextBox();
            this.comboBoxAltMode = new System.Windows.Forms.ComboBox();
            this.textBoxLon = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numUpDownScaleX = new System.Windows.Forms.NumericUpDown();
            this.numUpDownScaleZ = new System.Windows.Forms.NumericUpDown();
            this.numUpDownScaleY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxRote = new System.Windows.Forms.GroupBox();
            this.numUpDownRotZ = new System.Windows.Forms.NumericUpDown();
            this.numUpDownRotY = new System.Windows.Forms.NumericUpDown();
            this.numUpDownRotX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RotX = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownScaleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownScaleY)).BeginInit();
            this.groupBoxRote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownRotZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownRotX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAlign
            // 
            this.labelAlign.AutoSize = true;
            this.labelAlign.Location = new System.Drawing.Point(23, 130);
            this.labelAlign.Name = "labelAlign";
            this.labelAlign.Size = new System.Drawing.Size(65, 12);
            this.labelAlign.TabIndex = 36;
            this.labelAlign.Text = "位置锚点：";
            // 
            // comboBoxAlign
            // 
            this.comboBoxAlign.FormattingEnabled = true;
            this.comboBoxAlign.Items.AddRange(new object[] {
            "底部中心",
            "中心",
            "顶部中心"});
            this.comboBoxAlign.Location = new System.Drawing.Point(92, 127);
            this.comboBoxAlign.Name = "comboBoxAlign";
            this.comboBoxAlign.Size = new System.Drawing.Size(197, 20);
            this.comboBoxAlign.TabIndex = 35;
            this.comboBoxAlign.Text = "底部中心";
            this.comboBoxAlign.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlign_SelectedIndexChanged);
            // 
            // labelLat
            // 
            this.labelLat.AutoSize = true;
            this.labelLat.Location = new System.Drawing.Point(23, 50);
            this.labelLat.Name = "labelLat";
            this.labelLat.Size = new System.Drawing.Size(41, 12);
            this.labelLat.TabIndex = 30;
            this.labelLat.Text = "纬度：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 105);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 34;
            this.label19.Text = "高度模式：";
            // 
            // textBoxLat
            // 
            this.textBoxLat.Location = new System.Drawing.Point(93, 47);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(196, 21);
            this.textBoxLat.TabIndex = 29;
            this.textBoxLat.TextChanged += new System.EventHandler(this.textBoxLat_TextChanged);
            // 
            // labelLon
            // 
            this.labelLon.AutoSize = true;
            this.labelLon.Location = new System.Drawing.Point(23, 23);
            this.labelLon.Name = "labelLon";
            this.labelLon.Size = new System.Drawing.Size(41, 12);
            this.labelLon.TabIndex = 28;
            this.labelLon.Text = "经度：";
            // 
            // textBoxAlt
            // 
            this.textBoxAlt.Location = new System.Drawing.Point(93, 74);
            this.textBoxAlt.Name = "textBoxAlt";
            this.textBoxAlt.Size = new System.Drawing.Size(196, 21);
            this.textBoxAlt.TabIndex = 33;
            this.textBoxAlt.TextChanged += new System.EventHandler(this.textBoxAlt_TextChanged);
            // 
            // comboBoxAltMode
            // 
            this.comboBoxAltMode.FormattingEnabled = true;
            this.comboBoxAltMode.Items.AddRange(new object[] {
            "海拔高度",
            "紧贴地表",
            "相对地表"});
            this.comboBoxAltMode.Location = new System.Drawing.Point(92, 101);
            this.comboBoxAltMode.Name = "comboBoxAltMode";
            this.comboBoxAltMode.Size = new System.Drawing.Size(197, 20);
            this.comboBoxAltMode.TabIndex = 32;
            this.comboBoxAltMode.Text = "紧贴地表";
            this.comboBoxAltMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxAltMode_SelectedIndexChanged);
            // 
            // textBoxLon
            // 
            this.textBoxLon.Location = new System.Drawing.Point(92, 20);
            this.textBoxLon.Name = "textBoxLon";
            this.textBoxLon.Size = new System.Drawing.Size(197, 21);
            this.textBoxLon.TabIndex = 27;
            this.textBoxLon.TextChanged += new System.EventHandler(this.textBoxLon_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "高度：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numUpDownScaleX);
            this.groupBox1.Controls.Add(this.numUpDownScaleZ);
            this.groupBox1.Controls.Add(this.numUpDownScaleY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(13, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 65);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "缩放";
            // 
            // numUpDownScaleX
            // 
            this.numUpDownScaleX.DecimalPlaces = 1;
            this.numUpDownScaleX.Location = new System.Drawing.Point(51, 25);
            this.numUpDownScaleX.Name = "numUpDownScaleX";
            this.numUpDownScaleX.Size = new System.Drawing.Size(56, 21);
            this.numUpDownScaleX.TabIndex = 6;
            this.numUpDownScaleX.Value = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this.numUpDownScaleX.ValueChanged += new System.EventHandler(this.numUpDownScaleX_ValueChanged);
            // 
            // numUpDownScaleZ
            // 
            this.numUpDownScaleZ.DecimalPlaces = 1;
            this.numUpDownScaleZ.Location = new System.Drawing.Point(231, 25);
            this.numUpDownScaleZ.Name = "numUpDownScaleZ";
            this.numUpDownScaleZ.Size = new System.Drawing.Size(56, 21);
            this.numUpDownScaleZ.TabIndex = 8;
            this.numUpDownScaleZ.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numUpDownScaleZ.ValueChanged += new System.EventHandler(this.numUpDownScaleZ_ValueChanged);
            // 
            // numUpDownScaleY
            // 
            this.numUpDownScaleY.DecimalPlaces = 1;
            this.numUpDownScaleY.Location = new System.Drawing.Point(140, 25);
            this.numUpDownScaleY.Name = "numUpDownScaleY";
            this.numUpDownScaleY.Size = new System.Drawing.Size(56, 21);
            this.numUpDownScaleY.TabIndex = 7;
            this.numUpDownScaleY.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numUpDownScaleY.ValueChanged += new System.EventHandler(this.numUpDownScaleY_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Z:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "X:";
            // 
            // groupBoxRote
            // 
            this.groupBoxRote.Controls.Add(this.numUpDownRotZ);
            this.groupBoxRote.Controls.Add(this.numUpDownRotY);
            this.groupBoxRote.Controls.Add(this.numUpDownRotX);
            this.groupBoxRote.Controls.Add(this.label3);
            this.groupBoxRote.Controls.Add(this.label1);
            this.groupBoxRote.Controls.Add(this.RotX);
            this.groupBoxRote.Location = new System.Drawing.Point(13, 179);
            this.groupBoxRote.Name = "groupBoxRote";
            this.groupBoxRote.Size = new System.Drawing.Size(307, 65);
            this.groupBoxRote.TabIndex = 37;
            this.groupBoxRote.TabStop = false;
            this.groupBoxRote.Text = "旋转";
            // 
            // numUpDownRotZ
            // 
            this.numUpDownRotZ.DecimalPlaces = 2;
            this.numUpDownRotZ.Location = new System.Drawing.Point(231, 27);
            this.numUpDownRotZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numUpDownRotZ.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numUpDownRotZ.Name = "numUpDownRotZ";
            this.numUpDownRotZ.Size = new System.Drawing.Size(56, 21);
            this.numUpDownRotZ.TabIndex = 8;
            this.numUpDownRotZ.ValueChanged += new System.EventHandler(this.numUpDownRotZ_ValueChanged);
            // 
            // numUpDownRotY
            // 
            this.numUpDownRotY.DecimalPlaces = 2;
            this.numUpDownRotY.Location = new System.Drawing.Point(140, 27);
            this.numUpDownRotY.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numUpDownRotY.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numUpDownRotY.Name = "numUpDownRotY";
            this.numUpDownRotY.Size = new System.Drawing.Size(56, 21);
            this.numUpDownRotY.TabIndex = 7;
            this.numUpDownRotY.ValueChanged += new System.EventHandler(this.numUpDownRotY_ValueChanged);
            // 
            // numUpDownRotX
            // 
            this.numUpDownRotX.DecimalPlaces = 2;
            this.numUpDownRotX.Location = new System.Drawing.Point(51, 27);
            this.numUpDownRotX.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numUpDownRotX.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numUpDownRotX.Name = "numUpDownRotX";
            this.numUpDownRotX.Size = new System.Drawing.Size(56, 21);
            this.numUpDownRotX.TabIndex = 6;
            this.numUpDownRotX.ValueChanged += new System.EventHandler(this.numUpDownRotX_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Z:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Y:";
            // 
            // RotX
            // 
            this.RotX.AutoSize = true;
            this.RotX.Location = new System.Drawing.Point(23, 29);
            this.RotX.Name = "RotX";
            this.RotX.Size = new System.Drawing.Size(17, 12);
            this.RotX.TabIndex = 0;
            this.RotX.Text = "X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxAlign);
            this.groupBox2.Controls.Add(this.labelLat);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.labelAlign);
            this.groupBox2.Controls.Add(this.textBoxLat);
            this.groupBox2.Controls.Add(this.labelLon);
            this.groupBox2.Controls.Add(this.textBoxAlt);
            this.groupBox2.Controls.Add(this.comboBoxAltMode);
            this.groupBox2.Controls.Add(this.textBoxLon);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 161);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "位置";
            // 
            // CtrlEntitySpaceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxRote);
            this.Controls.Add(this.groupBox2);
            this.Name = "CtrlEntitySpaceInfo";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlEntitySpaceInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownScaleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownScaleY)).EndInit();
            this.groupBoxRote.ResumeLayout(false);
            this.groupBoxRote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownRotZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownRotX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAlign;
        private System.Windows.Forms.ComboBox comboBoxAlign;
        private System.Windows.Forms.Label labelLat;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxLat;
        private System.Windows.Forms.Label labelLon;
        private System.Windows.Forms.TextBox textBoxAlt;
        private System.Windows.Forms.ComboBox comboBoxAltMode;
        private System.Windows.Forms.TextBox textBoxLon;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxRote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RotX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numUpDownRotZ;
        private System.Windows.Forms.NumericUpDown numUpDownRotY;
        private System.Windows.Forms.NumericUpDown numUpDownRotX;
        private System.Windows.Forms.NumericUpDown numUpDownScaleX;
        private System.Windows.Forms.NumericUpDown numUpDownScaleZ;
        private System.Windows.Forms.NumericUpDown numUpDownScaleY;
    }
}
