using Microsoft.AspNet.Identity;
using PracticeSoftwareApplication.DomainModels;
using PracticeSoftwareApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Controllers.Admin
{
    public class TeachersController : AdminController
    {
        public static string Name => "Teachers";

        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var teachers = db.Teachers
                    .Include(nameof(Teacher.Subject))
                    .OrderBy(t => t.LastName)
                    .ThenBy(t => t.FirstName)
                    .ToList();
                return View(teachers);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var teacher = CreateTeacher(model);
                teacher.ApplicationUserId = user.Id;
                using (var db = ApplicationDbContext.Create())
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            AddErrors(result);

            return View(model);
        }

        protected Teacher CreateTeacher(RegisterViewModel model)
        {
            return new Teacher
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                SubjectId = model.SubjectId,
                WorkPlace = model.WorkPlace,
                Votes = 0
            };
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            if (id == null)
                return HttpNotFound();

            using (var db = ApplicationDbContext.Create())
            {
                var teacher = db.Teachers.Find(id);
                if (teacher == null)
                    return HttpNotFound();

                return View(teacher);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var db = ApplicationDbContext.Create())
            {
                var existingTeacher = db.Teachers.Find(model.Id);
                if (existingTeacher == null)
                    return HttpNotFound();

                existingTeacher.FirstName = model.FirstName;
                existingTeacher.MiddleName = model.MiddleName;
                existingTeacher.LastName = model.LastName;
                existingTeacher.SubjectId = model.SubjectId;
                existingTeacher.WorkPlace = model.WorkPlace;
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
                var existingTeachers = db.Teachers.Find(id);
                if (existingTeachers == null)
                    return HttpNotFound();

                db.Teachers.Remove(existingTeachers);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}