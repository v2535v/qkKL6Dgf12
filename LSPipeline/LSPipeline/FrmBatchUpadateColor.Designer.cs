namespace WorldGIS
{
    partial class FrmBatchUpadateColor
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLayers = new System.Windows.Forms.ComboBox();
            this.checkBoxLines = new System.Windows.Forms.CheckBox();
            this.checkBoxPolygons = new System.Windows.Forms.CheckBox();
            this.panelPoints = new System.Windows.Forms.Panel();
            this.checkBoxHideLabelOfMarker = new System.Windows.Forms.CheckBox();
            this.textBoxIconPath = new System.Windows.Forms.TextBox();
            this.buttonIconPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxPoints = new System.Windows.Forms.CheckBox();
            this.panelLines = new System.Windows.Forms.Panel();
            this.buttonLineColor = new System.Windows.Forms.Button();
            this.textBoxLineWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLineColor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPolygons = new System.Windows.Forms.Panel();
            this.textBoxPolygonAlpha = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonPolygonColor = new System.Windows.Forms.Button();
            this.buttonOutlineColor = new System.Windows.Forms.Button();
            this.textBoxPolygonColor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxOutlineWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOutlineColor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxHideLabelOfLine = new System.Windows.Forms.CheckBox();
            this.checkBoxHideLabelOfPolygon = new System.Windows.Forms.CheckBox();
            this.panelPoints.SuspendLayout();
            this.panelLines.SuspendLayout();
            this.panelPolygons.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(273, 457);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 23);
            this.button3.TabIndex = 45;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 457);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "请选择图层：";
            // 
            // comboBoxLayers
            // 
            this.comboBoxLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayers.FormattingEnabled = true;
            this.comboBoxLayers.Location = new System.Drawing.Point(124, 17);
            this.comboBoxLayers.Name = "comboBoxLayers";
            this.comboBoxLayers.Size = new System.Drawing.Size(145, 20);
            this.comboBoxLayers.TabIndex = 26;
            this.comboBoxLayers.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayers_TextChanged);
            // 
            // checkBoxLines
            // 
            this.checkBoxLines.AutoSize = true;
            this.checkBoxLines.Location = new System.Drawing.Point(19, 141);
            this.checkBoxLines.Name = "checkBoxLines";
            this.checkBoxLines.Size = new System.Drawing.Size(108, 16);
            this.checkBoxLines.TabIndex = 52;
            this.checkBoxLines.Text = "图层中的线对象";
            this.checkBoxLines.UseVisualStyleBackColor = true;
            this.checkBoxLines.CheckedChanged += new System.EventHandler(this.checkBoxLines_CheckedChanged);
            // 
            // checkBoxPolygons
            // 
            this.checkBoxPolygons.AutoSize = true;
            this.checkBoxPolygons.Location = new System.Drawing.Point(19, 262);
            this.checkBoxPolygons.Name = "checkBoxPolygons";
            this.checkBoxPolygons.Size = new System.Drawing.Size(108, 16);
            this.checkBoxPolygons.TabIndex = 53;
            this.checkBoxPolygons.Text = "图层中的面对象";
            this.checkBoxPolygons.UseVisualStyleBackColor = true;
            this.checkBoxPolygons.CheckedChanged += new System.EventHandler(this.checkBoxPolygons_CheckedChanged);
            // 
            // panelPoints
            // 
            this.panelPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPoints.Controls.Add(this.checkBoxHideLabelOfMarker);
            this.panelPoints.Controls.Add(this.textBoxIconPath);
            this.panelPoints.Controls.Add(this.buttonIconPath);
            this.panelPoints.Controls.Add(this.label3);
            this.panelPoints.Location = new System.Drawing.Point(30, 69);
            this.panelPoints.Name = "panelPoints";
            this.panelPoints.Size = new System.Drawing.Size(299, 66);
            this.panelPoints.TabIndex = 54;
            // 
            // checkBoxHideLabelOfMarker
            // 
            this.checkBoxHideLabelOfMarker.AutoSize = true;
            this.checkBoxHideLabelOfMarker.Location = new System.Drawing.Point(14, 8);
            this.checkBoxHideLabelOfMarker.Name = "checkBoxHideLabelOfMarker";
            this.checkBoxHideLabelOfMarker.Size = new System.Drawing.Size(72, 16);
            this.checkBoxHideLabelOfMarker.TabIndex = 60;
            this.checkBoxHideLabelOfMarker.Text = "隐藏标注";
            this.checkBoxHideLabelOfMarker.UseVisualStyleBackColor = true;
            this.checkBoxHideLabelOfMarker.CheckedChanged += new System.EventHandler(this.checkBoxClearAllIcon_CheckedChanged);
            // 
            // textBoxIconPath
            // 
            this.textBoxIconPath.Location = new System.Drawing.Point(92, 33);
            this.textBoxIconPath.Name = "textBoxIconPath";
            this.textBoxIconPath.Size = new System.Drawing.Size(145, 21);
            this.textBoxIconPath.TabIndex = 55;
            // 
            // buttonIconPath
            // 
            this.buttonIconPath.Location = new System.Drawing.Point(243, 31);
            this.buttonIconPath.Name = "buttonIconPath";
            this.buttonIconPath.Size = new System.Drawing.Size(47, 23);
            this.buttonIconPath.TabIndex = 54;
            this.buttonIconPath.Text = "...";
            this.buttonIconPath.UseVisualStyleBackColor = true;
            this.buttonIconPath.Click += new System.EventHandler(this.buttonIconPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 53;
            this.label3.Text = "图标路径：";
            // 
            // checkBoxPoints
            // 
            this.checkBoxPoints.AutoSize = true;
            this.checkBoxPoints.Location = new System.Drawing.Point(19, 47);
            this.checkBoxPoints.Name = "checkBoxPoints";
            this.checkBoxPoints.Size = new System.Drawing.Size(108, 16);
            this.checkBoxPoints.TabIndex = 57;
            this.checkBoxPoints.Text = "图层中的点对象";
            this.checkBoxPoints.UseVisualStyleBackColor = true;
            this.checkBoxPoints.CheckedChanged += new System.EventHandler(this.checkBoxPoints_CheckedChanged);
            // 
            // panelLines
            // 
            this.panelLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLines.Controls.Add(this.checkBoxHideLabelOfLine);
            this.panelLines.Controls.Add(this.buttonLineColor);
            this.panelLines.Controls.Add(this.textBoxLineWidth);
            this.panelLines.Controls.Add(this.label6);
            this.panelLines.Controls.Add(this.textBoxLineColor);
            this.panelLines.Controls.Add(this.label5);
            this.panelLines.Location = new System.Drawing.Point(30, 163);
            this.panelLines.Name = "panelLines";
            this.panelLines.Size = new System.Drawing.Size(299, 93);
            this.panelLines.TabIndex = 58;
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.Location = new System.Drawing.Point(243, 29);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(47, 23);
            this.buttonLineColor.TabIndex = 51;
            this.buttonLineColor.Text = "颜色";
            this.buttonLineColor.UseVisualStyleBackColor = true;
            this.buttonLineColor.Click += new System.EventHandler(this.buttonLineColor_Click);
            // 
            // textBoxLineWidth
            // 
            this.textBoxLineWidth.Location = new System.Drawing.Point(92, 60);
            this.textBoxLineWidth.Name = "textBoxLineWidth";
            this.textBoxLineWidth.Size = new System.Drawing.Size(145, 21);
            this.textBoxLineWidth.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "线宽：";
            // 
            // textBoxLineColor
            // 
            this.textBoxLineColor.Location = new System.Drawing.Point(92, 31);
            this.textBoxLineColor.Name = "textBoxLineColor";
            this.textBoxLineColor.ReadOnly = true;
            this.textBoxLineColor.Size = new System.Drawing.Size(145, 21);
            this.textBoxLineColor.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "颜色：";
            // 
            // panelPolygons
            // 
            this.panelPolygons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPolygons.Controls.Add(this.checkBoxHideLabelOfPolygon);
            this.panelPolygons.Controls.Add(this.textBoxPolygonAlpha);
            this.panelPolygons.Controls.Add(this.label11);
            this.panelPolygons.Controls.Add(this.buttonPolygonColor);
            this.panelPolygons.Controls.Add(this.buttonOutlineColor);
            this.panelPolygons.Controls.Add(this.textBoxPolygonColor);
            this.panelPolygons.Controls.Add(this.label10);
            this.panelPolygons.Controls.Add(this.textBoxOutlineWidth);
            this.panelPolygons.Controls.Add(this.label7);
            this.panelPolygons.Controls.Add(this.textBoxOutlineColor);
            this.panelPolygons.Controls.Add(this.label8);
            this.panelPolygons.Location = new System.Drawing.Point(30, 284);
            this.panelPolygons.Name = "panelPolygons";
            this.panelPolygons.Size = new System.Drawing.Size(299, 165);
            this.panelPolygons.TabIndex = 59;
            // 
            // textBoxPolygonAlpha
            // 
            this.textBoxPolygonAlpha.Location = new System.Drawing.Point(92, 99);
            this.textBoxPolygonAlpha.Name = "textBoxPolygonAlpha";
            this.textBoxPolygonAlpha.Size = new System.Drawing.Size(145, 21);
            this.textBoxPolygonAlpha.TabIndex = 60;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 59;
            this.label11.Text = "面不透明度：";
            // 
            // buttonPolygonColor
            // 
            this.buttonPolygonColor.Location = new System.Drawing.Point(243, 130);
            this.buttonPolygonColor.Name = "buttonPolygonColor";
            this.buttonPolygonColor.Size = new System.Drawing.Size(47, 23);
            this.buttonPolygonColor.TabIndex = 58;
            this.buttonPolygonColor.Text = "颜色";
            this.buttonPolygonColor.UseVisualStyleBackColor = true;
            this.buttonPolygonColor.Click += new System.EventHandler(this.buttonPolygonColor_Click);
            // 
            // buttonOutlineColor
            // 
            this.buttonOutlineColor.Location = new System.Drawing.Point(243, 33);
            this.buttonOutlineColor.Name = "buttonOutlineColor";
            this.buttonOutlineColor.Size = new System.Drawing.Size(47, 23);
            this.buttonOutlineColor.TabIndex = 57;
            this.buttonOutlineColor.Text = "颜色";
            this.buttonOutlineColor.UseVisualStyleBackColor = true;
            this.buttonOutlineColor.Click += new System.EventHandler(this.buttonOutlineColor_Click);
            // 
            // textBoxPolygonColor
            // 
            this.textBoxPolygonColor.Location = new System.Drawing.Point(92, 131);
            this.textBoxPolygonColor.Name = "textBoxPolygonColor";
            this.textBoxPolygonColor.ReadOnly = true;
            this.textBoxPolygonColor.Size = new System.Drawing.Size(145, 21);
            this.textBoxPolygonColor.TabIndex = 56;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 55;
            this.label10.Text = "面填充色：";
            // 
            // textBoxOutlineWidth
            // 
            this.textBoxOutlineWidth.Location = new System.Drawing.Point(92, 66);
            this.textBoxOutlineWidth.Name = "textBoxOutlineWidth";
            this.textBoxOutlineWidth.Size = new System.Drawing.Size(145, 21);
            this.textBoxOutlineWidth.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 53;
            this.label7.Text = "边框线宽度：";
            // 
            // textBoxOutlineColor
            // 
            this.textBoxOutlineColor.Location = new System.Drawing.Point(92, 33);
            this.textBoxOutlineColor.Name = "textBoxOutlineColor";
            this.textBoxOutlineColor.ReadOnly = true;
            this.textBoxOutlineColor.Size = new System.Drawing.Size(145, 21);
            this.textBoxOutlineColor.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 51;
            this.label8.Text = "边框线颜色：";
            // 
            // checkBoxHideLabelOfLine
            // 
            this.checkBoxHideLabelOfLine.AutoSize = true;
            this.checkBoxHideLabelOfLine.Location = new System.Drawing.Point(17, 7);
            this.checkBoxHideLabelOfLine.Name = "checkBoxHideLabelOfLine";
            this.checkBoxHideLabelOfLine.Size = new System.Drawing.Size(72, 16);
            this.checkBoxHideLabelOfLine.TabIndex = 61;
            this.checkBoxHideLabelOfLine.Text = "隐藏标注";
            this.checkBoxHideLabelOfLine.UseVisualStyleBackColor = true;
            this.checkBoxHideLabelOfLine.CheckedChanged += new System.EventHandler(this.checkBoxHideLabelOfLine_CheckedChanged);
            // 
            // checkBoxHideLabelOfPolygon
            // 
            this.checkBoxHideLabelOfPolygon.AutoSize = true;
            this.checkBoxHideLabelOfPolygon.Location = new System.Drawing.Point(16, 9);
            this.checkBoxHideLabelOfPolygon.Name = "checkBoxHideLabelOfPolygon";
            this.checkBoxHideLabelOfPolygon.Size = new System.Drawing.Size(72, 16);
            this.checkBoxHideLabelOfPolygon.TabIndex = 62;
            this.checkBoxHideLabelOfPolygon.Text = "隐藏标注";
            this.checkBoxHideLabelOfPolygon.UseVisualStyleBackColor = true;
            // 
            // FrmBatchUpadateColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(348, 487);
            this.Controls.Add(this.panelPolygons);
            this.Controls.Add(this.panelLines);
            this.Controls.Add(this.checkBoxPoints);
            this.Controls.Add(this.panelPoints);
            this.Controls.Add(this.checkBoxPolygons);
            this.Controls.Add(this.checkBoxLines);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBatchUpadateColor";
            this.ShowIcon = false;
            this.Text = "批量修改颜色";
            this.Load += new System.EventHandler(this.FrmBatchUpadateColor_Load);
            this.panelPoints.ResumeLayout(false);
            this.panelPoints.PerformLayout();
            this.panelLines.ResumeLayout(false);
            this.panelLines.PerformLayout();
            this.panelPolygons.ResumeLayout(false);
            this.panelPolygons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLayers;
        private System.Windows.Forms.CheckBox checkBoxLines;
        private System.Windows.Forms.CheckBox checkBoxPolygons;
        private System.Windows.Forms.Panel panelPoints;
        private System.Windows.Forms.TextBox textBoxIconPath;
        private System.Windows.Forms.Button buttonIconPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxPoints;
        private System.Windows.Forms.Panel panelLines;
        private System.Windows.Forms.Button buttonLineColor;
        private System.Windows.Forms.TextBox textBoxLineWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxLineColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelPolygons;
        private System.Windows.Forms.TextBox textBoxPolygonAlpha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonPolygonColor;
        private System.Windows.Forms.Button buttonOutlineColor;
        private System.Windows.Forms.TextBox textBoxPolygonColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxOutlineWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOutlineColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxHideLabelOfMarker;
        private System.Windows.Forms.CheckBox checkBoxHideLabelOfLine;
        private System.Windows.Forms.CheckBox checkBoxHideLabelOfPolygon;

    }
}