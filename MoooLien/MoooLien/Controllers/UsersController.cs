using MoooLien.Models;
using MoooLien.Models.ViewModel;
using MoooLien.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Controllers
{
    public class UsersController : Controller
    {
        private UsersService service = new UsersService();

        // GET: Users
        public ActionResult Index()
        {
            UserViewModel model = service.getAllUsers();
            return View(model);
        }
    }
}