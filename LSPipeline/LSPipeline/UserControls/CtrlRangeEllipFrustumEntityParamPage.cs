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
    public partial class CtrlRangeEllipFrustumEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoRangeEllipFrustumEntity geoRangeEllipFrustumEntity = null;
        public CtrlRangeEllipFrustumEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
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

        private void textBoxStartAngle_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxEndAngle_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void ParamChanged()
        {
            geoRangeEllipFrustumEntity = m_Geometry as GSOGeoRangeEllipFrustumEntity;
            if (geoRangeEllipFrustumEntity != null)
            {
                try
                {
                    geoRangeEllipFrustumEntity.TopXRadius = Convert.ToDouble(textBoxTopXRadius.Text);
                    geoRangeEllipFrustumEntity.TopYRadius = Convert.ToDouble(textBoxTopYRadius.Text);
                    geoRangeEllipFrustumEntity.BottomXRadius = Convert.ToDouble(textBoxBottomXRadius.Text);
                    geoRangeEllipFrustumEntity.BottomYRadius = Convert.ToDouble(textBoxBottomYRadius.Text);
                    geoRangeEllipFrustumEntity.Length = Convert.ToDouble(textBoxLength.Text);
                    geoRangeEllipFrustumEntity.Slices = Convert.ToInt32(textBoxSlices.Text);
                    geoRangeEllipFrustumEntity.StartAngle = Convert.ToDouble(textBoxStartAngle.Text);
                    geoRangeEllipFrustumEntity.EndAngle = Convert.ToDouble(textBoxEndAngle.Text);
                    GSOEntityStyle3D style = new GSOEntityStyle3D();
                    style.UsingSingleColor = true;
                    geoRangeEllipFrustumEntity.Style = style;
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
        private void CtrlRangeEllipFrustumEntityParamPage_Load(object sender, EventArgs e)
        {
            geoRangeEllipFrustumEntity = m_Geometry as GSOGeoRangeEllipFrustumEntity;
            if (geoRangeEllipFrustumEntity != null)
            {
                textBoxTopXRadius.Text = geoRangeEllipFrustumEntity.TopXRadius.ToString();
                textBoxTopYRadius.Text = geoRangeEllipFrustumEntity.TopYRadius.ToString();
                textBoxBottomXRadius.Text = geoRangeEllipFrustumEntity.BottomXRadius.ToString();
                textBoxBottomYRadius.Text = geoRangeEllipFrustumEntity.BottomYRadius.ToString();


                textBoxLength.Text = geoRangeEllipFrustumEntity.Length.ToString();
                textBoxSlices.Text = geoRangeEllipFrustumEntity.Slices.ToString();

                textBoxStartAngle.Text = geoRangeEllipFrustumEntity.StartAngle.ToString();
                textBoxEndAngle.Text = geoRangeEllipFrustumEntity.EndAngle.ToString();

            }
        }
    }
}
