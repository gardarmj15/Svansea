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
        private DefaultConnection db;
        private ApplicationDbContext Db;
        public UsersService()
        {
            db = new DefaultConnection();
            Db = new ApplicationDbContext();
        }
        public List<ApplicationUser> GetAllUsersAsEntity()
        {
            var users = (from user in Db.Users
                         orderby user.UserName ascending
                         select user).ToList();
            return users;
        }
        public UserViewModel getAllUsers()
        {
            UserViewModel theModel = new UserViewModel();
            theModel.users = (from user in Db.Users
                              orderby user.Email ascending
                              select user).ToList();
            return theModel;
        }
        public ApplicationUser getUserByID(string ID)
        {
            ApplicationUser user = (from users in Db.Users
                                    where users.Id == ID
                                    select users).SingleOrDefault();
            return user;
        }



    }
}