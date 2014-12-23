using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Globe;
using GeoScene.Engine;

namespace WorldGIS
{
    public partial class FrmPipelineIndented : Form
    {
        GSOGlobeControl globeControl1 = null;
        GSOLayer layerInit = null;
        GSOFeatures featuresInit = null;
        GSOFeatures featuresIndented = null;

        public FrmPipelineIndented(GSOGlobeControl _globeControl)
        {
            InitializeComponent();

            globeControl1 = _globeControl;            
        }

        private void FrmPipelineIndented_Load(object sender, EventArgs e)
        {
            if (globeControl1 != null)
            {
                for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
                {
                    GSOLayer layer = globeControl1.Globe.Layers[i];
                    if (layer != null && layer.Type == EnumLayerType.FeatureLayer)
                    {
                        comboBoxLayerCaption.Items.Add(layer.Caption);
                        comboBoxLayerValveCaption.Items.Add(layer.Caption);
                    }
                }
            }
            featuresIndented = new GSOFeatures();
            featuresInit = new GSOFeatures();
        }

       
        //应用
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (comboBoxLayerCaption.SelectedItem == null)
            {
                MessageBox.Show("请选择一个管线图层！", "提示");
                return;
            }
            if (comboBoxLayerValveCaption.SelectedItem == null)
            {
                MessageBox.Show("请选择一个工井图层！", "提示");
                return;
            }
            if (textBoxValueIndented.Text.Trim() == "")
            {
                MessageBox.Show("请输入缩进距离！", "提示");
                return;
            }
            if (textBoxAllowance.Text.Trim() == "")
            {
                MessageBox.Show("请输入容限值！", "提示");
                return;
            }

            double valueAllowance = 0.0;
            if (double.TryParse(textBoxAllowance.Text.Trim(), out valueAllowance) == false)
            {
                MessageBox.Show("请输入一个正确的容限值！", "提示");
                return;
            }

            float valueIndented = 0.0f;
            if (float.TryParse(textBoxValueIndented.Text.Trim(), out valueIndented) == false)
            {
                MessageBox.Show("请输入一个正确的缩进值！", "提示");
                return;
            }

            string layerCaption = comboBoxLayerCaption.SelectedItem.ToString().Trim();
            string valveLayerCaption = comboBoxLayerValveCaption.SelectedItem.ToString().Trim();
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(layerCaption);
            GSOLayer valveLayer = globeControl1.Globe.Layers.GetLayerByCaption(valveLayerCaption);
            if (layer != null && valveLayerCaption != null)
            {
                featuresIndented.RemoveAll();               
                cancelHighLight(layer.GetAllFeatures());
                
                
                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature feature = layer.GetAt(i);
                    if (feature != null && feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                    {
                        GSOGeoPolyline3D line = feature.Geometry as GSOGeoPolyline3D;
                        double lineLenght = line.GetSpaceLength(false, 6378137.0);
                        if (lineLenght <= valueIndented * 2)
                        {
                            continue;
                        }

                        featuresIndented.Add(feature);//缩进的管线集合
                        featuresInit.Add(feature.Clone());

                        //头缩进
                        GSOPoint3d headPoint = line[0][0];
                        GSOGeoPolyline3D newline = new GSOGeoPolyline3D();
                        GSOPoint3ds part = new GSOPoint3ds();
                        part.Add(headPoint);
                        headPoint.X = headPoint.X - 0.0000000005;
                        part.Add(headPoint);
                        newline.AddPart(part);
                        GSOGeoPolygon3D buffer = newline.CreateBuffer(valueAllowance, true, 5, true, false);
                        GSOFeatures features = valveLayer.FindFeaturesInPolygon(buffer, false);
                        if (features.Length > 0)
                        {
                            feature.HighLight = true;
                            if (line.Style != null && line.Style is GSOPipeLineStyle3D)
                            {
                                GSOPipeLineStyle3D style = line.Style as GSOPipeLineStyle3D;
                                style.HeadJointParam = new GSOPipeJointParam();
                                style.HeadJointParam.Extent = -valueIndented;
                            }
                        }

                        //尾缩进
                        GSOPoint3d tailPoint = line[line.PartCount - 1][line[line.PartCount - 1].Count - 1];
                        newline = new GSOGeoPolyline3D();
                        part = new GSOPoint3ds();
                        part.Add(tailPoint);
                        tailPoint.X = tailPoint.X - 0.0000000005;
                        part.Add(tailPoint);
                        newline.AddPart(part);
                        buffer = newline.CreateBuffer(valueAllowance, true, 5, true, false);
                        features = valveLayer.FindFeaturesInPolygon(buffer, false);
                        if (features.Length > 0)
                        {
                            feature.HighLight = true;
                            if (line.Style != null && line.Style is GSOPipeLineStyle3D)
                            {
                                GSOPipeLineStyle3D style = line.Style as GSOPipeLineStyle3D;
                                style.TailJointParam = new GSOPipeJointParam();
                                style.TailJointParam.Extent = -valueIndented;
                            }
                        }
                    }
                }
            }
            globeControl1.Globe.Refresh();
        }

        //取消高亮
        private void buttonCancelHighLight_Click(object sender, EventArgs e)
        {
            if (featuresIndented != null && featuresIndented.Length > 0)
            {
                cancelHighLight(featuresIndented);
            }
        }

        //取消
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelHighLight(GSOFeatures features)
        {
            if (features != null)
            {
                for (int i = 0; i < features.Length; i++)
                {
                    GSOFeature feature = features[i];
                    if (feature != null)
                    {
                        feature.HighLight = false;
                    }
                }
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
            }
        }

        private void FrmPipelineIndented_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonCancelHighLight_Click(sender, e);
        }
    }
}
