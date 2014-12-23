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
    public partial class CtrlGeometryCameraState : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOFeature m_feature = null;
        public CtrlGeometryCameraState(GSOFeature feature, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_feature = feature;
        }

        private void EnableCameraSet(Boolean value)
        {
            textBoxCameraLon.Enabled = value;
            textBoxCameraLat.Enabled = value;
            textBoxCameraAlt.Enabled = value;
            textBoxCameraHeading.Enabled = value;
            textBoxCameraTilt.Enabled = value;
            comboBoxAltiMode.Enabled = value;
            buttonCurCamera.Enabled = value;
            buttonResetCamera.Enabled = value;
        }

        private void buttonCurCamera_Click(object sender, EventArgs e)
        {
            if (m_GlobeControl != null)
            {
                textBoxCameraLon.Text = m_GlobeControl.Globe.CameraState.Longitude.ToString();
                textBoxCameraLat.Text = m_GlobeControl.Globe.CameraState.Latitude.ToString();
                textBoxCameraAlt.Text = m_GlobeControl.Globe.CameraState.Altitude.ToString();
                textBoxCameraHeading.Text = m_GlobeControl.Globe.CameraState.Heading.ToString();
                textBoxCameraTilt.Text = m_GlobeControl.Globe.CameraState.Tilt.ToString();

                textBoxDistance.Text = m_GlobeControl.Globe.CameraState.Distance.ToString();
                comboBoxAltiMode.Text = comboBoxAltiMode.Items[0].ToString();
            }
        }

        private void CtrlGeometryCameraState_Load(object sender, EventArgs e)
        {
            //动态加载时绑定控件不可编辑事件            
            //comboBoxAltiMode.KeyPress += new KeyPressEventHandler(comboBoxAltiMode_KeyPress);

            if (m_feature.Geometry != null && m_feature.Geometry.CameraState != null)
            {
                checkBoxEnableCamera.Checked = true;
                textBoxCameraLon.Text = m_feature.Geometry.CameraState.Longitude.ToString();
                textBoxCameraLat.Text = m_feature.Geometry.CameraState.Latitude.ToString();
                textBoxCameraAlt.Text = m_feature.Geometry.CameraState.Altitude.ToString();
                textBoxCameraHeading.Text = m_feature.Geometry.CameraState.Heading.ToString();
                textBoxCameraTilt.Text = m_feature.Geometry.CameraState.Tilt.ToString();
                textBoxDistance.Text = m_feature.Geometry.CameraState.Distance.ToString();
                switch (m_feature.Geometry.CameraState.AltitudeMode)
                {
                    case EnumAltitudeMode.Absolute:
                        comboBoxAltiMode.SelectedIndex = 0;
                        break;
                    case EnumAltitudeMode.ClampToGround:
                        comboBoxAltiMode.SelectedIndex = 1;
                        break;
                    case EnumAltitudeMode.RelativeToGround:
                        comboBoxAltiMode.SelectedIndex = 2;
                        break;
                }
                comboBoxAltiMode.Text = comboBoxAltiMode.Items[comboBoxAltiMode.SelectedIndex].ToString();
            }
            else
            {
                checkBoxEnableCamera.Checked = false;
                EnableCameraSet(false);
            }
        }

        private void buttonResetCamera_Click(object sender, EventArgs e)
        {
            if (m_feature.Geometry != null && m_GlobeControl != null)
            {
                textBoxCameraLon.Text = m_feature.Geometry.GeoTopCenterPoint.X.ToString();
                textBoxCameraLat.Text = m_feature.Geometry.GeoTopCenterPoint.Y.ToString();
                textBoxCameraAlt.Text = m_feature.Geometry.GeoTopCenterPoint.Z.ToString();
                textBoxCameraHeading.Text = "0";
                textBoxCameraTilt.Text = "0";
                textBoxDistance.Text = "0";
                comboBoxAltiMode.Text = comboBoxAltiMode.Items[0].ToString();
            }
        }

        private void checkBoxEnableCamera_CheckedChanged(object sender, EventArgs e)
        {
            EnableCameraSet(checkBoxEnableCamera.Checked);
        }
        public void ExchangeData()
        {
            if (m_feature.Geometry != null)
            {
                if (!checkBoxEnableCamera.Checked)
                {
                    m_feature.Geometry.CameraState = null;
                }
                else
                {
                    if (m_feature.Geometry.CameraState == null)
                    {
                        m_feature.Geometry.CameraState = new GSOCameraState();
                    }
                    try
                    {
                        m_feature.Geometry.CameraState.Longitude = Convert.ToDouble(textBoxCameraLon.Text);
                        m_feature.Geometry.CameraState.Latitude = Convert.ToDouble(textBoxCameraLat.Text);
                        m_feature.Geometry.CameraState.Altitude = Convert.ToDouble(textBoxCameraAlt.Text);
                        m_feature.Geometry.CameraState.Heading = Convert.ToDouble(textBoxCameraHeading.Text);
                        m_feature.Geometry.CameraState.Tilt = Convert.ToDouble(textBoxCameraTilt.Text);
                        m_feature.Geometry.CameraState.Distance = Convert.ToDouble(textBoxDistance.Text);

                        switch (comboBoxAltiMode.SelectedIndex)
                        {
                            case 0:
                                m_feature.Geometry.CameraState.AltitudeMode = EnumAltitudeMode.Absolute;
                                break;
                            case 1:
                                m_feature.Geometry.CameraState.AltitudeMode = EnumAltitudeMode.ClampToGround;
                                break;
                            case 2:
                                m_feature.Geometry.CameraState.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.PublishTxt(ex);
                        m_feature.Geometry.CameraState = null;
                    }
                }
            }
        }
    }
}
