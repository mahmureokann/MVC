using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MVC_Sepet.Utils
{
    public class MailSender
    {
        //Göndericiye ait.Bilgilendirme mesajını gönderici atacağı için

        //Bir adet metot
        public static void SendEmail(string email, string subject, string message)
        {
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("yzlCalisma@gmail.com");
            sender.To.Add(email);
            sender.Subject = subject;
            sender.Body = message;

            //smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("yzlCalisma@gmail.com", "YZLcalisma--");
            smtp.Port = 587; //Fix
            smtp.Host = "smtp.gmail.com"; //Fix --> Gmailin mail gönderme standartı
            smtp.EnableSsl = true;


            smtp.Send(sender);



        }

    }
}