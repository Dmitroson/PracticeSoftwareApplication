using PracticeSoftwareApplication.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Controllers.Admin
{
    [Authorize]
    public class TeachersController : BaseController
    {
        public static string Name => "Teachers";

        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var teachers = db.Teachers.ToList();
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
        public ActionResult Create(Teacher inputModel)
        {
            if (!ModelState.IsValid)
                return View(inputModel);

            using (var db = new ApplicationDbContext())
            {

            }

            return View(inputModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher inputModel)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}