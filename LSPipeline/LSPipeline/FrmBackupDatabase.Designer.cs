namespace WorldGIS
{
    partial class FrmBackupDatabase
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
            this.labelDB = new System.Windows.Forms.Label();
            this.checkBoxBackupAutomatic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBackupAutomatic = new System.Windows.Forms.Panel();
            this.comboBoxBackupInterval = new System.Windows.Forms.ComboBox();
            this.comboBoxDataSourceList = new System.Windows.Forms.ComboBox();
            this.buttonBackupDB = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelBackupAutomatic.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.Location = new System.Drawing.Point(17, 20);
            this.labelDB.Name = "labelDB";
            this.labelDB.Size = new System.Drawing.Size(77, 12);
            this.labelDB.TabIndex = 2;
            this.labelDB.Text = "目标数据源：";
            // 
            // checkBoxBackupAutomatic
            // 
            this.checkBoxBackupAutomatic.AutoSize = true;
            this.checkBoxBackupAutomatic.Location = new System.Drawing.Point(255, 47);
            this.checkBoxBackupAutomatic.Name = "checkBoxBackupAutomatic";
            this.checkBoxBackupAutomatic.Size = new System.Drawing.Size(72, 16);
            this.checkBoxBackupAutomatic.TabIndex = 5;
            this.checkBoxBackupAutomatic.Text = "自动备份";
            this.checkBoxBackupAutomatic.UseVisualStyleBackColor = true;
            this.checkBoxBackupAutomatic.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "时间间隔：";
            // 
            // panelBackupAutomatic
            // 
            this.panelBackupAutomatic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBackupAutomatic.Controls.Add(this.comboBoxBackupInterval);
            this.panelBackupAutomatic.Controls.Add(this.label1);
            this.panelBackupAutomatic.Location = new System.Drawing.Point(19, 70);
            this.panelBackupAutomatic.Name = "panelBackupAutomatic";
            this.panelBackupAutomatic.Size = new System.Drawing.Size(323, 46);
            this.panelBackupAutomatic.TabIndex = 7;
            // 
            // comboBoxBackupInterval
            // 
            this.comboBoxBackupInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBackupInterval.FormattingEnabled = true;
            this.comboBoxBackupInterval.Items.AddRange(new object[] {
            "半小时",
            "一小时",
            "四小时",
            "24小时"});
            this.comboBoxBackupInterval.Location = new System.Drawing.Point(79, 10);
            this.comboBoxBackupInterval.Name = "comboBoxBackupInterval";
            this.comboBoxBackupInterval.Size = new System.Drawing.Size(227, 20);
            this.comboBoxBackupInterval.TabIndex = 7;
            // 
            // comboBoxDataSourceList
            // 
            this.comboBoxDataSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList.FormattingEnabled = true;
            this.comboBoxDataSourceList.Location = new System.Drawing.Point(100, 12);
            this.comboBoxDataSourceList.Name = "comboBoxDataSourceList";
            this.comboBoxDataSourceList.Size = new System.Drawing.Size(242, 20);
            this.comboBoxDataSourceList.TabIndex = 8;
            // 
            // buttonBackupDB
            // 
            this.buttonBackupDB.Location = new System.Drawing.Point(193, 127);
            this.buttonBackupDB.Name = "buttonBackupDB";
            this.buttonBackupDB.Size = new System.Drawing.Size(49, 23);
            this.buttonBackupDB.TabIndex = 3;
            this.buttonBackupDB.Text = "备份";
            this.buttonBackupDB.UseVisualStyleBackColor = true;
            this.buttonBackupDB.Click += new System.EventHandler(this.buttonBackupDB_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(278, 127);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(49, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FrmBackupDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 160);
            this.Controls.Add(this.comboBoxDataSourceList);
            this.Controls.Add(this.panelBackupAutomatic);
            this.Controls.Add(this.checkBoxBackupAutomatic);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonBackupDB);
            this.Controls.Add(this.labelDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmBackupDatabase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "备份SqlServer数据库";
            this.Load += new System.EventHandler(this.FrmBackupsDatabase_Load);
            this.panelBackupAutomatic.ResumeLayout(false);
            this.panelBackupAutomatic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.CheckBox checkBoxBackupAutomatic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBackupAutomatic;
        private System.Windows.Forms.ComboBox comboBoxBackupInterval;
        private System.Windows.Forms.ComboBox comboBoxDataSourceList;
        private System.Windows.Forms.Button buttonBackupDB;
        private System.Windows.Forms.Button buttonCancel;
    }
}