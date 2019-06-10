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
            return View();
        }
        public ActionResult Search(string id)
        {
            var s = from c in db.Students where c.Sname.StartsWith(id) select c;
            return PartialView(s.ToList());
        }

    }
}