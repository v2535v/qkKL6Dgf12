using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Globe;
using GeoScene.Engine;

namespace WorldGIS
{
    public partial class CtrlDataGridView : UserControl
    {
        public int countLog = 0;
        GSOGlobeControl globeControl1 = null;
        DataTable mDataTable = null;
        public CtrlDataGridView(GSOGlobeControl globeControl,GSOLayer layer1, DataTable dt)
        {
            InitializeComponent();
            globeControl1 = globeControl;
            layer = layer1;
            mDataTable = dt;
            countLog = dt.Rows.Count;
            dataGridView1.DataSource = mDataTable;
            dataGridView1.ReadOnly = true;
        }

        GSOLayer layer = null;
        GSOFeatures features = null;
        GSOFeature m_feature = null;
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hittestinfo = dataGridView1.HitTest(e.X, e.Y);
                if (hittestinfo.RowIndex > -1)
                {
                   
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);

                    if (layer == null)
                    {
                        return;
                    }

                    GSOFeatureLayer pFeatureLayer = layer as GSOFeatureLayer;
                    if (pFeatureLayer != null)
                    {
                        features = layer.GetFeatureByName(dataGridView1.Rows[hittestinfo.RowIndex].Cells["编号"].Value.ToString(), true);
                        if (features != null)
                        {
                            for (int i = 0; i < features.Length; i++)
                            {
                                m_feature = features[i];
                                m_feature.HighLight = false;                               
                            }
                            globeControl1.Globe.Refresh();
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            
            
            GSOFeatureLayer pFeatureLayer = layer as GSOFeatureLayer;
            if (pFeatureLayer != null)
            {
                features = layer.GetFeatureByName(dataGridView1.Rows[e.RowIndex].Cells["编号"].Value.ToString(),true);
                if (features != null)
                {
                    for (int i = 0; i < features.Length; i++)
                    {
                        m_feature = features[i];
                        globeControl1.Globe.FlyToFeature(features[i]);
                    }
                    globeControl1.Globe.Refresh();
                }
            }
        }

        
        private void 定位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_feature != null)
            {
                globeControl1.Globe.FlyToFeature(m_feature);
                globeControl1.Globe.Refresh();
            }
        }

        int timerCount = 0;
        private void 闪烁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timerCount = 0;
            globeControl1.Globe.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_feature != null)
            {
                if (m_feature.HighLight)
                {
                    m_feature.HighLight = false;
                }
                else
                {
                    m_feature.HighLight = true;
                }
                timerCount++;
            }
            if (timerCount > 10)
            {
                if (m_feature.HighLight)
                {
                    m_feature.HighLight = false;
                }
                timer1.Stop();
            }
            globeControl1.Globe.Refresh();
        }
    }    
}
