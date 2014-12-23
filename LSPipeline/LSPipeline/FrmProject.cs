using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmProject : Form
    {
        public FrmProject()
        {
            InitializeComponent();
        }
        string project;
        private void FrmProject_Load(object sender, EventArgs e)
        {
            //txtLong.KeyDown += new KeyEventHandler(txtLong_KeyDown);
            
        }

        void txtLong_KeyDown(object sender, KeyEventArgs e)
        {
            //setKeys(e.KeyCode, txtLong.Text.Trim());
        }
        private void setKeys(Keys key,string text)
        {
            switch (key)
            { 
                case Keys.O:
           
                
                    break;
                default :
                    text = text.Substring(0, text.Length - 2);
                    break;
            }
        }


        private void btnLatlon2Coord_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整的参数信息！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            project = "+proj=tmerc +lat_0=@ +lon_0=& +k=1 +x_0=% +y_0=$ +ellps=krass +units=m +no_defs";
            //project = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1 +x_0=500000 +y_0=-494.361605 +ellps=krass +units=m +no_defs";
            project = project.Replace("&", textBox1.Text.Trim());
            project = project.Replace("%", textBox2.Text.Trim());
            project = project.Replace("$", textBox3.Text.Trim());
            project = project.Replace("@", txtLatOrigin.Text.Trim());

           int id = GeoScene.Data.GSOProjectManager.AddProject(project);
            double x = 0;
            double y = 0;
            if (txtLong.Text.Trim() == "" && txtLat.Text.Trim() == "")
            {
                MessageBox.Show("数据不能为空！");
                return;
            }
            if (txtLong.Text.Trim() != "")
            {                
                bool bl = Double.TryParse(txtLong.Text.Trim(), out x);
                if (!bl)
                {
                    MessageBox.Show("经度数据不符合要求！");
                    txtLong.Text = "";
                    return;
                }
                if (x > 180 || x < -180)
                {
                    MessageBox.Show("经度数据不符合要求！");
                    txtLong.Text = "";
                    return;
                }
            }
            if (txtLat.Text.Trim() != "")
            { 
                bool bl = Double.TryParse(txtLat.Text.Trim(), out y);
                if (!bl)
                {
                    MessageBox.Show("纬度数据不符合要求！");
                    txtLat.Text = "";
                    return;
                }
                if (y > 90 || y < -90)
                {
                    MessageBox.Show("纬度数据不符合要求！");
                    txtLat.Text = "";
                    return;
                }
            }

            GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x,y);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(pt2d, id);
            if (txtLong.Text.Trim() != "")
            {
                txtX.Text = result.X.ToString();
            }
            else
            {
                txtX.Text = "";
            }
            if (txtLat.Text.Trim() != "")
            {
                txtY.Text = result.Y.ToString();
            }
            else
            {
                txtY.Text = "";
            }
        }

        private void btnCoord2Latlon_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整的参数信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            project = "+proj=tmerc +lat_0=0 +lon_0=& +k=1 +x_0=% +y_0=$ +ellps=krass +units=m +no_defs";
            project = project.Replace("&", textBox1.Text.Trim());
            project = project.Replace("%", textBox2.Text.Trim());
            project = project.Replace("$", textBox3.Text.Trim());
            int id = GeoScene.Data.GSOProjectManager.AddProject(project);
            //int id = GeoScene.Data.GSOProjectManager.AddProject("+proj=tmerc +lat_0=0 +lon_0=117 +k=1 +x_0=555484.8092 +y_0=-4114948.631 +ellps=krass +units=mno_defs");

            double x = 0;
            double y = 0;
            if (txtX.Text.Trim() == "" && txtY.Text.Trim() == "")
            {
                MessageBox.Show("数据不能为空！");
                txtY.Text = "";
                return;
            }
            if (txtX.Text.Trim() != "")
            {
                bool bl = Double.TryParse(txtX.Text.Trim(), out x);
                if (!bl)
                {
                    MessageBox.Show("横轴数据不符合要求！");
                    txtX.Text = "";
                    return;
                }
                
            }
            if (txtY.Text.Trim() != "")
            {
                bool bl = Double.TryParse(txtY.Text.Trim(), out y);
                if (!bl)
                {
                    MessageBox.Show("纵轴数据不符合要求！");
                    txtY.Text = "";
                    return;
                }
            }
            GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(pt2d, id);

            if (txtX.Text.Trim() != "")
            {
                txtLong.Text = result.X.ToString();
            }
            else
            {
                txtLong.Text = "";
            }
            if (txtY.Text.Trim() != "")
            {
                txtLat.Text = result.Y.ToString();
            }
            else
            {
                txtLat.Text = "";
            }
        }

       
    }
}
