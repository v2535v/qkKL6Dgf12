namespace WorldGIS
{
    partial class CtrlGeometryCameraState
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
            this.textBoxCameraTilt = new System.Windows.Forms.TextBox();
            this.textBoxCameraHeading = new System.Windows.Forms.TextBox();
            this.textBoxCameraLon = new System.Windows.Forms.TextBox();
            this.textBoxCameraAlt = new System.Windows.Forms.TextBox();
            this.textBoxCameraLat = new System.Windows.Forms.TextBox();
            this.buttonResetCamera = new System.Windows.Forms.Button();
            this.buttonCurCamera = new System.Windows.Forms.Button();
            this.labelDegree4 = new System.Windows.Forms.Label();
            this.labelCameraTilt = new System.Windows.Forms.Label();
            this.label1Degree3 = new System.Windows.Forms.Label();
            this.labelCameraHeading = new System.Windows.Forms.Label();
            this.labelMeter1 = new System.Windows.Forms.Label();
            this.labelCameraAlt = new System.Windows.Forms.Label();
            this.labelDegree1 = new System.Windows.Forms.Label();
            this.labelCameraLon = new System.Windows.Forms.Label();
            this.labelDegree2 = new System.Windows.Forms.Label();
            this.checkBoxEnableCamera = new System.Windows.Forms.CheckBox();
            this.labelCameraLat = new System.Windows.Forms.Label();
            this.labelCameraAltiMode = new System.Windows.Forms.Label();
            this.comboBoxAltiMode = new System.Windows.Forms.ComboBox();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxCameraTilt
            // 
            this.textBoxCameraTilt.Location = new System.Drawing.Point(124, 221);
            this.textBoxCameraTilt.Name = "textBoxCameraTilt";
            this.textBoxCameraTilt.Size = new System.Drawing.Size(122, 21);
            this.textBoxCameraTilt.TabIndex = 76;
            // 
            // textBoxCameraHeading
            // 
            this.textBoxCameraHeading.Location = new System.Drawing.Point(124, 194);
            this.textBoxCameraHeading.Name = "textBoxCameraHeading";
            this.textBoxCameraHeading.Size = new System.Drawing.Size(122, 21);
            this.textBoxCameraHeading.TabIndex = 75;
            // 
            // textBoxCameraLon
            // 
            this.textBoxCameraLon.Location = new System.Drawing.Point(124, 86);
            this.textBoxCameraLon.Name = "textBoxCameraLon";
            this.textBoxCameraLon.Size = new System.Drawing.Size(122, 21);
            this.textBoxCameraLon.TabIndex = 74;
            // 
            // textBoxCameraAlt
            // 
            this.textBoxCameraAlt.Location = new System.Drawing.Point(124, 140);
            this.textBoxCameraAlt.Name = "textBoxCameraAlt";
            this.textBoxCameraAlt.Size = new System.Drawing.Size(122, 21);
            this.textBoxCameraAlt.TabIndex = 73;
            // 
            // textBoxCameraLat
            // 
            this.textBoxCameraLat.Location = new System.Drawing.Point(124, 113);
            this.textBoxCameraLat.Name = "textBoxCameraLat";
            this.textBoxCameraLat.Size = new System.Drawing.Size(122, 21);
            this.textBoxCameraLat.TabIndex = 72;
            // 
            // buttonResetCamera
            // 
            this.buttonResetCamera.Location = new System.Drawing.Point(204, 281);
            this.buttonResetCamera.Name = "buttonResetCamera";
            this.buttonResetCamera.Size = new System.Drawing.Size(83, 21);
            this.buttonResetCamera.TabIndex = 71;
            this.buttonResetCamera.Text = "重置";
            this.buttonResetCamera.UseVisualStyleBackColor = true;
            this.buttonResetCamera.Click += new System.EventHandler(this.buttonResetCamera_Click);
            // 
            // buttonCurCamera
            // 
            this.buttonCurCamera.Location = new System.Drawing.Point(46, 281);
            this.buttonCurCamera.Name = "buttonCurCamera";
            this.buttonCurCamera.Size = new System.Drawing.Size(130, 22);
            this.buttonCurCamera.TabIndex = 70;
            this.buttonCurCamera.Text = "获取当前场景相机";
            this.buttonCurCamera.UseVisualStyleBackColor = true;
            this.buttonCurCamera.Click += new System.EventHandler(this.buttonCurCamera_Click);
            // 
            // labelDegree4
            // 
            this.labelDegree4.AutoSize = true;
            this.labelDegree4.Location = new System.Drawing.Point(255, 225);
            this.labelDegree4.Name = "labelDegree4";
            this.labelDegree4.Size = new System.Drawing.Size(17, 12);
            this.labelDegree4.TabIndex = 69;
            this.labelDegree4.Text = "度";
            // 
            // labelCameraTilt
            // 
            this.labelCameraTilt.AutoSize = true;
            this.labelCameraTilt.Location = new System.Drawing.Point(66, 225);
            this.labelCameraTilt.Name = "labelCameraTilt";
            this.labelCameraTilt.Size = new System.Drawing.Size(41, 12);
            this.labelCameraTilt.TabIndex = 68;
            this.labelCameraTilt.Text = "倾斜：";
            // 
            // label1Degree3
            // 
            this.label1Degree3.AutoSize = true;
            this.label1Degree3.Location = new System.Drawing.Point(255, 198);
            this.label1Degree3.Name = "label1Degree3";
            this.label1Degree3.Size = new System.Drawing.Size(17, 12);
            this.label1Degree3.TabIndex = 67;
            this.label1Degree3.Text = "度";
            // 
            // labelCameraHeading
            // 
            this.labelCameraHeading.AutoSize = true;
            this.labelCameraHeading.Location = new System.Drawing.Point(66, 198);
            this.labelCameraHeading.Name = "labelCameraHeading";
            this.labelCameraHeading.Size = new System.Drawing.Size(41, 12);
            this.labelCameraHeading.TabIndex = 66;
            this.labelCameraHeading.Text = "偏北：";
            // 
            // labelMeter1
            // 
            this.labelMeter1.AutoSize = true;
            this.labelMeter1.Location = new System.Drawing.Point(255, 144);
            this.labelMeter1.Name = "labelMeter1";
            this.labelMeter1.Size = new System.Drawing.Size(17, 12);
            this.labelMeter1.TabIndex = 65;
            this.labelMeter1.Text = "米";
            // 
            // labelCameraAlt
            // 
            this.labelCameraAlt.AutoSize = true;
            this.labelCameraAlt.Location = new System.Drawing.Point(66, 144);
            this.labelCameraAlt.Name = "labelCameraAlt";
            this.labelCameraAlt.Size = new System.Drawing.Size(41, 12);
            this.labelCameraAlt.TabIndex = 64;
            this.labelCameraAlt.Text = "海拔：";
            // 
            // labelDegree1
            // 
            this.labelDegree1.AutoSize = true;
            this.labelDegree1.Location = new System.Drawing.Point(255, 90);
            this.labelDegree1.Name = "labelDegree1";
            this.labelDegree1.Size = new System.Drawing.Size(17, 12);
            this.labelDegree1.TabIndex = 63;
            this.labelDegree1.Text = "度";
            // 
            // labelCameraLon
            // 
            this.labelCameraLon.AutoSize = true;
            this.labelCameraLon.Location = new System.Drawing.Point(66, 90);
            this.labelCameraLon.Name = "labelCameraLon";
            this.labelCameraLon.Size = new System.Drawing.Size(41, 12);
            this.labelCameraLon.TabIndex = 62;
            this.labelCameraLon.Text = "经度：";
            // 
            // labelDegree2
            // 
            this.labelDegree2.AutoSize = true;
            this.labelDegree2.Location = new System.Drawing.Point(255, 117);
            this.labelDegree2.Name = "labelDegree2";
            this.labelDegree2.Size = new System.Drawing.Size(17, 12);
            this.labelDegree2.TabIndex = 61;
            this.labelDegree2.Text = "度";
            // 
            // checkBoxEnableCamera
            // 
            this.checkBoxEnableCamera.AutoSize = true;
            this.checkBoxEnableCamera.Location = new System.Drawing.Point(204, 42);
            this.checkBoxEnableCamera.Name = "checkBoxEnableCamera";
            this.checkBoxEnableCamera.Size = new System.Drawing.Size(96, 16);
            this.checkBoxEnableCamera.TabIndex = 60;
            this.checkBoxEnableCamera.Text = "使用相机定位";
            this.checkBoxEnableCamera.UseVisualStyleBackColor = true;
            this.checkBoxEnableCamera.CheckedChanged += new System.EventHandler(this.checkBoxEnableCamera_CheckedChanged);
            // 
            // labelCameraLat
            // 
            this.labelCameraLat.AutoSize = true;
            this.labelCameraLat.Location = new System.Drawing.Point(66, 117);
            this.labelCameraLat.Name = "labelCameraLat";
            this.labelCameraLat.Size = new System.Drawing.Size(41, 12);
            this.labelCameraLat.TabIndex = 59;
            this.labelCameraLat.Text = "纬度：";
            // 
            // labelCameraAltiMode
            // 
            this.labelCameraAltiMode.AutoSize = true;
            this.labelCameraAltiMode.Location = new System.Drawing.Point(65, 252);
            this.labelCameraAltiMode.Name = "labelCameraAltiMode";
            this.labelCameraAltiMode.Size = new System.Drawing.Size(65, 12);
            this.labelCameraAltiMode.TabIndex = 77;
            this.labelCameraAltiMode.Text = "高度模式：";
            // 
            // comboBoxAltiMode
            // 
            this.comboBoxAltiMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAltiMode.FormattingEnabled = true;
            this.comboBoxAltiMode.Items.AddRange(new object[] {
            "海拔高度",
            "紧贴地表",
            "相对地表"});
            this.comboBoxAltiMode.Location = new System.Drawing.Point(124, 248);
            this.comboBoxAltiMode.Name = "comboBoxAltiMode";
            this.comboBoxAltiMode.Size = new System.Drawing.Size(123, 20);
            this.comboBoxAltiMode.TabIndex = 78;
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(124, 167);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(122, 21);
            this.textBoxDistance.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "视高：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 65;
            this.label2.Text = "米";
            // 
            // CtrlGeometryCameraState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.comboBoxAltiMode);
            this.Controls.Add(this.labelCameraAltiMode);
            this.Controls.Add(this.textBoxCameraTilt);
            this.Controls.Add(this.textBoxCameraHeading);
            this.Controls.Add(this.textBoxCameraLon);
            this.Controls.Add(this.textBoxCameraAlt);
            this.Controls.Add(this.textBoxCameraLat);
            this.Controls.Add(this.buttonResetCamera);
            this.Controls.Add(this.buttonCurCamera);
            this.Controls.Add(this.labelDegree4);
            this.Controls.Add(this.labelCameraTilt);
            this.Controls.Add(this.label1Degree3);
            this.Controls.Add(this.labelCameraHeading);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMeter1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCameraAlt);
            this.Controls.Add(this.labelDegree1);
            this.Controls.Add(this.labelCameraLon);
            this.Controls.Add(this.labelDegree2);
            this.Controls.Add(this.checkBoxEnableCamera);
            this.Controls.Add(this.labelCameraLat);
            this.Name = "CtrlGeometryCameraState";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlGeometryCameraState_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCameraTilt;
        private System.Windows.Forms.TextBox textBoxCameraHeading;
        private System.Windows.Forms.TextBox textBoxCameraLon;
        private System.Windows.Forms.TextBox textBoxCameraAlt;
        private System.Windows.Forms.TextBox textBoxCameraLat;
        private System.Windows.Forms.Button buttonResetCamera;
        private System.Windows.Forms.Button buttonCurCamera;
        private System.Windows.Forms.Label labelDegree4;
        private System.Windows.Forms.Label labelCameraTilt;
        private System.Windows.Forms.Label label1Degree3;
        private System.Windows.Forms.Label labelCameraHeading;
        private System.Windows.Forms.Label labelMeter1;
        private System.Windows.Forms.Label labelCameraAlt;
        private System.Windows.Forms.Label labelDegree1;
        private System.Windows.Forms.Label labelCameraLon;
        private System.Windows.Forms.Label labelDegree2;
        private System.Windows.Forms.CheckBox checkBoxEnableCamera;
        private System.Windows.Forms.Label labelCameraLat;
        private System.Windows.Forms.Label labelCameraAltiMode;
        private System.Windows.Forms.ComboBox comboBoxAltiMode;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
