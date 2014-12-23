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
    public partial class FrmBatchCreatePipeDitch : Form
    {
        private GeoScene.Globe.GSOGlobeControl ctl;
        public FrmBatchCreatePipeDitch(GSOGlobeControl _ctl)
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
            cmbWidth.Items.Clear();
            cmbID.Items.Clear();
            cmbHeight.Items.Clear();
            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                cmbFrom.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbTo.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbWidth.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbID.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                cmbHeight.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
            }

            cmbFrom.SelectedItem = "Deep1";
            cmbTo.SelectedItem = "Deep2";
            cmbWidth.SelectedItem = "Weight";
            cmbHeight.SelectedItem = "Height";
            cmbID.SelectedItem = "Handle";
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
                    MessageBox.Show("管线模型文件路径无效！", "提示");
                    return;
                }
                if (File.Exists(txtModelLayer.Text))
                {
                    MessageBox.Show("管线模型文件已存在！", "提示");
                    return;
                }                 

                GSOLayer sourceLayer = ctl.Globe.Layers[cmbLayer.SelectedIndex];

                GSOLayer layer = ctl.Globe.Layers.Add(txtModelLayer.Text);
                lgdFilePath = txtModelLayer.Text;
                if (layer != null)
                {
                    GSOFeatures features = sourceLayer.GetAllFeatures();
                    string message = "";
                    for (int j = 0; j < features.Length; j++)
                    {
                        GSOFeature f = features[j];

                        GSOFeature newFeature = new GSOFeature();

                        GSOExtendSectionLineStyle3D style = new GSOExtendSectionLineStyle3D();
                        style.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), btnPipelineColor.BackColor);

                        double width = 0;
                        GSOFieldDefn field = (GSOFieldDefn)(f.GetFieldDefn(cmbWidth.SelectedItem.ToString()));
                        if (field.Type == EnumFieldType.Text)
                        {
                            string temp = f.GetFieldAsString(cmbWidth.SelectedItem.ToString());
                            double outNum = 0;
                            bool num = double.TryParse(temp, out outNum);
                            if (num)
                                width = outNum;

                        }
                        else if (field.Type == EnumFieldType.Double)
                            width = f.GetFieldAsDouble(cmbWidth.SelectedItem.ToString());


                        double height = 0;
                        field = (GSOFieldDefn)(f.GetFieldDefn(cmbHeight.SelectedItem.ToString()));
                        if (field.Type == EnumFieldType.Text)
                        {
                            string temp = f.GetFieldAsString(cmbHeight.SelectedItem.ToString());
                            double outNum = 0;
                            bool num = double.TryParse(temp, out outNum);
                            if (num)
                                height = outNum;

                        }
                        else if (field.Type == EnumFieldType.Double)
                            height = f.GetFieldAsDouble(cmbHeight.SelectedItem.ToString());

                        string eventid = f.GetFieldAsString(cmbID.SelectedItem.ToString());

                        if (width == 0 || height == 0)
                        {
                            message += "ID为" + f.ID + "的对象的沟宽或者沟高字段的值为0 \n";
                            continue;
                        }
                        GSOPoint3ds sectionpts = new GSOPoint3ds();
                        sectionpts.Add(new GSOPoint3d(width / -2, height / 2, 0));
                        sectionpts.Add(new GSOPoint3d(width / -2, height / -2, 0));
                        sectionpts.Add(new GSOPoint3d(width / 2, height / -2, 0));
                        sectionpts.Add(new GSOPoint3d(width / 2, height / 2, 0));

                        style.SetSectionPoints(sectionpts);
                        style.IsClosed = false;
                        style.SetAnchorByAlign(EnumAlign.BottomCenter);

                        f.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;

                        GSOGeoPolyline3D line = f.Geometry as GSOGeoPolyline3D;
                        if (line == null)
                        {
                            message += "ID为" + f.ID + "的对象不是线对象 \n";
                            continue;
                        }
                        double deep1 = f.GetFieldAsDouble(cmbFrom.SelectedItem.ToString());
                        double deep2 = f.GetFieldAsDouble(cmbTo.SelectedItem.ToString());

                        if (chkDeep.Checked)
                        {
                            deep1 = 0 - deep1;
                            deep2 = 0 - deep2;
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
                        layer.AddFeature(newFeature);
                    }
                    ctl.Refresh();
                    layer.Save();
                    ctl.Globe.Layers.Remove(layer);
                    string strMessage = "shp文件中共" + features.Length + "个对象，实际生成" + layer.GetAllFeatures().Length + "个对象！\n";                    
                    MessageBox.Show(strMessage + message, "提示");
                    this.Close();
                }                
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