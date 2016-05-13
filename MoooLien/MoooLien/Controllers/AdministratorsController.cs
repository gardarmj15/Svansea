using System.Web.Mvc;
using MoooLien.Models.ViewModel;
using MoooLien.Service;

namespace MoooLien.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdministratorsController : Controller
    {
        #region Service connection
        private UsersService uService = new UsersService(null);
        private CourseService cService = new CourseService(null);
        private UsersInCourseService uInCService = new UsersInCourseService(null);
        #endregion

        #region Index()
        //Index()
        public ActionResult Index()
        {

            return View();
        }
        #endregion

        #region Create()
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region List()
        public ActionResult List()
        {
            UserViewModel model = uService.getAllUsers();
            return View(model);
        }
        #endregion

        #region ManageUsers()
        public ActionResult ManageUsers()
        {
            UserViewModel model = uService.getAllUsers();
            return View(model);
        }
        #endregion

        #region ManageCourses()
        public ActionResult ManageCourses()
        {
            cService.getAllCourses();
            return View(cService.getAllCourses());
        }
        #endregion

        #region Enrole(int id)
        public ActionResult Enrole(int id)
        {
            ViewBag.courseID = id;
            
            return View(uService.getUsersByCourseID(id));
        }
        #endregion

        #region moveToStudent(string userID, int courseID)
        public ActionResult moveToStudent(string userID, int courseID)
        {

            if (uInCService.userExists(userID, courseID, 2))
            {
                uInCService.removeLink(userID, courseID);
            }
            uInCService.createLink(userID, courseID, 1);
            return RedirectToAction("Enrole", "Administrators", new { id = courseID });
        }
        #endregion

        #region moveToTeacher(string userID, int courseID)
        public ActionResult moveToTeacher(string userID, int courseID)
        {
            if (uInCService.userExists(userID, courseID, 1))
            {
                uInCService.removeLink(userID, courseID);
            }
            uInCService.createLink(userID, courseID, 2);
            return RedirectToAction("Enrole", "Administrators", new { id = courseID });
        }
        #endregion

        #region removeFromCourse(string userID, int courseID)
        public ActionResult removeFromCourse(string userID, int courseID)
        {
            uInCService.removeLink(userID, courseID);
            return RedirectToAction("Enrole", "Administrators", new { id = courseID });
        }
        #endregion

    }
}