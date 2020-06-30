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
    public class LoginsController : Controller
    {

        private Assignment_2_CSI2441Entities1 db = new Assignment_2_CSI2441Entities1();

        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(WebAssignment.Models.Login userModel, FormCollection Form)
        {

                var userLogin = db.Logins.Where(login => login.UserEmail == userModel.UserEmail && login.UserPassword == userModel.UserPassword).FirstOrDefault();

                if (userLogin == null)
                {
                    
                    return View("Index", userModel);
                }
                else
                {

                    Session["sessionID"] = userLogin.UserID.ToString();

    
                    if (userLogin.UserType == 1)
                    {
                        return RedirectToAction("Options", "Unit_Enrolment");
                    
                    }
                    else
                    {
                        return RedirectToAction("Options", "Units");
                    }
                }
            }

        }


    }
