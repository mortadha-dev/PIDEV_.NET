using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsumeWebServices.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]

        public ActionResult Create(CardDetails c)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PostAsJsonAsync<CardDetails>("pidev/payment/addcart/14", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
    }
}