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
    public partial class CtrlFeatureAttribute : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOFeature m_Feature = null;
        GSOBalloonEx m_Ballonex = null;
        public CtrlFeatureAttribute(GSOFeature feature,GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Feature = feature;
        }
        private void CheckBallonSetingEnable()
        {
            // 复杂气泡的时候其它的才能设置
            if (cbbShowMode.SelectedIndex == 1)
            {
                tbbWidth.Enabled = false;
                tbbHeight.Enabled = false;
                cbbContentType.Enabled = false;
            }
            else
            {
                tbbWidth.Enabled = true;
                tbbHeight.Enabled = true;
                cbbContentType.Enabled = true;
            }
        }
        private void CtrlFeatureAttribute_Load(object sender, EventArgs e)
        {
            if (m_Feature!=null)
            {
                // 属性信息相关
                m_Ballonex = new GSOBalloonEx(this.Handle);
                GSOBalloonParam param = m_Ballonex.ParseParam(m_Feature.Description);
                textBoxAttribute.Text = param.Content;
                switch (param.ShowMode)
                {
                    case EnumShowModeEx.BALLOONEX:
                        cbbShowMode.SelectedIndex = 0;
                        break;
                    case EnumShowModeEx.BALLOON:
                        cbbShowMode.SelectedIndex = 1;
                        break;
                    case EnumShowModeEx.EXPLORER:
                        cbbShowMode.SelectedIndex = 2;
                        break;
                    default:
                        cbbShowMode.SelectedIndex = 0;
                        break;

                }
                switch (param.ContentType)
                {
                    case EnumContentTypeEx.TEXT:
                        cbbContentType.SelectedIndex = 0;
                        break;
                    case EnumContentTypeEx.LINK:
                        cbbContentType.SelectedIndex = 1;
                        break;
                    default:
                        cbbContentType.SelectedIndex = 0;
                        break;
                }

                tbbWidth.Text = param.GetSize(EnumSizeIndexEx.CONTENT_CX).ToString();
                tbbHeight.Text = param.GetSize(EnumSizeIndexEx.CONTENT_CY).ToString();
            }
        
            CheckBallonSetingEnable();

        }
        public void ExchangeData()
        {

            // 属性信息
            String strAttribute = "";
            String strShowMode = "";
            switch (cbbShowMode.SelectedIndex)
            {
                case 0:
                    strShowMode = "balloonex";
                    break;
                case 1:
                    strShowMode = "balloon";
                    break;
                case 2:
                    strShowMode = "explorer";
                    break;
                default:
                    strShowMode = "balloonex";
                    break;

            }

            String strContentType;
            switch (cbbContentType.SelectedIndex)
            {
                case 0:
                    strContentType = "text";
                    break;
                case 1:
                    strContentType = "link";
                    break;
                default:
                    strContentType = "text";
                    break;
            }
            // 普通气泡不记录参数吧
            if (cbbShowMode.SelectedIndex != 1)
            {

                strAttribute = "<!-- <BALLOON>";
                strAttribute += "<CONTENT_CX>" + tbbWidth.Text + "</CONTENT_CX>" + "<CONTENT_CY>" + tbbHeight.Text + "</CONTENT_CY>" +
                    "<CONTENT_TYPE>" + strContentType + "</CONTENT_TYPE>" + "<SHOW_MODE>" + strShowMode + "</SHOW_MODE>";
                strAttribute += "-->";
            }
            if (m_Feature != null)
            {
                m_Feature.Description = strAttribute + textBoxAttribute.Text;
            }
            
        }
        private void cbbShowMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBallonSetingEnable();
        }
    }
}
