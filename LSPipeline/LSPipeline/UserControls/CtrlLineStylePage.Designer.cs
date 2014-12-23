namespace WorldGIS
{
    partial class CtrlLineStylePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("简单线", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("管线", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("管沟", 1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlLineStylePage));
            this.listViewStyle = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonArrowStyle = new System.Windows.Forms.Button();
            this.checkBoxShowArrow = new System.Windows.Forms.CheckBox();
            this.checkBoxUseStyle = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewStyle
            // 
            this.listViewStyle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewStyle.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listViewStyle.LargeImageList = this.imageList1;
            this.listViewStyle.Location = new System.Drawing.Point(12, 20);
            this.listViewStyle.MultiSelect = false;
            this.listViewStyle.Name = "listViewStyle";
            this.listViewStyle.Scrollable = false;
            this.listViewStyle.Size = new System.Drawing.Size(294, 56);
            this.listViewStyle.TabIndex = 0;
            this.listViewStyle.UseCompatibleStateImageBehavior = false;
            this.listViewStyle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewStyle_MouseDoubleClick);
            this.listViewStyle.SelectedIndexChanged += new System.EventHandler(this.listViewStyle_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "简单线";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "管线";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "line323.png");
            this.imageList1.Images.SetKeyName(1, "pipe01.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.checkBoxUseStyle);
            this.groupBox1.Controls.Add(this.listViewStyle);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 315);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(13, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(293, 169);
            this.tabControl1.TabIndex = 41;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonArrowStyle);
            this.groupBox3.Controls.Add(this.checkBoxShowArrow);
            this.groupBox3.Location = new System.Drawing.Point(13, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 49);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            // 
            // buttonArrowStyle
            // 
            this.buttonArrowStyle.Location = new System.Drawing.Point(60, 20);
            this.buttonArrowStyle.Name = "buttonArrowStyle";
            this.buttonArrowStyle.Size = new System.Drawing.Size(177, 23);
            this.buttonArrowStyle.TabIndex = 39;
            this.buttonArrowStyle.Text = "箭头风格";
            this.buttonArrowStyle.UseVisualStyleBackColor = true;
            this.buttonArrowStyle.Click += new System.EventHandler(this.buttonArrowStyle_Click);
            // 
            // checkBoxShowArrow
            // 
            this.checkBoxShowArrow.AutoSize = true;
            this.checkBoxShowArrow.Location = new System.Drawing.Point(182, 0);
            this.checkBoxShowArrow.Name = "checkBoxShowArrow";
            this.checkBoxShowArrow.Size = new System.Drawing.Size(72, 16);
            this.checkBoxShowArrow.TabIndex = 38;
            this.checkBoxShowArrow.Text = "显示箭头";
            this.checkBoxShowArrow.UseVisualStyleBackColor = true;
            this.checkBoxShowArrow.CheckedChanged += new System.EventHandler(this.checkBoxShowArrow_CheckedChanged);
            // 
            // checkBoxUseStyle
            // 
            this.checkBoxUseStyle.AutoSize = true;
            this.checkBoxUseStyle.Location = new System.Drawing.Point(183, 0);
            this.checkBoxUseStyle.Name = "checkBoxUseStyle";
            this.checkBoxUseStyle.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseStyle.TabIndex = 37;
            this.checkBoxUseStyle.Text = "使用自定义风格";
            this.checkBoxUseStyle.UseVisualStyleBackColor = true;
            this.checkBoxUseStyle.CheckedChanged += new System.EventHandler(this.checkBoxUseStyle_CheckedChanged);
            // 
            // CtrlLineStylePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "CtrlLineStylePage";
            this.Size = new System.Drawing.Size(334, 334);
            this.Load += new System.EventHandler(this.CtrlLineStylePage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewStyle;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxUseStyle;
        private System.Windows.Forms.CheckBox checkBoxShowArrow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonArrowStyle;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
