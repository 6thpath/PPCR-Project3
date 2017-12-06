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
    
    public class SaleController : Controller
    {
        DemoPPCRentalEntities entities = new DemoPPCRentalEntities();
        // GET: Sale
        public ActionResult Sale_ProjectsList(int? page)
        {
            var Properties = entities.PROPERTies.ToList();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Properties.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Sale_EditProject(int id)
        {
            var ProjectDetails = entities.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.Property_Type = entities.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.StreetName = entities.STREETs.ToList();
            ViewBag.WardName = entities.WARDs.OrderByDescending(x => x.ID).ToList();
            ViewBag.DistrictName = entities.DISTRICTs.OrderByDescending(x => x.ID).ToList();
            return View(ProjectDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sale_EditProject(int id, PROPERTY p)
        {
            var EditedInfo = entities.PROPERTies.FirstOrDefault(x => x.ID == id);
            EditedInfo.Avatar = p.Avatar;
            EditedInfo.Images = p.Images;
            EditedInfo.PropertyName = p.PropertyName;
            EditedInfo.PropertyType_ID = p.PropertyType_ID;
            EditedInfo.Area = p.Area;
            EditedInfo.BedRoom = p.BedRoom;
            EditedInfo.BathRoom = p.BathRoom;
            EditedInfo.PackingPlace = p.PackingPlace;
            EditedInfo.DISTRICT = p.DISTRICT;
            EditedInfo.WARD = p.WARD;
            EditedInfo.STREET = p.STREET;
            EditedInfo.Content = p.Content;
            EditedInfo.Status_ID = p.Status_ID;
            EditedInfo.Note = p.Note;
            entities.SaveChanges();
            return RedirectToAction("Sale_ProjectsList");
        }
    }
}