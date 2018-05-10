using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackathonManager.DTO;
using HackathonManager.PocoModels;

namespace HackathonManager.AdminWebMvc.Controllers
{
    public class MentorsController : Controller
    {

        // GET: Mentors
        public ActionResult Index()
        {
            var repo = MvcApplication.DbRepo;
            var mentors = repo.All<Mentor>().ToList();

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
            return View();
        }

        // POST: Mentors/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
        public ActionResult Delete(Guid id, FormCollection collection)
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
