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
    public class HintQuestionController : Controller
    {

        EventReminderEntities1 dbEntities = new EventReminderEntities1();
        public ActionResult Index()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");
            return View();
        }
        public ActionResult GetHintQuestionList()
        {

            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");
            List<tblHintQuestion> HintQuestion = new List<tblHintQuestion>();

            foreach (tblHintQuestion question in dbEntities.tblHintQuestions.ToList())
            {
                HintQuestion.Add(new tblHintQuestion() { HintQuestionId = question.HintQuestionId, HintQuestion = question.HintQuestion, IsActive = question.IsActive });

            }
            return Json(HintQuestion, JsonRequestBehavior.AllowGet);
        }
        public int InsertHintQuestion(string hintQuestion, string isActive)
        {
            tblHintQuestion question = new tblHintQuestion()
            {
                HintQuestion = hintQuestion,
                IsActive = Convert.ToBoolean(isActive)
            };
            dbEntities.tblHintQuestions.Add(question);

            return dbEntities.SaveChanges();
        }

        public int UpdateHintQuestions(string hintQuestionId, string hintQuestion, string isActive)
        {
            tblHintQuestion question  = dbEntities.tblHintQuestions.Find(int.Parse(hintQuestionId));

            question.HintQuestion = hintQuestion;
            question.IsActive = Convert.ToBoolean(isActive);
            return dbEntities.SaveChanges();
        }

        public int DeleteHintQuestions(string hintQuestionId)
        {
            tblHintQuestion question = dbEntities.tblHintQuestions.Find(int.Parse(hintQuestionId));
            dbEntities.tblHintQuestions.Remove(question);
            return dbEntities.SaveChanges();
        }
    }
}