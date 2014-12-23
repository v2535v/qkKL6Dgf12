using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data;

namespace WorldGIS
{
    public class Log
    {
        //public static  void PublishError(Exception e)
        //{
            //string stackTrace = e.StackTrace.Replace("\r\n", "||");
            //string message = e.Message.Replace("'", "\"");
            //string source = e.Source.Replace(" ", "-");
            //string sql = "use " + Utility.dbdatabase + " insert into 日志管理 values('"+DateTime.Now.ToString()+"','"+
            //    message + "','" + source + "','" + stackTrace + "','" + e.TargetSite + "')";
            //SqlConnection conn = OledbHelper.sqlConnection();
            //if (conn == null)
            //{
            //    Log.PublishTxt("", e);
            //    return;
            //}
            //SqlCommand sqlCmd = conn.CreateCommand();
            //sqlCmd.CommandText = sql;
            //int rowCount = 0;
            //try
            //{
            //    conn.Open();
            //    rowCount = sqlCmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Log.PublishTxt("", e);
            //    Log.PublishTxt("",ex);
            //}
            //finally
            //{
            //    if (conn.State == ConnectionState.Open)
            //    {
            //        conn.Close();
            //    }
            //}   
        //}
       
        public static void PublishTxt(Exception e)
        {
            //string m_LogName = ConfigurationManager.AppSettings["LogPath_Default"];
            //if (m_LogName == null)
            //{
            //    m_LogName = Path.GetDirectoryName(Application.StartupPath) + "/log.txt";
            //}
            //if (ConfigurationManager.AppSettings[LogName+"_Path"] != null)
            //{
            //    m_LogName = ConfigurationManager.AppSettings[LogName+"_Path"];
            //}

            //string m_LogSwitch = ConfigurationManager.AppSettings[LogName + "_Path"];
            //if (m_LogSwitch == null)
            //{
            //    return;
            //}
            //if (m_LogSwitch.ToLower().Trim() == "off")
            //{
            //    return;
            //}

            string m_LogName = Application.StartupPath + "/log.txt";

            //m_LogName = m_LogName.Split('.')[0] + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
            //    + DateTime.Now.Day.ToString() +"."+ m_LogName.Split('.')[1];

            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n exception begin -----------------" + DateTime.Now + "---------------------\r\n\r\n\r\n");
            sb.Append("\r\n e.Message:" + e.Message + "\r\n");
            sb.Append("\r\n e.Source:" + e.Source + "\r\n");
            sb.Append("\r\n e.TargetSite:" + e.TargetSite.ToString() + "\r\n");
            sb.Append("\r\n e.StackTrace:" + e.StackTrace + "\r\n");
            sb.Append("\r\n\r\n\r\n exception over ------------------------------------------------------------\r\n");
            if (e.Data.Count > 0)
            {
                foreach (DictionaryEntry de in e.Data)
                {
                    sb.Append("\r\n" + de.Key.ToString() + de.Value.ToString() + "\r\n");
                }
            }

            PublishStream(m_LogName, sb);   
        }
        private static void PublishStream(string LogName, StringBuilder sb)
        {            
            using (StreamWriter sw = new StreamWriter(LogName,true))
            {
                sw.Write(sb);
            }

            using (StreamReader sr = new StreamReader(LogName))
            {
                string strLog = sr.ReadToEnd();
                if (strLog.Length > 1024 * 1024)
                {
                    strLog = strLog.Substring(1024 * 512);
                }
            }
        }
    }
}
