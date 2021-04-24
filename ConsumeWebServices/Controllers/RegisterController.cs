using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsumeWebServices.Controllers
{
    public class RegisterController : Controller
    {

        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(User u)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PostAsJsonAsync<User>("pidev/customers/registerclient/", u).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index","Basket");
        }

    }
}