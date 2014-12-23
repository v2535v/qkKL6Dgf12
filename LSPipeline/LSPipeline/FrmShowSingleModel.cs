using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;

namespace WorldGIS
{
    
    public partial class FrmShowSingleModel : Form
    {
        public GSOPlane3DControl plane3DControl;
        private long m_lLastTime;
        private Point m_pntLast;
        public FrmShowSingleModel()
        {
            InitializeComponent();
            plane3DControl = new GSOPlane3DControl();
            panel1.Controls.Add(plane3DControl);
            plane3DControl.Dock = DockStyle.Fill;
            
        }
         
        private void ShowSingleModelDlg_Load(object sender, EventArgs e)
        {
            plane3DControl.MouseDown += new MouseEventHandler(plane3DControl_MouseDown);
            plane3DControl.MouseUp += new MouseEventHandler(plane3DControl_MouseUp);

        }
        void plane3DControl_MouseDown(object sender, MouseEventArgs e)
        {
            rMouseUpContextMenuStrip.Hide();
            if (e.Button == MouseButtons.Right)
            {
                m_lLastTime = DateTime.Now.Ticks;
                m_pntLast.X = e.X;
                m_pntLast.Y = e.Y;
            }

        }
        void plane3DControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

               // TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks - m_lLastTime);
                if (e.X - m_pntLast.X == 0 && e.Y - m_pntLast.Y==0)
                {
                    rMouseUpContextMenuStrip.Show(plane3DControl,e.X, e.Y);
                }

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fullExtemtMenuItem_Click(object sender, EventArgs e)
        {
            plane3DControl.Plane3DScene.FullExtent();
        }
    }
}
