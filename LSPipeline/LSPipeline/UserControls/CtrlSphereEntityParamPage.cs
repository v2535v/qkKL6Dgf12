using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
    public partial class CtrlSphereEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        public CtrlSphereEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void textBoxRadius_TextChanged(object sender, EventArgs e)
        {
            GSOGeoSphereEntity geoSphereEntity = m_Geometry as GSOGeoSphereEntity;
            if (geoSphereEntity != null)
            {
                try
                {
                    geoSphereEntity.Radius = Convert.ToDouble(textBoxRadius.Text);
                    if (m_GlobeControl!=null)
                    {
                        m_GlobeControl.Refresh();
                    }

                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
                

            }
        }

        private void CtrlSphereEntityParamPage_Load(object sender, EventArgs e)
        {
            GSOGeoSphereEntity geoSphereEntity = m_Geometry as GSOGeoSphereEntity;
            if (geoSphereEntity != null)
            {
                textBoxRadius.Text = geoSphereEntity.Radius.ToString();
            }
        }
    }
}
