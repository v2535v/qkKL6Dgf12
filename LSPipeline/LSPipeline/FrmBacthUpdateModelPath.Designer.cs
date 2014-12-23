namespace WorldGIS
{
    partial class FrmBacthUpdateModelPath
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
            this.listBoxLayerNames = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxModelPath = new System.Windows.Forms.TextBox();
            this.buttonModelPath = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxLayerNames
            // 
            this.listBoxLayerNames.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxLayerNames.FormattingEnabled = true;
            this.listBoxLayerNames.HorizontalScrollbar = true;
            this.listBoxLayerNames.ItemHeight = 20;
            this.listBoxLayerNames.Location = new System.Drawing.Point(15, 12);
            this.listBoxLayerNames.Name = "listBoxLayerNames";
            this.listBoxLayerNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLayerNames.Size = new System.Drawing.Size(245, 204);
            this.listBoxLayerNames.Sorted = true;
            this.listBoxLayerNames.TabIndex = 0;
            this.listBoxLayerNames.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxLayerNames_DrawItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "目标模型路径：";
            // 
            // textBoxModelPath
            // 
            this.textBoxModelPath.Location = new System.Drawing.Point(15, 253);
            this.textBoxModelPath.Name = "textBoxModelPath";
            this.textBoxModelPath.Size = new System.Drawing.Size(213, 21);
            this.textBoxModelPath.TabIndex = 2;
            // 
            // buttonModelPath
            // 
            this.buttonModelPath.Location = new System.Drawing.Point(230, 251);
            this.buttonModelPath.Name = "buttonModelPath";
            this.buttonModelPath.Size = new System.Drawing.Size(30, 23);
            this.buttonModelPath.TabIndex = 3;
            this.buttonModelPath.Text = "...";
            this.buttonModelPath.UseVisualStyleBackColor = true;
            this.buttonModelPath.Click += new System.EventHandler(this.buttonModelPath_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(110, 280);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(55, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "修改";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(205, 280);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(55, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FrmPacthUpdateModelPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 312);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonModelPath);
            this.Controls.Add(this.textBoxModelPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxLayerNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPacthUpdateModelPath";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量修改模型路径";
            this.Load += new System.EventHandler(this.FrmPacthUpdateModelPath_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLayerNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxModelPath;
        private System.Windows.Forms.Button buttonModelPath;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}