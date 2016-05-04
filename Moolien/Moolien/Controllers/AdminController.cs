using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moolien.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
   
        public ActionResult Courses()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}