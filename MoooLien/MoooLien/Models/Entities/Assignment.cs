﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.Entities
{
    public class Assignment
    {
        public int ID { get; set; }
        public int courseID { get; set; }
        public string name { get; set; }
        public string solution { get; set;}
        public int handinCounter { get; set; }
    }
}