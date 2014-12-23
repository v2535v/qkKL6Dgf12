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
    public partial class CtrlSimpleLineStylePage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        public GSOStyle oldStyle = null;

        public CtrlSimpleLineStylePage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void CtrlLineStylePage_Load(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                oldStyle = m_Geometry.Style;
                SetControlsByStyle(m_Geometry.Style);
            }
        }

        private void CheckControlsEnable(bool bValue)
        {
            pictureBoxLineColor.Enabled = bValue;
            numericUpDownLineOpaque.Enabled = bValue;
            textBoxLineWidth.Enabled = bValue;
            comboBoxLineType.Enabled = bValue;
        }

        GSOSimpleLineStyle3D simpleLineStyle3D = null;
        private void SetControlsByStyle(GSOStyle style)
        {
            simpleLineStyle3D = style as GSOSimpleLineStyle3D;
            if (simpleLineStyle3D != null)
            {

                // 这句要写到前面，不然下面Checked的时候要检查
                pictureBoxLineColor.BackColor = Color.FromArgb(255, simpleLineStyle3D.LineColor);
                numericUpDownLineOpaque.Value = simpleLineStyle3D.LineColor.A;
                textBoxLineWidth.Text = simpleLineStyle3D.LineWidth.ToString();

                switch (simpleLineStyle3D.LineType)
                {
                    case EnumLineType.Solid:
                        comboBoxLineType.SelectedIndex = 0;
                        break;
                    case EnumLineType.Dash:
                        comboBoxLineType.SelectedIndex = 1;
                        break;
                    case EnumLineType.Dot:
                        comboBoxLineType.SelectedIndex = 2;
                        break;
                    case EnumLineType.DashDot:
                        comboBoxLineType.SelectedIndex = 3;
                        break;
                    case EnumLineType.DashDotDot:
                        comboBoxLineType.SelectedIndex = 4;
                        break;
                }

                checkBoxUseStyle.Checked = true;                
            }
            else
            {
                simpleLineStyle3D = new GSOSimpleLineStyle3D();
                m_Geometry.Style = simpleLineStyle3D;
                checkBoxUseStyle.Checked = false;
            }

            CheckControlsEnable(checkBoxUseStyle.Checked);
        }

        private void lineColorChanged()
        {
            if (m_Geometry != null)
            {               
                if (simpleLineStyle3D != null)
                {
                    simpleLineStyle3D.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), pictureBoxLineColor.BackColor);
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }              
            }
        }
        private void pictureBoxLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxLineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxLineColor.BackColor = Color.FromArgb(255, dlg.Color);
                lineColorChanged();
            }

        }

        private void numericUpDownLineOpaque_ValueChanged(object sender, EventArgs e)
        {
            lineColorChanged();
        }

        private void textBoxLineWidth_TextChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                if (simpleLineStyle3D != null)
                {
                    try
                    {
                        simpleLineStyle3D.LineWidth = Convert.ToDouble(textBoxLineWidth.Text);
                        if (m_GlobeControl != null)
                        {
                            m_GlobeControl.Refresh();
                        }
                    }
                    catch (System.Exception exp)
                    {
                        Log.PublishTxt(exp);
                    } 
                }                
            }
        }

        private void comboBoxLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {               
                if (simpleLineStyle3D != null)
                {
                    switch (comboBoxLineType.SelectedIndex)
                    {
                        case 0:
                            simpleLineStyle3D.LineType = EnumLineType.Solid;
                            break;
                        case 1:
                            simpleLineStyle3D.LineType = EnumLineType.Dash;
                            break;
                        case 2:
                            simpleLineStyle3D.LineType = EnumLineType.Dot;
                            break;
                        case 3:
                            simpleLineStyle3D.LineType = EnumLineType.DashDot;
                            break;
                        case 4:
                            simpleLineStyle3D.LineType = EnumLineType.DashDotDot;
                            break;
                    }
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
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
                    m_Geometry.Style = oldStyle;
                }
            }
            else
            {
                if (m_Geometry != null )
                {
                    if (m_Geometry.Style == null)
                    {
                        m_Geometry.Style = new GSOSimpleLineStyle3D();
                    }
                    SetControlsByStyle(m_Geometry.Style);
                }
            }

            CheckControlsEnable(bChecked);
            if (m_GlobeControl != null)
            {
                m_GlobeControl.Refresh();
            }
        }
    }
}
