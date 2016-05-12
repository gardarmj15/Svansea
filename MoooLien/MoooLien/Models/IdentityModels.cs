using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoooLien.Models.Entities;

namespace MoooLien.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public interface IDataContext
    {
        IDbSet<Assignment> Assignments { get; set; }
        IDbSet<Course> Courses { get; set; }
        IDbSet<UserRoles> UserRoles { get; set; }
        IDbSet<UsersInCourse> UsersInCourse { get; set; }
        IDbSet<AssignmentsInCourse> AssingmentInCourse { get; set; }
        IDbSet<File> Files { get; set; }
        int SaveChanges();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        public IDbSet<Assignment> Assignments { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<UserRoles> UserRoles { get; set; }
        public IDbSet<UsersInCourse> UsersInCourse { get; set; }
        public IDbSet<AssignmentsInCourse> AssingmentInCourse { get; set; }
        public IDbSet<File> Files { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<MoooLien.Models.Entities.Course> Courses { get; set; }

        //public System.Data.Entity.DbSet<MoooLien.Models.Entities.Assignment> Assignments { get; set; }
    }
}