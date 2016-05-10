using MoooLien.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MoooLien.Controllers
{
    public class FileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Upload(HttpPostedFileBase file)
        //{
            /*
                        var userName = User.Identity.Name;

                        // Specify the directory you want to manipulate.
                        //string path = @"c:\MyDir";

                        string path = Server.MapPath("~/Files/" + User.Identity.Name + "/");

                        try
                        {
                            // Determine whether the directory exists.
                            if (Directory.Exists(path))
                            {
                                file.SaveAs(path + file.FileName);
                                ViewBag.Path = path;
                                //Console.WriteLine("That path exists already.");
                                //return;
                            }

                            // Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(path);
                            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                            // Delete the directory.
                            di.Delete();
                            Console.WriteLine("The directory was deleted successfully.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The process failed: {0}", e.ToString());
                        }
                        finally { }

                        return View();*/
        }
    }
