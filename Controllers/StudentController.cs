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
            //  var s = db.Students.ToList(); //Select Operation
            var s = (from c in db.Students select c).ToList();
            return View(s);
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            // db.Students.Add(s);  //Insert Opeation
            Student s1 = new Student();
            s1.Id = s.Id;
            s1.Name = s.Name;
           
            db.Students.Add(s1);
            db.SaveChanges();  //it is used to reflect the modification of Object to database
            ViewBag.Data = "Data Added Successfully";
            return RedirectToAction("Index");
           // return View();
        }
        public ActionResult EditStudent(int id)
        {
            //var s = db.Students.Find(id); //it will search record only by primary key column
            var s = (from c in db.Students where c.Id == id select c).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult EditStudent(Student s1)
        {
            //  db.Entry(s1).State = EntityState.Modified; //it is used to modify object
            var s = db.Students.Find(s1.Id);
            s.Name = s1.Name;
            s.Branch = s1.Branch;
            s.Fees = s1.Fees;

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