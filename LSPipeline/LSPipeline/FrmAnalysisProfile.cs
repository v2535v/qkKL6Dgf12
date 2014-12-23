using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 

//using System.Linq;  
using System.Drawing.Drawing2D; //  

using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;

using ZedGraph;



namespace WorldGIS
{
    public partial class FrmAnalysisProfile : Form
    {
        public GSOPoint3ds  m_pnt3ds;
        public GSOPoint3d m_pntMax;
        public GSOPoint3d m_pntMin;
        public GSOPoint3d m_pntStart;
        public GSOPoint3d m_pntEnd;
        public double m_dXTotalLength = 0;
        public double m_dSpaceLength=0;
        public double m_dSphereLength=0;
        public double m_dGroundLength=0;
        private Boolean m_bXYSameScale = false;
        private Boolean m_bSetMinX = false;
        private Boolean m_bSetMinY = false;
        public FrmAnalysisProfile()
        {
            InitializeComponent();
        }

        private void ProfileAnalysisDlg_Resize(object sender, EventArgs e)
        {
            this.Invalidate();  


        }

        private void ProfileAnalysisDlg_Paint(object sender, PaintEventArgs e)
        {
              Graphics g = e.Graphics;

             // Color FColor = Color.FromArgb(150, 150, 150);
             // Color TColor = Color.FromArgb(220, 220, 220);


              Color FColor = Color.FromArgb(255, 255, 255);

              Color TColor = Color.FromArgb(221, 221, 221);
              
             Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);  

            g.FillRectangle(b, this.ClientRectangle);  


        }
        private void DrawCurveGraph()
        {

            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
            

            zedGraphControl1.GraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.SteelBlue, 45.0F);
            if (m_pnt3ds != null)
            {


                GraphPane myPane = zedGraphControl1.GraphPane;

                
                myPane.Legend.IsVisible = false;



                PointPairList list = new PointPairList();

                int nPointCount = m_pnt3ds.Count;
                double dOneSegLen = m_dXTotalLength / (nPointCount - 1);

                for (int i = 0; i < m_pnt3ds.Count; i++)
                {
                    double x = i * dOneSegLen;
                    double y = (int)(Math.Round(m_pnt3ds[i].Z * 100)) / 100.0; // 精确到厘米就行了
                    list.Add(x, y);
                }


                myPane.AddStick("采样线", list, Color.Blue);

                LineItem myCurve = myPane.AddCurve("剖面", list, Color.Blue, SymbolType.None);
                //myCurve.Symbol.Fill = new Fill(Color.White);
                myCurve.Line.IsAntiAlias = true;
                myCurve.Line.IsSmooth = true;
                myCurve.Line.Width = 2;
                myCurve.Line.Fill = new Fill(Color.Yellow, Color.LightGray, 45.0f);






                // Show the x axis grid
                myPane.XAxis.MajorGrid.IsVisible = true;
                myPane.XAxis.IsAxisSegmentVisible = true;

               
                if(m_bSetMinX)
                {
                    myPane.XAxis.Scale.Min = 0;
                }
                 

                if (m_bSetMinY)
                {
                    myPane.YAxis.Scale.Min = m_pntMin.Z;
                }
                 






                // Make the Y axis scale red
                //myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
                //myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
                // turn off the opposite tics so the Y tics don't show up on the Y2 axis
                //myPane.YAxis.MajorTic.IsOpposite = false;
                // myPane.YAxis.MinorTic.IsOpposite = false;



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



                // Size the control to fit the window
                //SetSize();

                // Tell ZedGraph to calculate the axis ranges
                // Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
                // up the proper scrolling parameters
                zedGraphControl1.AxisChange();
                if (m_bXYSameScale)
                {
                    graphPane_AxisChangeEvent();
                }
                
                // Make sure the Graph gets redrawn
                zedGraphControl1.Invalidate();

                SetLableText();

            }
            

        }
        private void ProfileAnalysisDlg_Load(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            myPane.Title.Text = "剖面分析";

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

            DrawCurveGraph();
        }

        private void SetLableText()
        {
            
            labelStartLon.Text="起点经度： "+m_pntStart.X.ToString("f6");
            labelStartLat.Text="起点纬度： "+m_pntStart.Y.ToString("f6");
            labelEndLon.Text="终点经度： "+m_pntEnd.X.ToString("f6");
            labelEndLat.Text="终点纬度： "+m_pntEnd.Y.ToString("f6");
            labelStartAlt.Text = "起点高程： " + m_pntStart.Z.ToString("f2");
            labelEndAlt.Text = "终点高程： " + m_pntEnd.Z.ToString("f2");
            labelMaxAlt.Text = "最大高程： " + m_pntMax.Z.ToString("f2");
            labelMinAlt.Text = "最低高程： " + m_pntMin.Z.ToString("f2");
            labelSphereLenth.Text = "投影距离： " + m_dSphereLength.ToString("f2");
            labelGroundLenth.Text = "地表距离： " + m_dGroundLength.ToString("f2");
            labelSpaceLenth.Text = "直线距离： " + m_dSpaceLength.ToString("f2");
            labelPointNum.Text = "采样点数： " + m_pnt3ds.Count;

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

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        

        
    }
}
