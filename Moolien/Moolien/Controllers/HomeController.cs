﻿using Moolien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moolien.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IdentityManager manager = new IdentityManager();
            if (!manager.RoleExists("Administrators"))
            {
                manager.CreateRole("Administrators");
            }
            if (!manager.UserExists("admin"))
            {
                ApplicationUser newAdmin = new ApplicationUser();
                newAdmin.UserName = "admin@admin.is";
                manager.CreateUser(newAdmin, "123456");
                manager.AddUserToRole(newAdmin.Id, "Administrators");
            }
            return View();
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
        public ActionResult Tabs()
        {
            ViewBag.Message = "Your tabs examples.";

            return View();
        }
    }
}