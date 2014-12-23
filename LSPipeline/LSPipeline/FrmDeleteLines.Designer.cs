namespace WorldGIS
{
    partial class FrmDeleteLines
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
            this.textBoxLayerPath = new System.Windows.Forms.TextBox();
            this.buttonLayerPath = new System.Windows.Forms.Button();
            this.textBoxFeatureMaxLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFeatureMinLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxFeatureCount = new System.Windows.Forms.CheckBox();
            this.panelFeatureCount = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFeatureCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelFeatureCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标文件：";
            // 
            // textBoxLayerPath
            // 
            this.textBoxLayerPath.Location = new System.Drawing.Point(81, 14);
            this.textBoxLayerPath.Name = "textBoxLayerPath";
            this.textBoxLayerPath.Size = new System.Drawing.Size(206, 21);
            this.textBoxLayerPath.TabIndex = 1;
            // 
            // buttonLayerPath
            // 
            this.buttonLayerPath.Location = new System.Drawing.Point(295, 14);
            this.buttonLayerPath.Name = "buttonLayerPath";
            this.buttonLayerPath.Size = new System.Drawing.Size(54, 23);
            this.buttonLayerPath.TabIndex = 2;
            this.buttonLayerPath.Text = "...";
            this.buttonLayerPath.UseVisualStyleBackColor = true;
            this.buttonLayerPath.Click += new System.EventHandler(this.buttonLayerPath_Click);
            // 
            // textBoxFeatureMaxLength
            // 
            this.textBoxFeatureMaxLength.Location = new System.Drawing.Point(178, 82);
            this.textBoxFeatureMaxLength.Name = "textBoxFeatureMaxLength";
            this.textBoxFeatureMaxLength.Size = new System.Drawing.Size(109, 21);
            this.textBoxFeatureMaxLength.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "删除要素的最大长度：";
            // 
            // textBoxFeatureMinLength
            // 
            this.textBoxFeatureMinLength.Location = new System.Drawing.Point(178, 48);
            this.textBoxFeatureMinLength.Name = "textBoxFeatureMinLength";
            this.textBoxFeatureMinLength.Size = new System.Drawing.Size(109, 21);
            this.textBoxFeatureMinLength.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "删除要素的最小长度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "米";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "米";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(233, 192);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(54, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(293, 192);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(54, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxFeatureCount
            // 
            this.checkBoxFeatureCount.AutoSize = true;
            this.checkBoxFeatureCount.Location = new System.Drawing.Point(178, 119);
            this.checkBoxFeatureCount.Name = "checkBoxFeatureCount";
            this.checkBoxFeatureCount.Size = new System.Drawing.Size(96, 16);
            this.checkBoxFeatureCount.TabIndex = 11;
            this.checkBoxFeatureCount.Text = "限制要素个数";
            this.checkBoxFeatureCount.UseVisualStyleBackColor = true;
            this.checkBoxFeatureCount.CheckedChanged += new System.EventHandler(this.checkBoxFeatureCount_CheckedChanged);
            // 
            // panelFeatureCount
            // 
            this.panelFeatureCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFeatureCount.Controls.Add(this.label6);
            this.panelFeatureCount.Controls.Add(this.textBoxFeatureCount);
            this.panelFeatureCount.Controls.Add(this.label7);
            this.panelFeatureCount.Location = new System.Drawing.Point(12, 142);
            this.panelFeatureCount.Name = "panelFeatureCount";
            this.panelFeatureCount.Size = new System.Drawing.Size(338, 35);
            this.panelFeatureCount.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "个";
            // 
            // textBoxFeatureCount
            // 
            this.textBoxFeatureCount.Location = new System.Drawing.Point(164, 5);
            this.textBoxFeatureCount.Name = "textBoxFeatureCount";
            this.textBoxFeatureCount.Size = new System.Drawing.Size(109, 21);
            this.textBoxFeatureCount.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "最大要素个数：";
            // 
            // FrmDeleteLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 225);
            this.Controls.Add(this.panelFeatureCount);
            this.Controls.Add(this.checkBoxFeatureCount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFeatureMinLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFeatureMaxLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonLayerPath);
            this.Controls.Add(this.textBoxLayerPath);
            this.Controls.Add(this.label1);
            this.Name = "FrmDeleteLines";
            this.ShowIcon = false;
            this.Text = "条件删除管线";
            this.Load += new System.EventHandler(this.FrmDeleteLines_Load);
            this.panelFeatureCount.ResumeLayout(false);
            this.panelFeatureCount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLayerPath;
        private System.Windows.Forms.Button buttonLayerPath;
        private System.Windows.Forms.TextBox textBoxFeatureMaxLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFeatureMinLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxFeatureCount;
        private System.Windows.Forms.Panel panelFeatureCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFeatureCount;
        private System.Windows.Forms.Label label7;
    }
}