using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using RNS.Project.DBConnection;

/// <summary>
/// SqlHelper Class
/// Contining all static methods which interact with Database
/// </summary>

namespace RNS.Project.DAL
{
    public static class SqlHelper
    {

        #region Static Field
        static SqlConnection sqlConnection = null;
        static SqlDataAdapter sqlDataAdapter = null;
        static SqlCommand sqlCommand = null;
        static DataSet dataSet = null;
        #endregion

        #region Static Methods
        static void CreatConnection()
        {
            sqlConnection = new SqlConnection(Connection.GetConnection());
        }

        public static DataSet ExecuteDataSet(String sqlCommandText)
        {
            CreatConnection();

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;

        }

        public static DataSet ExecuteDataSet(String sqlCommandText, SqlParameter sqlParameter)
        {
            CreatConnection();

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataSet ExecuteDataSet(String sqlCommandText, SqlParameter[] sqlParameters)
        {
            CreatConnection();

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.AddRange(sqlParameters);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, CommandType commandType)
        {
            CreatConnection();

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, SqlParameter sqlParameter, CommandType commandType)
        {
            CreatConnection();

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, SqlParameter[] sqlParameterS, CommandType commandType)
        {
            CreatConnection();

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            sqlDataAdapter.SelectCommand.Parameters.AddRange(sqlParameterS);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static int ExecuteNonQuery(string sqlCommandText)
        {
            CreatConnection();

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter sqlParameter)
        {
            CreatConnection();

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter[] sqlParameters)
        {
            CreatConnection();

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParameters);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, CommandType commandType)
        {
            CreatConnection();

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = commandType;
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, CommandType commandType, SqlParameter sqlParameter)
        {
            CreatConnection();

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = commandType;
            sqlCommand.Parameters.Add(sqlParameter);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, CommandType commandType, SqlParameter[] sqlParameters)
        {
            CreatConnection();

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = commandType;
            sqlCommand.Parameters.AddRange(sqlParameters);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        #endregion
    }
}