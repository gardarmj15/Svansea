using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeDbSet;
using System.Data.Entity;
using MoooLien.Models;
using MoooLien.Models.Entities;

namespace Moolien.Tests
{
    /// <summary>
    /// This is an example of how we'd create a fake database by implementing the 
    /// same interface that the BookeStoreEntities class implements.
    /// </summary>
    public class MockDatabase : IAppDataContext
    {
        /// <summary>
        /// Sets up the fake database.
        /// </summary>
        public MockDatabase()
        {
            // We're setting our DbSets to be InMemoryDbSets rather than using SQL Server.
            this.Assignments = new InMemoryDbSet<Assignment>();
            this.Courses = new InMemoryDbSet<Course>();
            this.UserRoles = new InMemoryDbSet<UserRoles>();
            this.UsersInCourse = new InMemoryDbSet<UsersInCourse>();
            this.AssingmentInCourse = new InMemoryDbSet<AssignmentsInCourse>();
            this.Files = new InMemoryDbSet<File>();
            this.Users = new InMemoryDbSet<ApplicationUser>();
            this.Solutions = new InMemoryDbSet<Solution>();
        }

        public IDbSet<Assignment> Assignments { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<UserRoles> UserRoles { get; set; }
        public IDbSet<UsersInCourse> UsersInCourse { get; set; }
        public IDbSet<AssignmentsInCourse> AssingmentInCourse { get; set; }
        public IDbSet<File> Files { get; set; }
        public IDbSet<ApplicationUser> Users { get; set; }
        public IDbSet<Solution> Solutions { get; set; }

        public int SaveChanges()
        {
            // Pretend that each entity gets a database id when we hit save.
            int changes = 0;
            //changes += DbSetHelper.IncrementPrimaryKey<Author>(x => x.AuthorId, this.Authors);
            //changes += DbSetHelper.IncrementPrimaryKey<Book>(x => x.BookId, this.Books);

            return changes;
        }

        public void Dispose()
        {
            // Do nothing!
        }
    }
}
