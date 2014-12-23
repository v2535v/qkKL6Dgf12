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
    public partial class CtrlEntityStylePage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOFeature m_feature = null;
        //public GSOGeometry m_feature.Geometry = null;
        public CtrlEntityStylePage(GSOFeature feature, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_feature = feature;
        }

        private void CtrlEntityStylePage_Load(object sender, EventArgs e)
        {
            if (m_feature.Geometry != null)
            {
                SetControlsByStyle(m_feature.Geometry.Style);
            }
        }
        private void CheckControlsEnable(bool bValue)
        {
            checkBoxLight.Enabled = bValue;
            checkBoxTexture.Enabled = bValue;
            checkBoxUseSingleColor.Enabled = bValue;
            checkBoxBothFace.Enabled = bValue;
            comboBoxPolygonMode.Enabled = bValue;
           
            pictureBoxModelColor.Enabled = checkBoxUseSingleColor.Checked;
            numericUpDownModelOpaque.Enabled = checkBoxUseSingleColor.Checked;
        }
        private void SetControlsByStyle(GSOStyle style)
        {
            GSOEntityStyle3D geoStyle3d = style as GSOEntityStyle3D;
            if (geoStyle3d != null)
            {
                // 这句要写到前面，不然下面Checked的时候要检查
                pictureBoxModelColor.BackColor = geoStyle3d.EntityColor;
                numericUpDownModelOpaque.Value = geoStyle3d.EntityColor.A;

                switch (geoStyle3d.PolygonMode)
                {
                    case EnumPolygonMode.Solid:
                        comboBoxPolygonMode.SelectedIndex = 0;
                        break;
                    case EnumPolygonMode.Wireframe:
                        comboBoxPolygonMode.SelectedIndex = 1;
                        break;
                    case EnumPolygonMode.Points:
                        comboBoxPolygonMode.SelectedIndex = 2;
                        break;
                }                 

                checkBoxUseSingleColor.Checked = geoStyle3d.UsingSingleColor;
                checkBoxTexture.Checked = geoStyle3d.UsingTexture;
                checkBoxLight.Checked = geoStyle3d.UsingLight;
                checkBoxBothFace.Checked = geoStyle3d.UsingBothFace;

                checkBoxUseStyle.Checked = true;
            }
            else
            {
                checkBoxUseStyle.Checked = false;
            }

            CheckControlsEnable(checkBoxUseStyle.Checked);
        }

        private void checkBoxUseStyle_CheckedChanged(object sender, EventArgs e)
        {             
            bool bChecked = checkBoxUseStyle.Checked;

            if (!bChecked)
            {
                // 清除风格
                if (m_feature.Geometry != null)
                {
                    m_feature.Geometry.Style = null;
                }
            }
            else
            {
                if (m_feature.Geometry!=null && m_feature.Geometry.Style == null)
                {
                    m_feature.Geometry.Style = new GSOEntityStyle3D();
                    SetControlsByStyle(m_feature.Geometry.Style);
                }
            }

            CheckControlsEnable(bChecked);
            if (m_GlobeControl!=null)
            {
                m_GlobeControl.Refresh();
            }            
        }

        private void checkBoxUseSingleColor_CheckedChanged(object sender, EventArgs e)
        {          
            bool bChecked = checkBoxUseSingleColor.Checked;
            pictureBoxModelColor.Enabled = bChecked;
            numericUpDownModelOpaque.Enabled = bChecked;

            if (m_feature.Geometry != null)
            {
                GSOEntityStyle3D geoEntityStyle = m_feature.Geometry.Style as GSOEntityStyle3D;
                if (geoEntityStyle != null)
                {
                    geoEntityStyle.UsingSingleColor = bChecked;
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }                 
            }           
        }
        private void entityColorChanged()
        {
            if (m_feature.Geometry != null)
            {
                GSOEntityStyle3D geoStyle3d = m_feature.Geometry.Style as GSOEntityStyle3D;
                if (geoStyle3d != null)
                {
                    geoStyle3d.EntityColor = Color.FromArgb(Convert.ToByte(numericUpDownModelOpaque.Value), pictureBoxModelColor.BackColor);
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }
            }
        }
        private void pictureBoxModelColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxModelColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxModelColor.BackColor = dlg.Color;
                entityColorChanged();                
            }
        }

        private void numericUpDownModelOpaque_ValueChanged(object sender, EventArgs e)
        {
            entityColorChanged();          
        }

        private void comboBoxPolygonMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_feature.Geometry==null)
            {
                return;
            }
            GSOEntityStyle3D geoStyle3d = m_feature.Geometry.Style as GSOEntityStyle3D;
            if (geoStyle3d != null)
            {
                switch (comboBoxPolygonMode.SelectedIndex)
                {
                    case 0:
                        geoStyle3d.PolygonMode = EnumPolygonMode.Solid;
                        break;
                    case 1:
                        geoStyle3d.PolygonMode = EnumPolygonMode.Wireframe;
                        break;
                    case 2:
                        geoStyle3d.PolygonMode = EnumPolygonMode.Points;
                        break;
                }
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }

       
        private void checkBoxLight_CheckedChanged(object sender, EventArgs e)
        {
            if (m_feature.Geometry == null)
            {
                return;
            }
            GSOEntityStyle3D geoStyle3d = m_feature.Geometry.Style as GSOEntityStyle3D;
            if (geoStyle3d != null)
            {
                geoStyle3d.UsingLight = checkBoxLight.Checked;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }

        private void checkBoxTexture_CheckedChanged(object sender, EventArgs e)
        {
            if (m_feature.Geometry == null)
            {
                return;
            }
            GSOEntityStyle3D geoStyle3d = m_feature.Geometry.Style as GSOEntityStyle3D;
            if (geoStyle3d != null)
            {
                geoStyle3d.UsingTexture = checkBoxTexture.Checked;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }

        private void checkBoxBothFace_CheckedChanged(object sender, EventArgs e)
        {
            if (m_feature.Geometry == null)
            {
                return;
            }
            GSOEntityStyle3D geoStyle3d = m_feature.Geometry.Style as GSOEntityStyle3D;
            if (geoStyle3d != null)
            {
                geoStyle3d.UsingBothFace = checkBoxBothFace.Checked;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }         
    }
}
