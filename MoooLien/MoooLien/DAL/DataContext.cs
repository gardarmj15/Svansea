using MoooLien.Models;
using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MoooLien.DAL
{
    public class DataContext
    {

    }
    public class DefaultConnection : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }

        /*public System.Data.Entity.DbSet<MoooLien.Models.Course> Courses { get; set; }*/
    }
    /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Convension.Remove<PluralizingTableNameConvention>();
    }*/
}