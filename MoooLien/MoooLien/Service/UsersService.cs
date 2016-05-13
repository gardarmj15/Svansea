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
		#region User Service
	public class UsersService
    {

        private readonly IAppDataContext db;
        public UsersService(IAppDataContext context)
        {
            db = context ??  new ApplicationDbContext();
        }
        public List<ApplicationUser> GetAllUsersAsEntity()
        {
            var users = (from user in db.Users
                         orderby user.UserName ascending
                         select user).ToList();
            return users;
        }
		#endregion

		#region Get All Users
		//get all users from db.users
		public UserViewModel getAllUsers()
        {
            UserViewModel theModel = new UserViewModel();
            theModel.users = (from user in db.Users
                              orderby user.Email ascending
                              select user).ToList();
            return theModel;
        }
		#endregion

		#region Get Users by ID
		//get users by ID from db.Users
		public ApplicationUser getUserByID(string ID)
        {
            ApplicationUser user = (from users in db.Users
                                    where users.Id == ID
                                    select users).SingleOrDefault();
            return user;
        }
		#endregion

		#region Delete User
		//delete user from db.users
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
		#endregion

		#region Get Users by Course ID
		//get users by course ID from db.UsersInCourse
		public EnroleViewModel getUsersByCourseID(int id)
        {
            var courseStudents = (from u in db.UsersInCourse
                                  join us in db.Users on u.userID equals us.Id into result
                                  where u.courseID == id && u.roleID == 1
                                  from x in result
                                  select x);

            var courseTeachers = (from u in db.UsersInCourse
                                  join us in db.Users on u.userID equals us.Id into result
                                  where u.courseID == id && u.roleID == 2
                                  from x in result
                                  select x);

            var notEnroledUsers = (from u in db.Users
                                   select u).Except(courseStudents).Except(courseTeachers);

            var all = new EnroleViewModel();
            all.students = courseStudents.ToList();
            all.teachers = courseTeachers.ToList();
            all.notEnroled = notEnroledUsers.ToList();

            return all;
        }
		#endregion
	}
}