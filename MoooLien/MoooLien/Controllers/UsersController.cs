﻿using Microsoft.AspNet.Identity;
using MoooLien.Models;
using MoooLien.Models.ViewModel;
using MoooLien.Service;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace MoooLien.Controllers
{
    public class UsersController : Controller
    {
        private UsersService service = new UsersService();
        private ApplicationUserManager userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            UserViewModel model = service.getAllUsers();
            return View(model);
        }
        

    }
    
}