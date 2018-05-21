using HackathonManager.PocoModels;
using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonManager.WebMvc.Controllers
{
    public class TeamsController : Controller
    {
        private IRepository _Db = MvcApplication.DbRepo;

        // GET: Teams
        public ActionResult Index()
        {
            var teams = _Db.All<Team>();
            return View(teams);
        }
    }
}