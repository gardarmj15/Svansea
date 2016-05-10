using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace MoooLien.Models.Entities
{
    [Table(Name = "UsersInCourse")]
    public class UsersInCourse
    {
        public string ID { get; set; }
        public string userID { get; set; }
        public int courseID { get; set; }
        public int roleID { get; set; }
    }
}