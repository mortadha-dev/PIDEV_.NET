using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace ConsumeWebServices.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
<<<<<<< HEAD
        public ActionResult Index(Basket p)
        {
            Session["FullName"] = p.id.ToString();
=======
        public ActionResult Index(Basket b)
        {
>>>>>>> 034e99bb862299a454d2ccf7413371f367e6571f

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
        public ActionResult AffecterProductToBasket(Product p)
        {
            var productid= p.id;
            //var basketid = 16;
            //var productid = 5;
<<<<<<< HEAD
          //  Basket b = new Basket();
           var basketid = Session["FullName"];
=======
            //  Basket b = new Basket();
            var basketid = Session["basketid"]; 
>>>>>>> 034e99bb862299a454d2ccf7413371f367e6571f

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8085");

            client.PostAsync("pidev/basket/affecter/" + basketid + "/" + productid, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

<<<<<<< HEAD
            return View("AffecterProductToBasket");


        }
=======
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

>>>>>>> 034e99bb862299a454d2ccf7413371f367e6571f
    }
}


