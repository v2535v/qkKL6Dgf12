namespace WorldGIS
{
    partial class FrmElevateLayer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCurrentField = new System.Windows.Forms.Label();
            this.buttonGetFieldValue = new System.Windows.Forms.Button();
            this.comboBoxFieldNames = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewFieldValues = new System.Windows.Forms.ListView();
            this.radioButtonElevatePartFeature = new System.Windows.Forms.RadioButton();
            this.radioButtonElevateAllFeature = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.cmbLayers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.radioButtonElevatePartFeature);
            this.groupBox1.Controls.Add(this.radioButtonElevateAllFeature);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.cmbLayers);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 426);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelCurrentField);
            this.panel1.Controls.Add(this.buttonGetFieldValue);
            this.panel1.Controls.Add(this.comboBoxFieldNames);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.listViewFieldValues);
            this.panel1.Location = new System.Drawing.Point(23, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 255);
            this.panel1.TabIndex = 11;
            // 
            // labelCurrentField
            // 
            this.labelCurrentField.AutoSize = true;
            this.labelCurrentField.Location = new System.Drawing.Point(15, 214);
            this.labelCurrentField.Name = "labelCurrentField";
            this.labelCurrentField.Size = new System.Drawing.Size(119, 24);
            this.labelCurrentField.TabIndex = 12;
            this.labelCurrentField.Text = "当前字段名：       \r\n当前字段值：";
            // 
            // buttonGetFieldValue
            // 
            this.buttonGetFieldValue.Location = new System.Drawing.Point(191, 6);
            this.buttonGetFieldValue.Name = "buttonGetFieldValue";
            this.buttonGetFieldValue.Size = new System.Drawing.Size(74, 23);
            this.buttonGetFieldValue.TabIndex = 11;
            this.buttonGetFieldValue.Text = "获取字段值";
            this.buttonGetFieldValue.UseVisualStyleBackColor = true;
            this.buttonGetFieldValue.Click += new System.EventHandler(this.buttonGetFieldValue_Click);
            // 
            // comboBoxFieldNames
            // 
            this.comboBoxFieldNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldNames.FormattingEnabled = true;
            this.comboBoxFieldNames.Location = new System.Drawing.Point(64, 8);
            this.comboBoxFieldNames.Name = "comboBoxFieldNames";
            this.comboBoxFieldNames.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFieldNames.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "字段名：";
            // 
            // listViewFieldValues
            // 
            this.listViewFieldValues.FullRowSelect = true;
            this.listViewFieldValues.Location = new System.Drawing.Point(16, 38);
            this.listViewFieldValues.MultiSelect = false;
            this.listViewFieldValues.Name = "listViewFieldValues";
            this.listViewFieldValues.Size = new System.Drawing.Size(249, 163);
            this.listViewFieldValues.TabIndex = 8;
            this.listViewFieldValues.UseCompatibleStateImageBehavior = false;
            this.listViewFieldValues.View = System.Windows.Forms.View.List;
            this.listViewFieldValues.SelectedIndexChanged += new System.EventHandler(this.listViewFieldValues_SelectedIndexChanged);
            // 
            // radioButtonElevatePartFeature
            // 
            this.radioButtonElevatePartFeature.AutoSize = true;
            this.radioButtonElevatePartFeature.Location = new System.Drawing.Point(116, 59);
            this.radioButtonElevatePartFeature.Name = "radioButtonElevatePartFeature";
            this.radioButtonElevatePartFeature.Size = new System.Drawing.Size(71, 16);
            this.radioButtonElevatePartFeature.TabIndex = 10;
            this.radioButtonElevatePartFeature.TabStop = true;
            this.radioButtonElevatePartFeature.Text = "部分要素";
            this.radioButtonElevatePartFeature.UseVisualStyleBackColor = true;
            this.radioButtonElevatePartFeature.CheckedChanged += new System.EventHandler(this.radioButtonElevatePartFeature_CheckedChanged);
            // 
            // radioButtonElevateAllFeature
            // 
            this.radioButtonElevateAllFeature.AutoSize = true;
            this.radioButtonElevateAllFeature.Location = new System.Drawing.Point(23, 59);
            this.radioButtonElevateAllFeature.Name = "radioButtonElevateAllFeature";
            this.radioButtonElevateAllFeature.Size = new System.Drawing.Size(71, 16);
            this.radioButtonElevateAllFeature.TabIndex = 9;
            this.radioButtonElevateAllFeature.TabStop = true;
            this.radioButtonElevateAllFeature.Text = "所有要素";
            this.radioButtonElevateAllFeature.UseVisualStyleBackColor = true;
            this.radioButtonElevateAllFeature.CheckedChanged += new System.EventHandler(this.radioButtonElevateAllFeature_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(206, 388);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(56, 388);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(95, 354);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(163, 21);
            this.txtHeight.TabIndex = 6;
            // 
            // cmbLayers
            // 
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Location = new System.Drawing.Point(86, 28);
            this.cmbLayers.Name = "cmbLayers";
            this.cmbLayers.Size = new System.Drawing.Size(202, 20);
            this.cmbLayers.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "米";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "升降高差：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "图层名称：";
            // 
            // FrmElevateLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 448);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmElevateLayer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升降模型图层";
            this.Load += new System.EventHandler(this.FrmElevateLayer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonElevatePartFeature;
        private System.Windows.Forms.RadioButton radioButtonElevateAllFeature;
        private System.Windows.Forms.ListView listViewFieldValues;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGetFieldValue;
        private System.Windows.Forms.ComboBox comboBoxFieldNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCurrentField;
    }
}