using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackathonManager.Persistance;
using HackathonManager.Mvc.Models;
//using HackathonManager.DIContext;

namespace HackathonManager.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HackathonManagerEntities db = new HackathonManagerEntities();
            MentorViewModel mentorViewModel = new MentorViewModel();

            mentorViewModel.Mentors =  db.Mentors.ToList();
            mentorViewModel.PresentMentors = db.Mentors.Where(o => o.IsPresent == true).ToList();
            mentorViewModel.AvailableMentors = db.Mentors.Where(o => o.IsAvailable == true).ToList();

            //var repo = Context.GetMLabsMongoDbRepo();
            //mentorViewModel.Mentors = repo.All<Mentor>() as List<Mentor>;
            //mentorViewModel.PresentMentors = repo.All<Mentor>().Where(x => x.IsPresent == true).ToList();
            //mentorViewModel.AvailableMentors = repo.All<Mentor>().Where(x => x.IsAvailable == true).ToList();

            return View(mentorViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}