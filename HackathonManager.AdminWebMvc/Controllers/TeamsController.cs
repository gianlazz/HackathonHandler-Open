using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackathonManager.PocoModels;

namespace HackathonManager.AdminWebMvc.Controllers
{
    public class TeamsController : Controller
    {
        private IRepository _repo = MvcApplication.DbRepo;

        // GET: Teams
        public ActionResult Index()
        {
            var teams = _repo.All<Team>().ToList();

            return View(teams);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            var team = new UniqueTeamFactory(_repo).InstantiateUniquely();
            return View(team);
        }

        // POST: Teams/Create
        [HttpPost]
        public ActionResult Create(Team team)
        {
            try
            {
                // TODO: Add insert logic here
                _repo.Add<Team>(team);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(Guid id)
        {
            Team team;
            if (id == Guid.Empty)
                team = _repo.All<Team>().Where(x => x.GuidId == null).ToList().First();
            else
                team = _repo.All<Team>().Where(x => x.GuidId == id).ToList().First();

            return View(team);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        public ActionResult Edit(Team team)
        {
            try
            {
                // TODO: Add update logic here
                _repo.Delete<Team>(x => x.GuidId == team.GuidId);
                _repo.Add<Team>(team);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Teams/Delete/5
        [HttpPost]
        public ActionResult Delete(Team team)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Delete(team);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
