using Microsoft.AspNet.Identity;
using MoooLien.DAL;
using MoooLien.Models;
using MoooLien.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MoooLien.Service
{
    public class UsersService
    {
        private ApplicationDbContext db;
        public UsersService()
        {
            db = new ApplicationDbContext();
        }
        public List<ApplicationUser> GetAllUsersAsEntity()
        {
            var users = (from user in db.Users
                         orderby user.UserName ascending
                         select user).ToList();
            return users;
        }
        public UserViewModel getAllUsers()
        {
            UserViewModel theModel = new UserViewModel();
            theModel.users = (from user in db.Users
                              orderby user.Email ascending
                              select user).ToList();
            return theModel;
        }
        public ApplicationUser getUserByID(string ID)
        {
            ApplicationUser user = (from users in db.Users
                                    where users.Id == ID
                                    select users).SingleOrDefault();
            return user;
        }
        public bool CanDeleteUser(ApplicationUser user)
        {
            var exists = (from x in db.Users
                          where x.Id == user.Id
                          select x).FirstOrDefault();
            if (exists != null)
            {
                return false;
            }

            return true;
        }

        public UsersCoursesViewModel getUsersCoursesAndRole()
        {
            var currentUser = HttpContext.Current.User.Identity.GetUserId();

            var user = (from u in db.UsersInCourse
                        where u.userID == currentUser
                        select u).ToList();

            return null;
        }
    }
}