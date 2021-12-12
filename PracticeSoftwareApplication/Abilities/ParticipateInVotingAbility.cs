using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSoftwareApplication.Abilities
{
    public class ParticipateInVotingAbility : Ability
    {
        public static bool IsAllowed()
        {
            return new ParticipateInVotingAbility().CheckAvailability();
        }

        protected override bool CheckAvailability()
        {
            bool isRequestAuthenticated = HttpContext.Current.Request.IsAuthenticated;
            if (!isRequestAuthenticated)
                return true;

            bool isAdmin = HttpContext.Current.User.IsInRole("Admin");
            if (isAdmin)
                return true;

            return false;
        }
    }
}