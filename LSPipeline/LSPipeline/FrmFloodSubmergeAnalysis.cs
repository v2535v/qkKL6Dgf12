using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D; //  

using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;


namespace WorldGIS
{
    public partial class FrmFloodSubmergeAnalysis : Form
    {

        public GSOGeoPolygon3D m_polygon3D = null;
        public GSOGlobe m_globe = null;
        private GSOPoint3d m_pntMaxAlt;
        private GSOPoint3d m_pntMinAlt;
        private double m_dTotalArea = 0;
        private double m_dFloodArea = 0;
        private double m_dBaseAlt = 0;
        private GSOFeature m_WaterFeature = null;
        
        public FrmFloodSubmergeAnalysis()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            
            if (m_WaterFeature != null)
            {
                m_dBaseAlt = System.Convert.ToDouble(textBoxWaterAlt.Text);
                if (m_dBaseAlt > m_pntMaxAlt.Z)
                {
                    m_dBaseAlt = m_pntMaxAlt.Z;
                }
                if (m_dBaseAlt < m_pntMinAlt.Z)
                {
                    m_dBaseAlt = m_pntMinAlt.Z;
                }
                textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");
                trackBarAlt.Value = Math.Min((int)m_dBaseAlt, trackBarAlt.Maximum);
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                geoWater.SetAltitude(m_dBaseAlt);

                int nF = System.Convert.ToInt32(textBoxFrequency.Text);
                if (nF <= 0)
                {
                    nF = 1;
                }
                timerPlay.Interval = (int)(1000.0 / nF);
                timerPlay.Start();

            }
            else
            {
                MessageBox.Show("请先进行分析！");

            }


            
        }
        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            timerPlay.Stop();
            Analysis();
            SetText();
            ShowWater();
        }

        private void Analysis()
        {
            if (m_globe != null && m_polygon3D != null)
            {

                m_dBaseAlt = System.Convert.ToDouble(textBoxWaterAlt.Text);

                m_globe.Analysis3D.NoSourceFloodAnalyse(m_polygon3D, m_dBaseAlt,out m_dFloodArea, out m_dTotalArea,
                    out m_pntMaxAlt, out m_pntMinAlt, false,0);
            }

        }

        private void FloodSubmergeAnalysisDlg_Paint(object sender, PaintEventArgs e)
        {
            /*
            Graphics g = e.Graphics;
  

            Color FColor = Color.FromArgb(255, 255, 255);

            Color TColor = Color.FromArgb(221, 221, 221);
             

            Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);

            g.FillRectangle(b, this.ClientRectangle);  
             * */

        }
        
        private void SetText()
        {

            textBoxPntMax.Text = m_pntMaxAlt.X.ToString("f6") + "," + m_pntMaxAlt.Y.ToString("f6") + "," + m_pntMaxAlt.Z.ToString("f2");
            textBoxPntMin.Text = m_pntMinAlt.X.ToString("f6") + "," + m_pntMinAlt.Y.ToString("f6") + "," + m_pntMinAlt.Z.ToString("f2");

            textBoxFloodArea.Text = m_dFloodArea.ToString("f2") + " 平方米";
            
            textBoxTotalArea.Text = m_dTotalArea.ToString("f2") + " 平方米";


        }

        private void FloodSubmergeAnalysisDlg_Load(object sender, EventArgs e)
        {
             
             
        }
        private void Clear()
        {
            if (m_WaterFeature!=null)
            {
                m_globe.MemoryLayer.RemoveFeatureByID(m_WaterFeature.ID);
                m_WaterFeature = null;
            }
            
        }
        private void ShowWater()
        {

            if (m_WaterFeature==null || m_WaterFeature.IsDeleted)
            {

                m_dBaseAlt = m_pntMinAlt.Z;

                GSOGeoWater geoWater = m_polygon3D.ConvertToGeoWater();

                GSOExtrudeStyle extrudeStyle = new GSOExtrudeStyle();

                if (checkBoxExtrude.Checked)
                {
                    extrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeToValue;
                }
                else
                {
                    extrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeNone;
                }

                extrudeStyle.ExtrudeValue = m_pntMinAlt.Z;
                extrudeStyle.TailPartVisible = false;


                GSOSimplePolygonStyle3D polygonStyle = new GSOSimplePolygonStyle3D();
                polygonStyle.FillColor = Color.FromArgb(200, 0, 0, 255);

                extrudeStyle.BodyStyle = polygonStyle;

                geoWater.ExtrudeStyle = extrudeStyle;


                geoWater.AltitudeMode = EnumAltitudeMode.Absolute;
                geoWater.SetAltitude(m_dBaseAlt);
                geoWater.ReflectSky = false;
                geoWater.WaveWidth = 0.1;
                geoWater.Play();



                m_WaterFeature = new GSOFeature();
                m_WaterFeature.Geometry = geoWater;
                m_globe.MemoryLayer.AddFeature(m_WaterFeature);
                m_globe.Refresh();

                trackBarAlt.Maximum = (int)m_pntMaxAlt.Z;
                trackBarAlt.Minimum = (int)m_pntMinAlt.Z;
                trackBarAlt.Value = trackBarAlt.Minimum;
                textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");
            
            }
            else
            {
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                geoWater.SetAltitude(m_dBaseAlt);
                m_globe.Refresh();

                trackBarAlt.Maximum = (int)m_pntMaxAlt.Z;
                trackBarAlt.Minimum = (int)m_pntMinAlt.Z;

            }
            
        }

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            //Analysis();
            //SetText();
           

            if (m_WaterFeature!=null)
            {
                if (m_dBaseAlt>m_pntMaxAlt.Z)
                {
                    if (checkBoxLoopPlay.Checked)
                    {
                        m_dBaseAlt = m_pntMinAlt.Z;
                    }
                    else
                    {
                        timerPlay.Stop();
                    }
                    
                }

                m_dBaseAlt += (double)numericUpDownAddPerTime.Value;


                m_globe.Analysis3D.FetchNoSourceFloodAnalyseResult(m_dBaseAlt, out m_dFloodArea, out m_dTotalArea,
              out m_pntMaxAlt, out m_pntMinAlt);

                SetText();


                textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");
                trackBarAlt.Value = Math.Min((int)m_dBaseAlt, trackBarAlt.Maximum);
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                geoWater.SetAltitude(m_dBaseAlt);


           

            }
        }

        private void trackBarAlt_Scroll(object sender, EventArgs e)
        {
            textBoxWaterAlt.Text=trackBarAlt.Value.ToString();
            

        }
        private void numericUpDownAddPerTime_ValueChanged(object sender, EventArgs e)
        {
            trackBarAlt.TickFrequency = System.Convert.ToInt32(numericUpDownAddPerTime.Value);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerPlay.Stop();
        }

        private void checkBoxExtrude_CheckedChanged(object sender, EventArgs e)
        {
            if (m_WaterFeature != null)
            {
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                if (checkBoxExtrude.Checked)
                {   
                    geoWater.ExtrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeToValue;
                }
                else
                {
                    geoWater.ExtrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeNone;

                }
               
            }

        }

        private void FloodSubmergeAnalysisDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear();
        }

        private void buttonSetPlayParam_Click(object sender, EventArgs e)
        {
            int nF = System.Convert.ToInt32(textBoxFrequency.Text);
            if (nF <= 0)
            {
                nF = 1;
            }
            numericUpDownAddPerTime.Maximum = (decimal)m_pntMaxAlt.Z;
            numericUpDownAddPerTime.Minimum = 0;

            double dAltDiff = (m_pntMaxAlt.Z - m_pntMinAlt.Z);

            numericUpDownAddPerTime.Increment = (decimal)(0.1*dAltDiff / nF); // 用10秒播放完

            numericUpDownAddPerTime.Value = numericUpDownAddPerTime.Increment;



            trackBarAlt.Maximum = (int)m_pntMaxAlt.Z;
            trackBarAlt.Minimum = (int)m_pntMinAlt.Z;
            trackBarAlt.Value = trackBarAlt.Minimum;

            int nTF = (int)numericUpDownAddPerTime.Increment;

            if (nTF < 1)
            {
                nTF = 1;
            }
            trackBarAlt.TickFrequency = nTF;


            m_dBaseAlt = m_pntMinAlt.Z;
            textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");



        }

        private void buttonReplay_Click(object sender, EventArgs e)
        {
            
            if (m_WaterFeature != null)
            {
                m_dBaseAlt = m_pntMinAlt.Z;
                textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");
                trackBarAlt.Value = trackBarAlt.Minimum;
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                geoWater.SetAltitude(m_dBaseAlt);


                int nF = System.Convert.ToInt32(textBoxFrequency.Text);
                if (nF <= 0)
                {
                    nF = 1;
                }
                timerPlay.Interval = (int)(1000.0 / nF);
                timerPlay.Start();


            }
            else
            {
                MessageBox.Show("请先进行分析！");

            }

        }

         
        


    }
}
