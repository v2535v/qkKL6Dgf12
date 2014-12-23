using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmSetLayerVisibleAltitude : Form
    {
        public double m_dMaxVisibleAlt = -1;
        public double m_dMinVisibleAlt = -1;
        public FrmSetLayerVisibleAltitude()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_dMaxVisibleAlt = Convert.ToDouble(textBoxMaxVisibleAlt.Text);
            m_dMinVisibleAlt = Convert.ToDouble(textBoxMinVisibleAlt.Text);
        }

        private void FrmLayerVisibleAltitudeSetting_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxMaxVisibleAlt.Text = m_dMaxVisibleAlt.ToString();
                textBoxMinVisibleAlt.Text = m_dMinVisibleAlt.ToString();
            }
            catch (System.Exception exp)
            {
                Log.PublishTxt(exp);
            }
            
        }
    }
}
