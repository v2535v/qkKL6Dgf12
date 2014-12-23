using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;

namespace WorldGIS
{
    public partial class FrmUpdateLayoutColor : Form
    {
        GSOGlobeControl mGlobeControl;
        GSOLayer mlayer;

        public FrmUpdateLayoutColor(GSOGlobeControl globeControl,GSOLayer layer)
        {
            InitializeComponent();
            mGlobeControl = globeControl;
            mlayer = layer;
        }

        private void FrmUpdateLayoutColor_Load(object sender, EventArgs e)
        {
            this.Text += "——" + mlayer.Caption;
            groupBoxLineStyle.Enabled = groupBoxPolygonStyle.Enabled = groupBoxPolygonFillStyle.Enabled = groupBoxPolygonOutlineStyle.Enabled = false;
            checkBoxLineStyle.Checked = checkBoxPolygonStyle.Checked = checkBoxPolygonFillStyle.Checked = checkBoxPolygonOutlineStyle.Checked = false;
        }

        private void checkBoxLineStyle_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxLineStyle.Enabled = checkBoxLineStyle.Checked;
            textBoxLineWidth.Text = "1";
        }

        private void checkBoxPolygonStyle_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxPolygonStyle.Enabled = checkBoxPolygonStyle.Checked;
        }

        private void checkBoxPolygonFillStyle_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxPolygonFillStyle.Enabled = checkBoxPolygonFillStyle.Checked;
        }

        private void checkBoxPolygonOutlineStyle_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxPolygonOutlineStyle.Enabled = checkBoxPolygonOutlineStyle.Checked;
            textBoxPolygonOutlineWidth.Text = "1";
        }

        private void pictureBoxLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = pictureBoxLineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxLineColor.BackColor = dlg.Color;
            }
        }

        private void pictureBoxPolygonFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = pictureBoxPolygonFillColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPolygonFillColor.BackColor = dlg.Color;
            }
        }

        private void pictureBoxPolygonOutlineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = pictureBoxPolygonOutlineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPolygonOutlineColor.BackColor = dlg.Color;
            }
        }

        EnumLineType getLineType(int index )
        {
            EnumLineType lineType = EnumLineType.Solid;
            switch (index)
            {
                case 0:
                    lineType = EnumLineType.Solid;
                    break;
                case 1:
                    lineType = EnumLineType.Dash;
                    break;
                case 2:
                    lineType= EnumLineType.Dot;
                    break;
                case 3:
                    lineType = EnumLineType.DashDot;
                    break;
                case 4:
                    lineType = EnumLineType.DashDotDot;
                    break;
            }
            return lineType;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            GSOFeatures features = mlayer.GetAllFeatures();
            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                switch (feature.Geometry.Type)
                {
                    case EnumGeometryType.GeoPolyline3D:
                       
                        if (checkBoxLineStyle.Checked)
                        {
                            GSOSimpleLineStyle3D polylinestyle = null;
                            if (feature.Geometry.Style == null)
                            {
                                polylinestyle = new GSOSimpleLineStyle3D();
                                polylinestyle.LineColor = Color.FromArgb(Convert.ToByte(numericLineOpaque.Value), pictureBoxLineColor.BackColor);

                                polylinestyle.LineType = getLineType(comboBoxLineType.SelectedIndex);
                               
                                if (textBoxLineWidth.Text != "")
                                {
                                    string strwidth = textBoxLineWidth.Text;
                                    double dwidth = 0.0;
                                    if (double.TryParse(strwidth, out dwidth))
                                    {
                                        polylinestyle.LineWidth = dwidth;
                                    }
                                }
                                feature.Geometry.Style = polylinestyle;
                            }
                            else
                            {
                                polylinestyle = (GSOSimpleLineStyle3D)feature.Geometry.Style;
                                polylinestyle.LineColor = Color.FromArgb(Convert.ToByte(numericLineOpaque.Value), pictureBoxLineColor.BackColor);
                                polylinestyle.LineType = getLineType(comboBoxLineType.SelectedIndex);
                                if (textBoxLineWidth.Text != "")
                                {
                                    string strwidth = textBoxLineWidth.Text;
                                    double dwidth = 0.0;
                                    if (double.TryParse(strwidth, out dwidth))
                                    {
                                        polylinestyle.LineWidth = dwidth;
                                    }
                                }
                            }
                        }
                        break;
                    case EnumGeometryType.GeoPolygon3D:
                       
                        if (checkBoxPolygonStyle.Checked)
                        {
                            GSOSimplePolygonStyle3D polygonstyle = null;
                            GSOSimpleLineStyle3D outlinestyle = null;
                            if (checkBoxPolygonFillStyle.Checked)
                            {
                                if (feature.Geometry.Style == null)
                                {
                                    polygonstyle = new GSOSimplePolygonStyle3D();
                                    polygonstyle.FillColor = Color.FromArgb(Convert.ToByte(numericPolygonFillOpaque.Value), pictureBoxPolygonFillColor.BackColor);
                                    feature.Geometry.Style = polygonstyle;
                                }
                                else
                                {
                                    polygonstyle = (GSOSimplePolygonStyle3D)feature.Geometry.Style;
                                    polygonstyle.FillColor = Color.FromArgb(Convert.ToByte(numericPolygonFillOpaque.Value), pictureBoxPolygonFillColor.BackColor);
                                }
                            }
                            if (checkBoxPolygonOutlineStyle.Checked)
                            {

                                if (feature.Geometry.Style == null)
                                {
                                    polygonstyle = new GSOSimplePolygonStyle3D();
                                    outlinestyle = new GSOSimpleLineStyle3D();
                                    outlinestyle.LineColor = Color.FromArgb(Convert.ToByte(numericPolygonOutlineOpaque.Value), pictureBoxPolygonOutlineColor.BackColor);
                                    outlinestyle.LineType = getLineType(comboBoxPolygonOutlineType.SelectedIndex);
                                    if (textBoxPolygonOutlineWidth.Text != "")
                                    {
                                        string strwidth = textBoxPolygonOutlineWidth.Text;
                                        double dwidth = 0.0;
                                        if (double.TryParse(strwidth, out dwidth))
                                        {
                                            outlinestyle.LineWidth = dwidth;
                                        }
                                    }
                                    polygonstyle.OutlineStyle = outlinestyle;
                                    feature.Geometry.Style = polygonstyle;
                                }
                                else
                                {
                                    polygonstyle = (GSOSimplePolygonStyle3D)feature.Geometry.Style;
                                    if (polygonstyle.OutlineStyle == null)
                                    {
                                        outlinestyle = new GSOSimpleLineStyle3D();
                                        outlinestyle.LineColor = Color.FromArgb(Convert.ToByte(numericPolygonOutlineOpaque.Value), pictureBoxPolygonOutlineColor.BackColor);
                                        outlinestyle.LineType = getLineType(comboBoxPolygonOutlineType.SelectedIndex);
                                        if (textBoxPolygonOutlineWidth.Text != "")
                                        {
                                            string strwidth = textBoxPolygonOutlineWidth.Text;
                                            double dwidth = 0.0;
                                            if (double.TryParse(strwidth, out dwidth))
                                            {
                                                outlinestyle.LineWidth = dwidth;
                                            }
                                        }
                                        polygonstyle.OutlineStyle = outlinestyle;
                                        feature.Geometry.Style = polygonstyle;
                                    }
                                    else
                                    {
                                        outlinestyle = (GSOSimpleLineStyle3D)polygonstyle.OutlineStyle;
                                        outlinestyle.LineColor = Color.FromArgb(Convert.ToByte(numericPolygonOutlineOpaque.Value), pictureBoxPolygonOutlineColor.BackColor);
                                        outlinestyle.LineType = getLineType(comboBoxPolygonOutlineType.SelectedIndex);
                                        if (textBoxPolygonOutlineWidth.Text != "")
                                        {
                                            string strwidth = textBoxPolygonOutlineWidth.Text;
                                            double dwidth = 0.0;
                                            if (double.TryParse(strwidth, out dwidth))
                                            {
                                                outlinestyle.LineWidth = dwidth;
                                            }
                                        }
                                        feature.Geometry.Style = polygonstyle;
                                    }
                                }
                            }
                        }
                        break;
                }
                mGlobeControl.Refresh();
            }
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxLineWidth_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLineWidth.Text != "")
            {
                string strwidth = textBoxLineWidth.Text;
                double dwidth = 0.0;
                if (!double.TryParse(strwidth, out dwidth))
                {
                    MessageBox.Show("文本格式不正确！");
                    textBoxLineWidth.Text = "1";
                }
            }
        }

        private void textBoxPolygonOutlineWidth_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPolygonOutlineWidth.Text != "")
            {
                string strwidth = textBoxPolygonOutlineWidth.Text;
                double dwidth = 0.0;
                if (!double.TryParse(strwidth, out dwidth))
                {
                    MessageBox.Show("文本格式不正确！");
                    textBoxPolygonOutlineWidth.Text = "1";
                }
            }
        }
    }
}
