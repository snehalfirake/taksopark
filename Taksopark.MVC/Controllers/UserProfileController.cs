using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taksopark.MVC.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult GetUserProfile()
        {
            return View();
        }

        public ActionResult GetUserHistory()
        {
            return View();
        }
    }
}