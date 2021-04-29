using Microsoft.AspNetCore.Mvc;
using PIDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using System.Net.Mail;

namespace PIDEV.Controllers
{
    public class SendMailController : Controller
    {
        // GET: SendMail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index( Email em )
        {
            String to = em.To;

            String subject = em.Subject;

            String body = em.Body;
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = em.Body;
            mm.From = new MailAddress("nesrinetry@gamil.com");
            mm.IsBodyHtml = false;
            SmtpClient stmp = new SmtpClient("smtp.gmail.com");
            stmp.Port = 587;
            stmp.UseDefaultCredentials = true;
            stmp.EnableSsl = true;
            stmp.Credentials = new System.Net.NetworkCredential("nesrinetry@gmail.com", "Nesrinetry123");
            stmp.Send(mm);
            ViewBag.message = "Good job";
            return View();


        }


    }
}