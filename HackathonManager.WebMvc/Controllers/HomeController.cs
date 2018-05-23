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

        public ActionResult SetTeam()
        {
            HttpCookie cookie = Request.Cookies["team"];
            if (cookie == null)
            {
                Response.Cookies["team"].Value = "ExampleTeam";
                Response.Cookies["team"].Expires = DateTime.UtcNow.AddDays(3);
            }
            else
            {
                return RedirectToAction("Index");
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

        //public ActionResult Index()
        //{
        //    HttpCookie cookie = Request.Cookies["temp"];
        //    if (cookie == null)
        //    {
        //        ViewData["Message"] = "Cookie Not Found";
        //        Response.Cookies["temp"].Value = "This is a cookie: Welcome to ASP.NET MVC!";
        //        Response.Cookies["temp"].Expires = DateTime.UtcNow.AddDays(3);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Something");
        //    }
        //    return View();
        //}

        public ActionResult Something()
        {
            HttpCookie cookie = Request.Cookies["temp"];
            ViewData["Message"] = cookie.Value;
            return View();
        }
    }
}