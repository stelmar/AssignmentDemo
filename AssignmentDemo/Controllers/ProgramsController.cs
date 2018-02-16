using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignmentDemo.DAL;

namespace AssignmentDemo.Controllers
{
    public class ProgramsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (ProgramUserEntities entities = new ProgramUserEntities())
            {
                //return Request.CreateResponse(HttpStatusCode.OK, entities.Programs.Where(e => e.IsPaidProgram == true).ToList());
                return  View(entities.Programs.ToList());
            }

        }
        [HttpGet]
        public ActionResult GetPaidPrograms()
        {
            
            
                using (ProgramUserEntities entities = new ProgramUserEntities())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, entities.Programs.Where(e => e.IsPaidProgram == true).ToList());
                    return View(entities.Programs.Where(e => e.IsPaidProgram == true).ToList());
                }
            
            

        }



        [HttpGet]
        public ActionResult LoadProgramsById(int id)
        {
            using (ProgramUserEntities entities = new ProgramUserEntities())
            {

                var entity = entities.Programs.FirstOrDefault(p => p.ProgramId == id);
                return View(entity);
            }
        }
        [HttpGet]
        public ActionResult CreatePrograms()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePrograms(Program program)
        {

            using (ProgramUserEntities entities = new ProgramUserEntities())
            {

                entities.Programs.Add(program);
                entities.SaveChanges();
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult EditProgram(int id)
        {

            using (ProgramUserEntities entities = new ProgramUserEntities())
            {

               

                return View(entities.Programs.FirstOrDefault(p => p.ProgramId == id));
            }
            
        }

        [HttpPost]
        
        public ActionResult EditProgram(Program program)
        {
            using (ProgramUserEntities entities = new ProgramUserEntities())
            {
                entities.Programs.Add(program);
                entities.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult DeleteProgram(int id)
        {
            using (ProgramUserEntities entities = new ProgramUserEntities())
            {

               

                return View(entities.Programs.Find(id));
            }
        }

        [HttpPost, ActionName("DeleteProgram")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (ProgramUserEntities entities = new ProgramUserEntities())
            {
                entities.Programs.Remove(entities.Programs.FirstOrDefault(p => p.ProgramId == id));
                entities.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }
    }
}