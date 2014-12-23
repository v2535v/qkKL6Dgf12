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
    public partial class FrmEditLayerAttributesByTable : Form
    {
        private static GSOGlobeControl globeControl1;
        private static GSOLayer geoLayer;
        private static GSOFeatures m_features;
        
        private static FrmEditLayerAttributesByTable tableAttribute = null;
        public bool isShow = true;
        public bool isShowFirst = false;
        private FrmEditLayerAttributesByTable() { }

        public static FrmEditLayerAttributesByTable GetForm(GSOLayer layer, GSOFeatures selectFeatures, GSOGlobeControl globeControl)
        { 
            if (tableAttribute == null)
            {
                tableAttribute = new FrmEditLayerAttributesByTable(layer, selectFeatures, globeControl);
            }
            else
            {             
                geoLayer = layer;
                m_features = selectFeatures;
                globeControl1 = globeControl;
            }
            tableAttribute.isShow = true;
            return tableAttribute;
        }
      
        private FrmEditLayerAttributesByTable(GSOLayer layer,GSOFeatures selectFeatures, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            geoLayer = layer;
            m_features = selectFeatures;
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
            GSOFeatureDataset pFeatureDataset = pFeatureLayer.Dataset as GSOFeatureDataset;
            if (pFeatureLayer == null || pFeatureDataset == null)
            {
                MessageBox.Show("该数据不是属性数据，属性表为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isShow = false;
                return;
            }
            else
            {
                GSOFeatures feats = m_features;// pFeatureLayer.GetAllFeatures();
                GSOFeature feat = feats[0];

                countLog = 0;
                GetReallyFeature(feats);
                try
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    for (int j = 0; j < pFeatureDataset.FieldCount; j++)
                    {
                        GSOFieldAttr field = pFeatureDataset.GetField(j);
                        dataGridView1.Columns.Add(field.Name, field.Name);
                    }
                    for (int i = 0; i < feats.Length; i++)
                    {
                        feat = feats[i];
                        if (feat == null)
                        {
                            continue;
                        }
                        int rowIndex = dataGridView1.Rows.Add();
                        dataGridView1.Rows[rowIndex].Tag = feat;
                        for (int j = 0; j < feat.GetFieldCount(); j++)
                        {
                            GSOFieldDefn field = (GSOFieldDefn)feat.GetFieldDefn(j);
                            object fieldValue = feat.GetValue(j);
                            if (fieldValue != null)
                            {
                                dataGridView1.Rows[rowIndex].Cells[j].Value  = fieldValue.ToString();
                            }
                        }
                    }
                    
                    dataGridView1.ReadOnly = !pFeatureLayer.Editable;
                    this.编辑ToolStripMenuItem.BackColor = geoLayer.Editable == true ? Color.Orange : Color.Transparent;

                    if (statusStrip1.Items.Count > 0)
                    {
                        if (dataGridView1.Rows.Count >= countLog)
                        {
                            statusStrip1.Items[0].Text = " 共有 " + dataGridView1.Rows.Count + " 条记录";
                        }
                        else
                        {
                            statusStrip1.Items[0].Text = " 共有 " + countLog + " 条记录";
                        }
                    }
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                    if (statusStrip1.Items.Count > 0)
                    {
                        statusStrip1.Items[0].Text = " 共有 " + 0 + " 条记录";
                    }
                }
            }
        }
        int countLog = 0;
        private void GetReallyFeature(GSOFeatures features)
        {
            if (features != null && features.Length > 0)
            {
                for (int i = 0; i < features.Length; i++)
                {
                    if (features[i].Type == EnumFeatureType.FeatureFolder)
                    {
                        GetReallyFeature(((GSOFeatureFolder)features[i]).Features);
                    }
                    else
                    {                       
                        countLog++;                        
                    }
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
                GSOFeature featureFlyTo = dataGridView1.Rows[e.RowIndex].Tag as GSOFeature;
                if (featureFlyTo == null || globeControl1 == null)
                {
                    return;
                }

                if (featureFlyTo.Geometry != null && featureFlyTo.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                {
                    GSOGeoPolyline3D line = featureFlyTo.Geometry as GSOGeoPolyline3D;
                    double length = line.GetSpaceLength(true, 6378137);
                    GSOGeoPolyline3D lineLine = line.GetSegment(0, length / 2);
                    GSOPoint3d point3d = lineLine[lineLine.PartCount - 1][lineLine[lineLine.PartCount - 1].Count - 1];

                    globeControl1.Globe.FlyToPosition(point3d, EnumAltitudeMode.Absolute, 0, 45, 5);
                }
                else
                {
                    globeControl1.Globe.FlyToFeature(featureFlyTo, 0, 45, 3);
                }
                globeControl1.Globe.Refresh();

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
                    GSOFeatureLayer pFeatureLayer = geoLayer as GSOFeatureLayer;
                    if (pFeatureLayer != null)
                    {
                        contextMenuStrip1.Show(dataGridView1, e.X, e.Y);

                        GSOFeature feature = dataGridView1.Rows[hittestinfo.RowIndex].Tag as GSOFeature ;
                        if (feature != null)
                        {
                            m_feature = feature;
                            m_feature.HighLight = false;
                        }
                        globeControl1.Globe.Refresh();                        
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

        private void 添加字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddFieldToLayer addField = new FrmAddFieldToLayer(geoLayer, dataGridView1);
            addField.Show(this);
        }

        private void 删除字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDeleteFieldFromLayer deleteField = new FrmDeleteFieldFromLayer(geoLayer, dataGridView1);
            deleteField.Show(this);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (geoLayer != null)
            {
                geoLayer.Save();
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (geoLayer != null)
            {
                dataGridView1.ReadOnly = !dataGridView1.ReadOnly;
                geoLayer.Editable = !geoLayer.Editable;
                this.编辑ToolStripMenuItem.BackColor = geoLayer.Editable == true ? Color.Orange : Color.Transparent;
            }
        }
        //判断用户输入数据的类型
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {           
            if (geoLayer != null && m_features.Length >= e.RowIndex)
            {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                string cellValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString().Trim();
                GSOFeature featureEdit = dataGridView1.Rows[rowIndex].Tag as GSOFeature;// geoLayer.GetAt(rowIndex);
                if (featureEdit == null)
                {
                    MessageBox.Show("修改的对象不存在！","提示");
                    return;
                }
                string fieldName = dataGridView1.Columns[columnIndex].Name.Trim();
                GSOFieldDefn field = (GSOFieldDefn)featureEdit.GetFieldDefn(fieldName);
                switch (field.Type)
                { 
                    case EnumFieldType.INT32:
                        int intValue = 0;
                        if (!Int32.TryParse(cellValue, out intValue))
                        {
                            MessageBox.Show("输入的数据格式不正确，请重新输入！", "提示");
                            dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = cellValueBeginCellEdit;
                            return;
                        }
                        featureEdit.SetFieldValue(fieldName, intValue);
                        break;
                    case EnumFieldType.Double:
                        double doubleValue = 0;
                        if (!double.TryParse(cellValue, out doubleValue))
                        {
                            MessageBox.Show("输入的数据格式不正确，请重新输入！", "提示");
                            dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = cellValueBeginCellEdit;
                            return;
                        }
                        featureEdit.SetFieldValue(fieldName, doubleValue);
                        break;
                    case EnumFieldType.Date:
                        DateTime dateTimeValue = DateTime.Now.Date;
                        if (!DateTime.TryParse(cellValue, out dateTimeValue))
                        {
                            MessageBox.Show("输入的数据格式不正确，请重新输入！", "提示");
                            dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = cellValueBeginCellEdit;
                            return;
                        }
                        featureEdit.SetFieldValue(fieldName, dateTimeValue);
                        break;      
                    case EnumFieldType.Text:
                        featureEdit.SetFieldValue(fieldName, cellValue);
                        break;
                }
               
            }
        }
        string cellValueBeginCellEdit = "";
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                cellValueBeginCellEdit = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
            }
        }

        private List<DataGridViewCell> sortAllSelectCells(DataGridView dataGridView)
        {
            List<DataGridViewCell> listSelectCells = new List<DataGridViewCell>();
            for (int i = 0; i < dataGridView.SelectedCells.Count; i++)
            {
                listSelectCells.Add(dataGridView.SelectedCells[i]);
            }
            for (int i = 0; i < listSelectCells.Count - 1; i++)
            {
                for (int j = i + 1; j < listSelectCells.Count; j++)
                {
                    if (listSelectCells[i].ColumnIndex > listSelectCells[j].ColumnIndex)
                    {
                        DataGridViewCell cell = null;
                        cell = listSelectCells[i];
                        listSelectCells[i] = listSelectCells[j];
                        listSelectCells[j] = cell;
                    }
                }
            }
            for (int i = 0; i < listSelectCells.Count - 1; i++)
            {
                for (int j = i + 1; j < listSelectCells.Count; j++)
                {
                    if (listSelectCells[i].RowIndex > listSelectCells[j].RowIndex)
                    {
                        DataGridViewCell cell = null;
                        cell = listSelectCells[i];
                        listSelectCells[i] = listSelectCells[j];
                        listSelectCells[j] = cell;
                    }
                }
            }
            return listSelectCells;
        }
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            List<DataGridViewCell> listSelectCells = sortAllSelectCells(dataGridView1);
            string strCellValue = "";
            for (int i = 0; i < listSelectCells.Count; i++)
            {
                string cellValue = listSelectCells[i].Value == null ? "" : listSelectCells[i].Value.ToString().Trim();
                strCellValue += cellValue + "\r\n";
            }            
            Clipboard.SetData(DataFormats.Text, strCellValue);            
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ReadOnly)
            {
                MessageBox.Show("表格当前为不可编辑状态！","提示");
                return;
            }
            if(Clipboard.GetData(DataFormats.Text) == null)
            {
                return;
            }
            string strCellValue =  Clipboard.GetData(DataFormats.Text).ToString();
            string[] separator = {"\r\n"};
            if(strCellValue.EndsWith(separator[0]))
            {
                strCellValue = strCellValue.Remove(strCellValue.LastIndexOf(separator[0]));
            }
            string[] arrayCells = strCellValue.Split(separator,StringSplitOptions.None);
            if (arrayCells.Length <= 0 || dataGridView1.SelectedCells.Count <= 0)
            {
                return;
            }
            int count = arrayCells.Length > dataGridView1.SelectedCells.Count ? dataGridView1.SelectedCells.Count : arrayCells.Length;

            List<DataGridViewCell> listSelectCells = sortAllSelectCells(dataGridView1);
            for (int i = 0; i < count; i++)
            {
                string cellValue = arrayCells[i].Trim();
                GSOFeature featureEdit = dataGridView1.Rows[listSelectCells[i].RowIndex].Tag as GSOFeature;// geoLayer.GetAt(listSelectCells[i].RowIndex);
                if (featureEdit == null)
                {
                    MessageBox.Show("修改的对象不存在！", "提示");
                    return;
                }                
                string fieldName = dataGridView1.Columns[listSelectCells[i].ColumnIndex].Name.Trim();
                GSOFieldDefn field = (GSOFieldDefn)featureEdit.GetFieldDefn(fieldName);
                if (field == null)
                {
                    continue;
                }
                switch (field.Type)
                {
                    case EnumFieldType.INT32:
                        int intValue = 0;
                        if (!Int32.TryParse(cellValue, out intValue))
                        {
                            MessageBox.Show("数据格式不正确！", "提示");                            
                            return;
                        }
                        featureEdit.SetFieldValue(fieldName, intValue);
                        break;
                    case EnumFieldType.Double:
                        double doubleValue = 0;
                        if (!double.TryParse(cellValue, out doubleValue))
                        {
                            MessageBox.Show("数据格式不正确！", "提示");                           
                            return;
                        }
                        featureEdit.SetFieldValue(fieldName, doubleValue);
                        break;
                    case EnumFieldType.Date:
                        DateTime dateTimeValue = DateTime.Now.Date;
                        if (!DateTime.TryParse(cellValue, out dateTimeValue))
                        {
                            MessageBox.Show("数据格式不正确！", "提示");                            
                            return;
                        }
                        featureEdit.SetFieldValue(fieldName, dateTimeValue);
                        break;
                    case EnumFieldType.Text:
                        featureEdit.SetFieldValue(fieldName, cellValue);
                        break;
                }

                dataGridView1.Rows[listSelectCells[i].RowIndex].Cells[listSelectCells[i].ColumnIndex].Value = cellValue;
            }
        }
    }
}
