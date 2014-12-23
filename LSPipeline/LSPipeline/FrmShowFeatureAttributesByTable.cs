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
    public partial class FrmShowFeatureAttributesByTable : Form
    {
        private static GSOGlobeControl globeControl1;
        private static GSOLayer geoLayer;
        private static DataTable dt = null;
        private static FrmShowFeatureAttributesByTable tableAttribute = null;
        public bool isShowFirst = false;
        private FrmShowFeatureAttributesByTable() { }

       
        public static  FrmShowFeatureAttributesByTable GetForm(DataTable importDt, GSOLayer layer, GSOGlobeControl globeControl)
        {
            if (tableAttribute == null)
            {
                tableAttribute = new FrmShowFeatureAttributesByTable(importDt, layer, globeControl);
            }
            else
            {
                dt = importDt;
                geoLayer = layer;
                globeControl1 = globeControl;
            }
            return tableAttribute;
        }
      

        private FrmShowFeatureAttributesByTable(DataTable importDt, GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            dt = importDt;
            geoLayer = layer;
            globeControl1 = globeControl;
        }

        private void Frm_TableAttribute_Load(object sender, EventArgs e)
        {}
        void Frm_TableAttribute_Shown(object sender, EventArgs e)
        {
            isShowFirst = true;
        }
        public void SetDataTable()
        {
            this.Shown += new EventHandler(Frm_TableAttribute_Shown);
            GSOFeatureLayer pFeatureLayer = geoLayer as GSOFeatureLayer;
            if (dt != null)
            {
                if (pFeatureLayer != null)
                {
                    dataGridView1.ReadOnly = !geoLayer.Editable;
                }
               
                dataGridView1.DataSource = dt;
                
                if (statusStrip1.Items.Count > 0)
                {
                    statusStrip1.Items[0].Text = " 共有 " + dt.Rows.Count + " 条记录";
                }
            }
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            GSOFeatureLayer pFeatureLayer = geoLayer as GSOFeatureLayer;
            if (pFeatureLayer != null)
            {
                string featureName = dataGridView1.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                if (featureName == "")
                {
                    return;
                }
                GSOFeatures features = pFeatureLayer.GetFeatureByName(featureName, false);
                GSOFeature feature = new GSOFeature();
                for (int j = 0; j < features.Length; j++)
                {
                    if (features[j].Name == featureName)
                    {
                        feature = features[j];
                        if (globeControl1 != null)
                        {
                            globeControl1.Globe.FlyToFeature(feature);
                            globeControl1.Globe.Refresh();
                        }
                    }
                }
            }
        }

        private void Frm_TableAttribute_FormClosing(object sender, FormClosingEventArgs e)
        {
            tableAttribute = null;
        }
        GSOFeature m_feature = null;
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hittestinfo = dataGridView1.HitTest(e.X, e.Y);
                if (hittestinfo.RowIndex > -1)
                {
                    string featureName = dataGridView1.Rows[hittestinfo.RowIndex].Cells["编号"].Value.ToString();
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
                    featureName = featureName.Trim();


                    if (geoLayer == null)
                    {
                        return;
                    }
                    GSOFeatures features = geoLayer.GetFeatureByName(featureName, false);

                    for (int j = 0; j < features.Length; j++)
                    {
                        if (features[j].Name == featureName)
                        {
                            m_feature = features[j];
                            if (m_feature != null && m_feature.HighLight == true)
                            {
                                m_feature.HighLight = false;
                                globeControl1.Globe.Refresh();
                            }
                            break;
                        }
                    }
                }
            }
        }
        int timerCount = 0;
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

        private void 定位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_feature != null)
            {
                globeControl1.Globe.FlyToFeature(m_feature);
                globeControl1.Globe.Refresh();
            }
        }

        private void 闪烁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timerCount = 0;
            globeControl1.Globe.Refresh();
        }

        private void Frm_TableAttribute_FormClosed(object sender, FormClosedEventArgs e)
        {

            FrmQueryPipelineBySQL frm = new FrmQueryPipelineBySQL(globeControl1);
            frm = this.Owner as FrmQueryPipelineBySQL;
            if (frm != null)
            {
                if (!frm.Visible)
                {
                    frm.Dispose();
                    frm.Close();
                }
            }
        }
    }
}
