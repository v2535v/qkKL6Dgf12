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
    public partial class FrmAnalysisCollision : Form
    {
        GSOGlobeControl globeControl1 = new GSOGlobeControl();
        List<DataTable> list = null;

        public FrmAnalysisCollision(GSOGlobeControl globeControl)
        {
            InitializeComponent();
            globeControl1 = globeControl;
        }

        private void FrmOutEarth_Load(object sender, EventArgs e)
        {
            int count = globeControl1.Globe.Layers.Count;
            for (int i = 0; i < count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (layer.Type == EnumLayerType.FeatureLayer)
                {
                    listBox1.Items.Add(layer.Caption);
                }
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("没有选择管线图层！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            list = CollisionAnalysis();
            if (list.Count < 0)
            {
                MessageBox.Show("没有选择管线图层！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool bl = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Rows.Count > 0)
                {
                    bl = true;
                }
            }
            if (!bl)
            {
                MessageBox.Show("没有发生碰撞的管线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tabControlMain.TabPages.Clear();
            for (int i = 0; i < list.Count; i++)
            { 
                GSOLayer layer1 = globeControl1.Globe.Layers.GetLayerByCaption(listBox1.SelectedItems[i].ToString().Trim());
                AddNewCtrlPage(new CtrlDataGridView(globeControl1,layer1,list[i]),layer1.ID.ToString(),layer1.Caption);
            }
            if (statusStrip1.Items.Count > 0 && tabControlMain.TabCount>0)
            {
                tabControlMain.SelectedIndex = 0;
                CtrlDataGridView gridViewRowCount = (CtrlDataGridView)tabControlMain.TabPages[tabControlMain.SelectedIndex].Controls[0];
                
                statusStrip1.Items[0].Text = " 共有 " + gridViewRowCount.countLog + " 条记录";
            }
            globeControl1.Globe.Refresh();
        }

        private void AddNewCtrlPage(Control newCtrlPage, String key, String text)
        {
            tabControlMain.TabPages.Add(key, text);
            tabControlMain.TabPages[key].Controls.Add(newCtrlPage);
            newCtrlPage.Dock = DockStyle.Fill;
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statusStrip1.Items.Count > 0 && tabControlMain.TabCount > 0)
            {               
                CtrlDataGridView gridViewRowCount = (CtrlDataGridView)tabControlMain.TabPages[tabControlMain.SelectedIndex].Controls[0];            
                statusStrip1.Items[0].Text = " 共有 " + gridViewRowCount.countLog + " 条记录";
            }
        }

        private List<DataTable> CollisionAnalysis()
        {
            List<DataTable> listTable = new List<DataTable>();
            GSOPoint3d pntIntersect1;
            GSOPoint3d pntIntersect2;
            int layerCount = listBox1.SelectedItems.Count;

            for (int i = 0; i < layerCount; i++)//遍历所有的图层
            {
                GSOLayer layer1 = globeControl1.Globe.Layers.GetLayerByCaption(listBox1.SelectedItems[i].ToString().Trim());
                if (layer1 != null)
                {
                    DataTable dt = new DataTable();
                    if (layer1.GetAllFeatures().Length > 0)
                    {
                        for (int fieldName = 0; fieldName < layer1.GetAt(0).GetFieldCount(); fieldName++)
                        {
                            GSOFieldDefn field = (GSOFieldDefn)layer1.GetAt(0).GetFieldDefn(fieldName);
                            dt.Columns.Add(field.Name);
                        }
                    }
                    listTable.Add(dt);
                }
            }

            if (listTable.Count > 0 && listTable.Count == layerCount)
            {
                for (int i = 0; i < layerCount; i++)//遍历所有的图层
                {
                    GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(listBox1.SelectedItems[i].ToString().Trim());
                    if (layer.Caption.Contains("管线")) //过滤出管线图层
                    {
                        GSOFeatureLayer flayer = layer as GSOFeatureLayer;
                        GSOFeatureDataset fdataset = flayer.Dataset as GSOFeatureDataset;
                        GSOFeatures feats = flayer.GetAllFeatures();


                        for (int m = 0; m < feats.Length; m++) //遍历图层中的所有管线
                        {
                            GSOFeature feat = feats[m];

                            GSOGeoPolyline3D line1 = feat.Geometry as GSOGeoPolyline3D;
                            if (line1 == null) continue;
                            GSOPipeLineStyle3D pipeStyle1 = line1.Style as GSOPipeLineStyle3D;
                            if (pipeStyle1 == null) continue;
                            for (int j = i; j < layerCount; j++)
                            {
                                GSOLayer layer2 = globeControl1.Globe.Layers.GetLayerByCaption(listBox1.SelectedItems[j].ToString().Trim());
                                GSOFeatureLayer flayer2 = layer2 as GSOFeatureLayer;
                                if (layer2.Caption.Contains("管线"))
                                {
                                    GSOFeatureDataset fdataset2 = flayer2.Dataset as GSOFeatureDataset;
                                    GSOFeatures feats2 = flayer2.GetAllFeatures();
                                    for (int n = 0; n < feats2.Length; n++)//遍历图层中的所有管线
                                    {
                                        if (i == j)
                                        {
                                            if (m >= n)
                                            {
                                                continue;
                                            }
                                        }
                                        GSOFeature feat2 = feats2[n];
                                        GSOGeoPolyline3D line2 = feat2.Geometry as GSOGeoPolyline3D;
                                        if (line2 == null) continue;
                                        GSOPipeLineStyle3D pipeStyle2 = line2.Style as GSOPipeLineStyle3D;
                                        if (pipeStyle2 == null)
                                        {
                                            continue;
                                        }
                                        double dHonLen;
                                        double dVerLen;
                                        double dNoIntersectStartRatio = 0;
                                        // 计算两条线的距离和交点，若果失败返回-1
                                        // 若在同一直线上，并且有交点，返回0
                                        // 若不在同一平面，返回最近两点的距离，并且计算最近两点
                                        double dDist = globeControl1.Globe.Analysis3D.ComputeTwoGeoPolylineDistance(line1, line2, out pntIntersect1, out pntIntersect2, out dHonLen, out dVerLen, false, false, dNoIntersectStartRatio);
                                        if (dDist > -1)
                                        {
                                            if (dDist != 0)
                                            {
                                                dDist = dDist - pipeStyle1.Radius - pipeStyle2.Radius;
                                                if (dDist < 0) //发生碰撞，把发生碰撞的管线名称添加到DataTable里
                                                {

                                                    DataRow newRow = listTable[i].NewRow();
                                                    for (int fieldName = 0; fieldName < feats[m].GetFieldCount(); fieldName++)
                                                    {
                                                        newRow[fieldName] = feats[m].GetValue(fieldName);
                                                    }
                                                    if (newRow != null)
                                                    {
                                                        listTable[i].Rows.Add(newRow);
                                                    }

                                                    DataRow newRow1 = listTable[j].NewRow();
                                                    for (int fieldName = 0; fieldName < feats2[n].GetFieldCount(); fieldName++)
                                                    {
                                                        newRow1[fieldName] = feats2[n].GetValue(fieldName);
                                                    }
                                                    if (newRow != null)
                                                    {
                                                        listTable[j].Rows.Add(newRow1);
                                                    }
                                                    //newRow["编号1"] = layer.Caption + "-" + feats[m].ID;
                                                    //newRow["编号2"] = layer2.Caption + "-" + feats2[n].ID;
                                                    //dt.Rows.Add(newRow);

                                                }
                                            }
                                        }
                                        line2.ReleaseInnerPointer();
                                        feat2.ReleaseInnerPointer();
                                    }
                                    feats2.ReleaseInnerPointer();
                                }
                            }
                            line1.ReleaseInnerPointer();
                            feat.ReleaseInnerPointer();
                        }
                        feats.ReleaseInnerPointer();
                    }
                }
            }
            return listTable;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                StringFormat strFormat = new StringFormat();
                strFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFormat);
            }
        }

       
    }
}
