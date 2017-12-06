using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCR.Models;
using PagedList;
using PPCR.ViewModels;

namespace PPCRentalProject.Controllers
{

    public class AdminController : Controller
    {
        DemoPPCRentalEntities entities = new DemoPPCRentalEntities();

        public ActionResult Admin_ControlPage()
        {
            ViewModel VM = new ViewModel();
            VM.zUsers = entities.USERs.ToList();
            return View(VM);

            //var UserList = entities.USERs.ToList();
            //return View(UserList);
        }

        [HttpGet]
        public ActionResult Admin_Decentralization(int id)
        {
            var UserInfo = entities.USERs.FirstOrDefault(x => x.ID == id);
            return View(UserInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin_Decentralization(int id, USER user)
        {
            var EditedInfo = entities.USERs.FirstOrDefault(x => x.ID == id);
            EditedInfo.Email = user.Email;
            EditedInfo.FullName = user.FullName;
            EditedInfo.Phone = user.Phone;
            EditedInfo.Address = user.Address;
            EditedInfo.Role = user.Role;
            EditedInfo.Status = user.Status;
            return RedirectToAction("Admin_ControlPage");
        }
    }
}