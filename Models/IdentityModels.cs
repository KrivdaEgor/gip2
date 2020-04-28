using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GIP2LearnPlatform.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<GIP2LearnPlatform.Models.Classroom> Classrooms { get; set; }

        public System.Data.Entity.DbSet<GIP2LearnPlatform.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<GIP2LearnPlatform.Models.Lesson> Lessons { get; set; }

        public System.Data.Entity.DbSet<GIP2LearnPlatform.Models.Planning> Plannings { get; set; }

        public System.Data.Entity.DbSet<GIP2LearnPlatform.Models.CourseRequest> CourseRequests { get; set; }

        public System.Data.Entity.DbSet<GIP2LearnPlatform.Models.MyUser> MyUsers { get; set; }

        public System.Data.Entity.DbSet<GIP2LearnPlatform.Models.CourseJoinRequest> CourseJoinRequests { get; set; }
    }
}