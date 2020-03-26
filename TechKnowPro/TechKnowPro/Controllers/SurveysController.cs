using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechKnowPro.Models;

namespace TechKnowPro.Controllers
{
    public class SurveysController : Controller
    {
        private Techknowprocontext db = new Techknowprocontext();

        // GET: Surveys
        public ActionResult Index()
        {
            ViewBag.CustomerId = new SelectList(db.Registers.Where(x=>x.UserLevel == 3), "Id", "ProfileName");
            ViewBag.IncidentId = new SelectList(db.Incidents, "Id", "IncidentNo");
            return View();
        }

        // GET: Surveys/Details/5
        public  ActionResult LoadSurveyDetail(int CustomerID , int IncidentID)
        {
            var data = db.Surveys.Where(x => x.CustomerId == CustomerID && x.IncidentId == IncidentID).FirstOrDefault();
            return View("_SurveyDetail", data);
          
        }


        public ActionResult SurveyComplete()
        {
            return View();
        }
        // GET: Surveys/Create
        public ActionResult Create()
        {
            ViewBag.IncidentId = new SelectList(db.Incidents, "Id", "IncidentNo");
            ViewBag.UserId = Convert.ToInt16(Session["UserId"]);
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("SurveyComplete");
            }

            ViewBag.IncidentId = new SelectList(db.Incidents, "Id", "IncidentNo", survey.IncidentId);
            return View(survey);
        }

      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
