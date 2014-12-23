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
  
    public partial class CtrlEntitySpaceInfo : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOFeature m_feature = null;
        //public GSOGeometry m_feature.Geometry = null;
        public CtrlEntitySpaceInfo(GSOFeature feature, GSOGlobeControl globeControl)//(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            //m_feature.Geometry = geometry;
            m_feature = feature;
        }
      
        public void UpdateControls()
        {
            GSOGeoEntity geoEntity = m_feature.Geometry as GSOGeoEntity;
            if (geoEntity != null)
            {

                textBoxLat.Text = geoEntity.Position.Y.ToString();
                textBoxLon.Text = geoEntity.Position.X.ToString();
                textBoxAlt.Text = geoEntity.Position.Z.ToString();

                //textBoxRotX.Text = geoEntity.RotateX.ToString();
                //textBoxRotY.Text = geoEntity.RotateY.ToString();
                //textBoxRotZ.Text = geoEntity.RotateZ.ToString();
                double rotateX = geoEntity.RotateX;
                double rotateY = geoEntity.RotateY;
                double rotateZ = geoEntity.RotateZ;
                numUpDownRotX.Value = Convert.ToDecimal(rotateX);
                numUpDownRotY.Value = Convert.ToDecimal(rotateY);
                numUpDownRotZ.Value = Convert.ToDecimal(rotateZ);

                //textBoxScaleX.Text = geoEntity.ScaleX.ToString();
                //textBoxScaleY.Text = geoEntity.ScaleY.ToString();
                //textBoxScaleZ.Text = geoEntity.ScaleZ.ToString();

                double x = geoEntity.ScaleX;
                double y = geoEntity.ScaleY;
                double z = geoEntity.ScaleZ;
                numUpDownScaleX.Value = Convert.ToDecimal(x);
                numUpDownScaleY.Value = Convert.ToDecimal(y);
                numUpDownScaleZ.Value = Convert.ToDecimal(z);

                // 高度
                switch (geoEntity.AltitudeMode)
                {
                    case EnumAltitudeMode.Absolute:
                        comboBoxAltMode.SelectedIndex = 0;
                        break;
                    case EnumAltitudeMode.ClampToGround:
                        comboBoxAltMode.SelectedIndex = 1;
                        textBoxAlt.Enabled = false;
                        break;
                    case EnumAltitudeMode.RelativeToGround:
                        comboBoxAltMode.SelectedIndex = 2;
                        break;
                }

                switch (geoEntity.Align)
                {
                    case EnumEntityAlign.BottomCenter:
                        comboBoxAlign.SelectedIndex = 0;
                        break;
                    case EnumEntityAlign.MiddleCenter:
                        comboBoxAlign.SelectedIndex = 1;
                        break;
                    case EnumEntityAlign.TopCenter:
                        comboBoxAlign.SelectedIndex = 2;
                        break;
                }
            }
        }
        private void CtrlEntitySpaceInfo_Load(object sender, EventArgs e)
        {
            UpdateControls();

            numUpDownScaleX.Minimum = 0;
            numUpDownScaleX.Increment = 0.1M;
            numUpDownScaleX.DecimalPlaces = 1;
            numUpDownScaleX.Maximum = 2;

            numUpDownScaleY.Minimum = 0;
            numUpDownScaleY.DecimalPlaces = 1;
            numUpDownScaleY.Increment = 0.1M;
            numUpDownScaleY.Maximum = 2;

            numUpDownScaleZ.Minimum = 0;
            numUpDownScaleZ.DecimalPlaces = 1;
            numUpDownScaleZ.Increment = 0.1M;
            numUpDownScaleZ.Maximum = 2;
        }

        private void positionChanged()
        {
            GSOGeoEntity geoEntity = m_feature.Geometry as GSOGeoEntity;
            if (geoEntity != null)
            {
                try
                {
                    geoEntity.PositionX = Convert.ToDouble(textBoxLon.Text);
                    geoEntity.PositionY = Convert.ToDouble(textBoxLat.Text);
                    geoEntity.PositionZ = Convert.ToDouble(textBoxAlt.Text);
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
        private void textBoxLon_TextChanged(object sender, EventArgs e)
        {
            positionChanged();
        }
        private void textBoxLat_TextChanged(object sender, EventArgs e)
        {
            positionChanged();
        }

        private void textBoxAlt_TextChanged(object sender, EventArgs e)
        {
            positionChanged();
        }

        private void comboBoxAltMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOGeoEntity geoEntity = m_feature.Geometry as GSOGeoEntity;
            if (geoEntity != null)
            {
                switch (comboBoxAltMode.SelectedIndex)
                {
                    case 0:
                        geoEntity.AltitudeMode = EnumAltitudeMode.Absolute;
                        textBoxAlt.Enabled = true;
                        break;
                    case 1:
                        geoEntity.AltitudeMode = EnumAltitudeMode.ClampToGround;
                        textBoxAlt.Enabled = false;
                        break;
                    case 2:
                        geoEntity.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        textBoxAlt.Enabled = true;
                        break;
                }
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }

        private void comboBoxAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOGeoEntity geoEntity = m_feature.Geometry as GSOGeoEntity;
            if (geoEntity != null)
            {
                switch (comboBoxAlign.SelectedIndex)
                {
                    case 0:
                        geoEntity.Align = EnumEntityAlign.BottomCenter;
                        break;
                    case 1:
                        geoEntity.Align = EnumEntityAlign.MiddleCenter;
                        break;
                    case 2:
                        geoEntity.Align = EnumEntityAlign.TopCenter;
                        break;
                }
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }

        private void rotationChanged()
        {
            GSOGeoEntity geoEntity = m_feature.Geometry as GSOGeoEntity;
            if (geoEntity != null)
            {
                try
                {
                    geoEntity.RotateX = Convert.ToDouble(numUpDownRotX.Value);
                    geoEntity.RotateY = Convert.ToDouble(numUpDownRotY.Value);
                    geoEntity.RotateZ = Convert.ToDouble(numUpDownRotZ.Value);

                    m_feature.Geometry.SetModified(true);

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

        private void textBoxRotX_TextChanged(object sender, EventArgs e)
        {
            //rotationChanged();
        }

        private void textBoxRotY_TextChanged(object sender, EventArgs e)
        {
            //rotationChanged();
        }

        private void textBoxRotZ_TextChanged(object sender, EventArgs e)
        {
            //rotationChanged();
        }

        private void numUpDownRotX_ValueChanged(object sender, EventArgs e)
        {
            rotationChanged();
        }

        private void numUpDownRotY_ValueChanged(object sender, EventArgs e)
        {
            rotationChanged();
        }

        private void numUpDownRotZ_ValueChanged(object sender, EventArgs e)
        {
            rotationChanged();
        }

        private void scaleChanged()
        {
            GSOGeoEntity geoEntity = m_feature.Geometry as GSOGeoEntity;
            if (geoEntity != null)
            {
                try
                {
                    geoEntity.ScaleX = Convert.ToDouble(numUpDownScaleX.Value);
                    geoEntity.ScaleY = Convert.ToDouble(numUpDownScaleY.Value);
                    geoEntity.ScaleZ = Convert.ToDouble(numUpDownScaleZ.Value);

                    geoEntity.SetModified(true);
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

        private void textBoxScaleX_TextChanged(object sender, EventArgs e)
        {
            scaleChanged();
        }

        private void textBoxScaleY_TextChanged(object sender, EventArgs e)
        {
            scaleChanged();
        }

        private void textBoxScaleZ_TextChanged(object sender, EventArgs e)
        {
            scaleChanged();
        }

        private void numUpDownScaleX_ValueChanged(object sender, EventArgs e)
        {
            scaleChanged();
        }

        private void numUpDownScaleY_ValueChanged(object sender, EventArgs e)
        {
            scaleChanged();
        }

        private void numUpDownScaleZ_ValueChanged(object sender, EventArgs e)
        {
            scaleChanged();
        }
    }
}
