using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
    public partial class FrmUnderGroundFloorSetting : Form
    {
        public GSOGlobe m_globe;
        public FrmUnderGroundFloorSetting()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            double result;
            if (m_globe != null && Double.TryParse(textBoxAlt.Text, out result))
            {
                Double dAlt = Convert.ToDouble(textBoxAlt.Text);
                m_globe.UnderGroundFloor.Altitude = dAlt;
                m_globe.Refresh();                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUnderGroundFloorSetting_Load(object sender, EventArgs e)
        {
            if (m_globe != null)
            {
                textBoxAlt.Text = m_globe.UnderGroundFloor.Altitude.ToString();
            }
        }
    }
}
