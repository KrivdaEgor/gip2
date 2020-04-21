﻿using System;
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
    public class PlanningsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Plannings
        public ActionResult Index()
        {
            return View(db.Plannings.ToList());
        }

        // GET: Plannings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planning planning = db.Plannings.Find(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            return View(planning);
        }

        // GET: Plannings/Create
        public ActionResult Create()
        {
            ViewBag.Lessons = db.Lessons;
            return View();
        }

        // POST: Plannings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Lessons")] Planning planning)
        {
            ViewBag.Lessons = db.Lessons;
            if (ModelState.IsValid)
            {
                db.Plannings.Add(planning);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planning);
        }

        // GET: Plannings/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Lessons = db.Lessons;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planning planning = db.Plannings.Find(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            return View(planning);
        }

        // POST: Plannings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Lessons")] Planning planning)
        {
            ViewBag.Lessons = db.Lessons;
            if (ModelState.IsValid)
            {
                db.Entry(planning).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planning);
        }

        // GET: Plannings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planning planning = db.Plannings.Find(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            return View(planning);
        }

        // POST: Plannings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planning planning = db.Plannings.Find(id);
            db.Plannings.Remove(planning);
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