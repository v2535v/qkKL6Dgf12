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
    public partial class FrmAddYuBiZiShp : Form
    {
        GeoScene.Globe.GSOGlobeControl globeControl1;
        public FrmAddYuBiZiShp(GeoScene.Globe.GSOGlobeControl _globeControl1)
        {
            globeControl1 = _globeControl1;
            InitializeComponent();
        }

        private ArrayList files =new ArrayList ();
        private ArrayList modeltypes = new ArrayList(); // 井的型号
        private ArrayList deeps = new ArrayList();
        private Hashtable yb_cns = new Hashtable();
        private Hashtable yb_types = new Hashtable();
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
            textBoxModelFolder.Text = Application.StartupPath + "\\雨篦和工井模型";

            string filename = Application.StartupPath + "\\config.xml";
            if (File.Exists(filename))
            {
                XmlTextReader XmlReader = new XmlTextReader(filename);
                try
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.Name == "YuBi")
                        {
                            string str1 = XmlReader["label"];
                            string str3 = XmlReader["type"];
                            string str2 = XmlReader.ReadElementString();
                            yb_cns.Add(str1, str2);
                            yb_types.Add(str1, str3);
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

            combCode.Items.Clear();
            combDeep.Items.Clear();
            combModelName.Items.Clear();
            combAngle.Items.Clear();
            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i));
                combCode.Items.Add(fielddef.Name);
                combDeep.Items.Add(fielddef.Name);
                combModelName.Items.Add(fielddef.Name);
                combAngle.Items.Add(fielddef.Name);
            }
            combAngle.SelectedItem = "旋转角度";
            combCode.SelectedItem = "管线点编码";
            combDeep.SelectedItem = "井深";
            combModelName.SelectedItem = "编号";
        }

        private void button1_Click(object sender, EventArgs e)//模板文件夹
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = Application.StartupPath;
            dlg.ShowDialog();
            textBoxModelFolder.Text = dlg.SelectedPath;
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
            if (textBoxModelFolder.Text == "")
            {
                return;
            }
            if (comboBoxShpLayerList.SelectedIndex < 0)
            {
                return;
            }
            try
            {
                Regex regNum = new Regex("^[0-9]");

                DirectoryInfo theFolder = new DirectoryInfo(textBoxModelFolder.Text);
                foreach (FileInfo nextFile in theFolder.GetFiles())
                {
                    if (nextFile.Name.ToLower().IndexOf("3ds") > -1 || nextFile.Name.ToLower().IndexOf("gcm") > -1)
                    {
                        files.Add(nextFile.Name);
                        string temp = nextFile.Name.Substring(nextFile.Name.IndexOf("-") + 1, nextFile.Name.LastIndexOf(".") - nextFile.Name.IndexOf("-") - 1);
                        string modeltype = nextFile.Name.Substring(0, nextFile.Name.IndexOf("-"));
                        modeltypes.Add(modeltype);

                        double Num;
                        bool isNum = double.TryParse(temp, out Num);

                        if (isNum)
                        {
                            deeps.Add(Convert.ToDouble(temp));
                        }
                    }
                }
                GSOFeatureDataset featdataset = CreateDBFeatureDataset(textBoxNewLayerName.Text);
                if (featdataset == null)
                {
                    return;
                }
                featdataset.Open();
                GSOLayer shpLayer = globeControl1.Globe.Layers.GetLayerByCaption(comboBoxShpLayerList.SelectedItem.ToString().Trim());
                if (shpLayer == null)
                    return;
                
                GSOFeatures features = shpLayer.GetAllFeatures(true);
                string message = "";
                for (int j = 0; j < features.Length; j++)
                {
                    GSOFeature f = features[j];
                    GSOGeoPoint3D shpPoint = f.Geometry as GSOGeoPoint3D;

                    double x;
                    double y;
                    
                    double rotateAngle = 0;
                    rotateAngle = (double)f.GetValue(combAngle.SelectedItem.ToString());

                    string currentModelType = f.GetValue(combCode.SelectedItem.ToString()).ToString();
                    double z = Convert.ToDouble(txtUpGround.Text);
                    
                    double deep=f.GetFieldAsDouble(combDeep.SelectedItem.ToString());                    

                    int index = -1;
                    double diff = double.MaxValue;
                    for (int i = 0; i < deeps.Count; i++)
                    {
                        double tempdeep = Convert.ToDouble(deeps[i]);
                        string modeltype = modeltypes[i].ToString();
                        if (modeltype != currentModelType)
                        {
                            continue;
                        }

                        if (tempdeep > deep)
                        {
                            double chazhi = tempdeep - deep;
                            if (diff > chazhi)
                            {
                                diff = chazhi;
                                index = i;
                            }
                        }
                    }
                    if (index < 0)
                    {
                        message += "ID为" + f.ID + "的对象没有找到符合要求的模型 \r\n";
                        continue;
                    }
                    
                    GSOFeature feature = featdataset.CreateFeature();
                    GSOGeoModel model = new GSOGeoModel();
                    GSOPoint3d pt = new GSOPoint3d();
                    pt.X = shpPoint.X;
                    pt.Y = shpPoint.Y;
                    pt.Z = z;

                    model.Position = pt;
                    model.Align = EnumEntityAlign.TopCenter; //接口已修复作用
                    model.AltitudeMode = EnumAltitudeMode.RelativeToGround;

                    model.RotateZ = 0 - rotateAngle * 180 / Math.PI + 90;

                    model.FilePath = textBoxModelFolder.Text + "\\" + files[index];
                    model.Name = f.GetValue(combModelName.SelectedItem.ToString()).ToString();
                    feature.Name = f.GetValue(combModelName.SelectedItem.ToString()).ToString();
                    feature.Geometry = model;
                    
                    for (int i = 0; i < f.GetFieldCount(); i++)
                    {
                        GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(f.GetFieldDefn(i));
                      
                        if (fielddef == null)
                            continue;
                        if (!yb_cns.ContainsKey(fielddef.Name))
                            continue;
                        if (f.GetValue(fielddef.Name)==null )
                        {
                            continue;
                        }
                        string fieldName = yb_cns.ContainsKey(fielddef.Name) == true ? yb_cns[fielddef.Name].ToString() : fielddef.Name;
                        feature.SetValue(fieldName, f.GetValue(fielddef.Name));
                    }
                    featdataset.AddFeature(feature);                   
                }

                featdataset.Save();
                featdataset.Close();
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
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message);
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

                if (!yb_cns.ContainsKey(fielddef.Name))
                    continue;
                GSOFieldAttr field = new GSOFieldAttr();
                field.Name = yb_cns.ContainsKey(fielddef.Name) == true ? yb_cns[fielddef.Name].ToString() : fielddef.Name;
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
