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

namespace WorldGIS
{
    public partial class FrmMergeLayerLgdAndKml : Form
    {
        GSOGlobeControl mGlobeControl;

        public FrmMergeLayerLgdAndKml(GSOGlobeControl globeControl)
        {
            InitializeComponent();
            mGlobeControl = globeControl;
        }

        private void buttonSelectLgd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.lgd|*.lgd|*.kml|*.kml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxLgdPath.Text = dlg.FileName;
            }
        }

        private void buttonSelectKml_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.kml|*.kml|*.lgd|*.lgd";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxKmlPath.Text = dlg.FileName;
            }
        }

        private void buttonSavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.kml|*.kml|*.lgd|*.lgd||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxSavePath.Text = dlg.FileName;
            }
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            GSOLayer layerlgd = mGlobeControl.Globe.Layers.Add(textBoxLgdPath.Text.Trim());
            GSOLayer layerkml = mGlobeControl.Globe.Layers.Add(textBoxKmlPath.Text.Trim());
            GSOLayer newlayer = mGlobeControl.Globe.Layers.Add(textBoxSavePath.Text.Trim());
            if(layerlgd.GetAllFeatures().Length > 0)
            {
                GSOFeatures features = layerlgd.GetAllFeatures();
                for (int i = 0; i < features.Length; i++)
                {
                    GSOFeature feature = features[i];
                    newlayer = AddFeatureAndFeatureFolder(feature, newlayer);
                }
            }
            if (layerkml.GetAllFeatures().Length > 0)
            {
                GSOFeatures features = layerkml.GetAllFeatures();
                for (int i = 0; i < features.Length; i++)
                {
                    GSOFeature feature = features[i];
                    newlayer = AddFeatureAndFeatureFolder(feature, newlayer);
                }
            }
            if (newlayer.GetAllFeatures().Length > 0)
            {
                newlayer.SaveAs(textBoxSavePath.Text.Trim());
                MessageBox.Show("合并成功", "提示");
            }
            else 
            {
                MessageBox.Show("将要合并的图层不符合要求", "提示");
            }
            this.Close();
        }

        GSOLayer AddFeatureAndFeatureFolder(GSOFeature feature,GSOLayer newlayer)
        {
            if (feature != null && newlayer != null)
            {
                if (feature.Type == EnumFeatureType.Feature)
                {
                    newlayer.AddFeature(feature);
                }
                else
                {
                    GSOFeatureFolder folder = (GSOFeatureFolder)feature;
                    for (int i = 0; i < folder.Features.Length; i++)
                    {
                        newlayer = AddFeatureAndFeatureFolder(folder.Features[i], newlayer);
                    }
                }
            }
            return newlayer;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
