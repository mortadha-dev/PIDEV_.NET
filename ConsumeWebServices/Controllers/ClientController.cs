using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace ConsumeWebServices.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult ClientVue()
        {
            //Session["FullNammmme"] = b.id.ToString();

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