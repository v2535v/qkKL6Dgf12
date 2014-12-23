namespace WorldGIS
{
    partial class CtrlPoint3DSpaceInfo
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
            this.labelLat = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            this.labelLon = new System.Windows.Forms.Label();
            this.textBoxAlt = new System.Windows.Forms.TextBox();
            this.comboBoxAltMode = new System.Windows.Forms.ComboBox();
            this.textBoxLon = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLat
            // 
            this.labelLat.AutoSize = true;
            this.labelLat.Location = new System.Drawing.Point(22, 81);
            this.labelLat.Name = "labelLat";
            this.labelLat.Size = new System.Drawing.Size(41, 12);
            this.labelLat.TabIndex = 38;
            this.labelLat.Text = "纬度：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 166);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 42;
            this.label19.Text = "高度模式：";
            // 
            // textBoxLat
            // 
            this.textBoxLat.Location = new System.Drawing.Point(92, 78);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(166, 21);
            this.textBoxLat.TabIndex = 37;
            this.textBoxLat.TextChanged += new System.EventHandler(this.textBoxLat_TextChanged);
            // 
            // labelLon
            // 
            this.labelLon.AutoSize = true;
            this.labelLon.Location = new System.Drawing.Point(22, 41);
            this.labelLon.Name = "labelLon";
            this.labelLon.Size = new System.Drawing.Size(41, 12);
            this.labelLon.TabIndex = 36;
            this.labelLon.Text = "经度：";
            // 
            // textBoxAlt
            // 
            this.textBoxAlt.Location = new System.Drawing.Point(92, 119);
            this.textBoxAlt.Name = "textBoxAlt";
            this.textBoxAlt.Size = new System.Drawing.Size(166, 21);
            this.textBoxAlt.TabIndex = 41;
            this.textBoxAlt.TextChanged += new System.EventHandler(this.textBoxAlt_TextChanged);
            // 
            // comboBoxAltMode
            // 
            this.comboBoxAltMode.FormattingEnabled = true;
            this.comboBoxAltMode.Items.AddRange(new object[] {
            "海拔高度",
            "紧贴地表",
            "相对地表"});
            this.comboBoxAltMode.Location = new System.Drawing.Point(91, 162);
            this.comboBoxAltMode.Name = "comboBoxAltMode";
            this.comboBoxAltMode.Size = new System.Drawing.Size(167, 20);
            this.comboBoxAltMode.TabIndex = 40;
            this.comboBoxAltMode.Text = "紧贴地表";
            this.comboBoxAltMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxAltMode_SelectedIndexChanged);
            // 
            // textBoxLon
            // 
            this.textBoxLon.Location = new System.Drawing.Point(91, 38);
            this.textBoxLon.Name = "textBoxLon";
            this.textBoxLon.Size = new System.Drawing.Size(167, 21);
            this.textBoxLon.TabIndex = 35;
            this.textBoxLon.TextChanged += new System.EventHandler(this.textBoxLon_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 122);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 39;
            this.label18.Text = "高度：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelLat);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.textBoxLat);
            this.groupBox1.Controls.Add(this.labelLon);
            this.groupBox1.Controls.Add(this.textBoxAlt);
            this.groupBox1.Controls.Add(this.comboBoxAltMode);
            this.groupBox1.Controls.Add(this.textBoxLon);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(26, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 216);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // CtrlPoint3DSpaceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Name = "CtrlPoint3DSpaceInfo";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlPoint3DSpaceInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelLat;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxLat;
        private System.Windows.Forms.Label labelLon;
        private System.Windows.Forms.TextBox textBoxAlt;
        private System.Windows.Forms.ComboBox comboBoxAltMode;
        private System.Windows.Forms.TextBox textBoxLon;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
