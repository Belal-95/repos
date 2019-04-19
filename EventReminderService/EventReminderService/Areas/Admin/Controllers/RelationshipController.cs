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
    public class RelationshipController : Controller
    {

        EventReminderEntities1 dbEntities = new EventReminderEntities1();
        public ActionResult Index()
        {
            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");
            return View();
        }
        public ActionResult GetRelationshipList()
        {

            if (Session["AdminUser"] == null)
                return RedirectToAction("Login", "Home");
            List<tblRelationship> Relationship = new List<tblRelationship>();

            foreach (tblRelationship relationship in dbEntities.tblRelationships.ToList())
            {
                Relationship.Add(new tblRelationship() { RelationshipId = relationship.RelationshipId, RelationshipName = relationship.RelationshipName, IsActive = relationship.IsActive });

            }
            return Json(Relationship, JsonRequestBehavior.AllowGet);
        }
        public int InsertRelationship(string relationshipName, string isActive)
        {
            tblRelationship relationship = new tblRelationship()
            {
                RelationshipName = relationshipName,
                IsActive = Convert.ToBoolean(isActive)
            };
            dbEntities.tblRelationships.Add(relationship);

            return dbEntities.SaveChanges();
        }

        public int UpdateRelationship(string relationshipId, string relationshipName, string isActive)
        {
            tblRelationship relationship = dbEntities.tblRelationships.Find(int.Parse(relationshipId));

            relationship.RelationshipName = relationshipName;
            relationship.IsActive = Convert.ToBoolean(isActive);
            return dbEntities.SaveChanges();
        }

        public int DeleteRelationship(string relationshipId)
        {
            tblRelationship relationship = dbEntities.tblRelationships.Find(int.Parse(relationshipId));
            dbEntities.tblRelationships.Remove(relationship);
            return dbEntities.SaveChanges();
        }
    }
}