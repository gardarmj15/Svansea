using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoooLien.Service;
using Moolien.Tests;
using MoooLien.Models.Entities;
using MoooLien.Models;

namespace MoooLien.Tests.Services
{
    [TestClass]
    public class TestCourseService
    {
        private CourseService _service;

        [TestInitialize]
        public void Initialize()
        {
            var mockDB = new MockDatabase();
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

            _service = new CourseService(mockDB);
        }

        [TestMethod]
        public void TestGetCourseByID2()
        {
            // arrange
            const int ID = 2;


            // act

            var result = _service.getCourseByID(ID);

            // assert

            Assert.AreEqual(2, result.ID);
            //Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void TestGetCourseByID3()
        {
            // arrange
            const int ID = 3;


            // act

            var result = _service.getCourseByID(ID);

            // assert

            Assert.AreEqual(3, result.ID);
            //Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void TestGetCourseByID4()
        {
            // arrange
            const int ID = 4;


            // act

            var result = _service.getCourseByID(ID);

            // assert

            Assert.AreEqual(4, result.ID);
            //Assert.AreEqual(1, result.Count);
        }
    }
}
