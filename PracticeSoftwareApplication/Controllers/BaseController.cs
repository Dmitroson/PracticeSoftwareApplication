using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSoftwareApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        public ActionResult TestMethod()
        {
            return null;
        }

        public string TestMethod2()
        {
            return null;
        }
    }
}