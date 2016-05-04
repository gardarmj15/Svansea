using Moolien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moolien.Services
{
   
    public class CourseService
    {
        private ApplicationDbContext _db;
        public CourseService()
        {
            _db = new ApplicationDbContext();
        }
    }
}