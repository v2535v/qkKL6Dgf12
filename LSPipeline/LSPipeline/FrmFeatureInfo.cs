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
    public partial class FrmFeatureInfo : Form
    {
        static GSOLayer mlayer;
        public GSOFeature m_OldFeture = null;
        public  GSOFeature m_Feature = null;
        private  GSOGlobeControl m_GlobeControl = null;
        private  CtrlFeatureAttribute m_CtrlFeatureAttribute = null;
        private  CtrlGeometryCameraState m_CtrlGeometryCameraState = null;
        private  CtrlModelPathPage m_CtrlModePathPage = null;
       
        static FrmFeatureInfo featureInfo = null;        
        public static FrmFeatureInfo GetForm(GSOFeature feature, GSOLayer layer, GSOGlobeControl globeControl)
        {
            if (featureInfo == null)
            {
                featureInfo = new FrmFeatureInfo(feature, layer, globeControl);
                
            }            
            return featureInfo;
        }
        
        private FrmFeatureInfo() { }

        public FrmFeatureInfo(GSOFeature feature, GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            if (layer != null)
            {
                mlayer = layer;                
            }
            m_Feature = feature;
            // 先备份一个
            if (feature != null)
            {
                m_OldFeture = feature.Clone();
            }
            m_GlobeControl = globeControl;            
        }     

        private void FrmFeatureInfo_Load(object sender, EventArgs e)
        {
            SetTabControl();
        }
        
        public void SetTabControl()
        {           
            if (m_Feature != null)
            {
                tabControlMain.TabPages.Clear();
                textBoxName.Text = m_Feature.Name;
                checkBox1.Checked = m_Feature.Visible;

                if (m_Feature.Geometry != null)
                {
                    // 属性信息页面
                    if (m_Feature.Geometry.Type != EnumGeometryType.GeoPolyline3D)
                    {
                        m_CtrlFeatureAttribute = new CtrlFeatureAttribute(m_Feature, m_GlobeControl);
                        AddNewCtrlPage(m_CtrlFeatureAttribute, "tabAttribute", "属性信息");
                    }

                    switch (m_Feature.Geometry.Type)
                    {
                        case EnumGeometryType.GeoParticle:
                            {
                                InsertNewCtrlPage(0, new CtrlParticleParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                            }
                            break;
                        case EnumGeometryType.GeoMarker:
                        case EnumGeometryType.GeoDynamicMarker:
                            {
                                InsertNewCtrlPage(0, new CtrlMarkerTextPage(m_Feature.Geometry, m_GlobeControl), "tabMarkerText", "标注内容");
                            }
                            break;
                        case EnumGeometryType.GeoModel:
                            {
                                m_CtrlModePathPage = new CtrlModelPathPage(m_Feature, m_GlobeControl);
                                InsertNewCtrlPage(0, m_CtrlModePathPage, "tabModelPath", "模型路径");
                            }
                            break;
                        case EnumGeometryType.GeoFountain:
                            {
                                InsertNewCtrlPage(0, new CtrlFountainParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                            }
                            break;
                        case EnumGeometryType.GeoWater:
                            {
                                InsertNewCtrlPage(0, new FrmWaterParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                            }
                            break;
                        case EnumGeometryType.GeoSphereEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlSphereEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                            }
                            break;
                        case EnumGeometryType.GeoBoxEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlBoxEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "长方体";
                            }
                            break;
                        case EnumGeometryType.GeoCylinderEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlCylinderEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "柱";
                            }
                            break;
                        case EnumGeometryType.GeoFrustumEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlFrustumEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "台";
                            }
                            break;
                        case EnumGeometryType.GeoEllipsoidEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlEllipsoidEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "椭球";
                            }
                            break;
                        case EnumGeometryType.GeoEllipCylinderEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlEllipCylinderEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "椭圆柱";
                            }
                            break;
                        case EnumGeometryType.GeoEllipFrustumEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlEllipFrustumEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "椭圆台";
                            }
                            break;
                        case EnumGeometryType.GeoRangeEllipsoidEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlRangeEllipsoidEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "缺口椭球";
                            }
                            break;
                        case EnumGeometryType.GeoRangeEllipCylinderEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlRangeEllipCylinderEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "缺口椭圆柱";
                            }
                            break;
                        case EnumGeometryType.GeoRangeEllipFrustumEntity:
                            {
                                InsertNewCtrlPage(0, new CtrlRangeEllipFrustumEntityParamPage(m_Feature.Geometry, m_GlobeControl), "tabParam", "参数");
                                this.Text = "缺口椭圆台";
                            }
                            break;
                    }

                    // 空间信息页面
                    if (m_Feature.Geometry.IsEntity)
                    {
                        CtrlEntitySpaceInfo curCtrlEntitySpaceInfo = new CtrlEntitySpaceInfo(m_Feature, m_GlobeControl);
                        AddNewCtrlPage(curCtrlEntitySpaceInfo, "tabSpaceInfo", "空间信息");
                        if (m_CtrlModePathPage != null)
                        {
                            // 这里要设置关联一下，否则模型设置路径后里面的空间信息参数不能跟着更新
                            m_CtrlModePathPage.m_SpaceCtrl = curCtrlEntitySpaceInfo;
                        }
                        AddNewCtrlPage(new CtrlEntityStylePage(m_Feature, m_GlobeControl), "tabStyle", "风格");
                    }
                    else
                    {
                        switch (m_Feature.Geometry.Type)
                        {
                            case EnumGeometryType.GeoPoint3D:
                            case EnumGeometryType.GeoDynamicPoint3D:
                            case EnumGeometryType.GeoMarker:
                            case EnumGeometryType.GeoDynamicMarker:
                                {
                                    AddNewCtrlPage(new CtrlPoint3DSpaceInfo(m_Feature.Geometry, m_GlobeControl), "tabSpaceInfo", "空间信息");
                                    if (m_Feature.Geometry.Type == EnumGeometryType.GeoMarker ||
                                        m_Feature.Geometry.Type == EnumGeometryType.GeoDynamicMarker)
                                    {
                                        AddNewCtrlPage(new CtrlMarkerStylePage(m_Feature.Geometry, m_GlobeControl), "tabStyle", "风格");
                                    }
                                }
                                break;
                            case EnumGeometryType.GeoPolyline3D:
                                {
                                    AddNewCtrlPage(new CtrlPolylineSpaceInfo(m_Feature.Geometry, m_Feature, mlayer, m_GlobeControl), "tabSpaceInfo", "空间信息");                                   
                                    AddNewCtrlPage(new CtrlLineStylePage(m_Feature.Geometry, m_Feature, mlayer, m_GlobeControl), "tabStyle", "风格");
                                    if (m_Feature.GetFieldCount() > 0)
                                    {
                                        AddNewCtrlPage(new CtrlLineFieldsValuePage(m_Feature, mlayer, m_GlobeControl), "tabFieldsValue", "字段值");
                                    }
                                }
                                break;
                            case EnumGeometryType.GeoPolygon3D:
                            case EnumGeometryType.GeoWater:
                                {
                                    AddNewCtrlPage(new CtrlPolylineSpaceInfo(m_Feature.Geometry, m_GlobeControl), "tabSpaceInfo", "空间信息");
                                    AddNewCtrlPage(new CtrlPolygonStylePage(m_Feature, m_GlobeControl), "tabStyle", "风格");
                                    AddNewCtrlPage(new CtrlExtrudePage(m_Feature.Geometry, m_GlobeControl), "tabExtrude", "拉伸");
                                }
                                break;
                        }
                    }
                    if (m_Feature.Geometry.Type != EnumGeometryType.GeoPolyline3D)
                    {
                        m_CtrlGeometryCameraState = new CtrlGeometryCameraState(m_Feature, m_GlobeControl);
                        AddNewCtrlPage(m_CtrlGeometryCameraState, "tabCameraState", "定位参数");
                    }
                }
            }

            // 设置当前tab页面为第一个
            tabControlMain.SelectedIndex = 0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (m_Feature != null)
            {
                if (m_Feature.Geometry != null)
                {
                    m_Feature.Geometry.Name = textBoxName.Text;

                    // 交换数据
                    if (m_Feature.Geometry.Type != EnumGeometryType.GeoPolyline3D)
                    {
                        m_CtrlFeatureAttribute.ExchangeData();
                        m_CtrlGeometryCameraState.ExchangeData();
                    }
                }
                m_Feature.Name = textBoxName.Text; 
                m_GlobeControl.Refresh();
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // 如果取消的话，将备份的拷贝回来
            if (m_Feature != null)
            {
                if (CtrlPolylineSpaceInfo.m_style != null && CtrlPolylineSpaceInfo.m_oldStyle != null)
                {
                    try
                    {
                        CtrlPolylineSpaceInfo.m_style.Copy(CtrlPolylineSpaceInfo.m_oldStyle);
                    }
                    catch (Exception ex)
                    {
                        Log.PublishTxt(ex);
                        MessageBox.Show(ex.Message);
                    }
                    // 标记并未修改
                    CtrlPolylineSpaceInfo.m_style.SetModified(false);
                }                

                bool bHighLight = m_Feature.HighLight;
                m_Feature.Copy(m_OldFeture);
                // 高亮可能在设置的时候取消了,所以高亮状态需要恢复一下
                m_Feature.HighLight = bHighLight;
                m_GlobeControl.Refresh();
            }
            this.Close();
        }
        private void InsertNewCtrlPage(Int32 index,Control newCtrlPage, String key, String text)
        {
            tabControlMain.TabPages.Insert(index,key, text);
            tabControlMain.TabPages[key].Controls.Add(newCtrlPage);
            newCtrlPage.Dock = DockStyle.Fill;
        }
        private void AddNewCtrlPage(Control newCtrlPage, String key, String text) 
        {
            tabControlMain.TabPages.Add(key, text);
            tabControlMain.TabPages[key].Controls.Add(newCtrlPage);
            newCtrlPage.Dock = DockStyle.Fill;
        }
      
        private void buttonFlyTo_Click(object sender, EventArgs e)
        {
            if(m_Feature!=null && m_GlobeControl!=null)
            {
                if (m_Feature.Geometry != null && m_Feature.Geometry.CameraState != null)
                {
                    m_GlobeControl.Globe.FlyToCameraState(m_Feature.Geometry.CameraState);
                }
                else 
                {
                    m_GlobeControl.Globe.FlyToFeature(m_Feature);
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            m_GlobeControl.Globe.AddToEditHistroy(mlayer, m_Feature, EnumEditType.Modify);
        }

        private void FrmFeatureInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            featureInfo = null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            m_Feature.Visible = checkBox1.Checked;
            m_GlobeControl.Globe.Refresh();
        }
    }
}
