﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.Entities
{
    public class Solution
    {
        public int Id { get; set; }
        public string userID { get; set; }
        public int assignmentID { get; set; }
        public DateTime handinDate { get; set; }
        public string accepted { get; set; }
        public string file { get; set; }
    }
}