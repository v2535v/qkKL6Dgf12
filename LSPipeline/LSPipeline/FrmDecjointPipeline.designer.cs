namespace WorldGIS
{
    partial class FrmDecjointPipeline
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
            this.buttOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxTailDecValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxHeadDecValue = new System.Windows.Forms.TextBox();
            this.cboxHead = new System.Windows.Forms.CheckBox();
            this.cboxTail = new System.Windows.Forms.CheckBox();
            this.buttCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttOk
            // 
            this.buttOk.Location = new System.Drawing.Point(55, 130);
            this.buttOk.Name = "buttOk";
            this.buttOk.Size = new System.Drawing.Size(53, 23);
            this.buttOk.TabIndex = 4;
            this.buttOk.Text = "确定";
            this.buttOk.UseVisualStyleBackColor = true;
            this.buttOk.Click += new System.EventHandler(this.buttOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tBoxTailDecValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tBoxHeadDecValue);
            this.groupBox1.Controls.Add(this.cboxHead);
            this.groupBox1.Controls.Add(this.cboxTail);
            this.groupBox1.Location = new System.Drawing.Point(19, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 107);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "米";
            // 
            // tBoxTailDecValue
            // 
            this.tBoxTailDecValue.Location = new System.Drawing.Point(111, 63);
            this.tBoxTailDecValue.Name = "tBoxTailDecValue";
            this.tBoxTailDecValue.Size = new System.Drawing.Size(62, 21);
            this.tBoxTailDecValue.TabIndex = 5;
            this.tBoxTailDecValue.TextChanged += new System.EventHandler(this.tBoxTailDecValue_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "米";
            // 
            // tBoxHeadDecValue
            // 
            this.tBoxHeadDecValue.Location = new System.Drawing.Point(111, 32);
            this.tBoxHeadDecValue.Name = "tBoxHeadDecValue";
            this.tBoxHeadDecValue.Size = new System.Drawing.Size(62, 21);
            this.tBoxHeadDecValue.TabIndex = 2;
            this.tBoxHeadDecValue.TextChanged += new System.EventHandler(this.tBoxHeadDecValue_TextChanged);
            // 
            // cboxHead
            // 
            this.cboxHead.AutoSize = true;
            this.cboxHead.Location = new System.Drawing.Point(33, 36);
            this.cboxHead.Name = "cboxHead";
            this.cboxHead.Size = new System.Drawing.Size(72, 16);
            this.cboxHead.TabIndex = 0;
            this.cboxHead.Text = "头部缩进";
            this.cboxHead.UseVisualStyleBackColor = true;
            this.cboxHead.CheckedChanged += new System.EventHandler(this.cboxHead_CheckedChanged);
            // 
            // cboxTail
            // 
            this.cboxTail.AutoSize = true;
            this.cboxTail.Location = new System.Drawing.Point(33, 68);
            this.cboxTail.Name = "cboxTail";
            this.cboxTail.Size = new System.Drawing.Size(72, 16);
            this.cboxTail.TabIndex = 1;
            this.cboxTail.Text = "尾部缩进";
            this.cboxTail.UseVisualStyleBackColor = true;
            this.cboxTail.CheckedChanged += new System.EventHandler(this.cboxTail_CheckedChanged);
            // 
            // buttCancel
            // 
            this.buttCancel.Location = new System.Drawing.Point(150, 130);
            this.buttCancel.Name = "buttCancel";
            this.buttCancel.Size = new System.Drawing.Size(53, 23);
            this.buttCancel.TabIndex = 5;
            this.buttCancel.Text = "退出";
            this.buttCancel.UseVisualStyleBackColor = true;
            this.buttCancel.Click += new System.EventHandler(this.buttCancel_Click);
            // 
            // FrmDecjointPipeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 166);
            this.Controls.Add(this.buttOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDecjointPipeline";
            this.Text = "管线缩进";
            this.Load += new System.EventHandler(this.FrmDecjointPipeline_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxHeadDecValue;
        private System.Windows.Forms.CheckBox cboxHead;
        private System.Windows.Forms.CheckBox cboxTail;
        private System.Windows.Forms.Button buttCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxTailDecValue;
    }
}