using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace ConsumeWebServices.Controllers
{
    public class LoyaltycardController : Controller
    {
        // GET: Loyaltycard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult showLoyaltyCards()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/loyaltycard/getAllCards").Result;

            if (response.IsSuccessStatusCode)
            {
                var command = response.Content.ReadAsAsync<IEnumerable<Loyaltycard>>().Result;

                return View(command);

            }
            else
            {
                return View();
            }
        }
        [System.Web.Http.HttpPost]
        public ActionResult randomgift()
        {
            var productid = p.id;
            //var basketid = 16;
            //var productid = 5;
            //  Basket b = new Basket();
            var basketid = Session["basketid"];

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8085");

            client.PostAsync("pidev/basket/affecter/" + basketid + "/" + productid, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            TempData["SuccessMessage"] = "Product is Saved Successfully in your Basket";
            return RedirectToAction("ClientVue", "Client");


        }
    }
}