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
using WorldGIS.Forms;


namespace WorldGIS
{
    public partial class FrmBatchUpadateFontOfMarkers : Form
    {
        GSOGlobeControl mGlobeControl = null;
        public FrmBatchUpadateFontOfMarkers(GeoScene.Globe.GSOGlobeControl globeControl)
        {
            InitializeComponent();
            mGlobeControl = globeControl;
        }

        private void FrmBatchUpadateFontOfMarkers_Load(object sender, EventArgs e)
        {
            if (mGlobeControl != null)
            {
                GSOLayers layers = mGlobeControl.Globe.Layers;
                if (layers.Count > 0)
                {
                    for (int i = 0; i < layers.Count; i++)
                    {
                        GSOLayer layer = layers[i];
                        comboBoxLayers.Items.Add(layer.Caption);
                    }
                    GSOLayer destLayer = mGlobeControl.Globe.DestLayerFeatureAdd;
                    comboBoxLayers.Text = (destLayer.Type == EnumLayerType.MemoryLayer ? layers[0].Caption : destLayer.Caption);
                }
            }

            textBoxFontColor.BackColor = Color.White;            
            comboBoxFontSize.SelectedIndex = 2;           
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(comboBoxLayers.Text == "")
            {
                MessageBox.Show("请选择一个图层！");
                return;
            }
            GSOLayer layer = mGlobeControl.Globe.Layers.GetLayerByCaption(comboBoxLayers.Text.Trim());
            if (layer == null)
            {
                MessageBox.Show("您选择的图层不存在！");
                return;
            }
           
            Color fontColor = textBoxFontColor.BackColor;

            string strFontSize = comboBoxFontSize.Text;
            double fontSize = 12;
            bool blIsFontSize = double.TryParse(strFontSize, out fontSize);

            GSOFeatures features = layer.GetAllFeatures();
            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                if (feature.Geometry != null)
                { 
                    switch(feature.Geometry.Type)
                    {
                        case EnumGeometryType.GeoMarker:

                            GSOGeoMarker marker = (GSOGeoMarker)feature.Geometry;
                            GSOMarkerStyle3D style = (marker.Style == null ? new GSOMarkerStyle3D() : (GSOMarkerStyle3D)marker.Style);
                            GSOTextStyle textStyle = (style.TextStyle == null ? new GSOTextStyle() : style.TextStyle);
                            
                            textStyle.ForeColor = fontColor;
                            textStyle.FontSize = fontSize;
                            
                            style.TextStyle = textStyle;
                            marker.Style = style;

                            break;
                    }
                
                }
                mGlobeControl.Globe.Refresh();                
            }
            //layer.Save();
            this.Close();
        }

        //字体颜色
        private void buttonFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = textBoxFontColor.BackColor;
            if (color.ShowDialog() == DialogResult.OK)
            {
                textBoxFontColor.BackColor = color.Color;
            }
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
