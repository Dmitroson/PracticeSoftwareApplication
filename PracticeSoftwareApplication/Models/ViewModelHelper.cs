using Microsoft.AspNet.Identity.Owin;
using PracticeSoftwareApplication.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Models
{
    public class ViewModelHelper
    {
        public static SelectList CreateSubjectsSelectList(Guid? selectedSubjectId)
        {
            using (var db = ApplicationDbContext.Create())
            {
                var subjects = db.Subjects.OrderBy(s => s.Name).ToList();
                var selectedSubject = subjects.SingleOrDefault(s => s.Id.Equals(selectedSubjectId));
                return new SelectList(subjects, "Id", "Name", selectedSubject);
            }
        }

        public static string GetFullName(Teacher teacher)
        {
            return string.Join(" ", teacher.LastName, teacher.FirstName, teacher.MiddleName);
        }

        protected static string GetVoteCookieKey()
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByNameAsync(HttpContext.Current.User.Identity.Name).Result;

            return $"Vote_{user?.Id ?? "ANONYMOUS"}";
        }

        public static string GetVoteCookieValue()
        {
            return HttpContext.Current.Request.Cookies.Get(GetVoteCookieKey())?.Value;
        }
    }
}