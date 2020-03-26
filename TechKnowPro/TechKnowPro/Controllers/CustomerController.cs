using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechKnowPro.Models;

namespace TechKnowPro.Controllers
{
    public class CustomerController : Controller
    {
        private Techknowprocontext db = new Techknowprocontext();
        // GET: Customer
        public ActionResult Profile(int UserId)
        {
            var data = db.Registers.Where(x => x.Id == UserId && x.UserLevel == 3).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult SaveProfile(Register register)
        {
            if(register != null)
            {
                register.UserLevel = 3;
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(register);
        }

        public ActionResult List()
        {
            var data = db.Registers.Where(x => x.UserLevel == 3).ToList();
            return View(data);
        }

        public ActionResult AddContact(int id)
        {
            var Model = db.Registers.Where(x => x.Id == id).FirstOrDefault();
            if (Model != null)
            {
                var contactList = new ContactList();
                contactList.CustomerId = id;
                contactList.UserId = Model.Id;

                db.ContactLists.Add(contactList);
                db.SaveChanges();
                return RedirectToAction("Index" , "ContactLists");
            }
            return View();
        }
    }
}