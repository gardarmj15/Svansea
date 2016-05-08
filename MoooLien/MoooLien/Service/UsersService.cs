using MoooLien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Service
{
    public class UserService
    {
        private ApplicationDbContext db;
        public UserService()
        {
            db = new ApplicationDbContext();
        }
        public List<SelectListItem> getAllRoles()
        {
            List<SelectListItem> courseList = new List<SelectListItem>();
            SelectListItem item = new SelectListItem { Text = "-- Select category --", Value = "" };
            courseList.Add(item);
            var courses = db.Courses.ToList();
            foreach (var x in courses)
            {
                SelectListItem item0 = new SelectListItem { Text = x.name, Value = x.name.ToString() };
                courseList.Add(item0);
            }
            return courseList;

        }

    }
}