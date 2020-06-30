using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAssignment.Models;

namespace WebAssignment.Controllers
{
    public class StudentsController : Controller
    {
        private Assignment_2_CSI2441Entities1 db = new Assignment_2_CSI2441Entities1();

        // GET: Students
        public ActionResult Index()
        {
            if(Session["sessionID"] == null || Session["sessionID"].ToString() != "1")
            {
                return RedirectToAction("Index", "Logins");
            }
            return View(db.Students.ToList());
        }

       
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
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "1")
            {
                return RedirectToAction("Index", "Logins");
            }

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Student student)
        {

            string fileName = Path.GetFileNameWithoutExtension(student.PhotoFile.FileName);
            string extension = Path.GetExtension(student.PhotoFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            student.StudentPhoto = "~/StudentPics/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/StudentPics/"), fileName);
            student.PhotoFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Student student)
        {
           string fileName = Path.GetFileName(student.PhotoFile.FileName);
            student.StudentPhoto = "~/StudentPics/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/StudentPics/"), fileName);
            student.PhotoFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
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
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
