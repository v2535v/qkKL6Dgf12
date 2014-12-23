using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using System.IO;
namespace WorldGIS
{
    public partial class FrmLineToPowerLine : Form
    {
        private GSOGlobeControl ctl;
        public GSOGlobeControl Ctl
        {
            get
            {
                return ctl;
            }
            set
            {
                ctl = value;
            }
        }
        private GSOFeature feature;
        public GSOFeature Feature
        {
            get
            {
                return feature;
            }
            set
            {
                feature = value;
            }
        }
        public FrmLineToPowerLine(GSOGlobeControl _ctl,GSOFeature _feature)
        {
            InitializeComponent();
            ctl = _ctl;
            feature = _feature;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCurveFactor.Text != "" && txtRadius.Text != "" && textBoxPath.Text !="")
            {
                GSOGeoPolyline3D line = (GSOGeoPolyline3D)feature.Geometry;

                GSOGeoPowerLine geopowerline = new GSOGeoPowerLine();
                
                GSOPoint3d pnt = new GSOPoint3d();
                for (int i = 0; i < line[0].Count; i++)
                {
                    GSOGeoPowerLineNode node = new GSOGeoPowerLineNode();
                    pnt = line[0][i];
                    
                    node.NodeTemplatePath = textBoxPath.Text;
                    node.SetPosition(pnt.X, pnt.Y, pnt.Z);
                    geopowerline.AddNode(node);
                    
                }
                GSOFeature newFeature = new GSOFeature();

                geopowerline.LinkLineStyle = new GSOElecLineStyle3D();
                geopowerline.LinkLineStyle.LineColor = Color.FromArgb(255,pictureBoxFillColor.BackColor);
                geopowerline.LinkLineStyle.Radius = double.Parse(txtRadius.Text);
                geopowerline.LinkLineStyle.Slice = int.Parse(txtSlice.Text);
                geopowerline.LinkLineStyle.CurveFactor = double.Parse(txtCurveFactor.Text);
                newFeature.Geometry = geopowerline;
                ctl.Globe.MemoryLayer.AddFeature(newFeature);
                this.Close();
            }
        }

        private void pictureBoxFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxFillColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFillColor.BackColor = Color.FromArgb(255, dlg.Color.R, dlg.Color.G, dlg.Color.B);
            }
        }


        private void buttonSelPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "模板文件(*.len)|*.len|*.*|*.*||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = dlg.FileName;
            } 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
