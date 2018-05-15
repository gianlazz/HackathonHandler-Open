using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonManager.WebMvc.Controllers
{
    public class LeaderBoardsController : Controller
    {
        // GET: LeaderBoards
        public ActionResult Index()
        {
            return View();
        }
    }
}