namespace WorldGIS
{
    partial class FrmPipelineIndented
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
            this.comboBoxLayerCaption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxValueIndented = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLayerValveCaption = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxAllowance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancelHighLight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxLayerCaption
            // 
            this.comboBoxLayerCaption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayerCaption.FormattingEnabled = true;
            this.comboBoxLayerCaption.Location = new System.Drawing.Point(89, 11);
            this.comboBoxLayerCaption.Name = "comboBoxLayerCaption";
            this.comboBoxLayerCaption.Size = new System.Drawing.Size(151, 20);
            this.comboBoxLayerCaption.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "管线图层：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "缩进距离：";
            // 
            // textBoxValueIndented
            // 
            this.textBoxValueIndented.Location = new System.Drawing.Point(88, 110);
            this.textBoxValueIndented.Name = "textBoxValueIndented";
            this.textBoxValueIndented.Size = new System.Drawing.Size(150, 21);
            this.textBoxValueIndented.TabIndex = 3;
            this.textBoxValueIndented.Text = "0.3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "工井图层：";
            // 
            // comboBoxLayerValveCaption
            // 
            this.comboBoxLayerValveCaption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayerValveCaption.FormattingEnabled = true;
            this.comboBoxLayerValveCaption.Location = new System.Drawing.Point(88, 44);
            this.comboBoxLayerValveCaption.Name = "comboBoxLayerValveCaption";
            this.comboBoxLayerValveCaption.Size = new System.Drawing.Size(151, 20);
            this.comboBoxLayerValveCaption.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(192, 142);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(47, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "关闭";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxAllowance
            // 
            this.textBoxAllowance.Location = new System.Drawing.Point(88, 77);
            this.textBoxAllowance.Name = "textBoxAllowance";
            this.textBoxAllowance.Size = new System.Drawing.Size(150, 21);
            this.textBoxAllowance.TabIndex = 9;
            this.textBoxAllowance.Text = "0.3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "容限值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "米";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "米";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(113, 142);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(47, 23);
            this.buttonApply.TabIndex = 12;
            this.buttonApply.Text = "应用";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancelHighLight
            // 
            this.buttonCancelHighLight.Location = new System.Drawing.Point(18, 142);
            this.buttonCancelHighLight.Name = "buttonCancelHighLight";
            this.buttonCancelHighLight.Size = new System.Drawing.Size(63, 23);
            this.buttonCancelHighLight.TabIndex = 13;
            this.buttonCancelHighLight.Text = "取消高亮";
            this.buttonCancelHighLight.UseVisualStyleBackColor = true;
            this.buttonCancelHighLight.Click += new System.EventHandler(this.buttonCancelHighLight_Click);
            // 
            // FrmPipelineIndented
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 174);
            this.Controls.Add(this.buttonCancelHighLight);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAllowance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxLayerValveCaption);
            this.Controls.Add(this.textBoxValueIndented);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLayerCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPipelineIndented";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管线自动缩进";
            this.Load += new System.EventHandler(this.FrmPipelineIndented_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPipelineIndented_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLayerCaption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxValueIndented;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxLayerValveCaption;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxAllowance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancelHighLight;
    }
}