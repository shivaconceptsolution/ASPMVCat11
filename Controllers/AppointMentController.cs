using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseConnectivityExample.Models;
using System.Data.Entity;
namespace DatabaseConnectivityExample.Controllers
{
    public class AppointMentController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: AppointMent
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AppointMent o)
        {
            Patient p = new Patient();
            p.PatientId = o.PateientId;
            p.Patientname = o.PatirntName;
            p.ContactNumber = o.ContactNumber;
            db.Patients.Add(p);
            db.SaveChanges();
            Doctor d = new Doctor();
            d.Id = o.DoctorId;
            d.Doctorname = o.DoctorName;
            d.VisitingDate = o.VisitingDate;
            d.DoctorFees = ""+o.DoctorFee;
            d.Medicinename = o.MedicineName;
            d.PatiendId = o.PateientId;
            db.Doctors.Add(d);
            db.SaveChanges();
            ViewBag.data = "Appintement added successfully";
            return View();
        }
        public ActionResult ViewAppointMent()
        {
            var s = db.Doctors.Include(e=>e.Patient);
            return View(s.ToList());
        }
    }
}