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
    public class CourseRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseRequests
        public ActionResult Index()
        {
            return View(db.CourseRequests.ToList());
        }

        // GET: CourseRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRequest courseRequest = db.CourseRequests.Find(id);
            if (courseRequest == null)
            {
                return HttpNotFound();
            }
            return View(courseRequest);
        }

        // GET: CourseRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Course,User,Approved")] CourseRequest courseRequest)
        {
            if (ModelState.IsValid)
            {
                db.CourseRequests.Add(courseRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseRequest);
        }

        // GET: CourseRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRequest courseRequest = db.CourseRequests.Find(id);
            if (courseRequest == null)
            {
                return HttpNotFound();
            }
            return View(courseRequest);
        }

        // POST: CourseRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Course,User,Approved")] CourseRequest courseRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseRequest);
        }

        // GET: CourseRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRequest courseRequest = db.CourseRequests.Find(id);
            if (courseRequest == null)
            {
                return HttpNotFound();
            }
            return View(courseRequest);
        }

        // POST: CourseRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseRequest courseRequest = db.CourseRequests.Find(id);
            db.CourseRequests.Remove(courseRequest);
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
