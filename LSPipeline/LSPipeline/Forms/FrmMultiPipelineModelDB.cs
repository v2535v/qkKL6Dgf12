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

namespace WorldGIS.Forms
{
    public partial class FrmMultiPipelineModelDB : Form
    {
        private GeoScene.Globe.GSOGlobeControl globeControl1;
        public FrmMultiPipelineModelDB(GSOGlobeControl _globeControl)
        {
            globeControl1 = _globeControl;           
            InitializeComponent();
        }

        private void FrmPipelineModel_Load(object sender, EventArgs e)
        {
            comboBoxShpLayerList.Items.Clear();
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (Path.GetExtension(layer.Name).ToLower() == ".shp")
                {
                    comboBoxShpLayerList.Items.Add(layer.Caption);
                }
            }
            comboBoxDataSourceList.Items.Clear();
            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                }
            }
            chkDeep.Checked = true;
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShpLayerList.SelectedItem == null)
            {
                return;
            }
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(comboBoxShpLayerList.SelectedItem.ToString().Trim());
            if (layer == null)
            {
                return;
            }
            textBoxNewLayerName.Text = layer.Caption;
            GSOFeatures features = layer.GetAllFeatures();
            if(features.Length==0)
                return;

            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();
            cmbRadius.Items.Clear();
            cmbID.Items.Clear();
            cmbWidthNum.Items.Clear();
            cmbHeightNum.Items.Clear();           

            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                cmbFrom.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbTo.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbRadius.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbID.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbWidthNum.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbHeightNum.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);                           
            }
            cmbFrom.SelectedItem = "Deep1";
            cmbTo.SelectedItem = "Deep2";
            cmbRadius.SelectedItem = "Diameter";
            cmbWidthNum.SelectedItem = "Hor_Num";// "Weight";
            cmbHeightNum.SelectedItem = "Ver_Num";// "Height";
            cmbID.SelectedItem = "Handle";
        }
        
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
            if (comboBoxDataSourceList.SelectedItem == null)
            {
                MessageBox.Show("请选择一个目标数据源！", "提示");
                return;
            }
            GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
            if (ds == null)
            {
                MessageBox.Show("选择的目标数据源为空！", "提示");
                return;
            }
            if (string.IsNullOrEmpty(textBoxNewLayerName.Text))
            {
                MessageBox.Show("请选择一个Shp图层！", "提示");
                return;
            }
            if (ds.GetDatasetByName(textBoxNewLayerName.Text) != null)
            {
                MessageBox.Show("图层名称已存在！", "提示");
                return;
            }
            try
            {
                GSOLayer ShpSourceLayer = globeControl1.Globe.Layers.GetLayerByCaption(comboBoxShpLayerList.SelectedItem.ToString().Trim());
                GSOFeatureDataset pipeline = CreateDBFeatureDataset(textBoxNewLayerName.Text.Trim());
                if (pipeline == null)
                {
                    MessageBox.Show("输入的图层名称不符合要求！", "提示");
                    return;
                }
                pipeline.Open();
                GSOFeatureDataset pipelineRect = CreateDBFeatureDataset(textBoxNewLayerName.Text.Trim() + "_Rect");
                if (pipelineRect == null)
                {
                    return;
                }
                pipelineRect.Open();

                GSOFeatures features = ShpSourceLayer.GetAllFeatures();
                string message = "";
                for (int j = 0; j < features.Length; j++)
                {
                    GSOFeature f = features[j];

                    GSOFeature newFeature = pipeline.CreateFeature();

                    GSOPipeLineStyle3D style = new GSOPipeLineStyle3D();
                    style.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), btnPipelineColor.BackColor);

                    double radius = 0;
                    if (cmbRadius.SelectedItem == null)
                    {
                        cmbRadius.SelectedIndex = 0;
                    }
                    GSOFieldDefn diameterfield = (GSOFieldDefn)f.GetFieldDefn(cmbRadius.SelectedItem.ToString());
                    string fieldText = f.GetFieldAsString(cmbRadius.SelectedItem.ToString());
                    if (diameterfield.Type == EnumFieldType.Text)
                    {
                        if (double.TryParse(fieldText, out radius))
                        {
                            radius = radius / 2000;
                        }
                        else
                        {
                            message += "ID为" + f.ID + "的对象的管径字段值不符合要求！\r\n";
                            continue;
                        }
                    }
                    else
                    {
                        radius = f.GetFieldAsDouble(cmbRadius.SelectedItem.ToString()) / 2000;  // 探测数据的单位一般是毫米，需换算为米； 管径一般是 直径， 这个需要半径， 所有除以2000     
                    }

                    if (cmbID.SelectedItem == null)
                    {
                        cmbID.SelectedIndex = 0;
                    }
                    if (cmbWidthNum.SelectedItem == null)
                    {
                        cmbWidthNum.SelectedIndex = 0;
                    }
                    if (cmbHeightNum.SelectedItem == null)
                    {
                        cmbHeightNum.SelectedIndex = 0;
                    }
                    string eventid = f.GetFieldAsString(cmbID.SelectedItem.ToString());
                    double interval = radius * 2;
                    int num_width = 0;
                    int num_height = 0;
                    if (!int.TryParse(f.GetFieldAsString(cmbWidthNum.SelectedItem.ToString()), out num_width))
                    {
                        message += "ID为" + f.ID + "的对象的宽度字段值不符合要求！\r\n";
                        continue;
                    }
                    if (!int.TryParse(f.GetFieldAsString(cmbHeightNum.SelectedItem.ToString()), out num_height))
                    {
                        message += "ID为" + f.ID + "的对象的高度字段值不符合要求！\r\n";
                        continue;
                    }

                    double rectWidth = radius * 2 * num_width + 0.08;// 两端空出0.04
                    double rectHeight = radius * 2 * num_height + 0.08;

                    if (radius == 0)
                    {
                        message += "ID为" + f.ID + "的对象的管径字段值为0！\r\n";
                        continue;
                    }

                    int intSlice = 0;
                    double cornerSliceAngle = 0;
                    if (!int.TryParse(txtSlice.Text.Trim(), out intSlice))
                    {
                        message += "ID为" + f.ID + "的对象的截面分段数字段值不符合要求！\r\n";
                        continue;
                    }
                    if (!double.TryParse(textBoxCornerSliceAngle.Text.Trim(), out cornerSliceAngle))
                    {
                        message += "ID为" + f.ID + "的对象的拐弯平滑度字段值不符合要求！\r\n";
                        continue;
                    }
                    style.Radius = radius;
                    style.Slice = intSlice;
                    style.CornerSliceAngle = cornerSliceAngle;

                    f.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;

                    GSOGeoPolyline3D line = f.Geometry as GSOGeoPolyline3D;
                    if (line == null)
                    {
                        message += "ID为" + f.ID + "的对象不是一个线对象！\r\n";
                        continue;
                    }

                    if (cmbFrom.SelectedItem == null)
                    {
                        cmbFrom.SelectedIndex = 0;
                    }
                    if (cmbTo.SelectedItem == null)
                    {
                        cmbTo.SelectedIndex = 0;
                    }
                    double deep1 = 0;
                    double deep2 = 0;
                    if (!double.TryParse(f.GetFieldAsString(cmbFrom.Items[cmbTo.SelectedIndex].ToString().Trim()), out deep1))
                    {
                        message += "ID为" + f.ID + "的对象的起点埋深字段值不符合要求！\r\n";
                        continue;
                    }
                    if (!double.TryParse(f.GetFieldAsString(cmbTo.Items[cmbTo.SelectedIndex].ToString().Trim()), out deep2))
                    {
                        message += "ID为" + f.ID + "的对象的终点埋深字段值不符合要求！\r\n";
                        continue;
                    }


                    if (chkDeep.Checked)
                    {
                        deep1 = 0 - deep1;
                        deep2 = 0 - deep2;
                    }

                    if (cmbReference.SelectedIndex == 0) //管底
                    {
                        deep1 = deep1 + radius * 2;
                        deep2 = deep2 + radius * 2;
                    }
                    else if (cmbReference.SelectedIndex == 1) //管顶
                    {
                        deep1 = deep1 - radius * 2;
                        deep2 = deep2 - radius * 2;
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
                        SetFields(f, newFeature);

                        pipeline.AddFeature(newFeature);
                    }
                    else
                    {
                        GSOFeature rectfeat = pipelineRect.CreateFeature();
                        rectfeat.Geometry = CreatePipeRect(line, rectWidth, rectHeight);
                        if (rectfeat != null)
                        {
                            SetFields(f, rectfeat);
                            pipelineRect.AddFeature(rectfeat);
                        }
                        one2Multi(line, num_width, num_height, interval, style, pipeline, eventid, f);
                    }
                }
                globeControl1.Refresh();

                pipeline.Save();
                pipelineRect.Save();
                pipeline.Close();
                pipelineRect.Close();
                string strMessage = "shp文件中共" + features.Length + "个对象，实际入库" + pipeline.GetAllFeatures().Length + "个对象！\r\n";
                if (message == "")
                {
                    MessageBox.Show(strMessage, "提示");
                }
                else
                {
                    FrmMessageShow frm = new FrmMessageShow(strMessage + message);
                    frm.ShowDialog();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void SetFields(GSOFeature oldfeat, GSOFeature newFeature)
        {
            for (int i = 0; i < oldfeat.GetFieldCount(); i++)
            {
                GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(oldfeat.GetFieldDefn(i));

                object fieldvalue = oldfeat.GetValue(fielddef.Name);
                if (fieldvalue == null)
                    continue;
                newFeature.SetValue(fielddef.Name, fieldvalue);              
            }
        }

        private GSOGeoPolyline3D CreatePipeRect(GSOGeoPolyline3D line, double width, double height)
        {
            GSOGeoPolyline3D cloneline = line.Clone() as GSOGeoPolyline3D; 
            GSOExtendSectionLineStyle3D style = createRectStyle(width, height);
            if (style == null)
            {
                return null;
            }
            cloneline.Style = style;
            return cloneline;
        }        

        private GSOExtendSectionLineStyle3D createRectStyle(double width, double height)
        {
            GSOExtendSectionLineStyle3D style = new GSOExtendSectionLineStyle3D();
            style.LineColor = Color.FromArgb(Convert.ToByte(numOpaqueRect.Value), btnRectColor.BackColor);
            if (width == 0 || height == 0)
            {
                return null;
            }
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

        private void one2Multi(GSOGeoPolyline3D line, int num_width, int num_height, double interval, GSOPipeLineStyle3D style, GSOFeatureDataset layer,string name,GSOFeature oldfeat)
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

                    GSOFeature feat = layer.CreateFeature();
                    feat.Geometry = templine;
                    feat.Geometry.Style = style;
                    feat.Name = name;
                    SetFields(oldfeat, feat);
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
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(pt2d, id);
            return result;
        }

        private GSOPoint2d Coord2LatLon(GeoScene.Data.GSOPoint2d pt2d)
        {
            int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=-50000 +y_0=-4210000 +ellps=krass +units=m +no_defs");           
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(pt2d, id);
            return result;       
        }

        private GSOFeatureDataset CreateDBFeatureDataset(string name)
        {
            if (comboBoxShpLayerList.SelectedItem == null)
            {
                MessageBox.Show("请选择一个Shp图层！", "提示");
                return null;
            }
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(comboBoxShpLayerList.SelectedItem.ToString().Trim());
            if (layer == null)
            {
                MessageBox.Show("Shp图层为空！", "提示");
                return null;
            }
            GSOFeatures features = layer.GetAllFeatures();
            if (features.Length == 0)
            {
                MessageBox.Show("图层要素个数为0！", "提示");
                return null;
            }
            GSOFeatureDataset featureDataset = layer.Dataset as GSOFeatureDataset;
            if (featureDataset == null)
            {
                MessageBox.Show("Shp图层不是矢量图层！", "提示");
                return null;
            }
            if (comboBoxDataSourceList.SelectedItem == null)
            {
                MessageBox.Show("请选择一个目标数据源！", "提示");
                return null;
            }
            GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
            if (ds == null)
            {
                MessageBox.Show("选择的目标数据源为空！", "提示");
                return null ;
            }
            GSOFeatureDataset newFeatureDataset = ds.CreateFeatureDataset(name);
            if (newFeatureDataset != null)
            {
                for (int i = 0; i < featureDataset.FieldCount; i++)
                {
                    GeoScene.Data.GSOFieldAttr fielddef = featureDataset.GetField(i);

                    GSOFieldAttr field = new GSOFieldAttr();
                    field.Name = fielddef.Name;
                    field.Type = fielddef.Type;
                    field.Width = fielddef.Width;
                    field.Precision = fielddef.Precision;
                    bool res = newFeatureDataset.AddField(field);
                }
                newFeatureDataset.Save();
            }
            return newFeatureDataset;
        }
    }
}