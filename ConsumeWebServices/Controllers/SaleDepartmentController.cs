using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIDEV.Models;

using System.Net.Http;
using System.Net.Mail;

namespace PIDEV.Controllers
{
    public class SaleDepartmentController : Controller
    {

        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/SpringMVC/servlet/SaleDepartment/get-all-SaleDepartments").Result;
            IEnumerable<SaleDepartment> result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<SaleDepartment>>().Result;

              

            }
            else
            {
                result = null;
            }
            return View(result);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(SaleDepartment ev)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.PostAsJsonAsync<SaleDepartment>("/SpringMVC/servlet/SaleDepartment/ajouterSaleDepartment", ev).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            String to = "nesrinetry@gmail.com";

            String subject = "Product Dans sale deaptement ";

            String body = "Produit ajouter";
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("nesrinetry@gamil.com");
            mm.IsBodyHtml = false;
            SmtpClient stmp = new SmtpClient("smtp.gmail.com");
            stmp.Port = 587;
            stmp.UseDefaultCredentials = true;
            stmp.EnableSsl = true;
            stmp.Credentials = new System.Net.NetworkCredential("nesrinetry@gmail.com", "Nesrinetry123");
            stmp.Send(mm);
            ViewBag.message = "Good job";
            return RedirectToAction("Index");
        }

    
        public ActionResult Delete(long idSale)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("/SpringMVC/servlet/SaleDepartment/deleteSA/" + idSale.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");

        }




        public ActionResult Edit(long idSale)
        {
            SaleDepartment c = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                //HTTP GET
                var responseTask = client.GetAsync("/SpringMVC/servlet/advertisement/detail-advertisement/" + idSale.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SaleDepartment>();
                    readTask.Wait();

                    c = readTask.Result;
                }
            }

            return View(c);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(SaleDepartment c)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<SaleDepartment>("/SpringMVC/servlet/advertisement/update-advertisement/", c);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(c);
        }




    }
}