using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;


using System.Drawing.Drawing2D; //  

using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;

using ZedGraph;


namespace WorldGIS
{
    public partial class FrmBaseLineProfillAnalysis : Form
    {

        public GSOGeoPolyline3D m_geopolyline = null;
        public GSOGlobe m_globe = null;

        private GSOPoint3ds m_pnt3ds;
        private GSOPoint3d m_pntMax;
        private GSOPoint3d m_pntMin;
        private GSOPoint3d m_pntStart;
        private GSOPoint3d m_pntEnd;
        private double m_dXTotalLength = 0;
        private double m_dSpaceLength = 0;
        private double m_dSphereLength = 0;
        private double m_dGroundLength = 0;
        private double m_dBaseAlt = 0;
        private Boolean m_bXYSameScale = false;
        private Boolean m_bSetMinX = false;
        private Boolean m_bSetMinY = false;
        public FrmBaseLineProfillAnalysis()
        {
            InitializeComponent();
        }

        private void BaseLineProfillAnalysis_Load(object sender, EventArgs e)
        {

            GraphPane myPane = zedGraphControl1.GraphPane;

            myPane.Title.Text = "基线剖面分析";

            myPane.Title.FontSpec.Family = "黑体";
            myPane.Title.FontSpec.IsBold = false;
            myPane.Title.FontSpec.Size = 18.0f;


            // myPane.Title.IsVisible = false;
            myPane.XAxis.Title.Text = "长度";

            myPane.XAxis.Title.FontSpec.Family = "黑体";
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.XAxis.Title.FontSpec.Size = 18.0f;
            myPane.YAxis.Title.Text = "高程";

            myPane.YAxis.Title.FontSpec.Family = "黑体";
            myPane.YAxis.Title.FontSpec.IsBold = false;
            myPane.YAxis.Title.FontSpec.Size = 18.0f;

            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            checkBoxSameScale.Enabled = false;
            checkBoxXmin.Enabled = false;
            checkBoxYMin.Enabled = false;

        }

        private void BaseLineProfillAnalysis_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Color FColor = Color.FromArgb(150, 150, 150);
            //Color TColor = Color.FromArgb(220, 220, 220);

            Color FColor = Color.FromArgb(255, 255, 255);

            Color TColor = Color.FromArgb(221, 221, 221);

            Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);

            g.FillRectangle(b, this.ClientRectangle);  

        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            if(m_geopolyline!=null && m_globe!=null)
            {
                checkBoxSameScale.Enabled = true;
                checkBoxXmin.Enabled = true;
                checkBoxYMin.Enabled = true;

                GSOPoint3d pntMax, pntMin, pntStart, pntEnd;

                GSOPoint3ds pnt3ds;
                double dLineLength;

                m_globe.Analysis3D.ProfileAnalyse(m_geopolyline, 100, out pnt3ds, out dLineLength, out pntMax, out pntMin, out pntStart, out pntEnd);
                
                m_pnt3ds = pnt3ds;
                m_pntMax = pntMax;
                m_pntMin = pntMin;
                m_pntStart = pntStart;
                m_pntEnd = pntEnd;
                m_dXTotalLength = dLineLength;
                m_dSphereLength = m_geopolyline.GetSphereLength(6378137.0);
                m_dSpaceLength = m_geopolyline.GetSpaceLength(false, 6378137.0);
                m_dGroundLength = m_globe.Analysis3D.GetGroundLength(m_geopolyline, false, 0);

                SetLableText();
                DrawCurveGraph();

            }
        }
        private void SetLableText()
        {

            labelStartLon.Text = "起点经度： " + m_pntStart.X.ToString("f6");
            labelStartLat.Text = "起点纬度： " + m_pntStart.Y.ToString("f6");
            labelEndLon.Text = "终点经度： " + m_pntEnd.X.ToString("f6");
            labelEndLat.Text = "终点纬度： " + m_pntEnd.Y.ToString("f6");
            labelStartAlt.Text = "起点高程： " + m_pntStart.Z.ToString("f2");
            labelEndAlt.Text = "终点高程： " + m_pntEnd.Z.ToString("f2");
            labelMaxAlt.Text = "最大高程： " + m_pntMax.Z.ToString("f2");
            labelMinAlt.Text = "最小高程： " + m_pntMin.Z.ToString("f2");
            labelSphereLenth.Text = "投影距离： " + m_dSphereLength.ToString("f2");
            labelGroundLenth.Text = "地表距离： " + m_dGroundLength.ToString("f2");
            labelSpaceLenth.Text = "直线距离： " + m_dSpaceLength.ToString("f2");
            labelPointNum.Text = "采样点数： " + m_pnt3ds.Count;

        }
        private void DrawCurveGraph()
        {


            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
            
            

            

            m_dBaseAlt = System.Convert.ToDouble(textBoxBaseAlt.Text);


   
           
            myPane.Legend.IsVisible = false;



            PointPairList listHLAbove = new PointPairList();
            PointPairList listAbove = new PointPairList();
            PointPairList listHLBelow = new PointPairList();
            PointPairList listBelow = new PointPairList();
            PointPairList listEqual = new PointPairList();
            PointPairList listBase = new PointPairList();

            ArrayList arryHLAbove = new ArrayList();
            ArrayList arryHLBelow = new ArrayList();

            ArrayList arryAbove = new ArrayList();
            ArrayList arryBelow = new ArrayList();

            


            int nPointCount = m_pnt3ds.Count;
            double dOneSegLen = m_dXTotalLength / (nPointCount - 1);

            
           
            int nSegmentType = -1; //0=m_dBaseAlt,1=above,2=below

            for (int i = 0; i < m_pnt3ds.Count; i++)
            {
                double x = i * dOneSegLen;
                double y = (int)(Math.Round(m_pnt3ds[i].Z * 100)) / 100.0; // 精确到厘米就行了
                
                if (y>m_dBaseAlt)
                {
                    // 如果当前段是基准线下面的段
                    if (nSegmentType==2)
                    {
                        arryHLBelow.Add(listHLBelow);
                        arryBelow.Add(listBelow);
                        listHLBelow=new PointPairList();
                        listBelow=new PointPairList();
                    }
                    nSegmentType = 1;
                    listAbove.Add(x, y);
                    listHLAbove.Add(x, y, m_dBaseAlt);
                    
                }
                else if(y<m_dBaseAlt)
                {
                    if (nSegmentType == 1)
                    {
                        arryHLAbove.Add(listHLAbove);
                        arryAbove.Add(listAbove);
                        listHLAbove = new PointPairList();
                        listAbove = new PointPairList();
                    }
                    nSegmentType = 2;
                    listBelow.Add(x, y);
                    listHLBelow.Add(x, m_dBaseAlt, y);
                    
                }
                else
                {
                    if (nSegmentType == 2)
                    {
                        arryHLBelow.Add(listHLBelow);
                        arryBelow.Add(listBelow);
                        listHLBelow = new PointPairList();
                        listBelow = new PointPairList();
                    }
                    else if (nSegmentType == 1)
                    {
                        arryHLAbove.Add(listHLAbove);
                        arryAbove.Add(listAbove);
                        listHLAbove = new PointPairList();
                        listAbove = new PointPairList();
                    }
                    nSegmentType = 0;
                    listEqual.Add(x, y, m_dBaseAlt);
                }
                
            }

            if (nSegmentType == 2)
            {
                arryHLBelow.Add(listHLBelow);
                arryBelow.Add(listBelow);
            }
            else if (nSegmentType == 1)
            {
                arryHLAbove.Add(listHLAbove);
                arryAbove.Add(listAbove);
            }


            listBase.Add(0, m_dBaseAlt);
            listBase.Add(m_dXTotalLength, m_dBaseAlt);


            LineItem myCurveBase = myPane.AddCurve("基线剖面", listBase, Color.Blue, SymbolType.None);
            myCurveBase.Line.IsAntiAlias = true;
            myCurveBase.Line.Width = 2;


            int k=0;
            for(k=0;k<arryHLAbove.Count;k++)
            {


                LineItem myCurveAbove = myPane.AddCurve("高于基线剖面", (PointPairList)arryAbove[k], Color.Red, SymbolType.None);
                myCurveAbove.Line.IsAntiAlias = true;
                myCurveAbove.Line.Width = 2;
                myCurveAbove.Line.IsSmooth = true;


                HiLowBarItem hlAboveItem = myPane.AddHiLowBar("高于基线", (PointPairList)arryHLAbove[k], Color.Red);
                hlAboveItem.Bar.Border.Color = Color.Red;


            }
            for (k = 0; k < arryHLBelow.Count; k++)
            {

                LineItem myCurveBelow = myPane.AddCurve("低于基线剖面", (PointPairList)arryBelow[k], Color.Green, SymbolType.None);
                myCurveBelow.Line.IsAntiAlias = true;
                myCurveBelow.Line.Width = 2;
                myCurveBelow.Line.IsSmooth = true;

                HiLowBarItem hlBolowItem = myPane.AddHiLowBar("低于基线", (PointPairList)arryHLBelow[k], Color.Green);
                hlBolowItem.Bar.Border.Color = Color.Green;

               


            }


            /*
             
          LineItem myCurveAbove = myPane.AddCurve("高于基线剖面", listAbove, Color.Red, SymbolType.None);
          //myCurve.Symbol.Fill = new Fill(Color.White);
          myCurveAbove.Line.IsAntiAlias = true;
          myCurveAbove.Line.Width = 2;
          myCurveAbove.Line.IsSmooth = true;
            


          
         // myCurveAbove.Line.Fill = new Fill(Color.Yellow, Color.LightGray, 45.0f);
             

          LineItem myCurveBelow = myPane.AddCurve("低于基线剖面", listBelow, Color.Blue, SymbolType.None);
          //myCurve.Symbol.Fill = new Fill(Color.White);
          myCurveBelow.Line.IsAntiAlias = true;
          myCurveBelow.Line.Width = 2;
          myCurveBelow.Line.IsSmooth = true;

             
          //myCurveBelow.Line.Fill = new Fill(Color.Yellow, Color.LightGray, 45.0f);


          LineItem myCurveEqual = myPane.AddCurve("等于基线剖面", listEqual, Color.DarkOrange, SymbolType.None);
          //myCurve.Symbol.Fill = new Fill(Color.White);
          myCurveEqual.Line.IsAntiAlias = true;
          myCurveEqual.Line.Width = 2;
          //myCurveEqual.Line.Fill = new Fill(Color.Yellow, Color.LightGray, 45.0f);


         // LineItem myCurveBase = myPane.AddCurve("基线剖面", listBase, Color.Green, SymbolType.None);
          //myCurveBase.Line.IsAntiAlias = true;
          //myCurveBase.Line.Width = 2;
           * */



             

         
            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.IsAxisSegmentVisible = true;

            if (m_bSetMinX)
            {
                myPane.XAxis.Scale.Min = 0;
            }


            if (m_bSetMinY)
            {
                myPane.YAxis.Scale.Min = m_pntMin.Z;
            }
                 

            //myPane.XAxis.Scale.Min = 0;

            myPane.YAxis.MajorGrid.IsVisible = true;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            //myPane.YAxis.Scale.Min = -1000;
            // myPane.YAxis.Scale.Max = 1000;


            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);


            // Enable scrollbars if needed
            //zedGraphControl1.IsShowHScrollBar = true;
            //zedGraphControl1.IsShowVScrollBar = true;
            zedGraphControl1.IsAutoScrollRange = true;


            // OPTIONAL: Show tooltips when the mouse hovers over a point
            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);


            // OPTIONAL: Handle the Zoom Event
            zedGraphControl1.ZoomEvent += new ZedGraphControl.ZoomEventHandler(MyZoomEvent);

            zedGraphControl1.AxisChange();

            if (m_bXYSameScale)
            {
                graphPane_AxisChangeEvent();
            }
            // Make sure the Graph gets redrawn
            zedGraphControl1.Invalidate();

        }

        /// <summary>
        /// Display customized tooltips when the mouse hovers over a point
        /// </summary>
        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane,
                        CurveItem curve, int iPt)
        {
            // Get the PointPair that is under the mouse
            PointPair pt = curve[iPt];

            return "(" + pt.X.ToString("f2") + "," + pt.Y.ToString("f2") + ")";
        }


        // Respond to a Zoom Event
        private void MyZoomEvent(ZedGraphControl control, ZoomState oldState,
                    ZoomState newState)
        {
            // Here we get notification everytime the user zooms
        }
        private void graphPane_AxisChangeEvent()
        {
            GraphPane graphPane = zedGraphControl1.GraphPane;
            // Correct the scale so that the two axes are 1:1 aspect ratio
            double scalex2 = (graphPane.XAxis.Scale.Max - graphPane.XAxis.Scale.Min) / graphPane.Rect.Width;
            double scaley2 = (graphPane.YAxis.Scale.Max - graphPane.YAxis.Scale.Min) / graphPane.Rect.Height;
            if (scalex2 > scaley2)
            {
                double diff = graphPane.YAxis.Scale.Max - graphPane.YAxis.Scale.Min;
                double new_diff = graphPane.Rect.Height * scalex2;

                graphPane.YAxis.Scale.Max = graphPane.YAxis.Scale.Min + new_diff;


                //graphPane.YAxis.Scale.Min -= (new_diff - diff) / 2.0;
                //graphPane.YAxis.Scale.Max += (new_diff - diff) / 2.0;
            }
            else if (scaley2 > scalex2)
            {
                double diff = graphPane.XAxis.Scale.Max - graphPane.XAxis.Scale.Min;
                double new_diff = graphPane.Rect.Width * scaley2;
                // graphPane.XAxis.Scale.Min -= (new_diff - diff) / 2.0;
                //graphPane.XAxis.Scale.Max += (new_diff - diff) / 2.0;
                graphPane.XAxis.Scale.Max = graphPane.XAxis.Scale.Min + new_diff;
            }
            // Recompute the grid lines
            float scaleFactor = graphPane.CalcScaleFactor();
            Graphics g = zedGraphControl1.CreateGraphics();
            graphPane.XAxis.Scale.PickScale(graphPane, g, scaleFactor);
            graphPane.YAxis.Scale.PickScale(graphPane, g, scaleFactor);
        }

        private void checkBoxSameScale_CheckedChanged(object sender, EventArgs e)
        {
            m_bXYSameScale = checkBoxSameScale.Checked;
            DrawCurveGraph();
        }

        private void checkBoxXmin_CheckedChanged(object sender, EventArgs e)
        {
            m_bSetMinX = checkBoxXmin.Checked;
            DrawCurveGraph();
        }

        private void checkBoxYMin_CheckedChanged(object sender, EventArgs e)
        {
            m_bSetMinY = checkBoxYMin.Checked;
            DrawCurveGraph();
        }
    }
}
