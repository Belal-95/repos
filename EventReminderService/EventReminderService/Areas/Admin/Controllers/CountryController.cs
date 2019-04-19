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
    public class CountryController : Controller
    {

        EventReminderEntities1 dbEntities = new EventReminderEntities1();
        public ActionResult Index()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");
            return View();
        }
        public ActionResult GetCountryList()
        {

            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");
            List<tblCountry> countryList = new List<tblCountry>();

            foreach (tblCountry country in dbEntities.tblCountrys.ToList())
            {
                countryList.Add(new tblCountry() { CountryId = country.CountryId, CountryName = country.CountryName, IsActive = country.IsActive });

            }
            return Json(countryList, JsonRequestBehavior.AllowGet);
        }
        public int InsertCountryDetails(string countryName, string isActive)
        {
            tblCountry country = new tblCountry()
            {
                CountryName = countryName,
                IsActive = Convert.ToBoolean(isActive)
            };
            dbEntities.tblCountrys.Add(country);

            return dbEntities.SaveChanges();
        }

        public int UpdateCountryDetails(string countryId, string countryName, string IsActive)
        {
            tblCountry country = dbEntities.tblCountrys.Find(int.Parse(countryId));

            country.CountryName = countryName;
            country.IsActive = Convert.ToBoolean(IsActive);
            return dbEntities.SaveChanges();
        }

        public int DeleteCountryDetails(string countryId)
        {
            tblCountry country = dbEntities.tblCountrys.Find(int.Parse(countryId));
            dbEntities.tblCountrys.Remove(country);
            return dbEntities.SaveChanges();
        }
    }
}