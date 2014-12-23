namespace WorldGIS
{
    partial class FrmSetSceneLight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetSceneLight));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pbAmbient = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbDiffuse = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pbSpecular = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.tbPosX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPosY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPosZ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbGlobalAmbient = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbModelUseLighting = new System.Windows.Forms.CheckBox();
            this.cbTerrainUseLighting = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAmbient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiffuse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpecular)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGlobalAmbient)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(234, 318);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(60, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(328, 318);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(57, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // cbMode
            // 
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "默认光照",
            "物体模式",
            "眼模式",
            "场景模式",
            "日照模式"});
            this.cbMode.Location = new System.Drawing.Point(85, 54);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(97, 20);
            this.cbMode.TabIndex = 3;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "光照模式：";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "平行光",
            "点光源",
            "聚光灯"});
            this.cbType.Location = new System.Drawing.Point(85, 80);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(97, 20);
            this.cbType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "光源类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "环境光颜色：";
            // 
            // pbAmbient
            // 
            this.pbAmbient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAmbient.Location = new System.Drawing.Point(267, 29);
            this.pbAmbient.Name = "pbAmbient";
            this.pbAmbient.Size = new System.Drawing.Size(97, 18);
            this.pbAmbient.TabIndex = 8;
            this.pbAmbient.TabStop = false;
            this.pbAmbient.Click += new System.EventHandler(this.pbAmbient_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "反射光颜色：";
            // 
            // pbDiffuse
            // 
            this.pbDiffuse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDiffuse.Location = new System.Drawing.Point(267, 54);
            this.pbDiffuse.Name = "pbDiffuse";
            this.pbDiffuse.Size = new System.Drawing.Size(97, 18);
            this.pbDiffuse.TabIndex = 10;
            this.pbDiffuse.TabStop = false;
            this.pbDiffuse.Click += new System.EventHandler(this.pbDiffuse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "镜面光颜色：";
            // 
            // pbSpecular
            // 
            this.pbSpecular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSpecular.Location = new System.Drawing.Point(267, 80);
            this.pbSpecular.Name = "pbSpecular";
            this.pbSpecular.Size = new System.Drawing.Size(97, 18);
            this.pbSpecular.TabIndex = 12;
            this.pbSpecular.TabStop = false;
            this.pbSpecular.Click += new System.EventHandler(this.pbSpecular_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "光源状态：";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "打开",
            "关闭"});
            this.cbStatus.Location = new System.Drawing.Point(85, 28);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(97, 20);
            this.cbStatus.TabIndex = 13;
            // 
            // tbPosX
            // 
            this.tbPosX.Location = new System.Drawing.Point(155, 135);
            this.tbPosX.Name = "tbPosX";
            this.tbPosX.Size = new System.Drawing.Size(97, 21);
            this.tbPosX.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(130, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "X：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "Y：";
            // 
            // tbPosY
            // 
            this.tbPosY.Location = new System.Drawing.Point(155, 162);
            this.tbPosY.Name = "tbPosY";
            this.tbPosY.Size = new System.Drawing.Size(97, 21);
            this.tbPosY.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(130, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "Z：";
            // 
            // tbPosZ
            // 
            this.tbPosZ.Location = new System.Drawing.Point(155, 189);
            this.tbPosZ.Name = "tbPosZ";
            this.tbPosZ.Size = new System.Drawing.Size(97, 21);
            this.tbPosZ.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "光源位置：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbPosZ);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbPosY);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbPosX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.pbSpecular);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pbDiffuse);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pbAmbient);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbMode);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 232);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "光源设置";
            // 
            // pbGlobalAmbient
            // 
            this.pbGlobalAmbient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGlobalAmbient.Location = new System.Drawing.Point(114, 267);
            this.pbGlobalAmbient.Name = "pbGlobalAmbient";
            this.pbGlobalAmbient.Size = new System.Drawing.Size(49, 18);
            this.pbGlobalAmbient.TabIndex = 31;
            this.pbGlobalAmbient.TabStop = false;
            this.pbGlobalAmbient.Click += new System.EventHandler(this.pbGlobalAmbient_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 271);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 12);
            this.label14.TabIndex = 30;
            this.label14.Text = "全局环境光颜色：";
            // 
            // cbModelUseLighting
            // 
            this.cbModelUseLighting.AutoSize = true;
            this.cbModelUseLighting.Location = new System.Drawing.Point(313, 269);
            this.cbModelUseLighting.Name = "cbModelUseLighting";
            this.cbModelUseLighting.Size = new System.Drawing.Size(96, 16);
            this.cbModelUseLighting.TabIndex = 34;
            this.cbModelUseLighting.Text = "模型使用光照";
            this.cbModelUseLighting.UseVisualStyleBackColor = true;
            this.cbModelUseLighting.CheckedChanged += new System.EventHandler(this.cbModelUseLighting_CheckedChanged);
            // 
            // cbTerrainUseLighting
            // 
            this.cbTerrainUseLighting.AutoSize = true;
            this.cbTerrainUseLighting.Location = new System.Drawing.Point(198, 269);
            this.cbTerrainUseLighting.Name = "cbTerrainUseLighting";
            this.cbTerrainUseLighting.Size = new System.Drawing.Size(96, 16);
            this.cbTerrainUseLighting.TabIndex = 35;
            this.cbTerrainUseLighting.Text = "地形使用光照";
            this.cbTerrainUseLighting.UseVisualStyleBackColor = true;
            // 
            // SceneLightSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 347);
            this.Controls.Add(this.cbTerrainUseLighting);
            this.Controls.Add(this.cbModelUseLighting);
            this.Controls.Add(this.pbGlobalAmbient);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SceneLightSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "场景光照设置";
            this.Load += new System.EventHandler(this.SceneLightSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAmbient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiffuse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpecular)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGlobalAmbient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbAmbient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbDiffuse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbSpecular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox tbPosX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPosY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPosZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbGlobalAmbient;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbModelUseLighting;
        private System.Windows.Forms.CheckBox cbTerrainUseLighting;
    }
}