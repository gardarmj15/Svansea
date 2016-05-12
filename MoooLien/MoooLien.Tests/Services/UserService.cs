using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoooLien.Service;

namespace MoooLien.Tests.Services
{
    [TestClass]
    public class UserService
    {
        [TestMethod]
        public void TestGetUserByID()
        {
            // arrange
            const string ID = "1";
            var service = new UsersService();

            // act

            var result = service.getUserByID(ID);

            // assert

            Assert.IsNotNull(result);
        }
    }
}
