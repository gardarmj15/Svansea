using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Moolien.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            Database.SetInitializer<DataContext>(new DropCreateDatabaseAlways<DataContext>());        }
    }
    public DbSet<>
}