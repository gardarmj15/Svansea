using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Models.ViewModel
{
    public class AssignmentViewModel
    {
        public List<Assignment> assignments { get; set; }
        public Assignment assignment { get; set; }
    }
    public class CreateAssignmentViewModel
    {

    }
}