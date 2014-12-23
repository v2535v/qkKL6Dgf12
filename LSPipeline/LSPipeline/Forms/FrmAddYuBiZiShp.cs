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

namespace WorldGIS.Forms
{
    public partial class FrmAddYuBiZiShp : Form
    {
        GeoScene.Globe.GSOGlobeControl globeControl1;
        GSODataSource ds;
        public FrmAddYuBiZiShp(GeoScene.Globe.GSOGlobeControl _globeControl1, GSODataSource _ds)
        {
            globeControl1 = _globeControl1;
            ds = _ds;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            txtFolder.Text = dlg.SelectedPath;
        }

       

        private ArrayList files =new ArrayList ();
        private ArrayList modeltypes = new ArrayList(); // 井的型号
        private ArrayList deeps = new ArrayList();

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text == "")
                return;

            if (cmbLayer.SelectedIndex<0)
                return;

            try
            {
                Regex regNum = new Regex("^[0-9]");

                DirectoryInfo theFolder = new DirectoryInfo(txtFolder.Text);
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
                GSOFeatureDataset featdataset = CreateDBFeatureDataset(txtLayerName.Text);
                featdataset.Open();
                
                GSOLayer shpLayer = globeControl1.Globe.Layers[cmbLayer.SelectedIndex];
                if (shpLayer == null)
                    return;

                GSOFeatures features = shpLayer.GetAllFeatures(true);

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

                    model.FilePath = txtFolder.Text + "\\" + files[index];
                    model.Name = f.GetValue(combModelName.SelectedItem.ToString()).ToString();
                    feature.Name = f.GetValue(combModelName.SelectedItem.ToString()).ToString();
                    feature.Geometry = model;
                    
                    for (int i = 0; i < feature.GetFieldCount(); i++)
                    {
                        GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(f.GetFieldDefn(i));
                        //if (!en_cns.ContainsKey(fielddef.Name))
                        //    continue;
                      //  object fieldvalue = convertFieldValue(fielddef.Name, f.GetValue(fielddef.Name));
                        if (fielddef == null)
                            continue;
                        feature.SetValue(fielddef.Name, f.GetValue(fielddef.Name));
                    }
                    featdataset.AddFeature(feature);
                }

                featdataset.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        //导入数据库
   /*     private void button3_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text == "")
                return;

            if (txtPath.Text == "")
                return;


            Regex regNum = new Regex("^[0-9]");

            DirectoryInfo theFolder = new DirectoryInfo(txtFolder.Text);
            foreach (FileInfo nextFile in theFolder.GetFiles())
            {
                if (nextFile.Name.ToLower().IndexOf("3ds") > -1 || nextFile.Name.ToLower().IndexOf("gcm") > -1)
                {
                    files.Add(nextFile.Name);
                    string temp = nextFile.Name.Substring(nextFile.Name.IndexOf("-")+1, nextFile.Name.LastIndexOf(".") - nextFile.Name.IndexOf("-")-1);
                    string modeltype = nextFile.Name.Substring(0,nextFile.Name.IndexOf("-"));
                    modeltypes.Add(modeltype);

                    double Num;
                    bool isNum = double.TryParse(temp, out Num);

                    if (isNum)
                    {
                        deeps.Add(Convert.ToDouble(temp));
                    }
                }
            }

            TextReader tr = new StreamReader(txtPath.Text);
   
            string line = tr.ReadLine();

            GSOFeatureDataset featdataset = CreateDBFeatureDataset(txtLayerName.Text);
            featdataset.Open();
            while (line != null)
            {
                string[] paras = line.Split(',');

                if (paras.Length != 16)
                {
                    line = tr.ReadLine();
                    continue;
                }

                if (paras.Length <= 15)
                {
                    line = tr.ReadLine();
                    continue;
                }               

                if (paras[4] == "" || paras[5] == "" || paras[6] == "")
                {
                    line = tr.ReadLine();
                    continue;
                }
                double x;
                double y;

                if (!double.TryParse(paras[5], out x))
                {
                    line = tr.ReadLine();
                    continue;
                }

                if (!double.TryParse(paras[4], out y))
                {
                    line = tr.ReadLine();
                    continue;
                }                
                double rotateAngle = 0;
                if (!double.TryParse(paras[15], out rotateAngle))
                {
                    line = tr.ReadLine();
                    continue;
                }
                string currentModelType = paras[6];
                if (currentModelType.Length == 0)
                {
                    line = tr.ReadLine();
                    continue;
                }

                int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=-50000 +y_0=-4210000 +ellps=krass +units=m +no_defs");
                GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
                GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(pt2d, id);

                double z = Convert.ToDouble(txtUpGround.Text);
                GSOFeature feature = featdataset.CreateFeature();
                double deep;
                if (!double.TryParse(paras[8],out deep))
                {
                    line = tr.ReadLine();
                    continue;
                }

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

                    if ( tempdeep > deep )
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
                    line = tr.ReadLine();
                    continue;
                }

                //model.FilePath = txtFolder.Text + "\\" + files[index];
                //model.Position = new GSOPoint3d(result.X, result.Y, z);

                //model.Rotate(0, 0-rotateAngle*180/Math.PI + 90,0);  //旋转的轴，yz 调换了， 有bug              

                //model.Align = EnumEntityAlign.TopCenter; //接口已修复作用
                //model.AltitudeMode = EnumAltitudeMode.RelativeToGround;

                GSOGeoPoint3D pt = new GSOGeoPoint3D(result.X, result.Y, z);         
               
                //model.FilePath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/model/tank.3ds";
                feature.Geometry = pt;

                if (paras[9].Length > 0)
                    feature.SetValue("图片编码", paras[9]);
                feature.SetValue("旋转角度", 0 - rotateAngle * 180 / Math.PI + 90);
                feature.SetValue("编号", paras[0]);
                feature.SetValue("模型路径", txtFolder.Text + "\\" + files[index]);

                featdataset.AddFeature(feature);
            
                line = tr.ReadLine();
            }
            featdataset.Save();            
            this.Close();
        }
        */
        private GSOFeatureDataset CreateDBFeatureDataset(string name)
        {       
            //GSOFeatureDataset featDs = ds.CreateFeatureDataset(name);         

            //GSOFieldAttr field = new GSOFieldAttr();
            //field.Name = "编号";
            //field.Type = EnumFieldType.Text;
            //field.Width = 30;            
            //featDs.AddField(field);

            //field = new GSOFieldAttr();
            //field.Name = "井深";
            //field.Type = EnumFieldType.Double;
            //field.Width = 8;
            //featDs.AddField(field);

            //field = new GSOFieldAttr();
            //field.Name = "图片编码";
            //field.Type = EnumFieldType.Text;
            //field.Width = 150;
            //featDs.AddField(field);

            //field = new GSOFieldAttr();
            //field.Name = "建设年代";
            //field.Type = EnumFieldType.Text;
            //field.Width = 30;
            //featDs.AddField(field);

            //field = new GSOFieldAttr();
            //field.Name = "建设单位";
            //field.Type = EnumFieldType.Text;
            //field.Width = 60;
            //featDs.AddField(field);

            //field = new GSOFieldAttr();
            //field.Name = "权属单位";
            //field.Type = EnumFieldType.Text;
            //field.Width = 30;
            //featDs.AddField(field);

            //field = new GSOFieldAttr();
            //field.Name = "备注";
            //field.Type = EnumFieldType.Text;
            //field.Width = 30;
            //featDs.AddField(field);

            //field = new GSOFieldAttr();
            //field.Name = "旋转角度";
            //field.Type = EnumFieldType.Double;
            //field.Width = 8;
            //featDs.AddField(field);

            //field = new GSOFieldAttr();
            //field.Name = "模型路径";
            //field.Type = EnumFieldType.Text;
            //field.Width = 150;
            //featDs.AddField(field);

            GSOLayer layer = globeControl1.Globe.Layers[cmbLayer.SelectedIndex];
            GSOFeatures features = layer.GetAllFeatures();
            if (features.Length == 0)
            {
                MessageBox.Show("图层要素个数为0！", "提示");
                return null;
            }

            GSOFeatureDataset featDs = ds.CreateFeatureDataset(name);
            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i));

                //if (!en_cns.ContainsKey(fielddef.Name))
                //    continue;

                GSOFieldAttr field = new GSOFieldAttr();

                field.Name = fielddef.Name;  //en_cns[fielddef.Name].ToString();
                switch (fielddef.Type)
                {
                    case EnumFieldType.Text:
                        field.Type = EnumFieldType.Text;
                        field.Width = 100;
                        break;
                    case EnumFieldType.INT32:
                        field.Type = EnumFieldType.INT32;
                        field.Width = 4;
                        break;
                    case EnumFieldType.Double:
                        field.Type = EnumFieldType.Double;
                        field.Width = 8;
                        break;
                    case EnumFieldType.Date:
                        field.Type = EnumFieldType.Date;
                        field.Width = 10;
                        break;
                }
                bool res = featDs.AddField(field);
            }

            featDs.Save();
            return featDs;

            //featDs.Save();
            //return featDs;
        }

        private void FrmAddWellShp_Load(object sender, EventArgs e)
        {
            cmbLayer.Items.Clear();
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                cmbLayer.Items.Add(layer.Caption);
            }
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOLayer layer = globeControl1.Globe.Layers[cmbLayer.SelectedIndex];
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
        }
    }
}
