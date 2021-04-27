using finalPidev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace finalPidev.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
       
            public ActionResult Index()
            {

                IEnumerable<Basket> BasketList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("basket/getallbaskets").Result;
                BasketList = response.Content.ReadAsAsync<IEnumerable<Basket>>().Result;
                return View(BasketList);
            }
            public ActionResult AddOrEdit(int id = 0)
            {
                if (id == 0)
                    return View(new Basket());
                else
                {

                    Session["FullName"] = id.ToString();

                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("modifyName/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<Basket>().Result);
                }
            }
            [HttpPost]
            public ActionResult AddOrEdit(Basket basket)
            {

                if (basket.id == 0)
                {


                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("basket/addbasket/", basket).Result;
                    TempData["SuccessMessage"] = "Saved Successfully";
                }
                else
                {

                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("basket/modifyName/" + basket.id, basket).Result;
                    TempData["SuccessMessage"] = "Updated Successfully";
                }
                return RedirectToAction("Index");
            }

            public ActionResult Delete(int id)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("basket/deletebasket/" + id.ToString()).Result;
                TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }

        }
    
}