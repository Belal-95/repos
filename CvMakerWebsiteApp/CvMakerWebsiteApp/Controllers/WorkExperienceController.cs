using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CvMakerWebsiteApp.Common;
using System.Data.Entity;
using CvMakerWebsiteApp.Models;

namespace CvMakerWebsiteApp.Controllers
{
    public class WorkExperienceController : Controller
    {
        CvMakerDBEntities1 dbEntities = new CvMakerDBEntities1();

        // GET: WorkExperience
        public ActionResult Index()
        {
            return View();
        }

        public int UpdateWorkTitle(string workExperienceId, string jobTitle)
        {
            dbEntities.SP_UpdateWorkExperienceJobTitle(Convert.ToInt32(workExperienceId), jobTitle);

            return dbEntities.SaveChanges();
        }

        public int UpdateCompanyName(string workExperienceId, string companyName)
        {
            dbEntities.SP_UpdateWorkExperienceCompanyName(Convert.ToInt32(workExperienceId), companyName);

            return dbEntities.SaveChanges();
        }

        public int UpdateWorkstartDate(string workExperienceId, string workstartdate)
        {
            dbEntities.SP_UpdateWorkExperienceStartDate(Convert.ToInt32(workExperienceId), workstartdate);

            return dbEntities.SaveChanges();
        }

        public int UpdateWorkEndDate(string workExperienceId, string workenddate)
        {
            dbEntities.SP_UpdateWorkExperienceEndDate(Convert.ToInt32(workExperienceId), workenddate);

            return dbEntities.SaveChanges();
        }

        public int UpdateOtherWorkInformation(string workExperienceId, string otherWorkInformation)
        {
            dbEntities.SP_UpdateWorkExperienceOtherInformation(Convert.ToInt32(workExperienceId), otherWorkInformation);

            return dbEntities.SaveChanges();
        }

    }
}