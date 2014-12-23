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
using System.Xml;
using GeoScene.Globe;

namespace WorldGIS.Forms
{
    public partial class FrmAddWell : Form
    {
        GeoScene.Globe.GSOGlobeControl globeControl1;
        GSODataSource ds;

        private Hashtable en_cns = new Hashtable();
        private Hashtable fields_types = new Hashtable();

        public FrmAddWell(GeoScene.Globe.GSOGlobeControl _globeControl1,GSODataSource _ds)
        {
            globeControl1 = _globeControl1;
            ds = _ds;
            InitializeComponent();
        }

        private void FrmAddWell_Load(object sender, EventArgs e)
        {
            cmbLayer.Items.Clear();
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                cmbLayer.Items.Add(layer.Caption);
            }

            string filename = Application.StartupPath + "\\config.xml";
            if (File.Exists(filename))
            {
                XmlTextReader XmlReader = new XmlTextReader(filename);
                try
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.Name == "GongJing")
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
        private object convertFieldValue(string fieldname, object obj)
        {
            if (obj == null)
                return null;

            try
            {
                string type = fields_types[fieldname].ToString();
                switch (type)
                {
                    case "string":
                        return obj.ToString();
                    case "int":
                        //return 101;
                        int intResult;
                        if (int.TryParse(obj.ToString(), out intResult))
                            return intResult;
                        else
                            return null;
                    case "double":
                        //return 202.5;
                        double doubleResult;
                        if (double.TryParse(obj.ToString(), out doubleResult))
                            return doubleResult;
                        else
                            return null;
                    case "date":
                        DateTime dtResult;
                        if (DateTime.TryParse(obj.ToString(), out dtResult))
                            return dtResult;
                        else
                            return null;
                }
                return null;
            }
            catch (Exception exp)
            {
                Log.PublishTxt(exp);
                return null;
            }
        }

        public string lgdFilePath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            txtFolder.Text = dlg.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlg.FileName;
            }           
        }

        private ArrayList files =new ArrayList ();
        private ArrayList modeltypes = new ArrayList(); // 井的型号
        private ArrayList deeps = new ArrayList();

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text == "")
                return;

            //if (txtPath.Text == "")
            //    return;

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

        //        TextReader tr = new StreamReader(txtPath.Text);

        //        string line = tr.ReadLine();

        //        GSOFeatureDataset featdataset = CreateDBFeatureDataset(txtLayerName.Text);  // 创建 数据库要素集
        //        return;



                if (string .IsNullOrEmpty (txtLayerName .Text ))
                {
                    MessageBox .Show ("管线图层无效！","提示");
                    return ;
                }
                GSODataset dataset=ds .GetDatasetByName (txtLayerName .Text .Trim ());

                GSOFeatureDataset layer;
                if (dataset != null)
                {
                    DialogResult restult = MessageBox.Show("管线图层名称在数据库中已存在！是否向该表追加", "提示", MessageBoxButtons.YesNo);
                    if (restult == DialogResult.No)
                    {
                        return;
                    }
                    else if (restult == DialogResult.Yes)
                    {
                        layer = dataset as GSOFeatureDataset;
                    }
                    else
                        return;
                }
                else
                    layer = CreateDBFeatureDataset(txtLayerName.Text.Trim());

                if (layer == null)
                    return;

                GSOLayer sourceLayer = globeControl1.Globe.Layers[cmbLayer.SelectedIndex];

                MessageBox.Show("创建成功！");



                layer.Open();
                lgdFilePath = txtLayerName.Text;
                if (layer != null)
                {
                    GSOFeatures features = sourceLayer.GetAllFeatures(true);
                    for (int j = 0; j < features.Length; j++)
                    {
                        GSOFeature f = features[j];
                        GSOGeoPoint3D lineeee = f.Geometry as GSOGeoPoint3D;

                        //double x;
                        //double y;

                        //double rotateAngle = 0;

                        //string currentModelType = f.GetValue("管线点编码").ToString(); // paras[6];        
                        //double z = Convert.ToDouble(txtUpGround.Text);

                        //double deep = f.GetFieldAsDouble("井深");

                        //int index = -1;
                        //double diff = double.MaxValue;
                        //for (int i = 0; i < deeps.Count; i++)
                        //{
                        //    double tempdeep = Convert.ToDouble(deeps[i]);
                        //    string modeltype = modeltypes[i].ToString();
                        //    if (modeltype != currentModelType)
                        //    {
                        //        continue;
                        //    }

                        //    if (tempdeep > deep)
                        //    {
                        //        double chazhi = tempdeep - deep;
                        //        if (diff > chazhi)
                        //        {
                        //            diff = chazhi;
                        //            index = i;
                        //        }
                        //    }
                        //}
                        //if (index < 0)
                        //{
                        //    continue;
                        //}

                        //GSOFeature newFeature = layer.CreateFeature();
                        //GSOGeoModel model = new GSOGeoModel();
                        //GSOPoint3d pt = new GSOPoint3d();
                        //pt.X = lineeee.X;
                        //pt.Y = lineeee.Y;
                        //pt.Z = z;

                        //model.Position = pt;
                        //model.Align = EnumEntityAlign.TopCenter; //接口已修复作用
                        //model.AltitudeMode = EnumAltitudeMode.RelativeToGround;

                        //model.RotateZ = 0 - rotateAngle * 180 / Math.PI + 90;

                        //model.FilePath = txtFolder.Text + "\\" + files[index];



                        GSOFeature newFeature = layer.CreateFeature();

                        for (int i = 0; i < features[0].GetFieldCount(); i++)
                        {
                            GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i));
                            if (!en_cns.ContainsKey(fielddef.Name))
                                continue;
                            object fieldvalue = convertFieldValue(fielddef.Name, f.GetValue(fielddef.Name));
                            if (fielddef == null)
                                continue;

                            newFeature.SetValue(en_cns[fielddef.Name].ToString(), fieldvalue);
                        }
                        layer.AddFeature(newFeature);

                    }
                }
                globeControl1.Refresh();
                layer.Save();
                layer.Caption = layer.Name;
                globeControl1.Globe.Layers.Add(layer);
                this.Close();


            //创建

                //featdataset.Open();
                //while (line != null)
                //{
                //    string[] paras = line.Split(',');

                //    if (paras.Length != 16)
                //    {
                //        line = tr.ReadLine();
                //        continue;
                //    }

                //    if (paras.Length <= 15)
                //    {
                //        line = tr.ReadLine();
                //        continue;
                //    }

                //    if (paras[4] == "" || paras[5] == "" || paras[6] == "")
                //    {
                //        line = tr.ReadLine();
                //        continue;
                //    }
                //    double x;
                //    double y;

                //    if (!double.TryParse(paras[5], out x))
                //    {
                //        line = tr.ReadLine();
                //        continue;
                //    }

                //    if (!double.TryParse(paras[4], out y))
                //    {
                //        line = tr.ReadLine();
                //        continue;
                //    }
                //    double rotateAngle = 0;
                //    if (!double.TryParse(paras[15], out rotateAngle))
                //    {
                //        line = tr.ReadLine();
                //        continue;
                //    }
                //    string currentModelType = paras[6];
                //    if (currentModelType.Length == 0)
                //    {
                //        line = tr.ReadLine();
                //        continue;
                //    }

                //    int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=-50000 +y_0=-4210000 +ellps=krass +units=m +no_defs");
                //    GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
                //    GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(pt2d, id);

                //double z = Convert.ToDouble(txtUpGround.Text);
                //GSOFeature feature = featdataset.CreateFeature();
                //double deep;
                //if (!double.TryParse(paras[8], out deep))
                //{
                //    line = tr.ReadLine();
                //    continue;
                //}

                //int index = -1;
                //double diff = double.MaxValue;
                //for (int i = 0; i < deeps.Count; i++)
                //{
                //    double tempdeep = Convert.ToDouble(deeps[i]);
                //    string modeltype = modeltypes[i].ToString();
                //    if (modeltype != currentModelType)
                //    {
                //        continue;
                //    }

                //    if (tempdeep > deep)
                //    {
                //        double chazhi = tempdeep - deep;
                //        if (diff > chazhi)
                //        {
                //            diff = chazhi;
                //            index = i;
                //        }
                //    }
                //}
                //if (index < 0)
                //{
                //    line = tr.ReadLine();
                //    continue;
                //}

                //GSOGeoModel model = new GSOGeoModel();
                //GSOPoint3d pt = new GSOPoint3d();
                //pt.X = result.X;
                //pt.Y = result.Y;
                //pt.Z = z;

                //model.Position = pt;
                //model.Align = EnumEntityAlign.TopCenter; //接口已修复作用
                //model.AltitudeMode = EnumAltitudeMode.RelativeToGround;


                //model.RotateZ = 0 - rotateAngle * 180 / Math.PI + 90;

                //model.FilePath = txtFolder.Text + "\\" + files[index];
                //model.Name = paras[0];
                //feature.Name = paras[0];
                //feature.Geometry = model;

                //    if (paras[9].Length > 0)
                //        feature.SetValue("图片编码", paras[9]);
                //  //  feature.SetValue("旋转角度", 0 - rotateAngle * 180 / Math.PI + 90);
                //    feature.SetValue("编号", paras[0]);
                //   // feature.SetValue("模型路径", txtFolder.Text + "\\" + files[index]);
                //    feature.SetValue("建设年代",paras[10]);
                //    feature.SetValue("建设单位", paras[12]);
                //    feature.SetValue("权属单位",paras[13]);
                //    feature.SetValue("备注",paras[14]);
                //    featdataset.AddFeature(feature);
                //    line = tr.ReadLine();
                //}
                //featdataset.Save();
                //this.Close();
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
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

            //ICollection ic = en_cns.Keys;
            //IDictionaryEnumerator ie = en_cns.GetEnumerator();
            //while (ie.MoveNext())
            //{
            //    object en_name = ie.Key;
            //    object ch_name = ie.Value;
            //    object field_type = fields_types[en_name];

            //    field.Name = ch_name.ToString();
            //    switch (field_type.ToString())
            //    {
            //        case "string":
            //            field.Type = EnumFieldType.Text;
            //            field.Width = 100;
            //            break;
            //        case "int":
            //            field.Type = EnumFieldType.INT32;
            //            field.Width = 4;
            //            break;
            //        case "double":
            //            field.Type = EnumFieldType.Double;
            //            field.Width = 8;
            //            break;
            //        case "date":
            //            field.Type = EnumFieldType.Date;
            //            field.Width = 10;
            //            break;
            //    }
            //    bool res = featDs.AddField(field);
            //}
            //featDs.Save();
            //return featDs;

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

                if (!en_cns.ContainsKey(fielddef.Name))
                    continue;

                GSOFieldAttr field = new GSOFieldAttr();

                field.Name = en_cns[fielddef.Name].ToString();
                switch (fields_types[fielddef.Name].ToString())
                {
                    case "string":
                        field.Type = EnumFieldType.Text;
                        field.Width = 8000;
                        break;
                    case "int":
                        field.Type = EnumFieldType.INT32;
                        field.Width = 4;
                        break;
                    case "double":
                        field.Type = EnumFieldType.Double;
                        field.Width = 8;
                        break;
                    case "date":
                        field.Type = EnumFieldType.Date;
                        field.Width = 10;
                        break;
                }
                bool res = featDs.AddField(field);
            }

            featDs.Save();
            return featDs;
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOLayer layer = globeControl1.Globe.Layers[cmbLayer.SelectedIndex];
            GSOFeatures features = layer.GetAllFeatures();
            if (features.Length == 0)
                return;

            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                GeoScene.Data.GSOFieldDefn fielddef = (GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i));

                //cmbFrom.Items.Add(fielddef.Name);
                //cmbTo.Items.Add(fielddef.Name);
                //cmbRadius.Items.Add(fielddef.Name);
                //cmbID.Items.Add(fielddef.Name);
            }
        }
    }
}
