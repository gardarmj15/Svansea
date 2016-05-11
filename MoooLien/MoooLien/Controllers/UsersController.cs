using Microsoft.AspNet.Identity;
using MoooLien.Models;
using MoooLien.Models.ViewModel;
using MoooLien.Service;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace MoooLien.Controllers
{
    public class UsersController : Controller
    {
        private UsersService service = new UsersService();
        private ApplicationUserManager userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            UserViewModel model = service.getAllUsers();
            populateCourseDropDown();
            return View(model);
        }
        public void populateCourseDropDown()
        {
            CourseService cService = new CourseService();
            ViewData["Courses"] = cService.getAllCourses();
        }

        public async Task<ActionResult> Remove(string id)
        {
            if (id != null)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(id);
                if (service.CanDeleteUser(user))
                {
                    var result = UserManager.Delete(user);
                    if (result.Succeeded)
                    {
                        TempData["message"] = user.UserName + " has be deleted from the system";
                    }
                    else
                    {
                        TempData["errorMessage"] = "An error occured while trying to delete " + user.UserName;
                    }
                }
                return RedirectToAction("index", "user");
            }
            return View("404");
        }

    }
    
}