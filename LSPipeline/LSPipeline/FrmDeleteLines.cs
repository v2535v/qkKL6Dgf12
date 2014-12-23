using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;
using System.IO;

namespace WorldGIS
{
    public partial class FrmDeleteLines : Form
    {
        GSOGlobeControl globeControl1 = null;
        public FrmDeleteLines(GSOGlobeControl _globeControl)
        {
            InitializeComponent();
            globeControl1 = _globeControl;
        }

        private void FrmDeleteLines_Load(object sender, EventArgs e)
        {
            panelFeatureCount.Enabled = false;
        }

        private void buttonLayerPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = ".lgd|*.lgd| .kml|*.kml";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxLayerPath.Text = dlg.FileName;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string layerPath = textBoxLayerPath.Text.Trim();
            if (layerPath == "")
            {
                MessageBox.Show("请选择目标文件！","提示");
                return;
            }
            string featureMinLength = textBoxFeatureMinLength.Text.Trim();
            double minLength = 0;
            if (!double.TryParse(featureMinLength, out minLength))
            {
                MessageBox.Show("请输入正确的最小长度值！", "提示");
                return;
            }
            string featureMaxLength = textBoxFeatureMaxLength.Text.Trim();           
            double maxLength = 0;
            if (!double.TryParse(featureMaxLength, out maxLength))
            {
                MessageBox.Show("请输入正确的最大长度值！", "提示");
                return;
            }
            string featureCount = textBoxFeatureCount.Text.Trim();
            int count = 0;
            if (checkBoxFeatureCount.Checked)
            {                
                if (!int.TryParse(featureCount, out count))
                {
                    MessageBox.Show("请输入正确的要素个数值！", "提示");
                    return;
                }
            }

            GSOLayer layer = globeControl1.Globe.Layers.Add(layerPath);
            if (layer != null)
            {
                do
                {
                    for (int i = layer.GetAllFeatures().Length -1; i >= 0; i--)
                    {
                        GSOFeature feature = layer.GetAt(i);
                        if (feature != null && feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                        {
                            GSOGeoPolyline3D line = feature.Geometry as GSOGeoPolyline3D;
                            double length = line.GetSpaceLength(false, 6378137.0);
                            if (length >= minLength && length <= maxLength)
                            {
                                feature.Delete();
                            }
                        }
                        //else
                        //{
                        //    feature.Delete();
                        //}
                    }                                      
                    maxLength++;
                } 
                while (checkBoxFeatureCount.Checked && layer.GetAllFeatures().Length > 30000);
                layer.SaveAs(Path.GetDirectoryName(textBoxLayerPath.Text.Trim()) + "/" + layer.Caption + "-处理后" + Path.GetExtension(textBoxLayerPath.Text.Trim()));
                MessageBox.Show("删除成功！","提示");
            }
        }

        private void checkBoxFeatureCount_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFeatureCount.Checked)
            {
                panelFeatureCount.Enabled = true;
            }
            else
            {
                panelFeatureCount.Enabled = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
