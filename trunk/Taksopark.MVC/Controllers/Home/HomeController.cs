
using System.Web.Mvc;

namespace Taksopark.MVC.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult UserInfo()
        {
            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult ErrorView()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult Error500()
        {
            return View();
        }
    }
}