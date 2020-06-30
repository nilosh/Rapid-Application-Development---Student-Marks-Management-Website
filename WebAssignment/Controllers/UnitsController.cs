﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAssignment.Models;

namespace WebAssignment.Controllers
{
    public class UnitsController : Controller
    {
        private Assignment_2_CSI2441Entities1 db = new Assignment_2_CSI2441Entities1();

        public ActionResult Options()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "1")
            {
                return RedirectToAction("Index", "Logins");
            }
            return View();
        }

        // GET: Units
        public ActionResult Index()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "1")
            {
                return RedirectToAction("Index", "Logins");
            }

            return View(db.Units.ToList());
        }

        // GET: Units/Details/5
        public ActionResult Details(string id)
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "1")
            {
                return RedirectToAction("Index", "Logins");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "1")
            {
                return RedirectToAction("Index", "Logins");
            }

            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitCode,UnitTitle,UnitCoordinator,UnitOuttlinePdf")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: Units/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "1")
            {
                return RedirectToAction("Index", "Logins");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitCode,UnitTitle,UnitCoordinator,UnitOuttlinePdf")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "1")
            {
                return RedirectToAction("Index", "Logins");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
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
