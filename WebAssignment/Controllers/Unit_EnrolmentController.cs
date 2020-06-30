using System;
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
    public class Unit_EnrolmentController : Controller
    {
        private Assignment_2_CSI2441Entities1 db = new Assignment_2_CSI2441Entities1();

        public ActionResult Options()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "2")
            {
                return RedirectToAction("Index", "Logins");
            }
            return View();
        }

        // GET: Unit_Enrolment
        public ActionResult Index()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "2")
            {
                return RedirectToAction("Index", "Logins");
            }

            var unit_Enrolment = db.Unit_Enrolment.Include(u => u.Unit);
            return View(unit_Enrolment.ToList());
        }

        // GET: Unit_Enrolment/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "2")
            {
                return RedirectToAction("Index", "Logins");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_Enrolment unit_Enrolment = db.Unit_Enrolment.Find(id);
            if (unit_Enrolment == null)
            {
                return HttpNotFound();
            }
            return View(unit_Enrolment);
        }

        // GET: Unit_Enrolment/Create
        public ActionResult Create()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "2")
            {
                return RedirectToAction("Index", "Logins");
            }

            ViewBag.UnitCode = new SelectList(db.Units, "UnitCode", "UnitCode");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID");
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitCode,Year,Semester,Assessment_1,Assessment_2,Final_Exam,Enrolment_ID,StudentID")] Unit_Enrolment unit_Enrolment)
        {
            if (ModelState.IsValid)
            {
                db.Unit_Enrolment.Add(unit_Enrolment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.UnitCode = new SelectList(db.Units, "UnitCode", "UnitTitle", unit_Enrolment.UnitCode);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID", unit_Enrolment.StudentID);
            return View(unit_Enrolment);
        }

        // GET: Unit_Enrolment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "2")
            {
                return RedirectToAction("Index", "Logins");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_Enrolment unit_Enrolment = db.Unit_Enrolment.Find(id);
            if (unit_Enrolment == null)
            {
                return HttpNotFound();
            }

            

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID", unit_Enrolment.StudentID);
            ViewBag.UnitCode = new SelectList(db.Units, "UnitCode", "UnitTitle", unit_Enrolment.UnitCode);
            return View(unit_Enrolment);
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Unit_Enrolment unit_Enrolment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit_Enrolment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID", unit_Enrolment.StudentID);
            ViewBag.UnitCode = new SelectList(db.Units, "UnitCode", "UnitTitle", unit_Enrolment.UnitCode);
            return View(unit_Enrolment);
        }

        // GET: Unit_Enrolment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "2")
            {
                return RedirectToAction("Index", "Logins");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_Enrolment unit_Enrolment = db.Unit_Enrolment.Find(id);
            if (unit_Enrolment == null)
            {
                return HttpNotFound();
            }
            return View(unit_Enrolment);
        }

        // POST: Unit_Enrolment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit_Enrolment unit_Enrolment = db.Unit_Enrolment.Find(id);
            db.Unit_Enrolment.Remove(unit_Enrolment);
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
