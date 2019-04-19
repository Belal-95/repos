using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class DemoController : Controller
    {
        Emp objEmp = new Emp();

        // GET: Demo
        public ActionResult Index()
        {
            return View(objEmp.GetEmpData());
        }

        public ActionResult Create()
        {
            ViewBag.DeptList = new SelectList(objEmp.GetDeptData(), "DeptId", "DeptName");
            return View();
        }
    }
}