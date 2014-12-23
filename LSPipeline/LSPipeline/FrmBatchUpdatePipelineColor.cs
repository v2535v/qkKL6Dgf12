using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GeoScene.Globe;
using DevComponents.DotNetBar.Controls;
using GeoScene.Engine;
using GeoScene.Data;
using System.Collections;

namespace WorldGIS
{
    public partial class FrmBatchUpdatePipelineColor : Form
    {
        private GSOGlobeControl globeControl1;
        string sql;
        GSOFeatureDataset sourcefDataset;
        public FrmBatchUpdatePipelineColor(GSOGlobeControl _globeControl1)//, DataGridViewX _dgv, string userName)
        {
            InitializeComponent();
            globeControl1 = _globeControl1;           
        }

        private void Frm_QuerySQL_Load(object sender, EventArgs e)
        {
            cbox_Layers.Items.Clear();
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)//获取所有图层
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                cbox_Layers.Items.Add(layer.Caption);
            }
            if (cbox_Layers.Items.Count > 0)
            {
                cbox_Layers.SelectedIndex = 0;
            }
            groupBoxField.Enabled = false;
            checkBox1.Checked = false;
        }
        
        private void cbox_Layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_Layers.SelectedItem == null)
            {
                return;
            }
            GSOLayer m_layer = globeControl1.Globe.Layers.GetLayerByCaption(cbox_Layers.SelectedItem.ToString().Trim());//获取当前选择的layer图层
            if (m_layer == null)
            {
                return;
            }
            listBox_Field.Items.Clear();
            GSOFeatureLayer flayer = m_layer as GSOFeatureLayer;
            if (flayer == null)
            {
                return;
            }
            sourcefDataset = m_layer.Dataset as GSOFeatureDataset;
            if (sourcefDataset == null)
            {
                return;
            }
            sourcefDataset.Open();
            for (int j = 0; j < sourcefDataset.FieldCount; j++)
            {
                GSOFieldAttr fieldef = sourcefDataset.GetField(j);
                listBox_Field.Items.Add(fieldef.Name);
            }
            //设置当前选择字段为第一个
            listBox_Field.SelectedIndex = 0;
            //将描述信息修改
            label3.Text = "SELECT * FROM " + m_layer.Caption + " WHERE:";
        }

        #region 符号
        private void btn_equal_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " =";
        }

        private void btn_Notequal_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " <>";
        }

        private void btn_Big_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " >";
        }

        private void btn_BigEqual_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " >=";
        }

        private void btn_Small_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " <";
        }

        private void btn_Smallequal_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " <=";
        }

        private void btn_Brace_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " ()";
        }

        private void btn_Like_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " Like";
        }

        private void btn_And_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " AND";
        }

        private void btn_Or_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " OR";
        }

        private void btn_IS_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " IS";
        }

        private void btn_Not_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " NOT";
        }

        private void btn_What_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " ?";
        }

        private void btn_All_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " *";
        }
        #endregion

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            textBox_WhereClause.Clear();//清空条件
        }

        //获取唯一值添加到listbox_Value中        
        private void btn_GetValue_Click(object sender, EventArgs e)
        {
            if (listBox_Field.SelectedItem == null)
            {
                MessageBox.Show("请先选中一个字段！", "提示");
                return;
            }
            listBox_Value.Items.Clear();
            string strSepratorOfString = "";
            GSOFieldAttr fieldef = sourcefDataset.GetField(listBox_Field.SelectedItem.ToString().Trim());
            if (fieldef == null)
            {
                return;
            }
            if (fieldef.Type == EnumFieldType.Text)
            {
                strSepratorOfString = "'";
            }

            try
            {
                for (int i = 0; i < sourcefDataset.GetAllFeatures().Length; i++)
                {
                    GSOFeature feature = sourcefDataset.GetFeatureAt(i);
                    if (feature != null)
                    {
                        object fieldValue = feature.GetValue(listBox_Field.SelectedItem.ToString().Trim());
                        if (fieldValue != null && listBox_Value.Items.Contains(strSepratorOfString + fieldValue.ToString() + strSepratorOfString) == false)
                        {
                            listBox_Value.Items.Add(strSepratorOfString + fieldValue.ToString() + strSepratorOfString);
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
        //双击添加到查询列中
        private void listBox_Field_DoubleClick(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " " + listBox_Field.Text;
        }

        private void listBox_Value_DoubleClick(object sender, EventArgs e)
        {
            textBox_WhereClause.Text += " " + listBox_Value.Text;
        }

        //开始查询
        private void btn_Apply_Click(object sender, EventArgs e)
        {          
            string caption = cbox_Layers.Text;
            if (caption == "")
            {
                MessageBox.Show("请先添加图层","提示");
                return;
            }
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(caption);
            if (layer == null)
            {
                return;
            }
           
            if (!checkBox1.Checked)
            {
                GSOFeatures features = layer.GetAllFeatures();
                for (int i = 0; i < features.Length; i++)
                {
                    GSOFeature newfeature = features[i];

                    GSOGeoPolyline3D line = newfeature.Geometry as GSOGeoPolyline3D;
                    if (line == null)
                    {
                        continue;
                    }
                    GSOPipeLineStyle3D pipeLineStyle = line.Style as GSOPipeLineStyle3D;
                

                    // 管线暂不支持依地模式

                    if (pipeLineStyle == null)
                    {
                        pipeLineStyle = new GSOPipeLineStyle3D();
                    }

                    pipeLineStyle.LineColor = buttonPipelineColor.BackColor;
                    line.Style = pipeLineStyle;
                }
            }
            else
            {
                string sql = "select * from " + cbox_Layers.Text.Trim();
                if (textBox_WhereClause.Text != "")
                {
                    sql += " where " + textBox_WhereClause.Text;
                    try
                    {
                        if (layer.Dataset == null || layer.Dataset.DataSource == null 
                            || (layer.Dataset.DataSource.Type != EnumDataSourceType.SqlServer && layer.Dataset.DataSource.Type != EnumDataSourceType.Oracle))
                        {
                            return ;
                        }
                        DatabaseConnectParams connectParams = Utility.getConnectParamsByDatasourceName(globeControl1, layer.Dataset.DataSource.Name);
                        if (connectParams == null)
                        {
                            return ;
                        }
                        DataTable table = OledbHelper.QueryTable(sql, connectParams);
                        if (table == null)
                        {
                            return ;
                        }

                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            int id = Convert.ToInt32(table.Rows[i]["LSSYS_ID"]);
                            GSOFeature newfeature = layer.GetFeatureByID(id);

                            GSOGeoPolyline3D line = newfeature.Geometry as GSOGeoPolyline3D;
                            if (line == null)
                            {
                                continue;
                            }
                            GSOPipeLineStyle3D pipeLineStyle = line.Style as GSOPipeLineStyle3D;

                            // 管线暂不支持依地模式
                            if (pipeLineStyle == null)
                            {
                                pipeLineStyle = new GSOPipeLineStyle3D();
                            }
                            pipeLineStyle.LineColor = buttonPipelineColor.BackColor;
                            line.Style = pipeLineStyle;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.PublishTxt(ex);
                        MessageBox.Show(ex.Message, "提示");
                        return ;
                    }
                }
            }

            globeControl1.Refresh();
            return ;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //如果被选中，就是部分管线改变颜色
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxField.Enabled = checkBox1.Checked;           
        }

        private void buttonPipelineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = buttonPipelineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                buttonPipelineColor.BackColor = dlg.Color;
            }
        }
    }
}