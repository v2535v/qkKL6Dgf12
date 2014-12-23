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
    public partial class CtrlEllipFrustumEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoEllipFrustumEntity geoEllipFrustumEntity = null;
        public CtrlEllipFrustumEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void textBoxTopXRadius_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxTopYRadius_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxBottomXRadius_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxBottomYRadius_TextChanged(object sender, EventArgs e)
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
            geoEllipFrustumEntity = m_Geometry as GSOGeoEllipFrustumEntity;
            if (geoEllipFrustumEntity != null)
            {
                try
                {
                    geoEllipFrustumEntity.TopXRadius = Convert.ToDouble(textBoxTopXRadius.Text);
                    geoEllipFrustumEntity.TopYRadius = Convert.ToDouble(textBoxTopYRadius.Text);
                    geoEllipFrustumEntity.BottomXRadius = Convert.ToDouble(textBoxBottomXRadius.Text);
                    geoEllipFrustumEntity.BottomYRadius = Convert.ToDouble(textBoxBottomYRadius.Text);
                    geoEllipFrustumEntity.Length = Convert.ToDouble(textBoxLength.Text);
                    geoEllipFrustumEntity.Slices = Convert.ToInt32(textBoxSlices.Text);
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

        private void CtrlEllipFrustumEntityParamPage_Load(object sender, EventArgs e)
        {
            geoEllipFrustumEntity = m_Geometry as GSOGeoEllipFrustumEntity;
            if (geoEllipFrustumEntity != null)
            {
                textBoxTopXRadius.Text = geoEllipFrustumEntity.TopXRadius.ToString();
                textBoxTopYRadius.Text = geoEllipFrustumEntity.TopYRadius.ToString();
                textBoxBottomXRadius.Text = geoEllipFrustumEntity.BottomXRadius.ToString();
                textBoxBottomYRadius.Text = geoEllipFrustumEntity.BottomYRadius.ToString();
                textBoxLength.Text = geoEllipFrustumEntity.Length.ToString();
                textBoxSlices.Text = geoEllipFrustumEntity.Slices.ToString();
            }
        }
    }
}
