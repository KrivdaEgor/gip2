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
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "teacher" };
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
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