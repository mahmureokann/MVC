using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GetPost.Controllers
{
    public class HomeController : Controller
    {
        
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