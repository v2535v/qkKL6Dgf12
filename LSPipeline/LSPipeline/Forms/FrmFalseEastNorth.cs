using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS.Forms
{
    public partial class FrmFalseEastNorth : Form
    {
        public FrmFalseEastNorth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLong.Text.Trim() == "" && txtLat.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整的参数信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string project = "+proj=tmerc +lat_0=@ +lon_0=& +k=1 +x_0=0 +y_0=0 +ellps=krass +units=m +no_defs";
            project = project.Replace("&", txtCentrelLong.Text.Trim());
            project = project.Replace("@", txtLatOrgin.Text.Trim());
            int id = GeoScene.Data.GSOProjectManager.AddProject(project);

            double x = 0;
            double y = 0;
            if (txtLong.Text.Trim() == "" && txtLat.Text.Trim() == "")
            {
                MessageBox.Show("经纬度数据不能为空！");
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

            GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(pt2d, id);
            
            txtEast.Text = (0 - result.X + Convert.ToDouble(txtX.Text)).ToString();
            txtNorth.Text = (0 - result.Y + Convert.ToDouble(txtY.Text)).ToString();
        }
    }
}
