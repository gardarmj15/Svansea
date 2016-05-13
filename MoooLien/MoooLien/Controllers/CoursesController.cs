using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoooLien.DAL;
using MoooLien.Models.Entities;
using MoooLien.Service;
using MoooLien.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace MoooLien.Controllers
{
    public class CoursesController : Controller
    {

        private CourseService cService = new CourseService(null);

        // GET: Courses
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            CourseViewModel cView = cService.getAllCourses();
            return View(cView);
        }

        public ActionResult UserIndex()
        {
            var userid = User.Identity.GetUserId();
            return View(cService.getCourseByUserID(userid));
        }

        // GET: Courses/Details/5
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCourseViewModel newCourse)
        {
            if(cService.add(newCourse))
            {
                return RedirectToAction("ManageCourses", "Administrators");
            }
            else
            {
                ModelState.AddModelError("", "Couldn't add new course, please try again");
                return (RedirectToAction("Create"));
            }
        }
        public ActionResult Delete(int id)
        {
            if(cService.deleteCourse(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Deletetion of user failed");
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int id)
        {
            Course course = cService.getCourseByID(id);
            EditCourseViewModel model = new EditCourseViewModel();
            {
                
            };
            return View(model);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCourseViewModel editCourse)
        {
            if (cService.editCourse(editCourse))
            {
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Edit course failed!");
                return RedirectToAction("index");
            }

            

        }*/
    }
}
