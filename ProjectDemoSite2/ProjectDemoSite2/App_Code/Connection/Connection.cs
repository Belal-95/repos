using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
///  Connection Class Containing Methods Which Returns the Connection String from the Config File
/// </summary>

namespace RSN.Project.DBConnection
{
    public class Connection
    {
        #region
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        #endregion
    }
}