using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Controllers.Admin
{
    public class GeneralController : AdminController
    {
        public static string Name => "General";

        public ActionResult Index()
        {
            return RedirectToAction("Index", TeachersController.Name);
        }
    }
}