using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moolien.Models.Entities
{
    public class Student : User
    {
        private void submit()
        {

        }

        private string course { get; set; }
        private string assignment { get; set; }
        private List<Submission> submission { get; set; }
        private string department { get; set; }
        private string major { get; set; }
        private int semester { get; set; }
    }
}