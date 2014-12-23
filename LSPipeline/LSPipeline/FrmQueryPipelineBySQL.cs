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

using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;

namespace WorldGIS
{
    public partial class FrmQueryPipelineBySQL : Form
    {
        private GSOGlobeControl globeControl1;
        DatabaseConnectParams connectParams;
        GSOFeatureDataset sourcefDataset;
        public FrmQueryPipelineBySQL(GSOGlobeControl _globeControl1)
        {
            InitializeComponent();
            globeControl1 = _globeControl1;
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
        //添加字段到
        private void Frm_QuerySQL_Load(object sender, EventArgs e)
        {
            cbox_Layers.Items.Clear();
            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)//获取所有图层
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (layer.Dataset != null && layer.Dataset.DataSource != null &&
                    (layer.Dataset.DataSource.Type == EnumDataSourceType.SqlServer || layer.Dataset.DataSource.Type == EnumDataSourceType.Oracle))
                {
                    cbox_Layers.Items.Add(layer.Name);
                }                
            }
            if (cbox_Layers.Items.Count > 0)
            {
                cbox_Layers.SelectedIndex = 0;
            }
           
        }
        //获取唯一值添加到listbox_Value中
        string str1;
        string str2;
        private void btn_GetValue_Click(object sender, EventArgs e)
        {
            if (connectParams == null)
            {
                return;
            }
            try
            {
                listBox_Value.Items.Clear();

                for (int j = 0; j < sourcefDataset.FieldCount; j++)
                {
                    GSOFieldAttr fieldef = sourcefDataset.GetField(j);
                    if (listBox_Field.SelectedItem.ToString() == fieldef.Name && fieldef.Type == EnumFieldType.Text)
                    {
                        str1 = "'";
                        str2 = "'";
                    }
                }

                string sqltype = "select distinct " + listBox_Field.SelectedItem.ToString() + " from " + sourcefDataset.Name + " order by " + listBox_Field.SelectedItem.ToString() + "";

                DataTable table = OledbHelper.QueryTable(sqltype, connectParams);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow dr = table.Rows[i];
                    string colString1 = dr[0].ToString();
                    if (colString1 == null || colString1.Trim() == "")
                    {
                        continue;
                    }
                    string col = str1 + colString1 + str2;
                    listBox_Value.Items.Add(col);

                }
                str1 = "";
                str2 = "";
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

        
        private void cbox_Layers_SelectedIndexChanged(object sender, EventArgs e)
        {            
            GSOLayer m_layer = globeControl1.Globe.Layers.GetLayerByCaption(cbox_Layers.SelectedItem.ToString().Trim());//获取当前选择的layer图层
            if (m_layer == null || m_layer.Dataset == null || m_layer.Dataset.DataSource == null)
                return;
            connectParams = Utility.getConnectParamsByDatasourceName(globeControl1, m_layer.Dataset.DataSource.Name);
            if (connectParams == null)
            {
                return;
            }

            listBox_Field.Items.Clear();
            GSOFeatureLayer flayer = m_layer as GSOFeatureLayer;            
            sourcefDataset = m_layer.Dataset as GSOFeatureDataset;
            if (sourcefDataset != null)
            {
                sourcefDataset.Open();

                for (int j = 0; j < sourcefDataset.FieldCount; j++)
                {
                    GSOFieldAttr fieldef = sourcefDataset.GetField(j);
                    listBox_Field.Items.Add(fieldef.Name);
                }
                //设置当前选择字段为第一个
                if (listBox_Field.Items.Count > 0)
                {
                    listBox_Field.SelectedIndex = 0;
                }
                //将描述信息修改
                label3.Text = "SELECT * FROM " + sourcefDataset.Name + " WHERE:";
            }
        }

        //开始查询
        FrmShowFeatureAttributesByTable frm_editor = null;
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            string caption = cbox_Layers.Text;
            if (caption == "")
            {
                MessageBox.Show("请先添加图层", "提示");
                return;
            }
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(caption);
            if (layer == null || connectParams == null)
            {
                return;
            }

            string sql = "select * from " + cbox_Layers.Text.Trim();
            if (textBox_WhereClause.Text != "")
            {
                sql += " where " + textBox_WhereClause.Text;
                try
                {
                    DataTable table = OledbHelper.QueryTable(sql,connectParams);
                    if (table == null)
                    {
                        return;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        table.Columns.RemoveAt(0);
                    }
                    frm_editor = FrmShowFeatureAttributesByTable.GetForm(table, layer, globeControl1);
                    frm_editor.SetDataTable();
                    if (!frm_editor.isShowFirst)
                    {
                        frm_editor.Show(this);
                    }
                }
                catch (Exception ex)
                {
                    Log.PublishTxt(ex);
                    MessageBox.Show(ex.Message, "提示");
                    return;
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (frm_editor != null)
            {
                if (MessageBox.Show("是否关闭查询结果?", "提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
            else
            {
                this.Close();
            }
        }
       
        private void buttonOk_Click(object sender, EventArgs e)
        {
            btn_Apply_Click(sender,e);
            this.Hide();
        }
    }
}