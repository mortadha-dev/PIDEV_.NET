using System;
using System.Collections.Generic;

using System.Web.Mvc;
using ConsumeWebServices.Models;

using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsumeWebServices.Controllers
{
    public class PersonneController : Controller
    {
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev/personne/afficherpersonne").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Personne>>().Result;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }



        //create a new personne 

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        public ActionResult Create(Personne b)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PostAsJsonAsync<Personne>("pidev/personne/ajouterpersonne/", b).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

 
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:8085/pidev/personne/supprimerpersonne/" + id.ToString()).Result;

            return RedirectToAction("Index");

        }

       
        public ActionResult Edit(Personne personne)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            client.PutAsJsonAsync<Personne>("pidev/personne/updatePersonne", personne).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View("Edit");
        }


    }
}

