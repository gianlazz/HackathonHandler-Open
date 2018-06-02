using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonManager.WebMvc.Controllers
{
    public class JudgesController : Controller
    {
        private IRepository _Db = MvcApplication._dbRepo;

        // GET: Judges
        public ActionResult Index()
        {
            var judges = _Db.All<Judge>().ToList();
            return View(judges);
        }
    }
}
