using MoooLien.Models;
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
        private ApplicationDbContext _db;
        public AssignmentsService()
        {
            _db = new ApplicationDbContext();
        }
        public List<AssignmentViewModel> getAssignmentsInCourse(int assignmentID)
        {
            return null;
        }
        public AssignmentViewModel getAssignmentByID(int assignmentID)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentID);
            if (assignment == null)
            {
                return null;
            }

            var viewModel = new AssignmentViewModel
            {
                name = assignment.name
            };

            return viewModel;
        }
        public List<SelectListItem> getAllCourses()
        {
            List<SelectListItem> courseList = new List<SelectListItem>();
            SelectListItem item = new SelectListItem { Text = "-- Select category --", Value = "" };
            courseList.Add(item);
            var courses = _db.Courses.ToList();
            foreach (var x in courses)
            {
                SelectListItem item0 = new SelectListItem { Text = x.name, Value = x.name.ToString() };
                courseList.Add(item0);
            }
            return courseList;

        }
    }
}