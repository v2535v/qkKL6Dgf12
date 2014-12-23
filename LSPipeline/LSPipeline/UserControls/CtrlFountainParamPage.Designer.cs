namespace WorldGIS
{
    partial class CtrlFountainParamPage
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
            this.textBoxDropImage = new System.Windows.Forms.TextBox();
            this.buttonDropImage = new System.Windows.Forms.Button();
            this.textBoxAccFactor = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxAngleOfDeepestStep = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxRayDrops = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxStepRays = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxDropSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownDropOpaque = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxDropColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDropOpaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDropColor)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDropImage
            // 
            this.textBoxDropImage.Location = new System.Drawing.Point(158, 263);
            this.textBoxDropImage.Name = "textBoxDropImage";
            this.textBoxDropImage.Size = new System.Drawing.Size(100, 21);
            this.textBoxDropImage.TabIndex = 35;
            this.textBoxDropImage.TextChanged += new System.EventHandler(this.textBoxDropImage_TextChanged);
            // 
            // buttonDropImage
            // 
            this.buttonDropImage.Location = new System.Drawing.Point(74, 261);
            this.buttonDropImage.Name = "buttonDropImage";
            this.buttonDropImage.Size = new System.Drawing.Size(77, 23);
            this.buttonDropImage.TabIndex = 34;
            this.buttonDropImage.Text = "水滴图片...";
            this.buttonDropImage.UseVisualStyleBackColor = true;
            this.buttonDropImage.Click += new System.EventHandler(this.buttonDropImage_Click);
            // 
            // textBoxAccFactor
            // 
            this.textBoxAccFactor.Location = new System.Drawing.Point(158, 180);
            this.textBoxAccFactor.Name = "textBoxAccFactor";
            this.textBoxAccFactor.Size = new System.Drawing.Size(100, 21);
            this.textBoxAccFactor.TabIndex = 33;
            this.textBoxAccFactor.TextChanged += new System.EventHandler(this.textBoxAccFactor_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(72, 184);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 12);
            this.label24.TabIndex = 32;
            this.label24.Text = "初始加速度：";
            // 
            // textBoxAngleOfDeepestStep
            // 
            this.textBoxAngleOfDeepestStep.Location = new System.Drawing.Point(158, 153);
            this.textBoxAngleOfDeepestStep.Name = "textBoxAngleOfDeepestStep";
            this.textBoxAngleOfDeepestStep.Size = new System.Drawing.Size(100, 21);
            this.textBoxAngleOfDeepestStep.TabIndex = 31;
            this.textBoxAngleOfDeepestStep.TextChanged += new System.EventHandler(this.textBoxAngleOfDeepestStep_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(72, 158);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 12);
            this.label23.TabIndex = 30;
            this.label23.Text = "水柱水平角：";
            // 
            // textBoxRayDrops
            // 
            this.textBoxRayDrops.Location = new System.Drawing.Point(158, 126);
            this.textBoxRayDrops.Name = "textBoxRayDrops";
            this.textBoxRayDrops.Size = new System.Drawing.Size(100, 21);
            this.textBoxRayDrops.TabIndex = 29;
            this.textBoxRayDrops.TextChanged += new System.EventHandler(this.textBoxRayDrops_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(72, 129);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 12);
            this.label22.TabIndex = 28;
            this.label22.Text = "每注水滴数：";
            // 
            // textBoxStepRays
            // 
            this.textBoxStepRays.Location = new System.Drawing.Point(158, 98);
            this.textBoxStepRays.Name = "textBoxStepRays";
            this.textBoxStepRays.Size = new System.Drawing.Size(100, 21);
            this.textBoxStepRays.TabIndex = 27;
            this.textBoxStepRays.TextChanged += new System.EventHandler(this.textBoxStepRays_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "每层水柱数：";
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Location = new System.Drawing.Point(158, 71);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(100, 21);
            this.textBoxSteps.TabIndex = 25;
            this.textBoxSteps.TextChanged += new System.EventHandler(this.textBoxSteps_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(72, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 24;
            this.label21.Text = "喷泉层数：";
            // 
            // textBoxDropSize
            // 
            this.textBoxDropSize.Location = new System.Drawing.Point(158, 44);
            this.textBoxDropSize.Name = "textBoxDropSize";
            this.textBoxDropSize.Size = new System.Drawing.Size(100, 21);
            this.textBoxDropSize.TabIndex = 23;
            this.textBoxDropSize.TextChanged += new System.EventHandler(this.textBoxDropSize_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "水滴大小：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(72, 238);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 6;
            this.label20.Text = "不透明度：";
            // 
            // numericUpDownDropOpaque
            // 
            this.numericUpDownDropOpaque.Location = new System.Drawing.Point(159, 234);
            this.numericUpDownDropOpaque.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownDropOpaque.Name = "numericUpDownDropOpaque";
            this.numericUpDownDropOpaque.Size = new System.Drawing.Size(99, 21);
            this.numericUpDownDropOpaque.TabIndex = 5;
            this.numericUpDownDropOpaque.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownDropOpaque.ValueChanged += new System.EventHandler(this.numericUpDownDropOpaque_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "水滴颜色：";
            // 
            // pictureBoxDropColor
            // 
            this.pictureBoxDropColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxDropColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDropColor.Location = new System.Drawing.Point(159, 209);
            this.pictureBoxDropColor.Name = "pictureBoxDropColor";
            this.pictureBoxDropColor.Size = new System.Drawing.Size(99, 18);
            this.pictureBoxDropColor.TabIndex = 3;
            this.pictureBoxDropColor.TabStop = false;
            this.pictureBoxDropColor.Click += new System.EventHandler(this.pictureBoxDropColor_Click);
            // 
            // CtrlFountainParamPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxDropImage);
            this.Controls.Add(this.numericUpDownDropOpaque);
            this.Controls.Add(this.buttonDropImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxDropColor);
            this.Controls.Add(this.textBoxAccFactor);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBoxAngleOfDeepestStep);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textBoxRayDrops);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBoxStepRays);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSteps);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBoxDropSize);
            this.Controls.Add(this.label5);
            this.Name = "CtrlFountainParamPage";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlFountainParamPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDropOpaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDropColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDropImage;
        private System.Windows.Forms.Button buttonDropImage;
        private System.Windows.Forms.TextBox textBoxAccFactor;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxAngleOfDeepestStep;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxRayDrops;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxStepRays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxDropSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownDropOpaque;
        private System.Windows.Forms.PictureBox pictureBoxDropColor;
        private System.Windows.Forms.Label label2;
    }
}
