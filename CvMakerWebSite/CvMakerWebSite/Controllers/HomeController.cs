using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMakerWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login (string email, string password)
        {

            List<tblUserAccountDetail> objUserAccount = dbEntities.SP_CheckUserLogin(email, Utility.Encrypt(password, "ER")).ToList();

            if (objUserAccount.Count > 0)
            {
                if (dbEntities.SP_CheckUserAccountStatus(email, 1).FirstOrDefault().Value > 0)
                {
                    ViewBag.Status = "Please check your mail to activate the account!!!";
                    ViewBag.Activation = 1;
                    TempData["Email"] = email;
                    return View();
                }
                if (dbEntities.SP_CheckUserAccountStatus(email, 2).FirstOrDefault().Value > 0)
                {
                    ViewBag.Status = "Your Account has been cancelled. Please contact to Administration!!!";
                    return View();
                }

                Session["UserId"] = objUserAccount[0].UserId;

                Session["FirstName"] = objUserAccount[0].tblUserPersonalDetails.FirstOrDefault().FirstName;

                Session["EmailId"] = objUserAccount[0].EmailId;

                string lastAccessedDateTime = objUserAccount[0].LastAccessDateTime.ToString();

                DateTime currentAccessedDateTime = DateTime.Now;

                if (string.IsNullOrEmpty(lastAccessedDateTime))
                {
                    Session["LastAccessedDateTime"] = currentAccessedDateTime.ToString();
                }
                else
                {
                    Session["LastAccessedDateTime"] = lastAccessedDateTime;
                }

                tblUserAccountDetail objUserAccountDetail = dbEntities.tblUserAccountDetails.Find(objUserAccount[0].UserId);
                objUserAccountDetail.LastAccessDateTime = currentAccessedDateTime;

                dbEntities.SaveChanges();
                ////////////
                //string s = Session["ToPage"].ToString();
                //if (Session["ToPage"] == "MyReminders")

                //    return RedirectToAction(s, "Home", new { area = "User" });
                ///////////////

                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            else
            {
                ViewBag.Status = "Invalid Email Address or Password";
            }
            return View(); 
        }

        //
        [HttpPost]
        public ActionResult ActivationMail()
        {
            string email = TempData["Email"].ToString();

            string message = string.Empty;

            message += "<table style='width:700px;border:10px outset blue;border-radius:30px'>";

            message += "<tr><td><img src='http://webkul.com/blog/wp-content/uploads/2015/12/Event-Reminder-App-Banner-Blog-Banner-Image.png' width='700' alt='Event-Reminder Logo' /></td></tr>";

            message += "<tr style='background-color:yellow;color:green'><td><b>Dear Member," + "</br ></ br > thank you for registration for us.</br ></ br > please click following link bellow to Activate your account in-order to use our website services:</br ></ br >";

            message += "<a href='http://localhost:1784/Home/Activation?eml=" + email + "' target='_blank'>http://localhost:1784/Home/Activation?eml=" + email + "</a><br /><br />";

            message += "<b>Thanks & Best Regards,</b><br />Event - Reminder<br />Managment Team<br />Hyerabad India</td></tr></table>";

            Utility.SendEmail("Event-Reminder: Activation Mail", email, message, true);

            TempData["SendActivationMail"] = 1;

            return RedirectToAction("Login");
        }

        //
        public ActionResult Activation()
        {
            if (Request.QueryString["eml"] == null)
                return RedirectToAction("Index");

            string email = Request.QueryString["eml"];

            if (dbEntities.SP_UserApproval(email) > 0)
            {
                ViewBag.Status = 1;
            }
            else
            {
                ViewBag.Status = 0;
            }
            return View();
        }

        //
        public JsonResult CheckEmailAvailability(string email)
        {
            return Json(dbEntities.SP_CheckEmailAvailibility(email), JsonRequestBehavior.AllowGet);
        }

        //
        public JsonResult GetHintQuestion(string email)
        {
            SP_GetHintQuestion_Result objHintQuestionResult = dbEntities.SP_GetHintQuestion(email).FirstOrDefault();

            string hintQuestion = string.Empty;
            if (objHintQuestionResult != null)
            {
                if (!string.IsNullOrEmpty(objHintQuestionResult.HintQuestion))
                {
                    hintQuestion = objHintQuestionResult.HintQuestion;
                }
                else if (!string.IsNullOrEmpty(objHintQuestionResult.NewHintQuestion))
                {
                    hintQuestion = objHintQuestionResult.NewHintQuestion;

                }
            }
            return Json(hintQuestion, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SendForgetPassword(string email, string answer)
        {
            int userCount = dbEntities.SP_CheckUserByEmailAnswer(email, answer).SingleOrDefault().Value;
            int Status = 0;
            if (userCount > 0)
            {
                //Generate New Random Password
                Random objRandom = new Random();
                int num = objRandom.Next(999999999);
                DateTime dt = DateTime.Now;
                string password = num.ToString() + dt.Day.ToString() + dt.Month.ToString() + dt.Year.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
                //Update Generated Password into Database
                dbEntities.SP_UpdatPasswordByEmail(email, Utility.Encrypt(password, "ER"));

                //Send Generated Password By Email

                string message = string.Empty;

                message += "<table style='width:700px;border:10px outset blue;border-radius:30px'>";

                message += "<tr><td><img src='http://webkul.com/blog/wp-content/uploads/2015/12/Event-Reminder-App-Banner-Blog-Banner-Image.png' width='700' alt='Event-Reminder Logo' /></td></tr>";

                message += "<tr style='background-color:yellow;color:green'><td><b>Dear Member," + "<br /><br />";

                message += "Your New Password Is: " + password + "<br />< br />";

                message += "<b>Thanks & Best Regards,</b><br />Event - Reminder<br />Managment Team<br />Hyerabad India</td></tr></table>";

                Utility.SendEmail("Event-Reminder: Forgot Password", email, message, true);

                Status = 1;

            }
            else
            {
                Status = 0;
            }
            return Json(Status, JsonRequestBehavior.AllowGet);
        }
    }
}