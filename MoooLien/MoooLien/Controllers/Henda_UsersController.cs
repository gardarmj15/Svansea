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
    [Authorize]
    public class Henda_UsersController : Controller
    {
        private UsersService uService = new UsersService(null);
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
            UserViewModel model = uService.getAllUsers();
            return View(model);
        }

        public async Task<ActionResult> Remove(string id)
        {
            if (id != null)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(id);
                if (uService.CanDeleteUser(user))
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

        public ActionResult Enrole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enrole(FormCollection wasIstDas)
        {
            /*uService.getUsersCoursesAndRole();*/

            return null;
        }

    }
    
}