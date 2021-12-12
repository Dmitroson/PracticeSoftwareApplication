using Microsoft.AspNet.Identity.EntityFramework;
using PracticeSoftwareApplication.Abilities;
using PracticeSoftwareApplication.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PracticeSoftwareApplication.Controllers.Authorization
{
    public class AllowNewAdminUsersRegistrationAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!AddNewAdminUserAbility.IsAllowed())
                filterContext.Result = new RedirectResult("/admin");
        }
    }
}