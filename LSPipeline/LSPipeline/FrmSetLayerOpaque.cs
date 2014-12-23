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
    public partial class FrmSetLayerOpaque : Form
    {
        
        public GSOGlobe globe=null;
        public GSOLayer layer = null;
        public FrmSetLayerOpaque()
        {
            InitializeComponent();
            hScrollBar1.Maximum = 100;
            hScrollBar1.Minimum = 0;
            textbox1.Text = "0";
            
        }

        private void SetLayerOpaqueDlg_Load(object sender, EventArgs e)
        {

            if (globe != null && layer != null)
            {
                hScrollBar1.Value = (int)(100 - layer.Opaque);
                textbox1.Text = Convert.ToString(hScrollBar1.Value);
            }

             
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            if (globe != null && layer != null)
            {
                layer.Opaque = 100 - hScrollBar1.Value;
                textbox1.Text = Convert.ToString(hScrollBar1.Value);
                globe.Refresh();

            }          
        }

        private void textbox1_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (globe != null && layer != null && Int32.TryParse(textbox1.Text, out result))
            {
                Int32 nTrans = Convert.ToInt32(textbox1.Text);
                if (nTrans > 100)
                {
                    nTrans = 100;
                }
                if (nTrans < 0)
                {
                    nTrans = 0;
                }
                hScrollBar1.Value = nTrans;
                textbox1.Text = Convert.ToString(nTrans);
                layer.Opaque = 100 - hScrollBar1.Value;
                globe.Refresh();

            }         
        }
    }
}
