using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using RSN.Project.DBConnection;
using RSN.Project.Utility;

/// <summary>
/// Summary description for SqlHelper
/// </summary>
/// 
namespace RSN.Project.DAL
{
    public static class SqlHelper
    {
        #region Static Fields
        static SqlConnection sqlConnection = null;
        static SqlDataAdapter sqlDataAdapter = null;
        static DataSet dataSet = null;
        static SqlCommand sqlCommand = null;

        #endregion

        #region Static methods
        public static void CreateConnection()
        {
            sqlConnection = new SqlConnection(Connection.GetConnection());
        }

        public static DataSet ExecuteDataSet (string sqlCommandText)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText,SqlParameter sqlParameter)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, SqlParameter sqlParameter, SqlCommand sqlCommand)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, SqlParameter[] sqlParameters)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, SqlParameter[] sqlParameters, SqlCommand sqlCommand)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, SqlCommand sqlCommand)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static int ExecuteNonQuery(string sqlCommandText)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText,sqlConnection);
            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return RowEffected;

        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter sqlParameter)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return RowEffected;

        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter[] sqlParameters)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText,sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParameters);
            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return RowEffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter sqlParameter, SqlCommand sqlCommand)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return RowEffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter[] sqlParameters, SqlCommand sqlCommand)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParameters);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return RowEffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlCommand sqlCommand)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return RowEffected;
        }


        #endregion
    }
}