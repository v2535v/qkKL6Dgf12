namespace WorldGIS
{
    partial class CtrlPolylineSpaceInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxZ = new System.Windows.Forms.NumericUpDown();
            this.labelNumPoints = new System.Windows.Forms.Label();
            this.buttonModify = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonInsertNode = new System.Windows.Forms.Button();
            this.buttonAddNode = new System.Windows.Forms.Button();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.buttonDelNode = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.listViewNodeList = new System.Windows.Forms.ListView();
            this.chIndex = new System.Windows.Forms.ColumnHeader();
            this.chX = new System.Windows.Forms.ColumnHeader();
            this.chY = new System.Windows.Forms.ColumnHeader();
            this.chZ = new System.Windows.Forms.ColumnHeader();
            this.buttonMoveAllZ = new System.Windows.Forms.Button();
            this.groupBoxDec = new System.Windows.Forms.GroupBox();
            this.textBoxAllZAdded = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBoxAltMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxZ)).BeginInit();
            this.groupBoxDec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxAllZAdded)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxZ);
            this.groupBox1.Controls.Add(this.labelNumPoints);
            this.groupBox1.Controls.Add(this.buttonModify);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonInsertNode);
            this.groupBox1.Controls.Add(this.buttonAddNode);
            this.groupBox1.Controls.Add(this.textBoxY);
            this.groupBox1.Controls.Add(this.buttonDelNode);
            this.groupBox1.Controls.Add(this.textBoxX);
            this.groupBox1.Controls.Add(this.listViewNodeList);
            this.groupBox1.Location = new System.Drawing.Point(18, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 225);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // textBoxZ
            // 
            this.textBoxZ.DecimalPlaces = 2;
            this.textBoxZ.Location = new System.Drawing.Point(29, 196);
            this.textBoxZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(126, 21);
            this.textBoxZ.TabIndex = 36;
            // 
            // labelNumPoints
            // 
            this.labelNumPoints.AutoSize = true;
            this.labelNumPoints.Location = new System.Drawing.Point(11, 12);
            this.labelNumPoints.Name = "labelNumPoints";
            this.labelNumPoints.Size = new System.Drawing.Size(0, 12);
            this.labelNumPoints.TabIndex = 35;
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(248, 196);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(44, 20);
            this.buttonModify.TabIndex = 33;
            this.buttonModify.Text = "修改";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "X";
            // 
            // buttonInsertNode
            // 
            this.buttonInsertNode.Location = new System.Drawing.Point(248, 170);
            this.buttonInsertNode.Name = "buttonInsertNode";
            this.buttonInsertNode.Size = new System.Drawing.Size(44, 20);
            this.buttonInsertNode.TabIndex = 25;
            this.buttonInsertNode.Text = "插入";
            this.buttonInsertNode.UseVisualStyleBackColor = true;
            this.buttonInsertNode.Click += new System.EventHandler(this.buttonInsertNode_Click);
            // 
            // buttonAddNode
            // 
            this.buttonAddNode.Location = new System.Drawing.Point(178, 170);
            this.buttonAddNode.Name = "buttonAddNode";
            this.buttonAddNode.Size = new System.Drawing.Size(48, 20);
            this.buttonAddNode.TabIndex = 24;
            this.buttonAddNode.Text = "添加";
            this.buttonAddNode.UseVisualStyleBackColor = true;
            this.buttonAddNode.Click += new System.EventHandler(this.buttonAddNode_Click);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(28, 169);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(127, 21);
            this.textBoxY.TabIndex = 28;
            // 
            // buttonDelNode
            // 
            this.buttonDelNode.Location = new System.Drawing.Point(178, 196);
            this.buttonDelNode.Name = "buttonDelNode";
            this.buttonDelNode.Size = new System.Drawing.Size(48, 20);
            this.buttonDelNode.TabIndex = 26;
            this.buttonDelNode.Text = "删除";
            this.buttonDelNode.UseVisualStyleBackColor = true;
            this.buttonDelNode.Click += new System.EventHandler(this.buttonDelNode_Click);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(28, 142);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(127, 21);
            this.textBoxX.TabIndex = 27;
            // 
            // listViewNodeList
            // 
            this.listViewNodeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chIndex,
            this.chX,
            this.chY,
            this.chZ});
            this.listViewNodeList.FullRowSelect = true;
            this.listViewNodeList.GridLines = true;
            this.listViewNodeList.Location = new System.Drawing.Point(12, 28);
            this.listViewNodeList.MultiSelect = false;
            this.listViewNodeList.Name = "listViewNodeList";
            this.listViewNodeList.Size = new System.Drawing.Size(280, 108);
            this.listViewNodeList.TabIndex = 23;
            this.listViewNodeList.UseCompatibleStateImageBehavior = false;
            this.listViewNodeList.View = System.Windows.Forms.View.Details;
            this.listViewNodeList.Validated += new System.EventHandler(this.listViewNodeList_Validated);
            this.listViewNodeList.SelectedIndexChanged += new System.EventHandler(this.listViewNodeList_SelectedIndexChanged);
            // 
            // chIndex
            // 
            this.chIndex.Text = "编号";
            // 
            // chX
            // 
            this.chX.Text = "X";
            // 
            // chY
            // 
            this.chY.Text = "Y";
            // 
            // chZ
            // 
            this.chZ.Text = "Z";
            // 
            // buttonMoveAllZ
            // 
            this.buttonMoveAllZ.Location = new System.Drawing.Point(209, 23);
            this.buttonMoveAllZ.Name = "buttonMoveAllZ";
            this.buttonMoveAllZ.Size = new System.Drawing.Size(41, 20);
            this.buttonMoveAllZ.TabIndex = 36;
            this.buttonMoveAllZ.Text = "确定";
            this.buttonMoveAllZ.UseVisualStyleBackColor = true;
            this.buttonMoveAllZ.Click += new System.EventHandler(this.buttonMoveAllZ_Click);
            // 
            // groupBoxDec
            // 
            this.groupBoxDec.Controls.Add(this.textBoxAllZAdded);
            this.groupBoxDec.Controls.Add(this.label19);
            this.groupBoxDec.Controls.Add(this.comboBoxAltMode);
            this.groupBoxDec.Controls.Add(this.label4);
            this.groupBoxDec.Controls.Add(this.buttonMoveAllZ);
            this.groupBoxDec.Location = new System.Drawing.Point(18, 232);
            this.groupBoxDec.Name = "groupBoxDec";
            this.groupBoxDec.Size = new System.Drawing.Size(302, 95);
            this.groupBoxDec.TabIndex = 38;
            this.groupBoxDec.TabStop = false;
            // 
            // textBoxAllZAdded
            // 
            this.textBoxAllZAdded.DecimalPlaces = 2;
            this.textBoxAllZAdded.Location = new System.Drawing.Point(126, 22);
            this.textBoxAllZAdded.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.textBoxAllZAdded.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.textBoxAllZAdded.Name = "textBoxAllZAdded";
            this.textBoxAllZAdded.Size = new System.Drawing.Size(77, 21);
            this.textBoxAllZAdded.TabIndex = 37;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(43, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 39;
            this.label19.Text = "高度模式：";
            // 
            // comboBoxAltMode
            // 
            this.comboBoxAltMode.FormattingEnabled = true;
            this.comboBoxAltMode.Items.AddRange(new object[] {
            "海拔高度",
            "紧贴地表",
            "相对地表"});
            this.comboBoxAltMode.Location = new System.Drawing.Point(126, 60);
            this.comboBoxAltMode.Name = "comboBoxAltMode";
            this.comboBoxAltMode.Size = new System.Drawing.Size(124, 20);
            this.comboBoxAltMode.TabIndex = 38;
            this.comboBoxAltMode.Text = "紧贴地表";
            this.comboBoxAltMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxAltMode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "z值统一增加：";
            // 
            // CtrlPolylineSpaceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBoxDec);
            this.Controls.Add(this.groupBox1);
            this.Name = "CtrlPolylineSpaceInfo";
            this.Size = new System.Drawing.Size(334, 340);
            this.Load += new System.EventHandler(this.CtrlPolylineSpaceInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxZ)).EndInit();
            this.groupBoxDec.ResumeLayout(false);
            this.groupBoxDec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxAllZAdded)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDelNode;
        private System.Windows.Forms.Button buttonInsertNode;
        private System.Windows.Forms.Button buttonAddNode;
        private System.Windows.Forms.ListView listViewNodeList;
        private System.Windows.Forms.ColumnHeader chIndex;
        private System.Windows.Forms.ColumnHeader chX;
        private System.Windows.Forms.ColumnHeader chY;
        private System.Windows.Forms.ColumnHeader chZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonMoveAllZ;
        private System.Windows.Forms.GroupBox groupBoxDec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNumPoints;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBoxAltMode;
        private System.Windows.Forms.NumericUpDown textBoxZ;
        private System.Windows.Forms.NumericUpDown textBoxAllZAdded;
    }
}
