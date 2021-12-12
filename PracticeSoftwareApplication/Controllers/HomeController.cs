using Microsoft.AspNet.Identity.Owin;
using PracticeSoftwareApplication.Abilities;
using PracticeSoftwareApplication.DomainModels;
using PracticeSoftwareApplication.Models;
using PracticeSoftwareApplication.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Controllers
{
    public class HomeController : Controller
    {
        public static string Name => "Home";

        [HttpGet]
        public ActionResult Index(string q, string subject)
        {
            ViewBag.Filter = new FilterViewModel { Query = q, Subject = subject };

            if (string.IsNullOrEmpty(q) && string.IsNullOrEmpty(subject))
            {
                using (var db = ApplicationDbContext.Create())
                {
                    var topTeachers = db.Teachers
                        .Include(nameof(Teacher.Subject))
                        .OrderByDescending(t => t.Votes)
                            .ThenBy(t => t.LastName)
                            .ThenBy(t => t.FirstName)
                        .Take(10)
                        .ToList();

                    return View(topTeachers);
                }
            }
            else
            {
                var searcher = new Searcher();
                var teachers = searcher.Search(q, subject);
                return View(teachers);
            }
        }

        public ActionResult Participate()
        {
            return RedirectToAction("Register", AccountController.Name);
        }

        [HttpPost]
        public ActionResult AddVote(string teacherId)
        {
            if (!VoteAbility.IsAllowed())
                return Json("Failed");

            using (var db = ApplicationDbContext.Create())
            {
                var teacher = db.Teachers.Find(new Guid(teacherId));
                if (teacher == null)
                    return HttpNotFound();

                teacher.Votes += 1;
                db.SaveChanges();

                var cookie = new HttpCookie(GetVoteCookieKey(), teacherId)
                {
                    Expires = DateTime.Now.AddDays(30)
                };
                HttpContext.Response.Cookies.Add(cookie);

                return Json("Success");
            }
        }

        [HttpPost]
        public ActionResult RemoveVote(string teacherId)
        {
            using (var db = ApplicationDbContext.Create())
            {
                var teacher = db.Teachers.Find(new Guid(teacherId));
                if (teacher == null)
                    return HttpNotFound();

                teacher.Votes -= 1;
                db.SaveChanges();

                var existingCookie = HttpContext.Request.Cookies.Get(GetVoteCookieKey());
                if (existingCookie != null)
                {
                    existingCookie.Expires = DateTime.Now.AddSeconds(1);
                    HttpContext.Response.Cookies.Add(existingCookie);
                }

                return Json("Success");
            }
        }

        protected string GetVoteCookieKey()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

            return $"Vote_{user?.Id ?? "ANONYMOUS"}";
        }
    }
}