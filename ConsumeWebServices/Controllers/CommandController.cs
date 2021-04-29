using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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




        public ActionResult addcommandonbasket(Command c)
        {
            var idbasket = Session["basketid"];
            var iduser = Session["clientid"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PutAsJsonAsync<Command>("pidev/command/affectCommandBasket/" + idbasket+'/'+iduser ,c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            TempData["added"] = "You're Command is passed ! Enjoy Our Products <3";

            return RedirectToAction("showCommandForClient");
        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:8085/pidev/basket/deletebasket/" + id.ToString()).Result;

            return RedirectToAction("Index");
        }


        public ActionResult showCommandForClient()
        {
            var basketid = Session["basketid"];


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/command/showcommand/" + basketid).Result;

            if (response.IsSuccessStatusCode)
            {
                var command = response.Content.ReadAsAsync<IEnumerable<Command>>().Result;

                return View(command);

            }
            else
            {
                return View();
            }
        }



        public ActionResult showCommandForAdmin()
        {
           


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/command/showcommands").Result;

            if (response.IsSuccessStatusCode)
            {
                var command = response.Content.ReadAsAsync<IEnumerable<Command>>().Result;

                return View(command);

            }
            else
            {
                return View();
            }
        }



    }
}
