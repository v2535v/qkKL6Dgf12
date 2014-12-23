namespace WorldGIS
{
    partial class FrmUpdateLayerFieldValues
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
            this.comboBoxLayerSource = new System.Windows.Forms.ComboBox();
            this.comboBoxFieldSource = new System.Windows.Forms.ComboBox();
            this.comboBoxLayerTarget = new System.Windows.Forms.ComboBox();
            this.comboBoxFiledTarget = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxChangeSource1 = new System.Windows.Forms.ComboBox();
            this.comboBoxChangeTarget1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxLayerSource
            // 
            this.comboBoxLayerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayerSource.FormattingEnabled = true;
            this.comboBoxLayerSource.Location = new System.Drawing.Point(24, 28);
            this.comboBoxLayerSource.Name = "comboBoxLayerSource";
            this.comboBoxLayerSource.Size = new System.Drawing.Size(121, 20);
            this.comboBoxLayerSource.TabIndex = 0;
            this.comboBoxLayerSource.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayer1_SelectedIndexChanged);
            // 
            // comboBoxFieldSource
            // 
            this.comboBoxFieldSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldSource.FormattingEnabled = true;
            this.comboBoxFieldSource.Location = new System.Drawing.Point(24, 90);
            this.comboBoxFieldSource.Name = "comboBoxFieldSource";
            this.comboBoxFieldSource.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFieldSource.TabIndex = 1;
            // 
            // comboBoxLayerTarget
            // 
            this.comboBoxLayerTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayerTarget.FormattingEnabled = true;
            this.comboBoxLayerTarget.Location = new System.Drawing.Point(170, 28);
            this.comboBoxLayerTarget.Name = "comboBoxLayerTarget";
            this.comboBoxLayerTarget.Size = new System.Drawing.Size(121, 20);
            this.comboBoxLayerTarget.TabIndex = 2;
            this.comboBoxLayerTarget.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayer2_SelectedIndexChanged);
            // 
            // comboBoxFiledTarget
            // 
            this.comboBoxFiledTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiledTarget.FormattingEnabled = true;
            this.comboBoxFiledTarget.Location = new System.Drawing.Point(170, 90);
            this.comboBoxFiledTarget.Name = "comboBoxFiledTarget";
            this.comboBoxFiledTarget.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFiledTarget.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "源图层：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "标识字段：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "目标图层：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "标识字段：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxChangeSource1
            // 
            this.comboBoxChangeSource1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChangeSource1.FormattingEnabled = true;
            this.comboBoxChangeSource1.Location = new System.Drawing.Point(24, 158);
            this.comboBoxChangeSource1.Name = "comboBoxChangeSource1";
            this.comboBoxChangeSource1.Size = new System.Drawing.Size(121, 20);
            this.comboBoxChangeSource1.TabIndex = 10;
            // 
            // comboBoxChangeTarget1
            // 
            this.comboBoxChangeTarget1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChangeTarget1.FormattingEnabled = true;
            this.comboBoxChangeTarget1.Location = new System.Drawing.Point(170, 158);
            this.comboBoxChangeTarget1.Name = "comboBoxChangeTarget1";
            this.comboBoxChangeTarget1.Size = new System.Drawing.Size(121, 20);
            this.comboBoxChangeTarget1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "修改字段：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "修改字段：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(128, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ChangeFieldByFieldName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 238);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxChangeTarget1);
            this.Controls.Add(this.comboBoxChangeSource1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFiledTarget);
            this.Controls.Add(this.comboBoxLayerTarget);
            this.Controls.Add(this.comboBoxFieldSource);
            this.Controls.Add(this.comboBoxLayerSource);
            this.MaximizeBox = false;
            this.Name = "ChangeFieldByFieldName";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "根据字段名修改数据库字段";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLayerSource;
        private System.Windows.Forms.ComboBox comboBoxFieldSource;
        private System.Windows.Forms.ComboBox comboBoxLayerTarget;
        private System.Windows.Forms.ComboBox comboBoxFiledTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxChangeSource1;
        private System.Windows.Forms.ComboBox comboBoxChangeTarget1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
    }
}