using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmSetObjectVisiblePixelSize : Form
    {
        public double m_dMaxVisiblePixelSize = -1;
        public double m_dMinVisiblePixelSize = -1;
        public FrmSetObjectVisiblePixelSize()
        {
            InitializeComponent();
        }
        private void VisiblePixelSizeDlg_Load(object sender, EventArgs e)
        {
            textBoxMaxVisiblePixelSize.Text = m_dMaxVisiblePixelSize.ToString();
            textBoxMinVisiblePixelSize.Text = m_dMinVisiblePixelSize.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_dMaxVisiblePixelSize = Convert.ToDouble(textBoxMaxVisiblePixelSize.Text);
            m_dMinVisiblePixelSize = Convert.ToDouble(textBoxMinVisiblePixelSize.Text);

        }
    }
}
