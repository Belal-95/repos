using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RSN.DAL
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
        static void CreatConnection(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public static DataSet ExecuteDataSet(String sqlCommandText, string connectionString)
        {
            CreatConnection(connectionString);

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;

        }

        public static DataSet ExecuteDataSet(String sqlCommandText, SqlParameter sqlParameter, string connectionString)
        {
            CreatConnection(connectionString);

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataSet ExecuteDataSet(String sqlCommandText, SqlParameter[] sqlParameters, string connectionString)
        {
            CreatConnection(connectionString);

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.AddRange(sqlParameters);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, CommandType commandType, string connectionString)
        {
            CreatConnection(connectionString);

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, SqlParameter sqlParameter, CommandType commandType, string connectionString)
        {
            CreatConnection(connectionString);

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataSet ExecuteDataSet(string sqlCommandText, SqlParameter[] sqlParameterS, CommandType commandType, string connectionString)
        {
            CreatConnection(connectionString);

            sqlDataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            sqlDataAdapter.SelectCommand.Parameters.AddRange(sqlParameterS);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static int ExecuteNonQuery(string sqlCommandText, string connectionString)
        {
            CreatConnection(connectionString);

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter sqlParameter, string connectionString)
        {
            CreatConnection(connectionString);

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, SqlParameter[] sqlParameters, string connectionString)
        {
            CreatConnection(connectionString);

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParameters);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, CommandType commandType, string connectionString)
        {
            CreatConnection(connectionString);

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = commandType;
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, CommandType commandType, SqlParameter sqlParameter, string connectionString)
        {
            CreatConnection(connectionString);

            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            sqlCommand.CommandType = commandType;
            sqlCommand.Parameters.Add(sqlParameter);
            int rowAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowAffected;
        }

        public static int ExecuteNonQuery(string sqlCommandText, CommandType commandType, SqlParameter[] sqlParameters, string connectionString)
        {
            CreatConnection(connectionString);

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
