using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D; 

using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;

using ZedGraph;


namespace WorldGIS
{
    public partial class FrmAnalysisDigFill : Form
    {

        public GSOGeoPolygon3D m_polygon3D =null;
        public GSOGlobe m_globe = null;
        GSOPoint3d m_pntMaxAlt;
        GSOPoint3d m_pntMinAlt;
        double m_dDigVolume=0;
        double m_dFillVolume = 0;
        double m_dTotalArea = 0;
        double m_dDigArea = 0;
        double m_dFillArea = 0;


        private GSOFeature m_AltFeature = null;

        public FrmAnalysisDigFill()
        {
            InitializeComponent();
        }

        private void DigFillAnalysisDlg_Paint(object sender, PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;

            //Color FColor = Color.FromArgb(150, 150, 150);

            Color FColor = Color.FromArgb(255, 255, 255);

            Color TColor = Color.FromArgb(221,221,221);
            //Color TColor = Color.FromArgb(220, 220, 220);

            Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);

            g.FillRectangle(b, this.ClientRectangle);  
        

        }

         
        private void SetText()
        {

            textBoxPntMax.Text = m_pntMaxAlt.X.ToString("f6") + "," + m_pntMaxAlt.Y.ToString("f6") + "," + m_pntMaxAlt.Z.ToString("f2");
            textBoxPntMin.Text = m_pntMinAlt.X.ToString("f6") + "," + m_pntMinAlt.Y.ToString("f6") + "," + m_pntMinAlt.Z.ToString("f2");
            textBoxFillVolume.Text = m_dFillVolume.ToString("f2") + " 立方米";
            textBoxDigVolume.Text = m_dDigVolume.ToString("f2") + " 立方米";

            double dDFVolume=m_dDigVolume+m_dFillVolume;
            textBoxDFVolume.Text = dDFVolume.ToString("f2") + " 立方米";
            textBoxFillArea.Text = m_dFillArea.ToString("f2") + " 平方米";
            textBoxDigArea.Text = m_dDigArea.ToString("f2") + " 平方米";

            double dDFArea = m_dFillArea + m_dDigArea;

            textBoxDFArea.Text = dDFArea.ToString("f2") + " 平方米";
            textBoxTotalArea.Text = m_dTotalArea.ToString("f2") + " 平方米";
            

        }

        private void DigFillAnalysisDlg_Load(object sender, EventArgs e)
        {
            //textBoxDestAlt.Text = "0";
            
        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
             
            
             
             
            if (m_globe != null && m_polygon3D != null)
            {
                double dAlt=System.Convert.ToDouble(textBoxDestAlt.Text);
                m_globe.Analysis3D.DigFillAnalyse(m_polygon3D, dAlt, out m_dDigVolume, out m_dFillVolume,
                    out m_dDigArea, out m_dFillArea, out m_dTotalArea, out m_pntMaxAlt, out m_pntMinAlt, false, 0);

                //double dTempArea = m_polygon3D.Area;

                //double dDiff = dTempArea - m_dTotalArea;

                //double dRadio = dDiff / dTempArea;


                GSOFeature altFeature = null;
               GSOFeatures tempFeatures= m_globe.MemoryLayer.GetFeatureByName("DigFillAltPolygon",true);
                if (tempFeatures.Length>0)
                {
                    altFeature = tempFeatures[0];
                }
                GSOGeoPolygon3D newPolygon = (GSOGeoPolygon3D)m_polygon3D.Clone();
                newPolygon.SetAltitude(dAlt);
                newPolygon.AltitudeMode = EnumAltitudeMode.Absolute;
               
                GSOExtrudeStyle extrudeStyle = new GSOExtrudeStyle();
                extrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeToValue;
                extrudeStyle.ExtrudeValue = m_pntMinAlt.Z;
                extrudeStyle.TailPartVisible = false;

                GSOSimplePolygonStyle3D extrudePolygonStyle = new GSOSimplePolygonStyle3D();
                extrudePolygonStyle.FillColor = Color.FromArgb(150, 0, 255, 0);
                extrudeStyle.BodyStyle = extrudePolygonStyle;



                GSOSimplePolygonStyle3D polygonStyle = new GSOSimplePolygonStyle3D();
                polygonStyle.FillColor = Color.FromArgb(200, 0, 0, 255);

                newPolygon.Style = polygonStyle;
                newPolygon.ExtrudeStyle = extrudeStyle;


                if (m_AltFeature == null || m_AltFeature.IsDeleted)
                {
                    m_AltFeature = new GSOFeature();
                    m_AltFeature.Name = "DigFillAltPolygon";
                    m_AltFeature.Geometry = newPolygon;
                    m_globe.MemoryLayer.AddFeature(m_AltFeature);
                }
                else
                {
                    m_AltFeature.Geometry = newPolygon;
                }
                
               
               

                m_globe.Refresh();

                

                SetText();
            }

        }

        private void DigFillAnalysisDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_AltFeature!=null)
            {
                m_globe.MemoryLayer.RemoveFeatureByID(m_AltFeature.ID);
                m_AltFeature = null;
            }
            
        }

       
        
    }
}
