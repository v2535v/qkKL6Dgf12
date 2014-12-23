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
    
    public partial class FrmSetSceneLight : Form
    {
        public GSOLight  light = null;
        public GSOGlobeControl globeControl = null;
        public FrmSetSceneLight()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (light!=null)
            {
                light.LightOn = (cbStatus.SelectedIndex == 0);

            }

            switch (cbMode.SelectedIndex)
            {
                case 0:
                    light.LightMode = EnumLightMode.Default;
                    break;
                case 1:
                    light.LightMode=EnumLightMode.Object;
                    break;
                case 2:
                    light.LightMode = EnumLightMode.Eye;
                    break;
                case 3:
                    light.LightMode = EnumLightMode.World;
                    break;
                case 4:
                    light.LightMode = EnumLightMode.Sun;
                    break;
                default:
                    light.LightMode = EnumLightMode.Default;
                    break;
            }

            switch (cbType.SelectedIndex)
            {
                case 0:
                    light.LightType=EnumLightType.Parallel;
                    break;
                case 1:
                    light.LightType = EnumLightType.Point;
                    break;
                case 2:
                    light.LightType = EnumLightType.Spot;
                    break;
                default:
                    light.LightType = EnumLightType.Parallel;
                    break;
            }

            GSOPoint3d pos=new GSOPoint3d();
            pos.X = Convert.ToDouble(tbPosX.Text);
            pos.Y = Convert.ToDouble(tbPosY.Text);
            pos.Z = Convert.ToDouble(tbPosZ.Text);
            light.Position = pos;

            light.Ambient = pbAmbient.BackColor;
            light.Diffuse= pbDiffuse.BackColor;
            light.Specular = pbSpecular.BackColor;
            globeControl.Globe.SceneAmbient=  pbGlobalAmbient.BackColor;
            globeControl.Globe.ModelUseLighting = cbModelUseLighting.Checked;
            globeControl.Globe.TerrainUseLighting = cbTerrainUseLighting.Checked;

        }

        private void SceneLightSet_Load(object sender, EventArgs e)
        {
            if(light!=null)
            {

                if(light.LightOn)
                {
                    cbStatus.SelectedIndex = 0;
                }
                else
                {
                    cbStatus.SelectedIndex = 1;
                }
                switch (light.LightMode)
                {
                    case EnumLightMode.Default:
                        cbMode.SelectedIndex = 0;
                        break;
                    case EnumLightMode.Object:
                        cbMode.SelectedIndex = 1;
                        break;
                    case EnumLightMode.Eye:
                        cbMode.SelectedIndex = 2;
                        break;
                    case EnumLightMode.World:
                        cbMode.SelectedIndex = 3;
                        break;
                    case EnumLightMode.Sun:
                        cbMode.SelectedIndex = 4;
                        break;
                    default:
                        cbMode.SelectedIndex = 0;
                        break;
                }
                switch (light.LightType)
                {
                    case EnumLightType.Parallel:
                        cbType.SelectedIndex = 0;
                        break;
                    case EnumLightType.Point:
                        cbType.SelectedIndex = 1;
                        break;
                    case EnumLightType.Spot:
                        cbType.SelectedIndex = 2;
                        break;
                    default:
                        cbType.SelectedIndex = 0;
                        break;
                }

                tbPosX .Text= light.Position.X.ToString();
                tbPosY.Text = light.Position.Y.ToString();
                tbPosZ.Text = light.Position.Z.ToString();


                pbAmbient.BackColor = light.Ambient;
                

                pbDiffuse.BackColor = light.Diffuse;
               
                pbSpecular.BackColor = light.Specular;
             


                pbGlobalAmbient.BackColor = globeControl.Globe.SceneAmbient;
               

                cbTerrainUseLighting.Checked = globeControl.Globe.TerrainUseLighting;
                cbModelUseLighting.Checked = globeControl.Globe.ModelUseLighting;

            }

        }

        private void pbAmbient_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pbAmbient.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbAmbient.BackColor = Color.FromArgb(255, dlg.Color.R, dlg.Color.G, dlg.Color.B);
            }
        }

        private void pbDiffuse_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pbDiffuse.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbDiffuse.BackColor = dlg.Color;
            }
        }

        private void pbSpecular_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pbSpecular.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbSpecular.BackColor = dlg.Color;
            }

        }

        private void pbGlobalAmbient_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pbGlobalAmbient.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbGlobalAmbient.BackColor = dlg.Color;
            }

        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMode.SelectedIndex == 0)
            {
                pbGlobalAmbient.BackColor = Color.Black;

            }
            else
            {
                pbGlobalAmbient.BackColor = Color.FromArgb(255, 128, 128, 128);

            }
            /*
            if(cbMode.SelectedIndex==1)
            {
                tbPosX.Text ="0";
                tbPosY.Text = "0";
                tbPosZ.Text = "1";
               // pbGlobalAmbient.BackColor = Color.Black;
            }
            else
            {
                tbPosX.Text = "1";
                tbPosY.Text = "-1";
                tbPosZ.Text = "1";
               // pbGlobalAmbient.BackColor = Color.FromArgb(255, 128, 128, 128);
            }
             */

        }

        private void cbModelUseLighting_CheckedChanged(object sender, EventArgs e)
        {

        }

         
   
        
    }
}
