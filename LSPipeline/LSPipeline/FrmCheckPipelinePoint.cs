using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmCheckPipelinePoint : Form
    {
        public double pointDistance = 0.0;
        public FrmCheckPipelinePoint()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string strDistance = textBoxDistance.Text.Trim();
            if (strDistance == "")
            {
                MessageBox.Show("容限值不能为空！","提示");
                return;
            }
            double distance = 0;
            if (double.TryParse(strDistance, out distance) == false)
            {
                MessageBox.Show("容限值不符合要求！", "提示");
                return;
            }
            pointDistance = distance;
            this.DialogResult = DialogResult.OK;
        }
    }
}
