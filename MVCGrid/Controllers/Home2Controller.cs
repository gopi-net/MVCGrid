using MVCGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGrid.Controllers
{
    public class Home2Controller : Controller
    {
        EmployeeEntity db = new EmployeeEntity();

        // GET: Home2
        public ActionResult Index()
        {
            List<Employee> empList = db.Employees.ToList();
            return View(empList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            obj.DeptName = Request.Form["DeptName"].ToString();
            db.Employees.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return View();
        }


    }
}