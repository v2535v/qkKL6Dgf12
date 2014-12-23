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
using System.Collections;
using System.Xml;
using System.Text.RegularExpressions;

namespace WorldGIS.Forms
{
    public partial class FrmPipelineModelDB : Form
    {
        private GeoScene.Globe.GSOGlobeControl globeControl1;
        private Hashtable en_cns = new Hashtable();
        private Hashtable fields_types = new Hashtable();

        public FrmPipelineModelDB(GSOGlobeControl _globeControl1)
        {
            globeControl1 = _globeControl1;
            InitializeComponent();
        }

        private void FrmPipelineModel_Load(object sender, EventArgs e)
        {
            comboBoxDataSourceList.Items.Clear();
            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                }
            }
            comboBoxShpLayerList.Items.Clear();
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (Path.GetExtension(layer.Name).ToLower() == ".shp")
                {
                    comboBoxShpLayerList.Items.Add(layer.Caption);
                }
            }
            chkDeep.Checked = true;
            string filename = Application.StartupPath + "\\config.xml";
            if (File.Exists(filename))
            {
                XmlTextReader XmlReader = new XmlTextReader(filename);
                try
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.Name == "Field")
                        {
                            string str1 = XmlReader["label"];
                            string str3 = XmlReader["type"];
                            string str2 = XmlReader.ReadElementString();
                            en_cns.Add(str1, str2);
                            fields_types.Add(str1, str3);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.PublishTxt(ex);
                    MessageBox.Show(ex.Message);
                }
            }
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
            if (features.Length == 0)
                return;

            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();
            cmbRadius.Items.Clear();
            cmbID.Items.Clear();
            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i));

                cmbFrom.Items.Add(fielddef.Name);
                cmbTo.Items.Add(fielddef.Name);
                cmbRadius.Items.Add(fielddef.Name);
                cmbID.Items.Add(fielddef.Name);
            }
            cmbFrom.SelectedItem = "Deep1";
            cmbTo.SelectedItem = "Deep2";
            cmbRadius.SelectedItem = "Diameter";
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
            //判断是数字或者存在特殊字符串
            string SuiD = textBoxNewLayerName.Text.ToString().Trim();
            Regex reg = new Regex("^[0-9]+$");//判断是不是数据，要不是就表示没有选择。则从隐藏域里读出来
            Match ma = reg.Match(SuiD);
            if (ma.Success)
            {
                MessageBox.Show("管线图层名称不能全部为数字！", "警告");
                return;
            }
           
            try
            {
               // if (valiPipeData())
                {
                    if (string.IsNullOrEmpty(textBoxNewLayerName.Text))
                    {
                        MessageBox.Show("管线图层名称无效！", "提示");
                        return;
                    }

                    GSODataset dataset = ds.GetDatasetByName(textBoxNewLayerName.Text.Trim());

                    GSOFeatureDataset newFeatureDataset;
                    if (dataset != null)
                    {
                        DialogResult result = MessageBox.Show("管线图层名称在数据库中已存在！是否向该表追加", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            newFeatureDataset = dataset as GSOFeatureDataset;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        newFeatureDataset = CreateDBFeatureDataset(textBoxNewLayerName.Text.Trim());
                    }
                    if (newFeatureDataset == null)
                    {
                        return;
                    }
                    GSOLayer sourceLayer = globeControl1.Globe.Layers.GetLayerByCaption(comboBoxShpLayerList.SelectedItem.ToString().Trim());
                    newFeatureDataset.Open();
                    GSOFeatures features = sourceLayer.GetAllFeatures(true);
                    string message = "";
                    for (int j = 0; j < features.Length; j++)
                    {
                        GSOFeature f = features[j];

                        GSOGeoPolyline3D lineeee = f.Geometry as GSOGeoPolyline3D;
                        if (lineeee == null)
                        {
                            message += "ID为" + f.ID + "的对象不是一个线对象\n";
                            continue;

                        }
                        double length = lineeee.GetSpaceLength(true, 6378137);
                        if (length == 0)
                        {
                            message += "ID为" + f.ID + "的管线长度为0\n";
                            continue;
                        }

                        GSOFeature newFeature = newFeatureDataset.CreateFeature();

                        GSOPipeLineStyle3D style = new GSOPipeLineStyle3D();
                        style.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), btnPipelineColor.BackColor);

                        double radius = 0;
                        GSOFieldDefn field = (GSOFieldDefn)(f.GetFieldDefn(cmbRadius.SelectedItem.ToString()));
                        if (field.Type == EnumFieldType.Text)
                        {
                            string temp = f.GetFieldAsString(cmbRadius.SelectedItem.ToString());
                            double outNum = 0;
                            bool num = double.TryParse(temp, out outNum);
                            if (num)
                                radius = outNum / 2000;
                        }
                        else if (field.Type == EnumFieldType.INT32 || field.Type == EnumFieldType.Double)
                            radius = f.GetFieldAsDouble(cmbRadius.SelectedItem.ToString()) / 2000;  // 探测数据的单位一般是毫米，需换算为米； 管径一般是 直径， 这个需要半径， 所有除以2000 


                        string eventid = f.GetFieldAsString(cmbID.SelectedItem.ToString());

                        if (radius == 0)
                        {
                            message += "ID为" + f.ID + "的管线半径为0\n";
                            continue;
                        }

                        style.Radius = radius;
                        style.Slice = int.Parse(txtSlice.Text);
                        style.CornerSliceAngle = Convert.ToDouble(textBoxCornerSliceAngle.Text);

                        f.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;

                        GSOGeoPolyline3D line = f.Geometry as GSOGeoPolyline3D;
                        if (line == null)
                            return;

                        double deep1 = f.GetFieldAsDouble(cmbFrom.SelectedItem.ToString());
                        double deep2 = f.GetFieldAsDouble(cmbTo.SelectedItem.ToString());

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
                            double fenmu = Math.Sqrt(Math.Pow(line[0][pointcount - 1].Y - line[0][0].Y, 2) + Math.Pow(line[0][pointcount - 1].X - line[0][0].X, 2));

                            if (fenmu == 0)
                            {
                                pt3d.Z = deep1;
                            }
                            else
                            {
                                double radio = Math.Sqrt(Math.Pow(pt3d.Y - line[0][0].Y, 2) + Math.Pow(pt3d.X - line[0][0].X, 2)) / fenmu;
                                pt3d.Z = deep1 + (deep2 - deep1) * radio;
                            }

                            if (double.IsInfinity(pt3d.Z))
                            {
                                pt3d.Z = deep2;
                            }
                            line[0][n] = pt3d;
                        }

                        newFeature.Geometry = line; // f.Geometry;
                        newFeature.Geometry.Style = style;
                        newFeature.Name = eventid;

                        for (int i = 0; i < f.GetFieldCount(); i++)
                        {
                            GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(f.GetFieldDefn(i));
                            if (fielddef == null)
                            {
                                continue;
                            }
                            if (!en_cns.Contains(fielddef.Name))
                            {
                                continue;
                            }
                            object fieldvalue = f.GetValue(fielddef.Name);// convertFieldValue(fielddef.Name, f.GetValue(fielddef.Name));
                            if (fieldvalue == null)
                                continue;
                            string fieldName = en_cns.ContainsKey(fielddef.Name) == true ? en_cns[fielddef.Name].ToString() : fielddef.Name;
                            newFeature.SetValue(fieldName, fieldvalue);
                        }

                        newFeatureDataset.AddFeature(newFeature);
                    }
                    newFeatureDataset.Save();
                    newFeatureDataset.Caption = newFeatureDataset.Name;
                    globeControl1.Globe.Layers.Add(newFeatureDataset);
                    globeControl1.Refresh();

                    string strMessage = "shp文件中共" + features.Length + "个对象，实际入库" + newFeatureDataset.GetAllFeatures().Length + "个对象！\n";
                    if (message == "")
                    {
                        MessageBox.Show(strMessage,"提示");
                    }
                    else
                    {
                        FrmMessageShow frm = new FrmMessageShow(strMessage + message);
                        frm.ShowDialog();
                    }
                    this.Close();
                }           
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message);
            }
        }
      
        private bool valiPipeData()
        {
            if (comboBoxShpLayerList.SelectedItem == null)
            {
                MessageBox.Show("请选择一个shp图层！");
                return false;
            }
            GSOLayer sourceLayer = globeControl1.Globe.Layers.GetLayerByCaption(comboBoxShpLayerList.SelectedItem.ToString().Trim());
            if (sourceLayer == null)
            {
                MessageBox.Show("选择的图层为空！");
                return false;
            }
            GSOFeatures features = sourceLayer.GetAllFeatures(true);
            GSOFeatureDataset featDataSet = sourceLayer.Dataset as GSOFeatureDataset;
            if (featDataSet.FieldCount <= 0)
            {
                MessageBox.Show("图层中字段数必须大于0");
                return false;
            }
            GSOFieldAttr fieldDeep1 = featDataSet.GetField("Deep1");
            if (fieldDeep1 == null)
            {
                MessageBox.Show("Deep1字段不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (fieldDeep1.Type != EnumFieldType.Double && fieldDeep1.Type != EnumFieldType.Float && fieldDeep1.Type != EnumFieldType.INT16 && fieldDeep1.Type != EnumFieldType.INT32)
            {
                MessageBox.Show("Deep1必须为数值类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            GSOFieldAttr fieldDeep2 = featDataSet.GetField("Deep2");
            if (fieldDeep2 == null)
            {
                MessageBox.Show("Deep2字段不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (fieldDeep2.Type != EnumFieldType.Double && fieldDeep2.Type != EnumFieldType.Float && fieldDeep2.Type != EnumFieldType.INT16 && fieldDeep2.Type != EnumFieldType.INT32)
            {
                MessageBox.Show("Deep2必须为数值类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            GSOFieldAttr fieldDiameter = featDataSet.GetField("Diameter");
            if (fieldDiameter == null)
            {
                MessageBox.Show("Diameter字段不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (fieldDiameter.Type != EnumFieldType.Double && fieldDiameter.Type != EnumFieldType.Float)
            {
                MessageBox.Show("Diameter必须为数值类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            List<string> lst = new List<string>();
            for (int j = 0; j < features.Length; j++)
            {
                if (features[j].GetFieldAsFloat("Diameter") <= 0)
                {
                    MessageBox.Show("Diameter中的值必须大于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!lst.Contains(features[j].GetFieldAsString("Handle")))
                {
                    lst.Add(features[j].GetFieldAsString("Handle"));
                }
                else
                {
                    MessageBox.Show("Handle字段必须唯一！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
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
                return null;
            }
            GSOFeatureDataset newFeatureDataset = ds.CreateFeatureDataset(name);
            if (newFeatureDataset == null)
            {
                MessageBox.Show("输入的图层名称不符合要求！", "提示");
                return null;
            }
            for (int i = 0; i < featureDataset.FieldCount; i++)
            {
                GeoScene.Data.GSOFieldAttr fielddef = featureDataset.GetField(i);
                if (!en_cns.Contains(fielddef.Name))
                {
                    continue;
                }
                GSOFieldAttr field = new GSOFieldAttr();
                field.Name = en_cns.ContainsKey(fielddef.Name) == true ? en_cns[fielddef.Name].ToString() : fielddef.Name;
                field.Type = fielddef.Type;
                field.Width = fielddef.Width;
                field.Precision = fielddef.Precision;
                bool res = newFeatureDataset.AddField(field);
            }

            newFeatureDataset.Save();
            return newFeatureDataset;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}