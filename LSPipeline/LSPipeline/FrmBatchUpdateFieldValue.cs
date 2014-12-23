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
using System.Reflection;
using WorldGIS.Forms;
using System.Net.NetworkInformation;

namespace WorldGIS
{
    public partial class FrmBatchUpdateFieldValue : Form
    {
        private GSOGlobeControl globeControl1;
        public GSOLayer layer;
        GSOFeatures features = new GSOFeatures();
        public bool isSelectObject = false;

        public FrmBatchUpdateFieldValue(GSOGlobeControl _globeControl1)
        {
            InitializeComponent();
            globeControl1 = _globeControl1;
            globeControl1.TrackPolygonEndEvent +=new TrackPolygonEndEventHandler(mGlobeControl_TrackPolygonAnalysisEndEvent);
        }

        private void FrmBatchUpdateFieldValue_Load(object sender, EventArgs e)
        {
            GSOLayers layers = globeControl1.Globe.Layers;
            for (int i = 0; i < layers.Count; i++)
            {
                GSOLayer lay = layers[i];
                if (lay.Dataset.IsFeatureDataset)
                {
                    GSOFeatureDataset data = (GSOFeatureDataset)lay.Dataset;
                    if (data.FieldCount <= 0)
                    {
                        continue;
                    }
                    comboBoxLayers.Items.Add(lay.Caption); //绑定图层
                }
            }
            if (comboBoxLayers.Items.Count > 0)
            {
                comboBoxLayers.SelectedIndex = 0;
            }
            panel1.Enabled = false;
        }

        private void comboBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string layerCaption = comboBoxLayers.Text;
            layer = globeControl1.Globe.Layers.GetLayerByCaption(layerCaption);
            if (layer.Dataset.IsFeatureDataset)
            {
                GSOFeatureDataset data = (GSOFeatureDataset)layer.Dataset;
                if (data.FieldCount <= 0)
                {
                    return;
                }
                for (int i = 0; i < data.FieldCount; i++)
                {
                    comboBoxUpdateFieldName.Items.Add(data.GetField(i).Name); //绑定图层中的字段
                    comboBoxConditionFieldName.Items.Add(data.GetField(i).Name);
                }
            }
        }
        //框选查询
        private void radioButtonPolygonSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (layer == null)
            {
                MessageBox.Show("请选择一个图层！", "提示");
                radioButtonPolygonSelect.Checked = false;
                return;
            }
            if (radioButtonPolygonSelect.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
                isSelectObject = true;
                panel1.Enabled = false;
            }
        }
        //条件查询
        private void radioButtonConditionSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (layer == null)
            {
                MessageBox.Show("请选择一个图层！", "提示");
                radioButtonConditionSelect.Checked = false;
                return;
            }
            if (radioButtonConditionSelect.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                isSelectObject = false;
                panel1.Enabled = true;
            }            
        }
        //绘制面
        void mGlobeControl_TrackPolygonAnalysisEndEvent(object sender, TrackPolygonEndEventArgs e)
        {
            if (e.Polygon != null)
            { 
                if (layer != null && isSelectObject)
                {
                    GSOFeatures feats = layer.FindFeaturesInPolygon(e.Polygon, false);
                    if (feats != null && feats.Length > 0)
                    {
                        SetDataTable(feats);
                    }
                    else
                    {
                        MessageBox.Show("框选查询结果为空！","提示");
                    }
                    globeControl1.Globe.ClearLastTrackPolygon();
                    globeControl1.Globe.Refresh();
                    return;
                }
            }
        }
        //datagrid绑定数据
        public void SetDataTable(GSOFeatures feats)
        {
            if (feats.Length == 0)
            {
                MessageBox.Show("查询结果为空！","提示");
                return;
            }
            GSOFeature feat = feats[0];
            try
            {
                DataTable table = new DataTable();
                for (int i = 0; i < feat.GetFieldCount(); i++)
                {
                    GSOFieldDefn field = (GSOFieldDefn)feat.GetFieldDefn(i);
                    table.Columns.Add(field.Name);
                }
                for (int i = 0; i < feats.Length; i++)
                {
                    GSOFeature f = feats[i];
                    DataRow row = table.NewRow();
                    for (int j = 0; j < feat.GetFieldCount(); j++)
                    {
                        GSOFieldDefn field = (GSOFieldDefn)feat.GetFieldDefn(j);
                        row[j] = f.GetValue(field.Name);
                    }
                    table.Rows.Add(row);
                }
                dataGridView1.DataSource = table;
                for (int i = 0; i < feats.Length; i++)
                {
                    GSOFeature f = feats[i];
                    if (dataGridView1.Rows.Count > i)
                    {
                        dataGridView1.Rows[i].Tag = f;
                    }
                }
            }
            catch (System.Exception exp)
            {
                Log.PublishTxt(exp);
                MessageBox.Show(exp.Message,"提示");
            } 
        }
        
        //取消
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool updateFeatures()
        {
            if (layer == null)
            {
                MessageBox.Show("请选择一个图层！");
                return false;
            }
            if (comboBoxUpdateFieldName.Text == "")
            {
                MessageBox.Show("请选择一个字段！");
                return false;
            }
            string fieldValue = textBoxFieldValue.Text;

            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("查询结果为空！");
                return false;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                GSOFeature feat = dataGridView1.Rows[i].Tag as GSOFeature;
                if (feat != null)
                {
                    feat.SetFieldValue(comboBoxUpdateFieldName.Text, fieldValue);
                }
            }
            return true;
        }
        //修改
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (updateFeatures())
            {                
                SetDataTable(features);
                globeControl1.Globe.Refresh();
                MessageBox.Show("修改成功！","提示");
            }
        }        
        //保存
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (updateFeatures())
            {
                if (MessageBox.Show("确定要保存吗？", "提示",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (layer != null)
                    {
                        layer.Save();
                        this.Close();
                    }                    
                    globeControl1.Globe.Refresh();
                }
            }
        }
        
        //查询
        private void buttonConditionSelect_Click(object sender, EventArgs e)
        {
            if (layer == null)
            {
                MessageBox.Show("请选择一个图层！");
                return;
            }
            if (comboBoxConditionFieldName.Text == "" || comboBoxConditionFieldValue.Text == "" || comboBoxCondition.Text == "")
            {
                MessageBox.Show("请输入完整的查询条件！","提示");
                return;
            }
            GSOFeatureDataset featureDataset = layer.Dataset as GSOFeatureDataset;
            EnumFieldType currentFieldType = EnumFieldType.Text;
            if (featureDataset != null)
            {
                GSOFieldAttr field = featureDataset.GetField(comboBoxConditionFieldName.Text);
                if (field != null)
                {
                    switch (field.Type)
                    {
                        case EnumFieldType.Double:
                        case EnumFieldType.INT32:
                            currentFieldType = EnumFieldType.Double;
                            break;
                        case EnumFieldType.Date:
                            currentFieldType = EnumFieldType.Date;
                            break;
                    }
                }
            }
           
            try
            {
                switch (comboBoxCondition.Text)
                {
                    case "=":
                        for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                        {
                            GSOFeature feature = layer.GetAt(i);
                            if(feature != null && feature.GetValue(comboBoxConditionFieldName.Text).ToString() == comboBoxConditionFieldValue.Text)
                            {
                                features.Add(feature);
                            }
                        }
                        break;
                    case ">=":
                        for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                        {
                            GSOFeature feature = layer.GetAt(i);
                            if (currentFieldType == EnumFieldType.Double)
                            {
                                if (feature != null && Double.Parse(feature.GetFieldAsDataTime(comboBoxConditionFieldName.Text).ToString()) >= Double.Parse(comboBoxConditionFieldValue.Text))
                                {
                                    features.Add(feature);
                                }
                            }
                            else if (currentFieldType == EnumFieldType.Date)
                            {
                                if (feature != null && DateTime.Parse(feature.GetFieldAsDataTime(comboBoxConditionFieldName.Text).ToString()) >= DateTime.Parse(comboBoxConditionFieldValue.Text))
                                {
                                    features.Add(feature);
                                }
                            }
                        }
                        break;
                    case "<=":
                        for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                        {
                            GSOFeature feature = layer.GetAt(i);
                            if (currentFieldType == EnumFieldType.Double)
                            {
                                if (feature != null && Double.Parse(feature.GetFieldAsDataTime(comboBoxConditionFieldName.Text).ToString()) <= Double.Parse(comboBoxConditionFieldValue.Text))
                                {
                                    features.Add(feature);
                                }
                            }
                            else if (currentFieldType == EnumFieldType.Date)
                            {
                                if (feature != null && DateTime.Parse(feature.GetFieldAsDataTime(comboBoxConditionFieldName.Text).ToString()) <= DateTime.Parse(comboBoxConditionFieldValue.Text))
                                {
                                    features.Add(feature);
                                }
                            }
                        }
                        break;
                    case ">":
                        for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                        {
                            GSOFeature feature = layer.GetAt(i);
                            if (currentFieldType == EnumFieldType.Double)
                            {
                                if (feature != null && Double.Parse(feature.GetFieldAsDataTime(comboBoxConditionFieldName.Text).ToString()) > Double.Parse(comboBoxConditionFieldValue.Text))
                                {
                                    features.Add(feature);
                                }
                            }
                            else if (currentFieldType == EnumFieldType.Date)
                            {
                                if (feature != null && DateTime.Parse(feature.GetFieldAsDataTime(comboBoxConditionFieldName.Text).ToString()) > DateTime.Parse(comboBoxConditionFieldValue.Text))
                                {
                                    features.Add(feature);
                                }
                            }
                        }
                        break;
                    case "<":
                        for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                        {
                            GSOFeature feature = layer.GetAt(i);
                            if (currentFieldType == EnumFieldType.Double)
                            {
                                if (feature != null && Double.Parse(feature.GetFieldAsDataTime(comboBoxConditionFieldName.Text).ToString()) < Double.Parse(comboBoxConditionFieldValue.Text))
                                {
                                    features.Add(feature);
                                }
                            }
                            else if (currentFieldType == EnumFieldType.Date)
                            {
                                if (feature != null && DateTime.Parse(feature.GetFieldAsDataTime(comboBoxConditionFieldName.Text).ToString()) < DateTime.Parse(comboBoxConditionFieldValue.Text))
                                {
                                    features.Add(feature);
                                }
                            }
                        }
                        break;                    
                }
                if (features == null)
                {
                    MessageBox.Show("请重新输入查询条件！","提示");
                    return;
                }
                if (features.Length == 0)
                {
                    MessageBox.Show("没有找到符合查询条件的对象！","提示");
                    return;
                }
                SetDataTable(features);               
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message, "提示");
                return;
            }
        }
           
        //获取字段值
        private void comboBoxConditionFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layer == null)
            {
                MessageBox.Show("请先选择一个图层！");
                return;
            }
            comboBoxConditionFieldValue.Items.Clear();            
            try
            {
                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature f = layer.GetAt(i);
                    if (f != null)
                    {
                        object fieldValue = f.GetValue(comboBoxConditionFieldName.Text);
                        if (f != null && fieldValue != null && comboBoxConditionFieldValue.Items.Contains(fieldValue) == false)
                        {
                            comboBoxConditionFieldValue.Items.Add(fieldValue);
                        }
                    }                    
                }
                GSOFeatureDataset featureDataset = layer.Dataset as GSOFeatureDataset;
                if (featureDataset != null)
                {
                    GSOFieldAttr field = featureDataset.GetField(comboBoxConditionFieldName.Text);
                    if (field != null)
                    {
                        switch (field.Type)
                        { 
                            case EnumFieldType.Text:
                                comboBoxCondition.Items.Clear();
                                comboBoxCondition.Items.Add("=");
                                break;
                            case EnumFieldType.Double:
                            case EnumFieldType.INT32:
                            case EnumFieldType.Date:
                                comboBoxCondition.Items.Clear();
                                comboBoxCondition.Items.Add("=");
                                comboBoxCondition.Items.Add(">=");
                                comboBoxCondition.Items.Add("<=");
                                comboBoxCondition.Items.Add(">");
                                comboBoxCondition.Items.Add("<");
                                break;                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBatchUpdateFieldValue_FormClosing(object sender, FormClosingEventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.ActionNull;
            isSelectObject = false;
            layer = null;
            features = null;
        }
    }
}
