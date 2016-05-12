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
    public class SolutionServive
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public SolutionViewModel createHandinAttempt(int assignmentId, string solution)
        {
            var currentUser = HttpContext.Current.User.Identity.GetUserId();

            var assignmentSolution = (from assign in db.Assignments
                                      where assign.ID == assignmentId
                                      select assign.solution).ToString();

            var acceptedOrNot = "String";

            if(assignmentSolution == solution)
            {
                acceptedOrNot = "Accepted";
            }
            else
            {
                acceptedOrNot = "Not Accepted";
            }

            Solution sol = new Solution() { userID = currentUser, assignmentID = assignmentId, accepted = acceptedOrNot, handinDate = DateTime.Now };
            db.Solutions.Add(sol);
            db.SaveChanges();






            return null;
        }
    }
}