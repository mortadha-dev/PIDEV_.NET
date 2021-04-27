using finalPidev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace finalPidev.Controllers
{
    public class RatingTopicController : Controller
    {
        // GET: RatingTopic
        public ActionResult Index(int id)
        {
            IEnumerable<RatingTopic> ratingtopicList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ratingtopic/DisplayEtoileByTopic/"+id.ToString()).Result;
            ratingtopicList = response.Content.ReadAsAsync<IEnumerable<RatingTopic>>().Result;
            return View(ratingtopicList);
        }
    }
}