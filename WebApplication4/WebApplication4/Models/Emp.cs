using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Emp : Dept
    {
        string sqlCommandText;
        DataAccessLogic objDAL = new DataAccessLogic();

        [Display(Name ="Emp Id")]
        public int EmpId { get; set; }
        [Display(Name ="Emp Name")]
        public string EmpName { get; set; }
        [Display(Name ="Emp Job")]
        public string EmpJob { get; set; }
        [Display(Name ="Emp Salary")]
        public decimal EmpSalary { get; set; }


        public List<Emp> GetEmpData ()
        {
            sqlCommandText = "select e.EmpId, e.EmpName, e.EmpJob, e.EmpSalary, e.DeptId, d.DeptName from Emp e, Dept d where e.DeptId = d.DeptId";
            DataSet ds = objDAL.ExecuteDataSet(sqlCommandText);
            DataTable dt = ds.Tables[0];
            DataRowCollection dtc = dt.Rows;
            List<Emp> objEmp = new List<Emp>();

            foreach(DataRow dr in dtc)
            {
                objEmp.Add(new Emp()
                {
                    EmpId = Convert.ToInt32(dr["EmpId"]),
                    EmpName = dr["EmpName"].ToString(),
                    EmpJob = dr["EmpJob"].ToString(),
                    EmpSalary = Convert.ToDecimal(dr["EmpSalary"]),
                    DeptId = Convert.ToInt32(dr["DeptId"]),
                    DeptName = dr["DeptName"].ToString()
                });
            }

            return objEmp;
        }

        public Emp GetEmpDetails (int EmpId)
        {
            sqlCommandText = "select e.EmpId, e.EmpName, e.EmpJob, e.EmpSalary, e.DeptId, d.DeptName from Emp e, Dept d where e.DeptId = d.DeptId and e.EmpId =" + EmpId;
            DataSet ds = objDAL.ExecuteDataSet(sqlCommandText);
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            Emp emp = new Emp()
            {
                EmpId = Convert.ToInt32(dr["EmpId"]),
                EmpName = dr["EmpName"].ToString(),
                EmpJob = dr["EmpJob"].ToString(),
                EmpSalary = Convert.ToDecimal(dr["EmpSalary"]),
                DeptId = Convert.ToInt32(dr["DeptId"]),
                DeptName = dr["DeptName"].ToString()
            };

            return emp;
        }
        
        public int InsertEmpDetails (Emp objEmp)
        {
            sqlCommandText = "insert into Emp ( EmpName, EmpJob, EmpSalary, DeptId) values ('" + objEmp.DeptName + "', '" + objEmp.EmpJob + "', " + objEmp.EmpSalary + ", " + objEmp.EmpSalary + ", " + objEmp.DeptId + ")";

            return objDAL.ExecuteNonQuery(sqlCommandText);
        }

        public int UpdateEmpDetails (Emp objEmp)
        {
            sqlCommandText = "update Emp set EmpName='" + objEmp.EmpName + "', EmpJob='" + objEmp.EmpJob + "', EmpSalary=" + objEmp.EmpSalary + ", DeptId=" + objEmp.DeptId + " where EmpId=" + objEmp.EmpId;

            return objDAL.ExecuteNonQuery(sqlCommandText);
        }

        public int DeleteEmpDetails (int empId)
        {
            sqlCommandText = "Delete from Emp where EmpId=" + empId;

            return objDAL.ExecuteNonQuery(sqlCommandText);
        }
    }
}