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
    public partial class FrmBatchUpadateColor : Form
    {
        GSOGlobeControl mGlobeControl = null;
        public FrmBatchUpadateColor(GeoScene.Globe.GSOGlobeControl globeControl)
        {
            InitializeComponent();
            mGlobeControl = globeControl;
        }

        private void FrmBatchUpadateColor_Load(object sender, EventArgs e)
        {
            panelPoints.Enabled = false;
            panelLines.Enabled = false;
            panelPolygons.Enabled = false;

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
                    comboBoxLayers_TextChanged(sender, e);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
           
            string iconPath = textBoxIconPath.Text.Trim();
            if (iconPath == "")
            {
                iconPath = Application.StartupPath + "\\Resource\\DefaultIcon.png";
            }

            Color lineColor = textBoxLineColor.BackColor;
            string strLineWidth = textBoxLineWidth.Text.Trim();
            double lineWidth = 1;
            bool blIsLineWidth = double.TryParse(strLineWidth, out lineWidth);

            Color outlineColor = textBoxOutlineColor.BackColor;
            string strOutlineWidth = textBoxOutlineWidth.Text.Trim();
            double outlineWidth = 1;
            bool blIsOutlineWidth = double.TryParse(strOutlineWidth, out outlineWidth);
            Color polygonColor = textBoxPolygonColor.BackColor;
            string strPolygonAlpha = textBoxPolygonAlpha.Text.Trim();
            int polygonAlpha = 255;
            bool blIsPolygonAlpha = int.TryParse(strPolygonAlpha, out polygonAlpha);
            polygonColor = Color.FromArgb(polygonAlpha, polygonColor);
            
            for (int i = 0; i < layer.GetAllFeatures().Length; i++)
            {
                GSOFeature feature = layer.GetAt(i);
                if (feature.Geometry != null)
                { 
                    switch(feature.Geometry.Type)
                    {
                        case EnumGeometryType.GeoPoint3D:
                            if (panelPoints.Enabled)
                            {
                                GSOGeoPoint3D point = (GSOGeoPoint3D)feature.Geometry;
                                GSOGeoMarker marker = new GSOGeoMarker();
                                marker.Position = point.Position;
                                marker.Name = point.Name;
                                marker.CameraState = point.CameraState;
                                marker.Label = point.Label;

                                GSOFeature newFeature = new GSOFeature();
                                newFeature.Name = feature.Name;
                                newFeature.Geometry = marker;

                                layer.RemoveAt(i);
                                layer.AddFeature(newFeature);
                                i--;
                            }
                            break;
                        case EnumGeometryType.GeoMarker:
                            if (panelPoints.Enabled)
                            {
                                GSOGeoMarker marker = (GSOGeoMarker)feature.Geometry;
                                GSOMarkerStyle3D style = null;

                                if (marker.Style == null)
                                {
                                    style = new GSOMarkerStyle3D();
                                }
                                else
                                {
                                    style = (GSOMarkerStyle3D)marker.Style;
                                }

                                style.TextVisible = !checkBoxHideLabelOfMarker.Checked;
                                style.IconPath = iconPath.Trim();                                    
                                
                                marker.Style = style;
                            }
                            break;
                        case EnumGeometryType.GeoPolyline3D:
                            if (panelLines.Enabled)
                            {
                                GSOGeoPolyline3D line = (GSOGeoPolyline3D)feature.Geometry;
                                if (line.Label != null)
                                {
                                    line.Label.Visible = !checkBoxHideLabelOfLine.Checked;
                                }
                                if (line.Style == null)
                                {
                                    GSOSimpleLineStyle3D styleLine = new GSOSimpleLineStyle3D();
                                    styleLine.LineColor = lineColor;
                                    styleLine.LineWidth = lineWidth;                                    
                                    line.Style = styleLine;
                                }
                                else
                                {
                                    GSOSimpleLineStyle3D styleLine = (GSOSimpleLineStyle3D)line.Style;
                                    if (styleLine == null)
                                    {
                                        GSOPipeLineStyle3D pipeStyle = (GSOPipeLineStyle3D)line.Style;
                                        if (pipeStyle != null)
                                        {
                                            pipeStyle.LineColor = lineColor;
                                            pipeStyle.Radius = lineWidth / 2;
                                            line.Style = pipeStyle;
                                        }
                                    }
                                    else
                                    {
                                        styleLine.LineColor = lineColor;
                                        styleLine.LineWidth = lineWidth;
                                        line.Style = styleLine;
                                    }
                                }
                            }
                            break;
                        case EnumGeometryType.GeoPolygon3D:
                            if (panelPolygons.Enabled)
                            {
                                GSOGeoPolygon3D polygon = (GSOGeoPolygon3D)feature.Geometry;
                                if (polygon.Label != null)
                                {
                                    polygon.Label.Visible = !checkBoxHideLabelOfPolygon.Checked; 
                                }
                                GSOSimplePolygonStyle3D stylePolygon = (polygon.Style == null ? new GSOSimplePolygonStyle3D() : (GSOSimplePolygonStyle3D)polygon.Style);
                                stylePolygon.FillColor = polygonColor;
                                stylePolygon.OutLineVisible = true;
                                GSOSimpleLineStyle3D styleOutline = (GSOSimpleLineStyle3D)stylePolygon.OutlineStyle;
                                if (styleOutline == null)
                                {
                                    styleOutline = new GSOSimpleLineStyle3D();
                                }
                                styleOutline.LineWidth = outlineWidth;
                                styleOutline.LineColor = outlineColor;
                                stylePolygon.OutlineStyle = styleOutline;
                                polygon.Style = stylePolygon;
                            }
                            break;

                    }                
                }               
            }
            mGlobeControl.Globe.Refresh();
            this.Close();
        }


        //点对象图标路径
        private void buttonIconPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBoxIconPath.Text = file.FileName.Trim();
            }
        }

        //线对象的颜色
        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                textBoxLineColor.BackColor = color.Color;
            }
        }


        //面对象边框线的颜色
        private void buttonOutlineColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                textBoxOutlineColor.BackColor = color.Color;
            }
        }
        //面对象的颜色
        private void buttonPolygonColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                textBoxPolygonColor.BackColor = color.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxPoints_CheckedChanged(object sender, EventArgs e)
        {
            panelPoints.Enabled = checkBoxPoints.Checked;
        }

        private void checkBoxLines_CheckedChanged(object sender, EventArgs e)
        {
            panelLines.Enabled = checkBoxLines.Checked;
        }

        private void checkBoxPolygons_CheckedChanged(object sender, EventArgs e)
        {
            panelPolygons.Enabled = checkBoxPolygons.Checked;
        }

        private void checkBoxClearAllIcon_CheckedChanged(object sender, EventArgs e)
        {
            //textBoxIconPath.Enabled = buttonIconPath.Enabled = !checkBoxHideAllIconText.Checked;
        }

        private void comboBoxLayers_TextChanged(object sender, EventArgs e)
        {
            string layerName = comboBoxLayers.Text;
            if (layerName.Trim().Equals(""))
            {
                return;
            }
            GSOLayer layer = mGlobeControl.Globe.Layers.GetLayerByCaption(layerName);
            if (layer == null)
            {
                return;
            }
            //清空上一个图层的style
            textBoxIconPath.Text = "";

            textBoxLineColor.BackColor = this.BackColor;
            textBoxLineWidth.Text = "";

            textBoxOutlineColor.BackColor = this.BackColor;
            textBoxPolygonColor.BackColor = this.BackColor;
            textBoxOutlineWidth.Text = "";
            textBoxPolygonAlpha.Text = "";

            bool markerExists = false;
            bool lineExists = false;
            bool polygonExists = false;
            GSOFeatures features = GetAllRealFeatures(layer);
            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];                
                if(feature == null)
                {
                    continue;
                }

                if (feature.Geometry != null)
                {
                    switch (feature.Geometry.Type)
                    {
                        case EnumGeometryType.GeoMarker:
                            if (!markerExists)
                            {
                                GSOGeoMarker marker = (GSOGeoMarker)feature.Geometry;

                                GSOMarkerStyle3D style = (GSOMarkerStyle3D)marker.Style;
                                if (style != null)
                                {
                                    textBoxIconPath.Text = style.IconPath;
                                    checkBoxHideLabelOfMarker.Checked = !style.TextVisible;                                   
                                    markerExists = true;
                                }
                            }
                            break;
                        case EnumGeometryType.GeoPolyline3D:
                            if (!lineExists)
                            {
                                GSOGeoPolyline3D line = (GSOGeoPolyline3D)feature.Geometry;
                                if (line.Label != null)
                                {
                                    checkBoxHideLabelOfPolygon.Checked = !line.Label.Visible;
                                }
                                if (line.Style != null)
                                {
                                    GSOSimpleLineStyle3D simpleLineStyle = (GSOSimpleLineStyle3D)line.Style;
                                    if (simpleLineStyle != null)
                                    {
                                        textBoxLineColor.BackColor = simpleLineStyle.LineColor;
                                        textBoxLineWidth.Text = (simpleLineStyle.LineWidth == 0 ? "1".ToString() : simpleLineStyle.LineWidth.ToString());
                                        lineExists = true;
                                    }
                                    else
                                    {
                                        GSOPipeLineStyle3D pipeLineStyle = (GSOPipeLineStyle3D)line.Style;
                                        if (pipeLineStyle != null)
                                        {
                                            textBoxLineColor.BackColor = pipeLineStyle.LineColor;
                                            textBoxLineWidth.Text = (pipeLineStyle.Radius * 2).ToString();
                                            lineExists = true;
                                        }
                                    }
                                }
                            }
                            break;
                        case EnumGeometryType.GeoPolygon3D:
                            if (!polygonExists)
                            {
                                GSOGeoPolygon3D polygon = (GSOGeoPolygon3D)feature.Geometry;
                                if (polygon.Label != null)
                                {
                                    checkBoxHideLabelOfLine.Checked = !polygon.Label.Visible;
                                }
                                GSOSimplePolygonStyle3D stylePolygon = (GSOSimplePolygonStyle3D)polygon.Style;
                                
                                if (stylePolygon != null)
                                {
                                    textBoxPolygonColor.BackColor = Color.FromArgb(stylePolygon.FillColor.R, stylePolygon.FillColor.G, stylePolygon.FillColor.B);
                                    textBoxPolygonAlpha.Text = stylePolygon.FillColor.A.ToString();
                                    GSOSimpleLineStyle3D styleOutline = (GSOSimpleLineStyle3D)stylePolygon.OutlineStyle;
                                    if (styleOutline != null)
                                    {
                                        textBoxOutlineColor.BackColor = styleOutline.LineColor;
                                        textBoxOutlineWidth.Text = (styleOutline.LineWidth == 0 ? "1".ToString() : styleOutline.LineWidth.ToString());
                                    }
                                    polygonExists = true;
                                }
                            }
                            break;

                    }
                }    
                
            }
        }

        GSOFeatures GetAllRealFeatures(GSOLayer layer)
        {
            if (layer == null)
            {
                return null;
            }
            GSOFeatures realfeatures = new GSOFeatures();
            for (int i = 0; i < layer.GetAllFeatures().Length; i++)
            {
                GSOFeature feature = layer.GetAllFeatures()[i];
                GetRealFeature(feature, realfeatures);
            }
            return realfeatures;
        }
       
        void GetRealFeature(GSOFeature feature, GSOFeatures realfeatures)
        {
            if (feature == null || realfeatures == null)
            {
                return;
            }
            if (feature.Type == EnumFeatureType.Feature)
            {
                realfeatures.Add(feature);
            }
            else if (feature.Type == EnumFeatureType.FeatureFolder)
            {
                GSOFeatureFolder featureFolder = (GSOFeatureFolder)feature;
                for (int i = 0; i < featureFolder.Features.Length; i++)
                {
                    GetRealFeature(featureFolder.Features[i],realfeatures);
                }
            } 
        }

        private void checkBoxHideLabelOfLine_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
