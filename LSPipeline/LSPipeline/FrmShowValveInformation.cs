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
    public partial class FrmShowValveInformation : Form
    {
        GSOGlobe globe = null;
        GSOFeatures features = null;
        int valveCount = 0;
        public FrmShowValveInformation(GSOGlobe _globe, GSOFeatures _features,int _valveCount)
        {
            InitializeComponent();

            globe = _globe;           
            features = _features;
            valveCount = _valveCount;
        }

        private void FrmShowValveInformation_Load(object sender, EventArgs e)
        {
            labelValveInformation.Text = "共匹配了" + valveCount + "个阀门！";//localhost_casic_pipe_test
            
            if (features != null)
            {
                labelValveInformation.Text += "共有" + features.Length + "个阀门没有匹配！";
                for (int i = 0; i < features.Length; i++)
                {
                    GSOFeature f = features[i];
                    if (f != null)
                    {                       
                        for (int j = 0; j < f.GetFieldCount(); j++)
                        {
                            GSOFieldDefn fieldDefn = (GSOFieldDefn)f.GetFieldDefn(j);
                            if (fieldDefn != null)
                            {
                                dataGridView1.Columns.Add(fieldDefn.Name, fieldDefn.Name);
                            }
                        }
                        break;
                    }
                }
                for (int i = 0; i < features.Length; i++)
                {
                    GSOFeature f = features[i];
                    if (f != null)
                    {
                        int rowIndex = dataGridView1.Rows.Add();
                        for (int j = 0; j < f.GetFieldCount(); j++)
                        {                     
                            dataGridView1.Rows[rowIndex].Cells[j].Value = f.GetValue(j);
                        }
                    }
                }
            }
        }

        private void 飞行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_feature != null)
            {
                globe.FlyToFeature(m_feature, 0, 45, 3);
            }
        }

        private void 闪烁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < 12)
            {
                count++;
                if (m_feature != null)
                {
                    if (count % 2 != 0)
                    {
                        if (m_feature.Geometry != null)
                        {
                            if (m_feature.Geometry.Style != null)
                            {
                                ((GSOStyle3D)m_feature.Geometry.Style).UsingBlur = true;
                            }
                            else
                            {
                                m_feature.Geometry.Style = new GSOEntityStyle3D();
                                ((GSOStyle3D)m_feature.Geometry.Style).UsingBlur = true;
                            }
                        }
                        else
                        {
                            m_feature.HighLight = true;
                        }
                        globe.Refresh();
                    }
                    else
                    {
                        if (m_feature.Geometry != null)
                        {
                            if (m_feature.Geometry.Style != null)
                            {
                                ((GSOStyle3D)m_feature.Geometry.Style).UsingBlur = false;
                            }
                            else
                            {
                                m_feature.Geometry.Style = new GSOEntityStyle3D();
                                ((GSOStyle3D)m_feature.Geometry.Style).UsingBlur = false;
                            }
                        }
                        else
                        {
                            m_feature.HighLight = false;
                        }
                        globe.Refresh();
                    }
                }
            }
            else
            {
                timer1.Stop();
                count = 0;               
            }
        }
        GSOFeature m_feature = null;
        private void dataGridViewX1_MouseClick(object sender, MouseEventArgs e)
        {
            if (m_feature != null && m_feature.HighLight == true)
            {
                m_feature.HighLight = false;
            }
            m_feature = null;
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hittestinfo = dataGridView1.HitTest(e.X, e.Y);
                if (hittestinfo.RowIndex > -1)
                {
                    if (dataGridView1.Columns.Contains("编号"))
                    {
                        string featureName = dataGridView1.Rows[hittestinfo.RowIndex].Cells["编号"].Value.ToString().Trim();
                        contextMenuStrip1.Show(dataGridView1, e.X, e.Y);

                        for (int j = 0; j < features.Length; j++)
                        {
                            if (features[j].Name == featureName)
                            {
                                m_feature = features[j];
                                break;
                            }
                        }
                    }                   
                }
            }
        }

        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hittestinfo = dataGridView1.HitTest(e.X, e.Y);
                if (hittestinfo.RowIndex > -1)
                {
                    if (dataGridView1.Columns.Contains("编号"))
                    {
                        string featureName = dataGridView1.Rows[hittestinfo.RowIndex].Cells["编号"].Value.ToString().Trim();
                        for (int j = 0; j < features.Length; j++)
                        {
                            if (features[j].Name == featureName)
                            {
                                m_feature = features[j];
                                globe.FlyToFeature(m_feature, 0, 45, 3);
                            }
                        }
                    }
                }
            }
        }
    }
}
