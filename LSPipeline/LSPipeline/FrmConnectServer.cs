using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
namespace WorldGIS
{
    public partial class FrmConnectServer : Form
    {
        public string m_strIP;
        public Int32 m_nPort;
        public string m_strUser;
        public string m_strPsw;
        public FrmConnectServer()
        {
            InitializeComponent();
        }

        private void FrmConnectServer_Load(object sender, EventArgs e)
        {
            ReadXML();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            m_strIP = textBoxIP.Text;
            m_strUser = textBoxUser.Text;
            m_strPsw = textBoxPsw.Text;
            int nResult = 0;
            Int32.TryParse(textBoxPort.Text, out nResult);
            m_nPort = nResult;
            
            WriteXML();
        }

        private void ReadXML()
        {
            string strFileName = Path.GetDirectoryName(Application.ExecutablePath) + "/serverConfig.xml";
            if (!File.Exists(strFileName))
            {
                return;
            }

            //初始化XML文档操作类
            XmlDocument myDoc = new XmlDocument();
            //加载XML文件
            try
            {
                myDoc.Load(strFileName);
            }
            catch (System.Exception e)
            {
                Log.PublishTxt(e);
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
                XmlNode bRecordNode = serverRootNode.SelectSingleNode("IsRecorded");
                bool bRecorded = false;
                if (bRecordNode != null)
                {
                    bool.TryParse(bRecordNode.InnerText, out bRecorded);
                    cbbRecordServerConfig.Checked = bRecorded;
                }

                if (bRecorded)
                {
                    foreach (System.Xml.XmlNode xn in nodes)
                    {
                        if (xn.Name == "IP")
                        {
                            textBoxIP.Text = xn.InnerText;
                        }
                        else if (xn.Name == "Port")
                        {
                            textBoxPort.Text = xn.InnerText;
                        }
                        else if (xn.Name == "UserName")
                        {
                            textBoxUser.Text = xn.InnerText;
                        }
                        else if (xn.Name == "UserPwd")
                        {
                            textBoxPsw.Text = xn.InnerText;
                        }
                    }
                }
            }
        }
        private void WriteXML()
        {
             string strFileName = Path.GetDirectoryName(Application.ExecutablePath) + "/serverConfig.xml";
             File.WriteAllText(strFileName, "<?xml version='1.0' encoding='utf-8' ?><LocaSpace></LocaSpace> ");
             XmlDocument myDoc = new XmlDocument();

             //加载XML文件
            
             //XmlElement serverRootElem = null;
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

             XmlElement ele0 = myDoc.CreateElement("IsRecorded");
             ele0.InnerText = cbbRecordServerConfig.Checked.ToString();
             serverRootNode.AppendChild(ele0);


             XmlElement ele1 = myDoc.CreateElement("IP");
             ele1.InnerText = m_strIP;
             serverRootNode.AppendChild(ele1);

             XmlElement ele2 = myDoc.CreateElement("Port");
             ele2.InnerText = textBoxPort.Text;
             serverRootNode.AppendChild(ele2);

             XmlElement ele3 = myDoc.CreateElement("UserName");
             ele3.InnerText = m_strUser;
             serverRootNode.AppendChild(ele3);


             XmlElement ele4 = myDoc.CreateElement("UserPwd");
             ele4.InnerText = m_strPsw;
             serverRootNode.AppendChild(ele4);

             try
             {
                 myDoc.Save(strFileName);
             }
             catch (System.Exception e)
             {
                 Log.PublishTxt(e);
             }            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
