using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Controllers.Admin
{
    [Authorize]
    public class GeneralController : BaseController
    {
        public static string Name => "General";

        public ActionResult Index()
        {
            return View();
        }
    }
}