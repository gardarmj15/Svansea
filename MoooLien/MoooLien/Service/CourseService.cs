using MoooLien.Models;
using MoooLien.Models.Entities;
using MoooLien.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Service
{
    public class CourseService
    {
        private ApplicationDbContext db;

        public CourseService()
        {
            db = new ApplicationDbContext();
        }

        public Course getCourseByID(int Id)
        {
            Course course = (from co in db.Courses
                          where co.ID == Id
                          select co).SingleOrDefault();
            return course;
        }

        public CourseViewModel getAllCourses()
        {
            var courses = (from co in db.Courses
                           select co).ToList();

            CourseViewModel result = new CourseViewModel();
            result.courses = courses;

            return result;
        }
    }
}