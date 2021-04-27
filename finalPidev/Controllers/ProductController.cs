using finalPidev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace finalPidev.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        

        public ActionResult Index(Basket b)
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







        [HttpPost]
        public ActionResult AffecterProductToBasket(Product p)
        {
            var productid = p.id;
            //var basketid = 16;
            //var productid = 5;

            //  Basket b = new Basket();
            var basketid = Session["basketid"]; 


            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8085");

            client.PostAsync("pidev/basket/affecter/" + basketid + "/" + productid, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("GetBasketProducts", "Product");


        }


        public ActionResult GetBasketProducts()
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
    }
}