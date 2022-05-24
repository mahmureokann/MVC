using MVC_Sepet.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Net; //Gereklii
using System.Net.Mail; //Gerekli
using MVC_Sepet.Utils;

namespace MVC_Sepet.Controllers
{
    public class HomeController : Controller
    {

        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Index()
        {
            return View(db.Products.Where(x=>x.CategoryID!=null&&x.UnitsInStock>0).ToList());
        }

        public ActionResult AddToCart(int id)//50000
        {
            try
            {
                Product product = db.Products.Find(id);

                Cart c = null;

                if (Session["scart"] == null)
                {
                    c = new Cart();
                }
                else
                {
                    c = Session["scart"] as Cart;
                }

                //Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart; --if else alretnatifi--

                CartItem ci = new CartItem();
                ci.Id = product.ProductID;
                ci.Price = product.UnitPrice;
                ci.ProductName = product.ProductName;
                c.AddItem(ci);
                Session["scart"] = c;

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["error"] = $"{id} karşılık gelen bir ürün bulunamadı!";
                return View();
               
            }
            
        }

        public ActionResult MyCart()
        {
            if (Session["scart"] != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "sepetinizde ürün bulunmamaktadır!";
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult CompleteCart()
        {
            Cart cart = Session["scart"] as Cart;
            foreach (var item in cart.myCart)
            {
                Product product = db.Products.Find(item.Id);
                product.UnitsInStock -= Convert.ToInt16(item.Quantity);
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.OrderNumber = "156565";
                Session.Remove("scart");
               
            }
            return View();
        }
        public ActionResult Email()
        {
            MailSender.SendEmail("mahmureokannn@gmail.com", "Siparis bilgisi", "Siparişiniz başarıyla oluşturuldu.");
            return View();
        }

     
    }
}