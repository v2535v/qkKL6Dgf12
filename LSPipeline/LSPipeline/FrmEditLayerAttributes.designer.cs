namespace WorldGIS
{
    partial class FrmEditLayerAttributes
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
            this.buttonDelAttribute = new System.Windows.Forms.Button();
            this.labelAttributeType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAttribute = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxAddAttributeName = new System.Windows.Forms.TextBox();
            this.comboBoxAddAttributeType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddAttribute = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDelAttribute);
            this.groupBox1.Controls.Add(this.labelAttributeType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBoxAttribute);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性浏览";
            // 
            // buttonDelAttribute
            // 
            this.buttonDelAttribute.Location = new System.Drawing.Point(225, 162);
            this.buttonDelAttribute.Name = "buttonDelAttribute";
            this.buttonDelAttribute.Size = new System.Drawing.Size(68, 23);
            this.buttonDelAttribute.TabIndex = 3;
            this.buttonDelAttribute.Text = "删除";
            this.buttonDelAttribute.UseVisualStyleBackColor = true;
            this.buttonDelAttribute.Click += new System.EventHandler(this.buttonDelAttribute_Click);
            // 
            // labelAttributeType
            // 
            this.labelAttributeType.AutoSize = true;
            this.labelAttributeType.Location = new System.Drawing.Point(6, 170);
            this.labelAttributeType.Name = "labelAttributeType";
            this.labelAttributeType.Size = new System.Drawing.Size(0, 12);
            this.labelAttributeType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "图层属性字段：";
            // 
            // listBoxAttribute
            // 
            this.listBoxAttribute.FormattingEnabled = true;
            this.listBoxAttribute.ItemHeight = 12;
            this.listBoxAttribute.Location = new System.Drawing.Point(8, 32);
            this.listBoxAttribute.Name = "listBoxAttribute";
            this.listBoxAttribute.Size = new System.Drawing.Size(285, 124);
            this.listBoxAttribute.TabIndex = 0;
            this.listBoxAttribute.SelectedIndexChanged += new System.EventHandler(this.listBoxAttribute_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.buttonAddAttribute);
            this.groupBox2.Location = new System.Drawing.Point(13, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 153);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "属性编辑";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxAddAttributeName);
            this.groupBox4.Controls.Add(this.comboBoxAddAttributeType);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(8, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 89);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "添加";
            // 
            // textBoxAddAttributeName
            // 
            this.textBoxAddAttributeName.Location = new System.Drawing.Point(77, 23);
            this.textBoxAddAttributeName.Name = "textBoxAddAttributeName";
            this.textBoxAddAttributeName.Size = new System.Drawing.Size(199, 21);
            this.textBoxAddAttributeName.TabIndex = 4;
            // 
            // comboBoxAddAttributeType
            // 
            this.comboBoxAddAttributeType.FormattingEnabled = true;
            this.comboBoxAddAttributeType.Items.AddRange(new object[] {
            "String",
            "Double",
            "int",
            "Date"});
            this.comboBoxAddAttributeType.Location = new System.Drawing.Point(77, 56);
            this.comboBoxAddAttributeType.Name = "comboBoxAddAttributeType";
            this.comboBoxAddAttributeType.Size = new System.Drawing.Size(200, 20);
            this.comboBoxAddAttributeType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "属性类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "属性名称：";
            // 
            // buttonAddAttribute
            // 
            this.buttonAddAttribute.Location = new System.Drawing.Point(225, 115);
            this.buttonAddAttribute.Name = "buttonAddAttribute";
            this.buttonAddAttribute.Size = new System.Drawing.Size(68, 23);
            this.buttonAddAttribute.TabIndex = 2;
            this.buttonAddAttribute.Text = "添加";
            this.buttonAddAttribute.UseVisualStyleBackColor = true;
            this.buttonAddAttribute.Click += new System.EventHandler(this.buttonAddAttribute_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(98, 375);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(107, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "关闭";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Frm_EditorAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 410);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_EditorAttributes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "属性字段";
            this.Load += new System.EventHandler(this.Frm_EditorAttributes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAttribute;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxAddAttributeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddAttribute;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxAddAttributeName;
        private System.Windows.Forms.Label labelAttributeType;
        private System.Windows.Forms.Button buttonDelAttribute;
    }
}