using ConsumeWebServices.Models;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ConsumeWebServices.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult voir()
        {
            return View();
        }


        [System.Web.Http.HttpGet]
        public ActionResult var()
        {
            return View("Create");
        }



        [System.Web.Http.HttpPost]
        public ActionResult Create(CardDetails c)
        { 
            var clientid = Session["clientid"];
            c.number = "4242424242424242";
            c.expMonth = 3;
            c.expYear = 2025;
            c.cvc = "123";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PostAsJsonAsync<CardDetails>("pidev/payment/addcart/"+clientid, c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Charge");
        }

        [System.Web.Http.HttpPost]
        public ActionResult charge(Charge c)
        {
            c.currency = "usd";
            c.description = "c bon ";
            var clientid = Session["clientid"];
            var basketid = Session["basketid"];
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");           
            client.PostAsJsonAsync<Charge>("pidev/payment/charger/" + clientid +"/"+basketid , c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("ClientVue","Client");
        }
    }
}