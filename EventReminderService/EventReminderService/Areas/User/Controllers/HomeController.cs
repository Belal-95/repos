using EventReminderService.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using EventReminderService.Common;

namespace EventReminderService.Areas.User.Controllers
{

    public class HomeController : Controller
    {
        EventReminderEntities5 dbUserEntities = new EventReminderEntities5();
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Remove("UserId");
            Session.Remove("FirstName");
            Session.Remove("EmailId");
            Session.Remove("LastAccessedDateTime");

            return RedirectToAction("Index");
        }

        public ActionResult MembersCorner()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });

            return View();
        }

        public ActionResult AddBirthdays()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });

            List<SelectListItem> Gender = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Male",Value="M"},
                new SelectListItem()
                {Text="Female", Value="F" }
            };
            ViewBag.Gender = Gender;

            List<SelectListItem> Relationships = new List<SelectListItem>();

            List<BindRelationship> RelationshipList = dbUserEntities.SP_BindRelationship().ToList();

            foreach (BindRelationship relationship in RelationshipList)
            {
                Relationships.Add(new SelectListItem() { Text = relationship.RelationshipName, Value = relationship.RelationshipId.ToString() });
            }

            ViewBag.Relationships = Relationships;

            return View();
        }

        [HttpPost]
        public ActionResult AddBirthdays(tblBirthdayDetail model)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });

            model.UserId = Convert.ToInt32(Session["UserId"]);
            dbUserEntities.tblBirthdayDetails.Add(model);
            dbUserEntities.SaveChanges();

            TempData["Status"] = "Birthday Details has been added successfully!!!";
            return RedirectToAction("AddBirthdays");
        }


        public ActionResult MyAccount()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });

            UserDetails objUser = BindUserDetails();

            return View(objUser);
        }

        [HttpPost]
        public ActionResult MyAccount(string firstName, HttpPostedFileBase profilePhoto, string middleName, string lastName, string nickName, string Gender, string dateOfBirth, string isAgeSecret, string anniversaryDate, string mobileNo, string newPassword, int HintQuestion, string newHintQuestion, string answer, string address, int Country, int State, int City, string pinCode)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });

            UserDetails objUser = BindUserDetails();

            string virtualFilePath = objUser.UserPhoto;
            string serverFilePath = string.Empty;

            if (profilePhoto != null)
            {
                string fileType = profilePhoto.ContentType;

                if (fileType == "image/jpg" || fileType == "image/jpeg" || fileType == "image/gif" || fileType == "image/png" || fileType == "image/bmp")
                {
                    int fileSize = profilePhoto.ContentLength;
                    if (fileSize <= 512000)
                    {
                        string serverFoldepath = Server.MapPath("../../Images/UserPhotos\\");
                        if (!Directory.Exists(serverFilePath))
                            Directory.CreateDirectory(serverFoldepath);

                        string fileName = Path.GetFileName(profilePhoto.FileName);

                        string primaryFileName = Path.GetFileNameWithoutExtension(fileName);
                        string fileExtensionName = Path.GetExtension(fileName);

                        //Generate New FileName
                        Random objRandom = new Random();
                        int num = objRandom.Next(999999999);
                        DateTime dt = DateTime.Now;
                        string newFileName = primaryFileName + num.ToString() + dt.Day.ToString() + dt.Month.ToString() + dt.Year.ToString() + dt.Second.ToString() + dt.Millisecond.ToString() + fileExtensionName;

                        serverFilePath = serverFoldepath + newFileName;

                        virtualFilePath = "../../Images/UserPhotos/" + newFileName;

                    }
                    else
                    {
                        ViewBag.FileUploadError = "Please upload max 500 kb size file only";
                        return View(objUser);
                    }
                }
                else
                {
                    ViewBag.FileUploadError = "Please upload Image file only";
                    return View(objUser);
                }
            }
            bool ageSecret;
            if (isAgeSecret == "on")
                ageSecret = true;
            else
                ageSecret = false;

            if (!string.IsNullOrEmpty(newPassword))
                newPassword = Utility.Encrypt(newPassword, "ER");

            dbUserEntities.SP_UpdateUserProfile(Convert.ToInt32(Session["UserId"]), newPassword, HintQuestion, newHintQuestion, answer, firstName, middleName, lastName, nickName, dateOfBirth, anniversaryDate, Gender, ageSecret, mobileNo, virtualFilePath, address, Country, State, City, pinCode);

            if (profilePhoto != null)
            {
                string oldFilePath = Server.MapPath(objUser.UserPhoto);

                if (System.IO.File.Exists(oldFilePath))
                    System.IO.File.Delete(oldFilePath);

                profilePhoto.SaveAs(serverFilePath);
            }
            ViewBag.Status = "User Profile has Updated successfully!!!";

            return View(BindUserDetails());
        }

        public ActionResult MyReminders()
        {

            //////////////////////////////
            //Session["ToPage"] = "MyReminders";
            ///////////////////////////////

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });


            List<GetBirthdayDetailsByUserId> objBirthdayDetails = dbUserEntities.SP_GetBirthdayDetailsByUserId(Convert.ToInt32(Session["UserId"])).ToList();

            ViewBag.BirthdayEvents = objBirthdayDetails;

            return View();
        }

        [HttpPost]
        public ActionResult SendBirthdayMail(string toMail, string fromMail, string subject, string message, HttpPostedFileBase[] fileAttach)
        {
            Utility.SendEmail(Session["FirstName"].ToString(), subject, toMail, message, false, fileAttach);

            TempData["MailSuccess"] = "Your birthday wishes has been sent successfully!!!";

            return RedirectToAction("MyReminders");
        }

        private UserDetails BindUserDetails()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            UserDetails objUser = dbUserEntities.SP_GetUserDetails(userId).ToList().FirstOrDefault();
            List<BindHintQuestion> HintQuesList = dbUserEntities.SP_BindHintQuestion().ToList();

            HintQuesList.Add(new BindHintQuestion() { HintQuestion = "other", HintQuestionId = 1, IsActive = true });

            HintQuesList.Insert(0, new BindHintQuestion() { HintQuestion = "select", HintQuestionId = 0, IsActive = true });

            ViewBag.HintQuestionList = new SelectList(HintQuesList, "HintQuestionId", "HintQuestion", objUser.HintQuestionId);

            //Bind Country
            List<BindCountry> CountryList = dbUserEntities.SP_BindCountry().ToList();

            CountryList.Insert(0, new BindCountry() { CountryName = "Select", CountryId = 0, IsActive = true });

            ViewBag.CountryList = new SelectList(CountryList, "CountryId", "CountryName", objUser.CountryId);

            //Bind State
            List<BindState> StateList = dbUserEntities.SP_BindState(objUser.CountryId).ToList();

            StateList.Insert(0, new BindState() { StateName = "Select", StateId = 0, IsActive = true });

            ViewBag.StateList = new SelectList(StateList, "StateId", "StateName", objUser.StateId);

            //Bind City
            List<BindCity> CityList = dbUserEntities.SP_BindCity(objUser.StateId).ToList();

            CityList.Insert(0, new BindCity() { CityName = "Select", CityId = 0, IsActive = true });

            ViewBag.CityList = new SelectList(CityList, "CityId", "CityName", objUser.CityId);

            if (objUser.Gender == "M")
            {
                if (string.IsNullOrEmpty(objUser.UserPhoto))
                    objUser.UserPhoto = "../../Images/UserNoImage1.png";
            }
            else if (objUser.Gender == "F")
            {
                if (string.IsNullOrEmpty(objUser.UserPhoto))
                    objUser.UserPhoto = "../../Images/UserNoImage2.png";
            }

            return objUser;
        }


        public JsonResult GetStates(string countryId)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            List<BindState> stateList = dbUserEntities.SP_BindState(int.Parse(countryId)).ToList();
            states.Add(new SelectListItem() { Text = "Select", Value = "0" });
            foreach (BindState state in stateList)
            {
                states.Add(new SelectListItem() { Text = state.StateName, Value = state.StateId.ToString() });
            }

            return Json(new SelectList(states, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetCities(string stateId)
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            List<BindCity> cityList = dbUserEntities.SP_BindCity(int.Parse(stateId)).ToList();
            cities.Add(new SelectListItem() { Text = "Select", Value = "0" });
            foreach (BindCity city in cityList)
            {
                cities.Add(new SelectListItem() { Text = city.CityName, Value = city.CityId.ToString() });
            }

            return Json(new SelectList(cities, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult BirthdayRequester()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BirthdayRequester(string toMails, string emailSubject)
        {
            string message = "I'm organizing my freinds and family's birthdays." + "<br /><br />" + "Please do me a favor and enter your birthday by clicking on:" + "<br />" + "<a href='http://localhost:1784/Home/BirthdayDate?id=" + Session["UserId"].ToString() + "&nm=" + Session["FirstName"].ToString() + "' target='_blank'>http://localhost:1784/Home/BirthdayDate?id=" + Session["UserId"].ToString() + "&nm=" + Session["FirstName"].ToString() + "</a>" + "<br /><br />" + "It only takes a minute." + "<br /><br />" + "Thanks!<br />" + Session["FirstName"].ToString();

            Utility.SendEmail(Session["FirstName"].ToString(), emailSubject, toMails, message, true, null);

            TempData["ToMails"] = toMails;

            return RedirectToAction("BirthdayRequesterStatus");
        }

        public ActionResult BirthdayRequesterStatus()
        {
            return View();
        }

        public ActionResult BirthdayReminderSetup(int id)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });

            TempData["BirthdayDetailsId"] = id;

            GetBirthdayDetailsById birthdayDetails = dbUserEntities.SP_GetBirthdayDetailsById(id).SingleOrDefault();

            ViewBag.Name = birthdayDetails.FirstName;
            ViewBag.DateOfBirth = birthdayDetails.DateOfBirth;

            GetBirthdayReminder birthdayReminder = dbUserEntities.SP_GetBirthdayReminder(id, Convert.ToInt32(Session["UserId"])).SingleOrDefault();

            if (birthdayReminder != null)
            {
                TempData["BirthdayReminderId"] = birthdayReminder.BirthdayReminderId;
                ViewBag.Reminder = "Update";
            }
            else
            {
                ViewBag.Reminder = "Add";
                birthdayReminder = new GetBirthdayReminder();
            }
            return View(birthdayReminder);
        }

        [HttpPost]
        public ActionResult BirthdayReminderSetup(string chkDays30, string chkDays14, string chkDays7, string chkDays3, string chkDays0, string SubmitButton)
        {
            bool[] chkDays = new bool[5] { false, false, false, false, false };

            if (chkDays30 == "30")
                chkDays[0] = true;
            if (chkDays14 == "14")
                chkDays[1] = true;
            if (chkDays7 == "7")
                chkDays[2] = true;
            if (chkDays3 == "3")
                chkDays[3] = true;
            if (chkDays0 == "0")
                chkDays[4] = true;

            if(SubmitButton=="Add")
            {
                tblBirthdayReminder objBirthdayReminder = new tblBirthdayReminder()
                {
                    UserId = Convert.ToInt32(Session["UserId"]),
                    BirthdayDetailsId = Convert.ToInt32(TempData["BirthdayDetailsId"]),
                    C30DaysBefore = chkDays[0],
                    C14DaysBefore = chkDays[1],
                    C7DaysBefore = chkDays[2],
                    C3DaysBefore = chkDays[3],
                    DayOfEvent = chkDays[4]
                };
                dbUserEntities.tblBirthdayReminders.Add(objBirthdayReminder);
                dbUserEntities.SaveChanges();
            }
            else if(SubmitButton == "Update")
            {
                tblBirthdayReminder objBirthdayReminder = dbUserEntities.tblBirthdayReminders.Find(Convert.ToInt32(TempData["BirthdayReminderId"]));

                objBirthdayReminder.C30DaysBefore = chkDays[0];
                objBirthdayReminder.C14DaysBefore = chkDays[1];
                objBirthdayReminder.C7DaysBefore = chkDays[2];
                objBirthdayReminder.C3DaysBefore = chkDays[3];
                objBirthdayReminder.DayOfEvent = chkDays[4];
                dbUserEntities.SaveChanges();
            }
            return RedirectToAction("MyReminders");
        }

        public ActionResult GetRelationship()
        {

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home", new { area = "" });

            List<tblRelationshipUser> Relationships = new List<tblRelationshipUser>();

            foreach (tblRelationshipUser relashinship in dbUserEntities.tblRelationshipUsers.ToList())
            {
                Relationships.Add(new tblRelationshipUser() { RelationshipId = relashinship.RelationshipId, RelationshipName = relashinship.RelationshipName, IsActive = relashinship.IsActive });

            }
            //List<BindRelationship> RelationshipList = dbUserEntities.SP_BindRelationship().ToList();

            //foreach (BindRelationship relationship in RelationshipList)
            //{
            //    Relationships.Add(new SelectListItem() { Text = relationship.RelationshipName, Value = relationship.RelationshipId.ToString(), IsActive = relationship.IsActive});
            //}
            //List<BindRelationship> countryList = new List<tblCountry>();

            //foreach (tblCountry country in dbEntities.tblCountrys.ToList())
            //{
            //    countryList.Add(new tblCountry() { CountryId = country.CountryId, CountryName = country.CountryName, IsActive = country.IsActive });

            //}s
            ViewBag.Relationships = Relationships;

            return Json(Relationships, JsonRequestBehavior.AllowGet);
        }

        //public int UpdateRelationshipDetails(string eventDate, string firstName, string lastName, string nickName, string gender, string relationship, string email, string birthdayDetailsId)
        //{
        //    tblBirthdayDetail birthdayDetail = dbUserEntities.tblBirthdayDetails.Find(int.Parse(birthdayDetailsId));

        //    birthdayDetail.DateOfBirth = eventDate;
        //    birthdayDetail.FirstName = Convert.ToBoolean(IsActive);
        //    birthdayDetail.LastName = eventDate;
        //    birthdayDetail.NickName = eventDate;
        //    birthdayDetail.Gender = eventDate;
        //    birthdayDetail.rela = eventDate;


        //    tblBirthdayDetail birthdayDetail = dbUserEntities.tblBirthdayDetails.Find(int.Parse(birthdayDetailsId));

        //    return dbUserEntities.SaveChanges();
        //}

        //public ActionResult BirthdayProfilSetup(int id)
        //{
        //    if (Session["UserId"] == null)
        //        return RedirectToAction("Login", "Home", new Area )
        //}

        //[HttpPost]
        //public ActionResult BirthdayProfilSetup()
        //{

        //}
    }
}