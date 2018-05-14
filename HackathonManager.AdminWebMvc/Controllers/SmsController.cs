using HackathonManager.DTO;
using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonManager.AdminWebMvc.Controllers
{
    public class SmsController : Controller
    {
        private IRepository _repo = MvcApplication.DbRepo;
        // GET: Mentors
        public ActionResult Index()
        {
            var messages = _repo.All<SmsDto>().ToList();

            return View(messages);
        }
    }
}
