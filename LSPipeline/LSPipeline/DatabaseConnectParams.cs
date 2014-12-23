using System;
using System.Collections.Generic;
using System.Text;
using GeoScene.Data;

namespace WorldGIS
{
    public class DatabaseConnectParams
    {
        public string ip;
        public string databaseName;
        public string userName;
        public string password;
        public string dataSourceName;
        public EnumDataSourceType databaseType;

        public DatabaseConnectParams()
        { }

        public DatabaseConnectParams(string _ip, string _databaseName, string _userName, string _password, string _dataSourceName, EnumDataSourceType _databaseType)
        {
            ip = _ip;
            databaseName = _databaseName;
            userName = _userName;
            password = _password;
            dataSourceName = _dataSourceName;
            databaseType = _databaseType;
        }

        public string dataSourceFullName
        {
            get {
                if (databaseType == EnumDataSourceType.SqlServer)
                {
                    return "SqlServer：" + dataSourceName;
                }
                else if (databaseType == EnumDataSourceType.Oracle)
                {
                    return "Oracle：" + dataSourceName;
                }
                else
                {
                    return dataSourceName; 
                }
            }
        }
    }
}
