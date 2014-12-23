using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmSetDigPit : Form
    {
        public Double m_dDigPitValue = 3;
        public Boolean m_bDigPitByDepth = true;
        public Double m_dDigPitWidthAlongLine = 6;
        public FrmSetDigPit(Double dDigPitValue, Boolean bDigPitByDepth, Double dDigPitWidthAlongLine)
        {
            m_dDigPitValue = dDigPitValue;
            m_bDigPitByDepth = bDigPitByDepth;
            m_dDigPitWidthAlongLine = dDigPitWidthAlongLine;
            InitializeComponent();
        }

        private void FrmDigPitSetting_Load(object sender, EventArgs e)
        {
            if (m_bDigPitByDepth)
            {
                cbbValueMode.SelectedIndex = 0;
            }
            else
            {
                cbbValueMode.SelectedIndex = 1;
            }

            textBoxValue.Text = m_dDigPitValue.ToString();
            textBoxWidthAlongLine.Text = m_dDigPitWidthAlongLine.ToString();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (cbbValueMode.SelectedIndex==0)
            {
                m_bDigPitByDepth = true;
            }
            else
            {
                m_bDigPitByDepth = false;
            }
            try
            {
                m_dDigPitValue = Convert.ToDouble(textBoxValue.Text);
                m_dDigPitWidthAlongLine = Convert.ToDouble(textBoxWidthAlongLine.Text);
                
            }
            catch (System.Exception exp)
            {
                Log.PublishTxt(exp);
            }


        }
    }
}
