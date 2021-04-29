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

        


        public ActionResult ShowSingleProduct(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/products/getproductbyid/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<Product>().Result;

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
            //  Basket b = new Basket();
            var basketid = Session["basketid"]; 

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8085");

            client.PostAsync("pidev/basket/affecter/" + basketid + "/" + productid, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            TempData["SuccessMessage"] = "Product is Saved Successfully in your Basket";
            return RedirectToAction("ClientVue", "Client");


        }


        public ActionResult GetBasketProducts()
        {
                        var basketid = Session["basketid"]; 


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/basket/show/"+basketid).Result;
            HttpResponseMessage response2 = client.GetAsync("pidev/basket/calculateBasketPrice/" + basketid).Result;
            HttpResponseMessage response3 = client.GetAsync("pidev/basket/count/" + basketid).Result;


            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

                var basketprice = response2.Content.ReadAsStringAsync().Result;
                Session["basketprice"] = basketprice.ToString();

                var count = response3.Content.ReadAsStringAsync().Result;
                Session["count"] = count.ToString();


                return View(products);

            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var basketid = Session["basketid"];

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("basket/deleteproduct/"+ basketid.ToString()+"/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("GetBasketProducts");
        }


    }
}


