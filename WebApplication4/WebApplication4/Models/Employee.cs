using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Employee
    {
        [Display(Name ="Emp Id")]
        public int EmpId { get; set; }
        [Display(Name ="Emp Name")]
        public string EmpName { get; set; }
        [Display(Name ="Emp Job")]
        public string EmpJob { get; set; }
        [Display(Name ="Emp Salary")]
        public decimal EmpSalary { get; set; }
        [Display(Name ="Dept Name")]
        public string DeptName { get; set; }

        public Address Address { get; set; }

    }
}