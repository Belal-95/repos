using MultiLanguagesSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiLanguagesSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Regristration r)
        {
            return View(r);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return RedirectToAction("Index", "Home");
        }
    }
}