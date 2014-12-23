namespace WorldGIS
{
    partial class FrmFeatureInfo
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.buttonFlyTo = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelModelName = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(197, 441);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(61, 22);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Location = new System.Drawing.Point(12, 72);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(342, 359);
            this.tabControlMain.TabIndex = 4;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.checkBox1);
            this.groupBoxMain.Controls.Add(this.buttonFlyTo);
            this.groupBoxMain.Controls.Add(this.buttonCancel);
            this.groupBoxMain.Controls.Add(this.buttonOk);
            this.groupBoxMain.Controls.Add(this.tabControlMain);
            this.groupBoxMain.Controls.Add(this.textBoxName);
            this.groupBoxMain.Controls.Add(this.labelModelName);
            this.groupBoxMain.Location = new System.Drawing.Point(9, 13);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(366, 472);
            this.groupBoxMain.TabIndex = 5;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "输入对象信息";
            // 
            // buttonFlyTo
            // 
            this.buttonFlyTo.Location = new System.Drawing.Point(130, 441);
            this.buttonFlyTo.Name = "buttonFlyTo";
            this.buttonFlyTo.Size = new System.Drawing.Size(61, 22);
            this.buttonFlyTo.TabIndex = 7;
            this.buttonFlyTo.Text = "飞过去";
            this.buttonFlyTo.UseVisualStyleBackColor = true;
            this.buttonFlyTo.Click += new System.EventHandler(this.buttonFlyTo_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(264, 441);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(61, 22);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(91, 24);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(259, 21);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelModelName
            // 
            this.labelModelName.AutoSize = true;
            this.labelModelName.Location = new System.Drawing.Point(10, 27);
            this.labelModelName.Name = "labelModelName";
            this.labelModelName.Size = new System.Drawing.Size(65, 12);
            this.labelModelName.TabIndex = 2;
            this.labelModelName.Text = "对象名称：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(272, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "显示要素";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FrmFeatureInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 498);
            this.Controls.Add(this.groupBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmFeatureInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对象信息";
            this.Load += new System.EventHandler(this.FrmFeatureInfo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFeatureInfo_FormClosing);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelModelName;
        private System.Windows.Forms.Button buttonFlyTo;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}