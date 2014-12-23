﻿namespace WorldGIS
{
    partial class FrmAnalysisDigFill
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
            this.buttonAnalyse = new System.Windows.Forms.Button();
            this.textBoxDestAlt = new System.Windows.Forms.TextBox();
            this.labelFillArea = new System.Windows.Forms.Label();
            this.labelDFArea = new System.Windows.Forms.Label();
            this.labelDigArea = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDFVolume = new System.Windows.Forms.Label();
            this.labelDigVolume = new System.Windows.Forms.Label();
            this.labelFillVolume = new System.Windows.Forms.Label();
            this.labelMinAltPnt = new System.Windows.Forms.Label();
            this.labelMaxAltPnt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTotalArea = new System.Windows.Forms.Label();
            this.textBoxPntMax = new System.Windows.Forms.TextBox();
            this.textBoxPntMin = new System.Windows.Forms.TextBox();
            this.textBoxFillVolume = new System.Windows.Forms.TextBox();
            this.textBoxDigVolume = new System.Windows.Forms.TextBox();
            this.textBoxDFVolume = new System.Windows.Forms.TextBox();
            this.textBoxFillArea = new System.Windows.Forms.TextBox();
            this.textBoxDigArea = new System.Windows.Forms.TextBox();
            this.textBoxDFArea = new System.Windows.Forms.TextBox();
            this.textBoxTotalArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAnalyse
            // 
            this.buttonAnalyse.Location = new System.Drawing.Point(296, 269);
            this.buttonAnalyse.Name = "buttonAnalyse";
            this.buttonAnalyse.Size = new System.Drawing.Size(69, 21);
            this.buttonAnalyse.TabIndex = 16;
            this.buttonAnalyse.Text = "分析";
            this.buttonAnalyse.UseVisualStyleBackColor = true;
            this.buttonAnalyse.Click += new System.EventHandler(this.buttonAnalyse_Click);
            // 
            // textBoxDestAlt
            // 
            this.textBoxDestAlt.BackColor = System.Drawing.Color.White;
            this.textBoxDestAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDestAlt.Location = new System.Drawing.Point(197, 269);
            this.textBoxDestAlt.Name = "textBoxDestAlt";
            this.textBoxDestAlt.Size = new System.Drawing.Size(52, 21);
            this.textBoxDestAlt.TabIndex = 13;
            this.textBoxDestAlt.Text = "0";
            // 
            // labelFillArea
            // 
            this.labelFillArea.AutoSize = true;
            this.labelFillArea.BackColor = System.Drawing.Color.Transparent;
            this.labelFillArea.Location = new System.Drawing.Point(16, 150);
            this.labelFillArea.Name = "labelFillArea";
            this.labelFillArea.Size = new System.Drawing.Size(89, 12);
            this.labelFillArea.TabIndex = 19;
            this.labelFillArea.Text = "填方区域面积：";
            // 
            // labelDFArea
            // 
            this.labelDFArea.AutoSize = true;
            this.labelDFArea.BackColor = System.Drawing.Color.Transparent;
            this.labelDFArea.Location = new System.Drawing.Point(16, 204);
            this.labelDFArea.Name = "labelDFArea";
            this.labelDFArea.Size = new System.Drawing.Size(89, 12);
            this.labelDFArea.TabIndex = 18;
            this.labelDFArea.Text = "挖填区域面积：";
            // 
            // labelDigArea
            // 
            this.labelDigArea.AutoSize = true;
            this.labelDigArea.BackColor = System.Drawing.Color.Transparent;
            this.labelDigArea.Location = new System.Drawing.Point(16, 177);
            this.labelDigArea.Name = "labelDigArea";
            this.labelDigArea.Size = new System.Drawing.Size(89, 12);
            this.labelDigArea.TabIndex = 17;
            this.labelDigArea.Text = "挖方区域面积：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(114, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "基准面高程：";
            // 
            // labelDFVolume
            // 
            this.labelDFVolume.AutoSize = true;
            this.labelDFVolume.BackColor = System.Drawing.Color.Transparent;
            this.labelDFVolume.Location = new System.Drawing.Point(16, 123);
            this.labelDFVolume.Name = "labelDFVolume";
            this.labelDFVolume.Size = new System.Drawing.Size(77, 12);
            this.labelDFVolume.TabIndex = 14;
            this.labelDFVolume.Text = "挖填方总量：";
            // 
            // labelDigVolume
            // 
            this.labelDigVolume.AutoSize = true;
            this.labelDigVolume.BackColor = System.Drawing.Color.Transparent;
            this.labelDigVolume.Location = new System.Drawing.Point(16, 96);
            this.labelDigVolume.Name = "labelDigVolume";
            this.labelDigVolume.Size = new System.Drawing.Size(53, 12);
            this.labelDigVolume.TabIndex = 12;
            this.labelDigVolume.Text = "挖方量：";
            // 
            // labelFillVolume
            // 
            this.labelFillVolume.AutoSize = true;
            this.labelFillVolume.BackColor = System.Drawing.Color.Transparent;
            this.labelFillVolume.Location = new System.Drawing.Point(16, 69);
            this.labelFillVolume.Name = "labelFillVolume";
            this.labelFillVolume.Size = new System.Drawing.Size(53, 12);
            this.labelFillVolume.TabIndex = 11;
            this.labelFillVolume.Text = "填方量：";
            // 
            // labelMinAltPnt
            // 
            this.labelMinAltPnt.AutoSize = true;
            this.labelMinAltPnt.BackColor = System.Drawing.Color.Transparent;
            this.labelMinAltPnt.Location = new System.Drawing.Point(16, 42);
            this.labelMinAltPnt.Name = "labelMinAltPnt";
            this.labelMinAltPnt.Size = new System.Drawing.Size(53, 12);
            this.labelMinAltPnt.TabIndex = 10;
            this.labelMinAltPnt.Text = "最低点：";
            // 
            // labelMaxAltPnt
            // 
            this.labelMaxAltPnt.AutoSize = true;
            this.labelMaxAltPnt.BackColor = System.Drawing.Color.Transparent;
            this.labelMaxAltPnt.Location = new System.Drawing.Point(16, 15);
            this.labelMaxAltPnt.Name = "labelMaxAltPnt";
            this.labelMaxAltPnt.Size = new System.Drawing.Size(53, 12);
            this.labelMaxAltPnt.TabIndex = 9;
            this.labelMaxAltPnt.Text = "最高点：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(255, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "米";
            // 
            // labelTotalArea
            // 
            this.labelTotalArea.AutoSize = true;
            this.labelTotalArea.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalArea.Location = new System.Drawing.Point(16, 231);
            this.labelTotalArea.Name = "labelTotalArea";
            this.labelTotalArea.Size = new System.Drawing.Size(77, 12);
            this.labelTotalArea.TabIndex = 21;
            this.labelTotalArea.Text = "区域总面积：";
            // 
            // textBoxPntMax
            // 
            this.textBoxPntMax.BackColor = System.Drawing.Color.White;
            this.textBoxPntMax.Location = new System.Drawing.Point(116, 12);
            this.textBoxPntMax.Name = "textBoxPntMax";
            this.textBoxPntMax.ReadOnly = true;
            this.textBoxPntMax.Size = new System.Drawing.Size(249, 21);
            this.textBoxPntMax.TabIndex = 22;
            // 
            // textBoxPntMin
            // 
            this.textBoxPntMin.BackColor = System.Drawing.Color.White;
            this.textBoxPntMin.Location = new System.Drawing.Point(116, 39);
            this.textBoxPntMin.Name = "textBoxPntMin";
            this.textBoxPntMin.ReadOnly = true;
            this.textBoxPntMin.Size = new System.Drawing.Size(249, 21);
            this.textBoxPntMin.TabIndex = 23;
            // 
            // textBoxFillVolume
            // 
            this.textBoxFillVolume.BackColor = System.Drawing.Color.White;
            this.textBoxFillVolume.Location = new System.Drawing.Point(116, 66);
            this.textBoxFillVolume.Name = "textBoxFillVolume";
            this.textBoxFillVolume.ReadOnly = true;
            this.textBoxFillVolume.Size = new System.Drawing.Size(249, 21);
            this.textBoxFillVolume.TabIndex = 24;
            // 
            // textBoxDigVolume
            // 
            this.textBoxDigVolume.BackColor = System.Drawing.Color.White;
            this.textBoxDigVolume.Location = new System.Drawing.Point(116, 93);
            this.textBoxDigVolume.Name = "textBoxDigVolume";
            this.textBoxDigVolume.ReadOnly = true;
            this.textBoxDigVolume.Size = new System.Drawing.Size(249, 21);
            this.textBoxDigVolume.TabIndex = 25;
            // 
            // textBoxDFVolume
            // 
            this.textBoxDFVolume.BackColor = System.Drawing.Color.White;
            this.textBoxDFVolume.Location = new System.Drawing.Point(116, 120);
            this.textBoxDFVolume.Name = "textBoxDFVolume";
            this.textBoxDFVolume.ReadOnly = true;
            this.textBoxDFVolume.Size = new System.Drawing.Size(249, 21);
            this.textBoxDFVolume.TabIndex = 26;
            // 
            // textBoxFillArea
            // 
            this.textBoxFillArea.BackColor = System.Drawing.Color.White;
            this.textBoxFillArea.Location = new System.Drawing.Point(116, 147);
            this.textBoxFillArea.Name = "textBoxFillArea";
            this.textBoxFillArea.ReadOnly = true;
            this.textBoxFillArea.Size = new System.Drawing.Size(249, 21);
            this.textBoxFillArea.TabIndex = 27;
            // 
            // textBoxDigArea
            // 
            this.textBoxDigArea.BackColor = System.Drawing.Color.White;
            this.textBoxDigArea.Location = new System.Drawing.Point(116, 174);
            this.textBoxDigArea.Name = "textBoxDigArea";
            this.textBoxDigArea.ReadOnly = true;
            this.textBoxDigArea.Size = new System.Drawing.Size(249, 21);
            this.textBoxDigArea.TabIndex = 28;
            // 
            // textBoxDFArea
            // 
            this.textBoxDFArea.BackColor = System.Drawing.Color.White;
            this.textBoxDFArea.Location = new System.Drawing.Point(116, 201);
            this.textBoxDFArea.Name = "textBoxDFArea";
            this.textBoxDFArea.ReadOnly = true;
            this.textBoxDFArea.Size = new System.Drawing.Size(249, 21);
            this.textBoxDFArea.TabIndex = 29;
            // 
            // textBoxTotalArea
            // 
            this.textBoxTotalArea.BackColor = System.Drawing.Color.White;
            this.textBoxTotalArea.Location = new System.Drawing.Point(116, 228);
            this.textBoxTotalArea.Name = "textBoxTotalArea";
            this.textBoxTotalArea.ReadOnly = true;
            this.textBoxTotalArea.Size = new System.Drawing.Size(249, 21);
            this.textBoxTotalArea.TabIndex = 30;
            // 
            // DigFillAnalysisDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 307);
            this.Controls.Add(this.textBoxTotalArea);
            this.Controls.Add(this.textBoxDFArea);
            this.Controls.Add(this.textBoxDigArea);
            this.Controls.Add(this.textBoxFillArea);
            this.Controls.Add(this.textBoxDFVolume);
            this.Controls.Add(this.textBoxDigVolume);
            this.Controls.Add(this.textBoxFillVolume);
            this.Controls.Add(this.textBoxPntMin);
            this.Controls.Add(this.textBoxPntMax);
            this.Controls.Add(this.labelTotalArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAnalyse);
            this.Controls.Add(this.textBoxDestAlt);
            this.Controls.Add(this.labelFillArea);
            this.Controls.Add(this.labelDFArea);
            this.Controls.Add(this.labelDigArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDFVolume);
            this.Controls.Add(this.labelDigVolume);
            this.Controls.Add(this.labelFillVolume);
            this.Controls.Add(this.labelMinAltPnt);
            this.Controls.Add(this.labelMaxAltPnt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "DigFillAnalysisDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "填挖方分析";
            this.Load += new System.EventHandler(this.DigFillAnalysisDlg_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DigFillAnalysisDlg_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DigFillAnalysisDlg_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAnalyse;
        private System.Windows.Forms.TextBox textBoxDestAlt;
        private System.Windows.Forms.Label labelFillArea;
        private System.Windows.Forms.Label labelDFArea;
        private System.Windows.Forms.Label labelDigArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDFVolume;
        private System.Windows.Forms.Label labelDigVolume;
        private System.Windows.Forms.Label labelFillVolume;
        private System.Windows.Forms.Label labelMinAltPnt;
        private System.Windows.Forms.Label labelMaxAltPnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalArea;
        private System.Windows.Forms.TextBox textBoxPntMax;
        private System.Windows.Forms.TextBox textBoxPntMin;
        private System.Windows.Forms.TextBox textBoxFillVolume;
        private System.Windows.Forms.TextBox textBoxDigVolume;
        private System.Windows.Forms.TextBox textBoxDFVolume;
        private System.Windows.Forms.TextBox textBoxFillArea;
        private System.Windows.Forms.TextBox textBoxDigArea;
        private System.Windows.Forms.TextBox textBoxDFArea;
        private System.Windows.Forms.TextBox textBoxTotalArea;

    }
}