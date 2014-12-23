using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
    public partial class FrmSetPolygonStyle : Form
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOStyle m_OldStyle = null;
        public GSOStyle m_Style = null;
        public FrmSetPolygonStyle(GSOStyle style, GSOGlobeControl globeControl)
        {
            
            InitializeComponent();
            m_GlobeControl = globeControl;
            // 先备份一个
            if (style != null)
            {
                m_OldStyle = style.Clone();
            }
            m_Style = style;
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
                checkBoxUseOutlineStyle.Checked = (geoStyle3d.OutlineStyle != null);
                buttonSetLineStyle.Enabled = checkBoxUseOutlineStyle.Checked;
            }
          
        }
        private void FrmPolygonStyleSetting_Load(object sender, EventArgs e)
        {
            SetControlsByStyle(m_Style);
        }
        private void fillColorChanged()
        {
           
            GSOSimplePolygonStyle3D geoStyle3d = m_Style as GSOSimplePolygonStyle3D;
            if (geoStyle3d != null)
            {
                geoStyle3d.FillColor = Color.FromArgb(Convert.ToByte(numericUpDownFillOpaque.Value), pictureBoxFillColor.BackColor);
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
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

        private void checkBoxUseOutlineStyle_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxUseOutlineStyle.Checked;
            buttonSetLineStyle.Enabled = bChecked;

            GSOSimplePolygonStyle3D geoStyle3d = m_Style as GSOSimplePolygonStyle3D;
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

        private void buttonSetLineStyle_Click(object sender, EventArgs e)
        {
             
            GSOSimplePolygonStyle3D geoStyle3d = m_Style as GSOSimplePolygonStyle3D;
            if (geoStyle3d != null)
            {
                FrmSetLineStyle dlg = new FrmSetLineStyle(geoStyle3d.OutlineStyle, m_GlobeControl);
                dlg.Show(this);
            }
             
        }

        private void checkBoxFill_CheckedChanged(object sender, EventArgs e)
        {
             
            GSOSimplePolygonStyle3D geoStyle3d =m_Style as GSOSimplePolygonStyle3D;
            if (geoStyle3d != null)
            {
                geoStyle3d.Fill = checkBoxFill.Checked;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
             
        }

        private void checkBoxOutline_CheckedChanged(object sender, EventArgs e)
        {
             
            GSOSimplePolygonStyle3D geoStyle3d = m_Style as GSOSimplePolygonStyle3D;
            if (geoStyle3d != null)
            {
                geoStyle3d.OutLineVisible = checkBoxOutline.Checked;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
             
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // 如果取消的话，将备份的拷贝回来
            if (m_Style != null)
            {
                m_Style.Copy(m_OldStyle);
                m_GlobeControl.Refresh();
            }
            this.Close();
        }
    }
}
