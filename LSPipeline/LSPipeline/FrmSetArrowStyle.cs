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
    public partial class FrmSetArrowStyle : Form
    {

        public GSOGlobeControl m_GlobeControl = null;
        public GSOLayer mlayer = null;
        public GSOFeature mfeature = null;
        public GSOArrowStyle m_OldStyle = null;
        public GSOArrowStyle m_Style = null;
     
        public FrmSetArrowStyle(GSOArrowStyle style, GSOGlobeControl globeControl)
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

        public FrmSetArrowStyle(GSOArrowStyle style, GSOFeature feature, GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            mlayer = layer;
            mfeature = feature;

            // 如果m_OldStyle不存在，先备份一个
            if (style != null)
            {
                m_OldStyle = style.Clone();
            }
            m_Style = style;
        }

        private void SetControlsByStyle(GSOArrowStyle style)
        {
            if (style != null)
            {
                pboxArrowColor.BackColor = Color.FromArgb(255, style.ArrowColor);
                nudArrowOpaque.Value = style.ArrowColor.A;

                pboxOutlineColor.BackColor = Color.FromArgb(255, style.OutlineColor);
                nudOutlineOpaque.Value = style.OutlineColor.A;

                tboxArrowGap.Text = style.ArrowGap.ToString();
                tboxBodyLen.Text = style.BodyLen.ToString();
                tboxBodyWidth.Text = style.BodyWidth.ToString();
                tboxHeadLen.Text = style.HeadLen.ToString();
                tboxHeadWidth.Text = style.HeadWidth.ToString();
                tboxOutlineWidth.Text = style.OutlineWidth.ToString();

                cboxAlongCenter.Checked = style.IsAlongCenter;
                cboxPixelLen.Checked = style.UsingPixelLen;
                cboxAlwaysSee.Checked = !style.UsingDepthTest;
                cboxNegDir.Checked = style.IsNegtiveDir;
                cbxOutlineVisible.Checked = style.OutlineVisible;

                CheckOutlineControlsEnable(cbxOutlineVisible.Checked);

                switch (style.OutlineType)
                {
                    case EnumLineType.Solid:
                        comboxOutlineType.SelectedIndex = 0;
                        break;
                    case EnumLineType.Dash:
                        comboxOutlineType.SelectedIndex = 1;
                        break;
                    case EnumLineType.Dot:
                        comboxOutlineType.SelectedIndex = 2;
                        break;
                    case EnumLineType.DashDot:
                        comboxOutlineType.SelectedIndex = 3;
                        break;
                    case EnumLineType.DashDotDot:
                        comboxOutlineType.SelectedIndex = 4;
                        break;
                }

                switch (style.ArrowShape)
                {
                    case EnumArrowShape.Shape2D0:
                        comboxArrowShape.SelectedIndex = 0;
                        break;
                    case EnumArrowShape.Shape2D1:
                        comboxArrowShape.SelectedIndex = 1;
                        break;
                    case EnumArrowShape.Shape2D2:
                        comboxArrowShape.SelectedIndex = 2;
                        break;
                    case EnumArrowShape.Shape2D3:
                        comboxArrowShape.SelectedIndex = 3;
                        break;
                    case EnumArrowShape.Shape3D:
                        comboxArrowShape.SelectedIndex = 4;
                        break;
                         
                }
            }
        }
        private void CheckOutlineControlsEnable(Boolean bChecked)
        {          
            grpOutlineStyle.Enabled = bChecked;
        }
        private void FrmArrowStyleSetting_Load(object sender, EventArgs e)
        {
            SetControlsByStyle(m_Style);
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
                RefreshGlobe(m_OldStyle);
            }
            this.Close();
        }

        private void arrowColorChanged()
        {
            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                m_Style.ArrowColor = Color.FromArgb(Convert.ToByte(nudArrowOpaque.Value), pboxArrowColor.BackColor);
                RefreshGlobe(m_Style);
            }
        }

        private void pboxArrowColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pboxArrowColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pboxArrowColor.BackColor = Color.FromArgb(255, dlg.Color);
                arrowColorChanged();
            }
        }

        private void nudArrowOpaque_ValueChanged(object sender, EventArgs e)
        {
            arrowColorChanged();               
        }

        private void outlineColorChanged()
        {
            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                m_Style.OutlineColor = Color.FromArgb(Convert.ToByte(nudOutlineOpaque.Value), pboxOutlineColor.BackColor);
                RefreshGlobe(m_Style);
            }
        }
        private void pboxOutlineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pboxOutlineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pboxOutlineColor.BackColor = Color.FromArgb(255, dlg.Color);
                outlineColorChanged();
            }
        }       

        private void nudOutlineOpaque_ValueChanged(object sender, EventArgs e)
        {
            outlineColorChanged();
        }

        private void tboxBodyLen_TextChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                float dResult;
                if (float.TryParse(tboxBodyLen.Text, out dResult))
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    m_Style.BodyLen = dResult;
                    RefreshGlobe(m_Style);
                }
            }
        }

        private void tboxBodyWidth_TextChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                float dResult;
                if (float.TryParse(tboxBodyWidth.Text, out dResult))
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    m_Style.BodyWidth = dResult;
                    RefreshGlobe(m_Style);
                }
            }
        }

        private void tboxHeadLen_TextChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                float dResult;
                if (float.TryParse(tboxHeadLen.Text, out dResult))
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    m_Style.HeadLen = dResult;
                    RefreshGlobe(m_Style);
                }
            }
        }

        private void tboxHeadWidth_TextChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                float dResult;
                if (float.TryParse(tboxHeadWidth.Text, out dResult))
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    m_Style.HeadWidth = dResult;
                    RefreshGlobe(m_Style);
                }
            }
        }

        private void tboxArrowGap_TextChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                float dResult;
                if (float.TryParse(tboxArrowGap.Text, out dResult))
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    m_Style.ArrowGap = dResult;
                    RefreshGlobe(m_Style);
                }
            }
        }

        private void cboxAlwaysSee_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                m_Style.UsingDepthTest = !cboxAlwaysSee.Checked;
                RefreshGlobe(m_Style);              
            }            
        }

        private void cboxPixelLen_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                m_Style.UsingPixelLen = cboxPixelLen.Checked;
                RefreshGlobe(m_Style);
            }
        }

        private void cboxNegDir_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                m_Style.IsNegtiveDir = cboxNegDir.Checked;
                RefreshGlobe(m_Style);
            }
        }

        private void cboxAlongCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                m_Style.IsAlongCenter = cboxAlongCenter.Checked;
                RefreshGlobe(m_Style);
            }
        }

        private void cbxOutlineVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                m_Style.OutlineVisible = cbxOutlineVisible.Checked;
                CheckOutlineControlsEnable(cbxOutlineVisible.Checked);
                RefreshGlobe(m_Style);
            }
        }

        private void tboxOutlineWidth_TextChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                float dResult;
                if (float.TryParse(tboxOutlineWidth.Text, out dResult))
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    m_Style.OutlineWidth = dResult;
                    RefreshGlobe(m_Style);
                }
            }
        }

        private void comboxOutlineType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                switch (comboxOutlineType.SelectedIndex)
                {
                    case 0:
                        m_Style.OutlineType = EnumLineType.Solid;
                        break;
                    case 1:
                        m_Style.OutlineType = EnumLineType.Dash;
                        break;
                    case 2:
                        m_Style.OutlineType = EnumLineType.Dot;
                        break;
                    case 3:
                        m_Style.OutlineType = EnumLineType.DashDot;
                        break;
                    case 4:
                        m_Style.OutlineType = EnumLineType.DashDotDot;
                        break;
                }
                RefreshGlobe(m_Style);
            }
        }

        private void comboxArrowShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Style != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                switch (comboxArrowShape.SelectedIndex)
                {
                    case 0:
                        m_Style.ArrowShape = EnumArrowShape.Shape2D0;
                        break;
                    case 1:
                        m_Style.ArrowShape = EnumArrowShape.Shape2D1;
                        break;
                    case 2:
                        m_Style.ArrowShape = EnumArrowShape.Shape2D2;
                        break;
                    case 3:
                        m_Style.ArrowShape = EnumArrowShape.Shape2D3;
                        break;
                    case 4:
                        m_Style.ArrowShape = EnumArrowShape.Shape3D;
                        break;
                }
                RefreshGlobe(m_Style);
            }
        }
        private void RefreshGlobe(GSOArrowStyle m_Style)
        {
            ((GSOLineStyle3D)mfeature.Geometry.Style).ArrowVisible = true;
            ((GSOLineStyle3D)mfeature.Geometry.Style).ArrowStyle = m_Style;
            if (m_GlobeControl != null)
            {
                m_GlobeControl.Refresh();
            }
        }
    }
}
