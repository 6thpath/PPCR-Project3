using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PPCR.Models;
using PPCR.ViewModels;

namespace PPCRentalProject.Controllers
{
    public class HomeController : Controller
    {
        DemoPPCRentalEntities entities = new DemoPPCRentalEntities();
        public ActionResult Index()
        {
            ViewModel Vm = new ViewModel();
            Vm.zDistricts = entities.DISTRICTs.ToList();
            Vm.zProperties = entities.PROPERTies.ToList();
            Vm.zStreets = entities.STREETs.ToList();
            Vm.zWards = entities.WARDs.ToList();
            return View(Vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}