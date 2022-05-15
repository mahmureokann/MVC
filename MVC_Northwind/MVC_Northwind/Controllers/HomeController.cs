using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Controllers
{
    public class HomeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public static List<Customer> customers = new List<Customer>();

        // GET: Home
        public ActionResult Index()
        {
            List<Customer> customers = db.Customers.OrderByDescending(x => x.CustomerID).ToList();
            List<Order> orders = db.Orders.OrderByDescending(x => x.OrderID).ToList();
            List<Employee> employees = db.Employees.OrderByDescending(x => x.EmployeeID).ToList();
            List<Product> products = db.Products.OrderByDescending(x => x.ProductID).ToList();
            

            TempData["Customers"] = customers.ToList();
            TempData["Orders"] = orders.ToList();
            TempData["Employee"] = employees.ToList();

            TempData["CustomerNumber"] = customers.Count().ToString(); //Müşterilerin toplam sayısı
            TempData["EmployeeNumber"] = employees.Count().ToString(); //Çalışanların toplam sayısı
            TempData["ProductNumber"] = products.Count().ToString(); //Toplam ürün sayısı
            TempData["OrderNumber"] = orders.Count().ToString(); //Toplam siparişler
            TempData["SonSiparisler"] = db.Orders.OrderByDescending(x => x.OrderDate).Take(15).ToList(); //Son siparişleri gösteriyor

            TempData.Keep();
            return View();
        }
       


    }
}