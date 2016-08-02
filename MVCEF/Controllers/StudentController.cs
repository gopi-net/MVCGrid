using MVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEF.Controllers
{
    public class StudentController : Controller
    {
        StudentEntities db = new StudentEntities();

        // GET: Student
        public ActionResult Index()
        {
            StudentCourseVM obj = new StudentCourseVM();
            obj.StudentList= db.Students.ToList();
            obj.CourseList = db.Courses.ToList();
            return View(obj);
        }
    }
}