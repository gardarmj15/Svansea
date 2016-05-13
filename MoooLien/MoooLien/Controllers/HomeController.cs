using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace MoooLien.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]

        #region Index()
        public ActionResult Index()
        {
            if (User.IsInRole("Administrators"))
            {
                return RedirectToAction("ManageCourses", "Administrators");
            }
            else
            {
                return RedirectToAction("UserIndex", "Courses");
            }
        }
        #endregion

    }
}