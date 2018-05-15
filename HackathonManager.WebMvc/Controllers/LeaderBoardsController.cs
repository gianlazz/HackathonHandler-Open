using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonManager.WebMvc.Controllers
{
    public class LeaderboardsController : Controller
    {
        // GET: Leaderboards
        public ActionResult Index()
        {
            return View();
        }
    }
}