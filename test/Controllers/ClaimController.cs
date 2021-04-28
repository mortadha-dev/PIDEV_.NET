using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class ClaimController : Controller
    {

        // GET: Claim
        public ActionResult ListClaim()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("listClaim").Result;
            IEnumerable<Claim> ListClaim;
            if (response.IsSuccessStatusCode)
            {
                ListClaim = response.Content.ReadAsAsync<IEnumerable<Claim>>().Result;
            }
            else
            {
                ListClaim = null;
            }
            return View(ListClaim);

        }
            //List<Claim> ListClaim = new List<Claim>();


           [HttpGet]
            public ActionResult CreateClaim()
            {
                return View("CreateClaim");
            }
            [HttpPost]
            // GET: Event/Create
            public ActionResult CreateClaim(Claim claim)
            {
                /*HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");
                Client.PostAsJsonAsync<Claim>("addClaim", claim).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());*/
                return RedirectToAction("ListClaim");
            }

            // GET: Claim/Details/5
            public ActionResult Details(int id)
            {
                return View();
            }


            // GET: Claim/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: Claim/Edit/5
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

            // GET: Claim/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: Claim/Delete/5
            [HttpPost]
            /* public ActionResult Delete(int id, FormCollection collection)
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
            */
            public ActionResult DeleteClaim(long idClaim)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8085/maha/servlet/");

                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync("deleteClaim/" + idClaim.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");

            }
        }
    }
}
