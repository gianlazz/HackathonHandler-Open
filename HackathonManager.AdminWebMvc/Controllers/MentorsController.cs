using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackathonManager.DTO;
using HackathonManager.PocoModels;
using HackathonManager.RepositoryPattern;

namespace HackathonManager.AdminWebMvc.Controllers
{
    public class MentorsController : Controller
    {
        private IRepository _repo = MvcApplication.DbRepo;
        // GET: Mentors
        public ActionResult Index()
        {
            var mentors = _repo.All<Mentor>().ToList();

            return View(mentors);
        }

        // GET: Mentors/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: Mentors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mentors/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mentors/Edit/5
        public ActionResult Edit(Guid id)
        {
            Mentor mentor;
            if (id == Guid.Empty)
                mentor = _repo.All<Mentor>().Where(x => x.GuidId == null).ToList().First();
            else
                mentor = _repo.All<Mentor>().Where(x => x.GuidId == id).ToList().First();

            return View(mentor);
        }

        // POST: Mentors/Edit/5
        [HttpPost]
        public ActionResult Edit(Mentor mentor)
        {
            try
            {
                // TODO: Add update logic here
                _repo.Delete<Mentor>(x => x.GuidId == mentor.GuidId);
                _repo.Add<Mentor>(mentor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mentors/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Mentors/Delete/5
        [HttpPost]
        public ActionResult Delete(Mentor mentor)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
