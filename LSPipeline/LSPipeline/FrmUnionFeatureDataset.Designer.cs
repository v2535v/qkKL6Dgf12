namespace WorldGIS
{
    partial class FrmUnionFeatureDataset
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxDataSourceList2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxUnionLayerList2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxDataSourceList1 = new System.Windows.Forms.ComboBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.comboBoxUnionLayerList1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxTargetDataSource = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUnionLayerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Union = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 359);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxDataSourceList2);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.comboBoxUnionLayerList2);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(12, 238);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(364, 101);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "要合并的数据集2";
            // 
            // comboBoxDataSourceList2
            // 
            this.comboBoxDataSourceList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList2.FormattingEnabled = true;
            this.comboBoxDataSourceList2.Location = new System.Drawing.Point(105, 28);
            this.comboBoxDataSourceList2.Name = "comboBoxDataSourceList2";
            this.comboBoxDataSourceList2.Size = new System.Drawing.Size(246, 20);
            this.comboBoxDataSourceList2.TabIndex = 92;
            this.comboBoxDataSourceList2.SelectedIndexChanged += new System.EventHandler(this.comboBoxDataSourceList2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 91;
            this.label2.Text = "数据源：";
            // 
            // comboBoxUnionLayerList2
            // 
            this.comboBoxUnionLayerList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnionLayerList2.FormattingEnabled = true;
            this.comboBoxUnionLayerList2.Location = new System.Drawing.Point(105, 62);
            this.comboBoxUnionLayerList2.Name = "comboBoxUnionLayerList2";
            this.comboBoxUnionLayerList2.Size = new System.Drawing.Size(246, 20);
            this.comboBoxUnionLayerList2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "合并数据集：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxDataSourceList1);
            this.groupBox3.Controls.Add(this.labelIP);
            this.groupBox3.Controls.Add(this.comboBoxUnionLayerList1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 101);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "要合并的数据集1";
            // 
            // comboBoxDataSourceList1
            // 
            this.comboBoxDataSourceList1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList1.FormattingEnabled = true;
            this.comboBoxDataSourceList1.Location = new System.Drawing.Point(105, 28);
            this.comboBoxDataSourceList1.Name = "comboBoxDataSourceList1";
            this.comboBoxDataSourceList1.Size = new System.Drawing.Size(246, 20);
            this.comboBoxDataSourceList1.TabIndex = 92;
            this.comboBoxDataSourceList1.SelectedIndexChanged += new System.EventHandler(this.comboBoxDataSourceList1_SelectedIndexChanged);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(10, 31);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(53, 12);
            this.labelIP.TabIndex = 91;
            this.labelIP.Text = "数据源：";
            // 
            // comboBoxUnionLayerList1
            // 
            this.comboBoxUnionLayerList1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnionLayerList1.FormattingEnabled = true;
            this.comboBoxUnionLayerList1.Location = new System.Drawing.Point(105, 62);
            this.comboBoxUnionLayerList1.Name = "comboBoxUnionLayerList1";
            this.comboBoxUnionLayerList1.Size = new System.Drawing.Size(246, 20);
            this.comboBoxUnionLayerList1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "合并数据集：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxTargetDataSource);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxUnionLayerName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标数据集";
            // 
            // comboBoxTargetDataSource
            // 
            this.comboBoxTargetDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTargetDataSource.FormattingEnabled = true;
            this.comboBoxTargetDataSource.Location = new System.Drawing.Point(101, 26);
            this.comboBoxTargetDataSource.Name = "comboBoxTargetDataSource";
            this.comboBoxTargetDataSource.Size = new System.Drawing.Size(246, 20);
            this.comboBoxTargetDataSource.TabIndex = 93;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 92;
            this.label4.Text = "目标数据源：";
            // 
            // textBoxUnionLayerName
            // 
            this.textBoxUnionLayerName.Location = new System.Drawing.Point(101, 64);
            this.textBoxUnionLayerName.Name = "textBoxUnionLayerName";
            this.textBoxUnionLayerName.Size = new System.Drawing.Size(246, 21);
            this.textBoxUnionLayerName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "新数据集名称：";
            // 
            // btn_Union
            // 
            this.btn_Union.Location = new System.Drawing.Point(203, 381);
            this.btn_Union.Name = "btn_Union";
            this.btn_Union.Size = new System.Drawing.Size(68, 23);
            this.btn_Union.TabIndex = 1;
            this.btn_Union.Text = "合并";
            this.btn_Union.UseVisualStyleBackColor = true;
            this.btn_Union.Click += new System.EventHandler(this.btn_Union_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(305, 381);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(68, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmUnionFeatureDataset
            // 
            this.ClientSize = new System.Drawing.Size(413, 413);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Union);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmUnionFeatureDataset";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "合并数据集";
            this.Load += new System.EventHandler(this.Frm_UnionFeatureDataSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxUnionLayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxUnionLayerList1;
        private System.Windows.Forms.Button btn_Union;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ComboBox comboBoxTargetDataSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxDataSourceList2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxUnionLayerList2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxDataSourceList1;
        private System.Windows.Forms.Label labelIP;
    }
}