using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ConsumeWebServices.Models;

namespace ConsumeWebServices.Controllers
{
    public class RoleController : Controller
    {
        HttpClient httpClient;

        string Baseurl = "http://localhost:8085/pidev/";
        // GET: User
        public async Task<ActionResult> ListRole()
        {
            {

                List<Role> roles = new List<Role>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("User/Role/findall");
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        roles = JsonConvert.DeserializeObject<List<Role>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(roles);

                }
            }
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View("CreateRole");
        }
        [HttpPost]
        // GET: Event/Create
        public ActionResult CreateRole(Role roles)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/pidev/");
            Client.PostAsJsonAsync<Role>("User/Role/createRole", roles).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("ListRole", "Role");
        }
        public ActionResult UpdateRole(Role roles)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085/");
            client.PutAsJsonAsync<Role>("pidev/User/Role/updateRole", roles).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("ListRole", "Role");
        }

        [HttpGet]
        public ActionResult UpdateRole()
        {
            return View("UpdateRole");
        }


        public ActionResult DeleteRole(int idRole)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:8085/pidev/User/Role/deleteRoleById/" + idRole).Result;

            return RedirectToAction("ListRole", "Role");
        }
    }
}