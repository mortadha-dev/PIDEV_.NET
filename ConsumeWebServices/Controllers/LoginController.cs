using ConsumeWebServices.Models;
using System;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace ConsumeWebServices.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            using (var client = new HttpClient())
            {
                User user;
                client.BaseAddress = new Uri("http://localhost:8085/pidev/");
                var loginInfo = new Dictionary<string, string>();
                loginInfo.Add("username", username);
                loginInfo.Add("password", password);
                var changePassObj = JsonConvert.SerializeObject(loginInfo,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
                HttpResponseMessage res = await client.PostAsync("User/Access/login", new StringContent(changePassObj, Encoding.UTF8, "application/json"));

                string roletype = "";
                string tockenString = "";
                if (res.IsSuccessStatusCode)
                {
                    var loginResponse = res.Content.ReadAsStringAsync().Result;
                    JWTResponse JWTResponse = JsonConvert.DeserializeObject<JWTResponse>(loginResponse);

                    string[] subs = loginResponse.Split('"');
                    tockenString = subs[11];
                    ViewBag.JWTResponse = tockenString;
                    Session["accessToken"] = tockenString;

                    /*
                                        string[] roles = _role.Split('"');
                                        roletype = subs[15];
                                        ViewBag.JWTResponse = roletype;
                                        Session["role"] = roletype;
                    */
                    user = JsonConvert.DeserializeObject<User>(loginResponse);
                    // user = JsonConvert.DeserializeObject<User>(_role);
                    //var Role = Session["role"];

                    // String userlogin = user.Login;

                    //getting the id of the connected customer and put it in clientid variable
                    var _AccessToken = Session["AccessToken"];
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
                    HttpResponseMessage response2 = await client.GetAsync("User/Service/findUserBylogin/" + username);
                    // response2 = await client.GetAsync("Admin/User/getUserByName/" + username);
                    if (response2.IsSuccessStatusCode)
                    {
                        var userResponse = response2.Content.ReadAsStringAsync().Result;
                        user = JsonConvert.DeserializeObject<User>(userResponse);
                        Session["LoggedInUser"] = user;
                        if (JWTResponse.Role.Equals("Client"))
                        {


                            //ViewBag.Layout =
                            return RedirectToAction("ClientVue", "Client");

                        }
                        else
                        {
                            return RedirectToAction("Dashboard", "Admin");
                        }




                    }
                    // var clientid = response2.Content.ReadAsStringAsync().Result;
                    //Session["clientid"] = clientid.ToString();

                    //user.RoleType.ToString();
                    //String RoleType = user.RoleType.ToString();

                }
                return RedirectToAction("Login", "Login");

            }/*
            [HttpPost]
            public async Task<ActionResult> Login(string username, string password)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8088/Spring/pi/");
                    User loggedInUser;
                    var loginInfo = new Dictionary<string, string>();
                    loginInfo.Add("username", username);
                    loginInfo.Add("password", password);
                    var changePassObj = JsonConvert.SerializeObject(loginInfo,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
                    HttpResponseMessage res = await client.PostAsync("auth", new StringContent(changePassObj, Encoding.UTF8, "application/json"));
                    string tockenString = "";
                    if (res.IsSuccessStatusCode)
                    {
                        var loginResponse = res.Content.ReadAsStringAsync().Result;
                        string[] subs = loginResponse.Split('"');
                        tockenString = subs[3];
                        ViewBag.tocken = tockenString;
                        Session["jwt"] = tockenString;
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session["jwt"].ToString());
                        res = await client.GetAsync("Admin/User/getUserByName/" + username);
                        if (res.IsSuccessStatusCode)
                        {
                            var userResponse = res.Content.ReadAsStringAsync().Result;
                            loggedInUser = JsonConvert.DeserializeObject<User>(userResponse);
                            string userType = loggedInUser.Type;
                            switch (userType)
                            {
                                case "Admin":
                                    res = await client.GetAsync("getDirectorById/" + loggedInUser.Id);
                                    userResponse = res.Content.ReadAsStringAsync().Result;
                                    loggedInUser = JsonConvert.DeserializeObject<Director>(userResponse);
                                    Session["loggedInUser"] = loggedInUser;
                                    return RedirectToAction("Index", "Admin", new { area = "Administrator" });
                                case "Parent":
                                    res = await client.GetAsync("getParentById/" + loggedInUser.Id);
                                    userResponse = res.Content.ReadAsStringAsync().Result;
                                    loggedInUser = JsonConvert.DeserializeObject<Parent>(userResponse);
                                    Session["loggedInUser"] = loggedInUser;
                                    return RedirectToAction("Index", "Home");
                                default: return RedirectToAction("Index");
                            }
                        }
                    }
                }
                TempData["loginError"] = "Username and Password doesn't match";
                return RedirectToAction("Index");
            }*/


            /* [HttpPost]
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



             */







        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(string username)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:8085/pidev/");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session["jwt"].ToString());
                HttpResponseMessage res = await client.PostAsync("User/Access/forgot/" + username, null);
                if (res.IsSuccessStatusCode)
                {
                    TempData["forgotPassword"] = "Check your mail box";
                    return RedirectToAction("ResetPassword");
                }
            }
            TempData["forgotPasswordError"] = "User does not exists!";
            return RedirectToAction("ForgotPassword");
        }


        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ResetPassword(string token, string password)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:8085/pidev/");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session["jwt"].ToString());
                HttpResponseMessage res = await client.PostAsync("User/Access/reset/" + token + "/" + password, null);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login","Login");
                }
            }
            TempData["resetPasswordError"] = "Unvalid token!";
            return RedirectToAction("ResetPassword");
        }
    }
}