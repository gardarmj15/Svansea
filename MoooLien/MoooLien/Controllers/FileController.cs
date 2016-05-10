using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Controllers
{
    public class FileController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Files/" + file.FileName);
            file.SaveAs(path);
            ViewBag.Path = path;
            return View();
        }
    }
}