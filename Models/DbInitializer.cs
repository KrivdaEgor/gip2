using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GIP2LearnPlatform.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var adminRole = new IdentityRole { Name = "admin" };
            var teacherRole = new IdentityRole { Name = "teacher" };
            roleManager.Create(adminRole);
            roleManager.Create(teacherRole);

            {
                var u = new ApplicationUser { Email = "admin@test.com", UserName = "admin@test.com" };
                string password = "123456";
                var result = userManager.Create(u, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(u.Id, adminRole.Name);
                }
            }
            {
                var u = new ApplicationUser { Email = "teacher@test.com", UserName = "teacher@test.com" };
                string password = "123456";
                var result = userManager.Create(u, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(u.Id, teacherRole.Name);
                }
            }
            {
                var u = new ApplicationUser { Email = "user@test.com", UserName = "user@test.com" };
                string password = "123456";
                var result = userManager.Create(u, password);
            }
            {
                var u = new ApplicationUser { Email = "user2@test.com", UserName = "user2@test.com" };
                string password = "123456";
                var result = userManager.Create(u, password);
            }

            db.Courses.Add(new Course { Code = "GIP1", Name = "Integrated Project", StudentPoints = 4 });
            db.Courses.Add(new Course { Code = "JAVA", Name = "Java Basis", StudentPoints = 6 });
            db.Courses.Add(new Course { Code = "OOAN", Name = "Object Oriented Analysis", StudentPoints = 6 });

            db.Classrooms.Add(new Classroom { Location = "Floor 1, h. 24", Resources = "TV", Capacity = 30 });
            db.Classrooms.Add(new Classroom { Location = "Floor 1, h. 25", Resources = "Computer", Capacity = 22 });
            db.Classrooms.Add(new Classroom { Location = "Floor 1, h. 26", Resources = "", Capacity = 22 });
            db.Classrooms.Add(new Classroom { Location = "Gym", Resources = "barbells, balls", Capacity = 100 });
            base.Seed(db);
        }
    }
}