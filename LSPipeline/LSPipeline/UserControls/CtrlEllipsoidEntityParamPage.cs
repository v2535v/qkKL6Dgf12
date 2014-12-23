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
    public partial class CtrlEllipsoidEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoEllipsoidEntity geoEllipsoidEntity = null;
        public CtrlEllipsoidEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
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
        private void ParamChanged()
        {
            geoEllipsoidEntity = m_Geometry as GSOGeoEllipsoidEntity;
            if (geoEllipsoidEntity != null)
            {
                try
                {
                    geoEllipsoidEntity.XRadius = Convert.ToDouble(textBoxXRadius.Text);
                    geoEllipsoidEntity.YRadius = Convert.ToDouble(textBoxYRadius.Text);
                    geoEllipsoidEntity.ZRadius = Convert.ToDouble(textBoxZRadius.Text);
                    geoEllipsoidEntity.Stacks = Convert.ToInt32(textBoxStacks.Text);
                    geoEllipsoidEntity.Slices = Convert.ToInt32(textBoxSlices.Text);
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

        private void CtrlEllipsoidEntityParamPage_Load(object sender, EventArgs e)
        {
            geoEllipsoidEntity = m_Geometry as GSOGeoEllipsoidEntity;
            if (geoEllipsoidEntity != null)
            {
                textBoxXRadius.Text = geoEllipsoidEntity.XRadius.ToString();
                textBoxYRadius.Text = geoEllipsoidEntity.YRadius.ToString();
                textBoxZRadius.Text = geoEllipsoidEntity.ZRadius.ToString();
                textBoxStacks.Text = geoEllipsoidEntity.Stacks.ToString();
                textBoxSlices.Text = geoEllipsoidEntity.Slices.ToString();

            }
        }
    }
}
