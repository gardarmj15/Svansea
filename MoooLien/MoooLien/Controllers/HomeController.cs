using Microsoft.AspNet.Identity;
using MoooLien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            IdentityManager manager = new IdentityManager();
            //var user = manager.GetUser("admin@admin.com");
            var user1 = manager.GetUser("teacher@teacher.com");
        
/*
            if (manager.UserIsInRole(user.Id, "Administrators"))
            {
                return RedirectToAction("Index", "Administrator");
            }
*/
            if (manager.UserIsInRole(user1.Id, "Teachers"))
            {
                return RedirectToAction("Index", "Teacher");
            }

            return View();
        }
        /// <summary>
		/// This action demostrates how we can use our IdentityManager helper class to interact
		/// with default users and roles implementation provided for Forms authentication (Microsoft.AspNet.Identity).
		/// 
		/// 1.- This action checks if role "Administrators" exists, if not it is created.
		/// 2.- Then it check if user "admin" exists. if not it is created.
		/// 3.- The code checks if the "admin" user belong to the "Administrators" role. if not it is added to the role.
		/// 4.- Now the code get all the roles for "admin" user, then clears them all and get all the roles again.
		/// 5.- Finally the code demostrates how to check if user is authenticated, if so, the user id for the current login user is retrieved as well as the roles.
		/// </summary>
		/// <returns></returns>
		public ActionResult TestAuth()
        {
            IdentityManager manager = new IdentityManager();

            if (!manager.RoleExists("Administrators"))
            {
                manager.CreateRole("Administrators");
            }

            if (!manager.UserExists("admin@admin.com"))
            {
                ApplicationUser newAdmin = new ApplicationUser();
                newAdmin.UserName = "admin@admin.com";
                manager.CreateUser(newAdmin, "123456");
            }


            var user = manager.GetUser("admin@admin.com");

            if (!manager.UserIsInRole(user.Id, "Administrators"))
            {
                manager.AddUserToRole(user.Id, "Administrators");
            }


            //Check the admin roles
            var adminUserRoles = manager.GetUserRoles(user.Id);

            //Clear the roles for user id
            //manager.ClearUserRoles(user.Id);

            //Get admin user roles again, this action should now return no roles
            adminUserRoles = manager.GetUserRoles(user.Id);


            //Action to check if user is authenticated
            if (User.Identity.IsAuthenticated == true)
            {
                var id = User.Identity.GetUserId();
                var myRoles = manager.GetUserRoles(id);
            }

            if (!manager.RoleExists("Teachers"))
            {
                manager.CreateRole("Teachers");
            }

            if (!manager.UserExists("teacher@teacher.com"))
            {
                ApplicationUser newAdmin = new ApplicationUser();
                newAdmin.UserName = "teacher@teacher.com";
                manager.CreateUser(newAdmin, "123456");
            }


            var user1 = manager.GetUser("teacher@teacher.com");

            if (!manager.UserIsInRole(user1.Id, "Teachers"))
            {
                manager.AddUserToRole(user1.Id, "Teachers");
            }


            //Check the admin roles
            var teacherUserRoles = manager.GetUserRoles(user1.Id);

            //Clear the roles for user id
            //manager.ClearUserRoles(user.Id);

            //Get admin user roles again, this action should now return no roles
            teacherUserRoles = manager.GetUserRoles(user.Id);


            //Action to check if user is authenticated
            if (User.Identity.IsAuthenticated == true)
            {
                var id = User.Identity.GetUserId();
                var myRoles = manager.GetUserRoles(id);
            }

            return RedirectToAction("Index");
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