namespace WorldGIS
{
    partial class FrmAddMultiModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddMultiModel));
            this.checkBoxEntireDir = new System.Windows.Forms.CheckBox();
            this.checkBoxSubDir = new System.Windows.Forms.CheckBox();
            this.buttonSrcPath = new System.Windows.Forms.Button();
            this.textBoxSrcPath = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxEntireDir
            // 
            this.checkBoxEntireDir.AutoSize = true;
            this.checkBoxEntireDir.Location = new System.Drawing.Point(12, 18);
            this.checkBoxEntireDir.Name = "checkBoxEntireDir";
            this.checkBoxEntireDir.Size = new System.Drawing.Size(96, 16);
            this.checkBoxEntireDir.TabIndex = 0;
            this.checkBoxEntireDir.Text = "添加整个目录";
            this.checkBoxEntireDir.UseVisualStyleBackColor = true;
            this.checkBoxEntireDir.CheckedChanged += new System.EventHandler(this.checkBoxEntireDir_CheckedChanged);
            // 
            // checkBoxSubDir
            // 
            this.checkBoxSubDir.AutoSize = true;
            this.checkBoxSubDir.Enabled = false;
            this.checkBoxSubDir.Location = new System.Drawing.Point(125, 17);
            this.checkBoxSubDir.Name = "checkBoxSubDir";
            this.checkBoxSubDir.Size = new System.Drawing.Size(84, 16);
            this.checkBoxSubDir.TabIndex = 1;
            this.checkBoxSubDir.Text = "包含子目录";
            this.checkBoxSubDir.UseVisualStyleBackColor = true;
            // 
            // buttonSrcPath
            // 
            this.buttonSrcPath.Location = new System.Drawing.Point(9, 49);
            this.buttonSrcPath.Name = "buttonSrcPath";
            this.buttonSrcPath.Size = new System.Drawing.Size(91, 25);
            this.buttonSrcPath.TabIndex = 2;
            this.buttonSrcPath.Text = "源数据路径...";
            this.buttonSrcPath.UseVisualStyleBackColor = true;
            this.buttonSrcPath.Click += new System.EventHandler(this.buttonSrcPath_Click);
            // 
            // textBoxSrcPath
            // 
            this.textBoxSrcPath.Location = new System.Drawing.Point(106, 50);
            this.textBoxSrcPath.Name = "textBoxSrcPath";
            this.textBoxSrcPath.Size = new System.Drawing.Size(186, 21);
            this.textBoxSrcPath.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(136, 114);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(225, 114);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxSrcPath);
            this.groupBox1.Controls.Add(this.buttonSrcPath);
            this.groupBox1.Controls.Add(this.checkBoxSubDir);
            this.groupBox1.Controls.Add(this.checkBoxEntireDir);
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 98);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // FrmAddMultiModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 147);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAddMultiModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加多个模型";
            this.Load += new System.EventHandler(this.AddMultiModeDlg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxEntireDir;
        private System.Windows.Forms.CheckBox checkBoxSubDir;
        private System.Windows.Forms.Button buttonSrcPath;
        private System.Windows.Forms.TextBox textBoxSrcPath;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}