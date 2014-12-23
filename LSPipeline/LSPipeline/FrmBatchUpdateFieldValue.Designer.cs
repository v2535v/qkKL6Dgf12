namespace WorldGIS
{
    partial class FrmBatchUpdateFieldValue
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLayers = new System.Windows.Forms.ComboBox();
            this.radioButtonPolygonSelect = new System.Windows.Forms.RadioButton();
            this.radioButtonConditionSelect = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxUpdateFieldName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFieldValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonConditionSelect = new System.Windows.Forms.Button();
            this.comboBoxCondition = new System.Windows.Forms.ComboBox();
            this.comboBoxConditionFieldValue = new System.Windows.Forms.ComboBox();
            this.comboBoxConditionFieldName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层：";
            // 
            // comboBoxLayers
            // 
            this.comboBoxLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayers.FormattingEnabled = true;
            this.comboBoxLayers.Location = new System.Drawing.Point(68, 27);
            this.comboBoxLayers.Name = "comboBoxLayers";
            this.comboBoxLayers.Size = new System.Drawing.Size(120, 20);
            this.comboBoxLayers.TabIndex = 1;
            this.comboBoxLayers.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayers_SelectedIndexChanged);
            // 
            // radioButtonPolygonSelect
            // 
            this.radioButtonPolygonSelect.AutoSize = true;
            this.radioButtonPolygonSelect.Location = new System.Drawing.Point(15, 92);
            this.radioButtonPolygonSelect.Name = "radioButtonPolygonSelect";
            this.radioButtonPolygonSelect.Size = new System.Drawing.Size(71, 16);
            this.radioButtonPolygonSelect.TabIndex = 2;
            this.radioButtonPolygonSelect.TabStop = true;
            this.radioButtonPolygonSelect.Text = "框选查询";
            this.radioButtonPolygonSelect.UseVisualStyleBackColor = true;
            this.radioButtonPolygonSelect.Click += new System.EventHandler(this.radioButtonPolygonSelect_CheckedChanged);
            // 
            // radioButtonConditionSelect
            // 
            this.radioButtonConditionSelect.AutoSize = true;
            this.radioButtonConditionSelect.Location = new System.Drawing.Point(115, 91);
            this.radioButtonConditionSelect.Name = "radioButtonConditionSelect";
            this.radioButtonConditionSelect.Size = new System.Drawing.Size(71, 16);
            this.radioButtonConditionSelect.TabIndex = 3;
            this.radioButtonConditionSelect.TabStop = true;
            this.radioButtonConditionSelect.Text = "条件查询";
            this.radioButtonConditionSelect.UseVisualStyleBackColor = true;
            this.radioButtonConditionSelect.Click += new System.EventHandler(this.radioButtonConditionSelect_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(379, 289);
            this.dataGridView1.TabIndex = 4;
            // 
            // comboBoxUpdateFieldName
            // 
            this.comboBoxUpdateFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUpdateFieldName.FormattingEnabled = true;
            this.comboBoxUpdateFieldName.Location = new System.Drawing.Point(68, 54);
            this.comboBoxUpdateFieldName.Name = "comboBoxUpdateFieldName";
            this.comboBoxUpdateFieldName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxUpdateFieldName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "字段名：";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(297, 459);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(45, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(347, 459);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(45, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "字段值：";
            // 
            // textBoxFieldValue
            // 
            this.textBoxFieldValue.Location = new System.Drawing.Point(286, 54);
            this.textBoxFieldValue.Name = "textBoxFieldValue";
            this.textBoxFieldValue.Size = new System.Drawing.Size(105, 21);
            this.textBoxFieldValue.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "请先选择要修改的图层、图层中要修改的字段以及字段修改后的值";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonConditionSelect);
            this.panel1.Controls.Add(this.comboBoxCondition);
            this.panel1.Controls.Add(this.comboBoxConditionFieldValue);
            this.panel1.Controls.Add(this.comboBoxConditionFieldName);
            this.panel1.Location = new System.Drawing.Point(12, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 36);
            this.panel1.TabIndex = 18;
            // 
            // buttonConditionSelect
            // 
            this.buttonConditionSelect.Location = new System.Drawing.Point(327, 4);
            this.buttonConditionSelect.Name = "buttonConditionSelect";
            this.buttonConditionSelect.Size = new System.Drawing.Size(45, 23);
            this.buttonConditionSelect.TabIndex = 21;
            this.buttonConditionSelect.Text = "查询";
            this.buttonConditionSelect.UseVisualStyleBackColor = true;
            this.buttonConditionSelect.Click += new System.EventHandler(this.buttonConditionSelect_Click);
            // 
            // comboBoxCondition
            // 
            this.comboBoxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCondition.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)), true);
            this.comboBoxCondition.FormattingEnabled = true;
            this.comboBoxCondition.Items.AddRange(new object[] {
            "<",
            "<=",
            "=",
            ">",
            ">="});
            this.comboBoxCondition.Location = new System.Drawing.Point(130, 6);
            this.comboBoxCondition.Name = "comboBoxCondition";
            this.comboBoxCondition.Size = new System.Drawing.Size(56, 20);
            this.comboBoxCondition.Sorted = true;
            this.comboBoxCondition.TabIndex = 20;
            // 
            // comboBoxConditionFieldValue
            // 
            this.comboBoxConditionFieldValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConditionFieldValue.FormattingEnabled = true;
            this.comboBoxConditionFieldValue.Location = new System.Drawing.Point(192, 6);
            this.comboBoxConditionFieldValue.Name = "comboBoxConditionFieldValue";
            this.comboBoxConditionFieldValue.Size = new System.Drawing.Size(121, 20);
            this.comboBoxConditionFieldValue.TabIndex = 19;
            // 
            // comboBoxConditionFieldName
            // 
            this.comboBoxConditionFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConditionFieldName.FormattingEnabled = true;
            this.comboBoxConditionFieldName.Location = new System.Drawing.Point(3, 6);
            this.comboBoxConditionFieldName.Name = "comboBoxConditionFieldName";
            this.comboBoxConditionFieldName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxConditionFieldName.TabIndex = 18;
            this.comboBoxConditionFieldName.SelectedIndexChanged += new System.EventHandler(this.comboBoxConditionFieldName_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 11);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(245, 459);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(45, 23);
            this.buttonUpdate.TabIndex = 20;
            this.buttonUpdate.Text = "修改";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // FrmBatchUpdateFieldValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 488);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFieldValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxUpdateFieldName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.radioButtonConditionSelect);
            this.Controls.Add(this.radioButtonPolygonSelect);
            this.Controls.Add(this.comboBoxLayers);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBatchUpdateFieldValue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量修改字段值";
            this.Load += new System.EventHandler(this.FrmBatchUpdateFieldValue_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBatchUpdateFieldValue_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLayers;
        private System.Windows.Forms.RadioButton radioButtonPolygonSelect;
        private System.Windows.Forms.RadioButton radioButtonConditionSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxUpdateFieldName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFieldValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonConditionSelect;
        private System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.ComboBox comboBoxConditionFieldValue;
        private System.Windows.Forms.ComboBox comboBoxConditionFieldName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonUpdate;
    }
}