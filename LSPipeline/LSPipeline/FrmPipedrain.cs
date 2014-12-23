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
using System.IO;

namespace WorldGIS
{
    public partial class FrmPipedrain : Form
    {
        private GeoScene.Globe.GSOGlobeControl ctl;
        public FrmPipedrain(GSOGlobeControl _ctl)
        {
            ctl = _ctl;
            InitializeComponent();
        }

        private void btnBrowseModel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.lgd|*.lgd";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtModelLayer.Text = saveFileDialog1.FileName;
            }
        }

        private void FrmPipelineModel_Load(object sender, EventArgs e)
        {
            cmbLayer.Items.Clear();
            for (int i = 0; i < ctl.Globe.Layers.Count; i++)
            {
                GSOLayer layer = ctl.Globe.Layers[i];
                cmbLayer.Items.Add(layer.Caption);
            }
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOLayer layer = ctl.Globe.Layers[cmbLayer.SelectedIndex];
            GSOFeatures features = layer.GetAllFeatures();
            if(features.Length==0)
                return;

            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();
            cmbRadius.Items.Clear();
            cmbID.Items.Clear();
            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                cmbFrom.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbTo.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbRadius.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbID.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
            }
        }

        public string lgdFilePath = "";
        private void btnPipelineColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = btnPipelineColor.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnPipelineColor.BackColor = colorDialog1.Color;
            }
        }


        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtModelLayer.Text))
                {
                    MessageBox.Show("管沟模型文件路径无效！", "提示");
                    return;
                }
                if (File.Exists(txtModelLayer.Text))
                {
                    MessageBox.Show("管沟模型文件已存在！", "提示");
                    return;
                }

                GSOLayer sourceLayer = ctl.Globe.Layers[cmbLayer.SelectedIndex];

                GSOLayer layer = ctl.Globe.Layers.Add(txtModelLayer.Text);
                lgdFilePath = txtModelLayer.Text;
                if (layer != null)
                {
                    GSOFeatures features = sourceLayer.GetAllFeatures();

                    for (int j = 0; j < features.Length; j++)
                    {
                        GSOFeature f = features[j];

                        GSOFeature newFeature = new GSOFeature();

                        GSOPipeLineStyle3D style = new GSOPipeLineStyle3D();
                        style.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), btnPipelineColor.BackColor);

                        double radius = f.GetFieldAsDouble(cmbRadius.SelectedIndex) / 1000;  // 单位 
                        string eventid = f.GetFieldAsString(cmbID.SelectedItem.ToString());

                        style.Radius = radius;                       
                        style.CornerSliceAngle = Convert.ToDouble(textBoxCornerSliceAngle.Text);


                        f.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;

                         GSOGeoPolyline3D line = f.Geometry as GSOGeoPolyline3D;
                         if (line == null)
                             return;
                         
                         
                           
                         double deep1 = f.GetFieldAsDouble(cmbFrom.SelectedItem.ToString());
                         double deep2 = f.GetFieldAsDouble(cmbTo.SelectedItem.ToString());
                         
                         if (chkDeep.Checked)
                         {
                             deep1 = 0 - deep1;
                             deep2 = 0 - deep2;
                         }
                         
                         if (cmbReference.SelectedIndex == 0) //管底
                         {
                             deep1 = deep1 + radius;
                             deep2 = deep2 + radius;
                         }
                         else if (cmbReference.SelectedIndex == 1) //管顶
                         {
                             deep1 = deep1 - radius;
                             deep2 = deep2 - radius;
                         }
                         for (int n = 0; n < line[0].Count; n++)
                         {
                             GSOPoint3d pt3d = line[0][n];
                             int pointcount = line[0].Count;
                             double radio = Math.Sqrt(Math.Pow(pt3d.Y - line[0][0].Y, 2) + Math.Pow(pt3d.X - line[0][0].X, 2)) / Math.Sqrt(Math.Pow(line[0][pointcount - 1].Y - line[0][0].Y, 2) + Math.Pow(line[0][pointcount - 1].X - line[0][0].X, 2));
                             pt3d.Z = deep1 + (deep2 - deep1) * radio;
                             line[0][n] = pt3d;
                         }
                        
                        newFeature.Geometry = line; // f.Geometry;
                        newFeature.Geometry.Style = style;
                        newFeature.Name = eventid;
                        //newFeature.CustomID = f.ID;
                        layer.AddFeature(newFeature);                     
                    }
                }
                ctl.Refresh();

                layer.Save();

                ctl.Globe.Layers.Remove(layer);
                this.Close();
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message);
            }            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}