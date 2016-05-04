using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moolien.Models.Entities
{
    public class Course
    {
        public void addUser()
        {

        }
        public void removeUser()
        {

        }

        private int ID { get; set; }
        private string name { get; set; }
        private string description { get; set; }
        private List<Assignment> assignments;
    }
}