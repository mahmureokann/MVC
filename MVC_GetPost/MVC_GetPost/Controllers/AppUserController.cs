using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GetPost.Controllers
{
    public class AppUserController : Controller
    {
        //GET
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string userName)
        {
            return View();
        }
    }
}