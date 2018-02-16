using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignmentDemo.DAL;
using AssignmentDemo.Models;
using System.Web.Security;

namespace AssignmentDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            //using (ProgramUserEntities userEntity = new ProgramUserEntities())
            //    // if


            //        return RedirectToAction("Index", "Programs");
            //   // else
            //        return View("Index");
            ////

            ProgramUserEntities usersEntities = new ProgramUserEntities();
            var userId = usersEntities.Users.FirstOrDefault(u => u.Username == user.Username);

            string message = string.Empty;
            if(userId!=null)
            {

                message = "Successful Login";
                return RedirectToAction("GetPaidPrograms", "Programs");
            }
            else
            {
                message = "Invalid Login";
            }

            ViewBag.Message = message;
            return View(user);


        }

    }
    }