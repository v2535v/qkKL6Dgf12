namespace WorldGIS
{
    partial class FrmMessageBox
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonSqlServer = new System.Windows.Forms.Button();
            this.buttonOracle = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMessage.Location = new System.Drawing.Point(27, 24);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(127, 15);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "请先连接数据库！";
            // 
            // buttonSqlServer
            // 
            this.buttonSqlServer.Location = new System.Drawing.Point(25, 64);
            this.buttonSqlServer.Name = "buttonSqlServer";
            this.buttonSqlServer.Size = new System.Drawing.Size(69, 23);
            this.buttonSqlServer.TabIndex = 1;
            this.buttonSqlServer.Text = "SqlServer";
            this.buttonSqlServer.UseVisualStyleBackColor = true;
            this.buttonSqlServer.Click += new System.EventHandler(this.buttonSqlServer_Click);
            // 
            // buttonOracle
            // 
            this.buttonOracle.Location = new System.Drawing.Point(106, 64);
            this.buttonOracle.Name = "buttonOracle";
            this.buttonOracle.Size = new System.Drawing.Size(69, 23);
            this.buttonOracle.TabIndex = 2;
            this.buttonOracle.Text = "Oracle";
            this.buttonOracle.UseVisualStyleBackColor = true;
            this.buttonOracle.Click += new System.EventHandler(this.buttonOracle_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(187, 64);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(69, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FrmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 99);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOracle);
            this.Controls.Add(this.buttonSqlServer);
            this.Controls.Add(this.labelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMessageBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonSqlServer;
        private System.Windows.Forms.Button buttonOracle;
        private System.Windows.Forms.Button buttonCancel;
    }
}