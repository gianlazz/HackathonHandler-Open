using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackathonManager.DIContext;
using HackathonManager.DTO;
using HackathonManager.PocoModels;
using Microsoft.AspNet.SignalR;
using SignalRProgressBarSimpleExample.Hubs;

namespace HackathonManager.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
            string id = (string)hubContext.Clients.All.GetConnectionId().Result;

            var Db = MvcApplication.DbRepo;

            //var db = Context.GetMLabsMongoDbRepo();
            var model = new List<Mentor>();
            model = Db.All<Mentor>().Where(x => x.IsPresent == true).ToList().OrderBy(e => e.IsAvailable ? 0 : 1).ToList();
            //model = Db.All<Mentor>().Where(x => x.IsPresent == true).ToList();

            //mentorViewModel.PresentMentors = repo.All<Mentor>().Where(x => x.IsPresent == true).ToList();
            //mentorViewModel.AvailableMentors = repo.All<Mentor>().Where(x => x.IsAvailable == true).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult TeamLogin(int teamPin)
        {
            var Db = MvcApplication.DbRepo;

            HttpCookie cookie = Request.Cookies["team"];

            //CHECK IF A TEAM BY THAT PIN NUMBER EXSISTS
            if (Db.Single<Team>(x => x.PinNumber == teamPin) != null)
            {
                Team team = Db.Single<Team>(x => x.PinNumber == teamPin);

                if (cookie == null)
                {
                    Response.Cookies["team"].Value = team.Name;
                    Response.Cookies["team"].Expires = DateTime.UtcNow.AddDays(3);
                }
                if (cookie != null && cookie.Value == "")
                {
                    Response.Cookies["team"].Value = team.Name;
                    Response.Cookies["team"].Expires = DateTime.UtcNow.AddDays(3);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = Request.Cookies["team"];
            if (cookie != null)
            {
                Response.Cookies["team"].Value = "";
            }
            else
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult MentorRequest(int teamPin, Guid mentorGuidId)
        {
            var Db = MvcApplication.DbRepo;
            try
            {
                var team = Db.Single<Team>(x => x.PinNumber == teamPin);
                var mentor = Db.Single<Mentor>(x => x.GuidId == mentorGuidId);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}