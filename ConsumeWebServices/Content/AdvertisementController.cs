using PIDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PIDEV.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/SpringMVC/servlet/advertisement/get-all-advs").Result;
            IEnumerable<Advertisement> result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<Advertisement>>().Result;
            }
            else
            {
                result = null;
            }
            return View(result);
        }

        // GET: Advertisement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        // GET: Advertisement/Create
        [HttpPost]
        public ActionResult Create(Advertisement ad )
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.PostAsJsonAsync<Advertisement>("/SpringMVC/servlet/advertisement/add-advertisement", ad).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

        // POST: Advertisement/Create
     

        // GET: Advertisement/Edit/5
        public ActionResult Edit(int id_advertisement)
        {

            Advertisement c = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                //HTTP GET
                var responseTask = client.GetAsync("/SpringMVC/servlet/advertisement/detail-advertisement/" + id_advertisement.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Advertisement>();
                    readTask.Wait();

                    c = readTask.Result;
                }
            }

            return View(c);
        }

        // POST: Advertisement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id_advertisement, Advertisement c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Advertisement>("/SpringMVC/servlet/advertisement/update-advertisement/", c);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(c);
        }
    

        // GET: Advertisement/Delete/5
        public ActionResult Delete(int id_advertisement)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("/SpringMVC/servlet/advertisement/delete-advertisement/" + id_advertisement.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        // POST: Advertisement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
