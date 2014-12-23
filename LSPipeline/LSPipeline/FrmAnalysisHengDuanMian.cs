using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

using System.Collections;
using GeoScene.Globe;
using GeoScene.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace WorldGIS
{
    public partial class FrmAnalysisHengDuanMian : Form
    {
        private ArrayList listPoint = new ArrayList();
        private ArrayList listFeat = new ArrayList();
        GSOGeoPolyline3D line = new GSOGeoPolyline3D(); //创建线对象

        private static FrmAnalysisHengDuanMian allPipelineAnalysis = null;
        public bool isShowFirst = false;

        static ArrayList list = new ArrayList();
        static DataTable table = new DataTable();
        static DataTable showTable = new DataTable();
        GSOGlobeControl globeControl1;
        private FrmAnalysisHengDuanMian() 
        {
        
        }
        public static FrmAnalysisHengDuanMian GetForm(ArrayList arraylistP, ArrayList arraylistF, GSOGeoPolyline3D _line, GSOGlobeControl _ctl)
        {
            if (allPipelineAnalysis == null)
            {
                allPipelineAnalysis = new FrmAnalysisHengDuanMian(arraylistP, arraylistF, _line,_ctl);
            }
            else
            {
                allPipelineAnalysis.listPoint = arraylistP;
                allPipelineAnalysis.listFeat = arraylistF;
                allPipelineAnalysis.line = _line;
                allPipelineAnalysis.globeControl1 = _ctl;
                list = new ArrayList();
                //table = new DataTable();
                //showTable = new DataTable();
               
            }
            return allPipelineAnalysis;
        }

        public FrmAnalysisHengDuanMian(ArrayList arraylistP, ArrayList arraylistF, GSOGeoPolyline3D _line,GSOGlobeControl _ctl)
        {
            InitializeComponent();
            this.listPoint = arraylistP;
            this.listFeat = arraylistF;
            line = _line;
            globeControl1 = _ctl;
        }
        double A_x, A_y, B_x, B_y;//定义坐标点，用来就横断面的长度
        private void Frm_HDMAnalysis_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].BackImage = Application.StartupPath + "\\Resource\\pipelineBackGround副本.png";
        }
        void Frm_HDMAnalysis2_Shown(object sender, EventArgs e)
        {
            isShowFirst = true;

        }
        public void LoadChartEvent()
        {
            try
            {
                this.Shown += new EventHandler(Frm_HDMAnalysis2_Shown);

                chart1.Series["管线"].ChartType = SeriesChartType.Point;

                chart1.Series["管线"]["DrawingStyle"] = "Cylinder";
                chart1.Series["管线"].MarkerStyle = MarkerStyle.Circle; //点的类型     

                chart1.Series["管线"].MarkerBorderColor = Color.Black;  //点的边框颜色
                chart1.ChartAreas[0].AxisX.Minimum = 0;              //x轴的起始点大小
                chart1.ChartAreas[0].AxisX.Maximum = line.GetSpaceLength(true, 6378137);
                chart1.ChartAreas[0].AxisY.Maximum = 0;               //y轴的最大值

                chart1.ChartAreas[0].AxisX.Title = "距离 （米）";
                chart1.ChartAreas[0].AxisY.Title = "埋深 （米）";

                //chart1.ChartAreas[0].AxisY2.Title = "大家好 （）";
                //chart1.ChartAreas[0].AxisY2.Maximum = 10000;

                //chart1.ChartAreas[0].AxisY2.CustomLabels.Add(-3d, -2d, "1");
                //chart1.ChartAreas[0].AxisY2.CustomLabels.Add(-2d, -1.5d, "2");
                //chart1.ChartAreas[0].AxisY2.CustomLabels.Add(-1.5d, -1d, "3");
                //chart1.ChartAreas[0].AxisY2.CustomLabels.Add(-1d, -0.5d, "4");
                //chart1.ChartAreas[0].AxisY2.CustomLabels.Add(-0.5d, 0d, "5");
                //chart1.ChartAreas[0].AxisY2.CustomLabels.Add(0d, 1d, "6");
               
               
                if (line.PartCount > 0)
                {
                    GSOPoint3ds nodes = line[0];
                    GSOPoint3d node = nodes[0];
                    A_x = node.X;
                    A_y = node.Y;
                }

                DrawCurveGraph(A_x, A_y);
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
            }
        }
       

        private void DrawCurveGraph(double a_x,double a_y)
        {

            // 遍历线，求距离
            table = new DataTable();
            //showTable.Columns.Clear();
            list.Clear();
            chart1.Series["管线"].Points.Clear();
            
            table.Columns.Add("编号", typeof(string));
            table.Columns.Add("管线类型", typeof(string));
            table.Columns.Add("管线编码", typeof(string));
            table.Columns.Add("管径_毫米", typeof(string));
            table.Columns.Add("材质", typeof(string));
            table.Columns.Add("管线埋深", typeof(string));          

            object[,] sortIndex = new object[listPoint.Count, 2];
            for (int i = 0; i < listPoint.Count; i++)
            {                
                GSOPoint3d geoPoint = (GSOPoint3d)listPoint[i];
                GSOFeature feature = listFeat[i] as GSOFeature;
                //坐标投影
                int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=555484.8092 +y_0=-4114948.631 +ellps=krass +units=m +no_defs");

                GeoScene.Data.GSOPoint2d a_Point = GeoScene.Data.GSOProjectManager.Forward(new GSOPoint2d(a_x, a_y), id);//user画的线的起始点

                GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(geoPoint.X, geoPoint.Y);
                GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(pt2d, id);
                B_x = result.X;
                B_y = result.Y;

                double x = System.Math.Abs(B_x - a_Point.X);
                double y = System.Math.Abs(B_y - a_Point.Y);
                double Dis = Math.Round(Math.Sqrt(x * x + y * y) , 2);
                list.Add(geoPoint.Z);
                sortIndex[i, 0] = Dis;
                sortIndex[i, 1] = i;

                chart1.Series["管线"].Points.AddXY(Dis, geoPoint.Z);//绑定数据

                string pipeType = "";
                if (feature.GetFieldAsInt32("管线编码") >= 6000 && feature.GetFieldAsInt32("管线编码") <= 6203)  // 6100是热力管线的编码
                {
                    pipeType = "热力管线";
                }
                else if (feature.GetFieldAsInt32("管线编码") >= 4000 && feature.GetFieldAsInt32("管线编码") <= 4306)//排水
                {
                    pipeType = "排水管线";
                }
                else if (feature.GetFieldAsInt32("管线编码") >= 3000 && feature.GetFieldAsInt32("管线编码") <= 3513)  // 3000是给力管线的编码
                {
                    pipeType = "给水管线";
                }
                else if (feature.GetFieldAsInt32("管线编码") >= 1000 && feature.GetFieldAsInt32("管线编码") <= 1808)  // 电力管线的编码
                {
                    pipeType = "电力管线";
                }
                else if (feature.GetFieldAsInt32("管线编码") >= 2000 && feature.GetFieldAsInt32("管线编码") <= 2300)  // 通信管线的编码
                {
                    pipeType = "通信管线";
                }
                else if (feature.GetFieldAsInt32("管线编码") >= 5000 && feature.GetFieldAsInt32("管线编码") <= 5200)  // 通信管线的编码
                {
                    pipeType = "燃气管线";
                }
                string number = Convert.ToString(i + 1);
               
                string material = feature.GetFieldAsString("材质");
                string diameter = feature.GetFieldAsString("管径_毫米");
                table.Rows.Add(new object[] { number, pipeType, feature.Name.ToString(), diameter, material,Convert.ToDecimal(list[i].ToString()).ToString("f2")});//list[i].ToString().Substring(0,list[i].ToString().IndexOf('.')+3) }

                //chart1.Series["管线"].Points[i].Label = number;//管线的标签
                chart1.Series["管线"].Points[i].LegendText = number;
                if (feature.Geometry.Style.GetType() == typeof(GSOPipeLineStyle3D))
                {
                    GSOPipeLineStyle3D style = (GSOPipeLineStyle3D)feature.Geometry.Style;
                    chart1.Series["管线"].Points[i].MarkerBorderColor = style.LineColor;     //点的填充色
                }
                else
                {
                    chart1.Series["管线"].Points[i].MarkerBorderColor = Color.Black;
                }

                chart1.Series["管线"].Points[i].MarkerBorderWidth = 3;        //边框的宽度
                chart1.Series["管线"].Points[i].MarkerColor = Color.Transparent;
                chart1.Series["管线"].Points[i].MarkerSize = Convert.ToInt32(Math.Floor((feature.GetFieldAsDouble("管径_毫米") / 0.35 + chart1.Series["管线"].Points[i].MarkerBorderWidth) / 25.0));//点的大小
  
            }

            string htmlCode = "<html><head><style>#hor-minimalist-b " +
                        "{-moz-background-clip:border;" +
                                "-moz-background-inline-policy:continuous;" +
                                    "-moz-background-origin:padding;" +
                                    "background:#FFFFFF none repeat scroll 0 0;" +
                                    "border-collapse:collapse;" +
                                    "font-family:'Lucida Sans Unicode','Lucida Grande',Sans-Serif;" +
                                   " font-size:12px;" +
                                   " margin:10px;" +
                                   " text-align:left;" +
                                   " width:80%;" +
                                   " }" +
                                   " #hor-minimalist-b th {" +
                                   " border-bottom:2px solid #6678B1;" +
                                   " color:#003399;" +
                                   " font-size:12px;" +
                                "font-weight:normal;" +
                                  "  padding:10px 8px;" +
                                   " }" +
                                  "  #hor-minimalist-b td {" +
                                   " border-bottom:1px solid #CCCCCC;" +
                                   " font-size:12px;" +
                                   " color:#666699;" +
                                "padding:6px 8px;}" +
                                "#hor-minimalist-b tbody tr:hover td {" +
                                "color:#000099;}" +
                                "</style></head>" +
                        "<body style='border:none;' ><table align='center' summary='Employee Pay Sheet' id='hor-minimalist-b'><thead><tr><th scope='col'>管线类型</th><th scope='col'>管线编码</th><th scope='col'>管径_毫米</th>" +
                                        "<th scope='col'>材质</th><th scope='col'>管线埋深</th></tr></thead>" +
                                        "<tbody><tr><td>" +
                                        "</td><td>" +
                                        "</td><td>" +
                                        "</td><td>" + 
                                        "</td><td>" +
                                        "</td></tr></tbody></table></body><ml>";
            webBrowser1.DocumentText = htmlCode;


        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y, true); 
            if (result.PointIndex >= 0)
            {
                DataPoint p = (DataPoint)result.Object;
                if (p == null)
                {
                    return;
                }
                string number = p.LegendText;
                //MessageBox.Show(number);
                int indexInTableRows = 0;
                bool isInt = int.TryParse(number, out indexInTableRows);
                if (isInt)
                {
                    DataRow row = table.Rows[indexInTableRows - 1];
                    //showTable.Rows.Clear();
                    //showTable.Rows.Add(new object[] { row[0], row[1], row[2], row[3], row[4], row[5] });
                    string htmlCode = "<html><head><style>#hor-minimalist-b " +
                        "{-moz-background-clip:border;" +
                                "-moz-background-inline-policy:continuous;" +
                                    "-moz-background-origin:padding;" +
                                    "background:#FFFFFF none repeat scroll 0 0;" +
                                    "border-collapse:collapse;" +
                                    "font-family:'Lucida Sans Unicode','Lucida Grande',Sans-Serif;" +
                                   " font-size:12px;" +
                                   " margin:10px;" +
                                   " text-align:left;" +
                                   " width:80%;" +
                                   " }" +
                                   " #hor-minimalist-b th {" +
                                   " border-bottom:2px solid #6678B1;" +
                                   " color:#003399;" +
                                   " font-size:12px;" +
                                "font-weight:normal;" +
                                  "  padding:10px 8px;" +
                                   " }" +
                                  "  #hor-minimalist-b td {" +
                                   " border-bottom:1px solid #CCCCCC;" +
                                   " font-size:12px;" +
                                   " color:#666699;" +
                                "padding:6px 8px;}" +
                                "#hor-minimalist-b tbody tr:hover td {" +
                                "color:#000099;}" +
                                "</style></head>" +
                        "<body style='border:none;' ><table align='center' summary='Employee Pay Sheet' id='hor-minimalist-b'><thead><tr><th scope='col'>管线类型</th><th scope='col'>管线编码</th><th scope='col'>管径_毫米</th>" +
                                        "<th scope='col'>材质</th><th scope='col'>管线埋深</th></tr></thead>" +
                                        "<tbody><tr><td>" + row[1] +
                                        "</td><td>" + row[2] +
                                        "</td><td>" + row[3] +
                                        "</td><td>" + row[4] +
                                        "</td><td>" + row[5] +
                                        "</td></tr></tbody></table></body></html>";
                    webBrowser1.DocumentText = htmlCode;
                }
            }
        }

        private void Frm_HDMAnalysis3_FormClosing(object sender, FormClosingEventArgs e)
        {
            allPipelineAnalysis = null;
        }

        private void chart1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y, true);
            //Cursor cr = this.Cursor;
            if (result.PointIndex >= 0)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExportCAD_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.MemoryLayer.RemoveAllFeature();
            int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=555484.8092 +y_0=-4114948.631 +ellps=krass +units=m +no_defs");
            for (int i = 0; i < listPoint.Count; i++)
            {
                GSOPoint3d geoPoint = (GSOPoint3d)listPoint[i];
                GSOFeature feature = listFeat[i] as GSOFeature;
                if (feature != null)
                {
                    if (feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                    {
                        GSOPipeLineStyle3D style = feature.Geometry.Style as GSOPipeLineStyle3D;
                        double r = style.Radius;
                        //ExportCAD(double.Parse(sortIndex[i, 0].ToString()), geoPoint.Z, r);
                        Export(geoPoint, r);
                    }
                }

            }
            GSOLayer layer = globeControl1.Globe.MemoryLayer;
            layer.Dataset.ImportProjectionRefFromProj4("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=555484.8092 +y_0=-4114948.631 +ellps=krass +units=m +no_defs");
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.dxf|*.dxf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                layer.SaveAs(dlg.FileName);
                globeControl1.Globe.MemoryLayer.RemoveAllFeature();
                MessageBox.Show("导出CAD完成！", "提示");
            }
        }
        private void Export(GSOPoint3d _pnt, double r)
        {
            GSOPoint3ds pnts = new GSOPoint3ds();
            GSOPoint3d pnt = new GSOPoint3d();
            pnt.X = _pnt.X;
            pnt.Y = _pnt.Y;
            pnt.Z = _pnt.Z;
            pnts.Add(pnt);
            pnt.X = _pnt.X;
            pnt.Y = _pnt.Y - 0.0000000005;
            pnt.Z = _pnt.Z;
            pnts.Add(pnt);
            GSOGeoPolyline3D line = new GSOGeoPolyline3D();
            line.AddPart(pnts);
            GSOGeoPolygon3D polygon = line.CreateBuffer(r * 2, true, 5, true, false);
            GSOPoint3ds points = polygon[0];
            GSOGeoPolyline3D newLine = new GSOGeoPolyline3D();
            newLine.AddPart(points);
            newLine.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            GSOFeature newFeature = new GSOFeature();
            newFeature.Geometry = newLine;            
            globeControl1.Globe.MemoryLayer.AddFeature(newFeature);
           // globeControl1.Globe.FlyToFeature(f);
        }


      
        
    }
}