using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CvMakerWebsiteApp.Common;
using System.Data.Entity;
using CvMakerWebsiteApp.Models;
using System.IO;

namespace CvMakerWebsiteApp.Controllers
{
    public class HomeController : Controller
    {
        CvMakerDBEntities1 dbEntities = new CvMakerDBEntities1();

        public JsonResult CheckEmailAvailability(string email)
        {
            return Json(dbEntities.SP_CheckEmailAvailibility(email), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendForgetPassword(string email)
        {
            int userCount = dbEntities.SP_CheckUserByEmailAnswer(email).SingleOrDefault().Value;
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

                message += "<tr><td><img src='https://cdn.themix.org.uk/uploads/2018/07/shutterstock_229059250.jpg' width='700' alt='Cv-Maker Logo' /></td></tr>";

                message += "<tr style='background-color:yellow;color:green'><td><b>Dear Member," + "<br /><br />";

                message += "Your New Password Is: " + password + "<br /><br />";

                message += "<b>Thanks & Best Regards,</b><br />CV - Maker<br />Managment Team<br />^_^</td></tr></table>";

                Utility.SendEmail("Cv Maker: Forgot Password", email, message, true);

                Status = 1;

            }
            else
            {
                Status = 0;
            }
            return Json(Status, JsonRequestBehavior.AllowGet);
        }



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

        public ActionResult Registration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Registration(string name, string email, string pass, string repeatpass, string rememberme)
        {

            if (dbEntities.SP_UserRegistration(email, Utility.Encrypt(pass, "ER"), DateTime.Now, false, name) > 0)
            {
                //write code To send Email for Activation Account
                //Send the Mail Activation
                TempData["Email"] = email;
                ActivationMail();

                ViewBag.Status = 1;
            }
            else
            {
                ViewBag.Status = 0;
            }
            return View();
        }

        [HttpPost]
        public ActionResult ActivationMail()
        {
            string email = TempData["email"].ToString();

            string message = string.Empty;

            message += "<table style='width:700px;border:10px outset blue;border-radius:30px'>";

            message += "<tr><td><img src='https://cdn.themix.org.uk/uploads/2018/07/shutterstock_229059250.jpg' width='700' alt='Cv-Maker Logo' /></td></tr>";

            message += "<tr style='background-color:yellow;color:green'><td><b>Dear Member," + "</br ></ br > thank you for registration for us.</br ></ br > please click following link bellow to Activate your account in-order to use our website services:</br ></ br >";

            message += "<a href='http://belal0khanjar-001-site1.gtempurl.com//Home/Activation?eml=" + email + "' target='_blank'>http://belal0khanjar-001-site1.gtempurl.com/Home/Activation?eml=" + email + "</a><br /><br />";

            message += "<b>Thanks & Best Regards,</b><br />Cv - Maker<br />Managment Team<br />^_^</td></tr></table>";

            Utility.SendEmail("Cv Maker: Activation Mail", email, message, true);

            TempData["SendActivationMail"] = 1;

            return RedirectToAction("login");
        }

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


        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string email, string pass)
        {
            List<tblUserAccountDetail> objUserAccount = dbEntities.SP_CheckUserLogin(email, Utility.Encrypt(pass, "ER")).ToList();

            if (objUserAccount.Count > 0)
            {
                if (dbEntities.SP_CheckUserAccountStatus(email, 1).FirstOrDefault().Value > 0)
                {
                    ViewBag.Status = "Please check your mail to activate the account!!!";
                    ViewBag.Activation = 1;
                    TempData["Email"] = email;
                    return View();
                }
                //if (dbEntities.SP_CheckUserAccountStatus(email, 2).FirstOrDefault().Value > 0)
                //{
                //    ViewBag.Status = "Your Account has been cancelled. Please contact to Administration!!!";
                //    return View();
                //}

                Session["UserId"] = objUserAccount[0].UserId;

                Session["FirstName"] = objUserAccount[0].FullName;

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

                return RedirectToAction("CvUserHome", "Home");
            }
            else
            {
                ViewBag.Status = "Invalid Email Address or Password";
            }
            return View();
        }

        public ActionResult CvMaker()
        {
            return View();
        }

        public ActionResult CvUserHome()
        {

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home");


            List<SP_GetCvUserDetailsByUserId_Result1> objCvUserDetails = dbEntities.SP_GetCvUserDetailsByUserId(Convert.ToInt32(Session["UserId"])).ToList();

            ViewBag.CvDetails = objCvUserDetails;

            return View();
        }

        [HttpPost]
        public ActionResult CvUserHome(string cvId123)
        {
            Session["CvId"] = Convert.ToInt32(cvId123.Trim());
            //TempData["CvId"] = Convert.ToInt32(cvId123.Trim());


            return RedirectToAction("CvUserEditCv", "Home");
        }

        public ActionResult CvUserEditCv()
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
                return RedirectToAction("Login", "Home");

            //Session["CvId"] = Session["CvId"];
            //Session["UserId"] = Session["UserId"];
            //Console.WriteLine(Session["CvId"]);
            //Console.WriteLine(Session["UserId"]);


            List<SP_GetSingleCvDetailsByUserIdAndCvId_Result> objListCvDetails = dbEntities.SP_GetSingleCvDetailsByUserIdAndCvId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CvId"])).ToList();

            //foreach (SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails in objListCvDetails)
            //{
            //    Relationships.Add(new SelectListItem() { Text = relationship.RelationshipName, Value = relationship.RelationshipId.ToString() });
            //}
            SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails = objListCvDetails[0];

            ViewBag.CvDetails = objSingleCvDetails;

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];
            ViewBag.CvbasicInfoDetails = objSinglebasicInfo;

            //To aler if needed List
            List<SP_GetCvEducationDetailsByCvId_Result> objListEducationDetails = dbEntities.SP_GetCvEducationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            //SP_GetCvEducationDetailsByCvId_Result objSingleEducationInfo = objListEducationDetails[0];
            //ViewBag.CvEducationInfoDetails = objSingleEducationInfo;
            ViewBag.CvEducationInfoDetails = objListEducationDetails;

            List<SP_GetCvInterestDetailsByCvId_Result> objListInterestInformationDetails = dbEntities.SP_GetCvInterestDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvInterestDetailsByCvId_Result objSingInterestInfo = objListInterestInformationDetails[0];
            ViewBag.CvInterestInfoDetails = objSingInterestInfo;

            List<SP_GetCvObjectiveDetailsByCvId_Result> objListObjectiveDetails = dbEntities.SP_GetCvObjectiveDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvObjectiveDetailsByCvId_Result objSingleObjectiveInfo = objListObjectiveDetails[0];
            ViewBag.CvObjectiveInfoDetails = objSingleObjectiveInfo;

            List<SP_GetCvQualificationDetailsByCvId_Result> objListQualificationDetails = dbEntities.SP_GetCvQualificationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvQualificationDetailsByCvId_Result objSingleQualificationInfo = objListQualificationDetails[0];
            ViewBag.CvQualificationInfoDetails = objSingleQualificationInfo;

            List<SP_GetCvReferencesDetailsByCvId_Result> objListReferencesDetails = dbEntities.SP_GetCvReferencesDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvReferencesDetailsByCvId_Result objSingleReferencesInfo = objListReferencesDetails[0];
            ViewBag.CvReferencesInfoDetails = objSingleReferencesInfo;

            //To aler if needed List
            List<SP_GetCvWorkExperienceDetailsByCvId_Result> objListWorkExperienceDetails = dbEntities.SP_GetCvWorkExperienceDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            //SP_GetCvWorkExperienceDetailsByCvId_Result objSingleWorkExperienceInfo = objListWorkExperienceDetails[0];
            //ViewBag.CvWorkExperienceInfoDetails = objSingleWorkExperienceInfo;
            ViewBag.CvWorkExperienceInfoDetails = objListWorkExperienceDetails;

            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }


        public int AddNewCv(string cvName, string cvIndustry, string cvLang)
        {
            tblUserCvDetail model = new tblUserCvDetail();

            // if (Session["UserId"] == null)
            //return RedirectToAction("Login", "Home");

            model.UserId = Convert.ToInt32(Session["UserId"]);
            model.CvName = cvName;
            model.Language = cvLang;
            model.Industry = cvIndustry;

            DateTime currentAccessedDateTime = DateTime.Now;
            model.LastModificationDateTime = currentAccessedDateTime;
            dbEntities.tblUserCvDetails.Add(model);
            //dbEntities.Entry(model).GetDatabaseValues();

            dbEntities.SaveChanges();

            //Session["CvId"] = model.CvId;
            int CvId = model.CvId;

            tblCvBasicInformation modelBasicInfo = new tblCvBasicInformation();
            modelBasicInfo.CvId = CvId;
            dbEntities.tblCvBasicInformations.Add(modelBasicInfo);

            tblEducationDetail modelEdu = new tblEducationDetail();
            modelEdu.CvId = CvId;
            dbEntities.tblEducationDetails.Add(modelEdu);

            tblInterestDetail modelInterest = new tblInterestDetail();
            modelInterest.CvId = CvId;
            dbEntities.tblInterestDetails.Add(modelInterest);

            tblObjective modelObjective = new tblObjective();
            modelObjective.CvId = CvId;
            dbEntities.tblObjectives.Add(modelObjective);

            tblQualification modelQualification = new tblQualification();
            modelQualification.CvId = CvId;
            dbEntities.tblQualifications.Add(modelQualification);

            tblReferencesDetail modelReferences = new tblReferencesDetail();
            modelReferences.Cvid = CvId;
            dbEntities.tblReferencesDetails.Add(modelReferences);

            tblWorkExperienceDetail modelExperience = new tblWorkExperienceDetail();
            modelExperience.CvId = CvId;
            dbEntities.tblWorkExperienceDetails.Add(modelExperience);

            return dbEntities.SaveChanges(); ;

        }

        public int AddNewEduDetails()
        {
            tblEducationDetail model = new tblEducationDetail();

            //if (Session["UserId"] == null || Session["CvId"] == null)
            //    return RedirectToAction("Login", "Home");

            model.CvId = Convert.ToInt32(Session["CvId"]);

            dbEntities.tblEducationDetails.Add(model);

            return dbEntities.SaveChanges();

        }


        public int DeleteEduDetail(string eduId)
        {
            tblEducationDetail eduDetail = dbEntities.tblEducationDetails.Find(int.Parse(eduId));
        
            dbEntities.tblEducationDetails.Remove(eduDetail);
            return dbEntities.SaveChanges();
        }

        public int DeleteWorkDetail(string workExperienceId)
        {
            tblWorkExperienceDetail workDetail = dbEntities.tblWorkExperienceDetails.Find(int.Parse(workExperienceId));
        
            dbEntities.tblWorkExperienceDetails.Remove(workDetail);
            return dbEntities.SaveChanges();
        }



        public int AddNewWorkDetails()
        {
            tblWorkExperienceDetail model = new tblWorkExperienceDetail();

            //if (Session["UserId"] == null || Session["CvId"] == null)
            //    return RedirectToAction("Login", "Home");

            model.CvId = Convert.ToInt32(Session["CvId"]);

            dbEntities.tblWorkExperienceDetails.Add(model);

            return dbEntities.SaveChanges();

        }

        //public int AddNewObjective()
        //{
        //    tblWorkExperienceDetail model = new tblWorkExperienceDetail();

        //    //if (Session["UserId"] == null || Session["CvId"] == null)
        //    //    return RedirectToAction("Login", "Home");

        //    model.CvId = Convert.ToInt32(Session["CvId"]);

        //    dbEntities.tblWorkExperienceDetails.Add(model);

        //    return dbEntities.SaveChanges();

        //}

            public int EditCv(string cvIdEdit, string cvNameEdit, string cvIndustryEdit, string cvLangEdit)
        {
            tblUserCvDetail model = dbEntities.tblUserCvDetails.Find(int.Parse(cvIdEdit));

            // if (Session["UserId"] == null)
            //return RedirectToAction("Login", "Home");

            model.CvName = cvNameEdit;
            model.Language = cvIndustryEdit;
            model.Industry = cvLangEdit;

            DateTime currentAccessedDateTime = DateTime.Now;
            model.LastModificationDateTime = currentAccessedDateTime;



            return dbEntities.SaveChanges();

        }

        public int DeleteCv(string cvId)
        {
            tblUserCvDetail cvDetail = dbEntities.tblUserCvDetails.Find(int.Parse(cvId));
            dbEntities.SP_DeleteCvBasicInformationByCvId(int.Parse(cvId));
            dbEntities.SP_DeleteCvEducationDetailsByCvId(int.Parse(cvId));
            dbEntities.SP_DeleteCvInterestDetailsByCvId(int.Parse(cvId));
            dbEntities.SP_DeleteCvObjectiveDetailsByCvId(int.Parse(cvId));
            dbEntities.SP_DeleteCvQualificationsDetailsByCvId(int.Parse(cvId));
            dbEntities.SP_DeleteCvReferencesDetailsByCvId(int.Parse(cvId));
            dbEntities.SP_DeleteCvWorkExperienceDetailsByCvId(int.Parse(cvId));

            dbEntities.SaveChanges();
            dbEntities.tblUserCvDetails.Remove(cvDetail);
            return dbEntities.SaveChanges();
        }

        public ActionResult Testview()
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
                return RedirectToAction("Login", "Home");

            List<SP_GetSingleCvDetailsByUserIdAndCvId_Result> objListCvDetails = dbEntities.SP_GetSingleCvDetailsByUserIdAndCvId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CvId"])).ToList();

            //foreach (SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails in objListCvDetails)
            //{
            //    Relationships.Add(new SelectListItem() { Text = relationship.RelationshipName, Value = relationship.RelationshipId.ToString() });
            //}
            SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails = objListCvDetails[0];

            ViewBag.CvDetails = objSingleCvDetails;

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];
            ViewBag.CvbasicInfoDetails = objSinglebasicInfo;

            //To aler if needed List
            List<SP_GetCvEducationDetailsByCvId_Result> objListEducationDetails = dbEntities.SP_GetCvEducationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            ViewBag.CvEducationInfoDetails = objListEducationDetails;

            List<SP_GetCvInterestDetailsByCvId_Result> objListInterestInformationDetails = dbEntities.SP_GetCvInterestDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvInterestDetailsByCvId_Result objSingInterestInfo = objListInterestInformationDetails[0];
            ViewBag.CvInterestInfoDetails = objSingInterestInfo;

            List<SP_GetCvObjectiveDetailsByCvId_Result> objListObjectiveDetails = dbEntities.SP_GetCvObjectiveDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvObjectiveDetailsByCvId_Result objSingleObjectiveInfo = objListObjectiveDetails[0];
            ViewBag.CvObjectiveInfoDetails = objSingleObjectiveInfo;

            List<SP_GetCvQualificationDetailsByCvId_Result> objListQualificationDetails = dbEntities.SP_GetCvQualificationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvQualificationDetailsByCvId_Result objSingleQualificationInfo = objListQualificationDetails[0];
            ViewBag.CvQualificationInfoDetails = objSingleQualificationInfo;

            List<SP_GetCvReferencesDetailsByCvId_Result> objListReferencesDetails = dbEntities.SP_GetCvReferencesDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvReferencesDetailsByCvId_Result objSingleReferencesInfo = objListReferencesDetails[0];
            ViewBag.CvReferencesInfoDetails = objSingleReferencesInfo;

            //To aler if needed List
            List<SP_GetCvWorkExperienceDetailsByCvId_Result> objListWorkExperienceDetails = dbEntities.SP_GetCvWorkExperienceDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            ViewBag.CvWorkExperienceInfoDetails = objListWorkExperienceDetails;

            return View();
        }

        public ActionResult Testview1()
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
                return RedirectToAction("Login", "Home");

            List<SP_GetSingleCvDetailsByUserIdAndCvId_Result> objListCvDetails = dbEntities.SP_GetSingleCvDetailsByUserIdAndCvId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CvId"])).ToList();

            //foreach (SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails in objListCvDetails)
            //{
            //    Relationships.Add(new SelectListItem() { Text = relationship.RelationshipName, Value = relationship.RelationshipId.ToString() });
            //}
            SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails = objListCvDetails[0];

            ViewBag.CvDetails = objSingleCvDetails;

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];
            ViewBag.CvbasicInfoDetails = objSinglebasicInfo;

            //To aler if needed List
            List<SP_GetCvEducationDetailsByCvId_Result> objListEducationDetails = dbEntities.SP_GetCvEducationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            
            ViewBag.CvEducationInfoDetails = objListEducationDetails;

            List<SP_GetCvInterestDetailsByCvId_Result> objListInterestInformationDetails = dbEntities.SP_GetCvInterestDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvInterestDetailsByCvId_Result objSingInterestInfo = objListInterestInformationDetails[0];
            ViewBag.CvInterestInfoDetails = objSingInterestInfo;

            List<SP_GetCvObjectiveDetailsByCvId_Result> objListObjectiveDetails = dbEntities.SP_GetCvObjectiveDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvObjectiveDetailsByCvId_Result objSingleObjectiveInfo = objListObjectiveDetails[0];
            ViewBag.CvObjectiveInfoDetails = objSingleObjectiveInfo;

            List<SP_GetCvQualificationDetailsByCvId_Result> objListQualificationDetails = dbEntities.SP_GetCvQualificationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvQualificationDetailsByCvId_Result objSingleQualificationInfo = objListQualificationDetails[0];
            ViewBag.CvQualificationInfoDetails = objSingleQualificationInfo;

            List<SP_GetCvReferencesDetailsByCvId_Result> objListReferencesDetails = dbEntities.SP_GetCvReferencesDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvReferencesDetailsByCvId_Result objSingleReferencesInfo = objListReferencesDetails[0];
            ViewBag.CvReferencesInfoDetails = objSingleReferencesInfo;

            //To aler if needed List
            List<SP_GetCvWorkExperienceDetailsByCvId_Result> objListWorkExperienceDetails = dbEntities.SP_GetCvWorkExperienceDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            
            ViewBag.CvWorkExperienceInfoDetails = objListWorkExperienceDetails;

            return View();
        }

        public ActionResult Testview2()
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
                return RedirectToAction("Login", "Home");

            List<SP_GetSingleCvDetailsByUserIdAndCvId_Result> objListCvDetails = dbEntities.SP_GetSingleCvDetailsByUserIdAndCvId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CvId"])).ToList();

            //foreach (SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails in objListCvDetails)
            //{
            //    Relationships.Add(new SelectListItem() { Text = relationship.RelationshipName, Value = relationship.RelationshipId.ToString() });
            //}
            SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails = objListCvDetails[0];

            ViewBag.CvDetails = objSingleCvDetails;

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];
            ViewBag.CvbasicInfoDetails = objSinglebasicInfo;

            //To aler if needed List
            List<SP_GetCvEducationDetailsByCvId_Result> objListEducationDetails = dbEntities.SP_GetCvEducationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();


            ViewBag.CvEducationInfoDetails = objListEducationDetails;

            List<SP_GetCvInterestDetailsByCvId_Result> objListInterestInformationDetails = dbEntities.SP_GetCvInterestDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvInterestDetailsByCvId_Result objSingInterestInfo = objListInterestInformationDetails[0];
            ViewBag.CvInterestInfoDetails = objSingInterestInfo;

            List<SP_GetCvObjectiveDetailsByCvId_Result> objListObjectiveDetails = dbEntities.SP_GetCvObjectiveDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvObjectiveDetailsByCvId_Result objSingleObjectiveInfo = objListObjectiveDetails[0];
            ViewBag.CvObjectiveInfoDetails = objSingleObjectiveInfo;

            List<SP_GetCvQualificationDetailsByCvId_Result> objListQualificationDetails = dbEntities.SP_GetCvQualificationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvQualificationDetailsByCvId_Result objSingleQualificationInfo = objListQualificationDetails[0];
            ViewBag.CvQualificationInfoDetails = objSingleQualificationInfo;

            List<SP_GetCvReferencesDetailsByCvId_Result> objListReferencesDetails = dbEntities.SP_GetCvReferencesDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvReferencesDetailsByCvId_Result objSingleReferencesInfo = objListReferencesDetails[0];
            ViewBag.CvReferencesInfoDetails = objSingleReferencesInfo;

            //To aler if needed List
            List<SP_GetCvWorkExperienceDetailsByCvId_Result> objListWorkExperienceDetails = dbEntities.SP_GetCvWorkExperienceDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();


            ViewBag.CvWorkExperienceInfoDetails = objListWorkExperienceDetails;

            return View();
        }

        public ActionResult Testview3()
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
                return RedirectToAction("Login", "Home");

            List<SP_GetSingleCvDetailsByUserIdAndCvId_Result> objListCvDetails = dbEntities.SP_GetSingleCvDetailsByUserIdAndCvId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CvId"])).ToList();

            //foreach (SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails in objListCvDetails)
            //{
            //    Relationships.Add(new SelectListItem() { Text = relationship.RelationshipName, Value = relationship.RelationshipId.ToString() });
            //}
            SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails = objListCvDetails[0];

            ViewBag.CvDetails = objSingleCvDetails;

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];
            ViewBag.CvbasicInfoDetails = objSinglebasicInfo;

            //To aler if needed List
            List<SP_GetCvEducationDetailsByCvId_Result> objListEducationDetails = dbEntities.SP_GetCvEducationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();


            ViewBag.CvEducationInfoDetails = objListEducationDetails;

            List<SP_GetCvInterestDetailsByCvId_Result> objListInterestInformationDetails = dbEntities.SP_GetCvInterestDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvInterestDetailsByCvId_Result objSingInterestInfo = objListInterestInformationDetails[0];
            ViewBag.CvInterestInfoDetails = objSingInterestInfo;

            List<SP_GetCvObjectiveDetailsByCvId_Result> objListObjectiveDetails = dbEntities.SP_GetCvObjectiveDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvObjectiveDetailsByCvId_Result objSingleObjectiveInfo = objListObjectiveDetails[0];
            ViewBag.CvObjectiveInfoDetails = objSingleObjectiveInfo;

            List<SP_GetCvQualificationDetailsByCvId_Result> objListQualificationDetails = dbEntities.SP_GetCvQualificationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvQualificationDetailsByCvId_Result objSingleQualificationInfo = objListQualificationDetails[0];
            ViewBag.CvQualificationInfoDetails = objSingleQualificationInfo;

            List<SP_GetCvReferencesDetailsByCvId_Result> objListReferencesDetails = dbEntities.SP_GetCvReferencesDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvReferencesDetailsByCvId_Result objSingleReferencesInfo = objListReferencesDetails[0];
            ViewBag.CvReferencesInfoDetails = objSingleReferencesInfo;

            //To aler if needed List
            List<SP_GetCvWorkExperienceDetailsByCvId_Result> objListWorkExperienceDetails = dbEntities.SP_GetCvWorkExperienceDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();


            ViewBag.CvWorkExperienceInfoDetails = objListWorkExperienceDetails;

            return View();
        }

        public ActionResult Testview4()
        {
            //if (Session["UserId"] == null || Session["CvId"] == null)
            //    return RedirectToAction("Login", "Home");

            //List<SP_GetSingleCvDetailsByUserIdAndCvId_Result> objListCvDetails = dbEntities.SP_GetSingleCvDetailsByUserIdAndCvId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["CvId"])).ToList();

            ////foreach (SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails in objListCvDetails)
            ////{
            ////    Relationships.Add(new SelectListItem() { Text = relationship.RelationshipName, Value = relationship.RelationshipId.ToString() });
            ////}
            //SP_GetSingleCvDetailsByUserIdAndCvId_Result objSingleCvDetails = objListCvDetails[0];

            //ViewBag.CvDetails = objSingleCvDetails;

            //List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            //SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];
            //ViewBag.CvbasicInfoDetails = objSinglebasicInfo;

            ////To aler if needed List
            //List<SP_GetCvEducationDetailsByCvId_Result> objListEducationDetails = dbEntities.SP_GetCvEducationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();


            //ViewBag.CvEducationInfoDetails = objListEducationDetails;

            //List<SP_GetCvInterestDetailsByCvId_Result> objListInterestInformationDetails = dbEntities.SP_GetCvInterestDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            //SP_GetCvInterestDetailsByCvId_Result objSingInterestInfo = objListInterestInformationDetails[0];
            //ViewBag.CvInterestInfoDetails = objSingInterestInfo;

            //List<SP_GetCvObjectiveDetailsByCvId_Result> objListObjectiveDetails = dbEntities.SP_GetCvObjectiveDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            //SP_GetCvObjectiveDetailsByCvId_Result objSingleObjectiveInfo = objListObjectiveDetails[0];
            //ViewBag.CvObjectiveInfoDetails = objSingleObjectiveInfo;

            //List<SP_GetCvQualificationDetailsByCvId_Result> objListQualificationDetails = dbEntities.SP_GetCvQualificationDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            //SP_GetCvQualificationDetailsByCvId_Result objSingleQualificationInfo = objListQualificationDetails[0];
            //ViewBag.CvQualificationInfoDetails = objSingleQualificationInfo;

            //List<SP_GetCvReferencesDetailsByCvId_Result> objListReferencesDetails = dbEntities.SP_GetCvReferencesDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            //SP_GetCvReferencesDetailsByCvId_Result objSingleReferencesInfo = objListReferencesDetails[0];
            //ViewBag.CvReferencesInfoDetails = objSingleReferencesInfo;

            ////To aler if needed List
            //List<SP_GetCvWorkExperienceDetailsByCvId_Result> objListWorkExperienceDetails = dbEntities.SP_GetCvWorkExperienceDetailsByCvId(Convert.ToInt32(Session["CvId"])).ToList();


            //ViewBag.CvWorkExperienceInfoDetails = objListWorkExperienceDetails;

            return View();
        }



        public int SavingCvId(string cvId)
        {
            Session["CvId"] = Convert.ToInt32(cvId);

            //if (session["cvid"] == null)
            //    return 0;
            //TempData["CvId"] = Convert.ToInt32(cvId);

            return 1;
        }

        public int UpdateCvDetails(string fullName,/* HttpPostedFileBase profilePhoto,*/ string emailId, string phoneNo, string website, string addline1, string addline2,/* string jobTitle, string companyName, string dateStartWork, string dateEndWork, string otherWorkInformation,*/ string qualificationText, string objectivesText, /*string CourseName, string institutionName, string dateStartEdu, string dateEndEdu, string otherEduInfo,*/ string interestsText, string referenceText)
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
                return 0;

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];
            


            

            //int k = dbEntities.SP_UpdateCvInformationWithoutPhoto(Convert.ToInt32(Session["CvId"]), fullName, emailId, phoneNo, website, addline1, addline2, jobTitle, companyName, dateStartWork, dateEndWork, otherWorkInformation, qualificationText, objectivesText, CourseName, institutionName, dateStartEdu, dateEndEdu, otherEduInfo, interestsText, referenceText);

            int k = dbEntities.SP_UpdateCvInformationWithoutPhotoAndWithoutEduAndWorkInfo(Convert.ToInt32(Session["CvId"]), fullName, emailId, phoneNo, website, addline1, addline2,  qualificationText, objectivesText,  interestsText, referenceText);

            //if (profilePhoto != null)
            //{
            //    string oldFilePath = Server.MapPath(objSinglebasicInfo.UserPhoto);

            //    if (System.IO.File.Exists(oldFilePath))
            //        System.IO.File.Delete(oldFilePath);

            //    profilePhoto.SaveAs(serverFilePath);
            //}

            dbEntities.SaveChanges();

            return k;
        }

        public ActionResult UpgradeToPremium()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult CvUserEditDetails(HttpPostedFileBase profilePhoto)
        //{
        //    if (Session["UserId"] == null || Session["CvId"] == null)
        //        return View();

        //    List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

        //    SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];


        //    string virtualFilePath = objSinglebasicInfo.UserPhoto;
        //    string serverFilePath = string.Empty;

        //    if (profilePhoto != null)
        //    {
        //        string fileType = profilePhoto.ContentType;

        //        if (fileType == "image/jpg" || fileType == "image/jpeg" || fileType == "image/gif" || fileType == "image/png" || fileType == "image/bmp")
        //        {
        //            int fileSize = profilePhoto.ContentLength;
        //            if (fileSize <= 512000)
        //            {
        //                string serverFoldepath = Server.MapPath("../../Images/UserPhotos\\");
        //                if (!Directory.Exists(serverFilePath))
        //                    Directory.CreateDirectory(serverFoldepath);

        //                string fileName = Path.GetFileName(profilePhoto.FileName);

        //                string primaryFileName = Path.GetFileNameWithoutExtension(fileName);
        //                string fileExtensionName = Path.GetExtension(fileName);

        //                //Generate New FileName
        //                Random objRandom = new Random();
        //                int num = objRandom.Next(999999999);
        //                DateTime dt = DateTime.Now;
        //                string newFileName = primaryFileName + num.ToString() + dt.Day.ToString() + dt.Month.ToString() + dt.Year.ToString() + dt.Second.ToString() + dt.Millisecond.ToString() + fileExtensionName;

        //                serverFilePath = serverFoldepath + newFileName;

        //                virtualFilePath = "../../Images/UserPhotos/" + newFileName;

        //            }
        //            else
        //            {
        //                ViewBag.FileUploadError = "Please upload max 500 kb size file only";
        //                return View(objSinglebasicInfo);
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.FileUploadError = "Please upload Image file only";
        //            return View(objSinglebasicInfo);
        //        }
        //    }

        //    if (profilePhoto != null)
        //    {
        //        string oldFilePath = Server.MapPath(objSinglebasicInfo.UserPhoto);

        //        if (System.IO.File.Exists(oldFilePath))
        //            System.IO.File.Delete(oldFilePath);

        //        profilePhoto.SaveAs(serverFilePath);
        //    }
        //    ViewBag.Status = "User Profile has Updated successfully!!!";

        //    return View();
        //}
        [HttpPost]
        public ActionResult CvUserEditCv(string fullName, HttpPostedFileBase profilePhoto, string emailId, string phoneNo, string website, string addline1, string addline2, string jobTitle, string companyName, string dateStartWork, string dateEndWork, string otherWorkInformation, string qualificationText, string objectivesText, string CourseName, string institutionName, string dateStartEdu, string dateEndEdu, string otherEduInfo, string interestsText, string referenceText)
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
                return RedirectToAction("Login", "Home");

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];



            string virtualFilePath = objSinglebasicInfo.UserPhoto;
            string serverFilePath = string.Empty;

            if (profilePhoto != null)
            {
                string fileType = profilePhoto.ContentType;

                if (fileType == "image/jpg" || fileType == "image/jpeg" || fileType == "image/gif" || fileType == "image/png" || fileType == "image/bmp")
                {
                    int fileSize = profilePhoto.ContentLength;
                    if (fileSize <= 512000)
                    {
                        //HttpContext.Current.Server.MapPath("/") + "\\emails\\template1.html";


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
                        return View(objSinglebasicInfo);
                    }
                }
                else
                {
                    ViewBag.FileUploadError = "Please upload Image file only";
                    return View(objSinglebasicInfo);
                }
            }

            dbEntities.SP_UpdateCvInformation(Convert.ToInt32(Session["CvId"]), fullName, virtualFilePath, emailId, phoneNo, website, addline1, addline2, jobTitle, companyName, dateStartWork, dateEndWork, otherWorkInformation, qualificationText, objectivesText, CourseName, institutionName, dateStartEdu, dateEndEdu, otherEduInfo, interestsText, referenceText);

            if (profilePhoto != null)
            {
                string oldFilePath = Server.MapPath(objSinglebasicInfo.UserPhoto);

                if (System.IO.File.Exists(oldFilePath))
                    System.IO.File.Delete(oldFilePath);

                profilePhoto.SaveAs(serverFilePath);
            }
            ViewBag.Status = "User Profile has Updated successfully!!!";

            return View();



        }

        //public JsonResult UploadPhoto1(PhotoModel model)
        //{
        //    if (model.ImageFile.File.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(picture.File.FileName);
        //        var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
        //        picture.File.SaveAs(path);
        //    }
        //}

        public JsonResult UploadPhoto(PhotoModel model)
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
            {

            return Json(0);
            }
                

            var file = model.ImageFile;

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];

            //if(file != null)
            //{
            //    var fileName = Path.GetFileName(file.FileName);
            //    var fileExtention = Path.GetExtension(file.FileName);
            //    var fileNameWithoutExtention = Path.GetFileNameWithoutExtension(file.FileName);

            //    file.SaveAs(Server.MapPath("/images/" + file.FileName));

            //}
            string virtualFilePath = objSinglebasicInfo.UserPhoto;
            string serverFilePath = string.Empty;

            if (file != null)
            {
                string fileType = file.ContentType;

                if (fileType == "image/jpg" || fileType == "image/jpeg" || fileType == "image/gif" || fileType == "image/png" || fileType == "image/bmp")
                {
                    int fileSize = file.ContentLength;
                    //if (fileSize <= 512000)
                    if (fileSize <= 5000000)
                    {
                        string serverFoldepath = Server.MapPath("/images/UserPhotos\\");
                        //if (!Directory.Exists(serverFilePath))
                        //    Directory.CreateDirectory(serverFoldepath);
                        

                        string fileName = Path.GetFileName(file.FileName);

                        string primaryFileName = Path.GetFileNameWithoutExtension(fileName);
                        string fileExtensionName = Path.GetExtension(fileName);

                        //Generate New FileName
                        Random objRandom = new Random();
                        int num = objRandom.Next(999999999);
                        DateTime dt = DateTime.Now;
                        string newFileName = primaryFileName + num.ToString() + dt.Day.ToString() + dt.Month.ToString() + dt.Year.ToString() + dt.Second.ToString() + dt.Millisecond.ToString() + fileExtensionName;

                        // for locally
                        serverFilePath = serverFoldepath + newFileName;

                        virtualFilePath = "/images/UserPhotos/" + newFileName;

                        //for server
                        //serverFilePath = "http://belal0khanjar-001-site1.gtempurl.com" + virtualFilePath;
                        //serverFilePath = "http://belal0khanjar-001-site1.gtempurl.com" + virtualFilePath;
                    }
                    else
                    {
                        ViewBag.FileUploadError = "Please upload max 500 kb size file only";
                        return Json(0, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    ViewBag.FileUploadError = "Please upload Image file only";
                    return Json(0);
                }
            }

            dbEntities.SP_UpdateCvPhoto(Convert.ToInt32(Session["CvId"]), virtualFilePath);

            int status =0;

            if (file != null)
            {
                string oldFilePath = Server.MapPath(objSinglebasicInfo.UserPhoto);

                if (System.IO.File.Exists(oldFilePath))
                    System.IO.File.Delete(oldFilePath);

                file.SaveAs(serverFilePath);

                 status = 1;
            }
            //ViewBag.StatusPhoto = "User Profile photo has Updated successfully!!!";


            return Json(/*serverFilePath*/status , JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeletePhoto()
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
            {

                return Json(0);
            }

            List<SP_GetCvBasicInformationByCvId_Result> objListBasicInformationDetails = dbEntities.SP_GetCvBasicInformationByCvId(Convert.ToInt32(Session["CvId"])).ToList();

            SP_GetCvBasicInformationByCvId_Result objSinglebasicInfo = objListBasicInformationDetails[0];

            string oldFilePath = Server.MapPath(objSinglebasicInfo.UserPhoto);

            if (System.IO.File.Exists(oldFilePath))
                System.IO.File.Delete(oldFilePath);

            

            objSinglebasicInfo.UserPhoto = null;
            int k = dbEntities.SaveChanges();

            return Json( k,JsonRequestBehavior.AllowGet);

        }

        public ActionResult Logout()
        {
            Session.Abandon(); // Cancel the current Session
            Session.Remove("UserId");
            Session.Remove("CvId");

            return RedirectToAction("Login");
        }

        public ActionResult EditAccount()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home");


            tblUserAccountDetail objUserAccountDetail = dbEntities.tblUserAccountDetails.Find(Session["UserId"]);

            ViewBag.accountDetails = objUserAccountDetail;

            return View();
        }

        [HttpPost]
        public ActionResult EditAccount(string name, string password)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Home");

            if(password != "" && password.Length > 5)
            { 
            tblUserAccountDetail objUserAccountDetail = dbEntities.tblUserAccountDetails.Find(Session["UserId"]);


            objUserAccountDetail.FullName = name;
            objUserAccountDetail.Password = Utility.Encrypt(password, "ER");

            dbEntities.SaveChanges();

                
                TempData["SaveChanges"] = 1;
            }
            else
            {
                ViewBag.notValidated = 1;
            }

            tblUserAccountDetail objUserAccountDetail1 = dbEntities.tblUserAccountDetails.Find(Session["UserId"]);

            ViewBag.accountDetails = objUserAccountDetail1;



            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Task1()
        {
            return View();
        }

        public ActionResult Task2()
        {
            return View();
        }

        public ActionResult Task3()
        {
            return View();
        }

    }
}