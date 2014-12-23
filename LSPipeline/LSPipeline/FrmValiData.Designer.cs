namespace WorldGIS
{
    partial class FrmValiData
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
            this.buttonVali = new System.Windows.Forms.Button();
            this.buttonExportErrorMessage = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLayerName = new System.Windows.Forms.ComboBox();
            this.cmbLayerType = new System.Windows.Forms.ComboBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonVali
            // 
            this.buttonVali.Location = new System.Drawing.Point(21, 297);
            this.buttonVali.Name = "buttonVali";
            this.buttonVali.Size = new System.Drawing.Size(75, 23);
            this.buttonVali.TabIndex = 0;
            this.buttonVali.Text = "验证";
            this.buttonVali.UseVisualStyleBackColor = true;
            this.buttonVali.Click += new System.EventHandler(this.btnVali_Click);
            // 
            // buttonExportErrorMessage
            // 
            this.buttonExportErrorMessage.Location = new System.Drawing.Point(138, 297);
            this.buttonExportErrorMessage.Name = "buttonExportErrorMessage";
            this.buttonExportErrorMessage.Size = new System.Drawing.Size(75, 23);
            this.buttonExportErrorMessage.TabIndex = 1;
            this.buttonExportErrorMessage.Text = "导出信息";
            this.buttonExportErrorMessage.UseVisualStyleBackColor = true;
            this.buttonExportErrorMessage.Click += new System.EventHandler(this.buttonXExportErrorMessage_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(269, 297);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "关闭";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "shape图层名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "图层数据类型：";
            // 
            // cmbLayerName
            // 
            this.cmbLayerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayerName.FormattingEnabled = true;
            this.cmbLayerName.Location = new System.Drawing.Point(138, 17);
            this.cmbLayerName.Name = "cmbLayerName";
            this.cmbLayerName.Size = new System.Drawing.Size(206, 20);
            this.cmbLayerName.TabIndex = 5;
            // 
            // cmbLayerType
            // 
            this.cmbLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayerType.FormattingEnabled = true;
            this.cmbLayerType.Location = new System.Drawing.Point(138, 52);
            this.cmbLayerType.Name = "cmbLayerType";
            this.cmbLayerType.Size = new System.Drawing.Size(206, 20);
            this.cmbLayerType.TabIndex = 6;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(21, 89);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(323, 198);
            this.txtMessage.TabIndex = 7;
            // 
            // FrmValiData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 331);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.cmbLayerType);
            this.Controls.Add(this.cmbLayerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExportErrorMessage);
            this.Controls.Add(this.buttonVali);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmValiData";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据验证";
            this.Load += new System.EventHandler(this.FrmValiData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVali;
        private System.Windows.Forms.Button buttonExportErrorMessage;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLayerName;
        private System.Windows.Forms.ComboBox cmbLayerType;
        private System.Windows.Forms.TextBox txtMessage;
    }
}