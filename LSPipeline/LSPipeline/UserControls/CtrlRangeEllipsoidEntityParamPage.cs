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
    public partial class CtrlRangeEllipsoidEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoRangeEllipsoidEntity geoRangeEllipsoidEntity = null;
        public CtrlRangeEllipsoidEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
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

        private void textBoxZRadius_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxStacks_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxSlices_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxStartLon_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxEndLon_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxStartLat_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxEndLat_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void CtrlRangeEllipsoidEntityParamPage_Load(object sender, EventArgs e)
        {
            geoRangeEllipsoidEntity = m_Geometry as GSOGeoRangeEllipsoidEntity;
            if (geoRangeEllipsoidEntity != null)
            {
                textBoxXRadius.Text = geoRangeEllipsoidEntity.XRadius.ToString();
                textBoxYRadius.Text = geoRangeEllipsoidEntity.YRadius.ToString();
                textBoxZRadius.Text = geoRangeEllipsoidEntity.ZRadius.ToString();
                textBoxStacks.Text = geoRangeEllipsoidEntity.Stacks.ToString();
                textBoxSlices.Text = geoRangeEllipsoidEntity.Slices.ToString();
                textBoxStartLat.Text = geoRangeEllipsoidEntity.StartLat.ToString();
                textBoxEndLat.Text = geoRangeEllipsoidEntity.EndLat.ToString();
                textBoxStartLon.Text = geoRangeEllipsoidEntity.StartLon.ToString();
                textBoxEndLon.Text = geoRangeEllipsoidEntity.EndLon.ToString();

            }
        }
        private void ParamChanged()
        {
            geoRangeEllipsoidEntity = m_Geometry as GSOGeoRangeEllipsoidEntity;
            if (geoRangeEllipsoidEntity != null)
            {
                try
                {
                    geoRangeEllipsoidEntity.XRadius = Convert.ToDouble(textBoxXRadius.Text);
                    geoRangeEllipsoidEntity.YRadius = Convert.ToDouble(textBoxYRadius.Text);
                    geoRangeEllipsoidEntity.ZRadius = Convert.ToDouble(textBoxZRadius.Text);
                    geoRangeEllipsoidEntity.Stacks = Convert.ToInt32(textBoxStacks.Text);
                    geoRangeEllipsoidEntity.Slices = Convert.ToInt32(textBoxSlices.Text);
                    geoRangeEllipsoidEntity.StartLat = Convert.ToDouble(textBoxStartLat.Text);
                    geoRangeEllipsoidEntity.EndLat = Convert.ToDouble(textBoxEndLat.Text);
                    geoRangeEllipsoidEntity.StartLon = Convert.ToDouble(textBoxStartLon.Text);
                    geoRangeEllipsoidEntity.EndLon = Convert.ToDouble(textBoxEndLon.Text);
                    GSOEntityStyle3D style = new GSOEntityStyle3D();
                    style.UsingSingleColor = true;
                    geoRangeEllipsoidEntity.Style = style;
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
    }
}
