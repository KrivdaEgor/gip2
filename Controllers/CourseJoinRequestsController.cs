using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GIP2LearnPlatform.Models;

namespace GIP2LearnPlatform.Controllers
{
    public class CourseJoinRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseJoinRequests
        public ActionResult Index()
        {
            return View(db.CourseJoinRequests.ToList());
        }

        // GET: CourseJoinRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseJoinRequest courseJoinRequest = db.CourseJoinRequests.Find(id);
            if (courseJoinRequest == null)
            {
                return HttpNotFound();
            }
            return View(courseJoinRequest);
        }

        // GET: CourseJoinRequests/Create
        public ActionResult Create()
        {
            ViewBag.Courses = db.Courses;
            ViewBag.Users = db.Users;
            return View();
        }

        // POST: CourseJoinRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApprovedByStudent,ApprovedByTeacher,User,Course")] CourseJoinRequest courseJoinRequest)
        {
            ViewBag.Courses = db.Courses;
            ViewBag.Users = db.Users;
            if (ModelState.IsValid)
            {
                db.CourseJoinRequests.Add(courseJoinRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseJoinRequest);
        }

        // GET: CourseJoinRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Courses = db.Courses;
            ViewBag.Users = db.Users;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseJoinRequest courseJoinRequest = db.CourseJoinRequests.Find(id);
            if (courseJoinRequest == null)
            {
                return HttpNotFound();
            }
            return View(courseJoinRequest);
        }

        // POST: CourseJoinRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApprovedByStudent,ApprovedByTeacher,User,Course")] CourseJoinRequest courseJoinRequest)
        {
            ViewBag.Courses = db.Courses;
            ViewBag.Users = db.Users;
            if (ModelState.IsValid)
            {
                db.Entry(courseJoinRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseJoinRequest);
        }

        // GET: CourseJoinRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Courses = db.Courses;
            ViewBag.Users = db.Users;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseJoinRequest courseJoinRequest = db.CourseJoinRequests.Find(id);
            if (courseJoinRequest == null)
            {
                return HttpNotFound();
            }
            return View(courseJoinRequest);
        }

        // POST: CourseJoinRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Courses = db.Courses;
            ViewBag.Users = db.Users;
            CourseJoinRequest courseJoinRequest = db.CourseJoinRequests.Find(id);
            db.CourseJoinRequests.Remove(courseJoinRequest);
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
