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
    public partial class FrmEditLayerAttributes : Form
    {
        public GSOGlobeControl m_globeControl;
        private GSOLayer geoLayer;


        public FrmEditLayerAttributes(GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            geoLayer = layer;
            m_globeControl = globeControl;
        }

        private void Frm_EditorAttributes_Load(object sender, EventArgs e)
        {
            GSOFeatureLayer gsoFeatureLayer = geoLayer as GSOFeatureLayer;
            if (gsoFeatureLayer == null)
            {
                MessageBox.Show("该数据不是属性数据，属性值为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GSOFeatureDataset flayer = gsoFeatureLayer.Dataset as GSOFeatureDataset;
            for (int i = 0; i < flayer .FieldCount; i++)
            {
                GSOFieldAttr field = flayer.GetField(i);
                listBoxAttribute.Items.Add(field.Name);
                //labelAttributeType.Text = "图层属性类型为：" + field.Type.ToString() + "类型";
            }

        }

        private void buttonDelAttribute_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该属性字段？", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    GSOFeatureLayer pFeatureLayer = geoLayer as GSOFeatureLayer;
                    if (pFeatureLayer == null)
                        return;
                    GSOFeatureDataset dataset = pFeatureLayer.Dataset as GSOFeatureDataset;

                    dataset.DeleteField(listBoxAttribute.SelectedItem.ToString());

                    if (listBoxAttribute.SelectedItem !=null )
                    {
                        listBoxAttribute.Items.Remove(listBoxAttribute.SelectedItem);
                        dataset.SaveAs(@"F:\新建文件夹");
                        MessageBox.Show("删除字段成功！", "提示！");
                    }
                    if (m_globeControl != null)
                    {
                        m_globeControl.Refresh();
                    }

                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }

            }
        }

        private void buttonAddAttribute_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要添加该属性字段？", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    GSOFeatureLayer pFeatureLayer = geoLayer as GSOFeatureLayer;
                    if (pFeatureLayer == null)
                        return;
                    GSOFeatures feats = pFeatureLayer.GetAllFeatures();
                    GSOFeatureDataset dateset = pFeatureLayer.Dataset as GSOFeatureDataset;
                    GSOFieldAttr fieldattr=new GSOFieldAttr ();

                    fieldattr.Name = textBoxAddAttributeName.Text;
                    switch (comboBoxAddAttributeType.SelectedIndex)
                    {
                        case 0:
                            fieldattr.Type = EnumFieldType.Text;
                            fieldattr.Width = 2000;
                            break;
                        case 1:
                            fieldattr.Type = EnumFieldType.Double;
                            break;
                        case 2:
                            //fieldattr.Type = EnumFieldType.INT16;
                            //fieldattr.Type = EnumFieldType.INT32;
                            fieldattr.Type = EnumFieldType.INT64;
                            break;
                        case 3:
                            fieldattr.Type = EnumFieldType.Date;
                            break;
                    }

                    dateset.AddField(fieldattr);
                    dateset.Save();
                    listBoxAttribute.Items.Add(fieldattr.Name);

                    MessageBox.Show("添加属性字段成功！", "提示！");

                    if (m_globeControl != null)
                    {
                        m_globeControl.Refresh();
                    }
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void listBoxAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAttribute.SelectedItem != null)
            {
                GSOFeatureLayer gsoFeatureLayer = geoLayer as GSOFeatureLayer;
                if (gsoFeatureLayer == null)
                {
                    MessageBox.Show("该数据不是属性数据，属性值为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GSOFeatureDataset flayer = gsoFeatureLayer.Dataset as GSOFeatureDataset;

                GSOFieldAttr field = flayer.GetField(listBoxAttribute.SelectedItem.ToString());


                labelAttributeType.Text = "图层属性类型为：" + field.Type.ToString() + " 类型";
            }
        }
    }
}
