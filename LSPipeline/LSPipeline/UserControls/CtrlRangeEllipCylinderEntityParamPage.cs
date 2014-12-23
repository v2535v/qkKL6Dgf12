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
    public partial class CtrlRangeEllipCylinderEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoRangeEllipCylinderEntity geoRangeEllipCylinderEntity = null;
        public CtrlRangeEllipCylinderEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
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
            geoRangeEllipCylinderEntity = m_Geometry as GSOGeoRangeEllipCylinderEntity;
            if (geoRangeEllipCylinderEntity != null)
            {
                try
                {
                    geoRangeEllipCylinderEntity.XRadius = Convert.ToDouble(textBoxXRadius.Text);
                    geoRangeEllipCylinderEntity.YRadius = Convert.ToDouble(textBoxYRadius.Text);
                    geoRangeEllipCylinderEntity.Length = Convert.ToDouble(textBoxLength.Text);
                    geoRangeEllipCylinderEntity.Slices = Convert.ToInt32(textBoxSlices.Text);
                    geoRangeEllipCylinderEntity.StartAngle = Convert.ToDouble(textBoxStartAngle.Text);
                    geoRangeEllipCylinderEntity.EndAngle = Convert.ToDouble(textBoxEndAngle.Text);
                    GSOEntityStyle3D style = new GSOEntityStyle3D();
                    style.UsingSingleColor = true;
                    geoRangeEllipCylinderEntity.Style = style;
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

        private void CtrlRangeEllipCylinderEntityParamPage_Load(object sender, EventArgs e)
        {
            geoRangeEllipCylinderEntity = m_Geometry as GSOGeoRangeEllipCylinderEntity;
            if (geoRangeEllipCylinderEntity != null)
            {
                textBoxXRadius.Text = geoRangeEllipCylinderEntity.XRadius.ToString();
                textBoxYRadius.Text = geoRangeEllipCylinderEntity.YRadius.ToString();
                textBoxLength.Text = geoRangeEllipCylinderEntity.Length.ToString();
                textBoxSlices.Text = geoRangeEllipCylinderEntity.Slices.ToString();
                textBoxStartAngle.Text = geoRangeEllipCylinderEntity.StartAngle.ToString();
                textBoxEndAngle.Text = geoRangeEllipCylinderEntity.EndAngle.ToString();

            }
        }
    }
}
