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
    public partial class CtrlPipelineStyleSetting : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOLayer mlayer = null;
        public GSOFeature mfeature = null;
        public GSOStyle m_OldStyle = null;
        public GSOStyle m_Style = null;
        EnumAltitudeMode altituMode = EnumAltitudeMode.RelativeToGround;
        bool m_bInitialized = false;
        public CtrlPipelineStyleSetting(GSOStyle style, GSOGlobeControl globeControl)
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
        public CtrlPipelineStyleSetting(GSOStyle style, GSOFeature feature, GSOLayer layer, GSOGlobeControl globeControl)
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

        GSOPipeLineStyle3D pipeLineStyle3D = null;
        private void SetControlsByStyle(GSOStyle style)
        {
            if (m_Style != null)
            {
                pipeLineStyle3D = m_Style as GSOPipeLineStyle3D;
                if (pipeLineStyle3D == null)
                {
                    pipeLineStyle3D = new GSOPipeLineStyle3D();
                    RefreshGlobe(pipeLineStyle3D);
                }
            }
            else
            {
                pipeLineStyle3D = new GSOPipeLineStyle3D();
                RefreshGlobe(pipeLineStyle3D);
            }
            // 这句要写到前面，不然下面Checked的时候要检查
            pictureBoxLineColor.BackColor = Color.FromArgb(255, pipeLineStyle3D.LineColor);
            numericUpDownLineOpaque.Value = pipeLineStyle3D.LineColor.A;
            textBoxLineRadius.Text = pipeLineStyle3D.Radius.ToString();
            textBoxThickness.Text = pipeLineStyle3D.Thickness.ToString();
            textBoxSlice.Text = pipeLineStyle3D.Slice.ToString();
            textBoxCornerSliceAngle.Text = pipeLineStyle3D.CornerSliceAngle.ToString();

            GSOPipeJointParam headJointParam = pipeLineStyle3D.HeadJointParam;
            if (headJointParam != null && headJointParam.Extent < 0)
            {

                tBoxHeadDecValue.Text = (-headJointParam.Extent).ToString();
            }
            else
            {
                //tBoxHeadDecValue.Text = m_GlobeControl.Globe.DecjointValue.ToString();
            }

            GSOPipeJointParam tailJointParam = pipeLineStyle3D.TailJointParam;
            if (tailJointParam != null && tailJointParam.Extent < 0)
            {

                tBoxTailDecValue.Text = (-tailJointParam.Extent).ToString();
            }
            else
            {
                //tBoxTailDecValue.Text = m_GlobeControl.Globe.DecjointValue.ToString();
            }

            m_bInitialized = true;
        }

        private void lineColorChanged()
        {
            if (pipeLineStyle3D != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                pipeLineStyle3D.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), pictureBoxLineColor.BackColor);
                RefreshGlobe(pipeLineStyle3D);
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
            if (pipeLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    pipeLineStyle3D.Radius = Convert.ToDouble(textBoxLineRadius.Text);
                    RefreshGlobe(pipeLineStyle3D);
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }

        private void textBoxThickness_TextChanged(object sender, EventArgs e)
        {
            if (pipeLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    pipeLineStyle3D.Thickness = Convert.ToDouble(textBoxThickness.Text);
                    RefreshGlobe(pipeLineStyle3D);
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }

        private void textBoxSlice_TextChanged(object sender, EventArgs e)
        {
            if (pipeLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    pipeLineStyle3D.Slice = Convert.ToInt32(textBoxSlice.Text);
                    RefreshGlobe(pipeLineStyle3D);
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }


        private void textBoxCornerSliceAngle_TextChanged(object sender, EventArgs e)
        {
            if (pipeLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    pipeLineStyle3D.CornerSliceAngle = Convert.ToDouble(textBoxCornerSliceAngle.Text);
                    RefreshGlobe(pipeLineStyle3D);
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }


        //缩进接头
        void CheckChangeHeadJoint()
        {
            GSOPipeLineStyle3D geoStyle3dOld = m_OldStyle as GSOPipeLineStyle3D;
            GSOPipeJointParam headJointParam = null;
            float fValue = 0;
            if (pipeLineStyle3D != null)
            {
                // 先恢复，再设置
                if (!m_bInitialized || pipeLineStyle3D == null || geoStyle3dOld == null)
                {
                    if (headJointParam == null)
                    {
                        headJointParam = new GSOPipeJointParam();
                    }

                    if (float.TryParse(tBoxHeadDecValue.Text, out fValue))
                    {
                        if (!(fValue < 0))
                        {
                            headJointParam.Extent = -fValue;
                            pipeLineStyle3D.HeadJointParam = headJointParam;
                        }
                    }

                    if (headJointParam != null && headJointParam.Extent < 0)
                    {
                        //pipeLineStyle3D.HeadJointParam = null;
                        headJointParam = null;
                    }
                    return;
                }
                headJointParam = geoStyle3dOld.HeadJointParam;
                // 先恢复一下
                if (geoStyle3dOld.HeadJointParam == null)
                {
                    pipeLineStyle3D.HeadJointParam = null;
                }
                else
                {
                    pipeLineStyle3D.HeadJointParam = geoStyle3dOld.HeadJointParam;
                }


                if (headJointParam == null)
                {
                    headJointParam = new GSOPipeJointParam();
                }
                //float fValue = 0;
                if (float.TryParse(tBoxHeadDecValue.Text, out fValue))
                {
                    if (!(fValue < 0))
                    {
                        headJointParam.Extent = -fValue;
                        pipeLineStyle3D.HeadJointParam = headJointParam;
                    }
                }

                if (headJointParam != null && headJointParam.Extent < 0)
                {
                    //pipeLineStyle3D.HeadJointParam = null;
                    headJointParam = null;
                }
            }
        }
        void CheckChangeTailJoint()
        {
            GSOPipeLineStyle3D geoStyle3dOld = m_OldStyle as GSOPipeLineStyle3D;
            GSOPipeJointParam tailJointParam = null;
            float fValue = 0;
            if (pipeLineStyle3D != null)
            {
                // 先恢复，再设置
                if (!m_bInitialized || pipeLineStyle3D == null || geoStyle3dOld == null)
                {
                    if (tailJointParam == null)
                    {
                        tailJointParam = new GSOPipeJointParam();
                    }
                    if (float.TryParse(tBoxTailDecValue.Text, out fValue))
                    {
                        if (!(fValue < 0))
                        {
                            tailJointParam.Extent = -fValue;
                            pipeLineStyle3D.TailJointParam = tailJointParam;
                        }
                    }
                    return;
                }

                // 先恢复一下
                if (geoStyle3dOld.TailJointParam == null)
                {
                    pipeLineStyle3D.TailJointParam = null;
                }
                else
                {
                    pipeLineStyle3D.TailJointParam = geoStyle3dOld.TailJointParam;
                }
                tailJointParam = pipeLineStyle3D.TailJointParam;

                if (tailJointParam == null)
                {
                    tailJointParam = new GSOPipeJointParam();
                }
                if (float.TryParse(tBoxTailDecValue.Text, out fValue))
                {
                    if (!(fValue < 0))
                    {
                        tailJointParam.Extent = -fValue;
                        pipeLineStyle3D.TailJointParam = tailJointParam;
                    }
                }
            }
        }

        private void tBoxHeadDecValue_TextChanged(object sender, EventArgs e)
        {
            float fValue = 0;
            if (float.TryParse(tBoxHeadDecValue.Text, out fValue))
            {
                if (!(fValue < 0))
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    //m_GlobeControl.Globe.DecjointValue = fValue;

                    CheckChangeHeadJoint();
                    RefreshGlobe(pipeLineStyle3D);
                }
            }
        }
        private void tBoxTailDecValue_TextChanged(object sender, EventArgs e)
        {
            float fValue = 0;
            if (float.TryParse(tBoxTailDecValue.Text, out fValue))
            {
                if (!(fValue < 0))
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    //m_GlobeControl.Globe.DecjointValue = fValue;
                    CheckChangeTailJoint();
                    RefreshGlobe(pipeLineStyle3D);
                }
            }
        }

        private void RefreshGlobe(GSOPipeLineStyle3D pipeLineStyle3D)
        {
            mfeature.Geometry.Style = pipeLineStyle3D;
            mfeature.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            if (m_GlobeControl != null)
            {
                m_GlobeControl.Globe.Refresh();
            }
        }
    }
}
