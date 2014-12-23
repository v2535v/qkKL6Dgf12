namespace WorldGIS.Forms
{
    partial class FrmAddValve
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
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNewLayerName = new System.Windows.Forms.TextBox();
            this.comboBoxShpLayerList = new System.Windows.Forms.ComboBox();
            this.combModelName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.combPath = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.combZ = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDataSourceList = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.button3.Location = new System.Drawing.Point(390, 247);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "图层名称：";
            // 
            // textBoxNewLayerName
            // 
            this.textBoxNewLayerName.Location = new System.Drawing.Point(128, 112);
            this.textBoxNewLayerName.Name = "textBoxNewLayerName";
            this.textBoxNewLayerName.Size = new System.Drawing.Size(250, 21);
            this.textBoxNewLayerName.TabIndex = 4;
            // 
            // comboBoxShpLayerList
            // 
            this.comboBoxShpLayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShpLayerList.FormattingEnabled = true;
            this.comboBoxShpLayerList.Location = new System.Drawing.Point(128, 79);
            this.comboBoxShpLayerList.Name = "comboBoxShpLayerList";
            this.comboBoxShpLayerList.Size = new System.Drawing.Size(250, 20);
            this.comboBoxShpLayerList.TabIndex = 73;
            this.comboBoxShpLayerList.SelectedIndexChanged += new System.EventHandler(this.cmbLayer_SelectedIndexChanged);
            // 
            // combModelName
            // 
            this.combModelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combModelName.FormattingEnabled = true;
            this.combModelName.Location = new System.Drawing.Point(129, 147);
            this.combModelName.Name = "combModelName";
            this.combModelName.Size = new System.Drawing.Size(250, 20);
            this.combModelName.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "模型名称字段：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "模型路径字段：";
            // 
            // combPath
            // 
            this.combPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPath.FormattingEnabled = true;
            this.combPath.Location = new System.Drawing.Point(129, 183);
            this.combPath.Name = "combPath";
            this.combPath.Size = new System.Drawing.Size(250, 20);
            this.combPath.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "Z坐标字段：";
            // 
            // combZ
            // 
            this.combZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combZ.FormattingEnabled = true;
            this.combZ.Location = new System.Drawing.Point(129, 218);
            this.combZ.Name = "combZ";
            this.combZ.Size = new System.Drawing.Size(250, 20);
            this.combZ.TabIndex = 74;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(28, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(328, 35);
            this.label9.TabIndex = 1;
            this.label9.Text = "shp字段名要求是中文字段，入库后的字段名称和shp一致。阀门模型文件夹必须和程序exe在同一个目录下";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(388, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "鼠标提示的名称";
            // 
            // comboBoxDataSourceList
            // 
            this.comboBoxDataSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataSourceList.FormattingEnabled = true;
            this.comboBoxDataSourceList.Location = new System.Drawing.Point(126, 50);
            this.comboBoxDataSourceList.Name = "comboBoxDataSourceList";
            this.comboBoxDataSourceList.Size = new System.Drawing.Size(252, 20);
            this.comboBoxDataSourceList.TabIndex = 94;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 93;
            this.label17.Text = "目标数据源：";
            // 
            // FrmAddValve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 282);
            this.Controls.Add(this.comboBoxDataSourceList);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.combZ);
            this.Controls.Add(this.combPath);
            this.Controls.Add(this.combModelName);
            this.Controls.Add(this.comboBoxShpLayerList);
            this.Controls.Add(this.textBoxNewLayerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAddValve";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阀门模型批量入库-数据库";
            this.Load += new System.EventHandler(this.FrmAddWellShp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNewLayerName;
        private System.Windows.Forms.ComboBox comboBoxShpLayerList;
        private System.Windows.Forms.ComboBox combModelName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combZ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxDataSourceList;
        private System.Windows.Forms.Label label17;
    }
}