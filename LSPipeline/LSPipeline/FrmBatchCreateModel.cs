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
using GeoScene.Engine;
using GeoScene.Globe;

namespace WorldGIS
{
    public partial class FrmBatchCreateModel : Form
    {
        GeoScene.Globe.GSOGlobeControl globeControl1;
        public FrmBatchCreateModel(GeoScene.Globe.GSOGlobeControl _globeControl1)
        {           
            InitializeComponent();

            globeControl1 = _globeControl1;
        }
        
        private void FrmAddWell_Load(object sender, EventArgs e)
        {
            if (globeControl1.Globe.Layers.Count > 0)
            {
                for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
                {
                    if (globeControl1.Globe.Layers[i].Type == GeoScene.Globe.EnumLayerType.FeatureLayer)
                    {
                        comboBox1.Items.Add(globeControl1.Globe.Layers[i].Caption);
                    }
                }
            }
        }

        private void buttonSelectPath_Click(object sender, EventArgs e)//模型路径
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.gcm|*.gcm|*.3ds|*.3ds||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlg.FileName;
            } 
        }   
      
        private void buttonLayerPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.lgd|*.lgd|*.kml|*.kml||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxLayerPath.Text = dlg.FileName;
            } 
        }


        private ArrayList files =new ArrayList ();
        private ArrayList modeltypes = new ArrayList(); // 井的型号
        private ArrayList deeps = new ArrayList();

        private void buttonOk_Click(object sender, EventArgs e)//确定
        {
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("图层不能为空");
                return;
            }
            if (txtPath.Text.Trim() == "")
            {
                MessageBox.Show("模型路径不能为空");
                return;
            }

            if (textBoxLayerPath.Text.Trim() == "")
            {
                MessageBox.Show("图层保存路径不能为空");
                return;
            }

            GSOLayer newlayer = globeControl1.Globe.Layers.Add(textBoxLayerPath.Text.Trim());
            newlayer.Caption = Path.GetFileNameWithoutExtension(txtPath.Text.Trim());
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(comboBox1.Text.Trim());
            if (layer != null)
            { 
                GSOFeatures features = layer.GetAllFeatures();
                if (features.Length > 0)
                {
                    for (int i = 0; i < features.Length; i++)
                    {
                        if (features[i] != null && features[i].Geometry != null)
                        {
                            if (features[i].Geometry.Type == EnumGeometryType.GeoPoint3D)
                            {
                                GSOFeature feature = new GSOFeature();
                                GSOGeoPoint3D point3d = features[i].Geometry as GSOGeoPoint3D;
                                if (point3d != null)
                                {
                                    GSOGeoModel model = new GSOGeoModel();
                                    model.FilePath = txtPath.Text.Trim();
                                    model.Position = point3d.Position;
                                    feature.Geometry = model;
                                    newlayer.AddFeature(feature);
                                }
                            }
                        }
                    }
                    globeControl1.Globe.Refresh();
                }
            }

            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void button1_Click(object sender, EventArgs e)//测试点图层
        //{
        //    GSOLayer layer = globeControl1.Globe.Layers.Add(@"D:\data\point.lgd");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        GSOFeature feature = new GSOFeature();
        //        GSOGeoPoint3D p = new GSOGeoPoint3D();
        //        p.X = 113.1232 + i*2;
        //        p.Y = 34.212123;
        //        p.Z = 33;
        //        p.AltitudeMode = EnumAltitudeMode.RelativeToGround;
        //        feature.Geometry = p;
        //        layer.AddFeature(feature);
        //    }
        //    globeControl1.Globe.Refresh();
        //}


            #region 
            //Regex regNum = new Regex("^[0-9]");

            //DirectoryInfo theFolder = new DirectoryInfo(txtFolder.Text);
            //foreach (FileInfo nextFile in theFolder.GetFiles())
            //{
            //    if (nextFile.Name.ToLower().IndexOf("3ds") > -1 || nextFile.Name.ToLower().IndexOf("gcm") > -1)
            //    {
            //        files.Add(nextFile.Name);
            //        string temp = nextFile.Name.Substring(nextFile.Name.IndexOf("-")+1, nextFile.Name.LastIndexOf(".") - nextFile.Name.IndexOf("-")-1);
            //        string modeltype = nextFile.Name.Substring(0,nextFile.Name.IndexOf("-"));
            //        modeltypes.Add(modeltype);

            //        double Num;
            //        bool isNum = double.TryParse(temp, out Num);

            //        if (isNum)
            //        {
            //            deeps.Add(Convert.ToDouble(temp));
            //        }
            //    }
            //}

            //TextReader tr = new StreamReader(txtPath.Text);

            //GSOFeature lastfeature = null;
            //string line = tr.ReadLine();
            //while (line != null)
            //{
            //    string[] paras = line.Split(',');

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

            //    ///
            //    int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=-50000 +y_0=-4210000 +ellps=krass +units=m +no_defs");
            //    GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
            //    GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(pt2d, id);

            //    double z = Convert.ToDouble(txtUpGround.Text);
            //    GSOFeature feature = new GSOFeature();
            //    GSOGeoModel model = new GSOGeoModel();

            //    double deep;
            //    if (!double.TryParse(paras[8],out deep))
            //    {
            //        line = tr.ReadLine();
            //        continue;
            //    }

            //    //double deep = Convert.ToDouble(paras[8]);

            //    int index = -1;
            //    double diff = double.MaxValue;
            //    for (int i = 0; i < deeps.Count; i++)
            //    {
            //        double tempdeep = Convert.ToDouble(deeps[i]);
            //        string modeltype = modeltypes[i].ToString();
            //        if (modeltype != currentModelType)
            //        {
            //            continue;
            //        }

            //        if ( tempdeep > deep )
            //        {
            //            double chazhi = tempdeep - deep;
            //            if (diff > chazhi)
            //            {
            //                diff = chazhi;
            //                index = i;
            //            }
            //        }
            //    }
            //    if (index < 0)
            //    {
            //        line = tr.ReadLine();
            //        continue;
            //    }
            //    model.FilePath = txtFolder.Text + "\\" + files[index];
            //    model.Position = new GSOPoint3d(result.X, result.Y, z);

            //    model.Rotate(0, 0-rotateAngle*180/Math.PI + 90,0);
            //    //model.RotateZ = 0 - rotateAngle * 180 / Math.PI;

            //    model.Align = EnumEntityAlign.TopCenter; //接口已修复作用
            //    model.AltitudeMode = EnumAltitudeMode.RelativeToGround;

            //    feature.Geometry = model;
            //    feature.Name = paras[0];

            //    lastfeature = globeControl1.Globe.MemoryLayer.AddFeature(feature);
            //    line = tr.ReadLine();
            //}
            //globeControl1.Globe.FlyToFeature(lastfeature);
           
           

      

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    TextReader tr = new StreamReader(txtPath.Text);

        //    GSOFeature lastfeature = null;
        //    string line = tr.ReadLine();
        //    while (line != null)
        //    {
        //        string[] paras = line.Split(',');

        //        if (paras[4] == "" || paras[5] == "" || paras[6] == "")
        //        {
        //            line = tr.ReadLine();
        //            continue;
        //        }
        //        double x = Convert.ToDouble(paras[5]);
        //        double y = Convert.ToDouble(paras[4]);


        //        string currentModelType = paras[6];
                                
        //        int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=-50000 +y_0=-4210000 +ellps=krass +units=m +no_defs");
        //        GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
        //        GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(pt2d, id);

        //        double z = 0.1; //Convert.ToDouble(paras[3]);
        //        GSOFeature feature = new GSOFeature();


        //        GSOGeoMarker p = new GSOGeoMarker();
        //        GSOMarkerStyle3D style = new GSOMarkerStyle3D();
        //        style.IconPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/DefaultIcon.png";
        //        p.Style = style;
        //        p.X = result.X;
        //        p.Y = result.Y;

        //        feature.Geometry = p;
        //        feature.Name = paras[0];

        //        lastfeature = globeControl1.Globe.MemoryLayer.AddFeature(feature);
        //        line = tr.ReadLine();
        //    }
        //    globeControl1.Globe.FlyToFeature(lastfeature);
        //}
            #endregion 
    }
}
