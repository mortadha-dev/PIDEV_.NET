using ConsumeWebServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace ConsumeWebServices.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/products/showproducts").Result;
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

                return View(products);

            }
            else
            {
                ViewBag.result = "error";
                return View(new List<Product>());
            }
        }



        public ActionResult ProductDetails()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/products/showproducts").Result;
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

                return View(products);

            }
            else
            {
                ViewBag.result = "error";
                return View(new List<Product>());
            }
        }









        [System.Web.Http.HttpPost]
        public ActionResult AffecterProductToBasket()
        {
          var basketid = 16;
          var productid = 5;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8085");

    client.PostAsync("pidev/basket/affecter/"+ basketid + "/" + productid, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return View("AffecterProductToBasket");


        }
    }
        }

    
