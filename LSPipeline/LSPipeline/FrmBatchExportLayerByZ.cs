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

using System.Management;
using System.Runtime.InteropServices;
using System.Xml;
using WorldGIS.Forms;
using System.Collections;

namespace WorldGIS
{
    public partial class FrmBatchExportLayerByZ : Form
    {
        GeoScene.Globe.GSOGlobeControl globeControl1;
        public FrmBatchExportLayerByZ(GSOGlobeControl globeControl1)
        {
            InitializeComponent();
            this.globeControl1 = globeControl1;
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++) 
            {
                TreeNode node = new TreeNode();
                node.Text = globeControl1.Globe.Layers[i].Caption;
                node.Tag = globeControl1.Globe.Layers[i];
                treeView1.Nodes.Add(node);
            }
        }

        private GSOFeatures getFeatures() 
        {
            try
            {
                GSOFeatures feats = new GSOFeatures();
                double min = double.Parse(textBox1.Text);
                double max = double.Parse(textBox2.Text);
                for (int i = 0; i < treeView1.Nodes.Count; i++) 
                {
                    if (treeView1.Nodes[i].Checked) 
                    {
                        GSOLayer layer = treeView1.Nodes[i].Tag as GSOLayer;
                        GSOFeatures fs = layer.GetAllFeatures();
                        for (int j = 0; j < fs.Length; j++) 
                        {
                            GSOFeature f = fs[j];
                            double z = f.Geometry.GeoCenterPoint.Z;
                            if (f != null && f.Geometry != null && f.Geometry.Type == EnumGeometryType.GeoModel)
                            {
                                GSOGeoModel model = f.Geometry as GSOGeoModel;
                                z = model.PositionZ;
                            }
                            if (z >= min && z <= max) 
                            {
                                feats.Add(f);
                            }
                        }
                    }
                }
                return feats;
            }
            catch (Exception exp) 
            {
                exp.GetType();
            }
            return null;
        }
        //高亮
        private void button1_Click(object sender, EventArgs e)
        {
            GSOFeatures feats = getFeatures();
            if (feats != null && feats.Length != 0) 
            {
                for (int i = 0; i < feats.Length; i++) 
                {
                    feats[i].HighLight = true;
                }
            }
            globeControl1.Globe.Refresh();
        }
        //取消高亮
        private void button4_Click(object sender, EventArgs e)
        {
            GSOFeatures feats = getFeatures();
            if (feats != null && feats.Length != 0)
            {
                for (int i = 0; i < feats.Length; i++)
                {
                    feats[i].HighLight = false;
                }
            }
            globeControl1.Globe.Refresh();
        }
        //关闭
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //导出
        private void button2_Click(object sender, EventArgs e)
        {
            button4_Click(null, null);
            GSOFeatures feats = getFeatures();
            if (feats == null || feats.Length == 0)
            {
                MessageBox.Show("没有符合条件的对象!");
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.lgd)|*.lgd||";
            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                GSOLayer layer = globeControl1.Globe.Layers.Add(dlg.FileName);
                layer.AddFeatures(feats);
                layer.Visible = false;
                layer.Save();
            }
        }
        //删除
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double min = double.Parse(textBox1.Text);
                double max = double.Parse(textBox2.Text);
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    if (treeView1.Nodes[i].Checked)
                    {
                        GSOLayer layer = treeView1.Nodes[i].Tag as GSOLayer;
                        GSOFeatures fs = layer.GetAllFeatures();
                        for (int j = fs.Length-1; j >=0; j--)
                        {
                            GSOFeature f = fs[j];
                            double z = f.Geometry.GeoCenterPoint.Z;
                            if (z >= min && z <= max)
                            {
                                layer.RemoveAt(j);
                            }
                        }
                        
                    }
                }
               
            }
            catch (Exception exp)
            {
                exp.GetType();
            }
        }
      
    }
}
