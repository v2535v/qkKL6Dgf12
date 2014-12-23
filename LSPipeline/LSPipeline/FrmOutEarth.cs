using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using GeoScene.Engine;
using DevComponents.DotNetBar;

using System.IO;
using System.Xml;

namespace WorldGIS
{
    public partial class FrmOutEarth : Form
    {
        GSOGlobeControl globeControl1 = new GSOGlobeControl();
        DatabaseConnectParams connectParams;
        DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        ToolStripStatusLabel toolStripNumbers;
        GSOLayer layer = null;
        public FrmOutEarth(GSOGlobeControl _globeControl)
        {
            InitializeComponent();
            globeControl1 = _globeControl;           
        }

        public FrmOutEarth(GSOGlobeControl globeControl, DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX11, ToolStripStatusLabel toolStripNumbers1)
        {
            InitializeComponent();
            globeControl1 = globeControl;
            dataGridViewX1 = dataGridViewX11;
            toolStripNumbers = toolStripNumbers1;
        }

        private void FrmOutEarth_Load(object sender, EventArgs e)
        {
            int count = globeControl1.Globe.Layers.Count;
            for (int i = 0; i < count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (layer.Dataset != null && layer.Dataset.DataSource != null &&
                    (layer.Dataset.DataSource.Type == EnumDataSourceType.SqlServer || layer.Dataset.DataSource.Type == EnumDataSourceType.Oracle))
                {
                    cmbPipeShow.Items.Add(layer.Caption);
                }
            }
            if (cmbPipeShow.Items.Count > 0)
            {
                cmbPipeShow.SelectedIndex = 0;                
            }
        }
        private GSOPoint3ds getAllPointInPipeline(GSOGeoPolyline3D pipeline)
        {
            GSOPoint3ds points = new GSOPoint3ds();
            if (pipeline != null)
            {
                for (int i = 0; i < pipeline.PartCount; i++)
                {
                    GSOPoint3ds pnts = pipeline[i];
                    for (int j = 0; j < pnts.Count; j++)
                    {
                        GSOPoint3d pt = pnts[j];
                        points.Add(pt);
                    }
                }
            }
            return points;
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            int n = 0;
            layer = globeControl1.Globe.Layers.GetLayerByCaption(cmbPipeShow.Text.Trim());
            GSOFeatureLayer flayer = layer as GSOFeatureLayer;
            if(flayer == null)
            {
                return ;
            }
            GSOFeatureDataset fdataset = flayer.Dataset as GSOFeatureDataset;
            if (fdataset == null || fdataset.DataSource == null)
            {
                return;
            }
            connectParams = Utility.getConnectParamsByDatasourceName(globeControl1, fdataset.DataSource.Name);
            if (connectParams == null)
            {
                return;
            }
            GSOFeatures feats = flayer.GetAllFeatures();
            string type = layer.Caption.Substring(0, 2);
            string sql = "select * " + " from " + layer.Caption + "  where";
            for (int i = 0; i < feats.Length; i++)
            {
                GSOFeature f = feats[i];
                if (f.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                {
                    GSOGeoPolyline3D line = f.Geometry as GSOGeoPolyline3D;
                    GSOPipeLineStyle3D style = line.Style as GSOPipeLineStyle3D;
                    if (style != null)
                    {
                        GSOPoint3ds pnts = getAllPointInPipeline(line);
                        for (int j = 0; j < pnts.Count; j++)
                        {
                            GSOPoint3d pt = pnts[j];
                            if (Math.Abs(pt.Z) < style.Radius)
                            {
                                n++;
                                sql += "  编号='" + f.Name + "' or ";
                                break;
                            }
                        }
                    }
                }
            }
            if (n > 0)
            {
                sql = sql.Substring(0, sql.Length - 3);
                DataTable dt = new DataTable();
                dt = OledbHelper.QueryTable(sql, connectParams);

                if (dt == null)
                {
                    MessageBox.Show("没有地上管线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (dt.Columns.Count > 3)
                    {
                        dt.Columns.RemoveAt(0);
                        dt.Columns.RemoveAt(0);
                        dt.Columns.RemoveAt(0);
                    }     
                    dataGridView1.ReadOnly = !layer.Editable;
                    dataGridView1.DataSource = dt;
                    if (statusStrip1.Items.Count > 0)
                    {
                        statusStrip1.Items[0].Text = " 共有 " + dt.Rows.Count + " 条记录";
                    }
                    globeControl1.Globe.Refresh();
                }
            }
            else
            {
                MessageBox.Show("没有地上管线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView1.DataSource = null;
                if (statusStrip1.Items.Count > 0)
                {
                    statusStrip1.Items[0].Text = " 共有 " + 0 + " 条记录";
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (layer == null)
            {
                return;
            }
            GSOFeatureLayer pFeatureLayer = layer as GSOFeatureLayer;
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


                    if (layer == null)
                    {
                        return;
                    }
                    GSOFeatures features = layer.GetFeatureByName(featureName, false);

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
