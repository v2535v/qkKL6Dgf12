using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Globe;
using GeoScene.Engine;
using GeoScene.Data;

namespace WorldGIS.Forms
{
    public partial class FrmNewDBFeatureDataset : Form
    {
        private GeoScene.Globe.GSOGlobeControl globeControl1;
        public FrmNewDBFeatureDataset(GSOGlobeControl _globeControl1)
        {
            globeControl1 = _globeControl1;
            InitializeComponent();
        }

        private void FrmNewDBFeatureDataset_Load(object sender, EventArgs e)
        {
            comboBoxDataSourceList.Items.Clear();
            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                }
            }
            comboBoxShpLayerList.Items.Clear();
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (layer != null && System.IO.Path.GetExtension(layer.Name) == ".shp")
                {
                    comboBoxShpLayerList.Items.Add(layer.Caption);
                }
            }

            radioButtonUseTemplate.Checked = true;
            panelUseCustom.Enabled = false;
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem == null)
            {
                MessageBox.Show("请选择一个数据源！", "提示");
                return;
            }
            GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
            if (ds == null)
            {
                MessageBox.Show("数据源不能为空！", "提示");
                return;
            }
            string newLayerName = textboxNewLayerName.Text.Trim();
            if (newLayerName == "")
            {
                MessageBox.Show("新建图层的名称不能为空！","提示");
                return;
            }
            GSOFeatureDataset newFeatureDataset = ds.CreateFeatureDataset(newLayerName);
            if (newFeatureDataset == null)
            {
                MessageBox.Show("新建图层的名称不符合要求！", "提示");
                return;
            }
            if (radioButtonUseTemplate.Checked == true)
            {
                string shpLayerName = comboBoxShpLayerList.Text;
                GSOLayer shpLayer = globeControl1.Globe.Layers.GetLayerByCaption(shpLayerName);
                if (shpLayer == null)
                {
                    MessageBox.Show("您选择的图层模板不存在！", "提示");
                    return;
                }
                if (shpLayer.Dataset != null && shpLayer.Dataset is GSOFeatureDataset)
                {
                    GSOFeatureDataset shpFeatureDataset = shpLayer.Dataset as GSOFeatureDataset;
                    for (int i = 0; i < shpFeatureDataset.FieldCount; i++)
                    {
                        GSOFieldAttr fielddef = shpFeatureDataset.GetField(i);

                        GSOFieldAttr field = new GSOFieldAttr();
                        field.Name = fielddef.Name;
                        field.Type = fielddef.Type;
                        field.Width = fielddef.Width;
                        field.Precision = fielddef.Precision;
                        bool res = newFeatureDataset.AddField(field);
                    }

                    newFeatureDataset.Save();
                    MessageBox.Show("图层创建成功！", "提示");
                }
                else
                {
                    MessageBox.Show("您选择的图层模板不是矢量图层！", "提示");
                    return;
                }
            }
            else if (radioButtonUseCustom.Checked == true)
            {
                int rowCount = dataGridView1.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    string fieldName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string fieldType = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string fieldWidth = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string fieldPrecision = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    EnumFieldType enumFieldType = EnumFieldType.Text;
                    int intFieldWidth = 2000;
                    int intFieldPrecision = 0;
                    if (fieldType == "Double")
                    {
                        enumFieldType = EnumFieldType.Double;
                        intFieldWidth = 8;
                        if (int.TryParse(fieldPrecision, out intFieldPrecision) == false)
                        {
                            intFieldPrecision = 2;
                        }
                    }
                    else if (fieldType == "Int32")
                    {
                        enumFieldType = EnumFieldType.INT32;
                        intFieldWidth = 4;
                    }
                    else if (fieldType == "Date")
                    {
                        enumFieldType = EnumFieldType.Date;
                        intFieldWidth = 7;
                    }
                    else
                    {
                        int.TryParse(fieldWidth, out intFieldWidth);
                    }
                    
                    
                    GSOFieldAttr field = new GSOFieldAttr();
                    field.Name = fieldName;
                    field.Type = enumFieldType;
                    field.Width = intFieldWidth;
                    if (field.Type == EnumFieldType.Double)
                    {
                        field.Precision = intFieldPrecision;
                    }                    
                    bool res = newFeatureDataset.AddField(field);
                }
                newFeatureDataset.Save();
                MessageBox.Show("图层创建成功！", "提示");
            }
        }        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButtonUseTemplate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUseTemplate.Checked == true)
            {
                radioButtonUseCustom.Checked = false;
                panelUserTemplate.Enabled = true;
            }
            else
            {
                radioButtonUseCustom.Checked = true;
                panelUserTemplate.Enabled = false;
            }
        }

        private void radioButtonUseCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUseCustom.Checked == true)
            {
                radioButtonUseTemplate.Checked = false;
                panelUseCustom.Enabled = true;
            }
            else
            {
                radioButtonUseTemplate.Checked = true;
                panelUseCustom.Enabled = false;
            }
        }

        private void buttonAddField_Click(object sender, EventArgs e)
        {
            string fieldName = textBoxFieldName.Text.Trim();
            if (fieldName == "")
            {
                MessageBox.Show("字段名称不能为空！", "提示");
                return;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == null)
                {
                    MessageBox.Show("字段名称不能为空！", "提示");
                    return; 
                }
                if (dataGridView1.Rows[i].Cells[0].Value.Equals(fieldName) == true)
                {
                    MessageBox.Show("字段名称已存在！", "提示");
                    return;
                }
            }

            if (comboBoxFieldType.SelectedItem == null)
            {
                MessageBox.Show("请选择一个字段类型！", "提示");
                return;
            }
            string fieldType = comboBoxFieldType.SelectedItem.ToString().Trim();

            string fieldWidth = textBoxFieldWidth.Text.Trim();
            int intFieldWidth = 0;

            string fieldPrecision = textBoxFieldPrecision.Text.Trim();
            int intFieldPrecision = 0;            

            if (fieldType == "Double")
            {
                intFieldWidth = 8;
                if (int.TryParse(fieldPrecision, out intFieldPrecision) == false)
                {
                    MessageBox.Show("请输入一个正确的字段精度！", "提示");
                    return;
                }
            }
            else if (fieldType == "Int32")
            {
                intFieldWidth = 4;
                intFieldPrecision = 0;
            }
            else if (fieldType == "Date")
            {
                intFieldWidth = 7;
                intFieldPrecision = 0;
            }
            else
            {
                if (int.TryParse(fieldWidth, out intFieldWidth) == false)
                {
                    MessageBox.Show("请输入一个正确的字段长度！", "提示");
                    return;
                }
                intFieldPrecision = 0;
            }
            
            int rowIndex = dataGridView1.Rows.Add();
            dataGridView1.Rows[rowIndex].Cells[0].Value = fieldName;
            dataGridView1.Rows[rowIndex].Cells[1].Value = fieldType;
            dataGridView1.Rows[rowIndex].Cells[2].Value = intFieldWidth;
            dataGridView1.Rows[rowIndex].Cells[3].Value = intFieldPrecision;
        }

        private void buttonDeleteField_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请在表格中选中要删除的字段！","提示");
                return;
            }
            if (MessageBox.Show("确定要删除选中的字段吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[i]);
                }
            }
        }
    }
}
