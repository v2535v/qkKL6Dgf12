using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
    public partial class CtrlPolygonStylePage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        GSOFeature mfeature = null;
        public GSOGeometry m_Geometry = null;
        public CtrlPolygonStylePage(GSOFeature feature, GSOGlobeControl globeControl)
        {
            InitializeComponent();
             m_GlobeControl = globeControl;
             m_Geometry = feature.Geometry;
            mfeature = feature;
        }
        private void CtrlPolygonStylePage_Load(object sender, EventArgs e)
        {
             if (m_Geometry != null)
             {
                 SetControlsByStyle(m_Geometry.Style);
             }
        }
        private void CheckControlsEnable(bool bValue)
        {
            pictureBoxFillColor.Enabled = bValue;
            numericUpDownFillOpaque.Enabled = bValue;
            checkBoxFill.Enabled = bValue;
            checkBoxOutline.Enabled = bValue;
            checkBoxUseOutlineStyle.Enabled = bValue;
            buttonSetLineStyle.Enabled = checkBoxUseOutlineStyle.Checked;
        }
        private void SetControlsByStyle(GSOStyle style)
        {
            GSOSimplePolygonStyle3D geoStyle3d = style as GSOSimplePolygonStyle3D;
            if (geoStyle3d != null)
            {

                // 这句要写到前面，不然下面Checked的时候要检查
                pictureBoxFillColor.BackColor = geoStyle3d.FillColor;
                numericUpDownFillOpaque.Value = geoStyle3d.FillColor.A;
                checkBoxFill.Checked = geoStyle3d.Fill;
                checkBoxOutline.Checked = geoStyle3d.OutLineVisible;

                if (geoStyle3d.OutlineStyle!=null)
                {
                    checkBoxUseOutlineStyle.Checked = true;
                }
                else
                {
                    checkBoxUseOutlineStyle.Checked = false;
                }
                checkBoxUseStyle.Checked = true;
            }
            else
            {
                checkBoxUseStyle.Checked = false;

            }


            CheckControlsEnable(checkBoxUseStyle.Checked);


        }
        private void checkBoxFill_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                GSOSimplePolygonStyle3D geoStyle3d = m_Geometry.Style as GSOSimplePolygonStyle3D;
                if (geoStyle3d != null)
                {
                    geoStyle3d.Fill = checkBoxFill.Checked; 
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }
            }
        }

        private void checkBoxOutline_CheckedChanged(object sender, EventArgs e)
        {

            if (m_Geometry != null)
            {
                GSOSimplePolygonStyle3D geoStyle3d = m_Geometry.Style as GSOSimplePolygonStyle3D;
                if (geoStyle3d != null)
                {
                    geoStyle3d.OutLineVisible = checkBoxOutline.Checked;
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }
            }

        }
        private void fillColorChanged()
        {
            if (m_Geometry != null)
            {
                GSOSimplePolygonStyle3D geoStyle3d = m_Geometry.Style as GSOSimplePolygonStyle3D;
                if (geoStyle3d != null)
                {
                    geoStyle3d.FillColor = Color.FromArgb(Convert.ToByte(numericUpDownFillOpaque.Value), pictureBoxFillColor.BackColor);
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }
            }
        }
        private void pictureBoxFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxFillColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFillColor.BackColor = dlg.Color;
                fillColorChanged();

            }
           
        }

        private void numericUpDownFillOpaque_ValueChanged(object sender, EventArgs e)
        {
            fillColorChanged();
        }

        private void buttonSetLineStyle_Click(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                GSOSimplePolygonStyle3D geoStyle3d = m_Geometry.Style as GSOSimplePolygonStyle3D;
                if (geoStyle3d != null)
                {
                    FrmSetOutlineStyle dlg = new FrmSetOutlineStyle(geoStyle3d.OutlineStyle,(GSOGeoPolygon3D)m_Geometry,mfeature, m_GlobeControl);
                    dlg.Show(this);
                }
            }
          
        }

        private void checkBoxUseStyle_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxUseStyle.Checked;

            if (!bChecked)
            {
                // 清除风格
                if (m_Geometry != null)
                {
                    m_Geometry.Style = null;
                }


            }
            else
            {

                if (m_Geometry != null && m_Geometry.Style == null)
                {
                    m_Geometry.Style = new GSOSimplePolygonStyle3D();
                    SetControlsByStyle(m_Geometry.Style);
                }

            }

            CheckControlsEnable(bChecked);
            if (m_GlobeControl != null)
            {
                m_GlobeControl.Refresh();
            }
        }

        private void checkBoxUseOutlineStyle_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxUseOutlineStyle.Checked;
            buttonSetLineStyle.Enabled = bChecked;

           
            if (m_Geometry != null)
            {
                GSOSimplePolygonStyle3D geoStyle3d = m_Geometry.Style as GSOSimplePolygonStyle3D;
                if (geoStyle3d != null)
                {
                    if (!bChecked)
                    {
                        // 清除自定义的轮廓线风格
                        geoStyle3d.OutlineStyle = null;
                    }
                    else
                    {
                        if (geoStyle3d.OutlineStyle == null)
                        {
                            // 如果不存在就创建一个新的
                            geoStyle3d.OutlineStyle = new GSOSimpleLineStyle3D();
                        }
                       
                    }

                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                  
                }
            }
        }

    
    }
}
