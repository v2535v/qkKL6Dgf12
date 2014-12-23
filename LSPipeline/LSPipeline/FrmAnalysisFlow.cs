using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using DevComponents.DotNetBar;
using GeoScene.Data;

namespace WorldGIS
{
    public partial class FrmAnalysisFlow : Form
    {
        private GSOGlobeControl globeControl;
        private GSOLayer layer;
        public FrmAnalysisFlow(GSOGlobeControl ctl)
        {
            InitializeComponent();
            globeControl = ctl;
        }

        private void FrmFlow_Load(object sender, EventArgs e)
        {
            cboxLayer.Items.Clear();
            for (int i = 0; i < globeControl.Globe.Layers.Count; i++)
            {
                GSOLayer layer = globeControl.Globe.Layers[i];
                cboxLayer.Items.Add(layer.Caption);
            }
        }

        private void Flow(object sender, string pipelineNameCN)//流向
        {
            //if (checkBox1.Checked == true)
            //{
                GSOFeatures feats = layer.GetAllFeatures();
                if (feats.Length == 0)
                    return;
                for (int i = 0; i < feats.Length; i++)
                {
                    GSOFeature feat = feats[i];
                    GSOLineStyle3D lineStyle = feat.Geometry.Style as GSOLineStyle3D;
                    if (lineStyle != null)
                    {
                        if (lineStyle.ArrowStyle == null)
                        {
                            lineStyle.ArrowStyle = new GSOArrowStyle();
                            lineStyle.ArrowStyle.BodyWidth = 2;
                            lineStyle.ArrowStyle.BodyLen = 6;
                            lineStyle.ArrowStyle.HeadWidth = 8;
                            lineStyle.ArrowStyle.HeadLen = 10;
                            lineStyle.ArrowStyle.OutlineVisible = true;
                            lineStyle.ArrowStyle.OutlineColor = Color.Red;
                            lineStyle.ArrowStyle.Speed = lineStyle.ArrowStyle.Speed / 2;
                            lineStyle.ArrowStyle.Play();
                        }
                        lineStyle.ArrowVisible = checkBox1.Checked;
                        
                        feat.Geometry.SetModified(true);

                    }
                }
            //}
            globeControl.Globe.Refresh();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (cboxLayer.SelectedItem == null)
            {
                MessageBox.Show("请选择一个图层！","提示");
                return;
            }
            Flow(sender, cboxLayer.SelectedItem.ToString());
            this.Close();
        }

        private void cboxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer = globeControl.Globe.Layers[cboxLayer.SelectedIndex];
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
