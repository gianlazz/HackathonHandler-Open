using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackathonManager.Persistance;
using HackathonManager.Mvc.Models;

namespace HackathonManager.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HackathonManagerEntities db = new HackathonManagerEntities();
            MentorViewModel mentorViewModel = new MentorViewModel();

            mentorViewModel.Mentors =  db.Mentors.ToList();

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