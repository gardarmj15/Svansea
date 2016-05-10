using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Models.ViewModel
{
    public class AssignmentViewModel
    {
        public int ID { get; set; }
        public int courseID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string solution { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}