using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GeoScene.Globe;
using System.Collections;
using GeoScene.Data;
using GeoScene.Engine;

using System.Data.SqlClient;
using GeoScene.Data;
using GeoScene.Globe;
using GeoScene.Engine;

namespace WorldGIS
{
    public partial class FrmLogManager : Form
    {
        GSOGlobeControl globeControl1;
        DatabaseConnectParams connectParams;
        public FrmLogManager(GSOGlobeControl _globeControl1)
        {
            globeControl1 = _globeControl1;
            InitializeComponent();            
        }

        private void Frm_LogManager_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            this.datetime1.Checked = false;
            this.datetime2.Checked = false;

            comboBoxDataSourceList.Items.Clear();
            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                }
            }
            if (comboBoxDataSourceList.Items.Count > 0)
            {
                comboBoxDataSourceList.SelectedIndex = 0;
                connectParams = Utility.getConnectParamsByDatasourceFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                if (connectParams != null)
                {
                    string sql = "use " + connectParams.databaseName + " select * from 日志管理;";
                    DataTable table = OledbHelper.QueryTable(sql,connectParams);
                    if (table == null)
                    {
                        MessageBox.Show("数据库中没有日志信息！", "提示");
                        return;
                    }
                    dataGridView1.DataSource = table;
                }
            }
        }
        //查询
        private void btn_Query_Click(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem == null)
            {
                MessageBox.Show("请选择一个目标数据源！", "提示");
                return;
            }            
            if (connectParams == null)
            {
                MessageBox.Show("选择的目标数据源为空！", "提示");
                return;
            }
            string sql = "use " + connectParams.databaseName + " select * from 日志管理";
            ArrayList filters = new ArrayList();

            if (datetime1.Checked == true || datetime2.Checked == true)
            {
                if (datetime1.Checked == true && datetime2.Checked == false)
                {
                    string sql2 = " 异常日期>='" + datetime1.Value.ToString("yyyy-MM-dd") + "'";
                    filters.Add(sql2);
                }
                else if (datetime2.Checked == true && datetime1.Checked == false)
                {
                    string sql3 = " 异常日期<='" + datetime2.Value.ToString("yyyy-MM-dd") + "'";
                    filters.Add(sql3);
                }
                else
                {
                    string sql4 = " 异常日期 between '" + datetime1.Value.ToString("yyyy-MM-dd") + "' and '" + datetime2.Value.ToString("yyyy-MM-dd") + "'";
                    filters.Add(sql4);
                }
            }

            string[] aa = (string[])(filters.ToArray(typeof(string)));
            if (aa.Length > 0)
                sql += " where " + string.Join(" and ", aa);
            try
            {
                DataTable table = OledbHelper.QueryTable(sql, connectParams);
                if (table != null)
                {
                    dataGridView1.DataSource = table;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("没有找到任何数据！", "提示");
                }
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {            
            string filter = "";
            int selectedRowCount = dataGridView1.SelectedRows.Count;
            if (selectedRowCount <= 0)
            {
                MessageBox.Show("请选中要删除的行", "提示");
                return;
            }
            if (connectParams == null)
            {
                MessageBox.Show("选择的目标数据源为空！", "提示");
                return;
            }
            ArrayList list = new ArrayList();
            for (int i = selectedRowCount - 1; i >= 0; i--)
            {
                string datetime = dataGridView1.SelectedRows[i].Cells["异常日期"].Value.ToString().Trim();
                filter += "'" + datetime + "',";
                list.Add(dataGridView1.SelectedRows[i]);
            }
            filter = filter.Substring(0, filter.Length - 1);
            string sql = "use " + connectParams.databaseName + " delete from 日志管理 where 异常日期 in (" + filter + ");";
            int countDeleted = OledbHelper.sqlExecuteNonQuery(sql,connectParams);
            if (countDeleted != 0)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[i]);
                }                
            }
            MessageBox.Show("共删除" + countDeleted.ToString() +"条记录!", "提示");
        }

        private void comboBoxDataSourceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem != null)
            {
                connectParams = Utility.getConnectParamsByDatasourceFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
            }
        }
    }
}