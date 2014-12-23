namespace WorldGIS
{
    partial class FrmShowValvesNeedClose
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
            this.lstValvesName = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FlyToMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LightMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstValvesName
            // 
            this.lstValvesName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValvesName.FormattingEnabled = true;
            this.lstValvesName.ItemHeight = 12;
            this.lstValvesName.Location = new System.Drawing.Point(0, 0);
            this.lstValvesName.Name = "lstValvesName";
            this.lstValvesName.Size = new System.Drawing.Size(165, 112);
            this.lstValvesName.TabIndex = 0;
            this.lstValvesName.DoubleClick += new System.EventHandler(this.lstValvesName_DoubleClick);
            this.lstValvesName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstValvesName_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FlyToMenu,
            this.LightMenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // FlyToMenu
            // 
            this.FlyToMenu.Name = "FlyToMenu";
            this.FlyToMenu.Size = new System.Drawing.Size(100, 22);
            this.FlyToMenu.Text = "定位";
            this.FlyToMenu.Click += new System.EventHandler(this.FlyToMenu_Click);
            // 
            // LightMenu
            // 
            this.LightMenu.Name = "LightMenu";
            this.LightMenu.Size = new System.Drawing.Size(100, 22);
            this.LightMenu.Text = "闪烁";
            this.LightMenu.Click += new System.EventHandler(this.LightMenu_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmCloseValves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 112);
            this.Controls.Add(this.lstValvesName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCloseValves";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "要关闭的阀门";
            this.Load += new System.EventHandler(this.FrmCloseValves_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCloseValves_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstValvesName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FlyToMenu;
        private System.Windows.Forms.ToolStripMenuItem LightMenu;
        private System.Windows.Forms.Timer timer1;
    }
}