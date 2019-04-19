using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;


namespace RSN.ER.DBConnection
{
    /// <summary>
    /// Connection class contains methods fpr connecting to a Databaase.
    /// </summary>
    class Connection
    {
        public Connection()
        {
            //
            // TODO: Add constructor logic her
            //
        }

        public static Database GEtDefaultDbConnection()
        {
            // Configure the DataBaseFactory to read its configuration from the web.config file
            DatabaseProviderFactory factory = new DatabaseProviderFactory();

            // Create the default Database object from the factory
            // The actual concrete type is determined by the configuration settings.
            Database defaultDB = factory.CreateDefault();

            return defaultDB;
        }

        public static Database GetNamedDBConnection()
        {
            // Configuration the DataBaseFactory to read its configuration from the web.config file
            DatabaseProviderFactory factory = new DatabaseProviderFactory();

            // Create a Database Object from the factory using the connection string name
            Database namedDB = factory.Create("conStr");
            return namedDB;
        }

        public static SqlDatabase GetSqlDatabaseDefaultConnection()
        {
            // Configure the DataBaseFactory to read its configuration from the web.config file
            DatabaseProviderFactory factory = new DatabaseProviderFactory();

            // Create a SqlDatabase Object from configuration using the default database

            SqlDatabase sqlServerDefaultDB = factory.CreateDefault() as SqlDatabase;

            return sqlServerDefaultDB;
        }

        public static SqlDatabase GetSqlDatabaseNamedConnection()
        {
            // Configure the DataBaseFactory to read its configuration from the web.config file
            DatabaseProviderFactory factory = new DatabaseProviderFactory();

            // Create a SqlDatabase Object from configuration using the named database
            SqlDatabase sqlServerNamedDB = factory.Create("conStr") as SqlDatabase;

            return sqlServerNamedDB;
        }

        public static SqlDatabase GetSqlDBConnection()
        {
            //Create a SqlDatabase Object from configuratio
            SqlDatabase sqlServerDB = new SqlDatabase(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            return sqlServerDB;
        }
    }
}
