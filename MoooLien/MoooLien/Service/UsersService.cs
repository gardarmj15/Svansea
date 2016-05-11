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

        public EnroleViewModel getUsersByCourseID(int id)
        {
            var courseUser = (from u in db.UsersInCourse
                              join us in db.Users on u.userID equals us.Id into result
                              where u.courseID == id
                              from x in result
                              select x).ToList();

            var users = (from user in db.Users
                           orderby user.Email ascending
                           select user).ToList();

            var roles = (from role in db.UserRoles
                         orderby role.Role ascending
                         select role).ToList();

            var all = new EnroleViewModel();
            all.usersInCourse = courseUser;
            all.users = users;
            all.userRoles = roles;

            return all;
        }
    }
}