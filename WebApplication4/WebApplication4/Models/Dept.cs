using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

using System.ComponentModel.DataAnnotations;
namespace WebApplication4.Models
{
    public class Dept
    {
        string sqlCommandText;
        DataAccessLogic objDAL = new DataAccessLogic();

        [Display (Name ="Dept Id")]
        public int DeptId { get; set; }

        [Display (Name ="Dept Name")]
        public string DeptName { get; set; }

        public List<Dept> GetDeptData()
        {
            sqlCommandText = "select * from Dept";
            DataSet ds = objDAL.ExecuteDataSet(sqlCommandText);
            DataTable dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Dept> objList = new List<Dept>();

            foreach (DataRow dr in drc)
            {
                objList.Add(new Dept()
                {
                    DeptId = Convert.ToInt32(dr["DeptId"]),
                    DeptName = dr["DeptName"].ToString()
                });
            }
            return objList;
        }


    }
}