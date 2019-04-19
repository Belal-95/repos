using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication4.Models
{
    public class DataAccessLogic
    {
        SqlConnection cn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        SqlCommand cmd = null;

        public DataAccessLogic()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        }

        public DataSet ExecuteDataSet (string sqlCommandText)
        {
            da = new SqlDataAdapter(sqlCommandText, cn);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet ExecuteDataSet(string sqlCommandText, CommandType commandType, SqlParameter[] parameters)
        {
            da = new SqlDataAdapter(sqlCommandText, cn);
            da.SelectCommand.CommandType = commandType;
            da.SelectCommand.Parameters.AddRange(parameters);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public DataSet ExecuteDataSet(string sqlCommandText, CommandType commandType, SqlParameter parameter)
        {
            da = new SqlDataAdapter(sqlCommandText, cn);
            da.SelectCommand.CommandType = commandType;
            da.SelectCommand.Parameters.Add(parameter);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public DataSet ExecuteDataSet (string sqlCommandText, CommandType commandType)
        {
            da = new SqlDataAdapter(sqlCommandText, cn);
            da.SelectCommand.CommandType = commandType;
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int ExecuteNonQuery (string sqlCommandText)
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            cmd = new SqlCommand(sqlCommandText,cn);
            int rowEffected = cmd.ExecuteNonQuery();
            cn.Close();

            return rowEffected;
        }

        public int ExecuteNonQuery (string sqlCommandText, CommandType commandType)
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            cmd = new SqlCommand(sqlCommandText, cn);
            cmd.CommandType = commandType;
            int rowEffected = cmd.ExecuteNonQuery();
            cn.Close();

            return rowEffected;
        }

        public int ExecuteNonQuery (string sqlCommandText, SqlParameter parameter, CommandType commandType)
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmd = new SqlCommand(sqlCommandText, cn);
            cmd.CommandType = commandType;
            cmd.Parameters.Add(parameter);
            int rowEffected = cmd.ExecuteNonQuery();
            cn.Close();

            return rowEffected;
        }

        public int ExecuteNonQuery (string sqlCommandText, SqlParameter[] parameters, CommandType commandType)
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmd = new SqlCommand(sqlCommandText, cn);
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(parameters);
            int rowEffected = cmd.ExecuteNonQuery();
            cn.Close();

            return rowEffected;
        }
    }

    
}