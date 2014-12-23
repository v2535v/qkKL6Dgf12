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
    public partial class FrmAdjustLayer : Form
    {
        
        private  GSOGlobeControl ctl;
        private  GSOFeature startFeat;
        private  GSOFeature endFeat;

        private FrmAdjustLayer() { }

        public FrmAdjustLayer(GSOGlobeControl _ctl)
        {           
            ctl = _ctl;
            
            ctl.MouseClick += new MouseEventHandler(ctl_MouseClick);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            InitializeComponent();
        }

        private void FrmAdjustLayer_Load(object sender, EventArgs e)
        {
            SetLoad();
        }


        private void SetLoad()
        {

            for (int i = 0; i < ctl.Globe.Layers.Count; i++)
            {
                GSOLayer layer = ctl.Globe.Layers[i];              
                cmbLayers.Items.Add(layer.Caption);
            }

            txtNewLat.Enabled = false;
            txtNewLon.Enabled = false;
            txtOldLat.TextChanged += new EventHandler(txtOldLat_TextChanged);
            txtOldLon.TextChanged += new EventHandler(txtOldLon_TextChanged);
            
        }

        void ctl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GSOPoint3d point = ctl.Globe.ScreenToScene(e.X, e.Y);
                if (radioOld.Checked)
                {
                    txtOldLon.Text = point.X.ToString();
                    txtOldLat.Text = point.Y.ToString();

                    if (startFeat == null || startFeat.IsDeleted)
                    {
                        startFeat = new GSOFeature();
                        GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                        GSOGeoMarker p = new GSOGeoMarker();
                        style.IconPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/CrossIcon.png";
                        p.Style = style;
                        p.AltitudeMode = EnumAltitudeMode.ClampToGround;
                        p.X = point.X;
                        p.Y = point.Y;
                        p.Z = point.Z;
                        startFeat.Name = "起点";
                        startFeat.CustomID = 000;
                        startFeat.Geometry = p;

                        startFeat = ctl.Globe.MemoryLayer.AddFeature(startFeat);
                    }
                    else
                    {
                        GSOGeoPoint3D startpoint = startFeat.Geometry as GSOGeoPoint3D;
                        if (startpoint != null)
                        {
                            startpoint.X = point.X;
                            startpoint.Y = point.Y;
                            startpoint.Z = 0;
                        }
                    }
                }
                else
                {
                    txtNewLon.Text = point.X.ToString();
                    txtNewLat.Text = point.Y.ToString();

                    if (endFeat == null || endFeat.IsDeleted)
                    {
                        endFeat = new GSOFeature();
                        GSOGeoMarker p = new GSOGeoMarker();
                        GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                        style.IconPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/CrossIcon.png";
                        p.Style = style;
                        p.AltitudeMode = EnumAltitudeMode.ClampToGround;

                        endFeat.Name = "目标点";
                        endFeat.CustomID = 001;

                        p.X = point.X;
                        p.Y = point.Y;
                        p.Z = point.Z;
                        endFeat.Geometry = p;
                        endFeat = ctl.Globe.MemoryLayer.AddFeature(endFeat);
                    }
                    else
                    {
                        GSOGeoPoint3D endpoint = endFeat.Geometry as GSOGeoPoint3D;
                        if (endpoint != null)
                        {
                            endpoint.X = point.X;
                            endpoint.Y = point.Y;
                            endpoint.Z = 0;
                        }
                    }
                }
                ctl.Refresh();
            }
        }

    

        private void MoveEachFeature(GSOFeatureFolder folder,double daltX, double daltY)
        {
             GSOFeatures features = folder.Features;

             for (int i = 0; i < features.Length; i++)
             {
                 GSOFeature feature = features[i];
                 if (feature is GSOFeatureFolder)
                 {
                     MoveEachFeature(feature as GSOFeatureFolder, daltX, daltY);
                 }
                 else
                 {
                     GSOGeometry g = feature.Geometry;
                     if (g != null)
                     {
                         g.MoveXY(daltX, daltY);
                     }

                     //GSOGeoModel model = feature.Geometry as GSOGeoModel;
                     //if (model!=null)
                     //{
                     //    GSOPoint3d pt = model.Position;
                     //    pt.X += daltX;
                     //    pt.Y += daltY;

                     //    model.Position = pt;
                     //}
                     
                    
                 }
             }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            GSOLayer layer = ctl.Globe.Layers[cmbLayers.SelectedIndex];
            if (layer != null)
            {
                if (layer.Type != EnumLayerType.FeatureLayer)
                {
                    MessageBox.Show("当前选中的图层不是模型图层！", "提示");
                    return;
                }
                if (txtOldLat.Text == "")
                {
                    MessageBox.Show("请选择起点");
                }
                else if (txtNewLat.Text == "")
                {
                    MessageBox.Show("请选择目标点");
                }
                else
                {
                    double daltX = Convert.ToDouble(txtNewLon.Text) - Convert.ToDouble(txtOldLon.Text);
                    double daltY = Convert.ToDouble(txtNewLat.Text) - Convert.ToDouble(txtOldLat.Text);


                    GSOFeatureLayer flayer = layer as GSOFeatureLayer;
                    
                    GSOFeatures features = flayer.GetAllFeatures();
                    for (int i = 0; i < features.Length; i++)
                    {
                        GSOFeature feature = features[i];
                        if (feature is GSOFeatureFolder)
                        {
                            MoveEachFeature(feature as GSOFeatureFolder, daltX, daltY);
                        }
                        else
                        {
                            GSOGeometry g = feature.Geometry;
                            if (g != null)
                            {
                                 g.MoveXY(daltX, daltY);
                            }



                        //    switch (feature.Geometry.Type)
                        //    { 
                        //        case EnumGeometryType.GeoPolyline3D:
                        //            GSOGeoPolyline3D line = feature.Geometry as GSOGeoPolyline3D;                                    
                        //            for (int m = 0; m < line.PartCount; m++)
                        //            {
                        //                for (int j = 0; j < line[m].Count; j++)
                        //                {
                        //                    GSOPoint3d line0 = line[m][j];
                        //                    line0.X += daltX;
                        //                    line0.Y += daltY;
                        //                    line[m][j] = line0;
                        //                }
                        //            }
                        //            break;
                        //        case EnumGeometryType.GeoPolygon3D:
                        //            GSOGeoPolygon3D polygon = feature.Geometry as GSOGeoPolygon3D;
                        //            if (polygon != null)
                        //            {
                        //                polygon.MoveXY(daltX, daltY);
                        //            }
                        //            break;
                        //        case EnumGeometryType.GeoModel:
                        //            GSOGeoModel model = feature.Geometry as GSOGeoModel;
                        //            if (model != null)
                        //            {
                        //                GSOPoint3d pt = model.Position;
                        //                pt.X += daltX;
                        //                pt.Y += daltY;
                        //                model.Position = pt;
                        //            }
                        //            break;
                        //        case EnumGeometryType.GeoFrameAnimation:
                        //            GSOGeoFrameAnimation frameAnimation = feature.Geometry as GSOGeoFrameAnimation;
                        //            if (frameAnimation != null)
                        //            {
                        //                GSOPoint3d pt = frameAnimation.Position;
                        //                pt.X += daltX;
                        //                pt.Y += daltY;
                        //                frameAnimation.Position = pt;
                        //            }
                        //            break;
                        //        default:
                        //            GSOGeometry g = feature.Geometry;
                        //            if (g != null)
                        //            {
                        //                g.MoveXY(daltX, daltY);
                        //            }
                        //            break;
                        //    }
                            
                        }
                    }
                    if (startFeat != null)
                    {
                        startFeat.Delete();
                       
                    }
                    if (endFeat != null)
                    {
                        
                        endFeat.Delete();
                    }
                    ctl.Refresh();
                    //this.Close();
                }
            }
            else
            {
                MessageBox.Show("请选择图层");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAdjustLayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //adjustLayer = null;
            //blIsShowFirst = false;

            //this.Shown -= new EventHandler(FrmAdjustLayer_Shown);
            ctl.MouseClick -= new MouseEventHandler(ctl_MouseClick);
            if (startFeat!=null)
            {
                startFeat.Delete();
            }
            if (endFeat!=null)
            {
                endFeat.Delete();
            }
            ctl.Refresh();
        }

        private void txtOldLon_TextChanged(object sender, EventArgs e)
        {
            txtOldChange();
        }

        private void txtOldLat_TextChanged(object sender, EventArgs e)
        {
            txtOldChange();
        }

        private void txtNewLon_TextChanged(object sender, EventArgs e)
        {
            txtNewChange();
        }

        private void txtNewLat_TextChanged(object sender, EventArgs e)
        {
            txtNewChange();
        }

        private void txtNewChange()
        {
            decimal x;
            decimal y;
            if (txtNewLon.Text.Trim() == "")
            {
                txtNewLon.Text = 0 + "";
            }
            bool bl = decimal.TryParse(txtNewLon.Text.Trim(), out x);
            if (!bl)
            {
                MessageBox.Show("数据不符合要求！");
                return;
            }

            if (txtNewLat.Text.Trim() == "")
            {
                txtNewLat.Text = 0 + "";
            }
            bl = decimal.TryParse(txtNewLat.Text.Trim(), out y);
            if (!bl)
            {
                MessageBox.Show("数据不符合要求！");
                return;
            }

            GSOPoint3d point = ctl.Globe.ScreenToScene((int)Math.Round(x), (int)Math.Round(y));

            if (endFeat == null || endFeat.IsDeleted)
            {
                endFeat = new GSOFeature();
                GSOGeoMarker p = new GSOGeoMarker();
                GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                style.IconPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/CrossIcon.png";
                p.Style = style;
                p.AltitudeMode = EnumAltitudeMode.ClampToGround;

                endFeat.Name = "目标点";
                endFeat.CustomID = 001;

                p.X = (double)Math.Round(x);
                p.Y = (double)Math.Round(y); 
                p.Z = 0;
                endFeat.Geometry = p;
                endFeat = ctl.Globe.MemoryLayer.AddFeature(endFeat);
            }
            else
            {
                GSOGeoPoint3D endpoint = endFeat.Geometry as GSOGeoPoint3D;
                if (endpoint != null)
                {
                    endpoint.X = (double)Math.Round(x);
                    endpoint.Y = (double)Math.Round(y); 
                    endpoint.Z = 0;
                }
            }
            ctl.Refresh();
        }
        private void txtOldChange()
        {
            decimal x;
            decimal y;
            if (txtOldLon.Text.Trim() == "")
            {
                txtOldLon.Text = 0 + "";
            }
            bool bl = decimal.TryParse(txtOldLon.Text.Trim(), out x);
            if (!bl)
            {
                MessageBox.Show("数据不符合要求！");
                return;
            }

            if (txtOldLat.Text.Trim() == "")
            {
                txtOldLat.Text = 0 + "";
            }
            bl = decimal.TryParse(txtOldLat.Text.Trim(), out y);
            if (!bl)
            {
                MessageBox.Show("数据不符合要求！");
                return;
            }

            if (startFeat == null || startFeat.IsDeleted)
            {
                startFeat = new GSOFeature();
                GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                GSOGeoMarker p = new GSOGeoMarker();
                style.IconPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/CrossIcon.png";
                p.Style = style;
                p.AltitudeMode = EnumAltitudeMode.ClampToGround;
                p.X = (double)Math.Round(x); 
                p.Y = (double)Math.Round(y); 
                p.Z = 0;
                startFeat.Name = "起点";
                startFeat.CustomID = 000;
                startFeat.Geometry = p;

                startFeat = ctl.Globe.MemoryLayer.AddFeature(startFeat);
            }
            else
            {
                GSOGeoPoint3D startpoint = startFeat.Geometry as GSOGeoPoint3D;
                if (startpoint != null)
                {
                    startpoint.X = (double)Math.Round(x);
                    startpoint.Y = (double)Math.Round(y); 
                    startpoint.Z = 0;
                }
            }
            ctl.Refresh();
        }

        private void radioOld_CheckedChanged(object sender, EventArgs e)
        {
            txtOldLat.Enabled = radioOld.Checked;
            txtOldLon.Enabled = radioOld.Checked;
            if (radioOld.Checked)
            { 
                txtOldLat.TextChanged +=new EventHandler(txtOldLat_TextChanged);
                txtOldLon.TextChanged += new EventHandler(txtOldLon_TextChanged);

                txtNewLat.TextChanged -= new EventHandler(txtNewLat_TextChanged);
                txtNewLon.TextChanged -= new EventHandler(txtNewLon_TextChanged);
                
            }
        }

        private void radioNew_CheckedChanged(object sender, EventArgs e)
        {

            txtNewLat.Enabled = radioNew.Checked;
            txtNewLon.Enabled = radioNew.Checked;
            if (radioNew.Checked)
            {
                txtNewLat.TextChanged += new EventHandler(txtNewLat_TextChanged);
                txtNewLon.TextChanged += new EventHandler(txtNewLon_TextChanged);
               
                    txtOldLat.TextChanged -= new EventHandler(txtOldLat_TextChanged);
                    txtOldLon.TextChanged -= new EventHandler(txtOldLon_TextChanged);
                
            }
        }
    }
}
