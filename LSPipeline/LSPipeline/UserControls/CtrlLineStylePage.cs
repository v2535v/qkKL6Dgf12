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
    public partial class CtrlLineStylePage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        GSOFeature mfeature = null;
        GSOLayer mlayer = null;
        public GSOGeometry m_Geometry = null;

        GSOLineStyle3D m_Style = null;
        GSOLineStyle3D m_OldStyle = null;
        private Boolean m_bInitialized = false;

        public CtrlLineStylePage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();

            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        public CtrlLineStylePage(GSOGeometry geometry,GSOFeature feature,GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();

            m_GlobeControl = globeControl;
            m_Geometry = geometry;
            mlayer = layer;
            mfeature = feature;

            if (m_Geometry != null && m_Geometry.Style != null)
            {
                m_Style = (GSOLineStyle3D)m_Geometry.Style;

                m_OldStyle = (GSOLineStyle3D)m_Geometry.Style.Clone();
            }
        }

        private void SetControlsByStyle(GSOStyle style)
        {            
            if (style != null)
            {
                GSOPipeLineStyle3D pipelineStyle = style as GSOPipeLineStyle3D;
                if (pipelineStyle != null)
                {
                    AddTabPages("pipelineStyle", "管线", new CtrlPipelineStyleSetting(pipelineStyle, mfeature, mlayer, m_GlobeControl));                    
                }
                else
                {
                    GSOSimpleLineStyle3D simpleLineStyle = style as GSOSimpleLineStyle3D;
                    if (simpleLineStyle != null)
                    {
                        AddTabPages("simpleLineStyle", "简单线", new CtrlLineStyleSetting(simpleLineStyle, mfeature, mlayer, m_GlobeControl));
                    }
                    else
                    {
                        GSOExtendSectionLineStyle3D extentSectionLineStyle = style as GSOExtendSectionLineStyle3D;
                        if (extentSectionLineStyle != null)
                        {
                            AddTabPages("extendSectionLineStyle", "管沟", new CtrlExtentSectionlineStyleSetting(extentSectionLineStyle, mfeature, mlayer, m_GlobeControl));
                        }
                    }
                }
                     
                checkBoxUseStyle.Checked = true;
                GSOLineStyle3D lineStyle = style as GSOLineStyle3D;
                if (lineStyle != null && lineStyle.ArrowVisible && lineStyle.ArrowStyle!=null)
                {
                    checkBoxShowArrow.Checked = true;
                }
                else
                {
                    checkBoxShowArrow.Checked = false;
                }
            }
            else
            {
                checkBoxUseStyle.Checked = false;
                checkBoxShowArrow.Checked = false;
            }

            CheckControlsEnable(checkBoxUseStyle.Checked);
        }
        private void CheckControlsEnable(bool bValue)
        {
            listViewStyle.Enabled = bValue;
            checkBoxShowArrow.Enabled = bValue;
            CheckArrowControlsEnable(checkBoxShowArrow.Checked);
            tabControl1.Enabled = bValue;
        }
        private void CheckArrowControlsEnable(bool bValue)
        {
            buttonArrowStyle.Enabled = bValue;
        }
        private void CtrlLineStylePage_Load(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                SetControlsByStyle(m_Geometry.Style);
            }
        }

        private void checkBoxUseStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                bool bChecked = checkBoxUseStyle.Checked;
                if (!bChecked)
                {
                    // 清除风格
                    m_Geometry.Style = m_OldStyle;
                }
                else
                {                 
                    CheckControlsEnable(bChecked);                    
                }
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }

        private void listViewStyle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listViewStyle.SelectedIndices.Count>0)
            {
                tabControl1.TabPages.Clear();
                GSOStyle oldStyle = null;
                EnumAltitudeMode oldAltMode = m_Geometry.AltitudeMode;
                // 先复制一个原来的哦，以便在对话框取消的时候恢复
                if (m_Geometry.Style != null)
                {
                    oldStyle = m_Geometry.Style.Clone();
                }
                if (listViewStyle.SelectedIndices[0]==0)
                {
                    GSOSimpleLineStyle3D simpleLineStyle =m_Geometry.Style as GSOSimpleLineStyle3D;
                    if(simpleLineStyle == null )
                    {
                        m_Geometry.Style = new GSOSimpleLineStyle3D();
                    }
                    
                    FrmSetLineStyle dlg = new FrmSetLineStyle(m_Geometry.Style,mfeature,mlayer,m_GlobeControl);
                    if (dlg.ShowDialog(this)==DialogResult.Cancel)
                    {
                        m_Geometry.Style = oldStyle;
                    }
                }
                else if (listViewStyle.SelectedIndices[0]==1)
                {
                    GSOPipeLineStyle3D pipeLineStyle = m_Geometry.Style as GSOPipeLineStyle3D;

                    // 管线暂不支持依地模式
                    if (m_Geometry.AltitudeMode==EnumAltitudeMode.ClampToGround)
                    {
                        m_Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                    }
                    if (pipeLineStyle == null)
                    {
                        m_Geometry.Style = new GSOPipeLineStyle3D();
                    }

                    FrmSetPipelineStyle dlg = new FrmSetPipelineStyle(m_Geometry.Style,mfeature,mlayer, m_GlobeControl);
                    
                    // 恢复一下
                    if (dlg.ShowDialog(this) == DialogResult.Cancel)
                    {
                        m_Geometry.Style = oldStyle;
                        m_Geometry.AltitudeMode = oldAltMode;

                    }
                }
            }
        }

     
        private void checkBoxShowArrow_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxShowArrow.Checked;
             // 清除风格
            if (m_Geometry != null && m_Geometry.Style!=null)
            {
                GSOLineStyle3D lineStyle = m_Geometry.Style as GSOLineStyle3D;
                if (lineStyle != null)
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    if (!bChecked)
                    {
                        lineStyle.ArrowVisible = false;
                    }
                    else
                    {
                        if (lineStyle.ArrowStyle==null)
                        {
                            lineStyle.ArrowStyle = new GSOArrowStyle();
                        }
                        lineStyle.ArrowVisible = true;
                    }
                }
            }
            CheckArrowControlsEnable(bChecked);
            if (m_GlobeControl != null)
            {
                m_GlobeControl.Refresh();
            }
        }

        private void buttonArrowStyle_Click(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                GSOLineStyle3D lineStyle = m_Geometry.Style as GSOLineStyle3D;
                if (lineStyle != null && lineStyle.ArrowStyle!=null)
                {
                    
                    FrmSetArrowStyle dlg = new FrmSetArrowStyle(lineStyle.ArrowStyle,mfeature,mlayer, m_GlobeControl);
                    dlg.Show(this);
                }
            }
        }

        private void listViewStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStyle.SelectedIndices.Count > 0)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                EnumAltitudeMode oldAltMode = m_Geometry.AltitudeMode;
                
                if (listViewStyle.SelectedIndices[0] == 0)
                {
                    AddTabPages("simpleLineStyle", "简单线", new CtrlLineStyleSetting(m_Geometry.Style, mfeature, mlayer, m_GlobeControl));
                }
                else if (listViewStyle.SelectedIndices[0] == 1)
                {
                    AddTabPages("pipelineStyle", "管线", new CtrlPipelineStyleSetting(m_Geometry.Style, mfeature, mlayer, m_GlobeControl));
                }
                else if (listViewStyle.SelectedIndices[0] == 2)
                {
                    AddTabPages("extendSectionLineStyle", "管沟", new CtrlExtentSectionlineStyleSetting(m_Geometry.Style, mfeature, mlayer, m_GlobeControl));
                }
            }
        }

        void AddTabPages(string key, string text, Control styleControl)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(key, text);
            tabControl1.TabPages[key].Controls.Add(styleControl);
        }       
    }
}
