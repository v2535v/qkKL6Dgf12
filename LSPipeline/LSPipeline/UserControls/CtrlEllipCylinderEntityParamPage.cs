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
    public partial class CtrlEllipCylinderEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoEllipCylinderEntity geoEllipCylinderEntity = null;
        public CtrlEllipCylinderEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void textBoxXRadius_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxYRadius_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxLength_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxSlices_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }
        private void ParamChanged()
        {
            geoEllipCylinderEntity = m_Geometry as GSOGeoEllipCylinderEntity;
            if (geoEllipCylinderEntity != null)
            {
                try
                {
                    geoEllipCylinderEntity.XRadius = Convert.ToDouble(textBoxXRadius.Text);
                    geoEllipCylinderEntity.YRadius = Convert.ToDouble(textBoxYRadius.Text);
                    geoEllipCylinderEntity.Length = Convert.ToDouble(textBoxLength.Text);
                    geoEllipCylinderEntity.Slices = Convert.ToInt32(textBoxSlices.Text);
                    if (m_GlobeControl != null)
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

        private void CtrlEllipCylinderEntityParamPage_Load(object sender, EventArgs e)
        {
            geoEllipCylinderEntity = m_Geometry as GSOGeoEllipCylinderEntity;
            if (geoEllipCylinderEntity != null)
            {
                textBoxXRadius.Text = geoEllipCylinderEntity.XRadius.ToString();
                textBoxYRadius.Text = geoEllipCylinderEntity.YRadius.ToString();
                textBoxLength.Text = geoEllipCylinderEntity.Length.ToString();
                textBoxSlices.Text = geoEllipCylinderEntity.Slices.ToString();

            }
        }
    }
}
