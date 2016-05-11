using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.ViewModel
{
    public class EnroleViewModel
    {
        public List<ApplicationUser> usersInCourse { get; set; }
        public List<ApplicationUser> users { get; set; }
        public List<UserRoles> userRoles { get; set; }
    }
}