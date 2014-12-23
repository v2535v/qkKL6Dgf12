using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmSetFlyParams : Form
    {
        public double dFlyAboveLine=0;
        public double dFlyAloneLineSpeed = 50;
        public double dFlyAloneLineRotateSpeed = 50;
        public FrmSetFlyParams()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dFlyAboveLine = Convert.ToDouble(textBoxHeight.Text);
            dFlyAloneLineSpeed = Convert.ToDouble(textBoxFlySpeed.Text);
            dFlyAloneLineRotateSpeed = Convert.ToDouble(textBoxRotateSpeed.Text);


        }

        private void FlySetDlg_Load(object sender, EventArgs e)
        {
            textBoxHeight.Text = Convert.ToString(dFlyAboveLine);
            textBoxFlySpeed.Text = Convert.ToString(dFlyAloneLineSpeed);
            textBoxRotateSpeed.Text = Convert.ToString(dFlyAloneLineRotateSpeed);
        }
    }
}
