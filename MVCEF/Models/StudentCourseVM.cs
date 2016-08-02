using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEF.Models
{
    public class StudentCourseVM
    {
        public List<Student> StudentList { get; set; }
        public List<Course> CourseList { get; set; }
    }
}
