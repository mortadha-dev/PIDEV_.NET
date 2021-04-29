using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PIDEV.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/SpringMVC/servlet/Product/get-all-Products").Result;
          /*  IEnumerable<Product> result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

            }
            else
            {
                result = null;
            }*/
            return View();
        }
    }
}