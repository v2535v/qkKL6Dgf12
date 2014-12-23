using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;

namespace WorldGIS
{
    public partial class FrmBackupDatabase : Form
    {
        GSOGlobeControl globeControl1;
        Timer backupTimer;
        SqlConnection conn = null;
        public FrmBackupDatabase(GSOGlobeControl _globeControl1)
        {
            globeControl1 = _globeControl1;
            InitializeComponent();
        }

        private void FrmBackupsDatabase_Load(object sender, EventArgs e)
        {
            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panelBackupAutomatic.Enabled = checkBoxBackupAutomatic.Checked;            
        }

        private void buttonBackupDB_Click(object sender, EventArgs e)
        {
            if (checkBoxBackupAutomatic.Checked == true)
            {
                backupTimer = new Timer();
                switch (comboBoxBackupInterval.Text)
                {
                    case "半小时":
                        backupTimer.Interval = 30 * 60 * 1000;
                        break;
                    case "一小时":
                        backupTimer.Interval = 60 * 60 * 1000;
                        break;
                    case "四小时":
                        backupTimer.Interval = 60 * 4 * 60 * 1000;
                        break;
                    case "24小时":
                        backupTimer.Interval = 60 * 24 * 60 * 1000;
                        break;
                }
                backupTimer.Interval = 1000;
                backupTimer.Tick += new EventHandler(backupTimer_Tick);
                if (MessageBox.Show("确定要启动自动备份数据库文件功能吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    backupTimer.Start();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (!backupDB())
                {
                    MessageBox.Show("备份数据库文件失败！", "提示");
                    return;
                }
                else
                {
                    MessageBox.Show("备份数据库文件成功", "提示");
                }
            }
            this.Close();
        }

        void backupTimer_Tick(object sender, EventArgs e)
        {
            if (!backupDB())
            {
                MessageBox.Show("自动备份数据库文件失败！","提示");
                if (backupTimer != null)
                {
                    backupTimer.Stop();
                }
            }
        }

        private bool backupDB()
        {
            DatabaseConnectParams connectParams = Utility.getConnectParamsByDatasourceFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
            if (connectParams == null)
            {
                return false;
            }
            conn = OledbHelper.getSqlConnection(connectParams);
            
            SqlCommand cmdBK = new SqlCommand();
            cmdBK.CommandType = CommandType.Text;
            cmdBK.Connection = conn;

            DateTime currentTime = DateTime.Now;
            string Dtime = currentTime.GetDateTimeFormats('D')[0].ToString();
            string Htime = DateTime.Now.ToString("HH时mm分ss秒").Trim();
            string fileName = Dtime + "(" + Htime + ")";

            string DBBackupPath = Application.StartupPath + "\\" + comboBoxDataSourceList.SelectedItem.ToString().Trim();
            if (Directory.Exists(DBBackupPath) == false)
            {
                Directory.CreateDirectory(DBBackupPath);
            }

            string pathName = DBBackupPath + "\\" + fileName + ".bak";
            string databaseName = connectParams.databaseName;
            cmdBK.CommandText = "backup database " + databaseName + " to disk='" + pathName + "' with init";
            
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmdBK.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message ,"提示");
                return false;
            }
            finally
            {                
                conn.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
