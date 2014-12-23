namespace WorldGIS
{
    partial class FrmBatchUpadateFontOfMarkers
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
            this.panelPolygons = new System.Windows.Forms.Panel();
            this.comboBoxFontSize = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFontColor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelPolygons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "请选择图层：";
            // 
            // comboBoxLayers
            // 
            this.comboBoxLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayers.FormattingEnabled = true;
            this.comboBoxLayers.Location = new System.Drawing.Point(90, 17);
            this.comboBoxLayers.Name = "comboBoxLayers";
            this.comboBoxLayers.Size = new System.Drawing.Size(141, 20);
            this.comboBoxLayers.TabIndex = 26;
            // 
            // panelPolygons
            // 
            this.panelPolygons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPolygons.Controls.Add(this.comboBoxFontSize);
            this.panelPolygons.Controls.Add(this.label7);
            this.panelPolygons.Controls.Add(this.textBoxFontColor);
            this.panelPolygons.Controls.Add(this.label8);
            this.panelPolygons.Location = new System.Drawing.Point(13, 48);
            this.panelPolygons.Name = "panelPolygons";
            this.panelPolygons.Size = new System.Drawing.Size(226, 76);
            this.panelPolygons.TabIndex = 59;
            // 
            // comboBoxFontSize
            // 
            this.comboBoxFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFontSize.FormattingEnabled = true;
            this.comboBoxFontSize.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.comboBoxFontSize.Location = new System.Drawing.Point(75, 41);
            this.comboBoxFontSize.Name = "comboBoxFontSize";
            this.comboBoxFontSize.Size = new System.Drawing.Size(141, 20);
            this.comboBoxFontSize.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 53;
            this.label7.Text = "字体大小：";
            // 
            // textBoxFontColor
            // 
            this.textBoxFontColor.Location = new System.Drawing.Point(75, 9);
            this.textBoxFontColor.Name = "textBoxFontColor";
            this.textBoxFontColor.ReadOnly = true;
            this.textBoxFontColor.Size = new System.Drawing.Size(141, 21);
            this.textBoxFontColor.TabIndex = 52;
            this.textBoxFontColor.Text = "   单击获取颜色";
            this.textBoxFontColor.Click += new System.EventHandler(this.buttonFontColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 51;
            this.label8.Text = "字体颜色：";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(113, 133);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(55, 23);
            this.buttonOk.TabIndex = 44;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(183, 133);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(56, 23);
            this.buttonCancel.TabIndex = 45;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FrmBatchUpadateFontOfMarkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 164);
            this.Controls.Add(this.panelPolygons);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBatchUpadateFontOfMarkers";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量修改字体";
            this.Load += new System.EventHandler(this.FrmBatchUpadateFontOfMarkers_Load);
            this.panelPolygons.ResumeLayout(false);
            this.panelPolygons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLayers;
        private System.Windows.Forms.Panel panelPolygons;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFontColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxFontSize;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;

    }
}