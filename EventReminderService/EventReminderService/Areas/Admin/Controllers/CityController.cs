using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using EventReminderService.Areas.Admin.Models;

namespace EventReminderService.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        EventReminderEntities1 db = new EventReminderEntities1();

        public ActionResult Index()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        /// <summary>
        /// Action Methods To Be Used By JQuery Ajax
        /// </summary>
        

        public ActionResult GetCityList()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");

            List<tblCity> cityList = new List<tblCity>();
            
            foreach(tblCity city in db.tblCities.Include(c => c.tblState.tblCountry).ToList())
            {
                tblCity objCity = new tblCity();
                objCity.CityId = city.CityId;
                objCity.CityName = city.CityName;
                objCity.IsActive = city.IsActive;
                objCity.CountryId = city.CountryId;
                objCity.StateId = city.StateId;
                objCity.tblCountry = new tblCountry() { CountryId = city.CountryId, CountryName = city.tblCountry.CountryName };
                objCity.tblState = new tblState() { StateId = city.StateId, StateName = city.tblState.StateName };

                cityList.Add(objCity);
            }
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }

        public int InsertCityDetails(string cityName, int countryId, int stateId, bool isActive)
        {
            tblCity city = new tblCity()
            {
                CityName = cityName,
                CountryId = countryId,
                StateId = stateId,
                IsActive = isActive
            };
            db.tblCities.Add(city);

            return db.SaveChanges();
        }

        public int UpdateCityDetails(int cityId, string cityName, int countryId, int stateId, bool isActive)
        {
            tblCity city = db.tblCities.Find(cityId);

            city.CityName = cityName;
            city.CountryId = countryId;
            city.StateId = stateId;
            city.IsActive = isActive;

            return db.SaveChanges();
        }

        public int DeleteCityDetails(int cityId)
        {
            tblCity city = db.tblCities.Find(cityId);

            db.tblCities.Remove(city);

            return db.SaveChanges();
        }
    }
}