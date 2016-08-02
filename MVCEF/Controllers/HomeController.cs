using MVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEF.Controllers
{
    public class HomeController : Controller
    {
        MVCEntities db = new MVCEntities();

        // GET: Home
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
            db.Employees.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Employee obj = db.Employees.SingleOrDefault(x=>x.EmpId==id);
            return View(obj);
        }
        public ActionResult Delete(int id)
        {
            Employee obj = db.Employees.SingleOrDefault(x=>x.EmpId==id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            int eid = int.Parse(id);
            Employee obj = db.Employees.SingleOrDefault(x=>x.EmpId==eid);
            db.Employees.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Employee obj = db.Employees.SingleOrDefault(x=>x.EmpId==id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Employee newData)
        {
            Employee oldData = db.Employees.SingleOrDefault(x=>x.EmpId==newData.EmpId);
            oldData.Ename = newData.Ename;
            oldData.DeptName = newData.DeptName;
            oldData.Position = newData.Position;
            oldData.Sal = newData.Sal;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}