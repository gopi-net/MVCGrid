using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCGrid.Models
{
    public  class Login
    {
        public string Uid { get; set; }
        public string Pwd { get; set; }
    }

    public class Student
    {
        public string  Name { get; set; }

        public string Class { get; set; }

        public string Gender { get; set; }
    }

    public class Registers
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
