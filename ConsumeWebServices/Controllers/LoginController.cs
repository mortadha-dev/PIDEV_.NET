using ConsumeWebServices.Models;
using System;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace ConsumeWebServices.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
     


        [HttpGet]
        public ActionResult Login()
        {
            

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            //login customer
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("User/Access/login/", u).Result;

            //getting the id of the connected customer and put it in a2 variable
            String userlogin = u.login.ToString();
            HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("customers/please/"+ userlogin).Result;
            var clientid = response2.Content.ReadAsStringAsync().Result;

            //getting the id of the basket and put it in a3 variable
            HttpResponseMessage response3 = GlobalVariables.WebApiClient.GetAsync("basket/getbasketid/" + clientid.ToString()).Result;
            var basketid = response3.Content.ReadAsStringAsync().Result;

            Session["clientid"] = clientid.ToString();

            Session["basketid"] = basketid.ToString();

            return RedirectToAction("ClientVue", "Client");
        }



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
            return RedirectToAction("Index", "Product");
        }











    }
}