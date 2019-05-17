using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseConnectivityExample.Models;
using System.Data.Entity;
namespace DatabaseConnectivityExample.Controllers
{
    public class StudentController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Student
        public ActionResult Index()
        {
            var s = db.Students.ToList(); //Select Operation
            return View(s);
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            db.Students.Add(s);  //Insert Opeation
            db.SaveChanges();
            ViewBag.Data = "Data Added Successfully";
            return RedirectToAction("Index");
           // return View();
        }
        public ActionResult EditStudent(int id)
        {
            var s = db.Students.Find(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult EditStudent(Student s1)
        {
            db.Entry(s1).State =EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStudent(int id)
        {
            var s = db.Students.Find(id);
            db.Students.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}