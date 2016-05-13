﻿using Microsoft.AspNet.Identity;
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

        public SolutionService(IAppDataContext context)
        {
            db = context ?? new ApplicationDbContext();
        }
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

            return;
        }

        public SolutionViewModel getUsersBestHandin(int id)
        {
            var handins = (from hand in db.Solutions
                           where hand.assignmentID == id
                           select hand).ToList();

            SolutionViewModel result = new SolutionViewModel();
            result.solutions = handins;

            return result;
        }
        public UserViewModel getUsersInAssignments(int id)
        {
            var user = (from assign in db.Solutions
                         join us in db.Users on assign.userID equals us.Id into result
                         where assign.Id == id
                         from x in result
                         select x).ToList();

            var userView = new UserViewModel();
            userView.users = user;

            return userView;
        }
    }
}