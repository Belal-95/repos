using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using FAR.Project.DBConnection;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SqlHelper
/// </summary>

namespace FAR.Project.DAL
{
    public class SqlHelper
    {
        #region Static Fields
        static SqlConnection sqlConnection = null;
        static SqlDataAdapter sqlDataAdapter = null;
        static DataSet dataSet = null;
        static SqlCommand sqlCommand = null;
        #endregion

        #region Static Method
         static void CreateConnection()
        {
            sqlConnection = new SqlConnection(Connection.GetConnection());
        }

        public static DataSet ExecuteDataSet(string sqlCommandText)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText,SqlParameter sqlParameter)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText,SqlParameter[] sqlParameters)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.AddRange(sqlParameters);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText,CommandType commandType)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText,SqlParameter sqlParameter,CommandType commandType)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText,SqlParameter[] sqlParameters,CommandType commandType)
        {
            CreateConnection();
            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.AddRange(sqlParameters);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            dataSet = new DataSet();
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

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParameters);
            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return RowEffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, CommandType commandType)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = commandType;
            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return RowEffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter sqlParameter, CommandType commandType)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = commandType;
            sqlCommand.Parameters.Add(sqlParameter);
            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return RowEffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter[] sqlParameters, CommandType commandType)
        {
            CreateConnection();
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = commandType;
            sqlCommand.Parameters.AddRange(sqlParameters);
            int RowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return RowEffected;
        }
        #endregion
    }
}