using MoooLien.Models;
using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Service
{
    public class UsersInCourseService
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public bool createLink(string userID, int courseID, int roleID)
        {
            UsersInCourse uInC = new UsersInCourse() { userID = userID, courseID = courseID, roleID = roleID};
            db.UsersInCourse.Add(uInC);
            return(Convert.ToBoolean(db.SaveChanges())); 
        }
        public bool removeLink(string userID, int courseID)
        {
            var userToRemove = (from us in db.UsersInCourse
                                where us.userID == userID && us.courseID == courseID
                                select us).SingleOrDefault();
            db.UsersInCourse.Remove(userToRemove);
            return (Convert.ToBoolean(db.SaveChanges()));
        }
    }
}