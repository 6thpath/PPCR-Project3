﻿using System;
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

        public ActionResult Admin_ControlPage(int? page)
        {
            var UserList = entities.USERs.ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(UserList.ToPagedList(pageNumber, pageSize));
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