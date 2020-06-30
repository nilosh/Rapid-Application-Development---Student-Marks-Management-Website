using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAssignment.Models;

namespace WebAssignment.Methods
{
    public class Calculations
    {

        public static List<int> clculateMarks(IList<Unit_Enrolment> data)
        {
            List<int> totals = new List<int>();
            //int index = 0;

            foreach(var en in data)
            {
                totals.Add(en.Assessment_1 + en.Assessment_2 + en.Final_Exam);
            }

            return totals;
        }

        public static List<string> getGrades(List<int> data)
        {
            List<string> grades = new List<string>();

            foreach (var mark in data)
            {
                string grade = "";

                if (mark > 80)
                {
                    grade = "HD";
                }
                else if (mark > 70)
                {
                    grade = "D";
                }
                else if (mark > 60)
                {
                    grade = "CR";
                }
                else if (mark > 50)
                {
                    grade = "C";
                }
                else
                {
                    grade = "N";
                }

                grades.Add(grade);
            }

            return grades;
        }

        public static double CalculateRowAverage(IList<Unit_Enrolment> data)
        {
            double total = 0;
            foreach (var en in data)
            {
                total += (en.Assessment_1 + en.Assessment_2 + en.Final_Exam);
            }

            return total/data.Count();
        }

        public static string GetGrade(double score)
        {
            string grade = "";
            if (score > 80)
            {
                grade = "HD";
            }
            else if(score > 70)
            {
                grade = "D";
            }
            else if (score > 60)
            {
                grade = "CR";
            }
            else if (score > 50)
            {
                grade = "C";
            }
            else
            {
                grade = "N";
            }

            return grade;
        }


    }
}