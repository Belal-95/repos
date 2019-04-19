using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;


/// <summary>
/// Summary description for Connection
/// </summary>
/// 
namespace RSN.Project.DBConnection
{
    public class Connection
    {
        #region Public Methods
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        }
        #endregion
    }
}