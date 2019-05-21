using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseConnectivityExample.Models;
namespace DatabaseConnectivityExample.Controllers
{
    public class RegController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Reg
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Reg r)
        {
            var s = (from c in db.Regs where c.Email.Equals(r.Email) select c).FirstOrDefault();
            if (s == null)
            {
                db.Regs.Add(r);
                db.SaveChanges();
                ViewBag.data = "Registration SuccessFully";
            }
            else
            {
                ViewBag.data = "EmailID Already Exist";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Reg r)
        {
            var s = (from c in db.Regs where c.Email.Equals(r.Email) && c.Pass.Equals(r.Pass) select c).FirstOrDefault();
            if(s!=null)
            {
                TempData["uid"] = r.Email;
                TempData.Keep();
                return RedirectToAction("Index", "UserDash");
            }
            else
            {
                ViewBag.data = "Invalid emailid and password";
            }
            return View();
        }

    }
}