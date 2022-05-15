using MVC_EcommerceLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EcommerceLayout.Controllers
{
    public class HomeController : Controller
    {
        NORTHWNDEntities1 db = new NORTHWNDEntities1();



        // GET: Home
        public ActionResult Index()
        {
            List<Product> products = db.Products.OrderByDescending(x => x.ProductID).Take(8).ToList();
            return View(products);
        }
    }
}