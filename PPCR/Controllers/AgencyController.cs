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

        [HttpGet]
        public ActionResult PostProject()
        {
            ViewBag.property_type = entities.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.streetName = entities.STREETs.OrderByDescending(x => x.ID).ToList();
            ViewBag.wardName = entities.WARDs.OrderByDescending(x => x.ID).ToList();
            ViewBag.districtName = entities.DISTRICTs.OrderByDescending(x => x.ID).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult PostProject(PROPERTY p)
        {
            var Ei = new PROPERTY();
            Ei.Avatar = p.Avatar;
            Ei.Images = p.Images;
            Ei.PropertyName = p.PropertyName;
            Ei.PropertyType_ID = p.PropertyType_ID;
            Ei.Area = p.Area;
            Ei.BedRoom = p.BedRoom;
            Ei.BathRoom = p.BathRoom;
            Ei.PackingPlace = p.PackingPlace;
            Ei.District_ID = p.District_ID;
            Ei.Ward_ID = p.Ward_ID;
            Ei.Street_ID = p.Street_ID;
            Ei.Content = p.Content;
            Ei.Status_ID = p.Status_ID;
            Ei.Note = p.Note;
            entities.PROPERTies.Add(Ei);
            entities.SaveChanges();
            return RedirectToAction("Sale_ProjectsList");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {

            file.SaveAs(Server.MapPath("~/img/" + file.FileName));
            return "" + file.FileName;
        }

    }
}