using MoooLien.Models;
using MoooLien.Models.Entities;
using MoooLien.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Service
{
    public class UsersInCourseService
    {
        private readonly IAppDataContext db;

		#region Users in Course service
		public UsersInCourseService(IAppDataContext context)
        {
            db = context ?? new ApplicationDbContext();
        }
		#endregion

		#region createLink(string userID, int courseID, int roleID)
		//Create link between User and Course
		public bool createLink(string userID, int courseID, int roleID)
        {
            UsersInCourse uInC = new UsersInCourse() { userID = userID, courseID = courseID, roleID = roleID};
            db.UsersInCourse.Add(uInC);
            
            return(Convert.ToBoolean(db.SaveChanges())); 
        }
		#endregion

		#region removeLink(string userID, int courseID)
		//Remove link between User and Course
		public bool removeLink(string userID, int courseID)
        {
            var userToRemove = (from us in db.UsersInCourse
                                where us.userID == userID && us.courseID == courseID
                                select us).SingleOrDefault();
            db.UsersInCourse.Remove(userToRemove);
            return (Convert.ToBoolean(db.SaveChanges()));
        }
		#endregion

		#region userExists(string userID, int courseID, int roleID)
		public bool userExists(string userID, int courseID, int roleID)
        {
            var exists = (from uInC in db.UsersInCourse
                          where uInC.userID == userID && uInC.courseID == courseID && uInC.roleID == roleID
                          select uInC).ToList();

            if(exists.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
		#endregion
	}
}