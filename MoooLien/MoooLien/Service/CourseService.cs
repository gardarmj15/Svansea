using Microsoft.AspNet.Identity;
using MoooLien.Models;
using MoooLien.Models.Entities;
using MoooLien.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Service
{
    public class CourseService
    {
        private readonly IAppDataContext db;

		#region Course Service 
		public CourseService(IAppDataContext context)
        {
            db = context ?? new ApplicationDbContext();
        }
		#endregion

		#region Get Course by ID
		//get course by ID from db.course
		public Course getCourseByID(int Id)
        {
            Course course = (from co in db.Courses
                          where co.ID == Id
                          select co).SingleOrDefault();
            return course;
        }
		#endregion

		#region Get Course by UserID
		//Get course by UserID from db.UserInCourse
		public UsersCoursesViewModel getCourseByUserID(string id)
        {

            var userCourses = (from cUsers in db.UsersInCourse
                               join courses in db.Courses on cUsers.courseID equals courses.ID into result
                               where cUsers.userID == id
                               from x in result
                               select x).ToList();

            var all = new UsersCoursesViewModel();
            all.courses = userCourses;

            return all;

        }
		#endregion

		#region Get all Courses
		//Get all courses from db.Courses
		public CourseViewModel getAllCourses()
        {
            var courses = (from co in db.Courses
                           select co).ToList();

            CourseViewModel result = new CourseViewModel();
            result.courses = courses;

            return result;
        }
		#endregion

		#region Create Course
		//Add Course to db.Courses
		public bool add(CreateCourseViewModel newCourse)
        {
            Course temp = new Course() { name = newCourse.name, description = newCourse.description};
            db.Courses.Add(temp);
            return Convert.ToBoolean(db.SaveChanges());
        }
		#endregion

		#region Delete Course
		//Delete course from db.courses
		public bool deleteCourse(int id)
        {
            db.Courses.Remove(getCourseByID(id));

            return Convert.ToBoolean(db.SaveChanges());
        }
		#endregion
	}
}