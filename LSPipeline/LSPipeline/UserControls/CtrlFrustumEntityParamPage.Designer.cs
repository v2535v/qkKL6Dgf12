namespace WorldGIS
{
    partial class CtrlFrustumEntityParamPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelRadius = new System.Windows.Forms.Label();
            this.textBoxSlices = new System.Windows.Forms.TextBox();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.textBoxBottomRadius = new System.Windows.Forms.TextBox();
            this.textBoxTopRadius = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(267, 87);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 11;
            this.label16.Text = "米";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(267, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "米";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(267, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "米";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(54, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "分段数：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "长度：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(54, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "底部半径：";
            // 
            // labelRadius
            // 
            this.labelRadius.AutoSize = true;
            this.labelRadius.Location = new System.Drawing.Point(54, 26);
            this.labelRadius.Name = "labelRadius";
            this.labelRadius.Size = new System.Drawing.Size(65, 12);
            this.labelRadius.TabIndex = 7;
            this.labelRadius.Text = "顶部半径：";
            // 
            // textBoxSlices
            // 
            this.textBoxSlices.Location = new System.Drawing.Point(125, 118);
            this.textBoxSlices.Name = "textBoxSlices";
            this.textBoxSlices.Size = new System.Drawing.Size(129, 21);
            this.textBoxSlices.TabIndex = 4;
            this.textBoxSlices.TextChanged += new System.EventHandler(this.textBoxSlices_TextChanged);
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(125, 84);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(129, 21);
            this.textBoxLength.TabIndex = 3;
            this.textBoxLength.TextChanged += new System.EventHandler(this.textBoxLength_TextChanged);
            // 
            // textBoxBottomRadius
            // 
            this.textBoxBottomRadius.Location = new System.Drawing.Point(125, 53);
            this.textBoxBottomRadius.Name = "textBoxBottomRadius";
            this.textBoxBottomRadius.Size = new System.Drawing.Size(129, 21);
            this.textBoxBottomRadius.TabIndex = 6;
            this.textBoxBottomRadius.TextChanged += new System.EventHandler(this.textBoxBottomRadius_TextChanged);
            // 
            // textBoxTopRadius
            // 
            this.textBoxTopRadius.Location = new System.Drawing.Point(125, 23);
            this.textBoxTopRadius.Name = "textBoxTopRadius";
            this.textBoxTopRadius.Size = new System.Drawing.Size(129, 21);
            this.textBoxTopRadius.TabIndex = 5;
            this.textBoxTopRadius.TextChanged += new System.EventHandler(this.textBoxTopRadius_TextChanged);
            // 
            // CtrlFrustumEntityParamPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelRadius);
            this.Controls.Add(this.textBoxSlices);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.textBoxBottomRadius);
            this.Controls.Add(this.textBoxTopRadius);
            this.Name = "CtrlFrustumEntityParamPage";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlFrustumEntityParamPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelRadius;
        private System.Windows.Forms.TextBox textBoxSlices;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.TextBox textBoxBottomRadius;
        private System.Windows.Forms.TextBox textBoxTopRadius;
    }
}
