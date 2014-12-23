using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using GeoScene.Data;
using System.Text.RegularExpressions;
using GeoScene.Engine;
using GeoScene.Globe;
using System.Xml;

namespace WorldGIS.Forms
{
    public partial class FrmAddValve : Form
    {
        GeoScene.Globe.GSOGlobeControl globeControl1;
        private Hashtable fm_cns = new Hashtable();
        private Hashtable fm_types = new Hashtable();
        public FrmAddValve(GeoScene.Globe.GSOGlobeControl _globeControl1)
        {
            globeControl1 = _globeControl1;
            InitializeComponent();
        }
        private void FrmAddWellShp_Load(object sender, EventArgs e)
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
            string filename = Application.StartupPath + "\\config.xml";
            if (File.Exists(filename))
            {
                XmlTextReader XmlReader = new XmlTextReader(filename);
                try
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.Name == "Valve")
                        {
                            string str1 = XmlReader["label"];
                            string str3 = XmlReader["type"];
                            string str2 = XmlReader.ReadElementString();
                            fm_cns.Add(str1, str2);
                            fm_types.Add(str1, str3);
                        }
                    }
                }
                catch (Exception ex)
                {

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

            combPath.Items.Clear();
            combZ.Items.Clear();
            combModelName.Items.Clear();

            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i));
                combPath.Items.Add(fielddef.Name);
                combZ.Items.Add(fielddef.Name);
                combModelName.Items.Add(fielddef.Name);
            }
            combModelName.SelectedItem = "编号";
            combPath.SelectedItem = "模型路径";
            combZ.SelectedItem = "Z坐标";
        }

        private void button3_Click(object sender, EventArgs e)
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
            if (comboBoxShpLayerList.SelectedIndex<0)
            {
                return;
            }
            try
            {
                if (valiValvedata())
                {
                    GSOFeatureDataset featdataset = CreateDBFeatureDataset(textBoxNewLayerName.Text);
                    if (featdataset == null)
                    {
                        return;
                    }
                    featdataset.Open();
                    GSOLayer shpLayer = globeControl1.Globe.Layers[comboBoxShpLayerList.SelectedIndex];
                    if (shpLayer == null)
                    {
                        return;
                    }

                    GSOFeatures features = shpLayer.GetAllFeatures(true);
                    string message = "";
                    for (int j = 0; j < features.Length; j++)
                    {
                        GSOFeature f = features[j];
                        GSOGeoPoint3D shpPoint = f.Geometry as GSOGeoPoint3D;
                        double z = f.GetFieldAsDouble(combZ.SelectedItem.ToString());
                        double deep = f.GetFieldAsDouble(combZ.SelectedItem.ToString());

                        GSOFeature feature = featdataset.CreateFeature();
                        GSOGeoModel model = new GSOGeoModel();
                        GSOPoint3d pt = new GSOPoint3d();
                        pt.X = shpPoint.X;
                        pt.Y = shpPoint.Y;
                        pt.Z = z;

                        model.Position = pt;
                        model.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        string modelPath = f.GetFieldAsString(combPath.SelectedItem.ToString());
                        model.FilePath = Application.StartupPath + "\\" + modelPath;
                        model.Name = f.GetValue(combModelName.SelectedItem.ToString()).ToString();
                        feature.Name = f.GetValue(combModelName.SelectedItem.ToString()).ToString();
                        feature.Geometry = model;

                        for (int i = 0; i < f.GetFieldCount(); i++)
                        {
                            GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(f.GetFieldDefn(i));
                            if (fielddef == null)
                            {
                                continue;
                            }
                            if (!fm_cns.ContainsKey(fielddef.Name))
                            {
                                continue;
                            }

                            object obu = f.GetValue(fielddef.Name);
                            if (obu != null)
                            {
                                string fieldName = fm_cns.ContainsKey(fielddef.Name) == true ? fm_cns[fielddef.Name].ToString() : fielddef.Name;
                                feature.SetValue(fieldName, obu);
                            }                            
                        }
                        featdataset.AddFeature(feature);
                    }
                    featdataset.Save();

                    string strMessage = "shp文件中共" + features.Length + "个对象，实际入库" + featdataset.GetAllFeatures().Length + "个对象！\r\n";
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

        private bool valiValvedata()
        {
            if (comboBoxShpLayerList.SelectedItem == null)
            {
                MessageBox.Show("请选择一个shp图层！");
                return false;
            }
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(comboBoxShpLayerList.SelectedItem.ToString().Trim());
            if (layer == null)
            {
                MessageBox.Show("选择的图层为空！");
                return false;
            }
            if (layer != null)
            {
                GSOFeatureDataset featDataSet = layer.Dataset as GSOFeatureDataset;

                if (featDataSet.FieldCount <= 0)
                {
                    MessageBox.Show("图层中字段数必须大于0");
                    return false;
                }
                GSOFieldAttr fieldID = featDataSet.GetField("编号");
                if (fieldID == null)
                {
                    MessageBox.Show("编号 字段不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                GSOFieldAttr fieldModelPath = featDataSet.GetField("模型路径");
                if (fieldModelPath == null)
                {
                    MessageBox.Show("模型路径 字段不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                GSOFieldAttr fieldZ = featDataSet.GetField("Z坐标");
                if (fieldZ.Type != EnumFieldType.Double && fieldZ.Type != EnumFieldType.Float && fieldZ.Type != EnumFieldType.INT16 && fieldZ.Type != EnumFieldType.INT32)
                {
                    MessageBox.Show("Z坐标 必须为数值类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature f = layer.GetAt(i);
                    for (int j = 0; j < featDataSet.FieldCount; j++)
                    {
                        GSOFieldAttr field = featDataSet.GetField(j);
                        if (field.Type == EnumFieldType.Text)
                        {
                            if (f.GetValue(j).ToString().Trim().Length > 5000)
                            {
                                MessageBox.Show("ID为" + f.ID + "的要素的字段" + field.Name + "的长度大于5000 ！\r\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            else 
            {
                return false;
            }
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

                if (!fm_cns.ContainsKey(fielddef.Name))
                    continue;

                GSOFieldAttr field = new GSOFieldAttr();
                field.Name = fm_cns.ContainsKey(fielddef.Name) == true ? fm_cns[fielddef.Name].ToString() : fielddef.Name;
                field.Type = fielddef.Type;
                field.Width = fielddef.Width;
                field.Precision = fielddef.Precision;
                bool res = newFeatureDataset.AddField(field);
            }

            newFeatureDataset.Save();
            return newFeatureDataset;   
        }
    }
}
