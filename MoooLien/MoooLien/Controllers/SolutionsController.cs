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
using MoooLien.Models;
using System.IO;

namespace MoooLien.Controllers
{
    public class SolutionsController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Solutions
        public ActionResult Index()
        {
            return View(db.Assignments.ToList());
        }

        // GET: Solutions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        public ActionResult Handin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Handin([Bind(Include = "ID,name,description,solution,startDate,endDate")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignment);
        }

        [HttpPost]
        public ActionResult UploadStatus(HttpPostedFileBase file)
        {
            //var userName = User.Identity.Name;

            // Specify the directory you want to manipulate.
            //string path = @"c:\MyDir";

            string path = Server.MapPath("~/Files/" + User.Identity.Name + "/");

            try
            {
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                }
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    file.SaveAs(path + file.FileName);
                    ViewBag.Path = path;
                    //Console.WriteLine("That path exists already.");
                    //return;
                }

                // Try to create the directory.
                //DirectoryInfo di = Directory.CreateDirectory(path);
                //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

            
            return View();
        }


    }
}
