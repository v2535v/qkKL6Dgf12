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

namespace WorldGIS
{
    public partial class FrmAddFieldToLayer : Form
    {
        GSOLayer layer = null;
        DataGridView dataGridView1 = null;
        public FrmAddFieldToLayer(GSOLayer _layer, DataGridView _dataGridView1)
        {
            InitializeComponent();
            layer = _layer;
            dataGridView1 = _dataGridView1;
        }

        private void FrmAddFieldToLayer_Load(object sender, EventArgs e)
        {

        }
        private bool isContainChinese(string str)
        {
            bool isContainChinese = false;
            if (str != null)
            {
                foreach (char c in str)
                {
                    if (c >= 0x4E00 && c <= 0x9FA5)
                    {
                        isContainChinese = true;
                        break;
                    }
                }
            }
            return isContainChinese;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            string fieldName = textBoxFieldName.Text.Trim();
            if (fieldName == "")
            {
                MessageBox.Show("字段名不能为空！","提示");
                return;
            }
            int firstChar = 0;
            if (int.TryParse(fieldName.Substring(0,1),out firstChar))
            {
                MessageBox.Show("字段名不能以数字开头！", "提示");
                return;
            }
            //if (isContainChinese(fieldName))
            //{
            //    MessageBox.Show("字段名不能包含中文！", "提示");
            //    return;
            //}
            if (fieldName.Length > 10)
            {
                MessageBox.Show("字段名长度不能大于10！", "提示");
                return;
            }
            
            EnumFieldType fieldType = EnumFieldType.None;
            int fieldWidth = 0;
            string type = comboBoxFieldType.Text.Trim();
            if (type == "")
            {
                MessageBox.Show("字段类型不能为空！", "提示");
                return;
            }
            else
            {
                switch (type)
                { 
                    case "Date":
                        fieldType = EnumFieldType.Date;
                        fieldWidth = 10;
                        break;
                    case "Double":
                        fieldType = EnumFieldType.Double;
                        fieldWidth = 8;
                        break;
                    case "INT32":
                        fieldType = EnumFieldType.INT32;
                        fieldWidth = 4;
                        break;
                    case "Text":
                        fieldType = EnumFieldType.Text;
                        fieldWidth = 8000;
                        break;
                }
            }

            if (layer != null && layer.GetAllFeatures().Length > 0)
            {
                //GSOFieldDefn field = new GSOFieldDefn();
                //field.Name = fieldName;
                //field.Type = fieldType;
                //field.Width = fieldWidth;
                //for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                //{
                //    GSOFeature feature = layer.GetAt(i);                    
                //    feature.AddField(field);
                //}
                //dataGridView1.Columns.Add(fieldName, fieldName);

                GSOFieldAttr field = new GSOFieldAttr();
                field.Name = fieldName;
                field.Type = fieldType;
                field.Width = fieldWidth;
                GSOFeatureDataset dataset = layer.Dataset as GSOFeatureDataset;
                if (dataset != null)
                {
                    dataset.AddField(field);
                    dataGridView1.Columns.Add(fieldName, fieldName);
                }
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
