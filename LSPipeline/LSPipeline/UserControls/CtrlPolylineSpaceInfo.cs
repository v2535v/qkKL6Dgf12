using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GeoScene.Globe;
using GeoScene.Data;

namespace WorldGIS
{
    public partial class CtrlPolylineSpaceInfo : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOLayer mlayer = null;
        public GSOFeature mfeature = null;
        public GSOGeometry m_Geometry = null;
        private int m_nCurSelected = -1;
        private GSOFeature m_FeatureSelPoint = null;

        public static GSOPipeLineStyle3D m_style;
        public static GSOPipeLineStyle3D m_oldStyle;
        
        private Boolean m_bInitialized = false;
        public CtrlPolylineSpaceInfo(GSOGeometry geometry, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;
        }
        public CtrlPolylineSpaceInfo(GSOGeometry geometry,GSOFeature feature,GSOLayer layer,GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Geometry = geometry;

            mlayer = layer;
            mfeature = feature;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (m_FeatureSelPoint != null)
            {
                m_FeatureSelPoint.Delete();
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }

        private GSOPoint3ds GetCurNodes()
        {
            GSOPoint3ds nodes = null;
            if (m_Geometry.Type == EnumGeometryType.GeoPolyline3D)
            {

                GSOGeoPolyline3D geoPolyline3D = m_Geometry as GSOGeoPolyline3D;
                if (geoPolyline3D.PartCount > 0)
                {
                    //一条线由多条子线组成，目前就显示第一条子线的节点内容把
                    nodes = geoPolyline3D[0];
                }
            }
            else if (m_Geometry.Type == EnumGeometryType.GeoPolygon3D ||
                m_Geometry.Type == EnumGeometryType.GeoWater)
            {
                GSOGeoPolygon3D geoPolygon3D = m_Geometry as GSOGeoPolygon3D;
                if (geoPolygon3D.PartCount > 0)
                {
                    nodes = geoPolygon3D[0];
                }
            }
            return nodes;
        }
        private void UpdateNodeViewList()
        {

            GSOPoint3ds nodes = GetCurNodes();
           
            if (nodes!=null)
            {
                listViewNodeList.Items.Clear();
                for (int i = 0; i < nodes.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems[0].Text = i.ToString();
                    item.SubItems.Add(nodes[i].X.ToString());
                    item.SubItems.Add(nodes[i].Y.ToString());
                    item.SubItems.Add(nodes[i].Z.ToString());
                    listViewNodeList.Items.Add(item);
                }
                labelNumPoints.Text = "节点共" + listViewNodeList.Items.Count.ToString() + "个";
            }
           
        }
        private void CtrlPolylineSpaceInfo_Load(object sender, EventArgs e)
        {
           

            if (m_Geometry!=null)
            {
                UpdateNodeViewList();

                textBoxZ.Maximum = decimal.MaxValue;
                textBoxZ.Minimum = decimal.MinValue;
                textBoxAllZAdded.Maximum = decimal.MaxValue;
                textBoxAllZAdded.Minimum = decimal.MinValue;

                // 高度模式
                switch (m_Geometry.AltitudeMode)
                {
                    case EnumAltitudeMode.Absolute:
                        comboBoxAltMode.SelectedIndex = 0;
                        break;
                    case EnumAltitudeMode.ClampToGround:
                        comboBoxAltMode.SelectedIndex = 1;
                        break;
                    case EnumAltitudeMode.RelativeToGround:
                        comboBoxAltMode.SelectedIndex = 2;
                        break;
                }
                 
            }

        }
        private void CheckSelFeaturePoint()
        {
            if (m_nCurSelected >= 0 && m_nCurSelected < listViewNodeList.Items.Count)
            {
                GSOGeoPoint3D geoPoint3D = null;
                if (m_FeatureSelPoint == null || m_FeatureSelPoint.IsDeleted)
                {
                    m_FeatureSelPoint = new GSOFeature();
                    geoPoint3D = new GSOGeoMarker();
                    GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                    style.IconPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/CrossIcon.png";
                    geoPoint3D.Style = style;
                   
                    m_FeatureSelPoint.Geometry = geoPoint3D;
                    if (m_GlobeControl!=null)
                    {
                        m_GlobeControl.Globe.MemoryLayer.AddFeature(m_FeatureSelPoint);
                        m_GlobeControl.Refresh();
                    }
                }
                /*
                else
                {
                    geoPoint3D = m_FeatureSelPoint.Geometry as GSOGeoPoint3D;
                }
                */

                 
                geoPoint3D = m_FeatureSelPoint.Geometry as GSOGeoPoint3D;
                geoPoint3D.AltitudeMode = m_Geometry.AltitudeMode;  
                
                try
                {
                    ListViewItem itemSel = listViewNodeList.Items[m_nCurSelected];
                    geoPoint3D.X = Double.Parse(itemSel.SubItems[1].Text);
                    geoPoint3D.Y = Double.Parse(itemSel.SubItems[2].Text);
                    geoPoint3D.Z = Double.Parse(itemSel.SubItems[3].Text);
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }

            }


        }
        private void CheckOldAndSetCurSelItem(int nCurItemIndex)
        {
            if (m_nCurSelected != nCurItemIndex)
            {
                if (m_nCurSelected > -1 && m_nCurSelected < listViewNodeList.Items.Count)
                {
                    ListViewItem itemOldSel = listViewNodeList.Items[m_nCurSelected];
                    itemOldSel.ForeColor = Color.Black;
                    itemOldSel.BackColor = SystemColors.Window;

                }

                m_nCurSelected = nCurItemIndex;
            }
        }
        private void SelectItem(int nItemIndex)
        {
            if (nItemIndex < 0)
            {
                return;
            }
            int nRealIndex = nItemIndex;

            if (nRealIndex > listViewNodeList.Items.Count-1)
            {
                nRealIndex = listViewNodeList.Items.Count - 1;
            }

            CheckOldAndSetCurSelItem(nRealIndex);
            CheckSelFeaturePoint();
           
            ListViewItem item = listViewNodeList.Items[nRealIndex];
            item.Selected = true;
            item.BackColor = SystemColors.Highlight;
            item.ForeColor = Color.White;
            listViewNodeList.SelectedIndices.Clear();
            listViewNodeList.SelectedIndices.Add(nRealIndex);//**真正让其选择

        }
        private void listViewNodeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNodeList.SelectedItems.Count>0)
            {
                ListViewItem item = listViewNodeList.SelectedItems[0];
                if (item != null)
                {
                    CheckOldAndSetCurSelItem(item.Index);
                    CheckSelFeaturePoint();
                    textBoxX.Text = item.SubItems[1].Text;
                    textBoxY.Text = item.SubItems[2].Text;
                    try
                    {
                        textBoxZ.Value = decimal.Parse(item.SubItems[3].Text);
                    }
                    catch (Exception exp)
                    {
                        Log.PublishTxt(exp);
                        MessageBox.Show(exp.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
           
        }

        private void comboBoxAltMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                switch (comboBoxAltMode.SelectedIndex)
                {
                    case 0:
                        m_Geometry.AltitudeMode = EnumAltitudeMode.Absolute;
                        break;
                    case 1:
                        m_Geometry.AltitudeMode = EnumAltitudeMode.ClampToGround;
                        break;
                    case 2:
                        m_Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        break;
                }
                CheckSelFeaturePoint();
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
                
            }
        }

        private void buttonMoveAllZ_Click(object sender, EventArgs e)
        {
            if (m_Geometry != null)
            {
                double dZAdded =0;
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    dZAdded = Convert.ToDouble(textBoxAllZAdded.Value.ToString());
                    m_Geometry.MoveZ(dZAdded);

                    // 这个比较慢先暂时不用
                    //UpdateNodeViewList();
                    for (int i = 0; i < listViewNodeList.Items.Count; i++)
                    {
                        ListViewItem item = listViewNodeList.Items[i];
                        item.SubItems[3].Text = (Double.Parse(item.SubItems[3].Text) + dZAdded).ToString();
                    }
                    SelectItem(m_nCurSelected);
                    if (m_GlobeControl!=null)
                    {
                        m_GlobeControl.Refresh();
                    }

                    
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                    //MessageBox.Show(exp.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    
                    
            }
        }
       
        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            
                GSOPoint3ds nodes = GetCurNodes();
                if (nodes!=null)
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    GSOPoint3d newPoint = new GSOPoint3d();
                    try
                    {
                        newPoint.X = Double.Parse(textBoxX.Text);
                        newPoint.Y = Double.Parse(textBoxY.Text);
                        newPoint.Z = Double.Parse(textBoxZ.Value.ToString());

                    }
                    catch (System.Exception exp)
                    {
                        Log.PublishTxt(exp);
                        //MessageBox.Show(exp.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    /*
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(textBoxX.Text);
                    item.SubItems.Add(textBoxY.Text);
                    item.SubItems.Add(textBoxZ.Text);
                    listViewNodeList.Items.Add(item);
                    */

                    nodes.Add(newPoint);
                    UpdateNodeViewList();
                    // 选中最后一个
                    SelectItem(listViewNodeList.Items.Count - 1);
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }
           
            
            
        }
        private void buttonInsertNode_Click(object sender, EventArgs e)
        {
           

                if (listViewNodeList.SelectedIndices.Count > 0)
                {
                    int nSelIndex = listViewNodeList.SelectedIndices[0];
                    GSOPoint3ds nodes = GetCurNodes();

                    if (nodes != null && nodes.Count > nSelIndex)
                    {
                        
                        m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                        GSOPoint3d newPoint = new GSOPoint3d();
                        try
                        {
                            newPoint.X = Double.Parse(textBoxX.Text);
                            newPoint.Y = Double.Parse(textBoxY.Text);
                            newPoint.Z = Double.Parse(textBoxZ.Value.ToString());
                        }
                        catch (System.Exception exp)
                        {
                            Log.PublishTxt(exp);
                        }


                        nodes.Insert(nSelIndex, newPoint);

                        /*
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add(textBoxX.Text);
                        item.SubItems.Add(textBoxY.Text);
                        item.SubItems.Add(textBoxZ.Text);
                        listViewNodeList.Items.Insert(nSelIndex,item);
                        */

                        UpdateNodeViewList();
                        // 选中刚才的那个索引
                        SelectItem(m_nCurSelected);
                        if (m_GlobeControl != null)
                        {
                            m_GlobeControl.Refresh();
                        }                       
                    }
                }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
          
  
                if (listViewNodeList.SelectedIndices.Count>0)
                {
                    int nSelIndex = listViewNodeList.SelectedIndices[0];
                    GSOPoint3ds nodes = GetCurNodes();
                    if (nodes != null && nodes.Count > nSelIndex)
                    {
                        m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                        GSOPoint3d newPoint = new GSOPoint3d();
                        try
                        {
                            newPoint.X = Double.Parse(textBoxX.Text);
                            newPoint.Y = Double.Parse(textBoxY.Text);
                            newPoint.Z = Double.Parse(textBoxZ.Value.ToString());
                        }
                        catch (System.Exception exp)
                        {
                            Log.PublishTxt(exp);
                        }

                        nodes[nSelIndex] = newPoint;
                        ListViewItem item = listViewNodeList.Items[nSelIndex];
                        item.SubItems[1].Text = textBoxX.Text;
                        item.SubItems[2].Text = textBoxY.Text;
                        item.SubItems[3].Text = textBoxZ.Value.ToString();

                        // 选中刚才的那个索引

                        SelectItem(m_nCurSelected);

                        if (m_GlobeControl != null)
                        {
                            m_GlobeControl.Refresh();
                        }                        
                    }
                }
        }

        private void buttonDelNode_Click(object sender, EventArgs e)
        {
            if (listViewNodeList.SelectedIndices.Count>0)
            {
                int nSelIndex = listViewNodeList.SelectedIndices[0];
                GSOPoint3ds nodes = GetCurNodes();
                if (nodes != null && nodes.Count > nSelIndex)
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    nodes.Remove(nSelIndex);
                    UpdateNodeViewList();
                    // 选中刚才的那个索引
                    SelectItem(m_nCurSelected);
                    
                    
                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }  
                }
            }           
        }
       
        // 下面两个消息确保listview失去交点的时候选中的对象不消失
        private void listViewNodeList_Validated(object sender, EventArgs e)
        {
            SelectItem(m_nCurSelected);            
        }       
    }
}
