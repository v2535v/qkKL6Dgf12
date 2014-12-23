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
    public partial class FrmDeleteFieldFromLayer : Form
    {
        GSOLayer layer = null;
        DataGridView dataGridView1 = null;
        public FrmDeleteFieldFromLayer(GSOLayer _layer, DataGridView _dataGridView1)
        {
            InitializeComponent();
            layer = _layer;
            dataGridView1 = _dataGridView1;
        }

        private void FrmDeleteFieldFromLayer_Load(object sender, EventArgs e)
        {
            if (layer != null)
            {
                textBoxLayerCaption.Text = layer.Caption.Trim();
                if (layer.GetAllFeatures().Length > 0)
                {
                    GSOFeature feature = layer.GetAt(0);
                    if (feature != null)
                    {
                        for (int i = 0; i < feature.GetFieldCount(); i++)
                        {
                            GSOFieldDefn field = (GSOFieldDefn)feature.GetFieldDefn(i);
                            if (field != null)
                            {
                                listViewFields.Items.Add(field.Name.Trim());
                            }
                        }
                    }
                }
            }
        }
        //全选
        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewFields.Items.Count; i++)
            {
                listViewFields.Items[i].Checked = true;
            }
        }
        //反选
        private void buttonCheckUnCheckde_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewFields.Items.Count; i++)
            {
                listViewFields.Items[i].Checked = !listViewFields.Items[i].Checked;
            }
        }
        //重置
        private void buttonReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewFields.Items.Count; i++)
            {
                listViewFields.Items[i].Checked = false;
            }
        }
        //删除
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewFields.CheckedItems.Count <= 0)
            {
                MessageBox.Show("请选择要删除的字段！", "提示");
                return;
            }
            if (layer != null)
            {
                GSOFeatureDataset dataset = layer.Dataset as GSOFeatureDataset;
                if (dataset != null)
                {
                    for (int i = 0; i < listViewFields.CheckedItems.Count; i++)
                    {
                        string fieldName = listViewFields.CheckedItems[i].Text;
                        dataset.DeleteField(fieldName.Trim());
                        dataGridView1.Columns.Remove(fieldName.Trim());
                    }
                }
            }
            this.Close();
        }
        //取消
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
