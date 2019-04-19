using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public JsonResult Index()
        {
            var val = new List<string>
            {
                "AAA",
                "BBB",
                "CCC"
            };
            return Json(val,JsonRequestBehavior.AllowGet);
        }

        public ViewResult A()
        {
            ViewData["belal"] = "hello";
            return View();
        }

        // Non Action Method 
        // First way
        [NonAction]
        public string AA()
        {
            return "Hello how are you!!! ^_^ I am Non Action Method";
        }

        // Second Way (because Action Methods always should be Public)
        private string AAA()
        {
            return "Hello how are you!!! ^_^ I am Non Action Method";
        }

        public string B()
        {
            return Request["id"];
        }
        [HttpPost]
        public ViewResult BB(string Value1, string Value2)
        {
            float value1 = float.Parse(Value1);
            float value2 = float.Parse(Value2);
            float result = value1 + value2;
            ViewBag.Result = result;
            return View("BB");
        }

        [HttpPost]
        public ViewResult Calculate(string Value1, string Value2)
        {
            float value1 = float.Parse(Value1);
            float value2 = float.Parse(Value2);
            float result = value1 + value2;
            ViewBag.Result = result;
            return View("Display");
        }

        public ActionResult EmployeeDetails()
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee { EmpId=101, EmpName="Ahmad", EmpJob="Accountent", EmpSalary=12000, DeptName="Sales",Address = new Address () { AddressLine1="Ameerpet", City="Hyderabad", State="Telengana", PinCode="500020"} },
                new Employee { EmpId=102, EmpName="Belal", EmpJob="Programmer", EmpSalary=100000, DeptName="It",Address = new Address () { AddressLine1="MasabTank", City="Hyderabad", State="Telengana", PinCode="500020"} },
                new Employee { EmpId=101, EmpName="Ali", EmpJob="Team leader", EmpSalary=19500, DeptName="HR",Address = new Address () { AddressLine1="Malakpet", City="Hyderabad", State="Telengana", PinCode="500020"} }

            };
            return View(empList);
        }
    }
}