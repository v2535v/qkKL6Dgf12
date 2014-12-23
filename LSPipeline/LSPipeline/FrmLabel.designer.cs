namespace WorldGIS
{
    partial class FrmLabel
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
            this.numMinDistance = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numMaxdistance = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.numTrackWidth = new System.Windows.Forms.NumericUpDown();
            this.numBorderWidth = new System.Windows.Forms.NumericUpDown();
            this.numOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numOffsetX = new System.Windows.Forms.NumericUpDown();
            this.numFontsize = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarOpaque = new System.Windows.Forms.TrackBar();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkHasTrackLine = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnApply = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelTo = new DevComponents.DotNetBar.LabelX();
            this.labelFrom = new DevComponents.DotNetBar.LabelX();
            this.labelBorderColor = new DevComponents.DotNetBar.LabelX();
            this.btnImagePath = new DevComponents.DotNetBar.ButtonX();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxdistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrackWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontsize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpaque)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numMinDistance
            // 
            this.numMinDistance.Location = new System.Drawing.Point(420, 35);
            this.numMinDistance.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numMinDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numMinDistance.Name = "numMinDistance";
            this.numMinDistance.Size = new System.Drawing.Size(120, 21);
            this.numMinDistance.TabIndex = 67;
            this.numMinDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(276, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 66;
            this.label14.Text = "最小可见距离：";
            // 
            // numMaxdistance
            // 
            this.numMaxdistance.Location = new System.Drawing.Point(420, 9);
            this.numMaxdistance.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numMaxdistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numMaxdistance.Name = "numMaxdistance";
            this.numMaxdistance.Size = new System.Drawing.Size(120, 21);
            this.numMaxdistance.TabIndex = 65;
            this.numMaxdistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(276, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 64;
            this.label13.Text = "最大可见距离：";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(280, 82);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(250, 21);
            this.txtImagePath.TabIndex = 62;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(278, 125);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(291, 187);
            this.txtInfo.TabIndex = 59;
            this.txtInfo.Text = "";
            // 
            // numTrackWidth
            // 
            this.numTrackWidth.Location = new System.Drawing.Point(111, 274);
            this.numTrackWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numTrackWidth.Name = "numTrackWidth";
            this.numTrackWidth.Size = new System.Drawing.Size(120, 21);
            this.numTrackWidth.TabIndex = 52;
            this.numTrackWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numBorderWidth
            // 
            this.numBorderWidth.Location = new System.Drawing.Point(111, 221);
            this.numBorderWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numBorderWidth.Name = "numBorderWidth";
            this.numBorderWidth.Size = new System.Drawing.Size(120, 21);
            this.numBorderWidth.TabIndex = 51;
            // 
            // numOffsetY
            // 
            this.numOffsetY.Location = new System.Drawing.Point(111, 194);
            this.numOffsetY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numOffsetY.Name = "numOffsetY";
            this.numOffsetY.Size = new System.Drawing.Size(120, 21);
            this.numOffsetY.TabIndex = 53;
            this.numOffsetY.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numOffsetX
            // 
            this.numOffsetX.Location = new System.Drawing.Point(111, 162);
            this.numOffsetX.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numOffsetX.Name = "numOffsetX";
            this.numOffsetX.Size = new System.Drawing.Size(120, 21);
            this.numOffsetX.TabIndex = 55;
            // 
            // numFontsize
            // 
            this.numFontsize.Location = new System.Drawing.Point(111, 128);
            this.numFontsize.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numFontsize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFontsize.Name = "numFontsize";
            this.numFontsize.Size = new System.Drawing.Size(120, 21);
            this.numFontsize.TabIndex = 54;
            this.numFontsize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "实线",
            "虚线"});
            this.comboBox1.Location = new System.Drawing.Point(111, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 44;
            this.label9.Text = "颜色渐变：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "引线宽度：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "边框颜色：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "边框粗细：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "标注Y方向偏移：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "标注X方向偏移：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "字体大小：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "引线类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "标注透明度：";
            // 
            // trackBarOpaque
            // 
            this.trackBarOpaque.Location = new System.Drawing.Point(111, 81);
            this.trackBarOpaque.Name = "trackBarOpaque";
            this.trackBarOpaque.Size = new System.Drawing.Size(117, 45);
            this.trackBarOpaque.TabIndex = 39;
            this.trackBarOpaque.Value = 7;
            // 
            // chkItalic
            // 
            this.chkItalic.AutoSize = true;
            this.chkItalic.Location = new System.Drawing.Point(138, 16);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(48, 16);
            this.chkItalic.TabIndex = 37;
            this.chkItalic.Text = "斜体";
            this.chkItalic.UseVisualStyleBackColor = true;
            // 
            // chkHasTrackLine
            // 
            this.chkHasTrackLine.AutoSize = true;
            this.chkHasTrackLine.Checked = true;
            this.chkHasTrackLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHasTrackLine.Location = new System.Drawing.Point(8, 16);
            this.chkHasTrackLine.Name = "chkHasTrackLine";
            this.chkHasTrackLine.Size = new System.Drawing.Size(72, 16);
            this.chkHasTrackLine.TabIndex = 38;
            this.chkHasTrackLine.Text = "显示引线";
            this.chkHasTrackLine.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.JPG,*.PNG,*.GIF|*.JPG;*.PNG;*.GIF|*.*|*.*";
            // 
            // btnApply
            // 
            this.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnApply.Location = new System.Drawing.Point(329, 319);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnApply.TabIndex = 39;
            this.btnApply.Text = "应用";
            this.btnApply.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(414, 319);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 40;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(498, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupBox1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupBox1.Controls.Add(this.labelTo);
            this.groupBox1.Controls.Add(this.labelFrom);
            this.groupBox1.Controls.Add(this.labelBorderColor);
            this.groupBox1.Controls.Add(this.btnImagePath);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.chkHasTrackLine);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.numMaxdistance);
            this.groupBox1.Controls.Add(this.numMinDistance);
            this.groupBox1.Controls.Add(this.chkItalic);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtImagePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBarOpaque);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numTrackWidth);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numFontsize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numOffsetX);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numBorderWidth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numOffsetY);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, -13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 364);
            // 
            // 
            // 
            this.groupBox1.Style.Class = "";
            // 
            // 
            // 
            this.groupBox1.StyleMouseDown.Class = "";
            // 
            // 
            // 
            this.groupBox1.StyleMouseOver.Class = "";
            this.groupBox1.TabIndex = 68;
            this.groupBox1.Text = "groupPanel1";
            // 
            // labelTo
            // 
            this.labelTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(208)))));
            // 
            // 
            // 
            this.labelTo.BackgroundStyle.Class = "";
            this.labelTo.Location = new System.Drawing.Point(184, 301);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(44, 23);
            this.labelTo.TabIndex = 74;
            this.labelTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // labelFrom
            // 
            this.labelFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelFrom.BackgroundStyle.Class = "";
            this.labelFrom.Location = new System.Drawing.Point(111, 301);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(44, 23);
            this.labelFrom.TabIndex = 74;
            this.labelFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // labelBorderColor
            // 
            this.labelBorderColor.BackColor = System.Drawing.Color.Orange;
            // 
            // 
            // 
            this.labelBorderColor.BackgroundStyle.Class = "";
            this.labelBorderColor.Location = new System.Drawing.Point(111, 247);
            this.labelBorderColor.Name = "labelBorderColor";
            this.labelBorderColor.Size = new System.Drawing.Size(44, 23);
            this.labelBorderColor.TabIndex = 74;
            this.labelBorderColor.Click += new System.EventHandler(this.btnBorderColor_Click);
            // 
            // btnImagePath
            // 
            this.btnImagePath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImagePath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImagePath.Location = new System.Drawing.Point(538, 82);
            this.btnImagePath.Name = "btnImagePath";
            this.btnImagePath.Size = new System.Drawing.Size(38, 23);
            this.btnImagePath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImagePath.TabIndex = 73;
            this.btnImagePath.Text = "...";
            this.btnImagePath.Click += new System.EventHandler(this.btnImagePath_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(278, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 69;
            this.label12.Text = "标注文本：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(276, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 68;
            this.label11.Text = "背景图片：";
            // 
            // FrmLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 363);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmLabel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息公告";
            this.Load += new System.EventHandler(this.FrmLabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMinDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxdistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrackWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontsize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpaque)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.NumericUpDown numTrackWidth;
        private System.Windows.Forms.NumericUpDown numBorderWidth;
        private System.Windows.Forms.NumericUpDown numOffsetY;
        private System.Windows.Forms.NumericUpDown numOffsetX;
        private System.Windows.Forms.NumericUpDown numFontsize;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarOpaque;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.CheckBox chkHasTrackLine;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown numMinDistance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numMaxdistance;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.ButtonX btnApply;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.ButtonX btnImagePath;
        private DevComponents.DotNetBar.LabelX labelBorderColor;
        private DevComponents.DotNetBar.LabelX labelTo;
        private DevComponents.DotNetBar.LabelX labelFrom;
    }
}