using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;

using System.Reflection;
using System.Collections;


namespace WorldGIS
{
    public partial class FrmAtrributeMapping1 : Form
    {
        GSOGlobeControl m_globeControl = null;
        GSOFeature m_feature = null;
        GSOLayer m_layer = null;

        public FrmAtrributeMapping1(GSOGlobeControl globeControl,GSOLayer layer,GSOFeature feature)
        {
            InitializeComponent();
            m_globeControl = globeControl;
            m_feature = feature;
            m_layer = layer;
        }

        private void FrmAtrributeMapping_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            groupBox1.Controls.Add(new CtrlLineFieldsValuePage(m_feature, m_layer,m_globeControl));
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (m_feature != null)
            {

                for (int j = 0; j < m_feature.GetFieldCount(); j++)
                {
                    GSOFieldDefn field = (GSOFieldDefn)m_feature.GetFieldDefn(j);
                    if (field != null)
                    {
                        m_feature.SetValue(CtrlLineFieldsValuePage.dt.Rows[j][0].ToString(), CtrlLineFieldsValuePage.dt.Rows[j][1].ToString());
                    }
                }

            }
            this.Close();
        }  

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
