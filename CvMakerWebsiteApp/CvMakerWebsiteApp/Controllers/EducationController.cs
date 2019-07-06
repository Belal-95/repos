using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CvMakerWebsiteApp.Models;

namespace CvMakerWebsiteApp.Controllers
{
    public class EducationController : Controller
    {
        CvMakerDBEntities1 dbEntities = new CvMakerDBEntities1();

        // GET: Education
        public ActionResult Index()
        {
            return View();
        }

        public int UpdateCourseName(string EducationId, string courseName)
        {
            dbEntities.SP_UpdateEducationCourseName(Convert.ToInt32(EducationId), courseName);

            return dbEntities.SaveChanges();
        }

        public int UpdateInstitutionName(string EducationId, string institutionName)
        {
            dbEntities.SP_UpdateEducationInstitutionName(Convert.ToInt32(EducationId), institutionName);

            return dbEntities.SaveChanges();
        }

        public int UpdateEdustartdate(string EducationId, string edustartdate)
        {
            dbEntities.SP_UpdateEducationStartDate(Convert.ToInt32(EducationId), edustartdate);

            return dbEntities.SaveChanges();
        }

        public int UpdateEducatinEndDate(string EducationId, string eduenddate)
        {
            dbEntities.SP_UpdateEducatinEndDate(Convert.ToInt32(EducationId), eduenddate);

            return dbEntities.SaveChanges();
        }

        public int UpdateOtherEduInformation(string EducationId, string otherEduInfo)
        {
            dbEntities.SP_UpdateEducationOtherInformation(Convert.ToInt32(EducationId), otherEduInfo);

            return dbEntities.SaveChanges();
        }
    }
}