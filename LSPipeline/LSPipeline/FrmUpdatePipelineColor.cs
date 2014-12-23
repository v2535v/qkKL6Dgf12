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
    public partial class FrmUpdatePipelineColor : Form
    {
        GSOGlobeControl m_globeControl = null;

        public FrmUpdatePipelineColor(GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_globeControl = globeControl;
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string caption = comboBoxLayerNames.Text;
            if (caption == "")
            {
                return;
            }
            GSOLayer layer = m_globeControl.Globe.Layers.GetLayerByCaption(caption);
            GSOFeatures features = layer.GetAllFeatures();
            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                GSOGeoPolyline3D line = feature.Geometry as GSOGeoPolyline3D;
                if (line == null)
                {
                    continue;
                }
                GSOPipeLineStyle3D pipeLineStyle = line.Style as GSOPipeLineStyle3D;

                int mode = 0;
                // 管线暂不支持依地模式
                if (line.AltitudeMode == EnumAltitudeMode.ClampToGround)
                {
                    mode = 1;
                    line.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                }
                if (pipeLineStyle == null)
                {
                    pipeLineStyle = new GSOPipeLineStyle3D();
                }

                pipeLineStyle.LineColor = buttonPipelineColor.BackColor;
                line.Style = pipeLineStyle;
                if (mode == 1)
                {
                    line.AltitudeMode = EnumAltitudeMode.ClampToGround;
                }               

            }
            m_globeControl.Refresh();
            this.Close();
        }

        //加载所有图层
        private void FrmUpdatePipelineColor_Load(object sender, EventArgs e)
        {
            if (m_globeControl != null)
            {
                GSOLayers layers = m_globeControl.Globe.Layers;
                for (int i = 0; i < layers.Count; i++)
                {
                    GSOLayer layer = layers[i];
                    comboBoxLayerNames.Items.Add(layer.Caption);                       
                }
                comboBoxLayerNames.SelectedIndex = 0;
            }
        }

        private void comboBoxLayerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string caption = comboBoxLayerNames.Text;
            //if (caption != "")
            //{
            //    GSOLayer layer = m_globeControl.Globe.Layers.GetLayerByCaption(caption);

            //}
        }

        private void buttonPipelineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = buttonPipelineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                buttonPipelineColor.BackColor = dlg.Color;
            }
        }
    }
}
