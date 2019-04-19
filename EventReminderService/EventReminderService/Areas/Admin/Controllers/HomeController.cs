using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EventReminderService.Areas.Admin.Models;
using EventReminderService.Common;


namespace EventReminderService.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        EventReminderEntities1 dbEntities = new EventReminderEntities1();

        // GET: Admin/Home
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        // GET: Admin/User/Login
        public ActionResult Login()
        {
          //  ViewData["Pwd"] = Utility.Encrypt("admin123", "ER");
            return View();
        }

        // when we click on submit button on Login Form

        [HttpPost]
        public ActionResult Login(tblAdminAccount model)//parsing the model which hold validated UserName and Password was Entered by user to compare with the ones in the database
        {
            List<tblAdminAccount> objAdminAccountList = dbEntities.SP_CheckAdminLogin(model.UserName, Utility.Encrypt(model.Password, "ER")).ToList(); // declaring a list table object and using Entities and stored procedur compare (model.UserName, model.Password after encrypt it)(the user inputed values) with the ones in the database using the stored procedur to search about mathcing in the database as we parse for it these two values

            if(objAdminAccountList.Count>0)//if there is value in the first index from the list that means we find matching from database
            {
                Session["AdminUser"] = objAdminAccountList[0].UserName; // saving the admin name in session to use it in the pages where needed

                string lastAccessedDateTime = objAdminAccountList[0].LastAccessedDateTime.ToString();

                DateTime currentAccessedDateTime = DateTime.Now;

                if(string.IsNullOrEmpty(lastAccessedDateTime))//new user first time
                {
                    Session["LastAccessedDateTime"] = currentAccessedDateTime.ToString();
                }
                else //old user we have value for last date time in database
                {
                    Session["LastAccessedDateTime"] = lastAccessedDateTime;
                }

                // for updating last access login
                tblAdminAccount objAdminAccount = dbEntities.tblAdminAccounts.Find(objAdminAccountList[0].UserName);
                objAdminAccount.LastAccessedDateTime = currentAccessedDateTime;

                dbEntities.SaveChanges();

                ViewBag.Error = string.Empty;
                return RedirectToAction("ControlPanel");
            }
            else // no username and password matching found in database
            {
                ViewBag.Error = "Invalid User Name or Password";
            }
            return View();
        }

        public ActionResult ControlPanel()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("login");

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon(); // Cancel the current Session
            Session.Remove("AdminUser");
            Session.Remove("LastAccessDateTime");

            return RedirectToAction("Login");
        }

        public ActionResult ChangePassword()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login");

            return View();
        }

        public JsonResult CheckOldPassword(string oldPwd, string userName)
        {
            return Json(dbEntities.SP_CheckAdminOldPassword(userName, Utility.Encrypt(oldPwd, "ER")), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ChangePassword(Models.Admin model)
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login");

            tblAdminAccount objAdminAccount = dbEntities.tblAdminAccounts.Find(Session["AdminUser"].ToString());

            objAdminAccount.Password = Utility.Encrypt(model.NewPassword, "ER");

            if (dbEntities.SaveChanges() > 0)
                ViewBag.Status = 1;
            else
                ViewBag.Status = 0;

            return View();
        }
    }
}