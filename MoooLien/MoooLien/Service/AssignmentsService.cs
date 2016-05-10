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
        private ApplicationDbContext db;
        public AssignmentsService()
        {
            db = new ApplicationDbContext();
        }
        public Assignment getAssignmentByID(int assignmentID)
        {
            Assignment assignment = (from assign in db.Assignments
                              where assign.ID == assignmentID
                              select assign).SingleOrDefault();
            return assignment;
        }
        public AssignmentViewModel getAllAssignments()
        {
            var assignments = (from assign in db.Assignments
                               select assign).ToList();

            AssignmentViewModel result = new AssignmentViewModel();
            result.assignments = assignments;

            return result;

        }
        public AssignmentViewModel getAssignmentsInCourse(int courseID)
        {
            var assignmentInCourse = (from asInCo in db.AssingmentInCourse
                                      join assignment in db.Assignments on asInCo.assignmentID equals assignment.ID into result
                                      where asInCo.courseID == courseID
                                      from x in result
                                      select x).ToList();

            var all = new AssignmentViewModel();
            all.assignments = assignmentInCourse;

            return all;
        }

        public bool createAssignment(Assignment assignment)
        {
            db.Assignments.Add(assignment);
            return Convert.ToBoolean(db.SaveChanges());
        }
    }
}