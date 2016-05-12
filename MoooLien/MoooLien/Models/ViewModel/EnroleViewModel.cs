using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.ViewModel
{
    public class EnroleViewModel
    {
        public List<ApplicationUser> teachers { get; set; }
        public List<ApplicationUser> students { get; set; }
        public List<ApplicationUser> notEnroled { get; set; }
        public List<Course> courses { get; set; }
        //public int courseID { get; set; }
    }
}