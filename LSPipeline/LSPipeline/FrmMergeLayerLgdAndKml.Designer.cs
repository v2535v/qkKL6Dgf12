namespace WorldGIS
{
    partial class FrmMergeLayerLgdAndKml
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
            this.textBoxLgdPath = new System.Windows.Forms.TextBox();
            this.buttonSelectLgd = new System.Windows.Forms.Button();
            this.buttonSelectKml = new System.Windows.Forms.Button();
            this.textBoxKmlPath = new System.Windows.Forms.TextBox();
            this.buttonMerge = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonSavePath = new System.Windows.Forms.Button();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxLgdPath
            // 
            this.textBoxLgdPath.Location = new System.Drawing.Point(12, 12);
            this.textBoxLgdPath.Name = "textBoxLgdPath";
            this.textBoxLgdPath.Size = new System.Drawing.Size(175, 21);
            this.textBoxLgdPath.TabIndex = 1;
            // 
            // buttonSelectLgd
            // 
            this.buttonSelectLgd.Location = new System.Drawing.Point(193, 10);
            this.buttonSelectLgd.Name = "buttonSelectLgd";
            this.buttonSelectLgd.Size = new System.Drawing.Size(87, 23);
            this.buttonSelectLgd.TabIndex = 2;
            this.buttonSelectLgd.Text = "选择lgd文件";
            this.buttonSelectLgd.UseVisualStyleBackColor = true;
            this.buttonSelectLgd.Click += new System.EventHandler(this.buttonSelectLgd_Click);
            // 
            // buttonSelectKml
            // 
            this.buttonSelectKml.Location = new System.Drawing.Point(193, 46);
            this.buttonSelectKml.Name = "buttonSelectKml";
            this.buttonSelectKml.Size = new System.Drawing.Size(87, 23);
            this.buttonSelectKml.TabIndex = 4;
            this.buttonSelectKml.Text = "选择kml文件";
            this.buttonSelectKml.UseVisualStyleBackColor = true;
            this.buttonSelectKml.Click += new System.EventHandler(this.buttonSelectKml_Click);
            // 
            // textBoxKmlPath
            // 
            this.textBoxKmlPath.Location = new System.Drawing.Point(12, 48);
            this.textBoxKmlPath.Name = "textBoxKmlPath";
            this.textBoxKmlPath.Size = new System.Drawing.Size(175, 21);
            this.textBoxKmlPath.TabIndex = 3;
            // 
            // buttonMerge
            // 
            this.buttonMerge.Location = new System.Drawing.Point(131, 113);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(56, 23);
            this.buttonMerge.TabIndex = 5;
            this.buttonMerge.Text = "合并";
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSavePath
            // 
            this.buttonSavePath.Location = new System.Drawing.Point(193, 80);
            this.buttonSavePath.Name = "buttonSavePath";
            this.buttonSavePath.Size = new System.Drawing.Size(87, 23);
            this.buttonSavePath.TabIndex = 8;
            this.buttonSavePath.Text = "保存路径...";
            this.buttonSavePath.UseVisualStyleBackColor = true;
            this.buttonSavePath.Click += new System.EventHandler(this.buttonSavePath_Click);
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Location = new System.Drawing.Point(12, 82);
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(175, 21);
            this.textBoxSavePath.TabIndex = 7;
            // 
            // FrmMergeLayerLgdAndKml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 142);
            this.Controls.Add(this.buttonSavePath);
            this.Controls.Add(this.textBoxSavePath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonMerge);
            this.Controls.Add(this.buttonSelectKml);
            this.Controls.Add(this.textBoxKmlPath);
            this.Controls.Add(this.buttonSelectLgd);
            this.Controls.Add(this.textBoxLgdPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMergeLayerLgdAndKml";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "合并Lgd和Kml图层";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLgdPath;
        private System.Windows.Forms.Button buttonSelectLgd;
        private System.Windows.Forms.Button buttonSelectKml;
        private System.Windows.Forms.TextBox textBoxKmlPath;
        private System.Windows.Forms.Button buttonMerge;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSavePath;
        private System.Windows.Forms.TextBox textBoxSavePath;
    }
}