using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System.IO;

namespace WorldGIS
{
    public partial class CtrlParticleParamPage : UserControl
    {

        GSOGlobeControl mGlobeControl;
        GSOGeometry mGeometry;

        GSOGeoParticle particle = null;
        GSORingParticleEmitter emitter = null;
        GSORingParticleEmitter emitter2 = null;
        GSOPointParticleEmitter emitterPoint = null;
        GSOParticleEffector effector = null;

        public CtrlParticleParamPage(GSOGeometry geometry,GSOGlobeControl globeControl)
        {
            InitializeComponent();

            mGlobeControl = globeControl;
            mGeometry = geometry;
        }

        private void CtrlParticleParamPage_Load(object sender, EventArgs e)
        {
            if (mGeometry != null)
            {
                if (mGeometry.Type == EnumGeometryType.GeoParticle)
                {
                    particle = (GSOGeoParticle)mGeometry;
                    if (particle.GetEmitterCount() > 0)
                    {
                        emitter = particle.GetEmitterAt(0) as GSORingParticleEmitter;
                        emitter2 = particle.GetEmitterAt(1) as GSORingParticleEmitter;
                        if (emitter2 != null)
                        {
                            emitter = emitter2;
                        }
                        if (emitter == null)
                        {
                            emitterPoint = particle.GetEmitterAt(0) as GSOPointParticleEmitter;
                            if (emitterPoint != null)
                            {
                                textBoxSetSizeFixX.Text = emitterPoint.SizeFix.X.ToString();
                                textBoxSetSizeFixY.Text = emitterPoint.SizeFix.Y.ToString();
                                textBoxVelFix.Text = emitterPoint.VelFix.ToString();
                                textBoxVelRnd.Text = emitterPoint.VelRnd.ToString();
                                textBoxAccFix.Text = emitterPoint.AccFix.ToString();
                                textBoxAccRnd.Text = emitterPoint.AccRnd.ToString();
                                textBoxAngleXYFix.Text = emitterPoint.AngleXYFix.ToString();
                                textBoxAngleXYRnd.Text = emitterPoint.AngleXYRnd.ToString();
                                textBoxAngleXZFix.Text = emitterPoint.AngleXZFix.ToString();
                                textBoxAngleXZRnd.Text = emitterPoint.AngleXZRnd.ToString();
                                textBoxLifeFix.Text = emitterPoint.LifeFix.ToString();
                                textBoxLifeRnd.Text = emitterPoint.LifeRnd.ToString();
                                textBoxRotFix.Text = emitterPoint.RotFix.ToString();
                                textBoxRotRnd.Text = emitterPoint.RotRnd.ToString();
                                textBoxRotVelFix.Text = emitterPoint.RotVelFix.ToString();
                                textBoxRotVelRnd.Text = emitterPoint.RotVelRnd.ToString();
                                textBoxEmitPerSec.Text = emitterPoint.EmitPerSec.ToString();
                                textBoxColorRndStart.Enabled = false;
                                textBoxColorRndEnd.Enabled = false;
                                if (emitterPoint.GetEffectorCount() > 0)
                                {
                                    effector = emitterPoint.GetEffectorAt(0);
                                    textBoxStartTime.Text = effector.StartTime.ToString();
                                    textBoxEndTime.Text = effector.EndTime.ToString();
                                }

                                textBoxSetSizeFixX.TextChanged += new EventHandler(textBoxSetSizeFixX_TextChanged);
                                textBoxSetSizeFixY.TextChanged += new EventHandler(textBoxSetSizeFixY_TextChanged); 
                            }
                        }
                        else
                        {
                            textBoxSetSizeFixX.Text = emitter.SizeFix.X.ToString();
                            textBoxSetSizeFixY.Text = emitter.SizeFix.Y.ToString();
                            textBoxVelFix.Text = emitter.VelFix.ToString();
                            textBoxVelRnd.Text = emitter.VelRnd.ToString();
                            textBoxAccFix.Text = emitter.AccFix.ToString();
                            textBoxAccRnd.Text = emitter.AccRnd.ToString();
                            textBoxAngleXYFix.Text = emitter.AngleXYFix.ToString();
                            textBoxAngleXYRnd.Text = emitter.AngleXYRnd.ToString();
                            textBoxAngleXZFix.Text = emitter.AngleXZFix.ToString();
                            textBoxAngleXZRnd.Text = emitter.AngleXZRnd.ToString();                         
                            textBoxLifeFix.Text = emitter.LifeFix.ToString();
                            textBoxLifeRnd.Text = emitter.LifeRnd.ToString();
                            textBoxRotFix.Text = emitter.RotFix.ToString();
                            textBoxRotRnd.Text = emitter.RotRnd.ToString();
                            textBoxRotVelFix.Text = emitter.RotVelFix.ToString();
                            textBoxRotVelRnd.Text = emitter.RotVelRnd.ToString();
                            textBoxEmitPerSec.Text = emitter.EmitPerSec.ToString();
                            textBoxColorRndStart.BackColor = emitter.ColorRndStart;
                            textBoxColorRndEnd.BackColor = emitter.ColorRndEnd;
                            if (emitter.GetEffectorCount() > 0)
                            {
                                effector = emitter.GetEffectorAt(0);
                                textBoxStartTime.Text = effector.StartTime.ToString();
                                textBoxEndTime.Text = effector.EndTime.ToString();
                            }

                            textBoxSetSizeFixX.TextChanged += new EventHandler(textBoxSetSizeFixX_TextChanged);
                            textBoxSetSizeFixY.TextChanged += new EventHandler(textBoxSetSizeFixY_TextChanged);                           
                        }
                    }
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.jpg|*.jpg||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxTexturePath.Text = dlg.FileName;
            }
        }

        private void textBoxColorRndStart_Click(object sender, EventArgs e)
        {
            ColorDialog clg = new ColorDialog();
            clg.Color = textBoxColorRndStart.BackColor;
            
            if (clg.ShowDialog() == DialogResult.OK)
            {
                textBoxColorRndStart.BackColor = clg.Color;
            }
        }

        private void textBoxColorRndEnd_Click(object sender, EventArgs e)
        {
            ColorDialog clg = new ColorDialog();
            clg.Color = textBoxColorRndEnd.BackColor;
            if (clg.ShowDialog() == DialogResult.OK)
            {
                textBoxColorRndEnd.BackColor = clg.Color;
            }
        }

       
        private void textBoxSetSizeFixX_TextChanged(object sender, EventArgs e)
        {
            if (emitter != null)
            {
                float sizeX = 0;
                float sizeY = 0;
                bool blX = float.TryParse(textBoxSetSizeFixX.Text.Trim(), out sizeX);
                bool blY = float.TryParse(textBoxSetSizeFixY.Text.Trim(), out sizeY);
                if (blX && blY)
                {
                    emitter.SetSizeFix(sizeX,sizeY);
                }
            }
            if (emitterPoint != null)
            {
                float sizeX = 0;
                float sizeY = 0;
                bool blX = float.TryParse(textBoxSetSizeFixX.Text.Trim(), out sizeX);
                bool blY = float.TryParse(textBoxSetSizeFixY.Text.Trim(), out sizeY);
                if (blX && blY)
                {
                    emitterPoint.SetSizeFix(sizeX, sizeY);
                }
            }
        }

        private void textBoxSetSizeFixY_TextChanged(object sender, EventArgs e)
        {
            if (emitter != null)
            {
                float sizeX = 0;
                float sizeY = 0;
                bool blX = float.TryParse(textBoxSetSizeFixX.Text.Trim(), out sizeX);
                bool blY = float.TryParse(textBoxSetSizeFixY.Text.Trim(), out sizeY);
                if (blX && blY)
                {
                    emitter.SetSizeFix(sizeX, sizeY);
                    
                }
            }
            if (emitterPoint != null)
            {
                float sizeX = 0;
                float sizeY = 0;
                bool blX = float.TryParse(textBoxSetSizeFixX.Text.Trim(), out sizeX);
                bool blY = float.TryParse(textBoxSetSizeFixY.Text.Trim(), out sizeY);
                if (blX && blY)
                {
                    emitterPoint.SetSizeFix(sizeX, sizeY);

                }
            }
        }


        float checkedDataUserInput(string strUserInput)
        {
            if (emitter != null)
            {
                float result = 0;
                bool bl = float.TryParse(strUserInput, out result);
                if (bl)
                {
                    return result;
                }
                return -1;
            }
            if (emitterPoint != null)
            {
                float result = 0;
                bool bl = float.TryParse(strUserInput, out result);
                if (bl)
                {
                    return result;
                }
                return -1;
            }
            return -1;
        }
        private void textBoxVelFix_TextChanged(object sender, EventArgs e)//初速度
        {
            if (emitter != null)
            {
                float param = checkedDataUserInput(textBoxVelFix.Text.Trim());
                if (param != -1)
                {
                    emitter.VelFix = param;
                }
            }
            if (emitterPoint != null)
            {
                float param = checkedDataUserInput(textBoxVelFix.Text.Trim());
                if (param != -1)
                {
                    emitterPoint.VelFix = param;
                }
            }
        }

        private void textBoxVelRnd_TextChanged(object sender, EventArgs e)
        {
            
            if (emitter != null)
            {
                float param = checkedDataUserInput(textBoxVelRnd.Text.Trim());
                if (param != -1)
                {
                    emitter.VelRnd = param;
                }
            }
            if (emitterPoint != null)
            {
                float param = checkedDataUserInput(textBoxVelRnd.Text.Trim());
                if (param != -1)
                {
                    emitterPoint.VelRnd = param;
                }
            }
        }

        private void textBoxAccFix_TextChanged(object sender, EventArgs e)//初始加速度
        {
            float param = checkedDataUserInput(textBoxAccFix.Text.Trim());
            if (param != -1)
            {
                
                if (emitter != null)
                {
                    emitter.AccFix = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.AccFix = param;
                }
            }
        }

        private void textBoxAccRnd_TextChanged(object sender, EventArgs e)
        {
            float param = checkedDataUserInput(textBoxAccRnd.Text.Trim());
            if (param != -1)
            {
               
                if (emitter != null)
                {
                    emitter.AccRnd = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.AccRnd = param;
                }
            }
        }

        private void textBoxAngleXYFix_TextChanged(object sender, EventArgs e)//粒子发射方向角
        {
            float param = checkedDataUserInput(textBoxAngleXYFix.Text.Trim());
            if (param != -1)
            {
              
                if (emitter != null)
                {
                    emitter.AngleXYFix = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.AngleXYFix = param;
                }
            }
        }
       
        private void textBoxAngleXYRnd_TextChanged(object sender, EventArgs e)
        {
            float param = checkedDataUserInput(textBoxAngleXYRnd.Text.Trim());
            if (param != -1)
            {
               
                if (emitter != null)
                {
                    emitter.AngleXYRnd = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.AngleXYRnd = param;
                }
            }
        }

        private void textBoxAngleXZFix_TextChanged(object sender, EventArgs e)//粒子发射高度角
        {
            float param = checkedDataUserInput(textBoxAngleXZFix.Text.Trim());
            if (param != -1)
            {
                
                if (emitter != null)
                {
                    emitter.AngleXZFix = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.AngleXZFix = param;
                }
            }
        }

        private void textBoxAngleXZRnd_TextChanged(object sender, EventArgs e)
        {
            float param = checkedDataUserInput(textBoxAngleXZRnd.Text.Trim());
            if (param != -1)
            {
                
                if (emitter != null)
                {
                    emitter.AngleXZRnd = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.AngleXZRnd = param;
                }
            }
        }

      
        private void textBoxLifeFix_TextChanged(object sender, EventArgs e)//粒子生命值
        {
            float param = checkedDataUserInput(textBoxLifeFix.Text.Trim());
            if (param != -1)
            {
               
                if (emitter != null)
                {
                    emitter.LifeFix = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.LifeFix = param;
                }
            }
        }

        private void textBoxLifeRnd_TextChanged(object sender, EventArgs e)
        {
            float param = checkedDataUserInput(textBoxLifeRnd.Text.Trim());
            if (param != -1)
            {
               
                if (emitter != null)
                {
                    emitter.LifeRnd = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.LifeRnd = param;
                }
            }
        }

        private void textBoxRotFix_TextChanged(object sender, EventArgs e)//初始旋转角度
        {
            float param = checkedDataUserInput(textBoxRotFix.Text.Trim());
            if (param != -1)
            {
               
                if (emitter != null)
                {
                    emitter.RotFix = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.RotFix = param;
                }
            }
        }

        private void textBoxRotRnd_TextChanged(object sender, EventArgs e)
        {
            float param = checkedDataUserInput(textBoxRotRnd.Text.Trim());
            if (param != -1)
            {
                if (emitter != null)
                {
                    emitter.RotRnd = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.RotRnd = param;
                }
            }
        }

        private void textBoxRotVelFix_TextChanged(object sender, EventArgs e)//初始旋转速度
        {
            float param = checkedDataUserInput(textBoxRotVelFix.Text.Trim());
            if (param != -1)
            {                
                if (emitter != null)
                {
                    emitter.RotVelFix = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.RotVelFix = param;
                }
            }
        }

        private void textBoxRotVelRnd_TextChanged(object sender, EventArgs e)
        {
            float param = checkedDataUserInput(textBoxRotVelRnd.Text.Trim());
            if (param != -1)
            {
                if (emitter != null)
                {
                    emitter.RotVelRnd = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.RotVelRnd = param;
                }
            }
           
        }

        private void textBoxEmitPerSec_TextChanged(object sender, EventArgs e)//每秒发射粒子数
        {
            float param = checkedDataUserInput(textBoxEmitPerSec.Text.Trim());
            if (param != -1)
            {
                if (emitter != null)
                {
                    emitter.EmitPerSec = param;
                }
                if (emitterPoint != null)
                {
                    emitterPoint.EmitPerSec = param;
                }
            }
        }

        private void textBoxColorRndStart_BackColorChanged(object sender, EventArgs e)//粒子发射的初始颜色
        {
            if (emitter != null)
            {
                emitter.ColorRndStart = textBoxColorRndStart.BackColor;
            }
            if (emitterPoint != null)
            {
                emitterPoint.ColorRndStart = textBoxColorRndStart.BackColor;
            }
        }

        private void textBoxColorRndEnd_BackColorChanged(object sender, EventArgs e)
        {
            if (emitter != null)
            {
                emitter.ColorRndEnd = textBoxColorRndEnd.BackColor;
            }
            if (emitterPoint != null)
            {
                emitterPoint.ColorRndEnd = textBoxColorRndEnd.BackColor;
            }
        }

        private void textBoxTexturePath_TextChanged(object sender, EventArgs e)//粒子图片路径
        {
            if (emitter != null)
            {
                if (File.Exists(textBoxTexturePath.Text))
                {
                    emitter.TexturePath = textBoxTexturePath.Text;
                }
            }
            if (emitterPoint != null)
            {
                if (File.Exists(textBoxTexturePath.Text))
                {
                    emitterPoint.TexturePath = textBoxTexturePath.Text;
                }
            }
        }

        private void textBoxStartTime_TextChanged(object sender, EventArgs e)//效果器开始时间
        {
            if (effector != null)
            {
                float param = checkedDataUserInput(textBoxStartTime.Text.Trim());
                if (param != -1)
                {
                    effector.StartTime = param;
                }
            }
        }

        private void textBoxEndTime_TextChanged(object sender, EventArgs e)//效果器结束时间
        {
            if (effector != null)
            {
                float param = checkedDataUserInput(textBoxEndTime.Text.Trim());
                if (param != -1)
                {
                    effector.EndTime = param;
                }
            }
        }

    }
}
