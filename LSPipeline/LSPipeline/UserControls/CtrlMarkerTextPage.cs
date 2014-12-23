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
    public partial class CtrlMarkerTextPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        public CtrlMarkerTextPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void CtrlMarkerStylePage_Load(object sender, EventArgs e)
        {
            GSOGeoMarker geoMarker=m_Geometry as GSOGeoMarker;
            if (geoMarker!=null)
            {
                textMarkerText.Text = geoMarker.Text;
            }
        }

        private void textMarkerText_TextChanged(object sender, EventArgs e)
        {
            GSOGeoMarker geoMarker = m_Geometry as GSOGeoMarker;
            if (geoMarker != null)
            {
               geoMarker.Text= textMarkerText.Text;
               if (m_GlobeControl!=null)
               {
                    m_GlobeControl.Refresh();
               }
            }

        }
    }
}
