using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationForHostingExample.Models;

namespace WebApplicationForHostingExample.Controllers
{
    public class HomeController : Controller
    {
        ForHostingDataBaseEntities2 dbEntities = new ForHostingDataBaseEntities2();

        public ActionResult Index()
        {
            return View(dbEntities.Students.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student )
        {
            dbEntities.Students.Add(student);
            dbEntities.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}