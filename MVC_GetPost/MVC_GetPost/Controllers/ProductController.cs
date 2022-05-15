using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_GetPost.Models;

namespace MVC_GetPost.Controllers
{
    public class ProductController : Controller
    {

        public static List<Product> productList = new List<Product>()
        {
            new Product{ProductName="Chai",UnitPrice=18,UnitsInStock=500},
            new Product{ProductName="Chang",UnitPrice=15,UnitsInStock=200},
            new Product{ProductName="Tofu",UnitPrice=20,UnitsInStock=300}

        };


        //Get,Post


        public ActionResult Index()
        {

            return View(productList);
        }

        //Get Action
        
        public ActionResult AddProduct()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult AddProduct(string productName, string unitPrice, string unitsInStock)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddProduct(FormCollection collection)
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            productList.Add(product);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct()
        {
            return View();
        }
    }
}