namespace WorldGIS
{
    partial class FrmCreatePipeLineLayer
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
            this.textBoxPipelineName = new System.Windows.Forms.TextBox();
            this.textBoxAttriName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxDisplayAttri = new System.Windows.Forms.ListBox();
            this.buttonAddAttri = new System.Windows.Forms.Button();
            this.buttonDeleteAttri = new System.Windows.Forms.Button();
            this.buttonCreatePipe = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.comboBoxAttriType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "管线名称：";
            // 
            // textBoxPipelineName
            // 
            this.textBoxPipelineName.Location = new System.Drawing.Point(96, 20);
            this.textBoxPipelineName.Name = "textBoxPipelineName";
            this.textBoxPipelineName.Size = new System.Drawing.Size(100, 21);
            this.textBoxPipelineName.TabIndex = 1;
            // 
            // textBoxAttriName
            // 
            this.textBoxAttriName.Location = new System.Drawing.Point(96, 68);
            this.textBoxAttriName.Name = "textBoxAttriName";
            this.textBoxAttriName.Size = new System.Drawing.Size(100, 21);
            this.textBoxAttriName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "属性名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "属性类型：";
            // 
            // listBoxDisplayAttri
            // 
            this.listBoxDisplayAttri.FormattingEnabled = true;
            this.listBoxDisplayAttri.ItemHeight = 12;
            this.listBoxDisplayAttri.Location = new System.Drawing.Point(31, 142);
            this.listBoxDisplayAttri.Name = "listBoxDisplayAttri";
            this.listBoxDisplayAttri.Size = new System.Drawing.Size(165, 100);
            this.listBoxDisplayAttri.TabIndex = 6;
            // 
            // buttonAddAttri
            // 
            this.buttonAddAttri.Location = new System.Drawing.Point(202, 142);
            this.buttonAddAttri.Name = "buttonAddAttri";
            this.buttonAddAttri.Size = new System.Drawing.Size(75, 21);
            this.buttonAddAttri.TabIndex = 7;
            this.buttonAddAttri.Text = "添加属性";
            this.buttonAddAttri.UseVisualStyleBackColor = true;
            this.buttonAddAttri.Click += new System.EventHandler(this.buttonAddAttri_Click);
            // 
            // buttonDeleteAttri
            // 
            this.buttonDeleteAttri.Location = new System.Drawing.Point(202, 171);
            this.buttonDeleteAttri.Name = "buttonDeleteAttri";
            this.buttonDeleteAttri.Size = new System.Drawing.Size(75, 21);
            this.buttonDeleteAttri.TabIndex = 8;
            this.buttonDeleteAttri.Text = "删除属性";
            this.buttonDeleteAttri.UseVisualStyleBackColor = true;
            this.buttonDeleteAttri.Click += new System.EventHandler(this.buttonDeleteAttri_Click);
            // 
            // buttonCreatePipe
            // 
            this.buttonCreatePipe.Location = new System.Drawing.Point(121, 257);
            this.buttonCreatePipe.Name = "buttonCreatePipe";
            this.buttonCreatePipe.Size = new System.Drawing.Size(75, 23);
            this.buttonCreatePipe.TabIndex = 9;
            this.buttonCreatePipe.Text = "创建";
            this.buttonCreatePipe.UseVisualStyleBackColor = true;
            this.buttonCreatePipe.Click += new System.EventHandler(this.buttonCreatePipe_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(202, 257);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(75, 23);
            this.buttonNo.TabIndex = 10;
            this.buttonNo.Text = "取消";
            this.buttonNo.UseVisualStyleBackColor = true;
            // 
            // comboBoxAttriType
            // 
            this.comboBoxAttriType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttriType.FormattingEnabled = true;
            this.comboBoxAttriType.Items.AddRange(new object[] {
            "int",
            "double",
            "string",
            "datetime"});
            this.comboBoxAttriType.Location = new System.Drawing.Point(96, 95);
            this.comboBoxAttriType.Name = "comboBoxAttriType";
            this.comboBoxAttriType.Size = new System.Drawing.Size(100, 20);
            this.comboBoxAttriType.TabIndex = 11;
            // 
            // FrmAddPipeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 292);
            this.Controls.Add(this.comboBoxAttriType);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonCreatePipe);
            this.Controls.Add(this.buttonDeleteAttri);
            this.Controls.Add(this.buttonAddAttri);
            this.Controls.Add(this.listBoxDisplayAttri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAttriName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPipelineName);
            this.Controls.Add(this.label1);
            this.Name = "FrmAddPipeLine";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加管线";
            this.Load += new System.EventHandler(this.FrmAddPipeLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPipelineName;
        private System.Windows.Forms.TextBox textBoxAttriName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxDisplayAttri;
        private System.Windows.Forms.Button buttonAddAttri;
        private System.Windows.Forms.Button buttonDeleteAttri;
        private System.Windows.Forms.Button buttonCreatePipe;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.ComboBox comboBoxAttriType;
    }
}