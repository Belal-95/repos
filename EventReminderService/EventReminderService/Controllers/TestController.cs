using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EventReminderService.Models;


namespace EventReminderService.Controllers
{
    public class TestController : Controller
    {

        EventReminderEntities2 dbEntities = new EventReminderEntities2();

        public JsonResult CheckEmailAvailability(string email)
        {
            return Json(dbEntities.SP_CheckEmailAvailibility(email), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            TempData["Email"] = email;
            TempData["Password"] = password;
            return RedirectToAction("Registeration");
        }

        public ActionResult Registeration()
        {
            return View();
        }
    }
}