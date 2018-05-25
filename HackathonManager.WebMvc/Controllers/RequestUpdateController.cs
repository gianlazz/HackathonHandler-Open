using HackathonManager.DTO;
using HackathonManager.PocoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using HackathonManager.WebMvc.Util;
using HackathonManager.Models;
using SignalRProgressBarSimpleExample.Hubs;
using Microsoft.AspNet.SignalR;

namespace HackathonManager.WebMvc.Controllers
{
    public class RequestUpdateController : Controller
    {
        // POST: RequestUpdate
        [HttpPost]
        public ActionResult Index(Mentor mentor, Team team, List<SmsDto> smsMessages)
        {
            var mentorRequest = new MentorRequest(mentor, team);

            return View(mentorRequest);
        }

        // GET: RequestUpdate
        public ActionResult Index()
        {
            //Context is the Team Requesting & the Mentor being requested
            //Have loading bar based on text replies
            //Also real time signalr updateding of a view of sms responses
            //Team should be able to mark their mentor as arrived, so should the mentor themselves
            //All of these transactions should be handled through a queue and monitored through the
            //Admin page

            var mentorRequest = new MentorRequest(new Mentor() { FirstName = "Gian" }, new Team() { Name = "ExampleTeam" });

            return View(mentorRequest);
        }

        public JsonResult LongRunningProcess()
        {
            //THIS COULD BE SOME LIST OF DATA
            int itemsCount = 100;

            for (int i = 0; i <= itemsCount; i++)
            {
                //SIMULATING SOME TASK
                Thread.Sleep(250);

                //CALLING A FUNCTION THAT CALCULATES PERCENTAGE AND SENDS THE DATA TO THE CLIENT
                Functions.SendProgress("Process in progress...", i, itemsCount);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}