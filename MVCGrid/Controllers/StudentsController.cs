using MVCGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGrid.Controllers
{
    public class StudentsController : Controller
    {
        StudentCodeFirst db = new StudentCodeFirst();
        // GET: Students
        public ActionResult Index()
        {
            List<StudentFirst> sList = db.Students.ToList();
            return View(sList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentFirst sObj)
        {
            db.Students.Add(sObj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}