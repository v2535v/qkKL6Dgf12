using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
    public partial class FrmLabel : Form
    {
        private GSOGeoPoint3D pt = null;
        private GSOGlobeControl globeControl = null;
        GSOLabel label = new GSOLabel();
        public FrmLabel(GSOGlobeControl ctl)
        {
            
            InitializeComponent();
            globeControl = ctl;

            
        }    

        private void FrmLabel_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Apply();
            this.Close();
        }

        private void Apply()
        {
            label.Style = new GSOLabelStyle();

            label.Style.TextStyle.Italic = chkItalic.Checked;
            label.Style.Opaque =trackBarOpaque.Value / 10.0;

            label.Style.TextStyle.FontHeight = (double)numFontsize.Value;

            label.Style.TractionLineEndPos = new GSOPoint2d((double)numOffsetX.Value, (double)numOffsetY.Value);

            label.Style.OutlineColor = labelBorderColor.BackColor;
            if (chkHasTrackLine.Checked)
            {
                label.Style.TractionLineColor = Color.FromArgb(255, labelBorderColor.BackColor);
            }
            else
            {
                label.Style.TractionLineColor = Color.FromArgb(0, labelBorderColor.BackColor);
            }

            label.Style.BackFillEffect = EnumLabelBackEffect.EFFECT_VGRADIENT;
            label.Style.TracktionLineWidth = (double)numTrackWidth.Value;
            label.Style.OutlineWidth = (double)numBorderWidth.Value;

            Color beginColor = Color.FromArgb(255, Color.Transparent);
            Color endColor = Color.FromArgb(255, Color.Transparent);
            label.Style.BackBeginColor =  labelFrom.BackColor;  
            label.Style.BackEndColor =  labelTo.BackColor;
            
            label.Style.MaxVisibleDistance = (double)numMaxdistance.Value;
            label.Style.MinVisibleDistance = (double)numMinDistance.Value;


            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    label.Style.TracktionLineType = EnumTracktionLineType.Solid;
                    break;
                default:
                    label.Style.TracktionLineType = EnumTracktionLineType.Dot;
                    break;
            }

            label.Text = txtInfo.Text;
            if (txtImagePath.Text != "")
            {
                label.BKImage = txtImagePath.Text;
            }


            GSOFeature feature = globeControl.Globe.SelectedObject as GSOFeature;  //new GSOFeature();
            
            feature.Label = label;
         //   globeControl.Globe.MemoryLayer.AddFeature(feature);
            globeControl.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void btnFrom_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = labelFrom.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelFrom.BackColor = colorDialog1.Color;
            }
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = labelTo.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelTo.BackColor = colorDialog1.Color;
            }
        }

        private void btnBorderColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = labelBorderColor.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelBorderColor.BackColor = colorDialog1.Color;
            }
           
        }

        private void btnImagePath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
