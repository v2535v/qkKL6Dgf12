namespace WorldGIS
{
    partial class FrmCreateGenTopo
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
            this.comboBoxDataSourceList = new System.Windows.Forms.ComboBox();
            this.checkBoxIgnoreZ = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTolerance = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.comboBoxDBLayerList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxUnionValve = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTopoName = new System.Windows.Forms.TextBox();
            this.panelValve = new System.Windows.Forms.Panel();
            this.checkBoxClearValves = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxMatchNearest = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNearestDistLimit = new System.Windows.Forms.TextBox();
            this.comboBoxDBValveList = new System.Windows.Forms.ComboBox();
            this.checkBoxValveIgnoreZ = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxValveTolerance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelValve.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDataSourceList
            // 
            this.comboBoxDataSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList.FormattingEnabled = true;
            this.comboBoxDataSourceList.Location = new System.Drawing.Point(100, 12);
            this.comboBoxDataSourceList.Name = "comboBoxDataSourceList";
            this.comboBoxDataSourceList.Size = new System.Drawing.Size(229, 20);
            this.comboBoxDataSourceList.Sorted = true;
            this.comboBoxDataSourceList.TabIndex = 1;
            this.comboBoxDataSourceList.SelectedIndexChanged += new System.EventHandler(this.cbbDataSource_SelectedIndexChanged);
            // 
            // checkBoxIgnoreZ
            // 
            this.checkBoxIgnoreZ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxIgnoreZ.AutoSize = true;
            this.checkBoxIgnoreZ.Location = new System.Drawing.Point(246, 119);
            this.checkBoxIgnoreZ.Name = "checkBoxIgnoreZ";
            this.checkBoxIgnoreZ.Size = new System.Drawing.Size(78, 16);
            this.checkBoxIgnoreZ.TabIndex = 3;
            this.checkBoxIgnoreZ.Text = "不考虑z值";
            this.checkBoxIgnoreZ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxIgnoreZ.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "误差容限(米)：";
            // 
            // textBoxTolerance
            // 
            this.textBoxTolerance.Location = new System.Drawing.Point(100, 83);
            this.textBoxTolerance.Name = "textBoxTolerance";
            this.textBoxTolerance.Size = new System.Drawing.Size(226, 21);
            this.textBoxTolerance.TabIndex = 0;
            this.textBoxTolerance.Text = "0.1";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(291, 439);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(61, 22);
            this.buttonCancel.TabIndex = 80;
            this.buttonCancel.Text = "退出";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(183, 439);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(61, 22);
            this.buttonOk.TabIndex = 79;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // comboBoxDBLayerList
            // 
            this.comboBoxDBLayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDBLayerList.FormattingEnabled = true;
            this.comboBoxDBLayerList.Location = new System.Drawing.Point(100, 47);
            this.comboBoxDBLayerList.Name = "comboBoxDBLayerList";
            this.comboBoxDBLayerList.Size = new System.Drawing.Size(229, 20);
            this.comboBoxDBLayerList.Sorted = true;
            this.comboBoxDBLayerList.TabIndex = 2;
            this.comboBoxDBLayerList.SelectedIndexChanged += new System.EventHandler(this.cbbLayers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 83;
            this.label2.Text = "目标数据源：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 84;
            this.label4.Text = "图层名称：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.checkBoxUnionValve);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxTopoName);
            this.panel1.Controls.Add(this.comboBoxDataSourceList);
            this.panel1.Controls.Add(this.checkBoxIgnoreZ);
            this.panel1.Controls.Add(this.comboBoxDBLayerList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxTolerance);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 210);
            this.panel1.TabIndex = 85;
            // 
            // checkBoxUnionValve
            // 
            this.checkBoxUnionValve.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxUnionValve.AutoSize = true;
            this.checkBoxUnionValve.Location = new System.Drawing.Point(254, 187);
            this.checkBoxUnionValve.Name = "checkBoxUnionValve";
            this.checkBoxUnionValve.Size = new System.Drawing.Size(72, 16);
            this.checkBoxUnionValve.TabIndex = 87;
            this.checkBoxUnionValve.Text = "关联阀门";
            this.checkBoxUnionValve.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxUnionValve.UseVisualStyleBackColor = true;
            this.checkBoxUnionValve.CheckedChanged += new System.EventHandler(this.checkUnionFamen_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 86;
            this.label5.Text = "拓扑图层名称：";
            // 
            // textBoxTopoName
            // 
            this.textBoxTopoName.Location = new System.Drawing.Point(100, 148);
            this.textBoxTopoName.Name = "textBoxTopoName";
            this.textBoxTopoName.ReadOnly = true;
            this.textBoxTopoName.Size = new System.Drawing.Size(226, 21);
            this.textBoxTopoName.TabIndex = 85;
            // 
            // panelValve
            // 
            this.panelValve.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelValve.Controls.Add(this.checkBoxClearValves);
            this.panelValve.Controls.Add(this.label9);
            this.panelValve.Controls.Add(this.checkBoxMatchNearest);
            this.panelValve.Controls.Add(this.label3);
            this.panelValve.Controls.Add(this.textBoxNearestDistLimit);
            this.panelValve.Controls.Add(this.comboBoxDBValveList);
            this.panelValve.Controls.Add(this.checkBoxValveIgnoreZ);
            this.panelValve.Controls.Add(this.label6);
            this.panelValve.Controls.Add(this.textBoxValveTolerance);
            this.panelValve.Controls.Add(this.label8);
            this.panelValve.Location = new System.Drawing.Point(12, 228);
            this.panelValve.Name = "panelValve";
            this.panelValve.Size = new System.Drawing.Size(340, 200);
            this.panelValve.TabIndex = 86;
            // 
            // checkBoxClearValves
            // 
            this.checkBoxClearValves.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxClearValves.AutoSize = true;
            this.checkBoxClearValves.Location = new System.Drawing.Point(38, 165);
            this.checkBoxClearValves.Name = "checkBoxClearValves";
            this.checkBoxClearValves.Size = new System.Drawing.Size(192, 16);
            this.checkBoxClearValves.TabIndex = 89;
            this.checkBoxClearValves.Text = "匹配之前清理掉以前的阀门信息";
            this.checkBoxClearValves.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxClearValves.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 88;
            this.label9.Text = "米";
            // 
            // checkBoxMatchNearest
            // 
            this.checkBoxMatchNearest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxMatchNearest.AutoSize = true;
            this.checkBoxMatchNearest.Location = new System.Drawing.Point(38, 108);
            this.checkBoxMatchNearest.Name = "checkBoxMatchNearest";
            this.checkBoxMatchNearest.Size = new System.Drawing.Size(180, 16);
            this.checkBoxMatchNearest.TabIndex = 87;
            this.checkBoxMatchNearest.Text = "如果没有找到则用最近点匹配";
            this.checkBoxMatchNearest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxMatchNearest.UseVisualStyleBackColor = true;
            this.checkBoxMatchNearest.CheckedChanged += new System.EventHandler(this.checkBoxMatchNearest_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 86;
            this.label3.Text = "最近点距离不能超过：";
            // 
            // textBoxNearestDistLimit
            // 
            this.textBoxNearestDistLimit.Location = new System.Drawing.Point(187, 133);
            this.textBoxNearestDistLimit.Name = "textBoxNearestDistLimit";
            this.textBoxNearestDistLimit.Size = new System.Drawing.Size(69, 21);
            this.textBoxNearestDistLimit.TabIndex = 85;
            this.textBoxNearestDistLimit.Text = "0.2";
            // 
            // comboBoxDBValveList
            // 
            this.comboBoxDBValveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDBValveList.FormattingEnabled = true;
            this.comboBoxDBValveList.Location = new System.Drawing.Point(100, 12);
            this.comboBoxDBValveList.Name = "comboBoxDBValveList";
            this.comboBoxDBValveList.Size = new System.Drawing.Size(229, 20);
            this.comboBoxDBValveList.Sorted = true;
            this.comboBoxDBValveList.TabIndex = 1;
            // 
            // checkBoxValveIgnoreZ
            // 
            this.checkBoxValveIgnoreZ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxValveIgnoreZ.AutoSize = true;
            this.checkBoxValveIgnoreZ.Location = new System.Drawing.Point(221, 81);
            this.checkBoxValveIgnoreZ.Name = "checkBoxValveIgnoreZ";
            this.checkBoxValveIgnoreZ.Size = new System.Drawing.Size(78, 16);
            this.checkBoxValveIgnoreZ.TabIndex = 3;
            this.checkBoxValveIgnoreZ.Text = "不考虑z值";
            this.checkBoxValveIgnoreZ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxValveIgnoreZ.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "误差容限(米)：";
            // 
            // textBoxValveTolerance
            // 
            this.textBoxValveTolerance.Location = new System.Drawing.Point(100, 43);
            this.textBoxValveTolerance.Name = "textBoxValveTolerance";
            this.textBoxValveTolerance.Size = new System.Drawing.Size(226, 21);
            this.textBoxValveTolerance.TabIndex = 0;
            this.textBoxValveTolerance.Text = "0.1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 83;
            this.label8.Text = "阀门图层名称：";
            // 
            // FrmCreateGenTopo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 471);
            this.Controls.Add(this.panelValve);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmCreateGenTopo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建拓扑";
            this.Load += new System.EventHandler(this.FrmGenTopo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelValve.ResumeLayout(false);
            this.panelValve.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDataSourceList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTolerance;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkBoxIgnoreZ;
        private System.Windows.Forms.ComboBox comboBoxDBLayerList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTopoName;
        private System.Windows.Forms.CheckBox checkBoxUnionValve;
        private System.Windows.Forms.Panel panelValve;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxMatchNearest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNearestDistLimit;
        private System.Windows.Forms.ComboBox comboBoxDBValveList;
        private System.Windows.Forms.CheckBox checkBoxValveIgnoreZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxValveTolerance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxClearValves;
    }
}