using PracticeSoftwareApplication.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = ApplicationDbContext.Create())
            {
                var topTeachers = db.Teachers
                    .OrderByDescending(t => t.Votes)
                    .ThenBy(t => t.LastName)
                    .ThenBy(t => t.FirstName)
                    .Take(10)
                    .ToList();

                return View(topTeachers);
            }
        }
    }
}