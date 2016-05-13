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
    public class TestUsersInCourse
    {
        private UsersInCourseService _service;

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

            _service = new UsersInCourseService(mockDB);
        }
        [TestMethod]
        public void TestUserExists()
        {
            // arrange
            const string uid1 = "1";
            const string uid2 = "4";
            const int cid1 = 2;
            const int cid2 = 1;
            const int student = 1;
            const int teacher = 2;

            // act

            var result1 = _service.userExists(uid1, cid1, teacher);
            var result2 = _service.userExists(uid2, cid2, student);
            var result3 = _service.userExists(uid2, cid2, teacher);


            // assert

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }
        [TestMethod]
        public void TestCreateLink()
        {
            const string uid1 = "1";
            const string uid2 = "8";
            const int cid1 = 5;
            const int cid2 = 1;
            const int student = 1;
            const int teacher = 2;

            // act

            var result1 = _service.userExists(uid1, cid1, teacher);
            var result2 = _service.userExists(uid2, cid2, student);
            var result3 = _service.userExists(uid1, cid2, student);


            // assert

            //Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            //Assert.IsTrue(result3);
        }
    }
}
