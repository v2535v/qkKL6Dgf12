namespace WorldGIS
{
    partial class FrmAnalysisProfile
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.labelStartLon = new System.Windows.Forms.Label();
            this.groupBoxYMin = new System.Windows.Forms.GroupBox();
            this.labelPointNum = new System.Windows.Forms.Label();
            this.labelSpaceLenth = new System.Windows.Forms.Label();
            this.labelGroundLenth = new System.Windows.Forms.Label();
            this.labelSphereLenth = new System.Windows.Forms.Label();
            this.labelEndAlt = new System.Windows.Forms.Label();
            this.labelMinAlt = new System.Windows.Forms.Label();
            this.labelMaxAlt = new System.Windows.Forms.Label();
            this.labelStartAlt = new System.Windows.Forms.Label();
            this.labelEndLat = new System.Windows.Forms.Label();
            this.labelEndLon = new System.Windows.Forms.Label();
            this.labelStartLat = new System.Windows.Forms.Label();
            this.checkBoxSameScale = new System.Windows.Forms.CheckBox();
            this.checkBoxXmin = new System.Windows.Forms.CheckBox();
            this.checkBoxYMin = new System.Windows.Forms.CheckBox();
            this.groupBoxYMin.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(502, 238);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // labelStartLon
            // 
            this.labelStartLon.AutoSize = true;
            this.labelStartLon.Location = new System.Drawing.Point(40, 17);
            this.labelStartLon.Name = "labelStartLon";
            this.labelStartLon.Size = new System.Drawing.Size(65, 12);
            this.labelStartLon.TabIndex = 1;
            this.labelStartLon.Text = "起点经度：";
            // 
            // groupBoxYMin
            // 
            this.groupBoxYMin.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxYMin.Controls.Add(this.labelPointNum);
            this.groupBoxYMin.Controls.Add(this.labelSpaceLenth);
            this.groupBoxYMin.Controls.Add(this.labelGroundLenth);
            this.groupBoxYMin.Controls.Add(this.labelSphereLenth);
            this.groupBoxYMin.Controls.Add(this.labelEndAlt);
            this.groupBoxYMin.Controls.Add(this.labelMinAlt);
            this.groupBoxYMin.Controls.Add(this.labelMaxAlt);
            this.groupBoxYMin.Controls.Add(this.labelStartAlt);
            this.groupBoxYMin.Controls.Add(this.labelEndLat);
            this.groupBoxYMin.Controls.Add(this.labelEndLon);
            this.groupBoxYMin.Controls.Add(this.labelStartLat);
            this.groupBoxYMin.Controls.Add(this.labelStartLon);
            this.groupBoxYMin.Location = new System.Drawing.Point(12, 279);
            this.groupBoxYMin.Name = "groupBoxYMin";
            this.groupBoxYMin.Size = new System.Drawing.Size(502, 105);
            this.groupBoxYMin.TabIndex = 2;
            this.groupBoxYMin.TabStop = false;
            // 
            // labelPointNum
            // 
            this.labelPointNum.AutoSize = true;
            this.labelPointNum.Location = new System.Drawing.Point(368, 79);
            this.labelPointNum.Name = "labelPointNum";
            this.labelPointNum.Size = new System.Drawing.Size(65, 12);
            this.labelPointNum.TabIndex = 14;
            this.labelPointNum.Text = "采样点数：";
            // 
            // labelSpaceLenth
            // 
            this.labelSpaceLenth.AutoSize = true;
            this.labelSpaceLenth.Location = new System.Drawing.Point(368, 58);
            this.labelSpaceLenth.Name = "labelSpaceLenth";
            this.labelSpaceLenth.Size = new System.Drawing.Size(65, 12);
            this.labelSpaceLenth.TabIndex = 12;
            this.labelSpaceLenth.Text = "直线距离：";
            // 
            // labelGroundLenth
            // 
            this.labelGroundLenth.AutoSize = true;
            this.labelGroundLenth.Location = new System.Drawing.Point(368, 37);
            this.labelGroundLenth.Name = "labelGroundLenth";
            this.labelGroundLenth.Size = new System.Drawing.Size(65, 12);
            this.labelGroundLenth.TabIndex = 11;
            this.labelGroundLenth.Text = "地表距离：";
            // 
            // labelSphereLenth
            // 
            this.labelSphereLenth.AutoSize = true;
            this.labelSphereLenth.Location = new System.Drawing.Point(368, 17);
            this.labelSphereLenth.Name = "labelSphereLenth";
            this.labelSphereLenth.Size = new System.Drawing.Size(65, 12);
            this.labelSphereLenth.TabIndex = 10;
            this.labelSphereLenth.Text = "投影距离：";
            // 
            // labelEndAlt
            // 
            this.labelEndAlt.AutoSize = true;
            this.labelEndAlt.Location = new System.Drawing.Point(205, 37);
            this.labelEndAlt.Name = "labelEndAlt";
            this.labelEndAlt.Size = new System.Drawing.Size(65, 12);
            this.labelEndAlt.TabIndex = 8;
            this.labelEndAlt.Text = "终点海拔：";
            // 
            // labelMinAlt
            // 
            this.labelMinAlt.AutoSize = true;
            this.labelMinAlt.Location = new System.Drawing.Point(205, 79);
            this.labelMinAlt.Name = "labelMinAlt";
            this.labelMinAlt.Size = new System.Drawing.Size(65, 12);
            this.labelMinAlt.TabIndex = 7;
            this.labelMinAlt.Text = "最低海拔：";
            // 
            // labelMaxAlt
            // 
            this.labelMaxAlt.AutoSize = true;
            this.labelMaxAlt.Location = new System.Drawing.Point(205, 58);
            this.labelMaxAlt.Name = "labelMaxAlt";
            this.labelMaxAlt.Size = new System.Drawing.Size(65, 12);
            this.labelMaxAlt.TabIndex = 6;
            this.labelMaxAlt.Text = "最高海拔：";
            // 
            // labelStartAlt
            // 
            this.labelStartAlt.AutoSize = true;
            this.labelStartAlt.Location = new System.Drawing.Point(205, 17);
            this.labelStartAlt.Name = "labelStartAlt";
            this.labelStartAlt.Size = new System.Drawing.Size(65, 12);
            this.labelStartAlt.TabIndex = 5;
            this.labelStartAlt.Text = "起点海拔：";
            // 
            // labelEndLat
            // 
            this.labelEndLat.AutoSize = true;
            this.labelEndLat.Location = new System.Drawing.Point(40, 79);
            this.labelEndLat.Name = "labelEndLat";
            this.labelEndLat.Size = new System.Drawing.Size(65, 12);
            this.labelEndLat.TabIndex = 4;
            this.labelEndLat.Text = "终点纬度：";
            // 
            // labelEndLon
            // 
            this.labelEndLon.AutoSize = true;
            this.labelEndLon.Location = new System.Drawing.Point(40, 58);
            this.labelEndLon.Name = "labelEndLon";
            this.labelEndLon.Size = new System.Drawing.Size(65, 12);
            this.labelEndLon.TabIndex = 3;
            this.labelEndLon.Text = "终点经度：";
            // 
            // labelStartLat
            // 
            this.labelStartLat.AutoSize = true;
            this.labelStartLat.Location = new System.Drawing.Point(40, 37);
            this.labelStartLat.Name = "labelStartLat";
            this.labelStartLat.Size = new System.Drawing.Size(65, 12);
            this.labelStartLat.TabIndex = 2;
            this.labelStartLat.Text = "起点纬度：";
            // 
            // checkBoxSameScale
            // 
            this.checkBoxSameScale.AutoSize = true;
            this.checkBoxSameScale.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxSameScale.Location = new System.Drawing.Point(53, 260);
            this.checkBoxSameScale.Name = "checkBoxSameScale";
            this.checkBoxSameScale.Size = new System.Drawing.Size(84, 16);
            this.checkBoxSameScale.TabIndex = 3;
            this.checkBoxSameScale.Text = "图形不变形";
            this.checkBoxSameScale.UseVisualStyleBackColor = false;
            this.checkBoxSameScale.CheckedChanged += new System.EventHandler(this.checkBoxSameScale_CheckedChanged);
            // 
            // checkBoxXmin
            // 
            this.checkBoxXmin.AutoSize = true;
            this.checkBoxXmin.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxXmin.Location = new System.Drawing.Point(219, 260);
            this.checkBoxXmin.Name = "checkBoxXmin";
            this.checkBoxXmin.Size = new System.Drawing.Size(78, 16);
            this.checkBoxXmin.TabIndex = 4;
            this.checkBoxXmin.Text = "固定最小X";
            this.checkBoxXmin.UseVisualStyleBackColor = false;
            this.checkBoxXmin.CheckedChanged += new System.EventHandler(this.checkBoxXmin_CheckedChanged);
            // 
            // checkBoxYMin
            // 
            this.checkBoxYMin.AutoSize = true;
            this.checkBoxYMin.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxYMin.Location = new System.Drawing.Point(382, 260);
            this.checkBoxYMin.Name = "checkBoxYMin";
            this.checkBoxYMin.Size = new System.Drawing.Size(78, 16);
            this.checkBoxYMin.TabIndex = 5;
            this.checkBoxYMin.Text = "固定最小Y";
            this.checkBoxYMin.UseVisualStyleBackColor = false;
            this.checkBoxYMin.CheckedChanged += new System.EventHandler(this.checkBoxYMin_CheckedChanged);
            // 
            // ProfileAnalysisDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 396);
            this.Controls.Add(this.checkBoxYMin);
            this.Controls.Add(this.checkBoxXmin);
            this.Controls.Add(this.checkBoxSameScale);
            this.Controls.Add(this.groupBoxYMin);
            this.Controls.Add(this.zedGraphControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ProfileAnalysisDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "剖面分析";
            this.Load += new System.EventHandler(this.ProfileAnalysisDlg_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProfileAnalysisDlg_Paint);
            this.Resize += new System.EventHandler(this.ProfileAnalysisDlg_Resize);
            this.groupBoxYMin.ResumeLayout(false);
            this.groupBoxYMin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label labelStartLon;
        private System.Windows.Forms.GroupBox groupBoxYMin;
        private System.Windows.Forms.Label labelStartLat;
        private System.Windows.Forms.Label labelEndLat;
        private System.Windows.Forms.Label labelEndLon;
        private System.Windows.Forms.Label labelSpaceLenth;
        private System.Windows.Forms.Label labelGroundLenth;
        private System.Windows.Forms.Label labelSphereLenth;
        private System.Windows.Forms.Label labelEndAlt;
        private System.Windows.Forms.Label labelMinAlt;
        private System.Windows.Forms.Label labelMaxAlt;
        private System.Windows.Forms.Label labelStartAlt;
        private System.Windows.Forms.Label labelPointNum;
        private System.Windows.Forms.CheckBox checkBoxSameScale;
        private System.Windows.Forms.CheckBox checkBoxXmin;
        private System.Windows.Forms.CheckBox checkBoxYMin;
    }
}