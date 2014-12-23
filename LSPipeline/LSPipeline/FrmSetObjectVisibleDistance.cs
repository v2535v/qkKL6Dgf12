using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmSetObjectVisibleDistance : Form
    {
       
       public double m_dMaxVisibleDist = -1;
       public double m_dMinVisibleDist = -1;
        public FrmSetObjectVisibleDistance()
        {
            InitializeComponent();
        }

        private void VisibleDistanceDlg_Load(object sender, EventArgs e)
        {
            textBoxMaxVisibleDist.Text = m_dMaxVisibleDist.ToString();
            textBoxMinVisibleDist.Text = m_dMinVisibleDist.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_dMaxVisibleDist = Convert.ToDouble(textBoxMaxVisibleDist.Text);
            m_dMinVisibleDist = Convert.ToDouble(textBoxMinVisibleDist.Text);

        }
    }
}
