using MVCGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGrid.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        // Post: Login  using formcollection parameters
        //[HttpPost]
        //public ActionResult Login(FormCollection formObj)
        //{
        //    Response.Write("This is http request");
        //    string uname = formObj["Uid"];
        //    string pwd = formObj["Pwd"];
        //    if (uname=="admin" && pwd=="admin")
        //    {
        //        Response.Write("<span>welcome to" + uname + "</span>");
        //    }
        //    else
        //    {
        //        Response.Write("<span>Invalid Username or Password");
        //    }
        //    return View();
        //}

        //Post: Login using formal parameters
        //[HttpPost]
        //public ActionResult Login(string Uid,string Pwd)
        //{
        //    if (Uid == "admin" && Pwd == "admin")
        //    {
        //        Response.Write("<span>welcome to" + Uid + "</span>");
        //    }
        //    else
        //    {
        //        Response.Write("<span>Invalid Username or Password");
        //    }
        //    return View();
        //}

        // Post: Login using model object parameters
        //[HttpPost]
        //public ActionResult Login(Login obj)
        //{
        //    if (obj.Uid == "admin" && obj.Pwd == "admin")
        //    {
        //        Response.Write("<span>welcome to" + obj.Uid + "</span>");
        //    }
        //    else
        //    {
        //        Response.Write("<span>Invalid Username or Password");
        //    }
        //    return View();
        //}

        // Post : Login using ViewData sharing

        [HttpPost]
        public ActionResult Login(Login newLogin)
        {
            if (newLogin.Uid == "admin" && newLogin.Pwd == "admin")
            {
                ViewData["Uid"] = newLogin.Uid;
                ViewBag.Result = true;
            }
            else
            {
                ViewBag.Result = false;
                TempData["loginError"] = "Invalid Username or Password";
            }
            return View();
        }
    }
}