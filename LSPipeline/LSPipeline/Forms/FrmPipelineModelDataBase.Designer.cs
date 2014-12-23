﻿namespace WorldGIS.Forms
{
    partial class FrmPipelineModelDB
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
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCornerSliceAngle = new System.Windows.Forms.TextBox();
            this.numericUpDownLineOpaque = new System.Windows.Forms.NumericUpDown();
            this.txtSlice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbRadius = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.textBoxNewLayerName = new System.Windows.Forms.TextBox();
            this.btnPipelineColor = new System.Windows.Forms.Button();
            this.comboBoxShpLayerList = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmbID = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkDeep = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbReference = new System.Windows.Forms.ComboBox();
            this.comboBoxDataSourceList = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineOpaque)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(361, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 71;
            this.label7.Text = "度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(20, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 70;
            this.label9.Text = "拐弯平滑度：";
            // 
            // textBoxCornerSliceAngle
            // 
            this.textBoxCornerSliceAngle.Location = new System.Drawing.Point(129, 416);
            this.textBoxCornerSliceAngle.Name = "textBoxCornerSliceAngle";
            this.textBoxCornerSliceAngle.Size = new System.Drawing.Size(225, 21);
            this.textBoxCornerSliceAngle.TabIndex = 69;
            this.textBoxCornerSliceAngle.Text = "10";
            // 
            // numericUpDownLineOpaque
            // 
            this.numericUpDownLineOpaque.Location = new System.Drawing.Point(129, 339);
            this.numericUpDownLineOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownLineOpaque.Name = "numericUpDownLineOpaque";
            this.numericUpDownLineOpaque.Size = new System.Drawing.Size(225, 21);
            this.numericUpDownLineOpaque.TabIndex = 68;
            this.numericUpDownLineOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // txtSlice
            // 
            this.txtSlice.Location = new System.Drawing.Point(130, 378);
            this.txtSlice.Name = "txtSlice";
            this.txtSlice.Size = new System.Drawing.Size(224, 21);
            this.txtSlice.TabIndex = 67;
            this.txtSlice.Text = "24";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(19, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 65;
            this.label8.Text = "截面分段数：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(20, 341);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 66;
            this.label10.Text = "透明度：";
            // 
            // cmbRadius
            // 
            this.cmbRadius.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRadius.FormattingEnabled = true;
            this.cmbRadius.Location = new System.Drawing.Point(128, 229);
            this.cmbRadius.Name = "cmbRadius";
            this.cmbRadius.Size = new System.Drawing.Size(226, 20);
            this.cmbRadius.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "管道颜色：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 63;
            this.label5.Text = "管径字段：";
            // 
            // cmbTo
            // 
            this.cmbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(128, 149);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(226, 20);
            this.cmbTo.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 60;
            this.label4.Text = "终点埋深：";
            // 
            // cmbFrom
            // 
            this.cmbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(128, 116);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(226, 20);
            this.cmbFrom.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(14, 450);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 2);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "起点埋深：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 56;
            this.label2.Text = "管线图层名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "Shapefile图层：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(279, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Location = new System.Drawing.Point(130, 465);
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.Size = new System.Drawing.Size(74, 23);
            this.btnCreateModel.TabIndex = 54;
            this.btnCreateModel.Text = "建模(&M)";
            this.btnCreateModel.UseVisualStyleBackColor = true;
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // textBoxNewLayerName
            // 
            this.textBoxNewLayerName.Location = new System.Drawing.Point(128, 81);
            this.textBoxNewLayerName.Name = "textBoxNewLayerName";
            this.textBoxNewLayerName.Size = new System.Drawing.Size(226, 21);
            this.textBoxNewLayerName.TabIndex = 51;
            // 
            // btnPipelineColor
            // 
            this.btnPipelineColor.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPipelineColor.Location = new System.Drawing.Point(128, 300);
            this.btnPipelineColor.Name = "btnPipelineColor";
            this.btnPipelineColor.Size = new System.Drawing.Size(226, 23);
            this.btnPipelineColor.TabIndex = 48;
            this.btnPipelineColor.UseVisualStyleBackColor = false;
            this.btnPipelineColor.Click += new System.EventHandler(this.btnPipelineColor_Click);
            // 
            // comboBoxShpLayerList
            // 
            this.comboBoxShpLayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShpLayerList.FormattingEnabled = true;
            this.comboBoxShpLayerList.Location = new System.Drawing.Point(128, 48);
            this.comboBoxShpLayerList.Name = "comboBoxShpLayerList";
            this.comboBoxShpLayerList.Size = new System.Drawing.Size(226, 20);
            this.comboBoxShpLayerList.TabIndex = 72;
            this.comboBoxShpLayerList.SelectedIndexChanged += new System.EventHandler(this.cmbLayer_SelectedIndexChanged);
            // 
            // cmbID
            // 
            this.cmbID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbID.FormattingEnabled = true;
            this.cmbID.Location = new System.Drawing.Point(130, 265);
            this.cmbID.Name = "cmbID";
            this.cmbID.Size = new System.Drawing.Size(226, 20);
            this.cmbID.TabIndex = 74;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 73;
            this.label11.Text = "ID字段：";
            // 
            // chkDeep
            // 
            this.chkDeep.AutoSize = true;
            this.chkDeep.Location = new System.Drawing.Point(128, 175);
            this.chkDeep.Name = "chkDeep";
            this.chkDeep.Size = new System.Drawing.Size(144, 16);
            this.chkDeep.TabIndex = 75;
            this.chkDeep.Text = "埋深是否转换为相反数";
            this.chkDeep.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(356, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 76;
            this.label12.Text = "毫米";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 63;
            this.label13.Text = "埋深参考点：";
            // 
            // cmbReference
            // 
            this.cmbReference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReference.FormattingEnabled = true;
            this.cmbReference.Items.AddRange(new object[] {
            "管底",
            "管顶"});
            this.cmbReference.Location = new System.Drawing.Point(128, 196);
            this.cmbReference.Name = "cmbReference";
            this.cmbReference.Size = new System.Drawing.Size(226, 20);
            this.cmbReference.TabIndex = 64;
            // 
            // comboBoxDataSourceList
            // 
            this.comboBoxDataSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList.FormattingEnabled = true;
            this.comboBoxDataSourceList.Location = new System.Drawing.Point(126, 13);
            this.comboBoxDataSourceList.Name = "comboBoxDataSourceList";
            this.comboBoxDataSourceList.Size = new System.Drawing.Size(228, 20);
            this.comboBoxDataSourceList.TabIndex = 94;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(21, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 12);
            this.label20.TabIndex = 93;
            this.label20.Text = "目标数据源：";
            // 
            // FrmPipelineModelDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 500);
            this.Controls.Add(this.comboBoxDataSourceList);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkDeep);
            this.Controls.Add(this.cmbID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxShpLayerList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxCornerSliceAngle);
            this.Controls.Add(this.numericUpDownLineOpaque);
            this.Controls.Add(this.txtSlice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbReference);
            this.Controls.Add(this.cmbRadius);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateModel);
            this.Controls.Add(this.textBoxNewLayerName);
            this.Controls.Add(this.btnPipelineColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPipelineModelDB";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管线入库";
            this.Load += new System.EventHandler(this.FrmPipelineModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineOpaque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCornerSliceAngle;
        private System.Windows.Forms.NumericUpDown numericUpDownLineOpaque;
        private System.Windows.Forms.TextBox txtSlice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbRadius;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.TextBox textBoxNewLayerName;
        private System.Windows.Forms.Button btnPipelineColor;
        private System.Windows.Forms.ComboBox comboBoxShpLayerList;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox cmbID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkDeep;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbReference;
        private System.Windows.Forms.ComboBox comboBoxDataSourceList;
        private System.Windows.Forms.Label label20;
    }
}