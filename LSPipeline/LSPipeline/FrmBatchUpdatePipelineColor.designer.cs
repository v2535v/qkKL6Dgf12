namespace WorldGIS
{
    partial class FrmBatchUpdatePipelineColor
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
            this.groupBoxField = new System.Windows.Forms.GroupBox();
            this.textBox_WhereClause = new System.Windows.Forms.RichTextBox();
            this.btn_What = new System.Windows.Forms.Button();
            this.btn_All = new System.Windows.Forms.Button();
            this.btn_Not = new System.Windows.Forms.Button();
            this.btn_Brace = new System.Windows.Forms.Button();
            this.btn_IS = new System.Windows.Forms.Button();
            this.btn_Or = new System.Windows.Forms.Button();
            this.btn_Smallequal = new System.Windows.Forms.Button();
            this.btn_Small = new System.Windows.Forms.Button();
            this.btn_And = new System.Windows.Forms.Button();
            this.btn_BigEqual = new System.Windows.Forms.Button();
            this.btn_Big = new System.Windows.Forms.Button();
            this.btn_Like = new System.Windows.Forms.Button();
            this.btn_Notequal = new System.Windows.Forms.Button();
            this.btn_equal = new System.Windows.Forms.Button();
            this.btn_GetValue = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_Value = new System.Windows.Forms.ListBox();
            this.listBox_Field = new System.Windows.Forms.ListBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbox_Layers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonPipelineColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxField.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxField
            // 
            this.groupBoxField.Controls.Add(this.textBox_WhereClause);
            this.groupBoxField.Controls.Add(this.btn_What);
            this.groupBoxField.Controls.Add(this.btn_All);
            this.groupBoxField.Controls.Add(this.btn_Not);
            this.groupBoxField.Controls.Add(this.btn_Brace);
            this.groupBoxField.Controls.Add(this.btn_IS);
            this.groupBoxField.Controls.Add(this.btn_Or);
            this.groupBoxField.Controls.Add(this.btn_Smallequal);
            this.groupBoxField.Controls.Add(this.btn_Small);
            this.groupBoxField.Controls.Add(this.btn_And);
            this.groupBoxField.Controls.Add(this.btn_BigEqual);
            this.groupBoxField.Controls.Add(this.btn_Big);
            this.groupBoxField.Controls.Add(this.btn_Like);
            this.groupBoxField.Controls.Add(this.btn_Notequal);
            this.groupBoxField.Controls.Add(this.btn_equal);
            this.groupBoxField.Controls.Add(this.btn_GetValue);
            this.groupBoxField.Controls.Add(this.label3);
            this.groupBoxField.Controls.Add(this.listBox_Value);
            this.groupBoxField.Controls.Add(this.listBox_Field);
            this.groupBoxField.Location = new System.Drawing.Point(12, 154);
            this.groupBoxField.Name = "groupBoxField";
            this.groupBoxField.Size = new System.Drawing.Size(420, 295);
            this.groupBoxField.TabIndex = 6;
            this.groupBoxField.TabStop = false;
            this.groupBoxField.Text = "字段";
            // 
            // textBox_WhereClause
            // 
            this.textBox_WhereClause.Location = new System.Drawing.Point(8, 190);
            this.textBox_WhereClause.Name = "textBox_WhereClause";
            this.textBox_WhereClause.Size = new System.Drawing.Size(402, 88);
            this.textBox_WhereClause.TabIndex = 24;
            this.textBox_WhereClause.Text = "";
            // 
            // btn_What
            // 
            this.btn_What.Location = new System.Drawing.Point(153, 129);
            this.btn_What.Name = "btn_What";
            this.btn_What.Size = new System.Drawing.Size(27, 21);
            this.btn_What.TabIndex = 19;
            this.btn_What.Text = "?";
            this.btn_What.UseVisualStyleBackColor = true;
            this.btn_What.Click += new System.EventHandler(this.btn_What_Click);
            // 
            // btn_All
            // 
            this.btn_All.Location = new System.Drawing.Point(194, 129);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(27, 21);
            this.btn_All.TabIndex = 18;
            this.btn_All.Text = "*";
            this.btn_All.UseVisualStyleBackColor = true;
            this.btn_All.Click += new System.EventHandler(this.btn_All_Click);
            // 
            // btn_Not
            // 
            this.btn_Not.Location = new System.Drawing.Point(235, 102);
            this.btn_Not.Name = "btn_Not";
            this.btn_Not.Size = new System.Drawing.Size(35, 21);
            this.btn_Not.TabIndex = 16;
            this.btn_Not.Text = "Not";
            this.btn_Not.UseVisualStyleBackColor = true;
            this.btn_Not.Click += new System.EventHandler(this.btn_Not_Click);
            // 
            // btn_Brace
            // 
            this.btn_Brace.Location = new System.Drawing.Point(194, 102);
            this.btn_Brace.Name = "btn_Brace";
            this.btn_Brace.Size = new System.Drawing.Size(35, 21);
            this.btn_Brace.TabIndex = 15;
            this.btn_Brace.Text = "( )";
            this.btn_Brace.UseVisualStyleBackColor = true;
            this.btn_Brace.Click += new System.EventHandler(this.btn_Brace_Click);
            // 
            // btn_IS
            // 
            this.btn_IS.Location = new System.Drawing.Point(153, 102);
            this.btn_IS.Name = "btn_IS";
            this.btn_IS.Size = new System.Drawing.Size(35, 21);
            this.btn_IS.TabIndex = 14;
            this.btn_IS.Text = "IS";
            this.btn_IS.UseVisualStyleBackColor = true;
            this.btn_IS.Click += new System.EventHandler(this.btn_IS_Click);
            // 
            // btn_Or
            // 
            this.btn_Or.Location = new System.Drawing.Point(235, 75);
            this.btn_Or.Name = "btn_Or";
            this.btn_Or.Size = new System.Drawing.Size(35, 21);
            this.btn_Or.TabIndex = 13;
            this.btn_Or.Text = "Or";
            this.btn_Or.UseVisualStyleBackColor = true;
            this.btn_Or.Click += new System.EventHandler(this.btn_Or_Click);
            // 
            // btn_Smallequal
            // 
            this.btn_Smallequal.Location = new System.Drawing.Point(194, 75);
            this.btn_Smallequal.Name = "btn_Smallequal";
            this.btn_Smallequal.Size = new System.Drawing.Size(35, 21);
            this.btn_Smallequal.TabIndex = 12;
            this.btn_Smallequal.Text = "<=";
            this.btn_Smallequal.UseVisualStyleBackColor = true;
            this.btn_Smallequal.Click += new System.EventHandler(this.btn_Smallequal_Click);
            // 
            // btn_Small
            // 
            this.btn_Small.Location = new System.Drawing.Point(153, 75);
            this.btn_Small.Name = "btn_Small";
            this.btn_Small.Size = new System.Drawing.Size(35, 21);
            this.btn_Small.TabIndex = 11;
            this.btn_Small.Text = "<";
            this.btn_Small.UseVisualStyleBackColor = true;
            this.btn_Small.Click += new System.EventHandler(this.btn_Small_Click);
            // 
            // btn_And
            // 
            this.btn_And.Location = new System.Drawing.Point(235, 48);
            this.btn_And.Name = "btn_And";
            this.btn_And.Size = new System.Drawing.Size(35, 21);
            this.btn_And.TabIndex = 10;
            this.btn_And.Text = "And";
            this.btn_And.UseVisualStyleBackColor = true;
            this.btn_And.Click += new System.EventHandler(this.btn_And_Click);
            // 
            // btn_BigEqual
            // 
            this.btn_BigEqual.Location = new System.Drawing.Point(194, 48);
            this.btn_BigEqual.Name = "btn_BigEqual";
            this.btn_BigEqual.Size = new System.Drawing.Size(35, 21);
            this.btn_BigEqual.TabIndex = 9;
            this.btn_BigEqual.Text = ">=";
            this.btn_BigEqual.UseVisualStyleBackColor = true;
            this.btn_BigEqual.Click += new System.EventHandler(this.btn_BigEqual_Click);
            // 
            // btn_Big
            // 
            this.btn_Big.Location = new System.Drawing.Point(153, 48);
            this.btn_Big.Name = "btn_Big";
            this.btn_Big.Size = new System.Drawing.Size(35, 21);
            this.btn_Big.TabIndex = 8;
            this.btn_Big.Text = ">";
            this.btn_Big.UseVisualStyleBackColor = true;
            this.btn_Big.Click += new System.EventHandler(this.btn_Big_Click);
            // 
            // btn_Like
            // 
            this.btn_Like.Location = new System.Drawing.Point(235, 21);
            this.btn_Like.Name = "btn_Like";
            this.btn_Like.Size = new System.Drawing.Size(35, 21);
            this.btn_Like.TabIndex = 7;
            this.btn_Like.Text = "Like";
            this.btn_Like.UseVisualStyleBackColor = true;
            this.btn_Like.Click += new System.EventHandler(this.btn_Like_Click);
            // 
            // btn_Notequal
            // 
            this.btn_Notequal.Location = new System.Drawing.Point(194, 21);
            this.btn_Notequal.Name = "btn_Notequal";
            this.btn_Notequal.Size = new System.Drawing.Size(35, 21);
            this.btn_Notequal.TabIndex = 6;
            this.btn_Notequal.Text = "<>";
            this.btn_Notequal.UseVisualStyleBackColor = true;
            this.btn_Notequal.Click += new System.EventHandler(this.btn_Notequal_Click);
            // 
            // btn_equal
            // 
            this.btn_equal.Location = new System.Drawing.Point(153, 21);
            this.btn_equal.Name = "btn_equal";
            this.btn_equal.Size = new System.Drawing.Size(35, 21);
            this.btn_equal.TabIndex = 5;
            this.btn_equal.Text = "=";
            this.btn_equal.UseVisualStyleBackColor = true;
            this.btn_equal.Click += new System.EventHandler(this.btn_equal_Click);
            // 
            // btn_GetValue
            // 
            this.btn_GetValue.Location = new System.Drawing.Point(303, 163);
            this.btn_GetValue.Name = "btn_GetValue";
            this.btn_GetValue.Size = new System.Drawing.Size(109, 21);
            this.btn_GetValue.TabIndex = 3;
            this.btn_GetValue.Text = "获取唯一值";
            this.btn_GetValue.UseVisualStyleBackColor = true;
            this.btn_GetValue.Click += new System.EventHandler(this.btn_GetValue_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "SELECT * FROM WHERE";
            // 
            // listBox_Value
            // 
            this.listBox_Value.FormattingEnabled = true;
            this.listBox_Value.ItemHeight = 12;
            this.listBox_Value.Location = new System.Drawing.Point(286, 20);
            this.listBox_Value.Name = "listBox_Value";
            this.listBox_Value.Size = new System.Drawing.Size(126, 136);
            this.listBox_Value.TabIndex = 1;
            this.listBox_Value.DoubleClick += new System.EventHandler(this.listBox_Value_DoubleClick);
            // 
            // listBox_Field
            // 
            this.listBox_Field.FormattingEnabled = true;
            this.listBox_Field.ItemHeight = 12;
            this.listBox_Field.Location = new System.Drawing.Point(6, 20);
            this.listBox_Field.Name = "listBox_Field";
            this.listBox_Field.Size = new System.Drawing.Size(130, 136);
            this.listBox_Field.TabIndex = 0;
            this.listBox_Field.DoubleClick += new System.EventHandler(this.listBox_Field_DoubleClick);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(358, 469);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(263, 469);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.btn_Apply.TabIndex = 10;
            this.btn_Apply.Text = "应用";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(166, 469);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 9;
            this.btn_Clear.Text = "清除";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbox_Layers);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 62);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图层";
            // 
            // cbox_Layers
            // 
            this.cbox_Layers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Layers.FormattingEnabled = true;
            this.cbox_Layers.Items.AddRange(new object[] {
            "热力管线",
            "排水管线",
            "给水管线",
            "燃气管线",
            "电力管线",
            "通信管线"});
            this.cbox_Layers.Location = new System.Drawing.Point(89, 23);
            this.cbox_Layers.Name = "cbox_Layers";
            this.cbox_Layers.Size = new System.Drawing.Size(323, 20);
            this.cbox_Layers.TabIndex = 1;
            this.cbox_Layers.SelectedIndexChanged += new System.EventHandler(this.cbox_Layers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择图层：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.buttonPipelineColor);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 62);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "颜色";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(332, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "部分管线";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // buttonPipelineColor
            // 
            this.buttonPipelineColor.Location = new System.Drawing.Point(89, 34);
            this.buttonPipelineColor.Name = "buttonPipelineColor";
            this.buttonPipelineColor.Size = new System.Drawing.Size(323, 23);
            this.buttonPipelineColor.TabIndex = 16;
            this.buttonPipelineColor.Text = "请选择管线颜色";
            this.buttonPipelineColor.UseVisualStyleBackColor = true;
            this.buttonPipelineColor.Click += new System.EventHandler(this.buttonPipelineColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "管线颜色：";
            // 
            // FrmBatchUpdatePipelineColor
            // 
            this.ClientSize = new System.Drawing.Size(446, 506);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.groupBoxField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmBatchUpdatePipelineColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量修改数据库管线颜色";
            this.Load += new System.EventHandler(this.Frm_QuerySQL_Load);
            this.groupBoxField.ResumeLayout(false);
            this.groupBoxField.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxField;
        private System.Windows.Forms.Button btn_What;
        private System.Windows.Forms.Button btn_All;
        private System.Windows.Forms.Button btn_Not;
        private System.Windows.Forms.Button btn_Brace;
        private System.Windows.Forms.Button btn_IS;
        private System.Windows.Forms.Button btn_Or;
        private System.Windows.Forms.Button btn_Smallequal;
        private System.Windows.Forms.Button btn_Small;
        private System.Windows.Forms.Button btn_And;
        private System.Windows.Forms.Button btn_BigEqual;
        private System.Windows.Forms.Button btn_Big;
        private System.Windows.Forms.Button btn_Like;
        private System.Windows.Forms.Button btn_Notequal;
        private System.Windows.Forms.Button btn_equal;
        private System.Windows.Forms.Button btn_GetValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_Value;
        private System.Windows.Forms.ListBox listBox_Field;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbox_Layers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textBox_WhereClause;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonPipelineColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}