namespace WorldGIS
{
    partial class FrmDeleteFieldFromLayer
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLayerCaption = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCheckAll = new System.Windows.Forms.Button();
            this.buttonCheckUnCheckde = new System.Windows.Forms.Button();
            this.listViewFields = new System.Windows.Forms.ListView();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称：";
            // 
            // textBoxLayerCaption
            // 
            this.textBoxLayerCaption.Enabled = false;
            this.textBoxLayerCaption.Location = new System.Drawing.Point(93, 18);
            this.textBoxLayerCaption.Name = "textBoxLayerCaption";
            this.textBoxLayerCaption.Size = new System.Drawing.Size(182, 21);
            this.textBoxLayerCaption.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(169, 231);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(50, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(225, 231);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(50, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonCheckAll
            // 
            this.buttonCheckAll.Location = new System.Drawing.Point(225, 55);
            this.buttonCheckAll.Name = "buttonCheckAll";
            this.buttonCheckAll.Size = new System.Drawing.Size(50, 23);
            this.buttonCheckAll.TabIndex = 5;
            this.buttonCheckAll.Text = "全选";
            this.buttonCheckAll.UseVisualStyleBackColor = true;
            this.buttonCheckAll.Click += new System.EventHandler(this.buttonCheckAll_Click);
            // 
            // buttonCheckUnCheckde
            // 
            this.buttonCheckUnCheckde.Location = new System.Drawing.Point(225, 84);
            this.buttonCheckUnCheckde.Name = "buttonCheckUnCheckde";
            this.buttonCheckUnCheckde.Size = new System.Drawing.Size(50, 23);
            this.buttonCheckUnCheckde.TabIndex = 6;
            this.buttonCheckUnCheckde.Text = "反选";
            this.buttonCheckUnCheckde.UseVisualStyleBackColor = true;
            this.buttonCheckUnCheckde.Click += new System.EventHandler(this.buttonCheckUnCheckde_Click);
            // 
            // listViewFields
            // 
            this.listViewFields.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewFields.CheckBoxes = true;
            this.listViewFields.Location = new System.Drawing.Point(24, 55);
            this.listViewFields.Name = "listViewFields";
            this.listViewFields.ShowItemToolTips = true;
            this.listViewFields.Size = new System.Drawing.Size(195, 162);
            this.listViewFields.TabIndex = 8;
            this.listViewFields.UseCompatibleStateImageBehavior = false;
            this.listViewFields.View = System.Windows.Forms.View.List;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(225, 113);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(50, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "重置";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // FrmDeleteFieldFromLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 266);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.listViewFields);
            this.Controls.Add(this.buttonCheckUnCheckde);
            this.Controls.Add(this.buttonCheckAll);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxLayerCaption);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDeleteFieldFromLayer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "删除字段";
            this.Load += new System.EventHandler(this.FrmDeleteFieldFromLayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLayerCaption;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCheckAll;
        private System.Windows.Forms.Button buttonCheckUnCheckde;
        private System.Windows.Forms.ListView listViewFields;
        private System.Windows.Forms.Button buttonReset;
    }
}