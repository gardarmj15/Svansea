using MoooLien.DAL;
using MoooLien.Models;
using MoooLien.Models.Entities;
using MoooLien.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Service
{
    public class AssignmentsService
    {
        private DefaultConnection db;
        public AssignmentsService()
        {
            db = new DefaultConnection();
        }
        public List<AssignmentViewModel> getAssignmentsInCourse(int assignmentID)
        {
            return null;
        }
        public Assignment getAssignmentByID(int assignmentID)
        {
            Assignment assignment = (from assign in db.Assignments
                              where assign.ID == assignmentID
                              select assign).SingleOrDefault();
            return assignment;
        }
        public List<SelectListItem> getAllCourses()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            SelectListItem item = new SelectListItem { Text = "-- Select category --", Value = "0" };
            categories.Add(item);
            var courses = db.Courses.ToList();
            foreach (var x in courses)
            {
                SelectListItem item0 = new SelectListItem { Text = x.name, Value = x.ID.ToString() };
                categories.Add(item0);
            }
            return categories;

        }
    }
}