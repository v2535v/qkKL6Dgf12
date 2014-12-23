namespace WorldGIS.Forms
{
    partial class FrmShp2KML
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
            this.cmbLayer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.txtModelLayer = new System.Windows.Forms.TextBox();
            this.btnBrowseModel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.listFields = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combLabel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLayer
            // 
            this.cmbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayer.FormattingEnabled = true;
            this.cmbLayer.Location = new System.Drawing.Point(142, 18);
            this.cmbLayer.Name = "cmbLayer";
            this.cmbLayer.Size = new System.Drawing.Size(226, 20);
            this.cmbLayer.TabIndex = 98;
            this.cmbLayer.SelectedIndexChanged += new System.EventHandler(this.cmbLayer_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(33, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 94;
            this.label8.Text = "气泡高度：";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(28, 432);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 2);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 82;
            this.label3.Text = "导出字段：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 83;
            this.label2.Text = "KML、LGD文件：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 84;
            this.label1.Text = "Shapefile图层：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(293, 443);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 80;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Location = new System.Drawing.Point(210, 443);
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.Size = new System.Drawing.Size(74, 23);
            this.btnCreateModel.TabIndex = 81;
            this.btnCreateModel.Text = "转换(&M)";
            this.btnCreateModel.UseVisualStyleBackColor = true;
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // txtModelLayer
            // 
            this.txtModelLayer.Location = new System.Drawing.Point(142, 51);
            this.txtModelLayer.Name = "txtModelLayer";
            this.txtModelLayer.Size = new System.Drawing.Size(226, 21);
            this.txtModelLayer.TabIndex = 79;
            // 
            // btnBrowseModel
            // 
            this.btnBrowseModel.Location = new System.Drawing.Point(380, 50);
            this.btnBrowseModel.Name = "btnBrowseModel";
            this.btnBrowseModel.Size = new System.Drawing.Size(34, 23);
            this.btnBrowseModel.TabIndex = 78;
            this.btnBrowseModel.Text = "...";
            this.btnBrowseModel.UseVisualStyleBackColor = true;
            this.btnBrowseModel.Click += new System.EventHandler(this.btnBrowseModel_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(34, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 95;
            this.label10.Text = "气泡宽度：";
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(143, 363);
            this.numWidth.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(225, 21);
            this.numWidth.TabIndex = 97;
            this.numWidth.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(143, 400);
            this.numHeight.Maximum = new decimal(new int[] {
            1255,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(225, 21);
            this.numHeight.TabIndex = 99;
            this.numHeight.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // listFields
            // 
            this.listFields.FormattingEnabled = true;
            this.listFields.Location = new System.Drawing.Point(142, 135);
            this.listFields.Name = "listFields";
            this.listFields.Size = new System.Drawing.Size(226, 212);
            this.listFields.TabIndex = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 83;
            this.label4.Text = "标注字段：";
            // 
            // combLabel
            // 
            this.combLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combLabel.FormattingEnabled = true;
            this.combLabel.Location = new System.Drawing.Point(143, 91);
            this.combLabel.Name = "combLabel";
            this.combLabel.Size = new System.Drawing.Size(226, 20);
            this.combLabel.TabIndex = 98;
            this.combLabel.SelectedIndexChanged += new System.EventHandler(this.combLabel_SelectedIndexChanged);
            // 
            // FrmShp2KML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 473);
            this.Controls.Add(this.listFields);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.combLabel);
            this.Controls.Add(this.cmbLayer);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateModel);
            this.Controls.Add(this.txtModelLayer);
            this.Controls.Add(this.btnBrowseModel);
            this.Name = "FrmShp2KML";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "shp转kml、lgd工具";
            this.Load += new System.EventHandler(this.FrmPipelineModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLayer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.TextBox txtModelLayer;
        private System.Windows.Forms.Button btnBrowseModel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.CheckedListBox listFields;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combLabel;
    }
}