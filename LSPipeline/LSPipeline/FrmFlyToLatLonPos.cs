using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmFlyToLatLonPos : Form
    {
        public string m_strLon;
        public string m_strLat;
        public string m_strAlt;
        public FrmFlyToLatLonPos()
        {
            InitializeComponent();
        }

        private void SetLatLonPos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_strLon = textbox1.Text;
            m_strLat = textBox2.Text;
            m_strAlt = textBox3.Text;
        }
    }
}
