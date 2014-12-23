using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Globe;
using GeoScene.Engine;
using GeoScene.Data;
using System.IO;

namespace WorldGIS
{
    public partial class FrmBatchCreatePore : Form
    {
        private GeoScene.Globe.GSOGlobeControl ctl;
        public FrmBatchCreatePore(GSOGlobeControl _ctl)
        {
            ctl = _ctl;
            InitializeComponent();
        }
      
        private void btnBrowseModel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.lgd|*.lgd";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtModelLayer.Text = saveFileDialog1.FileName;                
            }
        }

        private void FrmPipelineModel_Load(object sender, EventArgs e)
        {
            cmbLayer.Items.Clear();
            for (int i = 0; i < ctl.Globe.Layers.Count; i++)
            {
                GSOLayer layer = ctl.Globe.Layers[i];
                cmbLayer.Items.Add(layer.Caption);
            }
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOLayer layer = ctl.Globe.Layers[cmbLayer.SelectedIndex];
            GSOFeatures features = layer.GetAllFeatures();
            if(features.Length==0)
                return;

            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();
            cmbRadius.Items.Clear();
            cmbID.Items.Clear();
            cmbWidthNum.Items.Clear();
            cmbHeightNum.Items.Clear();
            cmbInterval.Items.Clear();
          

            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                cmbFrom.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbTo.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbRadius.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbID.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbWidthNum.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbHeightNum.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbInterval.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
            }


            cmbFrom.SelectedItem = "Deep1";
            cmbTo.SelectedItem = "Deep2";
            cmbRadius.SelectedItem = "Diameter";
            cmbID.SelectedItem = "Handle";
            cmbWidthNum.SelectedItem = "Trans_Num";
            cmbHeightNum.SelectedItem = "Longi_Num";
        }

        public string lgdFilePath = "";
        private void btnPipelineColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = btnPipelineColor.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnPipelineColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtModelLayer.Text))
                {
                    MessageBox.Show("管线模型文件路径无效！", "提示");
                    return;
                }
                if (File.Exists(txtModelLayer.Text))
                {
                    MessageBox.Show("管线模型文件已存在！", "提示");
                    return;
                }                 

                GSOLayer ShpSourceLayer = ctl.Globe.Layers[cmbLayer.SelectedIndex];

                GSOLayer   pipeModelLayer = ctl.Globe.Layers.Add(txtModelLayer.Text);
                
                string pipeRectFile = Path.GetDirectoryName(txtModelLayer.Text) + "\\" + Path.GetFileNameWithoutExtension(txtModelLayer.Text) + "_Rect" + Path.GetExtension(txtModelLayer.Text);
                GSOLayer layer_Rect = ctl.Globe.Layers.Add(pipeRectFile);
                lgdFilePath = txtModelLayer.Text;
                
                if (pipeModelLayer != null)
                {
                    GSOFeatures features = ShpSourceLayer.GetAllFeatures();
                    string message = "";
                    for (int j = 0; j < features.Length; j++)
                    {
                        GSOFeature f = features[j];
                        
                        GSOFeature newFeature = new GSOFeature();
                        
                        GSOPipeLineStyle3D style = new GSOPipeLineStyle3D();
                        style.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), btnPipelineColor.BackColor);
                        
                        double radius = 0;
                        GSOFieldDefn diameterfield = (GSOFieldDefn)f.GetFieldDefn(cmbRadius.SelectedItem.ToString());
                        if (diameterfield.Type == EnumFieldType.Text)
                        {
                            radius = Convert.ToDouble(f.GetFieldAsString(cmbRadius.SelectedItem.ToString())) / 2000;
                        }
                        else
                        {
                            radius = f.GetFieldAsDouble(cmbRadius.SelectedItem.ToString()) / 2000;  // 探测数据的单位一般是毫米，需换算为米； 管径一般是 直径， 这个需要半径， 所有除以2000     
                        }
                                                                      
                        string eventid = f.GetFieldAsString(cmbID.SelectedItem.ToString());
                        int num_width = f.GetFieldAsInt32(cmbWidthNum.SelectedItem.ToString());
                        int num_height = f.GetFieldAsInt32(cmbHeightNum.SelectedItem.ToString());
                        double interval = radius * 2;    //  f.GetFieldAsDouble(cmbInterval.SelectedItem.ToString());
                        double rectWidth = radius * 2 * num_width + 0.08;// 两端空出0.04
                        double rectHeight = radius * 2 * num_height + 0.08;
                        if (radius == 0)
                        {
                            message += "ID为" + f.ID + "的管线的半径为0  \n  ";
                            continue;
                        }

                        style.Radius = radius;
                        style.Slice = int.Parse(txtSlice.Text);
                        style.CornerSliceAngle = Convert.ToDouble(textBoxCornerSliceAngle.Text);

                        f.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        
                         GSOGeoPolyline3D line = f.Geometry as GSOGeoPolyline3D;
                         if (line == null)
                         {
                             message += "ID为" + f.ID + "的管线不是线对象  \n  ";
                             continue;
                         }
                                                    
                         double deep1 = f.GetFieldAsDouble(cmbFrom.SelectedItem.ToString());
                         double deep2 = f.GetFieldAsDouble(cmbTo.SelectedItem.ToString());
                         
                         if (chkDeep.Checked)
                         {
                             deep1 = 0 - deep1;
                             deep2 = 0 - deep2;
                         }

                         if (cmbReference.SelectedIndex == 0) //管底
                         {
                             deep1 = deep1 + radius*2;
                             deep2 = deep2 + radius*2;
                         }
                         else if (cmbReference.SelectedIndex == 1) //管顶
                         {
                             deep1 = deep1 - radius*2;
                             deep2 = deep2 - radius*2;
                         }
                         for (int n = 0; n < line[0].Count; n++)
                         {
                             GSOPoint3d pt3d = line[0][n];
                             int pointcount = line[0].Count;
                             double radio = Math.Sqrt(Math.Pow(pt3d.Y - line[0][0].Y, 2) + Math.Pow(pt3d.X - line[0][0].X, 2)) / Math.Sqrt(Math.Pow(line[0][pointcount - 1].Y - line[0][0].Y, 2) + Math.Pow(line[0][pointcount - 1].X - line[0][0].X, 2));
                             pt3d.Z = deep1 + (deep2 - deep1) * radio;

                             if (double.IsInfinity(pt3d.Z))
                             {
                                 pt3d.Z = deep2;
                             }   
                             line[0][n] = pt3d;
                         }
                         if (num_height == 0 || num_width == 0) // 直埋
                         {
                             newFeature.Geometry = line;
                             newFeature.Geometry.Style = style;
                             newFeature.Name = eventid;
                             pipeModelLayer.AddFeature(newFeature);
                         }
                         else
                         {
                             GSOFeature rectfeat = CreatePipeRect(f, line,rectWidth,rectHeight);
                             if (rectfeat != null)
                             {
                                 layer_Rect.AddFeature(rectfeat);
                             }
                             one2Multi(line, num_width, num_height, interval, style, pipeModelLayer, eventid);
                         }                               
                    }
                    ctl.Refresh();

                    pipeModelLayer.Save();
                    layer_Rect.Save();
                    string strMessage = "shp文件中共" + features.Length + "个对象，实际生成" + (pipeModelLayer.GetAllFeatures().Length + layer_Rect.GetAllFeatures().Length) + "个对象！\n";
                    MessageBox.Show(strMessage + message, "提示");
                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private GSOFeature CreatePipeRect(GSOFeature shp_feat,GSOGeoPolyline3D line,double width,double height)
        {
            GSOFeature newRectfeat = new GSOFeature();
            GSOGeoPolyline3D cloneline = line.Clone() as GSOGeoPolyline3D;

            GSOExtendSectionLineStyle3D style = createRectStyle(width, height);
            if (style == null)
                return null;

            cloneline.Style = style;
            newRectfeat.Geometry = cloneline;
            return newRectfeat;
        }
        

        private GSOExtendSectionLineStyle3D createRectStyle(double width, double height)
        {
            GSOExtendSectionLineStyle3D style = new GSOExtendSectionLineStyle3D();
            style.LineColor = Color.FromArgb(Convert.ToByte(numOpaqueRect.Value), btnRectColor.BackColor);

            if (width == 0 || height == 0)
                return null;

            GSOPoint3ds sectionpts = new GSOPoint3ds();
            sectionpts.Add(new GSOPoint3d(width / -2, height / 2, 0));
            sectionpts.Add(new GSOPoint3d(width / -2, height / -2, 0));
            sectionpts.Add(new GSOPoint3d(width / 2, height / -2, 0));
            sectionpts.Add(new GSOPoint3d(width / 2, height / 2, 0));

            style.SetSectionPoints(sectionpts);
            style.IsClosed = true;
            style.SetAnchorByAlign(EnumAlign.MiddleCenter);
            
            return style;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void one2Multi(GSOGeoPolyline3D line, int num_width, int num_height, double interval, GSOPipeLineStyle3D style, GSOLayer layer,string name)
        {
            line = LatLon2Coord_Line(line);

            double width_all = interval * (num_width-1);
            double height_all = interval * (num_height-1);

            line.Clone();
            GSOGeoPolyline3D line_1 = line.Clone() as GSOGeoPolyline3D;
            
            GSOPoint3d p1 = line[0][0];
            GSOPoint3d p2 = line[0][1];

            double daltaX = p2.X-p1.X;
            double daltaY = p2.Y-p1.Y;
            
            double agree = Math.Atan(daltaY/daltaX);

            line.MoveXY((-0.5*width_all-interval)*Math.Sin(agree),(0.5*width_all+interval)*Math.Cos(agree));

            line.MoveZ(height_all / -2);
            
            for (int i = 0; i < num_width; i++)
            {
                for (int j = 0; j < num_height; j++)
                {
                    GSOGeoPolyline3D templine = line.Clone() as GSOGeoPolyline3D;

                    templine.MoveXY((i + 1) * interval * Math.Sin(agree), -1 * (i + 1) * interval * Math.Cos(agree));

                    templine = Coord2LatLon_Line(templine);

                    templine.MoveZ(interval*j);

                    GSOFeature feat = new GSOFeature();
                    feat.Geometry = templine;
                    feat.Geometry.Style = style;
                    feat.Name = name;
                    layer.AddFeature(feat);
                }
            }
        }

        private GSOGeoPolyline3D LatLon2Coord_Line(GSOGeoPolyline3D line)
        {
            GSOGeoPolyline3D newline = line.Clone() as GSOGeoPolyline3D;
            for (int i = 0; i < newline[0].Count; i++)
            {
                GSOPoint3d pt = newline[0][i];
                GSOPoint2d pt2d = new GSOPoint2d(pt.X, pt.Y);
                GSOPoint2d pt2dnew = LatLon2Coord(pt2d);

                GSOPoint3d ptnew = new GSOPoint3d(pt2dnew.X, pt2dnew.Y, pt.Z);
                newline[0][i] = ptnew;

            }
            return newline;
        }

        private GSOGeoPolyline3D Coord2LatLon_Line(GSOGeoPolyline3D line)
        {
            GSOGeoPolyline3D newline = line.Clone() as GSOGeoPolyline3D;
            for (int i = 0; i < newline[0].Count; i++)
            {
                GSOPoint3d pt = newline[0][i];
                GSOPoint2d pt2d = new GSOPoint2d(pt.X, pt.Y);
                GSOPoint2d pt2dnew = Coord2LatLon(pt2d);

                GSOPoint3d ptnew = new GSOPoint3d(pt2dnew.X, pt2dnew.Y, pt.Z);
                newline[0][i] = ptnew;
            }
            return newline;
        }

        private GSOPoint2d LatLon2Coord(GeoScene.Data.GSOPoint2d pt2d)
        {
            int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=-50000 +y_0=-4210000 +ellps=krass +units=m +no_defs");
           //  GeoScene.Data.GSOProjectManager.SetCurProject(id);
           // double x = Convert.ToDouble(txtLong.Text);
           // double y = Convert.ToDouble(txtLat.Text);
           // GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
            
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(pt2d, id);
            return result;
        }


        private GSOPoint2d Coord2LatLon(GeoScene.Data.GSOPoint2d pt2d)
        {
            int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=-50000 +y_0=-4210000 +ellps=krass +units=m +no_defs");
            //  GeoScene.Data.GSOProjectManager.SetCurProject(id);
            //double x = Convert.ToDouble(txtX.Text);
            //double y = Convert.ToDouble(txtY.Text);
            //GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(pt2d, id);
            return result;
           // txtLong.Text = result.X.ToString();
            //txtLat.Text = result.Y.ToString();
        }

    }
}