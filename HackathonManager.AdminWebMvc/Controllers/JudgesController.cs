using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonManager.AdminWebMvc.Controllers
{
    public class JudgesController : Controller
    {
        private IRepository _repo = MvcApplication.DbRepo;

        // GET: Judges
        public ActionResult Index()
        {
            var judges = _repo.All<Judge>().ToList();

            return View(judges);
        }

        // GET: Judges/Create
        public ActionResult Create()
        {
            var judge = new Judge();
            return View(judge);
        }

        // POST: Judges/Create
        [HttpPost]
        public ActionResult Create(Judge judge)
        {
            try
            {
                // TODO: Add insert logic here
                _repo.Add<Judge>(judge);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Judges/Edit/5
        public ActionResult Edit(Guid id)
        {
            Judge judge;
            if (id == Guid.Empty)
                judge = _repo.All<Judge>().Where(x => x.GuidId == null).ToList().First();
            else
                judge = _repo.All<Judge>().Where(x => x.GuidId == id).ToList().First();

            return View(judge);
        }

        // POST: Judges/Edit/5
        [HttpPost]
        public ActionResult Edit(Judge judge)
        {
            try
            {
                // TODO: Add update logic here
                _repo.Delete<Judge>(x => x.GuidId == judge.GuidId);
                _repo.Add<Judge>(judge);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Judges/Delete/5
        [HttpPost]
        public ActionResult Delete(Judge judge)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Delete(judge);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
