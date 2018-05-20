using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackathonManager.DIContext;
using HackathonManager.DTO;

namespace HackathonManager.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var Db = MvcApplication.DbRepo;

            //var db = Context.GetMLabsMongoDbRepo();
            var model = new List<Mentor>();
            model = Db.All<Mentor>().Where(x => x.IsPresent == true).ToList().OrderBy(e => e.IsAvailable ? 0 : 1).ToList();
            //model = Db.All<Mentor>().Where(x => x.IsPresent == true).ToList();

            //mentorViewModel.PresentMentors = repo.All<Mentor>().Where(x => x.IsPresent == true).ToList();
            //mentorViewModel.AvailableMentors = repo.All<Mentor>().Where(x => x.IsAvailable == true).ToList();

            return View(model);
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