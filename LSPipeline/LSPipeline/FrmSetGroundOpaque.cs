using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
   
    public partial class FrmSetGroundOpaque : Form
    {
        public GSOGlobe globe;
        public FrmSetGroundOpaque()
        {
            InitializeComponent();
            hScrollBar1.Maximum = 100;
            hScrollBar1.Minimum = 0;
            textbox1.Text = "0";
        }

        private void textbox1_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (globe != null && Int32.TryParse(textbox1.Text, out result))
            {
                Int32 nTrans = Convert.ToInt32(textbox1.Text);
                if (nTrans>100)
                {
                    nTrans = 100;
                }
                if (nTrans<0)
                {
                    nTrans = 0;
                }
                hScrollBar1.Value = nTrans;
                textbox1.Text = Convert.ToString(nTrans);
                globe.GroundOpaque = 100 - hScrollBar1.Value;

            }
         
            
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (globe != null)
            {
                globe.GroundOpaque = 100 - hScrollBar1.Value;
                textbox1.Text = Convert.ToString(hScrollBar1.Value);

            }
          

        }

        private void GroundTransSetDlg_Load(object sender, EventArgs e)
        {
            if (globe!=null)
            {
                hScrollBar1.Value = 100 - globe.GroundOpaque;
                textbox1.Text = Convert.ToString(hScrollBar1.Value);
            }

           


                

     
        }
    }
}
