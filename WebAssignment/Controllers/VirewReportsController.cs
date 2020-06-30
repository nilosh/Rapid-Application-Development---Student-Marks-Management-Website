using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAssignment.Models;
using WebAssignment.Methods;

namespace WebAssignment.Controllers
{
    public class VirewReportsController : Controller
    {
        private Assignment_2_CSI2441Entities1 db = new Assignment_2_CSI2441Entities1();

        // GET: 
        public ActionResult Index()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "2")
            {
                return RedirectToAction("Index", "Logins");
            }
            var unit_Enrolment = db.Unit_Enrolment.Include(u => u.Unit);
            return View(unit_Enrolment.ToList());
        }

        [HttpGet]
        public ActionResult UnitCode()
        {
            if (Session["sessionID"] == null || Session["sessionID"].ToString() != "2")
            {
                return RedirectToAction("Index", "Logins");
            }

            List<Unit_Enrolment> units = new List<Unit_Enrolment>();

            ViewBag.unitcode = new SelectList(db.Units, "unitcode", "unitcode");

            return View(units);
        }

        [HttpPost]
        public ActionResult UnitCode(FormCollection input)
        {
            System.Diagnostics.Debug.WriteLine(input["UnitCode"]);

            List<Unit_Enrolment> data = new List<Unit_Enrolment>();
            string unitcode = input["UnitCode"];
            data = db.Unit_Enrolment.Where(x => x.UnitCode == unitcode).ToList();
            
            List<int> totals = new List<int>();
            totals = Methods.Calculations.clculateMarks(data);

            List<string> grades = new List<string>();
            grades = Methods.Calculations.getGrades(totals);

            double average = Methods.Calculations.CalculateRowAverage(data);
            string grade = Methods.Calculations.GetGrade(average);



            ViewBag.grades = grades;
            ViewBag.grade = grade;
            ViewBag.average = average;
            ViewBag.totals = totals;
            ViewBag.unitcode = new SelectList(db.Units, "unitcode", "unitcode");
            return View(data);
        }



        [HttpGet]
        public ActionResult StudentID()
        {

            List<Unit_Enrolment> units = new List<Unit_Enrolment>();

            ViewBag.StudentID = new SelectList(db.Students ,"StudentID", "StudentID");

            return View(units);
        }


        [HttpPost]
        public ActionResult StudentID(FormCollection input)
        {

            List<Unit_Enrolment> data = new List<Unit_Enrolment>();
            string StudentID = input["StudentID"];
            data = db.Unit_Enrolment.Where(x => x.StudentID == StudentID).ToList();

            List<int> totals = new List<int>();
            totals = Methods.Calculations.clculateMarks(data);

            List<string> grades = new List<string>();
            grades = Methods.Calculations.getGrades(totals);

            double average = Methods.Calculations.CalculateRowAverage(data);
            string grade = Methods.Calculations.GetGrade(average);

            ViewBag.grades = grades;
            ViewBag.grade = grade;
            ViewBag.average = average;
            ViewBag.totals = totals;
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID");

            return View(data);
        }



        [HttpGet]
        public ActionResult Semester()
        {

            List<Unit_Enrolment> units = new List<Unit_Enrolment>();

            ViewBag.Semester = new SelectList(db.Unit_Enrolment.Distinct(), "Semester", "Semester");

            return View(units);
        }


        [HttpPost]
        public ActionResult Semester(FormCollection input)
        {

            List<Unit_Enrolment> data = new List<Unit_Enrolment>();
            int Semester = Convert.ToInt32(input["Semester"]);

            data = db.Unit_Enrolment.Where(x => x.Semester == Semester).ToList();

            List<int> totals = new List<int>();
            totals = Methods.Calculations.clculateMarks(data);

            List<string> grades = new List<string>();
            grades = Methods.Calculations.getGrades(totals);

            double average = Methods.Calculations.CalculateRowAverage(data);
            string grade = Methods.Calculations.GetGrade(average);

            ViewBag.grades = grades;
            ViewBag.grade = grade;
            ViewBag.average = average;
            ViewBag.totals = totals;
            ViewBag.Semester = new SelectList(db.Unit_Enrolment.Distinct(), "Semester", "Semester");

            return View(data);
        }


        [HttpGet]
        public ActionResult Many()
        {

            List<Unit_Enrolment> units = new List<Unit_Enrolment>();

            units = db.Unit_Enrolment.ToList();

            List<int> totals = new List<int>();
            totals = Methods.Calculations.clculateMarks(units);

            List<string> grades = new List<string>();
            grades = Methods.Calculations.getGrades(totals);

            double average = Methods.Calculations.CalculateRowAverage(units);
            string grade = Methods.Calculations.GetGrade(average);

            ViewBag.grades = grades;
            ViewBag.grade = grade;
            ViewBag.average = average;
            ViewBag.totals = totals;

            return View(units);
        }


        [HttpGet]
        public ActionResult Year()
        {

            List<Unit_Enrolment> units = new List<Unit_Enrolment>();

            ViewBag.Year = new SelectList(db.Unit_Enrolment, "Year", "Year");

            return View(units);
        }


        [HttpPost]
        public ActionResult Year(FormCollection input)
        {

            List<Unit_Enrolment> data = new List<Unit_Enrolment>();
            int Year = Convert.ToInt32(input["Year"]);

            data = db.Unit_Enrolment.Where(x => x.Year == Year).ToList();

            List<int> totals = new List<int>();
            totals = Methods.Calculations.clculateMarks(data);

            List<string> grades = new List<string>();
            grades = Methods.Calculations.getGrades(totals);

            double average = Methods.Calculations.CalculateRowAverage(data);
            string grade = Methods.Calculations.GetGrade(average);

            ViewBag.grades = grades;
            ViewBag.grade = grade;
            ViewBag.average = average;
            ViewBag.totals = totals;
            ViewBag.Year = new SelectList(db.Unit_Enrolment.Distinct(), "Year", "Year");

            return View(data);
        }

    }
}
