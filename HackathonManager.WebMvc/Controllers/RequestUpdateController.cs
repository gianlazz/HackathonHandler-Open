using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonManager.WebMvc.Controllers
{
    public class RequestUpdateController : Controller
    {
        // GET: RequestUpdate
        public ActionResult Index()
        {
            //Context is the Team Requesting & the Mentor being requested
            //Have loading bar based on text replies
            //Also real time signalr updateding of a view of sms responses
            //Team should be able to mark their mentor as arrived, so should the mentor themselves
            //All of these transactions should be handled through a queue and monitored through the
            //Admin page
            return View();
        }
    }
}