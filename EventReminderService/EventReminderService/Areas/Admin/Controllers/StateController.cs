using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using EventReminderService.Areas.Admin.Models;

namespace EventReminderService.Areas.Admin.Controllers
{
    public class StateController : Controller
    {
        // GET: Admin/State
        private EventReminderEntities1 db = new EventReminderEntities1();

        public ActionResult Index()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        public ActionResult GetStateList()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");

            List<tblState> stateList = new List<tblState>();

            foreach (tblState state in db.tblStates.Include(c => c.tblCountry).ToList())
            {
                tblState objState = new tblState();
                objState.StateId = state.StateId;
                objState.StateName = state.StateName;
                objState.IsActive = state.IsActive;
                objState.CountryId = state.CountryId;
                objState.tblCountry = new tblCountry() { CountryId = state.CountryId, CountryName = state.tblCountry.CountryName };

                stateList.Add(objState);
            }
            return Json(stateList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStateListByCountryId(int countryId)
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");

            List<tblState> stateList = new List<tblState>();

            var result = from s in db.tblStates.Where(c => c.CountryId == countryId) select s;

            foreach (tblState state in result.ToList())
            {
                stateList.Add(new tblState() { StateId = state.StateId, StateName = state.StateName });
            }

            return Json(stateList, JsonRequestBehavior.AllowGet);
        }

        public int InsertStateDetails(string stateName, int countryId, bool IsActive)
        {
            tblState state = new tblState()
            {
                StateName = stateName,
                CountryId = countryId,
                IsActive = IsActive
            };
            db.tblStates.Add(state);

            return db.SaveChanges();
        }

        public int UpdateStateDetails(string stateId, string stateName, string countryId, string IsActive)
        {
            tblState state = db.tblStates.Find(int.Parse(stateId));

            state.StateName = stateName;
            state.CountryId = int.Parse(countryId);
            state.IsActive = Convert.ToBoolean(IsActive);

            return db.SaveChanges();
        }

        public int DeleteStateDetails(string stateId)
        {
            tblState state = db.tblStates.Find(int.Parse(stateId));

            db.tblStates.Remove(state);

            return db.SaveChanges();
        }

    }
}