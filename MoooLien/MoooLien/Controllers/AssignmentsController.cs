﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoooLien.DAL;
using MoooLien.Models.Entities;
using MoooLien.Service;
using MoooLien.Models.ViewModel;

namespace MoooLien.Controllers
{
    [Authorize]
    public class AssignmentsController : Controller
    {
        private DefaultConnection db = new DefaultConnection();
        private AssignmentsService aService = new AssignmentsService();

        // GET: Assignments
        public ActionResult Index(int id)
        {
            
            if(aService.isTeacher(id))
            {
                return null;
            }
            ViewBag.courseID = id;
            return View(aService.getAssignmentsInCourse(id));
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAssignmentViewModel newAssignment, int id)
        {
            //var assignment = newAssignment;
            newAssignment.courseID = id;

            if (aService.createAssignment(newAssignment))
            {
                return RedirectToAction("Index", "Assignments", new { id = id });
            }
            else
            {
                ModelState.AddModelError("", "Could not add the assignment!");
                return RedirectToAction("Create", "Assignments");
            }
        }

        // GET: Assignments/Details/5
        /*public ActionResult Details(int? id)
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

        // GET: Assignments/Create
        public ActionResult Create()
        {
            PopulateDropDown();
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,courseID,name,solution")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,courseID,name,solution")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            db.Assignments.Remove(assignment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public void PopulateDropDown()
        {
            AssignmentsService a = new AssignmentsService();
            ViewData["Categories"] = a.getAllCourses();
        }*/

    }
}
