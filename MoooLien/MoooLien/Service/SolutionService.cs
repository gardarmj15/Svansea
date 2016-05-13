using Microsoft.AspNet.Identity;
using MoooLien.Models;
using MoooLien.Models.Entities;
using MoooLien.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Service
{
	public class SolutionService
    {
        private readonly IAppDataContext db;

		#region Solution Service
		public SolutionService(IAppDataContext context)
        {
            db = context ?? new ApplicationDbContext();
        }
		#endregion

		#region createHandinAttempt(int assignmentID, string soltuion)
		public void createHandinAttempt(int assignmentId, string solution)
        {
            var currentUser = HttpContext.Current.User.Identity.GetUserId();

            var assignmentSolution = (from assign in db.Assignments
                                      where assign.ID == assignmentId
                                      select assign.solution).FirstOrDefault();

            var acceptedOrNot = "";

            if(assignmentSolution == solution)
            {
                acceptedOrNot = "Accepted";
            }
            else
            {
                acceptedOrNot = "Not Accepted";
            }

            Solution sol = new Solution() { userID = currentUser, assignmentID = assignmentId, accepted = acceptedOrNot, handinDate = DateTime.Now, file = solution};
            db.Solutions.Add(sol);
            db.SaveChanges();

            getSolution(assignmentId);

            return;
        }
		#endregion

		#region getUserHandin(string id, int Id)
		//get user handin from db.soltution
		public SolutionViewModel getUsersHandin(string id, int Id)
        {
            var handins = (from hand in db.Solutions
                           where hand.userID == id && hand.assignmentID == Id
                           select hand).ToList();

            SolutionViewModel result = new SolutionViewModel();
            result.solutions = handins;

            return result;
        }
		#endregion

		#region getUsersinAssignments(int id)
		//get course from db.AssignmentInCourse and user from db.UserInCourse
		public UserViewModel getUsersInAssignments(int id)
        {
            var courseId = (from cor in db.AssingmentInCourse
                            where cor.assignmentID == id
                            select cor.courseID).SingleOrDefault();

            var courseStudents = (from u in db.UsersInCourse
                                  join us in db.Users on u.userID equals us.Id into result
                                  where u.courseID == courseId && u.roleID == 1
                                  from x in result
                                  select x).ToList();

            var userView = new UserViewModel();
            userView.users = courseStudents;

            return userView;
        }
		#endregion

		#region getSolution(int id)
		//get soltuion from db.Assignments
		public SolutionViewModel getSolution(int id)
        {
            var solution = (from sol in db.Assignments
                            where sol.ID == id
                            select sol.solution).SingleOrDefault();

            SolutionViewModel solu = new SolutionViewModel() { theSolution = solution };

            return solu;
        }
		#endregion
	}
}