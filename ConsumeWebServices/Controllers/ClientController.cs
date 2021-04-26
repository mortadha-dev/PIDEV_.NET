<<<<<<< HEAD
﻿using System.Web.Mvc;
=======
﻿using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
>>>>>>> 034e99bb862299a454d2ccf7413371f367e6571f

namespace ConsumeWebServices.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult ClientVue()
        {
<<<<<<< HEAD
            return View();
=======
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
          
>>>>>>> 034e99bb862299a454d2ccf7413371f367e6571f
        }
    }
}