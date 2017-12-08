using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCR.Models;
using System.Threading.Tasks;
using PPCR.PasswordHelper;

namespace PPCR.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Register
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
                if (entities.USERs.Any(x => x.Email == user.Email))
                {
                    ViewBag.DuplicateMessage = "This Email has already used.";
                    return View("Register", user);
                }
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                entities.USERs.Add(user);
                entities.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Your account successfully registered. Your account will be activated in 24h if all information is valid.";

            return View("Register", new USER());
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USER user)
        {
            using (DemoPPCRentalEntities entities = new DemoPPCRentalEntities())
            {
                var EncryptedUsersPassword = Crypto.Hash(user.Password);
                var UserDetails = entities.USERs.Where(x => x.Email == user.Email && x.Password == EncryptedUsersPassword && x.Status == true).FirstOrDefault();
                if (UserDetails == null)
                {
                    ViewBag.LoginError = "Wrong username or password.";
                    return View("Login", user);
                }
                else
                {
                    Session["ID"] = UserDetails.ID;
                    Session["Email"] = UserDetails.Email;
                    Session["FullName"] = UserDetails.FullName;
                    Session["Role"] = UserDetails.Role;
                    Session["Status"] = UserDetails.Status;
                    if (Convert.ToInt32(Session["Role"]) == 1)
                    {
                        return RedirectToAction("Admin_ControlPage", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }

        public ActionResult Logout()
        {
            int ID = (int)Session["ID"];
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public ActionResult ChangePassword(int id)
        {
            using (DemoPPCRentalEntities entities = new DemoPPCRentalEntities())
            {
                var UserInfo = entities.USERs.FirstOrDefault(x => x.ID == id);
                return View(UserInfo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(int id, USER user)
        {
            using (DemoPPCRentalEntities entities = new DemoPPCRentalEntities())
            {
                var AccountDetails = entities.USERs.FirstOrDefault(x => x.ID == id);
                AccountDetails.Password = Crypto.Hash(user.Password);
                AccountDetails.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                entities.Configuration.ValidateOnSaveEnabled = false;
                entities.SaveChanges();
                return Redirect(Url.Action("Agency_AccountPage", "Agency") +"/"+ Session["ID"]);
            }
        }
    }
}