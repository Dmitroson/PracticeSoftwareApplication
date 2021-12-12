using PracticeSoftwareApplication.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSoftwareApplication.Abilities
{
    public class AddNewAdminUserAbility : Ability
    {
        public static bool IsAllowed()
        {
            return new AddNewAdminUserAbility().CheckAvailability();
        }

        protected override bool CheckAvailability()
        {
            using (var db = ApplicationDbContext.Create())
            {
                var existingAdminUsers = db.Users.Where(u => u.Roles.Any(r => r.RoleId.Equals("Admin"))).ToList();
                return !existingAdminUsers.Any();
            }
        }
    }
}