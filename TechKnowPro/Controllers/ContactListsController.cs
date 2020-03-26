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
    public class ContactListsController : Controller
    {
        private Techknowprocontext db = new Techknowprocontext();

        // GET: ContactLists
        public ActionResult Index()
        {
            var contactLists = db.ContactLists.Include(c => c.Register);
            return View(contactLists.ToList());
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
