using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moolien.Models.Entities
{
    public class Courses
    {
        public void addUser()
        {

        }
        public void removeUser()
        {

        }
        /*
        public int ID { get; set; }
        [Required(ErrorMessage = "Plese enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Plese enter description")]
        public string Description { get; set; }
        */
        private int ID { get; set; }
        private string name { get; set; }
        private string description { get; set; }
        private List<Assignment> assignments;
        
    }
}