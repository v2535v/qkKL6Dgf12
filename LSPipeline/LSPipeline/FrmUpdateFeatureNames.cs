using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Engine;
using GeoScene.Data;

namespace WorldGIS
{
    public partial class FrmUpdateFeatureNames : Form
    {
        GSOGlobeControl mGlobeControl;


        public FrmUpdateFeatureNames(GSOGlobeControl globeControl)
        {
            InitializeComponent();
            mGlobeControl = globeControl;
        }

       
        private void FrmUpdateFeatureNames_Load(object sender, EventArgs e)
        {
            GSOLayers layers = mGlobeControl.Globe.Layers;
            if(layers.Count > 0)
            {
                for (int i = 0; i < layers.Count; i++)
                {
                    comboBox1.Items.Add(layers[i].Caption);
                }
            }
        }
        GSOLayer layer;
        GSOFeatures features;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = comboBox1.SelectedIndex;
            if (selectIndex >= 0)
            {
                layer = mGlobeControl.Globe.Layers.GetLayerByCaption(comboBox1.SelectedItem.ToString());
                if (layer != null)
                {
                    features = layer.GetAllFeatures();
                    if (features.Length > 0)
                    {
                        GSOFeature feature = features[0];
                        if (feature.GetFieldCount() > 0)
                        {
                            for (int i = 0; i < feature.GetFieldCount(); i++)
                            {
                                GSOFieldDefn defn = (GSOFieldDefn)feature.GetFieldDefn(i);
                                listBox1.Items.Add(defn.Name);
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectIndex = listBox1.SelectedIndex;
            if (selectIndex >= 0)
            {
                string name = listBox1.SelectedItem.ToString();
                if (features != null)
                {
                    if (features.Length > 0)
                    {
                        for (int i = 0; i < features.Length; i++)
                        {
                            GSOFeature feature = features[i];
                            feature.Name = feature.GetValue(name.Trim()).ToString();
                        }
                        this.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (features != null)
            {
                if (features.Length > 0)
                {
                    for (int i = 0; i < features.Length; i++)
                    {
                        GSOFeature feature = features[i];
                        feature.SetFieldValue("编号", feature.Name);
                    }
                    this.Close();
                }
            }
        }
    }
}
