using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace WorldGIS
{
    public partial class FrmDecjointPipeline : Form
    {
        private GSOPipeLineStyle3D m_style;
        private GSOPipeLineStyle3D m_oldStyle;
        private GSOGlobe m_globe;
        private Boolean m_bInitialized = false;
        public FrmDecjointPipeline(GSOGlobe globe, GSOPipeLineStyle3D style)
        {
            InitializeComponent();
            m_globe = globe; 
            m_style = style;
            if (style!=null)
            {
                m_oldStyle = (GSOPipeLineStyle3D)style.Clone();
            }
            m_bInitialized = false;
           
        }
        private void buttOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttCancel_Click(object sender, EventArgs e)
        {
            if (m_style != null && m_oldStyle!=null)
            {
                m_style.Copy(m_oldStyle);
                // 标记并未修改
                m_style.SetModified(false);
            }
            this.Close();
        }

        private void FrmDecjointPipeline_Load(object sender, EventArgs e)
        {
            GSOPipeJointParam headJointParam = m_style.HeadJointParam;
            if (headJointParam != null && headJointParam.Extent<0)
            {
                cboxHead.Checked = true;
                tBoxHeadDecValue.Text = (-headJointParam.Extent).ToString();
            }
            else
            {
                tBoxHeadDecValue.Text = m_globe.DecjointValue.ToString();
            }

            GSOPipeJointParam tailJointParam = m_style.TailJointParam;
            if (tailJointParam != null && tailJointParam.Extent < 0)
            {
                cboxTail.Checked = true;
                tBoxTailDecValue.Text = (-tailJointParam.Extent).ToString();
            }
            else
            {
                tBoxTailDecValue.Text = m_globe.DecjointValue.ToString();
            }

            m_bInitialized = true;
        }
        void CheckChangeHeadJoint()
        {
            // 先恢复，再设置
            if (!m_bInitialized || m_style == null || m_oldStyle == null)
            {
                return;
            }

            // 先恢复一下
            if (m_oldStyle.HeadJointParam==null)
            {
                m_style.HeadJointParam = null;
            }
            else
            {
                m_style.HeadJointParam = m_oldStyle.HeadJointParam;
            }
            GSOPipeJointParam headJointParam = m_style.HeadJointParam;
            if (cboxHead.Checked)
            {

                if (headJointParam == null)
                {
                    headJointParam = new GSOPipeJointParam();
                }
                float fValue = 0;
                if (float.TryParse(tBoxHeadDecValue.Text, out fValue))
                {
                    if (!(fValue < 0))
                    {
                        headJointParam.Extent = -fValue;
                        m_style.HeadJointParam = headJointParam;
                    }

                }


            }
            else
            {
                if (headJointParam != null && headJointParam.Extent < 0)
                {
                    m_style.HeadJointParam = null;
                }

            }

        }
        void CheckChangeTailJoint()
        {


            // 先恢复，再设置
            if (!m_bInitialized || m_style == null || m_oldStyle == null)
            {
                return;
            }

            // 先恢复一下
            if (m_oldStyle.TailJointParam == null)
            {
                m_style.TailJointParam = null;
            }
            else
            {
                m_style.TailJointParam = m_oldStyle.TailJointParam;
            }
            GSOPipeJointParam tailJointParam = m_style.TailJointParam;
            if (cboxTail.Checked)
            {

                if (tailJointParam == null)
                {
                    tailJointParam = new GSOPipeJointParam();
                }
                float fValue = 0;
                if (float.TryParse(tBoxTailDecValue.Text, out fValue))
                {
                    if (!(fValue < 0))
                    {
                        tailJointParam.Extent = -fValue;
                        m_style.TailJointParam = tailJointParam;
                    }

                }


            }
            else
            {
                if (tailJointParam != null && tailJointParam.Extent < 0)
                {
                    m_style.TailJointParam = null;
                }

            }

        }
         
         
        private void cboxHead_CheckedChanged(object sender, EventArgs e)
        {
            CheckChangeHeadJoint();
            m_globe.Refresh();
            
        }
        private void cboxTail_CheckedChanged(object sender, EventArgs e)
        {
            CheckChangeTailJoint();
            m_globe.Refresh();
            
        }

        private void tBoxHeadDecValue_TextChanged(object sender, EventArgs e)
        {
            float fValue=0;
            if (float.TryParse(tBoxHeadDecValue.Text, out fValue))
            {
                if (!(fValue < 0))
                {
                    m_globe.DecjointValue = fValue;
                    CheckChangeHeadJoint();
                    m_globe.Refresh();
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
                    m_globe.DecjointValue = fValue;
                    CheckChangeTailJoint();
                    m_globe.Refresh();
                }
            }
        }   
    }
}
