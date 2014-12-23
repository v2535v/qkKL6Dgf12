namespace WorldGIS.Forms
{
    partial class FrmAddYuBiZiShp
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
            this.buttonModelFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxModelFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtUpGround = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNewLayerName = new System.Windows.Forms.TextBox();
            this.comboBoxShpLayerList = new System.Windows.Forms.ComboBox();
            this.combModelName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.combCode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.combDeep = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.combAngle = new System.Windows.Forms.ComboBox();
            this.comboBoxDataSourceList = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonModelFolder
            // 
            this.buttonModelFolder.Location = new System.Drawing.Point(373, 112);
            this.buttonModelFolder.Name = "buttonModelFolder";
            this.buttonModelFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonModelFolder.TabIndex = 0;
            this.buttonModelFolder.Text = "模板文件夹 ";
            this.buttonModelFolder.UseVisualStyleBackColor = true;
            this.buttonModelFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "工井模型文件夹：";
            // 
            // textBoxModelFolder
            // 
            this.textBoxModelFolder.Location = new System.Drawing.Point(129, 114);
            this.textBoxModelFolder.Name = "textBoxModelFolder";
            this.textBoxModelFolder.Size = new System.Drawing.Size(237, 21);
            this.textBoxModelFolder.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "图层文件：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 368);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtUpGround
            // 
            this.txtUpGround.Location = new System.Drawing.Point(128, 189);
            this.txtUpGround.Name = "txtUpGround";
            this.txtUpGround.Size = new System.Drawing.Size(237, 21);
            this.txtUpGround.TabIndex = 4;
            this.txtUpGround.Text = "0.01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "高出地面：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "米";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "图层名称：";
            // 
            // textBoxNewLayerName
            // 
            this.textBoxNewLayerName.Location = new System.Drawing.Point(128, 153);
            this.textBoxNewLayerName.Name = "textBoxNewLayerName";
            this.textBoxNewLayerName.Size = new System.Drawing.Size(237, 21);
            this.textBoxNewLayerName.TabIndex = 4;
            // 
            // comboBoxShpLayerList
            // 
            this.comboBoxShpLayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShpLayerList.FormattingEnabled = true;
            this.comboBoxShpLayerList.Location = new System.Drawing.Point(128, 79);
            this.comboBoxShpLayerList.Name = "comboBoxShpLayerList";
            this.comboBoxShpLayerList.Size = new System.Drawing.Size(237, 20);
            this.comboBoxShpLayerList.TabIndex = 73;
            this.comboBoxShpLayerList.SelectedIndexChanged += new System.EventHandler(this.cmbLayer_SelectedIndexChanged);
            // 
            // combModelName
            // 
            this.combModelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combModelName.FormattingEnabled = true;
            this.combModelName.Location = new System.Drawing.Point(129, 225);
            this.combModelName.Name = "combModelName";
            this.combModelName.Size = new System.Drawing.Size(237, 20);
            this.combModelName.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "模型名称字段：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "管点编码字段：";
            // 
            // combCode
            // 
            this.combCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combCode.FormattingEnabled = true;
            this.combCode.Location = new System.Drawing.Point(129, 261);
            this.combCode.Name = "combCode";
            this.combCode.Size = new System.Drawing.Size(237, 20);
            this.combCode.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "井深字段：";
            // 
            // combDeep
            // 
            this.combDeep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combDeep.FormattingEnabled = true;
            this.combDeep.Location = new System.Drawing.Point(129, 296);
            this.combDeep.Name = "combDeep";
            this.combDeep.Size = new System.Drawing.Size(237, 20);
            this.combDeep.TabIndex = 74;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(28, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(319, 45);
            this.label9.TabIndex = 1;
            this.label9.Text = "shp字段名要求是中文字段，入库后的字段名称和shp一致。雨水篦子模型文件夹必须和程序exe在同一个目录下";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(371, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "鼠标提示的名称";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(371, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "工井类型标识";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 337);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "旋转角度字段：";
            // 
            // combAngle
            // 
            this.combAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combAngle.FormattingEnabled = true;
            this.combAngle.Location = new System.Drawing.Point(128, 333);
            this.combAngle.Name = "combAngle";
            this.combAngle.Size = new System.Drawing.Size(237, 20);
            this.combAngle.TabIndex = 74;
            // 
            // comboBoxDataSourceList
            // 
            this.comboBoxDataSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList.FormattingEnabled = true;
            this.comboBoxDataSourceList.Location = new System.Drawing.Point(129, 46);
            this.comboBoxDataSourceList.Name = "comboBoxDataSourceList";
            this.comboBoxDataSourceList.Size = new System.Drawing.Size(239, 20);
            this.comboBoxDataSourceList.TabIndex = 96;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(26, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 95;
            this.label17.Text = "目标数据源：";
            // 
            // FrmAddYuBiZiShp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 406);
            this.Controls.Add(this.comboBoxDataSourceList);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.combAngle);
            this.Controls.Add(this.combDeep);
            this.Controls.Add(this.combCode);
            this.Controls.Add(this.combModelName);
            this.Controls.Add(this.comboBoxShpLayerList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNewLayerName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUpGround);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxModelFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonModelFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAddYuBiZiShp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "雨水篦子批量入库-数据库";
            this.Load += new System.EventHandler(this.FrmAddWellShp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonModelFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxModelFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtUpGround;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNewLayerName;
        private System.Windows.Forms.ComboBox comboBoxShpLayerList;
        private System.Windows.Forms.ComboBox combModelName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combDeep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox combAngle;
        private System.Windows.Forms.ComboBox comboBoxDataSourceList;
        private System.Windows.Forms.Label label17;
    }
}