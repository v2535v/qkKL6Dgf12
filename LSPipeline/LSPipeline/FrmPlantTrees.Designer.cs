namespace WorldGIS
{
    partial class FrmPlantTrees
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSeeFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNo = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.comboBoxModelPath = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Location = new System.Drawing.Point(12, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 255);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请选择模型所在文件夹：";
            // 
            // buttonSeeFolder
            // 
            this.buttonSeeFolder.Location = new System.Drawing.Point(300, 40);
            this.buttonSeeFolder.Name = "buttonSeeFolder";
            this.buttonSeeFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSeeFolder.TabIndex = 4;
            this.buttonSeeFolder.Text = "浏览...";
            this.buttonSeeFolder.UseVisualStyleBackColor = true;
            this.buttonSeeFolder.Click += new System.EventHandler(this.buttonSeeFolder_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "请选择一个模型：";
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(300, 509);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(75, 23);
            this.buttonNo.TabIndex = 7;
            this.buttonNo.Text = "关闭";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 88);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(363, 145);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // comboBoxModelPath
            // 
            this.comboBoxModelPath.FormattingEnabled = true;
            this.comboBoxModelPath.Location = new System.Drawing.Point(12, 42);
            this.comboBoxModelPath.Name = "comboBoxModelPath";
            this.comboBoxModelPath.Size = new System.Drawing.Size(282, 20);
            this.comboBoxModelPath.TabIndex = 9;
            this.comboBoxModelPath.SelectedIndexChanged += new System.EventHandler(this.comboBoxModelPath_SelectedIndexChanged);
            // 
            // FrmPlantTrees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 538);
            this.Controls.Add(this.comboBoxModelPath);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSeeFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPlantTrees";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "种树";
            this.Load += new System.EventHandler(this.FrmPlantTrees_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlantTrees_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSeeFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBoxModelPath;
    }
}