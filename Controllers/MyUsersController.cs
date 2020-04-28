using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GIP2LearnPlatform.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace GIP2LearnPlatform.Controllers
{
    public class MyUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyUsers
        public ActionResult Index()
        {
            ViewBag.Users = db.Users;
            return View(db.MyUsers.ToList());
        }

        // GET: MyUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // GET: MyUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,Role")] MyUser myUser)
        {
            if (ModelState.IsValid)
            {
                db.MyUsers.Add(myUser);

                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

                var u = new ApplicationUser { Email = myUser.Email, UserName = myUser.Email };
                string password = myUser.Password;
                var result = userManager.Create(u, password);
                if (result.Succeeded)
                {
                    if (myUser.Role == "teacher" || myUser.Role == "admin")
                        userManager.AddToRole(u.Id, myUser.Role);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myUser);
        }

        // GET: MyUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // POST: MyUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,Role")] MyUser myUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myUser);
        }

        // GET: MyUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // POST: MyUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyUser myUser = db.MyUsers.Find(id);
            db.MyUsers.Remove(myUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
