using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Models.ViewModel
{
    public class AssignmentViewModel
    {
        public string name { get; set; }

        public AssignmentViewModel getAssignmentByID(int assignmentID)
        {
            return null;
        }

        public IEnumerable<SelectListItem> Assignments { get; set; }
    }
}