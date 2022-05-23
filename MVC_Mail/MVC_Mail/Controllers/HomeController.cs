using MVC_Mail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail; //Gerekli
using System.Web;
using System.Web.Mvc;

namespace MVC_Mail.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
       public ActionResult Index(Email model)
        {
            //Sender

            MailMessage mail = new MailMessage();
            mail.To.Add("mahmureokannn@gmail.com");
            mail.From= new MailAddress("yzl3156yzl@gmail.com", "YZL3156");
            mail.Subject = "Bize ulaşın sayfasından mesajınız var!"+model.baslik;
            mail.Body = "Sayın yetkili"+model.AdSoyad+"kişisi tarafından gönderilen mesaj içeriği: <br>"+model.icerik;
            mail.IsBodyHtml = true; //Html olduğunu söylüyorum.Böylelikle <br> etiketi çalışır hale geliyor.

            //smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("yzl3156yzl@gmail.com", "Yzl3156--");
            smtp.Port = 587; //Fix
            smtp.Host = "smtp.gamil.com"; //Fix -->Gmailin mail gönderme starndartı.

            try
            {
                smtp.Send(mail);
                TempData["message"] = "Mail gönderme işlemi başarılı.En kısa zamanda geri dönüş sağlanacaktır.";
            }
            catch (Exception ex)
            {

                TempData["message"] = "Mail gönderilemedi. Hata nedeni: " + ex.Message;
            }


            return View();
        }
    }
}