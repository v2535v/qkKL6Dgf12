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
    public partial class FrmWaterParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        public FrmWaterParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void CtrlWaterParamPage_Load(object sender, EventArgs e)
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater!=null)
            {
                textBoxWaveSpeedX.Text = geoWater.WaveSpeedX.ToString();
                textBoxWaveSpeedY.Text = geoWater.WaveSpeedY.ToString();
                textBoxWaveWidth.Text = geoWater.WaveWidth.ToString();

                pictureBoxWaterColor.BackColor = geoWater.WaterColor;
                pictureBoxReflectColor.BackColor = Color.FromArgb(255,geoWater.ReflectColor);
                upDownReflectOpaque.Value = geoWater.ReflectColor.A;


                if (geoWater.LightType < 0 || geoWater.LightType > 3)
                {
                    comboBoxLightType.SelectedIndex = 0;
                }
                else
                {
                    comboBoxLightType.SelectedIndex = geoWater.LightType;
                }


                textBoxNormalImage.Text = geoWater.WaveNormalImage;
                textBoxDuDvImage.Text = geoWater.WaveDuDvImage;

                cboxReflectSky.Checked = geoWater.ReflectSky;
                checkBoxWaveLOD.Checked = geoWater.UseWaveLOD;
            }
            

        }

        private void textBoxWaveSpeedX_TextChanged(object sender, EventArgs e)
        {
             GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
             if (geoWater != null)
             {

                 try
                 {
                     geoWater.WaveSpeedX = Convert.ToDouble(textBoxWaveSpeedX.Text);
                     if(m_GlobeControl!=null)
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

        private void textBoxWaveSpeedY_TextChanged(object sender, EventArgs e)
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater != null)
            {

                try
                {
                    geoWater.WaveSpeedY = Convert.ToDouble(textBoxWaveSpeedY.Text);
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

        private void textBoxWaveWidth_TextChanged(object sender, EventArgs e)
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater != null)
            {

                try
                {
                    geoWater.WaveWidth = Convert.ToDouble(textBoxWaveWidth.Text);
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
        private void waterColorChanged()
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater != null)
            {

                try
                {
                    geoWater.WaterColor = pictureBoxWaterColor.BackColor;
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
        private void pictureBoxWaterColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxWaterColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxWaterColor.BackColor = dlg.Color;
                waterColorChanged();
            }

           
        }
        private void reflectColorChanged()
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater != null)
            {

                try
                {
                    geoWater.ReflectColor = Color.FromArgb(Convert.ToByte(upDownReflectOpaque.Value), pictureBoxReflectColor.BackColor);
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

        private void pictureBoxReflectColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxReflectColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxReflectColor.BackColor = dlg.Color;
                reflectColorChanged();
            }

        }

        private void upDownReflectOpaque_ValueChanged(object sender, EventArgs e)
        {
            reflectColorChanged();
        }

        private void comboBoxLightType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater != null)
            {
                geoWater.LightType = comboBoxLightType.SelectedIndex;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
            
        }


        private void normalImageChanged()
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater != null)
            {
                geoWater.WaveNormalImage = textBoxNormalImage.Text;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }

        }
        private void buttonNormalImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.jpg)|*.jpg|(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                textBoxNormalImage.Text = dlg.FileName;
                normalImageChanged();
            }
        }

        private void duDvImageImageChanged()
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater != null)
            {
                geoWater.WaveDuDvImage = textBoxDuDvImage.Text;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }

        }
        private void buttonDuDvImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.jpg)|*.jpg|(*.jpeg)|*.jpeg|(*.bmp)|*.bmp|(*.png)|*.png|(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                textBoxDuDvImage.Text = dlg.FileName;
                duDvImageImageChanged();
            }

        }

        private void cboxReflectSky_CheckedChanged(object sender, EventArgs e)
        {
             GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
             if (geoWater != null)
             {
                 geoWater.ReflectSky = cboxReflectSky.Checked;
                 if (m_GlobeControl != null)
                 {
                     m_GlobeControl.Refresh();
                 }
             }

        }

        private void checkBoxWaveLOD_CheckedChanged(object sender, EventArgs e)
        {
            GSOGeoWater geoWater = m_Geometry as GSOGeoWater;
            if (geoWater != null)
            {
                geoWater.UseWaveLOD = checkBoxWaveLOD.Checked;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }


        }
    }
}
