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
        public ActionResult Agency_AccountPage(int id)
        {
            using (DemoPPCRentalEntities entities = new DemoPPCRentalEntities())
            {
                var AccountDetails = entities.USERs.FirstOrDefault(x => x.ID == id);
                return View(AccountDetails);
            }
        }

        public ActionResult Agency_ProjectsList(int? page, int id)
        {
            var Vm = entities.PROPERTies.ToList().Where(x => x.ID == id);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Vm.ToPagedList(pageNumber, pageSize));
        }
    }
}