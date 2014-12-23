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
    public partial class CtrlPoint3DSpaceInfo : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        public CtrlPoint3DSpaceInfo(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void CtrlPoint3DSpaceInfo_Load(object sender, EventArgs e)
        {
            GSOGeoPoint3D geoPoint3D = m_Geometry as GSOGeoPoint3D;
            if (geoPoint3D != null)
            {

                textBoxLat.Text = geoPoint3D.Position.Y.ToString();
                textBoxLon.Text = geoPoint3D.Position.X.ToString();
                textBoxAlt.Text = geoPoint3D.Position.Z.ToString();
                // 高度模式
                switch (geoPoint3D.AltitudeMode)
                {
                    case EnumAltitudeMode.Absolute:
                        comboBoxAltMode.SelectedIndex = 0;
                        break;
                    case EnumAltitudeMode.ClampToGround:
                        comboBoxAltMode.SelectedIndex = 1;
                        textBoxAlt.Enabled = false;
                        break;
                    case EnumAltitudeMode.RelativeToGround:
                        comboBoxAltMode.SelectedIndex = 2;
                        break;
                }

            }
        }

        private void positionChanged()
        {
            GSOGeoPoint3D geoPoint3D = m_Geometry as GSOGeoPoint3D;
            if (geoPoint3D != null)
            {
                try
                {
                    geoPoint3D.X = Convert.ToDouble(textBoxLon.Text);
                    geoPoint3D.Y = Convert.ToDouble(textBoxLat.Text);
                    geoPoint3D.Z = Convert.ToDouble(textBoxAlt.Text);
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
        private void textBoxLon_TextChanged(object sender, EventArgs e)
        {
            positionChanged();
        }

        private void textBoxLat_TextChanged(object sender, EventArgs e)
        {
            positionChanged();
        }

        private void textBoxAlt_TextChanged(object sender, EventArgs e)
        {
            positionChanged();
        }

        private void comboBoxAltMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                switch (comboBoxAltMode.SelectedIndex)
                {
                    case 0:
                        m_Geometry.AltitudeMode = EnumAltitudeMode.Absolute;
                        textBoxAlt.Enabled = true;
                        break;
                    case 1:
                        m_Geometry.AltitudeMode = EnumAltitudeMode.ClampToGround;
                        textBoxAlt.Enabled = false;
                        break;
                    case 2:
                        m_Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        textBoxAlt.Enabled = true;
                        break;
                }
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }

            }
        }
    }
}
