using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.Entities
{
    public class UsersInCourse
    {
        public string userID { get; set; }
        public int courseID { get; set; }
        public int roleID { get; set; }
    }
}