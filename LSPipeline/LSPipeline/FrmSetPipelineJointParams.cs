using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
namespace WorldGIS
{
    public partial class FrmSetPipelineJointParams : Form
    {
        private GSOGlobe m_globe = null;

        public FrmSetPipelineJointParams(GSOGlobe globe)
        {
            InitializeComponent();
            m_globe = globe;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (m_globe!=null)
            {
                double dResult;
                if(Double.TryParse(tboxTolerance.Text,out dResult))
                {
                       m_globe.ButtjointTolerance=dResult;
                }
                
            }
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmButtjointSetting_Load(object sender, EventArgs e)
        {
            if (m_globe != null)
            {
                tboxTolerance.Text = m_globe.ButtjointTolerance.ToString();
            }
        }
    }
}
