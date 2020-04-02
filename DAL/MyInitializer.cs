using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GIP2.Models;

namespace GIP2.DAL
{
    public class MyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
        }
    }
}