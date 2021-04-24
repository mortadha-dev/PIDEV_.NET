using ConsumeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ConsumeWebServices.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            IEnumerable<Customer> BasketList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("customers/getallbaskets").Result;
            BasketList = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return View(BasketList);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]

        public ActionResult Create(Customer c)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PostAsJsonAsync<Customer>("pidev/customers/addclient/", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("updateToUser");
        }





        [HttpGet]
        public ActionResult updateToUser()
        {
            return View();
        }



        [HttpPost]

        public ActionResult updateToUser(User c)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PutAsJsonAsync<User>("pidev/customers/updateclient/14", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Create", "Payment");
        }
























    }
}