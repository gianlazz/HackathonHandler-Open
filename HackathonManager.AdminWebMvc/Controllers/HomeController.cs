using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackathonManager.DTO;
using HackathonManager.PocoModels;
using HackathonManager.AdminWebMvc.Models;

namespace HackathonManager.AdminWebMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OverViewModel overView = new OverViewModel();
            overView.Mentors = new List<Mentor>();
            overView.Judges = new List<Judge>();
            overView.Teams = new List<Team>();
            var repo = MvcApplication.DbRepo;

            //overView.Mentors.AddRange(repo.All<Mentor>().Where(x => x.Event == "seattle-eastside"));
            try
            {
                overView.Mentors.AddRange(repo.All<Mentor>().ToList());
                overView.Judges.AddRange(repo.All<Judge>().ToList());
                overView.Teams.AddRange(repo.All<Team>().ToList());
            }
            catch (Exception)
            {
                
            }

            return View(overView);
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

        public ActionResult Sms()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Teams()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Judges()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}