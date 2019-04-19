using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
///  Connection Class Containing Methods Which Returns the Connection String from the Config File
/// </summary>

namespace FAR.Project.DBConnection
{
    public class Connection
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
    }
}