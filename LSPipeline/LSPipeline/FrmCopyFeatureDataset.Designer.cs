namespace WorldGIS
{
    partial class FrmCopyFeatureDataset
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxTargetDataSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxCopyOne = new System.Windows.Forms.GroupBox();
            this.textboxNewLayerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBoxDataSourceList = new System.Windows.Forms.ComboBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.listBoxCopyLayerList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBoxCopyMult = new System.Windows.Forms.RadioButton();
            this.checkBoxCopyOne = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxCopyOne.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(11, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 350);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxCopyOne);
            this.groupBox2.Controls.Add(this.checkBoxCopyMult);
            this.groupBox2.Controls.Add(this.comboBoxTargetDataSource);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBoxCopyOne);
            this.groupBox2.Location = new System.Drawing.Point(362, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 323);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "要复制到的数据源";
            // 
            // comboBoxTargetDataSource
            // 
            this.comboBoxTargetDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTargetDataSource.FormattingEnabled = true;
            this.comboBoxTargetDataSource.Location = new System.Drawing.Point(4, 42);
            this.comboBoxTargetDataSource.Name = "comboBoxTargetDataSource";
            this.comboBoxTargetDataSource.Size = new System.Drawing.Size(246, 20);
            this.comboBoxTargetDataSource.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "目标数据源：";
            // 
            // groupBoxCopyOne
            // 
            this.groupBoxCopyOne.Controls.Add(this.textboxNewLayerName);
            this.groupBoxCopyOne.Controls.Add(this.label5);
            this.groupBoxCopyOne.Location = new System.Drawing.Point(8, 192);
            this.groupBoxCopyOne.Name = "groupBoxCopyOne";
            this.groupBoxCopyOne.Size = new System.Drawing.Size(242, 117);
            this.groupBoxCopyOne.TabIndex = 11;
            this.groupBoxCopyOne.TabStop = false;
            this.groupBoxCopyOne.Text = "数据库要素集";
            // 
            // textboxNewLayerName
            // 
            this.textboxNewLayerName.Location = new System.Drawing.Point(14, 68);
            this.textboxNewLayerName.Name = "textboxNewLayerName";
            this.textboxNewLayerName.Size = new System.Drawing.Size(212, 21);
            this.textboxNewLayerName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "新数据集名称：";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxDataSourceList);
            this.groupBox6.Controls.Add(this.labelIP);
            this.groupBox6.Controls.Add(this.listBoxCopyLayerList);
            this.groupBox6.Location = new System.Drawing.Point(14, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(261, 323);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "要复制的数据源及数据";
            // 
            // comboBoxDataSourceList
            // 
            this.comboBoxDataSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList.FormattingEnabled = true;
            this.comboBoxDataSourceList.Location = new System.Drawing.Point(3, 41);
            this.comboBoxDataSourceList.Name = "comboBoxDataSourceList";
            this.comboBoxDataSourceList.Size = new System.Drawing.Size(255, 20);
            this.comboBoxDataSourceList.TabIndex = 90;
            this.comboBoxDataSourceList.SelectedIndexChanged += new System.EventHandler(this.comboBoxDataSourceList_SelectedIndexChanged);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(3, 25);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(53, 12);
            this.labelIP.TabIndex = 89;
            this.labelIP.Text = "数据源：";
            // 
            // listBoxCopyLayerList
            // 
            this.listBoxCopyLayerList.FormattingEnabled = true;
            this.listBoxCopyLayerList.ItemHeight = 12;
            this.listBoxCopyLayerList.Location = new System.Drawing.Point(3, 76);
            this.listBoxCopyLayerList.Name = "listBoxCopyLayerList";
            this.listBoxCopyLayerList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCopyLayerList.Size = new System.Drawing.Size(255, 244);
            this.listBoxCopyLayerList.Sorted = true;
            this.listBoxCopyLayerList.TabIndex = 0;
            this.listBoxCopyLayerList.SelectedIndexChanged += new System.EventHandler(this.listBoxCopyLayerList_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "数据库对接";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "_____________";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(568, 370);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(55, 23);
            this.btn_Cancel.TabIndex = 15;
            this.btn_Cancel.Text = "关闭";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(482, 370);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(51, 23);
            this.buttonApply.TabIndex = 13;
            this.buttonApply.Text = "应用";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 370);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(348, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // checkBoxCopyMult
            // 
            this.checkBoxCopyMult.AutoSize = true;
            this.checkBoxCopyMult.Location = new System.Drawing.Point(22, 90);
            this.checkBoxCopyMult.Name = "checkBoxCopyMult";
            this.checkBoxCopyMult.Size = new System.Drawing.Size(71, 16);
            this.checkBoxCopyMult.TabIndex = 92;
            this.checkBoxCopyMult.TabStop = true;
            this.checkBoxCopyMult.Text = "复制多个";
            this.checkBoxCopyMult.UseVisualStyleBackColor = true;
            this.checkBoxCopyMult.CheckedChanged += new System.EventHandler(this.checkBoxCopyMult_CheckedChanged);
            // 
            // checkBoxCopyOne
            // 
            this.checkBoxCopyOne.AutoSize = true;
            this.checkBoxCopyOne.Location = new System.Drawing.Point(22, 140);
            this.checkBoxCopyOne.Name = "checkBoxCopyOne";
            this.checkBoxCopyOne.Size = new System.Drawing.Size(71, 16);
            this.checkBoxCopyOne.TabIndex = 93;
            this.checkBoxCopyOne.TabStop = true;
            this.checkBoxCopyOne.Text = "复制单个";
            this.checkBoxCopyOne.UseVisualStyleBackColor = true;
            this.checkBoxCopyOne.CheckedChanged += new System.EventHandler(this.checkBoxCopyOne_CheckedChanged);
            // 
            // FrmCopyFeatureDataset
            // 
            this.ClientSize = new System.Drawing.Size(654, 405);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCopyFeatureDataset";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "复制要素数据集";
            this.Load += new System.EventHandler(this.Frm_CopyFeatureDataSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxCopyOne.ResumeLayout(false);
            this.groupBoxCopyOne.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxCopyOne;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textboxNewLayerName;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox listBoxCopyLayerList;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDataSourceList;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.ComboBox comboBoxTargetDataSource;
        private System.Windows.Forms.RadioButton checkBoxCopyOne;
        private System.Windows.Forms.RadioButton checkBoxCopyMult;
    }
}