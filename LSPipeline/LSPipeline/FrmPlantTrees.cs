using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System.IO;
using System.Collections;

namespace WorldGIS
{
    public partial class FrmPlantTrees : Form
    {
        GSOGlobeControl mGlobeControl;
        public static GSOPlane3DControl plane3DControl; //预览模型的控件

        static Dictionary<int, string> dictionary = new Dictionary<int, string>();//存放打开的模型的路径
        static ArrayList listModel = new ArrayList();//存放打开的模型的名称
        static int iModelCount = 1;
        static string filePath = "";
        bool isEventEnabled = false;
        GSOPoint3d point;
        static List<string> modelPath = new List<string>();//存放已经打开过的模型所在文件夹的路径

        public FrmPlantTrees(GSOGlobeControl globeControl)
        {
            InitializeComponent();
            mGlobeControl = globeControl;
        }

        private void FrmPlantTrees_Load(object sender, EventArgs e)
        {
            if (modelPath.Count > 0)
            {
                foreach (string name in modelPath)
                {
                    comboBoxModelPath.Items.Add(name);  //加载时给combobox添加已经打开过的模型的路径
                }
            }           

            plane3DControl = new GSOPlane3DControl();
            panel1.Controls.Add(plane3DControl); //将控件添加到panel中
            plane3DControl.Dock = DockStyle.Fill;
            if (listModel.Count > 0)
            {
                foreach (string name in listModel)
                {
                    listView1.Items.Add(name);  //加载时给listView添加已经打开过的模型
                }               
            }
            //绑定鼠标的按下和谈起事件
            if (!isEventEnabled)
            {
                mGlobeControl.MouseDown += new MouseEventHandler(mGlobeControl_MouseDown);
                mGlobeControl.MouseUp += new MouseEventHandler(mGlobeControl_MouseUp);
                isEventEnabled = true;
            }
        }
        void mGlobeControl_MouseDown(object sender, MouseEventArgs e)//单击添加模型
        {
            if (e.Button == MouseButtons.Left)
            {                
                GSOLayer templayer;
                GSOFeature feature1 = mGlobeControl.Globe.HitTest(e.X, e.Y, out templayer, out point, false, true, 0);
                if (point.X == 0 && point.Y == 0 && point.Z == 0)
                {
                    point = mGlobeControl.Globe.ScreenToScene(e.X, e.Y);
                }               
            }
        }

        void mGlobeControl_MouseUp(object sender, MouseEventArgs e)//单击添加模型
        {
            if (e.Button == MouseButtons.Left)
            {
                GSOPoint3d newpoint;
                GSOLayer templayer;
                GSOFeature feature1 = mGlobeControl.Globe.HitTest(e.X, e.Y, out templayer, out newpoint, false, true, 0);
                if (newpoint.X == 0 && newpoint.Y == 0 && newpoint.Z == 0)
                {
                    newpoint = mGlobeControl.Globe.ScreenToScene(e.X, e.Y);
                }
                if (newpoint == point)
                {
                    GSOPoint3d pt = new GSOPoint3d();
                    pt.X = newpoint.X;
                    pt.Y = newpoint.Y;
                    pt.Z = newpoint.Z;

                    if (filePath != null && filePath != "")
                    {
                        if (mGlobeControl.Globe.Action == EnumAction3D.SelectObject)
                        {
                            GSOFeature newfeature = null;
                            if (mGlobeControl.Globe.DestLayerFeatureAdd.Dataset != null && mGlobeControl.Globe.DestLayerFeatureAdd.Dataset.IsFeatureDataset == true)
                            {
                                GSOFeatureDataset featureDataset = mGlobeControl.Globe.DestLayerFeatureAdd.Dataset as GSOFeatureDataset;
                                newfeature = featureDataset.CreateFeature();
                            }
                            else
                            {
                                newfeature = new GSOFeature();
                            }
                            newfeature.Name = Path.GetFileNameWithoutExtension(filePath) + "_" + iModelCount.ToString();
                            GSOGeoModel model = new GSOGeoModel();
                           
                            model.FilePath = filePath;                          
                           
                            model.Position = pt;
                            newfeature.Geometry = model;
                            mGlobeControl.Globe.DestLayerFeatureAdd.AddFeature(newfeature);

                            iModelCount++;
                        }
                    }
                } 
            }
        }

        private void buttonSeeFolder_Click_1(object sender, EventArgs e)//打开模型所在文件夹
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (comboBoxModelPath.Text == "")
            {
                if (modelPath.Count > 0)
                {
                    dlg.SelectedPath = modelPath[modelPath.Count - 1];
                }
                else
                {
                    dlg.SelectedPath = Application.StartupPath;
                }
            }
            else
            {
                dlg.SelectedPath = comboBoxModelPath.Text.Trim();
            }
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                comboBoxModelPath.Text = dlg.SelectedPath;
                modelPath.Add(dlg.SelectedPath);
                comboBoxModelPath.Items.Add(dlg.SelectedPath);//给combbox绑定数据
                listView1.Items.Clear();
                listModel.Clear();
                dictionary.Clear();
                GetAllModel(dlg.SelectedPath);
            }
        }

        private void GetAllModel(string path)  //将打开的文件夹中的所有模型都显示在listView中
        {
            string[] sArrayDir = Directory.GetDirectories(path);//得到所有子文件夹
            if (sArrayDir.Length > 0)
            {
                for(int i = 0; i<sArrayDir.Length; i++)
                {
                    GetAllModel(sArrayDir[i]);
                }                
            }
            string[] sArrayFile = Directory.GetFiles(path);//得到所有子文件
            if (sArrayFile.Length > 0)
            {
                for (int i = 0; i < sArrayFile.Length; i++)
                {
                    int m = sArrayFile[i].LastIndexOf("\\");
                    int n = sArrayFile[i].LastIndexOf(".");
                    string fileName = sArrayFile[i].Substring(m + 1, n - m - 1);
                    if (Path.GetExtension(sArrayFile[i]) == ".gcm" || Path.GetExtension(sArrayFile[i]) == ".3ds")
                    {
                        listView1.Items.Add(fileName);
                        listModel.Add(fileName);
                        dictionary.Add(listView1.Items.Count - 1, sArrayFile[i]);
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)//单击listView的项并在控件中预览
        {
            if (listView1.SelectedItems.Count > 0)
            {
                plane3DControl.Plane3DScene.RemoveAllFeature();

                GSOFeature feature = new GSOFeature();
                GSOGeoModel model = new GSOGeoModel();
                model.FilePath = dictionary[listView1.SelectedItems[0].Index];
                model.SetPosition(0, 0, 0);
                feature.Geometry = model;
                feature.Geometry.HighLight = false;
                feature.Geometry.LatLonCoord = false;
                plane3DControl.Plane3DScene.AddFeature(feature);

                filePath = dictionary[listView1.SelectedItems[0].Index];
            }
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void FrmPlantTrees_FormClosing(object sender, FormClosingEventArgs e)
        {
            mGlobeControl.MouseDown -= new MouseEventHandler(mGlobeControl_MouseDown);
            mGlobeControl.MouseUp -= new MouseEventHandler(mGlobeControl_MouseUp);
        }

        private void comboBoxModelPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModelPath.SelectedIndex != -1)
            {
                listView1.Items.Clear();
                listModel.Clear();
                dictionary.Clear();
                GetAllModel(comboBoxModelPath.Text.Trim());                
            }
        }
    }
}
