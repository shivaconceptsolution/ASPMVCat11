using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseConnectivityExample.Models;
namespace DatabaseConnectivityExample.Controllers
{
    public class UserDashController : Controller
    {
        Database1Entities db = new Database1Entities();
        
        // GET: UserDash
        public ActionResult Index()
        {
            if (TempData["uid"] == null)
                return RedirectToAction("Login", "Reg");
            else
            {
                TempData.Keep();
                String uid = TempData["uid"].ToString();

                var s = (from c in db.Regs where c.Email.Equals(uid) select c).FirstOrDefault();
                return View(s);
            }
        }
        public ActionResult Logout()
        {
            TempData.Remove("uid");
            return RedirectToAction("Login", "Reg");

        }
    }
}