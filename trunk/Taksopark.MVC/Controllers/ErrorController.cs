using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taksopark.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult General(Exception exception)
        {
            return View("ErrorView", exception);
        }

        public ActionResult Http404()
        {
            return View("Error404");
        }

        public ActionResult Http403()
        {
            return View("Error403");
        }
	}
}