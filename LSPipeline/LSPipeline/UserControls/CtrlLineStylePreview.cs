using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using System.Drawing.Drawing2D; 
namespace WorldGIS
{
    public partial class CtrlLineStylePreview : UserControl
    {
        public GSOStyle m_Style = null;
        public CtrlLineStylePreview(GSOStyle style)
        {
            InitializeComponent();
            m_Style = style;

        }

        public void CtrlLineStylePreview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

         
            /*
            Color FColor = Color.FromArgb(255, 255, 255);

            Color TColor = Color.FromArgb(221, 221, 221);

            Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);

            g.FillRectangle(b, this.ClientRectangle);
             */
             


            if (m_Style!=null)
            {
                GSOSimpleLineStyle3D simpleLineStyle= m_Style as GSOSimpleLineStyle3D;
                if (simpleLineStyle!=null)
                {
                    DrawSimpleLine(g, simpleLineStyle);
                }
                else
                {
                    GSOPipeLineStyle3D pipeLineStyle = m_Style as GSOPipeLineStyle3D;
                    if (pipeLineStyle!=null)
                    {
                        DrawPipeLine(g, pipeLineStyle);
                    }
                }
            }
            else
            {
                
                StringFormat stringFormat = new StringFormat();
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Center;
                g.DrawString("无风格", new Font("宋体", 10), new SolidBrush(Color.Black), this.Bounds, stringFormat);
            }


        }
        public void DrawSimpleLine(Graphics g,GSOSimpleLineStyle3D simpleLineStyle)
        {

            int nStartX = (int)(Width * 0.1);
            Pen newPen = new Pen(simpleLineStyle.LineColor,(float)simpleLineStyle.LineWidth);

            switch (simpleLineStyle.LineType)
            {
                case EnumLineType.Solid:
                    newPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case EnumLineType.Dash:
                    newPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    break;
                case EnumLineType.Dot:
                    newPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    break;
               
                case EnumLineType.DashDot:
                    newPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    break;
                case EnumLineType.DashDotDot:
                    newPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                    break;
              
            }

            Point pt1 = new Point(nStartX, this.Height / 2);
            Point pt2 = new Point(Width - nStartX, this.Height / 2);

            g.DrawLine(newPen, pt1, pt2);


            
        }
        public void DrawPipeLine(Graphics g,GSOPipeLineStyle3D pipeLineStyle)
        {
            Pen newPen = new Pen(pipeLineStyle.LineColor, 1.0f);

            
            int nEllipseHeight = (int)(Height * 0.3);
            int nEllipseWidth = nEllipseHeight/2;
            int nStartX = (int)(Width*0.1);

            int nHalfHeight=Height/2;
           

            int nBodyStartX=nStartX+nEllipseWidth/2;



            Rectangle rcEllipse = new Rectangle(nStartX, nHalfHeight - nEllipseHeight / 2, nEllipseWidth, nEllipseHeight);
            Rectangle rcTailEllipse = new Rectangle(this.Width - nStartX - nEllipseWidth, nHalfHeight - nEllipseHeight / 2, nEllipseWidth, nEllipseHeight);
            Rectangle rcFill = new Rectangle(nBodyStartX, rcEllipse.Top, Width - 2*nBodyStartX+nEllipseWidth/2, nEllipseHeight);

            Color FColor = pipeLineStyle.LineColor;

            Color TColor = Color.FromArgb(255, 255, 255);

            Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.BackwardDiagonal);

            g.FillRectangle(b, rcFill);



          
            g.DrawEllipse(newPen, rcEllipse);

            
            g.DrawEllipse(newPen, rcTailEllipse);


            g.DrawLine(newPen, nBodyStartX, rcEllipse.Top, Width - nBodyStartX, rcEllipse.Top);
            g.DrawLine(newPen, nBodyStartX, rcEllipse.Bottom, Width - nBodyStartX, rcEllipse.Bottom);


            


        }

        private void CtrlLineStylePreview_Load(object sender, EventArgs e)
        {

        }
    }
}
