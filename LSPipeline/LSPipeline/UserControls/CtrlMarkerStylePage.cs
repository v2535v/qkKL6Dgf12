using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
    public partial class CtrlMarkerStylePage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOGeometry m_Geometry = null;
        public CtrlMarkerStylePage(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }

        private void CtrlMarkerStylePage_Load(object sender, EventArgs e)
        {

            if (m_Geometry != null)
            {
                SetControlsByStyle(m_Geometry.Style);
            }

        }
         private void SetControlsByStyle(GSOStyle style)
         {
             GSOMarkerStyle3D markerStyle = style as GSOMarkerStyle3D;
             if (markerStyle != null)
             {
                 if (markerStyle.IconPath != "")
                 {

                     textBoxIconPath.Text = markerStyle.IconPath;
                     try
                     {
                         if (File.Exists(markerStyle.IconPath))
                         {
                             Bitmap bitmap1 = (Bitmap)Bitmap.FromFile(markerStyle.IconPath);
                             pictureBoxIconPath.SizeMode = PictureBoxSizeMode.StretchImage;
                             pictureBoxIconPath.Image = bitmap1;
                         }

                     }
                     catch (System.Exception exp)
                     {
                         Log.PublishTxt(exp);
                     }
                  
                      
                 }
                 pictureBoxIconColor.BackColor = Color.FromArgb(255,markerStyle.IconColor);
                 numericUpDownIconOpaque.Value = markerStyle.IconColor.A;

                 try
                 {
                     numericUpDownIconScale.Value = Convert.ToDecimal(markerStyle.IconScale);
                 }
                 catch (System.Exception exp)
                 {
                     Log.PublishTxt(exp);
                 }


                 GSOTextStyle geoTextStyle = (GSOTextStyle)markerStyle.TextStyle;
                 if (geoTextStyle != null)
                 {

                     pictureBoxTextColor.BackColor = Color.FromArgb(255, geoTextStyle.ForeColor);
                     numericUpDownTextOpaque.Value = geoTextStyle.ForeColor.A;

                     try
                     {
                         numericUpDownTextScale.Value = Convert.ToDecimal(geoTextStyle.Scale);
                     }
                     catch (System.Exception exp)
                     {
                         Log.PublishTxt(exp);
                     }

                    


                 }


             }

         }

         private void pictureBoxIconPath_Click(object sender, EventArgs e)
         {
             OpenFileDialog dlg = new OpenFileDialog();
             dlg.Filter = "图标(*.ico)|*.ico|(*.*)|*.*";
             if (dlg.ShowDialog() == DialogResult.OK)
             {
                 textBoxIconPath.Text = dlg.FileName;
                 try
                 {
                     if (File.Exists(dlg.FileName))
                     {
                         Bitmap bitmap1 = (Bitmap)Bitmap.FromFile(dlg.FileName);
                         pictureBoxIconPath.SizeMode = PictureBoxSizeMode.StretchImage;
                         pictureBoxIconPath.Image = bitmap1;
                     }
                 }
                 catch (System.Exception exp)
                 {
                     Log.PublishTxt(exp);
                 }

                 if (m_Geometry!=null)
                 {
                     GSOMarkerStyle3D markerStyle = m_Geometry.Style as GSOMarkerStyle3D;
                     if (markerStyle != null)
                     {
                         markerStyle.IconVisible = true;
                         markerStyle.IconPath = dlg.FileName;
                     }
                     else
                     {
                         markerStyle = new GSOMarkerStyle3D();
                         markerStyle.IconPath = dlg.FileName;
                         m_Geometry.Style = markerStyle;
                     }
                     if (m_GlobeControl!=null)
                     {
                         m_GlobeControl.Refresh();
                     }

                 }

             }
         }

         private void iconColorChanged()
         {
             if (m_Geometry != null)
             {
                 GSOMarkerStyle3D markerStyle = m_Geometry.Style as GSOMarkerStyle3D;
                 if (markerStyle != null)
                 {
                     markerStyle.IconColor = Color.FromArgb(Convert.ToByte(numericUpDownIconOpaque.Value), pictureBoxIconColor.BackColor); ;
                 }
                 if (m_GlobeControl != null)
                 {
                     m_GlobeControl.Refresh();
                 }
             }
         }
         private void pictureBoxIconColor_Click(object sender, EventArgs e)
         {
             ColorDialog dlg = new ColorDialog();
             dlg.FullOpen = true;
             dlg.Color = pictureBoxIconColor.BackColor;
             if (dlg.ShowDialog() == DialogResult.OK)
             {
                pictureBoxIconColor.BackColor = Color.FromArgb(255, dlg.Color);
                iconColorChanged();
             }
         }

         private void numericUpDownIconOpaque_ValueChanged(object sender, EventArgs e)
         {
             iconColorChanged();
         }

         private void numericUpDownIconScale_ValueChanged(object sender, EventArgs e)
         {
             if (m_Geometry != null)
             {
                 GSOMarkerStyle3D markerStyle = m_Geometry.Style as GSOMarkerStyle3D;
                 if (markerStyle != null)
                 {
                     markerStyle.IconScale = Convert.ToDouble(numericUpDownIconScale.Value);
                 }
                 if (m_GlobeControl != null)
                 {
                     m_GlobeControl.Refresh();
                 }


             }
         }
         private void textColorChanged()
         {
             if (m_Geometry != null)
             {
                 GSOMarkerStyle3D markerStyle = m_Geometry.Style as GSOMarkerStyle3D;
                 if (markerStyle != null)
                 {
                     if (markerStyle.TextStyle == null)
                     {
                         markerStyle.TextStyle = new GSOTextStyle();
                     }
                     markerStyle.TextStyle.ForeColor = Color.FromArgb(Convert.ToByte(numericUpDownTextOpaque.Value), pictureBoxTextColor.BackColor); ;
                 }
                 if (m_GlobeControl != null)
                 {
                     m_GlobeControl.Refresh();
                 }

             }
         }
         private void pictureBoxTextColor_Click(object sender, EventArgs e)
         {

             ColorDialog dlg = new ColorDialog();
             dlg.FullOpen = true;
             dlg.Color = pictureBoxTextColor.BackColor;
             if (dlg.ShowDialog() == DialogResult.OK)
             {
                 pictureBoxTextColor.BackColor = Color.FromArgb(255, dlg.Color.R, dlg.Color.G, dlg.Color.B);
                 textColorChanged();
             }

         }
         private void numericUpDownTextOpaque_ValueChanged(object sender, EventArgs e)
         {
             textColorChanged();

         }
         private void numericUpDownTextScale_ValueChanged(object sender, EventArgs e)
         {
             if (m_Geometry != null)
             {
                 GSOMarkerStyle3D markerStyle = m_Geometry.Style as GSOMarkerStyle3D;
                 if (markerStyle != null)
                 {
                     if (markerStyle.TextStyle == null)
                     {
                         markerStyle.TextStyle = new GSOTextStyle();
                     }
                     markerStyle.TextStyle.Scale = Convert.ToDouble(numericUpDownTextScale.Value);
                 }
                 if (m_GlobeControl != null)
                 {
                     m_GlobeControl.Refresh();
                 }


             }

         }

     
    }
}
