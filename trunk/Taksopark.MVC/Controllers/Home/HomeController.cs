
using System.Web.Mvc;
using Taksopark.MVC.Models;

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

        public ActionResult BingMap()
        {
            return PartialView();
        }

        public ActionResult ConPartialView()
        {
            return View();
        }


        public ActionResult OrderTaxi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderTaxi(FormCollection form)
        {
            var direction = new TaxiOrdering {PlaceFrom = form["txtFrom"], PlaceTo = form["txtTo"]};
            return View("OrderTaxi", direction);
        }
    }
}