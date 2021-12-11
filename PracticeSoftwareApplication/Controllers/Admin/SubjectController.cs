using PracticeSoftwareApplication.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Controllers.Admin
{
    public class SubjectController : BaseController
    {
        public static string Name => "Subject";

        [HttpGet]
        public ActionResult Index()
        {
            using (var db = ApplicationDbContext.Create())
            {
                var subjects = db.Subjects.OrderBy(s => s.Name).ToList();
                return View(subjects);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject inputModel)
        {
            if (!ModelState.IsValid)
                return View(inputModel);

            using (var db = ApplicationDbContext.Create())
            {
                inputModel.Id = Guid.NewGuid();
                db.Subjects.Add(inputModel);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            if (id == null)
                return HttpNotFound();

            using (var db = ApplicationDbContext.Create())
            {
                var subject = db.Subjects.Find(id);
                if (subject == null)
                    return HttpNotFound();

                return View(subject);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject inputModel)
        {
            if (!ModelState.IsValid)
                return View(inputModel);

            using (var db = ApplicationDbContext.Create())
            {
                var existingSubject = db.Subjects.Find(inputModel.Id);
                if (existingSubject == null)
                    return HttpNotFound();

                existingSubject.Name = inputModel.Name;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Delete(Guid id)
        {
            if (id == null)
                return HttpNotFound();

            using (var db = ApplicationDbContext.Create())
            {
                var existingSubject = db.Subjects.Find(id);
                if (existingSubject == null)
                    return HttpNotFound();

                db.Subjects.Remove(existingSubject);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}