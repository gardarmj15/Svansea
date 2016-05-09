using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.Entities
{
    public class Assignment
    {
        public int ID { get; set; }
        public string courseID { get; set; }
        public string name { get; set; }
        public int description { get; set; }
        public string solution { get; set; }
    }
}