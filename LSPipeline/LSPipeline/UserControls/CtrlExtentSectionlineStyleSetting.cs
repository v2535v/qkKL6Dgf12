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
    public partial class CtrlExtentSectionlineStyleSetting : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOLayer mlayer = null;
        public GSOFeature mfeature = null;
        public GSOStyle m_OldStyle = null;
        public GSOStyle m_Style = null;
        EnumAltitudeMode altituMode = EnumAltitudeMode.RelativeToGround;
        bool m_bInitialized = false;
        public CtrlExtentSectionlineStyleSetting(GSOStyle style, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            // 如果m_OldStyle不存在，先备份一个
            if (style != null)
            {
                m_OldStyle = style.Clone();
            }
            m_Style = style;
        }
        public CtrlExtentSectionlineStyleSetting(GSOStyle style, GSOFeature feature, GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            mlayer = layer;
            mfeature = feature;
            altituMode = feature.Geometry.AltitudeMode;

            // 如果m_OldStyle不存在，先备份一个
            if (style != null)
            {
                m_OldStyle = style.Clone();
            }
            m_Style = style;
        }

        private void FormPipelineStyleSetting_Load(object sender, EventArgs e)
        {
            SetControlsByStyle(m_Style);
        }

        GSOExtendSectionLineStyle3D extentSectionLineStyle3D = null;
        private void SetControlsByStyle(GSOStyle style)
        {
            if (m_Style != null)
            {
                extentSectionLineStyle3D = m_Style as GSOExtendSectionLineStyle3D;
                if (extentSectionLineStyle3D == null)
                {
                    extentSectionLineStyle3D = new GSOExtendSectionLineStyle3D();
                    extentSectionLineStyle3D.LineColor = Color.Green;
                    GSOPoint3ds points = new GSOPoint3ds();
                    points.Add(new GSOPoint3d(-0.5, 0.5, 0));
                    points.Add(new GSOPoint3d(-0.5, -0.5, 0));
                    points.Add(new GSOPoint3d(0.5, -0.5, 0));
                    points.Add(new GSOPoint3d(0.5, 0.5, 0));
                    extentSectionLineStyle3D.SetSectionPoints(points);
                    RefreshGlobe(extentSectionLineStyle3D);
                }
            }
            else
            {
                extentSectionLineStyle3D = new GSOExtendSectionLineStyle3D();
                extentSectionLineStyle3D.LineColor = Color.Green;
                GSOPoint3ds points = new GSOPoint3ds();
                points.Add(new GSOPoint3d(-0.5, 0.5, 0));
                points.Add(new GSOPoint3d(-0.5, -0.5, 0));
                points.Add(new GSOPoint3d(0.5,- 0.5, 0));
                points.Add(new GSOPoint3d(0.5, 0.5, 0));
                extentSectionLineStyle3D.SetSectionPoints(points);
                RefreshGlobe(extentSectionLineStyle3D);
            }
            // 这句要写到前面，不然下面Checked的时候要检查
            pictureBoxLineColor.BackColor = extentSectionLineStyle3D.LineColor;
            numericUpDownLineOpaque.Value = extentSectionLineStyle3D.LineColor.A;          
                       
            textBoxCornerSliceAngle.Text = extentSectionLineStyle3D.CornerSliceAngle.ToString();
            GSOPoint3ds mpoints = extentSectionLineStyle3D.GetSectionPoints();
            if (mpoints != null && mpoints.Count > 0)
            {
                for (int i = 0; i < mpoints.Count; i++)
                {
                    GSOPoint3d point = mpoints[i];
                    if (point != null)
                    {
                        textBoxLineRadius.Text = (Math.Abs(point.X) * 2).ToString();
                        textBoxThickness.Text = (Math.Abs(point.Y) * 2).ToString();
                        break;
                    }                    
                }
            }            

            m_bInitialized = true;
        }

        private void lineColorChanged()
        {
            if (extentSectionLineStyle3D != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                extentSectionLineStyle3D.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), pictureBoxLineColor.BackColor);
                RefreshGlobe(extentSectionLineStyle3D);
            }
        }
        private void pictureBoxLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxLineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxLineColor.BackColor = dlg.Color;
                lineColorChanged();
            }
        }

        private void numericUpDownLineOpaque_ValueChanged(object sender, EventArgs e)
        {
            lineColorChanged();
        }

        private void textBoxLineRadius_TextChanged(object sender, EventArgs e)
        {
            if (extentSectionLineStyle3D != null)
            {
                try
                {
                    double width = 0.0;
                    if (textBoxLineRadius.Text.Trim() == "" || double.TryParse(textBoxLineRadius.Text,out width) == false)
                    {
                        return;
                    }
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);                    
                    
                    GSOPoint3ds points = extentSectionLineStyle3D.GetSectionPoints();
                    for(int i = 0; i< points.Count;i++)
                    {
                        GSOPoint3d point = points[i];
                        if (point != null)
                        {
                            if (point.X > 0)
                            {
                                point.X = width / 2;
                            }
                            else 
                            {
                                point.X = -width / 2;
                            }
                        }
                        points[i] = point;
                    }
                    extentSectionLineStyle3D.SetSectionPoints(points);
                    RefreshGlobe(extentSectionLineStyle3D);
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }

        private void textBoxThickness_TextChanged(object sender, EventArgs e)
        {
            if (extentSectionLineStyle3D != null)
            {
                try
                {
                    double width = 0.0;
                    if (textBoxThickness.Text.Trim() == "" || double.TryParse(textBoxThickness.Text, out width) == false)
                    {
                        return;
                    }
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    GSOPoint3ds points = extentSectionLineStyle3D.GetSectionPoints();
                    for (int i = 0; i < points.Count; i++)
                    {
                        GSOPoint3d point = points[i];
                        if (point != null)
                        {
                            if (point.Y > 0)
                            {
                                point.Y = width / 2;
                            }
                            else
                            {
                                point.Y = -width / 2;
                            }
                        }
                        points[i] = point;
                    }
                    extentSectionLineStyle3D.SetSectionPoints(points);
                    RefreshGlobe(extentSectionLineStyle3D);
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }

        private void textBoxCornerSliceAngle_TextChanged(object sender, EventArgs e)
        {
            if (extentSectionLineStyle3D != null)
            {
                try
                {
                    double width = 0.0;
                    if (textBoxCornerSliceAngle.Text.Trim() == "" || double.TryParse(textBoxCornerSliceAngle.Text, out width) == false)
                    {
                        return;
                    }
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    extentSectionLineStyle3D.CornerSliceAngle = width;
                    RefreshGlobe(extentSectionLineStyle3D);
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }
      
        private void RefreshGlobe(GSOExtendSectionLineStyle3D extentSectionLineStyle3D)
        {
            mfeature.Geometry.Style = extentSectionLineStyle3D;
            mfeature.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            if (m_GlobeControl != null)
            {
                m_GlobeControl.Globe.Refresh();
            }
        }
    }
}
