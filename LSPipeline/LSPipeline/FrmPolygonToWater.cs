using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;

namespace WorldGIS
{
    public partial class FrmPolygonToWater : Form
    {
        GSOFeatures mFeaturesOld;
        GSOFeatures mFeatures;
        GSOGlobeControl mGlobeControl;
        GSOLayer mLayer;

        public FrmPolygonToWater(GSOGlobeControl globeControl,GSOLayer layer)
        {
            mGlobeControl = globeControl;
            mLayer = layer;
            InitializeComponent();
        }

        private void FrmPolygonToWater_Load(object sender, EventArgs e)
        {
            mFeatures = mLayer.GetAllFeatures();
            mFeaturesOld = new GSOFeatures();
            bool hasGeoWater = false;
            for (int i = 0; i < mFeatures.Length; i++)
            {
                if (mFeatures[i] != null)
                {
                    mFeaturesOld.Add(mFeatures[i].Clone());
                    if (!hasGeoWater)
                    {
                        if (mFeatures[i].Geometry != null && mFeatures[i].Geometry.Type == EnumGeometryType.GeoWater)
                        {
                            GSOGeoWater geoWater = (GSOGeoWater)mFeatures[i].Geometry;
                            // 水一般都是绝对高度模式
                            //geoWater.Altitude = EnumAltitudeMode.Absolute; 

                            textBoxWaveSpeedX.Text = geoWater.WaveSpeedX.ToString();
                            textBoxWaveSpeedY.Text = geoWater.WaveSpeedY.ToString();
                            textBoxWaveWidth.Text = geoWater.WaveWidth.ToString();
                            pictureBoxWaterColor.BackColor = geoWater.WaterColor;
                            pictureBoxReflectColor.BackColor = geoWater.ReflectColor;
                            textBoxNormalImage.Text = geoWater.WaveNormalImage;
                            textBoxDuDvImage.Text = geoWater.WaveDuDvImage;
                            checkboxReflectSky.Checked = geoWater.ReflectSky;
                            checkBoxWaveLOD.Checked = geoWater.UseWaveLOD;

                            hasGeoWater = true;
                        }
                    }
                }
            }
            if (!hasGeoWater)
            {
                textBoxWaveSpeedX.Text = "" + 0;
                textBoxWaveSpeedY.Text = "" + 0.00999999977648258;
                textBoxWaveWidth.Text = "" + 1;
                comboBoxLightType.SelectedIndex = 0;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (apply())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            }
        }  

        private void buttonNormalImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.jpg)|*.jpg|(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxNormalImage.Text = dlg.FileName;                
            }
        }

        private void buttonDuDvImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.jpg)|*.jpg|(*.jpeg)|*.jpeg|(*.bmp)|*.bmp|(*.png)|*.png|(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxDuDvImage.Text = dlg.FileName;                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            mLayer.RemoveAllFeature();
            mLayer.AddFeatures(mFeaturesOld);
            mGlobeControl.Refresh();
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            apply();
        }

        private bool apply()
        {
            double waveSpeedX = 0;
            if (!double.TryParse(textBoxWaveSpeedX.Text.Trim(), out waveSpeedX))
            {
                MessageBox.Show("水波横向速度不符合要求");
                return false ;
            }
            double waveSpeedY = 0;
            if (!double.TryParse(textBoxWaveSpeedY.Text.Trim(), out waveSpeedY))
            {
                MessageBox.Show("水波纵向速度不符合要求");
                return false;
            }
            double waveWidth = 0;
            if (!double.TryParse(textBoxWaveWidth.Text.Trim(), out waveWidth))
            {
                MessageBox.Show("水波宽度不符合要求");
                return false;
            }
            Color waterColor = pictureBoxWaterColor.BackColor;
            Color reflectorColor = Color.FromArgb(Convert.ToByte(upDownReflectOpaque.Value), pictureBoxReflectColor.BackColor);
            int intLightType = comboBoxLightType.SelectedIndex;
            string waveNormalImagePath = textBoxNormalImage.Text;
            string waveDuDvImagePath = textBoxDuDvImage.Text;
            GSOFeatures featuresAdded = new GSOFeatures();
            GSOFeatures featuresNomal = new GSOFeatures();
            for (int i = mFeatures.Length - 1; i >= 0 ; i--)
            {
                GSOFeature feature = mFeatures[i];
                if (feature != null && feature.Geometry != null)
                {
                    if (feature.Geometry.Type == EnumGeometryType.GeoPolygon3D)
                    {
                        GSOGeoPolygon3D geoPolygon3d = (GSOGeoPolygon3D)feature.Geometry;
                        GSOGeoWater geoWater = geoPolygon3d.ConvertToGeoWater();
                        // 水一般都是绝对高度模式
                        //geoWater.Altitude = EnumAltitudeMode.Absolute; 

                        geoWater.WaveSpeedX = waveSpeedX;
                        geoWater.WaveSpeedY = waveSpeedY;
                        geoWater.WaveWidth = waveWidth;
                        geoWater.WaterColor = waterColor;
                        geoWater.ReflectColor = reflectorColor;
                        geoWater.WaveNormalImage = waveNormalImagePath;
                        geoWater.WaveDuDvImage = waveDuDvImagePath;
                        geoWater.ReflectSky = checkboxReflectSky.Checked;
                        geoWater.UseWaveLOD = checkBoxWaveLOD.Checked;


                        GSOFeature newFeature = feature.Clone();                                             
                        geoWater.Play();                        
                        newFeature.Geometry = geoWater;
                        
                        featuresAdded.Add(newFeature);
                        
                    }
                    else if (feature.Geometry.Type == EnumGeometryType.GeoWater)
                    {
                        GSOGeoWater geoWater = (GSOGeoWater)feature.Geometry;
                        // 水一般都是绝对高度模式
                        //geoWater.Altitude = EnumAltitudeMode.Absolute; 

                        geoWater.WaveSpeedX = waveSpeedX;
                        geoWater.WaveSpeedY = waveSpeedY;
                        geoWater.WaveWidth = waveWidth;
                        geoWater.WaterColor = waterColor;
                        geoWater.ReflectColor = reflectorColor;
                        geoWater.WaveNormalImage = waveNormalImagePath;
                        geoWater.WaveDuDvImage = waveDuDvImagePath;
                        geoWater.ReflectSky = checkboxReflectSky.Checked;
                        geoWater.UseWaveLOD = checkBoxWaveLOD.Checked;

                        GSOFeature newFeature = feature.Clone();                        
                        geoWater.Play();
                        newFeature.Geometry = geoWater;

                        featuresAdded.Add(newFeature);                      
                    }
                    else
                    {
                        featuresNomal.Add(feature);
                    }
                }
            }
            mLayer.RemoveAllFeature();
            mLayer.AddFeatures(featuresAdded);
            mLayer.AddFeatures(featuresNomal);
            mGlobeControl.Refresh();
            return true;
        }
    }
}
