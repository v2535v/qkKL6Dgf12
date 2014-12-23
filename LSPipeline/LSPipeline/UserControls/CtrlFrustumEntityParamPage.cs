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
    public partial class CtrlFrustumEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoFrustumEntity geoFrustumEntity = null;
        public CtrlFrustumEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void textBoxTopRadius_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxBottomRadius_TextChanged(object sender, EventArgs e)
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
            geoFrustumEntity = m_Geometry as GSOGeoFrustumEntity;
            if (geoFrustumEntity != null)
            {
                try
                {
                    geoFrustumEntity.TopRadius = Convert.ToDouble(textBoxTopRadius.Text);
                    geoFrustumEntity.BottomRadius = Convert.ToDouble(textBoxBottomRadius.Text);
                    geoFrustumEntity.Length = Convert.ToDouble(textBoxLength.Text);
                    geoFrustumEntity.Slices = Convert.ToInt32(textBoxSlices.Text);
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

        private void CtrlFrustumEntityParamPage_Load(object sender, EventArgs e)
        {
            geoFrustumEntity = m_Geometry as GSOGeoFrustumEntity;
            if (geoFrustumEntity != null)
            {
                textBoxTopRadius.Text = geoFrustumEntity.TopRadius.ToString();
                textBoxBottomRadius.Text = geoFrustumEntity.BottomRadius.ToString();
                textBoxLength.Text = geoFrustumEntity.Length.ToString();
                textBoxSlices.Text = geoFrustumEntity.Slices.ToString();

            }
        }
    }
}
