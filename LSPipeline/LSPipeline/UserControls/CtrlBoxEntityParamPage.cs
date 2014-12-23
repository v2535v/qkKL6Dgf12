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
    public partial class CtrlBoxEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoBoxEntity geoBoxEntity = null;
        public CtrlBoxEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void textBoxLength_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            ParamChanged();
        }
        private void ParamChanged()
        {
            geoBoxEntity = m_Geometry as GSOGeoBoxEntity;
            if (geoBoxEntity != null)
            {
                try
                {
                    geoBoxEntity.Height = Convert.ToDouble(textBoxHeight.Text);
                    geoBoxEntity.Width = Convert.ToDouble(textBoxWidth.Text);
                    geoBoxEntity.Length = Convert.ToDouble(textBoxLength.Text);
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

        private void CtrlBoxEntityParamPage_Load(object sender, EventArgs e)
        {
            geoBoxEntity = m_Geometry as GSOGeoBoxEntity;
            if (geoBoxEntity != null)
            {
                textBoxHeight.Text = geoBoxEntity.Height.ToString();
                textBoxWidth.Text = geoBoxEntity.Width.ToString();
                textBoxLength.Text = geoBoxEntity.Length.ToString();
            }
        }
    }
}
