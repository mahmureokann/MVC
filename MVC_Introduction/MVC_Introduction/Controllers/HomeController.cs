using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Introduction.Controllers
{
    public class HomeController : Controller
    {
       //controller içerisinde varsayılan olarak tetiklenen metotun ismi her zaman index olmak zorundadır.

        //public string Index()
        //{
        //    return "Index sayfası";
        //}

        //Index
        public ActionResult Index()
        {
            return View();
        }


        //About
        public ActionResult About()
        {
            return View();
        }

        //Contact
        public ActionResult Contact()
        {
            return View();
        }

    }
}