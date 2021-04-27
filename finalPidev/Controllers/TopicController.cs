using finalPidev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace finalPidev.Controllers
{
    public class TopicController : Controller
    {
        // GET: Topic
        public ActionResult Index()
        {
            IEnumerable<Topic> topicList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("topic/DisplayTopics").Result;
            topicList = response.Content.ReadAsAsync<IEnumerable<Topic>>().Result;
            return View(topicList);
        }

        public ActionResult Create(int id = 0)
        {
            if (id == 0)
                return View(new Topic());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("topic/getTopic/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Topic>().Result);
            }
        }
        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            var userid = Session["userid"];
            if (topic.idTopic == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("topic/addTopic/" + userid.ToString(), topic).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("topic/UpdateTopic/" + topic.idTopic + "/" + userid.ToString(), topic).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var userid = Session["userid"];
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("topic/deleteTopic/" + id.ToString() + "/" + userid.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            int idtopic = id;
            Session["idtopic"] = idtopic;
            if (id == 0)
                return RedirectToAction("Index");
            else
            {

                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("topic/getdetailsTopic/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Topic>().Result);

            }
        }
        
    }
}
