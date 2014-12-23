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

namespace WorldGIS.Forms
{
    public partial class FrmShp2KML : Form
    {
        private GeoScene.Globe.GSOGlobeControl ctl;
        public FrmShp2KML(GSOGlobeControl _ctl)
        {
            ctl = _ctl;
            InitializeComponent();
        }

        private void btnBrowseModel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.lgd,*.kml|*.lgd;*.kml";
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
            if (features.Length == 0)
                return;

            listFields.Items.Clear();
            combLabel.Items.Clear();
            
            for (int i = 0; i < features[0].GetFieldCount(); i++)
            {
                listFields.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
                combLabel.Items.Add(((GeoScene.Data.GSOFieldDefn)(features[0].GetFieldDefn(i))).Name);
            }
        }

        public string lgdFilePath = "";

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtModelLayer.Text))
                {
                    MessageBox.Show("文件路径无效！", "提示");
                    return;
                }
                if (File.Exists(txtModelLayer.Text))
                {
                    MessageBox.Show("文件已存在！", "提示");
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
                       
                        string text = "";
                        if (combLabel.SelectedItem != null)
                        {
                            text = f.GetFieldAsString(combLabel.SelectedItem.ToString());
                        }
                        if (listFields.CheckedItems.Count > 0)
                        {
                            newFeature.Description = GetBubbleInfo(f, numWidth.Value.ToString(), numHeight.Value.ToString());
                        }

                        if (f.Geometry is GSOGeoPoint3D)
                        {
                            GSOGeoMarker marker = new GSOGeoMarker();
                            marker.Position = f.Geometry.GeoCenterPoint;
                            marker.Text = text;
                            GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                            style.IconPath = Application.StartupPath + "\\Resource\\ddd.png";
                            marker.Style = style;
                            newFeature.Geometry = marker;
                        }
                        else if(f.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                        {
                            GSOGeoPolyline3D line = (GSOGeoPolyline3D)f.Geometry.Clone();
                            GSOLabel label = new GSOLabel();
                            label.Text = text;
                            GSOLabelStyle style = new GSOLabelStyle();
                            style.HasTracktionLine = false;
                            style.OutlineColor = Color.Transparent;
                            style.MaxVisibleDistance = 100000;
                            label.Style = style;
                            line.Label = label;
                            newFeature.Geometry = line;
                        }
                        else if (f.Geometry.Type == EnumGeometryType.GeoPolygon3D)
                        {
                            GSOGeoPolygon3D polygon = (GSOGeoPolygon3D)f.Geometry.Clone(); 
                            GSOLabel label = new GSOLabel();
                            label.Text = text;
                            GSOLabelStyle style = new GSOLabelStyle();
                            style.HasTracktionLine = false;
                            style.OutlineColor = Color.Transparent;
                            style.MaxVisibleDistance = 100000;
                            label.Style = style;
                            polygon.Label = label;
                            newFeature.Geometry = polygon;
                        }
                        newFeature.Name = text;                        
                        layer.AddFeature(newFeature);
                    }
                }
                ctl.Refresh();
                layer.Save();

                //ctl.Globe.Layers.Remove(layer);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetBubbleInfo(GSOFeature feature,string width,string height)
        {
            string str = "<!-- <BALLOON><CONTENT_CX>" + width + "</CONTENT_CX><CONTENT_CY>"+ height +"</CONTENT_CY><CONTENT_TYPE>text</CONTENT_TYPE><SHOW_MODE>balloonex</SHOW_MODE>-->";

            str += "<html><body><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"width:100%;background:#FFFFFF none repeat scroll 0 0;border-collapse:collapse;font-family:\"Lucida Sans Unicode\",\"Lucida Grande\",Sans-Serif;font-size:10px;text-align:center;\" >";
                
            for (int j = 0; j < listFields.CheckedItems.Count; j++)
            {
                GSOFieldDefn field1 = (GSOFieldDefn)feature.GetFieldDefn(listFields.CheckedItems[j].ToString());

                string value1 = feature.GetFieldAsString(listFields.CheckedItems[(j)].ToString());                              

                str += "<tr><td style=\"font-size:10pt;border:1px solid #CCCCCC;color:#666699;padding:2px 2px; background-color:#E7F3FB\"><center>" +
                    field1.Name +
                    "</center></td><td style=\"font-size:10pt;border:1px solid #CCCCCC;color:#666699;padding:2px 2px;\"><center>" +
                    value1 + "</center></td></tr>";
            }

            str += "</table></body></html>";
            return str;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combLabel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
