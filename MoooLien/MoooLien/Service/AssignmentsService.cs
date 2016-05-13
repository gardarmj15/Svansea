using Microsoft.AspNet.Identity;
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
		private readonly IAppDataContext db;
		#region Assingment Service
		public AssignmentsService(IAppDataContext context)
        {
            db = context ?? new ApplicationDbContext();
        }
		#endregion

		#region Get Assignment by ID
		//get Assingment by ID from Assignment.db
		public Assignment getAssignmentByID(int assignmentID)
        {
            Assignment assignment = (from assign in db.Assignments
                              where assign.ID == assignmentID
                              select assign).SingleOrDefault();
            return assignment;
        }
		#endregion

		#region Get all Assignments
		//Get all assignments from db.Assigments
		public AssignmentViewModel getAllAssignments()
        {
            var assignments = (from assign in db.Assignments
                               select assign).ToList();

            AssignmentViewModel result = new AssignmentViewModel();
            result.assignments = assignments;

            return result;

        }
		#endregion

		#region Get Assignments in Course
		//Get Assignment in course from db.Assignment
		public AssignmentViewModel getAssignmentsInCourse(int courseID)
        {
            //cID = courseID;
            var assignmentInCourse = (from asInCo in db.AssingmentInCourse
                                      join assignment in db.Assignments on asInCo.assignmentID equals assignment.ID into result
                                      where asInCo.courseID == courseID
                                      from x in result
                                      select x).ToList();

            var all = new AssignmentViewModel();
            all.assignments = assignmentInCourse;

            return all;
        }
		#endregion

		#region Create Assignment
		// Add assignment to db.assignments
		public bool createAssignment(CreateAssignmentViewModel newAssignment)
        {
            Assignment temp = new Assignment() { name = newAssignment.name, solution = newAssignment.solution,
                                                 description = newAssignment.description, startDate = newAssignment.startDate,
                                                 endDate = newAssignment.endDate};
            db.Assignments.Add(temp);
            db.SaveChanges();

            AssignmentsInCourse link = new AssignmentsInCourse() { assignmentID = temp.ID, courseID = newAssignment.courseID };
            db.AssingmentInCourse.Add(link);
            
            return Convert.ToBoolean(db.SaveChanges());
        }
		#endregion

		#region Set as Teacher
		//set role of user in UserInCourse 
		public bool isTeacher(int id, string userid)
        {

            var getRole = (from role in db.UsersInCourse
                           where role.courseID == id && role.userID == userid
                           select role.roleID).SingleOrDefault();

            if(getRole == 2)
            {
                return true;
            }
            return false;
        }
		#endregion

		#region Get Course Name
		public string givenCourse(int id)
        {
            var courseID = (from coId in db.AssingmentInCourse
                            where coId.assignmentID == id
                            select coId.courseID).SingleOrDefault();

            var courseName = (from co in db.Courses
                              where co.ID == courseID
                              select co.name).SingleOrDefault();

            return courseName;
        }
		#endregion
	}
}