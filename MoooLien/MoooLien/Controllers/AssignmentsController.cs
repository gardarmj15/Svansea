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
    [Authorize]
    public class AssignmentsController : Controller
    {
        private AssignmentsService aService = new AssignmentsService(null);
        private CourseService cService = new CourseService(null);

		#region Index(int id)
		// GET: Assignments
		public ActionResult Index(int id)
        {
            var currentUser = User.Identity.GetUserId();

            if (aService.isTeacher(id, currentUser))
            {
                return RedirectToAction("TeacherIndex", "Assignments", new { id = id });
            }
            else
            {
                return RedirectToAction("StudentIndex", "Assignments", new { id = id });
            }
        }
		#endregion

		#region Create(int id)
		//Create Assignment
		public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAssignmentViewModel newAssignment, int id)
        {
            newAssignment.courseID = id;

            if (aService.createAssignment(newAssignment))
            {
                return RedirectToAction("Index", "Assignments", new { id = id });
            }
            else
            {
                ModelState.AddModelError("", "Could not add the assignment!");
                return RedirectToAction("Create", "Assignments");
            }
        }
		#endregion

		#region TeacherIndex(int id)
		//Teacher Index
		public ActionResult TeacherIndex(int id)
        {
            var coursName = cService.getCourseByID(id);
            ViewBag.coursName = coursName.name;
            ViewBag.courseID = id;
            return View(aService.getAssignmentsInCourse(id));
        }
		#endregion

		#region StudentIndex(int id)
		//Student Index
		public ActionResult StudentIndex(int id)
        {
            ViewBag.courseID = id;
            return View(aService.getAssignmentsInCourse(id));
        }
		#endregion
	}
}
