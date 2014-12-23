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
    public partial class FrmBacthUpdateModelPath : Form
    {
        GSOGlobeControl globeControl1 = null;
        GSODataSource ds = null;

        public FrmBacthUpdateModelPath(GSOGlobeControl _globeControl1)
        {
            InitializeComponent();

            globeControl1 = _globeControl1;           
        }

        private void FrmPacthUpdateModelPath_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (layer != null && layer is GSOFeatureLayer)
                {
                    listBoxLayerNames.Items.Add(layer.Caption);
                }
            }
        }

        private void buttonModelPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.3ds|*.3ds|*.gcm|*.gcm";
            dlg.InitialDirectory = Application.StartupPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxModelPath.Text = dlg.FileName;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listBoxLayerNames.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选中要修改图层的名称！","提示");
                return;
            }
            string modelPath = textBoxModelPath.Text.Trim();
            if (modelPath == "")
            {
                MessageBox.Show("请选择一个模型！", "提示");
                return;
            }
            for (int i = 0; i < listBoxLayerNames.SelectedItems.Count; i++)
            {
                string layerName = listBoxLayerNames.SelectedItems[i].ToString().Trim();
                GSOLayer  layer = globeControl1.Globe.Layers.GetLayerByCaption(layerName);
                if (layer != null && layer is GSOFeatureLayer)
                {
                    for (int j = 0; j < layer.GetAllFeatures().Length; j++)
                    {
                        GSOFeature feature = layer.GetAt(j);
                        if (feature != null && feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoModel)
                        {
                            GSOGeoModel model = feature.Geometry as GSOGeoModel;
                            GSOGeoModel modelnew = new GSOGeoModel();
                            modelnew.FilePath = modelPath;
                            modelnew.Position = model.Position;
                            
                            feature.Geometry = modelnew;
                        }
                    }
                    layer.Save();
                }
            }
            globeControl1.Globe.Refresh();
            MessageBox.Show("修改成功！","提示");
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //重新设置item高度
        private void listBoxLayerNames_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            PointF point = new PointF();
            point.X = e.Bounds.X;
            point.Y = e.Bounds.Y + (listBoxLayerNames.ItemHeight - e.Font.Height) / 2;
            e.Graphics.DrawString(listBoxLayerNames.Items[e.Index].ToString().Trim(), e.Font, new SolidBrush(Color.Black), point);
        }
    }
}
