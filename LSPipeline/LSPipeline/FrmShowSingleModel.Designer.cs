namespace WorldGIS
{
    partial class FrmShowSingleModel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowSingleModel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rMouseUpContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullExtemtMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMouseUpContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 432);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rMouseUpContextMenuStrip
            // 
            this.rMouseUpContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullExtemtMenuItem});
            this.rMouseUpContextMenuStrip.Name = "rMouseUpContextMenuStrip";
            this.rMouseUpContextMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // fullExtemtMenuItem
            // 
            this.fullExtemtMenuItem.Name = "fullExtemtMenuItem";
            this.fullExtemtMenuItem.Size = new System.Drawing.Size(118, 22);
            this.fullExtemtMenuItem.Text = "全幅显示";
            this.fullExtemtMenuItem.Click += new System.EventHandler(this.fullExtemtMenuItem_Click);
            // 
            // ShowSingleModelDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 432);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowSingleModelDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "展示单个模型";
            this.Load += new System.EventHandler(this.ShowSingleModelDlg_Load);
            this.rMouseUpContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip rMouseUpContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fullExtemtMenuItem;
    }
}