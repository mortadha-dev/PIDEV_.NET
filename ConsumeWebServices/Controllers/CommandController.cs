    using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ConsumeWebServices.Controllers
{
    public class CommandController : Controller
    {
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/basket/getallbaskets").Result;
            if (response.IsSuccessStatusCode)
            {
                var baskets = response.Content.ReadAsAsync<IEnumerable<Basket>>().Result;

                return View(baskets);

            }
            else
            {
                ViewBag.result = "error";
                return View(new List<Basket>());
            }

        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]

        public ActionResult Create(Basket b, int userid)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PostAsJsonAsync<Basket>("pidev/basket/addbasket/" + userid, b).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:8085/pidev/basket/deletebasket/" + id.ToString()).Result;

            return RedirectToAction("Index");
        }


        public ActionResult Edit([System.Web.Http.FromBody] String b)
        {
            Basket ba = new Basket();
            b = ba.nameBasket;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PutAsJsonAsync<String>("pidev/basket/modifyName/", b).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

    }
}
