using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechKnowPro.Models;

namespace TechKnowPro.Controllers
{
    public class AccountController : Controller
    {
        private Techknowprocontext db = new Techknowprocontext();
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var success = db.Registers.Where(x => x.Email.ToLower() == loginViewModel.Email.ToLower() && x.Password.ToLower() == loginViewModel.Password.ToLower()).FirstOrDefault();
                if(success != null)
                {
                    this.Session["UserId"] = success.Id;
                    return RedirectToAction("Index", "Home");
                }
                TempData["Message"] = "Invalid Login Attempt";
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
             if(ModelState.IsValid)
            {
                register.UserLevel = 3;
                db.Registers.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public ActionResult Logout()
        {
            this.Session["UserId"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}