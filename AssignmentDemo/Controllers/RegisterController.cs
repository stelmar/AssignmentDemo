using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignmentDemo.DAL;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace AssignmentDemo.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        
[HttpGet]
        public ActionResult Register() 

        { 

            return View();

    }

    [HttpPost]

    [ValidateAntiForgeryToken]

    public ActionResult Register(User user)

    {

        if (ModelState.IsValid)

        {

            using (ProgramUserEntities entity = new ProgramUserEntities())

            {

                    entity.Users.Add(user);

                    entity.SaveChanges();

                ModelState.Clear();

                user = null;

                ViewBag.Message = "Successfully Registration Done";
                    return RedirectToAction("GetPaidPrograms", "Programs");

                }

        }

            return View(user);

    }
        [Authorize()]
        public ActionResult GetUserDetails()
        {
            var UserId = HttpContext.User.Identity.GetUserId();
            

            return View(UserId);
        }
        [HttpGet]
        public ActionResult EditProfile(int id)
        {

            using (ProgramUserEntities entities = new ProgramUserEntities())
            {
                
                return View(entities.Users.FirstOrDefault(p => p.UserId == id));
            }

        }

        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            using (ProgramUserEntities entity = new ProgramUserEntities())

            {

                entity.Entry(user).State = EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("Index","Programs");

            }

        }

} 
}