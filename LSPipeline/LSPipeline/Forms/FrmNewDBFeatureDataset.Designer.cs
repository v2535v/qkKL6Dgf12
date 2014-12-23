namespace WorldGIS.Forms
{
    partial class FrmNewDBFeatureDataset
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
            this.comboBoxShpLayerList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxNewLayerName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.radioButtonUseTemplate = new System.Windows.Forms.RadioButton();
            this.radioButtonUseCustom = new System.Windows.Forms.RadioButton();
            this.panelUserTemplate = new System.Windows.Forms.Panel();
            this.panelUseCustom = new System.Windows.Forms.Panel();
            this.comboBoxFieldType = new System.Windows.Forms.ComboBox();
            this.buttonDeleteField = new System.Windows.Forms.Button();
            this.buttonAddField = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFieldPrecision = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFieldWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFieldName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFieldWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFieldPrecision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxDataSourceList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelUserTemplate.SuspendLayout();
            this.panelUseCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxShpLayerList
            // 
            this.comboBoxShpLayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShpLayerList.FormattingEnabled = true;
            this.comboBoxShpLayerList.Location = new System.Drawing.Point(88, 8);
            this.comboBoxShpLayerList.Name = "comboBoxShpLayerList";
            this.comboBoxShpLayerList.Size = new System.Drawing.Size(229, 20);
            this.comboBoxShpLayerList.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "新图层名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 75;
            this.label1.Text = "模板Shp图层：";
            // 
            // textboxNewLayerName
            // 
            this.textboxNewLayerName.Location = new System.Drawing.Point(106, 43);
            this.textboxNewLayerName.Name = "textboxNewLayerName";
            this.textboxNewLayerName.Size = new System.Drawing.Size(229, 21);
            this.textboxNewLayerName.TabIndex = 73;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(266, 443);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 23);
            this.btnClose.TabIndex = 77;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Location = new System.Drawing.Point(170, 443);
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.Size = new System.Drawing.Size(68, 23);
            this.btnCreateModel.TabIndex = 78;
            this.btnCreateModel.Text = "创建(&M)";
            this.btnCreateModel.UseVisualStyleBackColor = true;
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // radioButtonUseTemplate
            // 
            this.radioButtonUseTemplate.AutoSize = true;
            this.radioButtonUseTemplate.Location = new System.Drawing.Point(18, 76);
            this.radioButtonUseTemplate.Name = "radioButtonUseTemplate";
            this.radioButtonUseTemplate.Size = new System.Drawing.Size(119, 16);
            this.radioButtonUseTemplate.TabIndex = 79;
            this.radioButtonUseTemplate.TabStop = true;
            this.radioButtonUseTemplate.Text = "使用模板创建字段";
            this.radioButtonUseTemplate.UseVisualStyleBackColor = true;
            this.radioButtonUseTemplate.CheckedChanged += new System.EventHandler(this.radioButtonUseTemplate_CheckedChanged);
            // 
            // radioButtonUseCustom
            // 
            this.radioButtonUseCustom.AutoSize = true;
            this.radioButtonUseCustom.Location = new System.Drawing.Point(18, 147);
            this.radioButtonUseCustom.Name = "radioButtonUseCustom";
            this.radioButtonUseCustom.Size = new System.Drawing.Size(83, 16);
            this.radioButtonUseCustom.TabIndex = 80;
            this.radioButtonUseCustom.TabStop = true;
            this.radioButtonUseCustom.Text = "自定义字段";
            this.radioButtonUseCustom.UseVisualStyleBackColor = true;
            this.radioButtonUseCustom.CheckedChanged += new System.EventHandler(this.radioButtonUseCustom_CheckedChanged);
            // 
            // panelUserTemplate
            // 
            this.panelUserTemplate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelUserTemplate.Controls.Add(this.comboBoxShpLayerList);
            this.panelUserTemplate.Controls.Add(this.label1);
            this.panelUserTemplate.Location = new System.Drawing.Point(7, 98);
            this.panelUserTemplate.Name = "panelUserTemplate";
            this.panelUserTemplate.Size = new System.Drawing.Size(333, 38);
            this.panelUserTemplate.TabIndex = 81;
            // 
            // panelUseCustom
            // 
            this.panelUseCustom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelUseCustom.Controls.Add(this.comboBoxFieldType);
            this.panelUseCustom.Controls.Add(this.buttonDeleteField);
            this.panelUseCustom.Controls.Add(this.buttonAddField);
            this.panelUseCustom.Controls.Add(this.label5);
            this.panelUseCustom.Controls.Add(this.textBoxFieldPrecision);
            this.panelUseCustom.Controls.Add(this.label6);
            this.panelUseCustom.Controls.Add(this.textBoxFieldWidth);
            this.panelUseCustom.Controls.Add(this.label4);
            this.panelUseCustom.Controls.Add(this.label3);
            this.panelUseCustom.Controls.Add(this.textBoxFieldName);
            this.panelUseCustom.Controls.Add(this.dataGridView1);
            this.panelUseCustom.Location = new System.Drawing.Point(7, 169);
            this.panelUseCustom.Name = "panelUseCustom";
            this.panelUseCustom.Size = new System.Drawing.Size(333, 268);
            this.panelUseCustom.TabIndex = 82;
            // 
            // comboBoxFieldType
            // 
            this.comboBoxFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldType.FormattingEnabled = true;
            this.comboBoxFieldType.Items.AddRange(new object[] {
            "Double",
            "Int32",
            "Text",
            "Date"});
            this.comboBoxFieldType.Location = new System.Drawing.Point(84, 34);
            this.comboBoxFieldType.Name = "comboBoxFieldType";
            this.comboBoxFieldType.Size = new System.Drawing.Size(162, 20);
            this.comboBoxFieldType.TabIndex = 86;
            // 
            // buttonDeleteField
            // 
            this.buttonDeleteField.Location = new System.Drawing.Point(265, 86);
            this.buttonDeleteField.Name = "buttonDeleteField";
            this.buttonDeleteField.Size = new System.Drawing.Size(52, 23);
            this.buttonDeleteField.TabIndex = 84;
            this.buttonDeleteField.Text = "删除";
            this.buttonDeleteField.UseVisualStyleBackColor = true;
            this.buttonDeleteField.Click += new System.EventHandler(this.buttonDeleteField_Click);
            // 
            // buttonAddField
            // 
            this.buttonAddField.Location = new System.Drawing.Point(265, 59);
            this.buttonAddField.Name = "buttonAddField";
            this.buttonAddField.Size = new System.Drawing.Size(52, 23);
            this.buttonAddField.TabIndex = 83;
            this.buttonAddField.Text = "添加";
            this.buttonAddField.UseVisualStyleBackColor = true;
            this.buttonAddField.Click += new System.EventHandler(this.buttonAddField_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 82;
            this.label5.Text = "字段精度：";
            // 
            // textBoxFieldPrecision
            // 
            this.textBoxFieldPrecision.Location = new System.Drawing.Point(84, 89);
            this.textBoxFieldPrecision.Name = "textBoxFieldPrecision";
            this.textBoxFieldPrecision.Size = new System.Drawing.Size(162, 21);
            this.textBoxFieldPrecision.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 80;
            this.label6.Text = "字段长度：";
            // 
            // textBoxFieldWidth
            // 
            this.textBoxFieldWidth.Location = new System.Drawing.Point(84, 61);
            this.textBoxFieldWidth.Name = "textBoxFieldWidth";
            this.textBoxFieldWidth.Size = new System.Drawing.Size(162, 21);
            this.textBoxFieldWidth.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 78;
            this.label4.Text = "字段类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 76;
            this.label3.Text = "字段名：";
            // 
            // textBoxFieldName
            // 
            this.textBoxFieldName.Location = new System.Drawing.Point(84, 8);
            this.textBoxFieldName.Name = "textBoxFieldName";
            this.textBoxFieldName.Size = new System.Drawing.Size(162, 21);
            this.textBoxFieldName.TabIndex = 75;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFieldName,
            this.ColumnFieldType,
            this.ColumnFieldWidth,
            this.ColumnFieldPrecision});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(329, 147);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnFieldName
            // 
            this.ColumnFieldName.HeaderText = "字段名";
            this.ColumnFieldName.Name = "ColumnFieldName";
            this.ColumnFieldName.ReadOnly = true;
            this.ColumnFieldName.Width = 80;
            // 
            // ColumnFieldType
            // 
            this.ColumnFieldType.HeaderText = "字段类型";
            this.ColumnFieldType.Name = "ColumnFieldType";
            this.ColumnFieldType.ReadOnly = true;
            this.ColumnFieldType.Width = 80;
            // 
            // ColumnFieldWidth
            // 
            this.ColumnFieldWidth.HeaderText = "字段长度";
            this.ColumnFieldWidth.Name = "ColumnFieldWidth";
            this.ColumnFieldWidth.ReadOnly = true;
            this.ColumnFieldWidth.Width = 80;
            // 
            // ColumnFieldPrecision
            // 
            this.ColumnFieldPrecision.HeaderText = "字段精度";
            this.ColumnFieldPrecision.Name = "ColumnFieldPrecision";
            this.ColumnFieldPrecision.ReadOnly = true;
            this.ColumnFieldPrecision.Width = 80;
            // 
            // comboBoxDataSourceList
            // 
            this.comboBoxDataSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList.FormattingEnabled = true;
            this.comboBoxDataSourceList.Location = new System.Drawing.Point(106, 13);
            this.comboBoxDataSourceList.Name = "comboBoxDataSourceList";
            this.comboBoxDataSourceList.Size = new System.Drawing.Size(229, 20);
            this.comboBoxDataSourceList.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 84;
            this.label7.Text = "目标数据源：";
            // 
            // FrmNewDBFeatureDataset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 473);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxDataSourceList);
            this.Controls.Add(this.panelUseCustom);
            this.Controls.Add(this.panelUserTemplate);
            this.Controls.Add(this.radioButtonUseCustom);
            this.Controls.Add(this.radioButtonUseTemplate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateModel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textboxNewLayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmNewDBFeatureDataset";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在数据库中创建要素类";
            this.Load += new System.EventHandler(this.FrmNewDBFeatureDataset_Load);
            this.panelUserTemplate.ResumeLayout(false);
            this.panelUserTemplate.PerformLayout();
            this.panelUseCustom.ResumeLayout(false);
            this.panelUseCustom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxShpLayerList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxNewLayerName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.RadioButton radioButtonUseTemplate;
        private System.Windows.Forms.RadioButton radioButtonUseCustom;
        private System.Windows.Forms.Panel panelUserTemplate;
        private System.Windows.Forms.Panel panelUseCustom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFieldName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFieldPrecision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFieldWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDeleteField;
        private System.Windows.Forms.Button buttonAddField;
        private System.Windows.Forms.ComboBox comboBoxFieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFieldWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFieldPrecision;
        private System.Windows.Forms.ComboBox comboBoxDataSourceList;
        private System.Windows.Forms.Label label7;
    }
}