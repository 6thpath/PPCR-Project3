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
    public class AgencyController : Controller
    {
        DemoPPCRentalEntities entities = new DemoPPCRentalEntities();

        [HttpGet]
        public ActionResult Agency_AccountPage(int id)
        {
            using (DemoPPCRentalEntities entities = new DemoPPCRentalEntities())
            {
                var AccountDetails = entities.USERs.FirstOrDefault(x => x.ID == id);
                return View(AccountDetails);
            }
        }

        [HttpGet]
        public ActionResult Agency_ProjectsList(int? page, int id)
        {
            var Vm = entities.PROPERTies.ToList().Where(x => x.ID == id);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Vm.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Agency_UpdateInfomation(int id)
        {
            var UI = entities.USERs.FirstOrDefault(x => x.ID == id);
            return View(UI);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agency_UpdateInfomation(int id, USER user)
        {
            using (DemoPPCRentalEntities entities = new DemoPPCRentalEntities())
            {
                var EditedInfo = entities.USERs.FirstOrDefault(x => x.ID == id);
                EditedInfo.Email = user.Email;
                EditedInfo.Password = user.Password;
                EditedInfo.ConfirmPassword = user.ConfirmPassword;
                EditedInfo.FullName = user.FullName;
                EditedInfo.Phone = user.Phone;
                EditedInfo.Address = user.Address;
                EditedInfo.Role = user.Role;
                EditedInfo.Status = user.Status;
                entities.Configuration.ValidateOnSaveEnabled = false;
                entities.SaveChanges();
            }
            return Redirect(Url.Action("Agency_AccountPage", "Agency") + "/" + Session["ID"]);

        }
    }
}