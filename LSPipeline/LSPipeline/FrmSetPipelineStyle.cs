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
    public partial class FrmSetPipelineStyle : Form
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOLayer mlayer = null;
        public GSOFeature mfeature = null;
        public GSOStyle m_OldStyle = null;
        public GSOStyle m_Style = null;
        public FrmSetPipelineStyle(GSOStyle style, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            // 如果m_OldStyle不存在，先备份一个
            if (style != null && m_OldStyle != null)
            {
                m_OldStyle = style.Clone();
            }
            m_Style = style;
        }
        public FrmSetPipelineStyle(GSOStyle style,GSOFeature feature,GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            mlayer = layer;
            mfeature = feature;

            // 如果m_OldStyle不存在，先备份一个
            if (style != null && m_OldStyle != null)
            {
                m_OldStyle = style.Clone();
            }
            m_Style = style;
        }

        private void SetControlsByStyle(GSOStyle style)
        {
            GSOPipeLineStyle3D geoStyle3d = m_Style as GSOPipeLineStyle3D;
            if (geoStyle3d != null)
            {
                // 这句要写到前面，不然下面Checked的时候要检查
                pictureBoxLineColor.BackColor = Color.FromArgb(255, geoStyle3d.LineColor);
                numericUpDownLineOpaque.Value = geoStyle3d.LineColor.A;
                textBoxLineRadius.Text = geoStyle3d.Radius.ToString();
                textBoxThickness.Text = geoStyle3d.Thickness.ToString();
                textBoxSlice.Text = geoStyle3d.Slice.ToString();
                textBoxCornerSliceAngle.Text = geoStyle3d.CornerSliceAngle.ToString();
            }
        }
        private void FormPipelineStyleSetting_Load(object sender, EventArgs e)
        {
            SetControlsByStyle(m_Style);
        }
        private void lineColorChanged()
        {
            GSOPipeLineStyle3D pipeLineStyle3D = m_Style as GSOPipeLineStyle3D;
            if (pipeLineStyle3D != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                pipeLineStyle3D.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), pictureBoxLineColor.BackColor);
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
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
            GSOPipeLineStyle3D pipeLineStyle3D = m_Style as GSOPipeLineStyle3D;
            if (pipeLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    pipeLineStyle3D.Radius = Convert.ToDouble(textBoxLineRadius.Text);
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

        private void textBoxThickness_TextChanged(object sender, EventArgs e)
        {
            GSOPipeLineStyle3D pipeLineStyle3D = m_Style as GSOPipeLineStyle3D;
            if (pipeLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    pipeLineStyle3D.Thickness = Convert.ToDouble(textBoxThickness.Text);
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

        private void textBoxCornerSliceAngle_TextChanged(object sender, EventArgs e)
        {
            GSOPipeLineStyle3D pipeLineStyle3D = m_Style as GSOPipeLineStyle3D;
            if (pipeLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    pipeLineStyle3D.CornerSliceAngle = Convert.ToDouble(textBoxCornerSliceAngle.Text);
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
        private void textBoxSlice_TextChanged(object sender, EventArgs e)
        {
            GSOPipeLineStyle3D pipeLineStyle3D = m_Style as GSOPipeLineStyle3D;
            if (pipeLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    pipeLineStyle3D.Slice = Convert.ToInt32(textBoxSlice.Text);
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
