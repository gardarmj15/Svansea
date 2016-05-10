using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.Entities
{
    public class AssignmentsInCourse
    {
        public int ID { get; set; }
        public string assignmentID { get; set; }
        public string courseID { get; set; }
    }
}