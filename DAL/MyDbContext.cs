using GIP2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GIP2.DAL
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("MyDbContext")
        {
            Database.SetInitializer(new MyInitializer());
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}