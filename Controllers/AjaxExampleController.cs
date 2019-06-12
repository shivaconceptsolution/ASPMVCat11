using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication25.Models;
namespace WebApplication25.Controllers
{
    public class AjaxExampleController : Controller
    {

        SchoolDB db = new SchoolDB();
        // GET: AjaxExample
        public ActionResult Index()
        {
           
            ViewBag.data = new SelectList( db.Students,"Sname","Sname" );      
            return View();
        }
        public ActionResult Search(string id)
        {
            var s = from c in db.Students where c.Sname.StartsWith(id) select c;
            return PartialView(s.ToList());
        }
        public ActionResult SubmitData()
        {
            return View();
        }
        public ActionResult InsertData()
        {
            Student s = new Student();
            s.Rno = int.Parse(Request["rno"]);
            s.Sname = Request["name"];
            s.Branch = Request["branch"];
            s.Fees = int.Parse(Request["fees"]);
            db.Students.Add(s);
            db.SaveChanges();
            ViewBag.data = "Data Inserted Successfully";
            return PartialView();
        }
    }
}