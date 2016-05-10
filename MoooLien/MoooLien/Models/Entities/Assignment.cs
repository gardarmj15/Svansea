using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.Entities
{
    public class Assignment
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