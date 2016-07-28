using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCGrid.Models;

namespace MVCGrid.Controllers
{
    public class HomeController : Controller
    {
        Data_Context db = new Data_Context();
        // GET: Home
        public ActionResult Index()
        {
            Student newStudent = new Student();
            newStudent.Name = "Gopi";
            newStudent.Class = "Unknown";
            newStudent.Gender = "Male";
            return View(newStudent);
        }

        public ActionResult AboutUs()
        {
            List<Student> studentList = new List<Student>();
            Student s1 = new Student {Name="Gopi",Class="Unknown",Gender="Male" };
            Student s2 = new Student { Name = "Dhaniska", Class = "Film", Gender = "FeMale" };
            Student s3 = new Student { Name = "Prasad", Class = "19", Gender = "Male" };
            Student s4 = new Student { Name = "Nivedha Thomas", Class = "Heroine", Gender = "FeMale" };
            studentList.Add(s1);
            studentList.Add(s2);
            studentList.Add(s3);
            studentList.Add(s4);
            return View(studentList);
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register obj)
        {
            db.AddUser(obj);
            return RedirectToAction("StudentIndex");
        }

        public ActionResult StudentIndex()
        {
            List<Register> obj = db.GetUsers();
            return View(obj);
        }

        public ActionResult UserDetail(string id)
        {
            Register newReg = db.GetUser(id);
            return View(newReg);
        }
        public ActionResult UserEdit(string id)
        {
            Register newreg = db.GetUser(id);
            return View(newreg);
        }
        [HttpPost]
        public ActionResult UserEdit(Register updateReg)
        {
            db.UpdateUser(updateReg);
            return RedirectToAction("StudentIndex");
        }
        public ActionResult UserDelete(string id)
        {
            Register newreg = db.GetUser(id);
            return View(newreg);
        }
        public ActionResult DeleteUser(string id)
        {
            //string id = Request["id"].ToString();
            db.DeleteUser(id);
            return RedirectToAction("StudentIndex");
        }
    }
}