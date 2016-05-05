using Moolien.Models;
using Moolien.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moolien.Services
{
    public class AssignmentService
    {
        private ApplicationDbContext _db;
        public AssignmentService()
        {
            _db = new ApplicationDbContext();
        }
        public List<AssignmentViewModel> getAssignmentsInCourse(int courseID)
        {
            return null;
        }

        public AssignmentViewModel getAssignmentInCourse(int assignmentID)
        {
            return null;
        }
    }
}