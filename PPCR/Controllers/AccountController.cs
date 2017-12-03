using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCR.Models;

namespace PPCR.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register(int id = 0)
        {
            USER userx = new USER();
            return View(userx);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(USER user)
        {
            using (DemoPPCRentalEntities entities = new DemoPPCRentalEntities())
            {
                if (entities.USERs.Any( x => x.Email == user.Email))
                {
                    ViewBag.DuplicateMessage = "This Email has already used";
                    return View("Register", user);
                }
                entities.USERs.Add(user);
                entities.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Your account successully registered";

            return View("Register", new USER());
        }

        [AllowAnonymous]
        public ActionResult Login(USER user)
        {
            using (DemoPPCRentalEntities entities = new DemoPPCRentalEntities())
            {
                var userDetails = entities.USERs.Where( x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    user.LoginError = "Wrong username or password.";
                    return View("Login", user);
                }
                else
                {
                    Session["ID"] = userDetails.ID;
                    Session["Email"] = userDetails.Email;
                    Session["FullName"] = userDetails.FullName;
                    Session["Role"] = userDetails.Role;
                    return RedirectToAction("Index","Home");
                }
            }
        }
        
        public ActionResult Logout()
        {
            int ID = (int)Session["ID"];
            Session.Abandon();
            return RedirectToAction("Login","Account");
        }

    }
}