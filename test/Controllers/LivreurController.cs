using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class LivreurController : Controller
    {
        // GET: Livreur
        public ActionResult ListLivreur()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("listLivreur").Result;
            IEnumerable<Livreur> ListLivreur;
            if (response.IsSuccessStatusCode)
            {
                ListLivreur = response.Content.ReadAsAsync<IEnumerable<Livreur>>().Result;
            }
            else
            {
                ListLivreur = null;
            }
            return View(ListLivreur);
        }
 [HttpGet]
        public ActionResult CreateLivreur()
        {
            return View("CreateLivreur");
        }
        [HttpPost]
        // GET: Event/Create
        public ActionResult CreateLivreur(Livreur liv)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");
            Client.PostAsJsonAsync<Livreur>("addLivreur", liv).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("ListLivreur");
        }

        // GET: Event/Edit/5
        public ActionResult EditLivreur(long id)
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("findLivreur/" + id.ToString()).Result;
            Livreur ListLivreur;
            if (response.IsSuccessStatusCode)
            {
                ListLivreur = response.Content.ReadAsAsync<Livreur>().Result;
            }
            else
            {
                ListLivreur = null;
                return View("CreateLivreur");
            }
            return View(ListLivreur);

        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult EditLivreur(Livreur l)
        {

            using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");

                 //HTTP POST

                 var putTask = client.PutAsJsonAsync<Livreur>("updateLivreur", l).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                putTask.Wait();

                 var result = putTask.Result;
                 if (result.IsSuccessStatusCode)
                 {

                     return RedirectToAction("ListLivreur");
                 }
             }
             return View(l);
         }
        [HttpGet]
        public ActionResult DeleteLivreur(long id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("findLivreur/" + id.ToString()).Result;
            Livreur ListLivreur;
            if (response.IsSuccessStatusCode)
            {
                ListLivreur = response.Content.ReadAsAsync<Livreur>().Result;
            }
            else
            {
                ListLivreur = null;
                return View("CreateLivreur");
            }
            return View(ListLivreur);
            
        }
        [HttpGet]
        public ActionResult ConfirmDeleteLivreur(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("deleteLivreur/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ListLivreur");
                }
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult DisableLivreur(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");

                //HTTP DELETE
                var deleteTask = client.GetAsync("DesactivateLivreur/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ListLivreur");
                }
            }

            return RedirectToAction("Index");

        }
        /*
        // GET: Livreur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Livreur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livreur/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livreur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Livreur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livreur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Livreur/Delete/5
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
        }*/
    }
}
