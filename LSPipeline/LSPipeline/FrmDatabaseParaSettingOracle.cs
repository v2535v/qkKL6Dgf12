using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace WorldGIS
{
    
    public partial class FrmDatabaseParaSettingOracle : Form
    {
        private GSOGlobeControl globeControl1;
        public FrmDatabaseParaSettingOracle(GSOGlobeControl _globeControl)
        {
            globeControl1 = _globeControl;
            InitializeComponent();
        }

        private void FrmDatabaseParaSetting_Load(object sender, EventArgs e)
        {
            ReadXML();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (textBoxIP.Text == "" || textBoxDatabase.Text == "" || textBoxUser.Text == "" || textBoxPassword.Text == "")
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("连接参数不能为空！", "提示");
                return;
            }
            if (!Utility.isNetworkConnectionSuccess(textBoxIP.Text.Trim()))
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("网络连接失败！", "提示");
                return;
            }

            string serverIp = textBoxIP.Text.Trim();
            string hostName = System.Net.Dns.GetHostName();
            if (serverIp == hostName || serverIp == "localhost"
               || serverIp == System.Net.Dns.GetHostAddresses(hostName).GetValue(2).ToString())
            {
                serverIp = "127.0.0.1";
            }
            DateTime timeStart = DateTime.Now;
            GSODataSource ds = globeControl1.Globe.DataManager.GetDataSourceByName(serverIp + "/" + textBoxDatabase.Text.Trim() + "_" + textBoxUser.Text.Trim());
            if (ds == null)
            {
                ds = globeControl1.Globe.DataManager.OpenOracleDataSource(serverIp + "/" + textBoxDatabase.Text, "", "", textBoxUser.Text, textBoxPassword.Text);
            }
            if (ds == null)
            {
                ds = globeControl1.Globe.DataManager.CreateOracleDataSource(serverIp + "/" + textBoxDatabase.Text, "", "", textBoxUser.Text, textBoxPassword.Text);
            }
            TimeSpan timeConnectOracle = DateTime.Now - timeStart;
            double secondsConnectOracle = timeConnectOracle.TotalSeconds;            
           
            if (ds == null)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("连接Oracle数据库失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ds.IsCloseSaved = false;
                DatabaseConnectParams connectParams = new DatabaseConnectParams();
                connectParams.ip = textBoxIP.Text.Trim();
                connectParams.databaseName = textBoxDatabase.Text.Trim();
                connectParams.userName = textBoxUser.Text.Trim();
                connectParams.password = textBoxPassword.Text.Trim();
                connectParams.dataSourceName = ds.Name;
                connectParams.databaseType = EnumDataSourceType.Oracle;
                Utility.connectParamsOfDatabase.Add(connectParams);

                WriteXML();
                MessageBox.Show("连接Oracle数据库成功，用时：" + secondsConnectOracle.ToString() + "秒", "提示");
            }
            this.DialogResult = DialogResult.OK;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void ReadXML()
        {
            string strFileName = Path.GetDirectoryName(Application.ExecutablePath) + "/databaseConfigOracle.xml";
            if (!File.Exists(strFileName))
            {
                return;
            }

            //初始化XML文档操作类
            XmlDocument myDoc = new XmlDocument();
            {
                //加载XML文件
                try
                {
                    myDoc.Load(strFileName);
                }
                catch (System.Exception e)
                {
                    Log.PublishTxt(e);
                    return;
                }
                //搜索指定的节点
                XmlNode serverRootNode = myDoc.SelectSingleNode("LocaSpace");
                XmlNodeList nodes = null;
                if (serverRootNode != null)
                {
                    nodes = myDoc.SelectSingleNode("LocaSpace").ChildNodes;
                }
                if (nodes != null)
                {
                    XmlNode bRecordNode = serverRootNode.SelectSingleNode("IsRecordedSql");
                    bool bRecorded = false;
                    if (bRecordNode != null)
                    {
                        bool.TryParse(bRecordNode.InnerText, out bRecorded);
                        cbbRecordDatabaseConfig.Checked = bRecorded;
                    }
                    if (bRecorded)
                    {
                        foreach (System.Xml.XmlNode xn in nodes)
                        {
                            if (xn.Name == "sqlIP")
                            {
                                textBoxIP.Text = xn.InnerText;
                            }
                            else if (xn.Name == "database")
                            {
                                textBoxDatabase.Text = xn.InnerText;
                            }
                            else if (xn.Name == "userName")
                            {
                                textBoxUser.Text = xn.InnerText;
                            }
                            else if (xn.Name == "password")
                            {
                                textBoxPassword.Text = xn.InnerText;
                            }
                        }
                    }
                }                
            }
        }

        private void WriteXML()
        {
            string strFileName = Path.GetDirectoryName(Application.ExecutablePath) + "/databaseConfigOracle.xml";
            File.WriteAllText(strFileName, "<?xml version='1.0' encoding='utf-8' ?><LocaSpace></LocaSpace> ");
            XmlDocument myDoc = new XmlDocument();

            //加载XML文件
            try
            {
                myDoc.Load(strFileName);

            }
            catch (System.Exception e)
            {
                Log.PublishTxt(e);
                File.Delete(strFileName);
                File.WriteAllText(strFileName, "<?xml version='1.0' encoding='utf-8' ?><LocaSpace></LocaSpace> ");
            }
            XmlNode serverRootNode = myDoc.SelectSingleNode("LocaSpace");
            if (serverRootNode == null)
            {
                serverRootNode = myDoc.CreateElement("LocaSpace");
            }
            XmlElement ele0 = myDoc.CreateElement("IsRecordedSql");
            ele0.InnerText = cbbRecordDatabaseConfig.Checked.ToString();
            serverRootNode.AppendChild(ele0);


            XmlElement ele1 = myDoc.CreateElement("sqlIP");
            ele1.InnerText = textBoxIP.Text.Trim();
            serverRootNode.AppendChild(ele1);

            XmlElement ele2 = myDoc.CreateElement("database");
            ele2.InnerText = textBoxDatabase.Text.Trim();
            serverRootNode.AppendChild(ele2);

            XmlElement ele3 = myDoc.CreateElement("userName");
            ele3.InnerText = textBoxUser.Text.Trim();
            serverRootNode.AppendChild(ele3);

            XmlElement ele4 = myDoc.CreateElement("password");
            ele4.InnerText = textBoxPassword.Text.Trim();
            serverRootNode.AppendChild(ele4);
            try
            {
                myDoc.Save(strFileName);
            }
            catch (Exception exp)
            {
                Log.PublishTxt(exp);
            }            
        }        
        
        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 