using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.ViewModel
{
    public class UsersCoursesViewModel
    {
        public List<Course> courses { get; set; }
        public Course course { get; set; }
    }
}