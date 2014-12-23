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

namespace WorldGIS
{
    public partial class FrmParticalExportLayer : Form
    {
        GSOGlobeControl mGlobeControl;
        List<GSOGeoPolygon3D> mListPolygon = new List<GSOGeoPolygon3D>();

        public FrmParticalExportLayer(GSOGlobeControl globeControl1, List<GSOGeoPolygon3D> listPolygon)
        {
            InitializeComponent();
            mGlobeControl = globeControl1;
            mListPolygon = listPolygon;
        }

        private void FrmParticalExportLayer_Load(object sender, EventArgs e)
        {
            GSOLayers layers = mGlobeControl.Globe.Layers;
            if (layers.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < layers.Count; i++)
            {
                GSOLayer layer = layers[i];
                if (layer.Type == EnumLayerType.FeatureLayer)
                {
                    comboBoxLayerName.Items.Add(layers[i].Caption);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.lgd|*.lgd|*.kml|*.kml||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textbox1.Text = dlg.FileName;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string filename = textbox1.Text.Trim();
            GSOLayer newlayer =  mGlobeControl.Globe.Layers.Add(filename);
            
            int indexCount = filename.LastIndexOf('.') - filename.LastIndexOf('\\') - 1;
            string newlayerCaption = "";
            if (indexCount > 0)
            {
                newlayerCaption = filename.Substring(filename.LastIndexOf('\\') + 1, indexCount);
                newlayer.Caption = newlayerCaption;
                
            }
            
            for (int i = 0; i < mListPolygon.Count; i++)
            {
                GSOGeoPolygon3D polygon = mListPolygon[i];
                string caption = "";
                if (comboBoxLayerName.SelectedIndex >= 0)
                {
                    caption = comboBoxLayerName.SelectedItem.ToString().Trim();
                }
                GSOLayer layer = mGlobeControl.Globe.Layers.GetLayerByCaption(caption);
                GSOFeatures feats = new GSOFeatures();
                if (layer != null)
                {
                    feats = layer.FindFeaturesInPolygon(polygon, false);
                }
                if (feats != null)
                {
                    newlayer.AddFeatures(feats);
                }
            }
            if (newlayer != null)
            {
                newlayer.SaveAs(filename);
                MessageBox.Show("导出成功！","提示");
            }
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
