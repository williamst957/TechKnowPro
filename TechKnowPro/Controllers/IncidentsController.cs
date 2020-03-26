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
    public class IncidentsController : Controller
    {
        private Techknowprocontext db = new Techknowprocontext();

        // GET: Incidents
        public ActionResult Index()
        {
            ViewBag.CustomerId = new SelectList(db.Registers.Where(x=>x.UserLevel == 3), "Id", "ProfileName");
            ViewBag.IncidentId = new SelectList(db.Incidents, "Id", "IncidentNo");
            return View();
        }

        public ActionResult LoadIncidentDetail(int CustomerID, int IncidentID)
        {
            var data = db.Incidents.Where(x => x.CustomerId == CustomerID && x.Id == IncidentID).FirstOrDefault();
            return View("_IncidentDetail", data);

        }

        // GET: Incidents/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Registers.Where(x => x.UserLevel == 3), "Id", "ProfileName");
            var IncidentNo = new Incident();
            var data = db.Incidents.ToList().Count +1;
            IncidentNo.IncidentNo = "INC/" + data;
            return View(IncidentNo);
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Incidents.Add(incident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Registers, "Id", "ProfileName", incident.CustomerId);
            return View(incident);
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
