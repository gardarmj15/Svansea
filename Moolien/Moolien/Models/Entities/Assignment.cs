using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moolien.Models.Entities
{
    public class Assignment
    {
        public void compare()
        {

        }

        private int ID { get; set; }
        private int courseID { get; set; }
        private string title { get; set; }
        private string solution { get; set; }
    }
}