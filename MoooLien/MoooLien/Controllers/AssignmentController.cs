using MoooLien.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Controllers
{
    public class AssignmentController : Controller
    {
        private AssignmentsService service = new AssignmentsService();
        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var viewModel = service.getAssignmentByID(id);

            return View(viewModel);
        }
    }
}