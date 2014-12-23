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

namespace WorldGIS.Forms
{
    public partial class FrmPaiShui2DB : Form
    {
        private GeoScene.Globe.GSOGlobeControl globeControl1;

        private Hashtable en_cns = new Hashtable();
        private Hashtable fields_types = new Hashtable();

        public FrmPaiShui2DB(GSOGlobeControl _globeControl1)
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
            {
                return;
            }
            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();
            cmbRadius.Items.Clear();
            cmbID.Items.Clear();
            cmbMaiSheFangShi.Items.Clear();
            cmbWidth.Items.Clear();
            cmbHeight.Items.Clear();
            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i));

                cmbFrom.Items.Add(fielddef.Name);
                cmbTo.Items.Add(fielddef.Name);
                cmbRadius.Items.Add(fielddef.Name);
                cmbID.Items.Add(fielddef.Name);
                cmbMaiSheFangShi.Items.Add(fielddef.Name);
                cmbWidth.Items.Add(fielddef.Name);
                cmbHeight.Items.Add(fielddef.Name);
            }
            cmbFrom.SelectedItem = "Deep1";
            cmbTo.SelectedItem = "Deep2";
            cmbID.SelectedItem = "Handle";
            cmbRadius.SelectedItem = "Diameter";
            cmbMaiSheFangShi.SelectedItem = "D_Type";
            cmbWidth.SelectedItem = "Weight";
            cmbHeight.SelectedItem = "Height";
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
            try
            {
                if (string.IsNullOrEmpty(textBoxNewLayerName.Text))
                {
                    MessageBox.Show("管线图层名称无效！", "提示");
                    return;
                }
                if (valiPipeData())
                {
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
                        MessageBox.Show("输入的图层名称不符合要求！", "提示");
                        return;
                    }
                    GSOLayer sourceLayer = globeControl1.Globe.Layers.GetLayerByCaption(comboBoxShpLayerList.SelectedItem.ToString().Trim());
                    if (sourceLayer == null)
                    {
                        MessageBox.Show("选择的shp图层为空！", "提示");
                        return;
                    }
                    newFeatureDataset.Open();
                    GSOFeatures features = sourceLayer.GetAllFeatures(true);
                    string message = "";
                    for (int j = 0; j < features.Length; j++)
                    {
                        GSOFeature f = features[j];

                        GSOFeature newFeature = newFeatureDataset.CreateFeature();
                        string maisheFangshi = f.GetFieldAsString(cmbMaiSheFangShi.SelectedItem.ToString());
                        string eventid = f.GetFieldAsString(cmbID.SelectedItem.ToString());

                        f.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;

                        GSOGeoPolyline3D line = f.Geometry as GSOGeoPolyline3D;
                        if (line == null)
                        {
                            message += "ID为" + f.ID + "的管线不是一个线对象\r\n";
                            continue;
                        }

                        double deep1 = f.GetFieldAsDouble(cmbFrom.SelectedItem.ToString());
                        double deep2 = f.GetFieldAsDouble(cmbTo.SelectedItem.ToString());

                        if (chkDeep.Checked)
                        {
                            deep1 = 0 - deep1;
                            deep2 = 0 - deep2;
                        }

                        if (maisheFangshi == "直埋")
                        {
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
                            else if (field.Type == EnumFieldType.Double)
                                radius = f.GetFieldAsDouble(cmbRadius.SelectedItem.ToString()) / 2000;  // 探测数据的单位一般是毫米，需换算为米； 管径一般是 直径， 这个需要半径， 所有除以2000 

                            if (radius == 0)
                            {
                                message += "ID为" + f.ID + "的管线半径为0\r\n";
                                continue;
                            }

                            style.Radius = radius;
                            style.Slice = int.Parse(txtSlice.Text);
                            style.CornerSliceAngle = Convert.ToDouble(textBoxCornerSliceAngle.Text);


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
                                    pt3d.Z = deep1;
                                else
                                {
                                    double radio = Math.Sqrt(Math.Pow(pt3d.Y - line[0][0].Y, 2) + Math.Pow(pt3d.X - line[0][0].X, 2)) / fenmu;
                                    pt3d.Z = deep1 + (deep2 - deep1) * radio;
                                }
                                line[0][n] = pt3d;
                            }

                            newFeature.Geometry = line; // f.Geometry;
                            newFeature.Geometry.Style = style;
                        }
                        else if (maisheFangshi == "沟道")
                        {
                            GSOExtendSectionLineStyle3D style = new GSOExtendSectionLineStyle3D();
                            style.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), btnPipelineColor.BackColor);

                            double width = 0;
                            GSOFieldDefn field = (GSOFieldDefn)(f.GetFieldDefn(cmbWidth.SelectedItem.ToString()));
                            if (field.Type == EnumFieldType.Text)
                            {
                                string temp = f.GetFieldAsString(cmbWidth.SelectedItem.ToString());
                                double outNum = 0;
                                bool num = double.TryParse(temp, out outNum);
                                if (num)
                                    width = outNum;

                            }
                            else if (field.Type == EnumFieldType.Double)
                                width = f.GetFieldAsDouble(cmbWidth.SelectedItem.ToString());


                            double height = 0;
                            field = (GSOFieldDefn)(f.GetFieldDefn(cmbHeight.SelectedItem.ToString()));
                            if (field.Type == EnumFieldType.Text)
                            {
                                string temp = f.GetFieldAsString(cmbHeight.SelectedItem.ToString());
                                double outNum = 0;
                                bool num = double.TryParse(temp, out outNum);
                                if (num)
                                    height = outNum;

                            }
                            else if (field.Type == EnumFieldType.Double)
                                height = f.GetFieldAsDouble(cmbHeight.SelectedItem.ToString());


                            if (width == 0 || height == 0)
                            {
                                message += "ID为" + f.ID + "的沟道的宽度或高度为0\r\n";
                                continue;
                            }

                            GSOPoint3ds sectionpts = new GSOPoint3ds();
                            sectionpts.Add(new GSOPoint3d(width / -2, height / 2, 0));
                            sectionpts.Add(new GSOPoint3d(width / -2, height / -2, 0));
                            sectionpts.Add(new GSOPoint3d(width / 2, height / -2, 0));
                            sectionpts.Add(new GSOPoint3d(width / 2, height / 2, 0));

                            style.SetSectionPoints(sectionpts);
                            style.IsClosed = false;
                            style.SetAnchorByAlign(EnumAlign.BottomCenter);


                            for (int n = 0; n < line[0].Count; n++)
                            {
                                GSOPoint3d pt3d = line[0][n];
                                int pointcount = line[0].Count;
                                double fenmu = Math.Sqrt(Math.Pow(line[0][pointcount - 1].Y - line[0][0].Y, 2) + Math.Pow(line[0][pointcount - 1].X - line[0][0].X, 2));
                                if (fenmu == 0)
                                    pt3d.Z = deep1;
                                else
                                {
                                    double radio = Math.Sqrt(Math.Pow(pt3d.Y - line[0][0].Y, 2) + Math.Pow(pt3d.X - line[0][0].X, 2)) / fenmu;
                                    pt3d.Z = deep1 + (deep2 - deep1) * radio;
                                }
                                line[0][n] = pt3d;
                            }

                            newFeature.Geometry = line; // f.Geometry;
                            newFeature.Geometry.Style = style;
                        }
                        else
                        {
                            message += "ID为" + f.ID + "的对象的埋设方式既不是直埋，也不是沟道\r\n";
                            continue;  // 即不是 直埋，又不是 沟道，那么忽略该记录
                        }

                        for (int i = 0; i < f.GetFieldCount(); i++)
                        {
                            GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(f.GetFieldDefn(i));
                            if (!en_cns.ContainsKey(fielddef.Name))
                                continue;

                            object fieldvalue = f.GetValue(fielddef.Name);// convertFieldValue(fielddef.Name, f.GetValue(fielddef.Name));
                            if (fieldvalue == null)
                                continue;
                            string fieldName = en_cns.ContainsKey(fielddef.Name) == true ? en_cns[fielddef.Name].ToString() : fielddef.Name;
                            newFeature.SetValue(fieldName, fieldvalue);
                        }

                        newFeature.Name = eventid;
                        newFeatureDataset.AddFeature(newFeature);
                    }
                    globeControl1.Refresh();

                    newFeatureDataset.Save();
                    newFeatureDataset.Close();
                    newFeatureDataset.Caption = newFeatureDataset.Name;
                    globeControl1.Globe.Layers.Add(newFeatureDataset);

                    string strMessage = "shp文件中共" + features.Length + "个对象，实际入库" + newFeatureDataset.GetAllFeatures().Length + "个对象！\r\n";
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
            if (featDataSet == null)
            {
                MessageBox.Show("选择的图层不是矢量图层！");
                return false;
            }
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
            List<string> lst = new List<string>();
            for (int j = 0; j < features.Length; j++)
            {
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
                if (!en_cns.ContainsKey(fielddef.Name))
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