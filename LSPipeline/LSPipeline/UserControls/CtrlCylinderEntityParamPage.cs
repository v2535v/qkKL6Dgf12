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
    public partial class CtrlCylinderEntityParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        GSOGeoCylinderEntity geoCylinderEntity = null;
        public CtrlCylinderEntityParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void textBoxRadius_TextChanged(object sender, EventArgs e)
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
            geoCylinderEntity = m_Geometry as GSOGeoCylinderEntity;
            if (geoCylinderEntity != null)
            {
                try
                {
                    geoCylinderEntity.Slices = Convert.ToInt32(textBoxSlices.Text);
                    geoCylinderEntity.Radius = Convert.ToDouble(textBoxRadius.Text);
                    geoCylinderEntity.Length = Convert.ToDouble(textBoxLength.Text);
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

        private void CtrlCylinderEntityParamPage_Load(object sender, EventArgs e)
        {
            geoCylinderEntity = m_Geometry as GSOGeoCylinderEntity;
            if (geoCylinderEntity != null)
            {
                textBoxLength.Text = geoCylinderEntity.Length.ToString();
                textBoxSlices.Text = geoCylinderEntity.Slices.ToString();
                textBoxRadius.Text = geoCylinderEntity.Radius.ToString();
            }
        }
    }
}
