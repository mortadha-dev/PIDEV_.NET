using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{

    public class LivraisonController : Controller
    {
        List<Livraison> livraison = new List<Livraison>();

        HttpClient httpClient;
        string baseAddress;
        public LivraisonController()
        {
            
           // var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", _AccessToken));
        }
        // GET: Livraison
        public ActionResult Livraision()
        //async Task<ActionResult> Livraision()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("listLivraison").Result;
            IEnumerable<Livraison> Livraision;
            if (response.IsSuccessStatusCode)
            {
                var lv = response.Content.ReadAsAsync<IEnumerable<Livraison>>().Result;
                Livraision = lv;
                //return RedirectToAction("ListLivreur");
            }
            else
            {
                Livraision = null;
            }
            return View(Livraision);
            /*httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            baseAddress = "http://localhost:8082/maha/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            HttpResponseMessage Res = await httpClient.GetAsync("servlet/listLivraison");
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                livraison = JsonConvert.DeserializeObject<List<Livraison>>(EmpResponse);

            }
            //returning the employee list to view  
            return View(livraison);
       */
        }
            // GET: Livraison/Details/5
            public ActionResult Details(int id)
            {
                return View();
            }

        // GET: Livraison/Create
        [HttpGet]
        public ActionResult CreateLivraison()
        {
            return View("CreateLivraison");
        }
        [HttpPost]
        // GET: Event/Create
        public ActionResult CreateLivraison(Livraison livr)
        {
            livr.state = State.ENCOURS;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");
            Client.PostAsJsonAsync<Livraison>("addLivraison/"+livr.idCommande +"/"+livr.idLivreur, livr).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("ListLivraison");
        }
        /*try
        {
            var APIResponse = httpClient.PostAsJsonAsync<Livraison>(baseAddress + "servlet/listLivraison",
            livraison).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction(" Index ");
        }
        catch
        {
            return View();
        }

   */


        // POST: Livraison/Create
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

        // GET: Livraison/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Livraison/Edit/5
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

        // GET: Livraison/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Livraison/Delete/5
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
