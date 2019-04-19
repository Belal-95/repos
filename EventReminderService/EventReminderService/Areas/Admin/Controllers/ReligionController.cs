using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
//
using EventReminderService.Areas.Admin.Models;


namespace EventReminderService.Areas.Admin.Controllers
{
    public class ReligionController : Controller
    {

        EventReminderEntities1 dbEntities = new EventReminderEntities1();
        public ActionResult Index()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");
            return View();
        }
        public ActionResult GetReligionList()
        {

            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");
            List<tblReligion> Religion = new List<tblReligion>();

            foreach (tblReligion religion in dbEntities.tblReligions.ToList())
            {
                Religion.Add(new tblReligion() { ReligionId = religion.ReligionId, ReligionName = religion.ReligionName, IsActive = religion.IsActive });

            }
            return Json(Religion, JsonRequestBehavior.AllowGet);
        }
        public int InsertReligion(string religionName, string isActive)
        {
            tblReligion religion = new tblReligion()
            {
                ReligionName = religionName,
                IsActive = Convert.ToBoolean(isActive)
            };
            dbEntities.tblReligions.Add(religion);

            return dbEntities.SaveChanges();
        }

        public int UpdateReligion(string religionId, string religionName, string isActive)
        {
            tblReligion religion = dbEntities.tblReligions.Find(int.Parse(religionId));

            religion.ReligionName = religionName;
            religion.IsActive = Convert.ToBoolean(isActive);
            return dbEntities.SaveChanges();
        }

        public int DeleteReligion(string religionId)
        {
            tblReligion religion = dbEntities.tblReligions.Find(int.Parse(religionId));
            dbEntities.tblReligions.Remove(religion);
            return dbEntities.SaveChanges();
        }
    }
}