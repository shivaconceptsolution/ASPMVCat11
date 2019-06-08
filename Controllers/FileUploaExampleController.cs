using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCExample.Models;
namespace MVCExample.Controllers
{
    public class FileUploaExampleController : Controller
    {
        Database1Entities db = new Database1Entities();
       
        // GET: FileUploaExample
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            
            file.SaveAs(Server.MapPath("img/")+Path.GetFileName(file.FileName));
            tbl_upload t = new tbl_upload();
            t.imgname = Path.GetFileName(file.FileName);
            db.tbl_upload.Add(t);
            db.SaveChanges();
            return View();
        }
        public ActionResult ViewImage()
        {
            return View(db.tbl_upload.ToList());
        }
    }
}