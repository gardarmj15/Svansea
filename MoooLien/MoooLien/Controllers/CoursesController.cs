using System.Web.Mvc;
using MoooLien.Models.Entities;
using MoooLien.Service;
using MoooLien.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace MoooLien.Controllers
{
    public class CoursesController : Controller
    {
        #region Server conections
        private CourseService cService = new CourseService(null);
        #endregion

        #region Index()
        // GET: Courses
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            CourseViewModel cView = cService.getAllCourses();
            return View(cView);
        }
        #endregion

        #region UserIndex()
        public ActionResult UserIndex()
        {
            var userid = User.Identity.GetUserId();
            return View(cService.getCourseByUserID(userid));
        }
        #endregion

        #region Create()
        // GET: Courses/Details/5
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Create(CreateCourseViewModel newCourse)
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
        #endregion

        #region Delete(int id)
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
        #endregion

        # region Edit(int id)
        public ActionResult Edit(int id)
        {
            return View();
        }
        #endregion
    }
}
