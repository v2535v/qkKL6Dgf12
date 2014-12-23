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
    public partial class CtrlFountainParamPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        public CtrlFountainParamPage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void CtrlFountainParamPage_Load(object sender, EventArgs e)
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain!=null)
            {
                textBoxSteps.Text = geoFountain.Steps.ToString();
                textBoxStepRays.Text = geoFountain.RaysPerStep.ToString();
                textBoxRayDrops.Text = geoFountain.DropsPerRay.ToString();
                textBoxDropSize.Text = geoFountain.DropSize.ToString();

                textBoxAngleOfDeepestStep.Text = geoFountain.AngleOfDeepestStep.ToString();
                textBoxAccFactor.Text = geoFountain.AccFactor.ToString();

                textBoxDropImage.Text = geoFountain.DropImage;
                pictureBoxDropColor.BackColor = geoFountain.DropColor;
                numericUpDownDropOpaque.Value = geoFountain.DropColor.A;
            }
            

        }

        private void textBoxDropSize_TextChanged(object sender, EventArgs e)
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain != null)
            {
                try
                {
                    geoFountain.DropSize = Convert.ToDouble(textBoxDropSize.Text);
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

        private void textBoxSteps_TextChanged(object sender, EventArgs e)
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain != null)
            {
                try
                {
                    geoFountain.Steps = Convert.ToInt32(textBoxSteps.Text);
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

        private void textBoxStepRays_TextChanged(object sender, EventArgs e)
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain != null)
            {
                try
                {
                    geoFountain.RaysPerStep = Convert.ToInt32(textBoxStepRays.Text);
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

        private void textBoxRayDrops_TextChanged(object sender, EventArgs e)
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain != null)
            {
                try
                {
                    geoFountain.DropsPerRay = Convert.ToInt32(textBoxRayDrops.Text);
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

        private void textBoxAngleOfDeepestStep_TextChanged(object sender, EventArgs e)
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain != null)
            {
                try
                {
                    geoFountain.AngleOfDeepestStep = Convert.ToDouble(textBoxAngleOfDeepestStep.Text);
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

        private void textBoxAccFactor_TextChanged(object sender, EventArgs e)
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain != null)
            {
                try
                {
                    geoFountain.AccFactor = Convert.ToDouble(textBoxAccFactor.Text);
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
        private void dropColorChanged()
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain != null)
            {
                geoFountain.DropColor = Color.FromArgb(Convert.ToByte(numericUpDownDropOpaque.Value), pictureBoxDropColor.BackColor);
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }

        }
        private void pictureBoxDropColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxDropColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxDropColor.BackColor =dlg.Color;
                dropColorChanged();
            }
        }

        private void numericUpDownDropOpaque_ValueChanged(object sender, EventArgs e)
        {
            dropColorChanged();
        }


        private void dropImageChanged()
        {
            GSOGeoFountain geoFountain = m_Geometry as GSOGeoFountain;
            if (geoFountain != null)
            {
                geoFountain.DropImage = textBoxDropImage.Text;
                if (m_GlobeControl!=null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }
        private void buttonDropImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                textBoxDropImage.Text = dlg.FileName;
                dropImageChanged();
            }
        }

        private void textBoxDropImage_TextChanged(object sender, EventArgs e)
        {
            dropImageChanged();
        }

       
    }
}
