using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
using System.IO;
namespace WorldGIS
{
    public partial class FrmElevateLayer : Form
    {
        private GSOGlobeControl ctl;
        public FrmElevateLayer(GSOGlobeControl _ctl)
        {
            ctl = _ctl;
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void FrmElevateLayer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ctl.Globe.Layers.Count; i++)
            {
                GSOLayer layer = ctl.Globe.Layers[i];
                /*
                int idx=layer.Name.LastIndexOf(@"\");
                int idx1=layer.Name.LastIndexOf(".");
                string layerCaption = layer.Caption.Substring(idx+1,idx1-idx-1);
                */
                cmbLayers.Items.Add(layer.Caption);
            }

            radioButtonElevateAllFeature.Checked = true;
            panel1.Enabled = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            GSOLayer layer = ctl.Globe.Layers.GetLayerByCaption(cmbLayers.Text.Trim());
            if (layer == null)
            {
                MessageBox.Show("请选择图层", "提示");
                return;
            }
            if (layer.Type != EnumLayerType.FeatureLayer)
            {
                MessageBox.Show("当前选中的图层不是模型图层！", "提示");
                return;
            }
            GSOFeatureLayer flayer = layer as GSOFeatureLayer;
            GSOFeatures features = new GSOFeatures();
            if (radioButtonElevateAllFeature.Checked == true)
            {
                features = flayer.GetAllFeatures();
            }
            else if (radioButtonElevatePartFeature.Checked == true)
            {
                string fieldName = comboBoxFieldNames.Text.Trim();
                if (fieldName == "")
                {
                    MessageBox.Show("请选择字段名称！", "提示");
                    return;
                }
                if (listViewFieldValues.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选中一个字段值！", "提示");
                    return;
                }
                string fieldValue = listViewFieldValues.SelectedItems[0].Text.Trim();
                features = flayer.GetFeatureByFieldValue(fieldName, fieldValue,true);
            }

            string elevateHeight = txtHeight.Text.Trim();
            double height = 0;
            if (txtHeight.Text == "" || double.TryParse(elevateHeight, out height) == false)
            {
                MessageBox.Show("请输入正确的调整高度", "提示");
                return;
            }

            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                if (feature is GSOFeatureFolder)
                {
                    MoveEachFeature(feature as GSOFeatureFolder, height);
                }
                else if (feature.Geometry is GSOGeoModel)
                {
                    GSOGeoModel model = feature.Geometry as GSOGeoModel;
                    if (model != null)
                    {
                        GSOPoint3d pt = model.Position;
                        pt.Z += height;
                        model.Position = pt;
                    }
                }
                else if (feature.Geometry is GSOGeoPolyline3D)
                {
                    GSOGeoPolyline3D templine = feature.Geometry as GSOGeoPolyline3D;
                    if (templine != null)
                    {
                        templine.MoveZ(height);
                        feature.Geometry = templine;
                    }
                }
            }
            ctl.Refresh();
            MessageBox.Show("抬升成功", "提示");
        }

        private void MoveEachFeature(GSOFeatureFolder folder, double height)
        {
            GSOFeatures features = folder.Features;

            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                if (feature is GSOFeatureFolder)
                {
                    MoveEachFeature(feature as GSOFeatureFolder, height);
                }
                else
                {
                    GSOGeoModel model = feature.Geometry as GSOGeoModel;
                    if (model != null)
                    {
                        GSOPoint3d pt = model.Position;
                        if (model.AltitudeMode == EnumAltitudeMode.ClampToGround)
                        {
                            model.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        }
                        pt.Z += height;
                        model.Position = pt;
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //所有要素
        private void radioButtonElevateAllFeature_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonElevateAllFeature.Checked == true)
            {
                panel1.Enabled = false;
                radioButtonElevatePartFeature.Checked = false;
            }
            else
            {
                panel1.Enabled = true;
                radioButtonElevatePartFeature.Checked = true;
            }
        }

        private void radioButtonElevatePartFeature_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonElevatePartFeature.Checked == true)
            {
                string layerCaption = cmbLayers.Text.Trim();
                if (layerCaption == "")
                {
                    radioButtonElevateAllFeature.Checked = true;
                    MessageBox.Show("请先选择图层！", "提示");
                    return;
                }
                GSOLayer layer = ctl.Globe.Layers.GetLayerByCaption(layerCaption);
                if (layer == null)
                {
                    radioButtonElevateAllFeature.Checked = true;
                    MessageBox.Show("请先选择图层！", "提示");
                    return;
                }

                GSOFeatureLayer featureLayer = layer as GSOFeatureLayer;
                if (featureLayer == null)
                {
                    radioButtonElevateAllFeature.Checked = true;
                    MessageBox.Show("图层不是矢量图层！", "提示");
                    return;
                }
                if (featureLayer.GetAllFeatures().Length <= 0)
                {
                    radioButtonElevateAllFeature.Checked = true;
                    MessageBox.Show("图层中的要素个数为0个！", "提示");
                    return;
                }
                for (int i = 0; i < featureLayer.GetAllFeatures().Length; i++)
                {
                    GSOFeature feature = featureLayer.GetAt(i);
                    if (feature != null)
                    {
                        if (feature.GetFieldCount() <= 0)
                        {
                            radioButtonElevateAllFeature.Checked = true;
                            MessageBox.Show("图层中的字段个数为0个！", "提示");
                            return;
                        }
                        for (int j = 0; j < feature.GetFieldCount(); j++)
                        {
                            GSOFieldDefn field = (GSOFieldDefn)feature.GetFieldDefn(j);
                            if (field != null)
                            {
                                comboBoxFieldNames.Items.Add(field.Name);
                            }
                        }
                        break;
                    }
                }

                radioButtonElevateAllFeature.Checked = false;
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
                radioButtonElevateAllFeature.Checked = true;
            }
        }

        private void listViewFieldValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFieldValues.SelectedItems.Count > 0)
            {
                string fieldName = comboBoxFieldNames.Text.Trim();
                string fieldValue = listViewFieldValues.SelectedItems[0].Text.Trim();
                labelCurrentField.Text = "当前字段名：" + fieldName + "\r\n当前字段值：" + fieldValue;
            }
        }

        private void buttonGetFieldValue_Click(object sender, EventArgs e)
        {
            string fieldName = comboBoxFieldNames.Text.Trim();
            if (fieldName == "")
            {
                MessageBox.Show("请选择字段名称！", "提示");
                return;
            }
            GSOLayer layer = ctl.Globe.Layers.GetLayerByCaption(cmbLayers.Text.Trim());
            if (layer == null)
            {
                MessageBox.Show("请选择图层", "提示");
                return;
            }
            if (layer.Type != EnumLayerType.FeatureLayer)
            {
                MessageBox.Show("当前选中的图层不是模型图层！", "提示");
                return;
            }
            GSOFeatureLayer featureLayer = layer as GSOFeatureLayer;
            List<string> listValues = new List<string>();
            for (int i = 0; i < featureLayer.GetAllFeatures().Length; i++)
            {
                GSOFeature feature = featureLayer.GetAt(i);
                if (feature != null)
                {
                    object value = feature.GetValue(fieldName);
                    if (value == null || value.ToString() == "")
                    {
                        continue;
                    }
                    if (listValues.Contains(value.ToString()) == false)
                    {
                        listValues.Add(value.ToString());
                    }
                }
            }
            listViewFieldValues.Items.Clear();
            if (listValues.Count <= 0)
            {
                MessageBox.Show("没有找到不为空的字段值！","提示");
                return;
            }
            for (int i = 0; i < listValues.Count; i++)
            {
                listViewFieldValues.Items.Add(listValues[i]);
            }            
        }
    }
}
