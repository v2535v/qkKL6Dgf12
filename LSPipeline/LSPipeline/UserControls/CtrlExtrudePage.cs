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
    public partial class CtrlExtrudePage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        public CtrlExtrudePage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }
        private void CheckControlsEnable(bool bValue)
        {
            
            if (bValue)
            {
                tboxExtrudeValue.Enabled = true;
                if (m_Geometry != null && m_Geometry.ExtrudeStyle != null)
                {
                    if (m_Geometry.ExtrudeStyle.ExtrudeType==EnumExtrudeType.ExtrudeToGround)
                    {
                        tboxExtrudeValue.Enabled = false;

                    }
                    
                    // 对于线拉伸的末端还是线
                    if (m_Geometry.Type==EnumGeometryType.GeoPolyline3D)
                    {
                        buttonTailPartStyle.Text = "定义线风格";
                    }
                    else
                    {
                        buttonTailPartStyle.Text = "定义面风格";
                    }

                    buttonBodyPartStyle.Enabled = (m_Geometry.ExtrudeStyle.BodyStyle != null);
                    buttonTailPartStyle.Enabled = (m_Geometry.ExtrudeStyle.TailStyle != null);
                   
                }
            }
            else
            {
                buttonTailPartStyle.Enabled = false;
                buttonBodyPartStyle.Enabled = false;
                tboxExtrudeValue.Enabled = false;
                
            }
           
            
            cbbExtrudeType.Enabled = bValue;
            checkBoxUseBodyPartStyle.Enabled = bValue;
            checkBoxUseTailPartStyle.Enabled = bValue;
            checkBoxHeadPartVisible.Enabled = bValue;
            checkBoxBodyPartVisible.Enabled = bValue;
            checkBoxTailPartVisible.Enabled = bValue;


        }
        private void CtrlExtrudePage_Load(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                SetControlsByExtrudeStyle(m_Geometry.ExtrudeStyle);
            }
        }

       

        private void tboxExtrudeValue_TextChanged(object sender, EventArgs e)
        {
             if (m_Geometry != null && m_Geometry.ExtrudeStyle != null)
             {
                 try
                 {
                     m_Geometry.ExtrudeStyle.ExtrudeValue = Convert.ToDouble(tboxExtrudeValue.Text);
                     if (m_GlobeControl!=null)
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

        private void cbbExtrudeType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (m_Geometry != null && m_Geometry.ExtrudeStyle != null)
            {
                switch (cbbExtrudeType.SelectedIndex)
                {
                    case 0:
                        m_Geometry.ExtrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeValue;
                        tboxExtrudeValue.Enabled = true;
                        break;
                    case 1:
                        m_Geometry.ExtrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeToValue;
                        tboxExtrudeValue.Enabled = true;
                        break;
                    case 2:
                        m_Geometry.ExtrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeToGround;
                        tboxExtrudeValue.Enabled = false;
                        break;
                  
                   
                }
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }

       
        private void SetControlsByExtrudeStyle(GSOExtrudeStyle extrudeStyle)
        {
           
            if (extrudeStyle != null)
            {

                tboxExtrudeValue.Text=extrudeStyle.ExtrudeValue.ToString();                

                switch (extrudeStyle.ExtrudeType)
                {
                    case EnumExtrudeType.ExtrudeValue:
                        cbbExtrudeType.SelectedIndex = 0;
                        break;
                    case EnumExtrudeType.ExtrudeToValue:
                        cbbExtrudeType.SelectedIndex = 1;
                        break;
                    case EnumExtrudeType.ExtrudeToGround:
                        cbbExtrudeType.SelectedIndex = 2;
                        break;
                  
                    
                }

             
                checkBoxUseBodyPartStyle.Checked = (extrudeStyle.BodyStyle != null);
                checkBoxUseTailPartStyle.Checked = (extrudeStyle.TailStyle != null);

                
                checkBoxHeadPartVisible.Checked=extrudeStyle.HeadPartVisible;
                checkBoxBodyPartVisible.Checked = extrudeStyle.BodyPartVisible;
                checkBoxTailPartVisible.Checked = extrudeStyle.TailPartVisible;
                
                // 这句要写到最后
                checkBoxUseExturde.Checked = true;
            }
            else
            {
                checkBoxUseExturde.Checked = false;

            }

            CheckControlsEnable(checkBoxUseExturde.Checked);


        }
        private void checkBoxUseExturde_CheckedChanged(object sender, EventArgs e)
        {


            bool bChecked = checkBoxUseExturde.Checked;

            if (!bChecked)
            {
                // 清除风格
                if (m_Geometry.ExtrudeStyle != null)
                {
                    m_Geometry.ExtrudeStyle = null;
                }


            }
            else
            {

                if (m_Geometry != null && m_Geometry.ExtrudeStyle == null)
                {
                    m_Geometry.ExtrudeStyle = new GSOExtrudeStyle();
                    SetControlsByExtrudeStyle(m_Geometry.ExtrudeStyle);
                }

            }

            CheckControlsEnable(bChecked);
            if (m_GlobeControl != null)
            {
                m_GlobeControl.Refresh();
            }

        }

        private void checkBoxHeadPartVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null && m_Geometry.ExtrudeStyle != null)
            {
                m_Geometry.ExtrudeStyle.HeadPartVisible = checkBoxHeadPartVisible.Checked;
                if (m_GlobeControl!=null)
                {
                    m_GlobeControl.Refresh();
                }
            }

        }

        private void checkBoxTailPartVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null && m_Geometry.ExtrudeStyle != null)
            {
                m_Geometry.ExtrudeStyle.TailPartVisible = checkBoxTailPartVisible.Checked;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }

        }

        private void checkBoxBodyPartVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null && m_Geometry.ExtrudeStyle != null)
            {
                m_Geometry.ExtrudeStyle.BodyPartVisible = checkBoxBodyPartVisible.Checked;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }

        }

        private void checkBoxUseBodyPartStyle_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxUseBodyPartStyle.Checked;
            buttonBodyPartStyle.Enabled = bChecked;


            if (m_Geometry != null && m_Geometry.ExtrudeStyle!=null)
            {
                if (!bChecked)
                {
                    // 清除立面风格
                    m_Geometry.ExtrudeStyle.BodyStyle = null;
                }
                else
                {
                    if (m_Geometry.ExtrudeStyle.BodyStyle == null)
                    {
                        // 如果不存在就创建一个新的
                        m_Geometry.ExtrudeStyle.BodyStyle = new GSOSimplePolygonStyle3D();
                    }

                }

                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }

                 
            }
        }

        private void checkBoxUseTailPartStyle_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxUseTailPartStyle.Checked;
            buttonTailPartStyle.Enabled = bChecked;


            if (m_Geometry != null && m_Geometry.ExtrudeStyle != null)
            {
                // 线拉伸后的末端仍然是线
                if (m_Geometry.Type==EnumGeometryType.GeoPolyline3D)
                {
                    if (!bChecked)
                    {
                        // 清除末端风格
                        m_Geometry.ExtrudeStyle.TailStyle = null;
                    }
                    else
                    {
                        if (m_Geometry.ExtrudeStyle.TailStyle == null)
                        {
                            // 如果不存在就创建一个新的
                            m_Geometry.ExtrudeStyle.TailStyle = new GSOSimpleLineStyle3D();
                        }

                    }

                }
                else
                {
                     
                    if (!bChecked)
                    {
                        // 清除末端风格
                        m_Geometry.ExtrudeStyle.TailStyle = null;
                    }
                    else
                    {
                        if (m_Geometry.ExtrudeStyle.TailStyle == null)
                        {
                            // 如果不存在就创建一个新的
                            m_Geometry.ExtrudeStyle.TailStyle = new GSOSimplePolygonStyle3D();
                        }

                    }
                 

                }
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }

               
            }
        }

        private void buttonBodyPartStyle_Click(object sender, EventArgs e)
        {
            if (m_Geometry != null && m_Geometry.ExtrudeStyle!=null)
            {
                GSOSimplePolygonStyle3D geoStyle3d = m_Geometry.ExtrudeStyle.BodyStyle as GSOSimplePolygonStyle3D;
                if (geoStyle3d != null)
                {
                    FrmSetPolygonStyle dlg = new FrmSetPolygonStyle(geoStyle3d, m_GlobeControl);
                    dlg.Show(this);
                }
            }
        }

        private void buttonTailPartStyle_Click(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                if(m_Geometry.Type==EnumGeometryType.GeoPolyline3D)
                {
                    GSOSimpleLineStyle3D geoStyle3d = m_Geometry.ExtrudeStyle.TailStyle as GSOSimpleLineStyle3D;
                    if (geoStyle3d != null)
                    {
                        FrmSetLineStyle dlg = new FrmSetLineStyle(geoStyle3d, m_GlobeControl);
                        dlg.Show(this);
                    }

                }
                else
                {
                    GSOSimplePolygonStyle3D geoStyle3d = m_Geometry.ExtrudeStyle.TailStyle as GSOSimplePolygonStyle3D;
                    if (geoStyle3d != null)
                    {
                        FrmSetPolygonStyle dlg = new FrmSetPolygonStyle(geoStyle3d, m_GlobeControl);
                        dlg.Show(this);
                    }

                }
               
            }

        }
    }
}
