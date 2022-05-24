using MVC_Sepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sepet.Controllers
{
    public class LoginController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
            
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user) //User tipinde user gelecek.
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.Users.Any(x=>x.Username==user.Username && x.Password == user.Password)) //sqlden kullancıı girişi yapılacak
                    {
                        TempData["basarili"] = "Giriş işlemi başarılı!";
                        
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "Hatalı veya eksik bilgi girişi.";

                        return View(user);//userValidation kontrolu icin tekrar Login'e gonderilir.
                    }
                }
                catch (Exception ex)
                {

                    return View(ex.Message);
                }
            }
            else
            {
                return View(user);
            }
          
        }
    }
}