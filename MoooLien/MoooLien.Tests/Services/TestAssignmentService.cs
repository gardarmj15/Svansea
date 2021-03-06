﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoooLien.Service;
using Moolien.Tests;
using MoooLien.Models.Entities;
using MoooLien.Models;
using MoooLien.Models.ViewModel;

namespace MoooLien.Tests.Services
{
    [TestClass]
    public class TestAssignmentService
    {
        private AssignmentsService _service;

        [TestInitialize]
        public void Initialize()
        {
            var mockDB = new MockDatabase();
            #region Courses
            var c1 = new Course
            {
                ID = 1,
                name = "Forritun",
                description = "Kennir grunnatriði í C++"
            };
            mockDB.Courses.Add(c1);
            var c2 = new Course
            {
                ID = 2,
                name = "Gagnaskipan",
                description = "Framhald af Forritun"
            };
            mockDB.Courses.Add(c2);
            var c3 = new Course
            {
                ID = 3,
                name = "Vefforitun",
                description = "Kennir grunnatriði í vefforitun"
            };
            mockDB.Courses.Add(c3);
            var c4 = new Course
            {
                ID = 4,
                name = "Stærðfræði",
                description = "Tölvunarfræðimiðuð stærðfræði"
            };
            mockDB.Courses.Add(c4);
            var c5 = new Course
            {
                ID = 5,
                name = "Tölvuhögun",
                description = "Hvernig tölvur haga sér"
            };
            mockDB.Courses.Add(c5);
            #endregion

            #region Assignments

            var a1 = new Assignment
            {
                ID = 1,
                name = "Sum of integers",
                description = "Sum of 2,3,4",
                startDate = new DateTime(2016, 05, 05, 00, 00, 00),
                endDate = new DateTime(2016, 06, 06, 23, 59, 59),
                solution = "9"
            };
            mockDB.Assignments.Add(a1);

            var a2 = new Assignment
            {
                ID = 2,
                name = "Strings together",
                description = "'get' and 'hyper' together",
                startDate = DateTime.Now,
                endDate = new DateTime(2016, 06, 20, 23, 59, 59),
                solution = "get hyper"
            };
            mockDB.Assignments.Add(a2);

            var a3 = new Assignment
            {
                ID = 3,
                name = "Find blah",
                description = "Find the position of blah in array",
                startDate = new DateTime(2016, 06, 06, 00, 00, 00),
                endDate = new DateTime(2016, 06, 10, 23, 59, 59),
                solution = "5"
            };
            mockDB.Assignments.Add(a3);

            var a4 = new Assignment
            {
                ID = 4,
                name = "Hello world!",
                description = "Write C++ code that writes out 'Hello World'",
                startDate = DateTime.Now,
                endDate = new DateTime(2016, 06, 30, 23, 59, 59),
                solution = "Hello World"
            };
            mockDB.Assignments.Add(a4);

            var a5 = new Assignment
            {
                ID = 5,
                name = "For loop",
                description = "Make a For loop that counts",
                startDate = new DateTime(2016, 06, 05, 00, 00, 00),
                endDate = new DateTime(2016, 06, 20, 23, 59, 59),
                solution = "4"
            };
            mockDB.Assignments.Add(a5);

            var a6 = new Assignment
            {
                ID = 6,
                name = "Get highest number",
                description = "Get the highest number from an array",
                startDate = new DateTime(2016, 06, 10, 00, 00, 00),
                endDate = new DateTime(2016, 06, 20, 23, 59, 59),
                solution = "8"
            };
            mockDB.Assignments.Add(a6);
            #endregion

            #region Users in course

            var uc1 = new UsersInCourse
            {
                ID = 1,
                userID = "1",
                courseID = 2,
                roleID = 2
            };
            mockDB.UsersInCourse.Add(uc1);

            var uc2 = new UsersInCourse
            {
                ID = 2,
                userID = "3",
                courseID = 1,
                roleID = 1
            };
            mockDB.UsersInCourse.Add(uc2);

            var uc3 = new UsersInCourse
            {
                ID = 3,
                userID = "2",
                courseID = 2,
                roleID = 1
            };
            mockDB.UsersInCourse.Add(uc3);

            var uc4 = new UsersInCourse
            {
                ID = 4,
                userID = "5",
                courseID = 3,
                roleID = 1
            };
            mockDB.UsersInCourse.Add(uc4);

            var uc5 = new UsersInCourse
            {
                ID = 5,
                userID = "4",
                courseID = 1,
                roleID = 1
            };
            mockDB.UsersInCourse.Add(uc5);

            var uc6 = new UsersInCourse
            {
                ID = 6,
                userID = "5",
                courseID = 2,
                roleID = 2
            };
            mockDB.UsersInCourse.Add(uc6);

            #endregion

            #region Assignments in courses

            var ac1 = new AssignmentsInCourse
            {
                ID = 1,
                assignmentID = 1,
                courseID = 1
            };
            mockDB.AssingmentInCourse.Add(ac1);

            var ac2 = new AssignmentsInCourse
            {
                ID = 2,
                assignmentID = 2,
                courseID = 2
            };
            mockDB.AssingmentInCourse.Add(ac2);

            var ac3 = new AssignmentsInCourse
            {
                ID = 3,
                assignmentID = 3,
                courseID = 3
            };
            mockDB.AssingmentInCourse.Add(ac3);

            var ac4 = new AssignmentsInCourse
            {
                ID = 4,
                assignmentID = 4,
                courseID = 4
            };
            mockDB.AssingmentInCourse.Add(ac4);

            var ac5 = new AssignmentsInCourse
            {
                ID = 5,
                assignmentID = 5,
                courseID = 5
            };
            mockDB.AssingmentInCourse.Add(ac5);

            var ac6 = new AssignmentsInCourse
            {
                ID = 6,
                assignmentID = 6,
                courseID = 2
            };
            mockDB.AssingmentInCourse.Add(ac6);

            #endregion

            _service = new AssignmentsService(mockDB);
        }

        [TestMethod]
        public void testGetAssignmentByID()
        {
            // arrange
            const int ID = 2;
            const int ID2 = 3;
            const int ID3 = 6;

            // act

            var result1 = _service.getAssignmentByID(ID);
            var result2 = _service.getAssignmentByID(ID2);
            var result3 = _service.getAssignmentByID(ID3);

            // assert

            Assert.AreEqual(2, result1.ID);
            Assert.AreEqual(3, result2.ID);
            Assert.AreEqual(6, result3.ID);
            Assert.AreEqual("Strings together", result1.name);
            Assert.AreEqual("Find blah", result2.name);
            Assert.AreEqual("Get highest number", result3.name);
        }

        [TestMethod]
        public void testGetAllAssignments()
        {
            // arrange


            // act

            var result = _service.getAllAssignments();

            // assert

            Assert.AreEqual(6, result.assignments.Count);
        }

        [TestMethod]
        public void testGetAssignmentsInCourse()
        {
            // arrange
            const int courseID1 = 2;
            const int courseID2 = 1;
            const int courseID3 = 5;

            // act

            var result1 = _service.getAssignmentsInCourse(courseID1);
            var result2 = _service.getAssignmentsInCourse(courseID2);
            var result3 = _service.getAssignmentsInCourse(courseID3);

            // assert

            Assert.AreEqual(2, result1.assignments.Count);
            Assert.AreEqual(1, result2.assignments.Count);
            Assert.AreEqual(1, result3.assignments.Count);
        }
        [TestMethod]
        public void testIsTeacher()
        {
            // arrange
            const int courseID1 = 2;
            const int courseID2 = 1;
            const int courseID3 = 2;
            const string userid1 = "2";
            const string userid2 = "4";
            const string userid3 = "5";

            // act

            var result1 = _service.isTeacher(courseID1, userid1);
            var result2 = _service.isTeacher(courseID2, userid2);
            var result3 = _service.isTeacher(courseID3, userid3);

            // assert

            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }
        [TestMethod]
        public void testGivenCourse()
        {
            const int assignid1 = 2;
            const int assignid2 = 1;
            const int assignid3 = 4;


            // act

            var result1 = _service.givenCourse(assignid1);
            var result2 = _service.givenCourse(assignid2);
            var result3 = _service.givenCourse(assignid3);

            // assert

            Assert.AreEqual("Gagnaskipan", result1);
            Assert.AreEqual("Forritun", result2);
            Assert.AreEqual("Stærðfræði", result3);
        }
        [TestMethod]
        public void testCreateAssignment()
        {
            // arrange
            var a1 = new CreateAssignmentViewModel
            {
                name = "Mooshak 2.0",
                description = "Make Mooshak free for us",
                startDate = new DateTime(2016, 05, 05, 00, 00, 00),
                endDate = new DateTime(2016, 06, 06, 23, 59, 59),
                solution = "free"
            };

            // act
            var beforeadd = _service.getAllAssignments();
            var result = _service.createAssignment(a1);
            var afteradd = _service.getAllAssignments();
            // assert

            Assert.AreEqual(6, beforeadd.assignments.Count);
            Assert.AreEqual(7, afteradd.assignments.Count);
        }
    }
}
