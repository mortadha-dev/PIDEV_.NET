using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using ConsumeWebServices.Models;

namespace ConsumeWebServices.Controllers
{
    public class UserController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        Token token;
        string Baseurl = "http://localhost:8085/pidev/";
        // GET: User


        public async Task<ActionResult> List()
        {
            {
                List<User> users = new List<User>();

                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // var jwt = JsonWebToken.Encode(token, APISECRET, JwtHashAlgorithm.HS256);
                    // Acquire the access token.

                    var _AccessToken = Session["AccessToken"];
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));

                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJiYmJiYmIiLCJpYXQiOjE2MTkwNDYxOTAsImV4cCI6MTYxOTkxMDE5MH0.ftUt2OiPgIfogtDw8NVKjaee9AQb09btDG1q_AzE30oFAhRnSal_mLbeWT3LNhr3dLoiYZ3MO9nx1zAxTegyow");
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("User/Service/findall");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        users = JsonConvert.DeserializeObject<List<User>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(users);
                }
            }
        }

        /*private object Session(string v)
        {
            throw new NotImplementedException();
        }*/

        [HttpPost]
        public ActionResult UpdateUser(User users)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085/pidev/");
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJiYmJiYmIiLCJpYXQiOjE2MTkwNDYxOTAsImV4cCI6MTYxOTkxMDE5MH0.ftUt2OiPgIfogtDw8NVKjaee9AQb09btDG1q_AzE30oFAhRnSal_mLbeWT3LNhr3dLoiYZ3MO9nx1zAxTegyow");
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
            client.PutAsJsonAsync<User>("User/Service/UpdateUser", users).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("List", "User");
        }

        [HttpGet]
        public ActionResult UpdateUser()
        {
           User u = Session["LoggedInUser"] as User;
           
            
            // u = await findAdById(id);
            return View(u);
        }
        public async Task<User> findAdById(int idUser)
        {
            {

                User Users = new User();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    var _AccessToken = Session["AccessToken"];
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
                    //Define request data format  
                  //  int id = (Session["clientid"];

                    HttpResponseMessage Res = await client.GetAsync("User/Service/userbyid/" + idUser);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        Users = JsonConvert.DeserializeObject<User>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return Users;

                }
            }
        }

        public ActionResult DeleteUser(int idUser)
        {
            HttpClient client = new HttpClient();
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
            HttpResponseMessage response = client.DeleteAsync("http://localhost:8085/pidev/User/Service/deleteUserById/" + idUser.ToString()).Result;

            return RedirectToAction("List", "User");
        }
        public ActionResult activateUser(User users)
        {
            HttpClient client = new HttpClient();
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
            client.PutAsJsonAsync<User>("User/Service/activateUser", users).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            //  HttpResponseMessage response = client.PutAsync<User>("http://localhost:8085/pidev/User/Service/activateUser/",User);

            return RedirectToAction("List", "User");
        }
        [HttpGet]
        public ActionResult activateUser()
        {
            //User u = Session["LoggedInUser"] as User;


            // u = await findAdById(id);
            return View("List");
        }
        public ActionResult desactivateUser(User users)
        {
            HttpClient client = new HttpClient();
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
            client.PutAsJsonAsync<User>("User/Service/desactivateUser", users).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            //  HttpResponseMessage response = client.PutAsync<User>("http://localhost:8085/pidev/User/Service/activateUser/",User);

            return RedirectToAction("List", "User");
        }
        [HttpGet]
        public ActionResult desactivateUser()
        {
            //User u = Session["LoggedInUser"] as User;


            // u = await findAdById(id);
            return View("List");
        }

        [HttpGet]
        public ActionResult signup()
        {
            return View("signup");
        }
        [HttpPost]
        // GET: Event/Create
        public ActionResult signup(User user, RoleType roleType)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085/pidev/");
            // HttpResponseMessage response = Client.PostAsync("http://localhost:8085/pidev/User/Access/signup/"+RoleType).Result;

            Client.PostAsJsonAsync<User>("http://localhost:8085/pidev/User/Access/signup/" + roleType.ToString(), user).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Login", "Login");
        }
    }
}

/*
HttpClient Client = new HttpClient();
Client.BaseAddress = new Uri("https://localhost:8085/");
// httpClient.BaseAddress = new Uri(baseAddress);
Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
HttpResponseMessage response = Client.GetAsJsonAsync("pidev/User/Access/login",new Login() {UserName="bbbbbb",password="aaa" }).Result;
if (response.IsSuccessStatusCode)
{
    token = response.Content.ReadAsAsync<Token>().Result;

}
else
{ ViewBag.result = "error"; }
// var _AccessToken ="eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJiYmJiYmIiLCJpYXQiOjE2MTg0NzQ5MDUsImV4cCI6MTYxOTMzODkwNX0.dRTC6Xl93sV-2ZSW7bhULvnh1SJcbOiPXv0A61xsVM1RA_oJ-qI-i7susJVUq7W7Ppere9_2lrlkmObrbwT9Hg";

Client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", token.accessToken));
HttpResponseMessage response1 = Client.GetAsync("/pidev/User/Service/findall").Result;
if (response.IsSuccessStatusCode)
{
    ViewBag.result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

}
else
{ ViewBag.result = "error"; }
return View();}
*/



/* [HttpPost]

 [ValidateAntiForgeryToken]
 public ActionResult Create(User u)
 {
     List<User> users= Session["users"] as List<User>;
     if (users == null)
     {
         users = new List<User>();
     }
     users.Add(u);
     return RedirectToAction("Index");
 }*/

