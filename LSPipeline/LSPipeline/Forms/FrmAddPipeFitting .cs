using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;
using System.Runtime.InteropServices;
namespace WorldGIS.Forms
{
    public partial class FrmAddPipeFitting : Form
    {
        public GSOPlane3DControl plane3DControl;
        private GSOGlobeControl globeControl1;
        private GSOFeature feature;
        string modelPath;
        public GSOPoint3d point;
        private GSOLayer layer;
        public FrmAddPipeFitting(GSOGlobeControl ctl, GSOPoint3d p,GSOLayer _layer)
        {
            InitializeComponent();
            this.globeControl1 = ctl;
            this.point = p;
            layer = _layer;
            plane3DControl = new GSOPlane3DControl();
            panel1.Controls.Add(plane3DControl);
            plane3DControl.Dock = DockStyle.Fill;
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (feature != null)
            {
                GSOPoint3d pt = new GSOPoint3d();
                pt.X = point.X;
                pt.Y = point.Y;
                pt.Z = point.Z;
                GSOGeoModel model = new GSOGeoModel();
                model.FilePath = modelPath;
                model.Position = pt;
                model.AltitudeMode = EnumAltitudeMode.Absolute;
                feature = new GSOFeature();
                feature.Geometry = model;
                layer.AddFeature(feature);
                globeControl1.Refresh();
            }
            this.Close();     
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddPipeFitting_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\管道配件gcm\";
            DirectoryInfo theFolder = new DirectoryInfo(path);
            foreach (DirectoryInfo NextFolder in theFolder.GetDirectories())
            {
                this.listBoxType.Items.Add(NextFolder.Name);
            }
        }
        List<string> list = new List<string>() ;
        private void listBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxSize.Items.Clear();
            list.Clear();
            string path = Application.StartupPath + @"\管道配件gcm\" + listBoxType.SelectedItem.ToString() + @"\";
            DirectoryInfo theFolder = new DirectoryInfo(path);
            foreach (FileInfo nextFile in theFolder.GetFiles())
            {
                if (nextFile.Name.IndexOf("3DS") > -1 || nextFile.Name.IndexOf("gcm")>-1)
                {
                    this.listBoxSize.Items.Add(nextFile.Name.Substring(0,nextFile.Name.IndexOf(".")));
                    list.Add(nextFile.Name);
                }
            }
        }

        private void listBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSize.SelectedIndex != -1)
            {
                string path = Application.StartupPath + @"\管道配件gcm\" + listBoxType.SelectedItem.ToString() + "\\" + list[listBoxSize.SelectedIndex];
                GSOGeoModel model = new GSOGeoModel();
                model.FilePath = path;
                modelPath = path;
                model.SetPosition(0, 0, 0);
                feature = new GSOFeature();
                feature.Geometry = model;
                feature.Geometry.LatLonCoord = false;
                feature.HighLight = false;
                this.plane3DControl.Plane3DScene.RemoveAllFeature();
                this.plane3DControl.Plane3DScene.AddFeature(feature);
            }
            else
            {

            }
           
            
        }
    }
}
