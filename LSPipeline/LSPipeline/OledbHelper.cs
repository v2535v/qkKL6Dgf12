using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace WorldGIS
{
    class OledbHelper
    {
        public static DataTable QueryTable(string cmdText,DatabaseConnectParams connectParams)
        {
            SqlConnection conn = OledbHelper.getSqlConnection(connectParams);
            if (conn == null)
            {
                return null;
            }
            try
            {
                conn.Open();
                SqlCommand sqlCmd = conn.CreateCommand();
                sqlCmd.CommandText = cmdText;
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(sqlReader);

                sqlReader.Close();
                conn.Close();

                return table;
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message, "提示");
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public static int ExecuteNonQuery(string cmdText, DatabaseConnectParams connectParams)
        {
            OleDbConnection oleConn = new OleDbConnection("Data Source=" + connectParams.ip + ";Initial Catalog=" + connectParams.databaseName 
                + ";Persist Security Info=True;User ID=" + connectParams.userName + ";pwd=" + connectParams.password + "");
            OleDbCommand oleCmd = new OleDbCommand();
            oleCmd.Connection = oleConn;
            oleCmd.CommandText = cmdText;
            int rowCount = 0;
            try
            {
                oleConn.Open();
                rowCount = oleCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message, "提示");
            }
            finally
            {
                if (oleConn.State == ConnectionState.Open)
                {
                    oleConn.Close();
                }
            }
            return rowCount;
        }
        
        public static SqlConnection getSqlConnection(string dbServer, string databaseName, string userName, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=" + dbServer + ";Database=" + databaseName + ";User ID=" + userName + ";pwd=" + password + ";Trusted_Connection=false");
                return conn;
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message, "提示");
                return null;
            }
        }
        public static SqlConnection getSqlConnection(DatabaseConnectParams connectParams)
        {
            if (connectParams == null)
            {
                return null;
            }
            try
            {
                SqlConnection conn = new SqlConnection("Server=" + connectParams.ip + ";Database=" + connectParams.databaseName 
                    + ";User ID=" + connectParams.userName + ";pwd=" + connectParams.password + ";Trusted_Connection=false");
                return conn;
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message, "提示");
                return null;
            }
        }

        public static int sqlExecuteNonQuery(string sql, DatabaseConnectParams connectParams)
        {
            SqlConnection conn = OledbHelper.getSqlConnection(connectParams);
            if (conn == null)
            {
                return 0;
            }
            SqlCommand sqlCmd = conn.CreateCommand();
            sqlCmd.CommandText = sql;
            int rowCount = 0;
            try
            {
                conn.Open();
                rowCount = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message, "提示");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rowCount;
        }
        public static int ExecuteScalar(string sql, DatabaseConnectParams connectParams)
        {
            SqlConnection conn = OledbHelper.getSqlConnection(connectParams);
            if (conn == null)
            {
                return 0;
            }
            SqlCommand sqlCmd = conn.CreateCommand();
            sqlCmd.CommandText = sql;
            int num = 0;
            try
            {
                conn.Open();
                num = Convert.ToInt32(sqlCmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                num = -1;
                MessageBox.Show(ex.Message, "提示");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return num;
        }
    }
}
