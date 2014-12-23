using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Xml;
using System.Net;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
namespace WorldGIS
{
    public class Utility
    {
        public static void SetBallons(GSOBalloon featureTooltip,GSOBalloonEx balloonEx)
        {
            featureTooltip.CacheFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "/GeoScene/Globe/Temp";

            featureTooltip.SetSize(EnumSizeIndex.ROUNDED_CX, 0);
            featureTooltip.SetSize(EnumSizeIndex.ROUNDED_CY, 0);
            featureTooltip.SetSize(EnumSizeIndex.MARGIN_CX, 3);
            featureTooltip.SetSize(EnumSizeIndex.MARGIN_CY, 3);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_HEIGHT, 0);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_WIDTH, 0);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_MARGIN, 0);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_OFFSET_CX, 1);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_OFFSET_CY, -1);
            featureTooltip.SetDirection(EnumToolTipDirection.TD_BOTTOMEDGE_LEFT);

            featureTooltip.EscapeSequencesEnabled = true;
            featureTooltip.HyperlinkEnabled = true;
            featureTooltip.Opaque = 30;
            featureTooltip.MaxWidth = 300;
            featureTooltip.SetShadow(0, 0, 50, true, 0, 0);
            
            balloonEx.SetSize(EnumSizeIndexEx.CONTENT_CX, 500);
            balloonEx.SetSize(EnumSizeIndexEx.CONTENT_CY, 300);
            balloonEx.Opaque = 5;
            balloonEx.SetBorder(Color.White, 1, 1);
            balloonEx.SetColorBkType(EnumBkColorTypeEx.SKY);
        }

        public static GSOFeature FindFeatureByUserID(GSOFeatureDataset featdataset,string fieldname,string value)
        {
            GSOFeatures feats = featdataset.GetAllFeatures(); 
            for (int i = 0; i < feats.Length; i++)
            {
                GSOFeature feat = feats[i];
                if (feat.GetFieldAsString(fieldname) == value)
                {
                    return feat;
                }
            }
            return null;
        }
        public static List<DatabaseConnectParams> connectParamsOfDatabase = new List<DatabaseConnectParams>();      

        public static Hashtable Pipe_QueryFields;
       
        public static string DBBackUp;
        public static string serverip;
        public static int serverport;
        public static string localicenseserverip;
        public static int localicenseserverport;
        public static GeoScene.Engine.GSODataSource dataSource;
        public static ArrayList LayerLabels;
        public static ArrayList LayerNames;
        public static ArrayList TerrainsName;
        public static Hashtable LayerLabel_LayerIDs;
        public static Hashtable Query_Fields = new Hashtable();
        public static Hashtable Pipe_Code = new Hashtable();
        public static string PicRootURL;
        public static double dFlyAboveLine = 2;

        public static string GetProjectName()
        {
            string strProjectName = "";
            string filename = Application.StartupPath + "\\config.xml";
            if (File.Exists(filename))
            {
                XmlTextReader XmlReader = new XmlTextReader(filename);
                try
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.Name == "Project")
                        {
                            strProjectName = XmlReader["name"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.PublishTxt(ex);
                    MessageBox.Show(ex.Message);
                }
            }
            return strProjectName;
        }

        public static GeoScene.Data.GSOPoint2d XYZ_2_Latlon(double x, double y)
        {
            int id = GeoScene.Data.GSOProjectManager.AddProject(Utility.GetProjectName());            
            GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(x, y);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(pt2d, id);
            return result;
        }

        public static GeoScene.Data.GSOPoint2d Latlon_2_XYZ(double lon, double lat)
        {
            int id = GeoScene.Data.GSOProjectManager.AddProject(Utility.GetProjectName());
            GeoScene.Data.GSOPoint2d pt2d = new GeoScene.Data.GSOPoint2d(lon, lat);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(pt2d, id);
            return result;
        }

        public static GSOFeatures Table2Features(DataTable table, string currentQueryLayer,GeoScene.Globe.GSOGlobeControl globeControl1)
        {
            GSOFeatures features = new GSOFeatures();
            for (int i = 0; i < table.Rows.Count; i++)
			{
			    DataRow row = table.Rows[i];

                string featureName = row["编号"].ToString();
                featureName = featureName.Trim();
                GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(currentQueryLayer);            
                GSOFeatures tempfeatures = layer.GetFeatureByName(featureName, false);
                if (tempfeatures.Length > 0)
                {
                    features.Add(tempfeatures[0]);
                }
			}
            return features;
        }

        public static bool isNetworkConnectionSuccess(string ipAdress)
        {
            if (ipAdress.Trim().Contains("\\") == true)
            {
                ipAdress = ipAdress.Substring(0, ipAdress.IndexOf("\\"));
            }
            if (ipAdress.Trim() == "localhost" || ipAdress.Trim() == "127.0.0.1" || ipAdress.Trim() == Dns.GetHostName() || ipAdress.Trim() == Dns.GetHostAddresses(Dns.GetHostName()).GetValue(2).ToString())
            {
                return true;
            }
            Ping ping = new Ping();
            PingReply pr = ping.Send(ipAdress.Trim(), 10000);
            if (pr.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }

        public static GSODataSource getDataSourceByFullName(GSOGlobeControl globeControl1, string dataSourceFullName)
        {
            foreach (DatabaseConnectParams connectParmas in Utility.connectParamsOfDatabase)
            {                
                if (connectParmas != null && connectParmas.dataSourceFullName == dataSourceFullName)
                {
                    return globeControl1.Globe.DataManager.GetDataSourceByName(connectParmas.dataSourceName);
                }
            }
            return null;
        }
        public static DatabaseConnectParams getConnectParamsByDatasourceFullName(GSOGlobeControl globeControl1, string dataSourceFullName)
        {
            foreach (DatabaseConnectParams connectParmas in Utility.connectParamsOfDatabase)
            {
                if (connectParmas != null && connectParmas.dataSourceFullName == dataSourceFullName)
                {
                    return connectParmas;
                }
            }
            return null;
        }
        public static DatabaseConnectParams getConnectParamsByDatasourceName(GSOGlobeControl globeControl1, string dataSourceName)
        {
            foreach (DatabaseConnectParams connectParmas in Utility.connectParamsOfDatabase)
            {
                if (connectParmas != null && connectParmas.dataSourceName == dataSourceName)
                {
                    return connectParmas;
                }
            }
            return null;
        }
    }    
}