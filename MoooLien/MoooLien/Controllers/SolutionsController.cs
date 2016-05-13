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
using System.Diagnostics;
using MoooLien.Models.ViewModel;
using MoooLien.Service;

namespace MoooLien.Controllers
{
    [Authorize]
    public class SolutionsController : Controller
    {

        private AssignmentsService aService = new AssignmentsService(null);
        private SolutionService sService = new SolutionService(null);
        private UsersService uSerivice = new UsersService(null);
 


        // GET: Solutions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Solutions/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.AssId = id;
            return View(aService.getAssignmentByID(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult viewHandin(string userID, int courseID)
        {
            return View(sService.getUsersHandin(userID, courseID));
        }
        
        public ActionResult viewStudentsInCourse(int id)
        {
            ViewBag.assignId = id;
            return View(sService.getUsersInAssignments(id));
        }

        [HttpPost]
        public ActionResult UploadStatus(HttpPostedFileBase file, int id)
        {
            ViewBag.assId = id;
            //var userName = User.Identity.Name;

            // Specify the directory you want to manipulate.
            //string path = @"c:\MyDir";
            var assignment = aService.getAssignmentByID(id);
            var course = aService.givenCourse(id);

            string path = Server.MapPath("~/Files/" + User.Identity.Name + "/" + course + "/" + assignment.name + "/");

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


            //return View();
            return View("Details");
        }

        protected override void Dispose(bool disposing)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Compiler(int id)
        {
            ViewBag.assId = id;
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Compiler(FormCollection data, int id)
        {
            //ViewBag.AssId = id;

            //Compiler();
            // To simplify matters, we declare the code here.
            // The code would of course come from the student!
            var assignment = aService.getAssignmentByID(id);
            var course = aService.givenCourse(id);
            

            var path = Server.MapPath("~/Files/" + User.Identity.Name + "/"  + course + "/" + assignment.name + "/" + "main.cpp");
            var code = System.IO.File.ReadAllText(path);

            // Set up our working folder, and the file names/paths.
            // In this example, this is all hardcoded, but in a
            // real life scenario, there should probably be individual
            // folders for each user/assignment/milestone.
            //var workingFolder = "C:\\Users\\Svanur\\Documents\\GitHub\\Svansea\\MoooLien\\MoooLien\\Tests\\";
            var workingFolder = Server.MapPath("~/Files/" + User.Identity.Name + "/");
            var cppFileName = "main.cpp";
            var exeFilePath = workingFolder + "main.exe";

            // Write the code to a file, such that the compiler
            // can find it:
            System.IO.File.WriteAllText(workingFolder + cppFileName, code);

            // In this case, we use the C++ compiler (cl.exe) which ships
            // with Visual Studio. It is located in this folder:
            var compilerFolder = "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\VC\\bin\\";
            // There is a bit more to executing the compiler than
            // just calling cl.exe. In order for it to be able to know
            // where to find #include-d files (such as <iostream>),
            // we need to add certain folders to the PATH.
            // There is a .bat file which does that, and it is
            // located in the same folder as cl.exe, so we need to execute
            // that .bat file first.

            // Using this approach means that:
            // * the computer running our web application must have
            //   Visual Studio installed. This is an assumption we can
            //   make in this project.
            // * Hardcoding the path to the compiler is not an optimal
            //   solution. A better approach is to store the path in
            //   web.config, and access that value using ConfigurationManager.AppSettings.

            // Execute the compiler:
            Process compiler = new Process();
            compiler.StartInfo.FileName = "cmd.exe";
            compiler.StartInfo.WorkingDirectory = workingFolder;
            compiler.StartInfo.RedirectStandardInput = true;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.UseShellExecute = false;

            compiler.Start();
            compiler.StandardInput.WriteLine("\"" + compilerFolder + "vcvars32.bat" + "\"");
            compiler.StandardInput.WriteLine("cl.exe /nologo /EHsc " + cppFileName);
            compiler.StandardInput.WriteLine("exit");
            string output = compiler.StandardOutput.ReadToEnd();
            compiler.WaitForExit();
            compiler.Close();

            // Check if the compile succeeded, and if it did,
            // we try to execute the code:
            if (System.IO.File.Exists(exeFilePath))
            {
                var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                processInfoExe.UseShellExecute = false;
                processInfoExe.RedirectStandardOutput = true;
                processInfoExe.RedirectStandardError = true;
                processInfoExe.CreateNoWindow = true;
                using (var processExe = new Process())
                {
                    processExe.StartInfo = processInfoExe;
                    processExe.Start();
                    // In this example, we don't try to pass any input
                    // to the program, but that is of course also
                    // necessary. We would do that here, using
                    // processExe.StandardInput.WriteLine(), similar
                    // to above.

                    // We then read the output of the program:

                    var lines = new List<string>();
                    while (!processExe.StandardOutput.EndOfStream)
                    {
                        lines.Add(processExe.StandardOutput.ReadLine());
                    }
                    var allLines = lines[0];
                    sService.createHandinAttempt(id, allLines);
                    ViewBag.Output = lines;
                }
            }

            // TODO: We might want to clean up after the process, there
            // may be files we should delete etc.

            return View();
        }


    }
}
