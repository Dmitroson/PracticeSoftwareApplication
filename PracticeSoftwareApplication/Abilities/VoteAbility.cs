using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSoftwareApplication.Abilities
{
    public class VoteAbility : Ability
    {
        public static bool IsAllowed()
        {
            return new VoteAbility().CheckAvailability();
        }

        protected override bool CheckAvailability()
        {
            var requestInfo = HttpContext.Current.User;
            if (requestInfo.IsInRole("Admin"))
                return false;

            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByNameAsync(requestInfo.Identity.Name).Result;

            var cookie = HttpContext.Current.Request.Cookies.Get($"Vote_{user?.Id ?? "ANONYMOUS"}");
            if (cookie == null)
                return true;

            return false;
        }
    }
}