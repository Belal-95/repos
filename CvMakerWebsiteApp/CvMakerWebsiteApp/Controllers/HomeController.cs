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

            message += "<a href='http://localhost:28285/Home/Activation?eml=" + email + "' target='_blank'>http://localhost:28285/Home/Activation?eml=" + email + "</a><br /><br />";

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
            TempData["CvId"] = Convert.ToInt32(cvId123.Trim());


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

            SP_GetCvEducationDetailsByCvId_Result objSingleEducationInfo = objListEducationDetails[0];
            ViewBag.CvEducationInfoDetails = objSingleEducationInfo;

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

            SP_GetCvWorkExperienceDetailsByCvId_Result objSingleWorkExperienceInfo = objListWorkExperienceDetails[0];
            ViewBag.CvWorkExperienceInfoDetails = objSingleWorkExperienceInfo;










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

        public int UpdateCvDetails(string fullName, HttpPostedFileBase profilePhoto, string emailId, string phoneNo, string website, string addline1, string addline2, string jobTitle, string companyName, string dateStartWork, string dateEndWork, int otherWorkInformation, string qualificationText, string objectivesText, string CourseName, string institutionName, string dateStartEdu, string dateEndEdu, string otherEduInfo, string interestsText, string referenceText)
        {
            if (Session["UserId"] == null || Session["CvId"] == null)
                return 0;

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
                        return 0;
                    }
                }
                else
                {
                    ViewBag.FileUploadError = "Please upload Image file only";
                    return 0;
                }
            }

            //dbEntities.sp(Convert.ToInt32(Session["UserId"]), newPassword, HintQuestion, newHintQuestion, answer, firstName, middleName, lastName, nickName, dateOfBirth, anniversaryDate, Gender, ageSecret, mobileNo, virtualFilePath, address, Country, State, City, pinCode);

            if (profilePhoto != null)
            {
                string oldFilePath = Server.MapPath(objSinglebasicInfo.UserPhoto);

                if (System.IO.File.Exists(oldFilePath))
                    System.IO.File.Delete(oldFilePath);

                profilePhoto.SaveAs(serverFilePath);
            }
            ViewBag.Status = "User Profile has Updated successfully!!!";

            return 1;


          
        }

        public ActionResult UpgradeToPremium()
        {
            return View();
        }
    }
}