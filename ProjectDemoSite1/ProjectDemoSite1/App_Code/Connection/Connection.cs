using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
///  Connection Class Containing Methods Which Returns the Connection String from the Config File
/// </summary>

namespace RNS.Project.DBConnection
{
    public class Connection
    {
        #region Static Methods
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        }
        #endregion
    }
}