
using System;
using System.Web.Mvc;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Enums;
using Taksopark.DAL.Models;

namespace Taksopark.MVC.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IUserBl _userBl;

        public HomeController(IUserBl userBl)
        {
            _userBl = userBl;
        }
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

        public ActionResult BingMap()
        {
            return PartialView();
        }

        public ActionResult ConPartialView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderTaxi()
        {
            var request = new Request();
            if (User.Identity.IsAuthenticated)
            {
                var user = _userBl.GetUserByLogin(User.Identity.Name);
                request.CreatorId = user.Id;
            }
            else
            {
                request.CreatorId = null;
            }
            request.OperatorId = null;
            request.FinishPoint = Request["txtFrom"];
            request.PhoneNumber = Request["txtPhone"];
            request.StartPoint = Request["txtTo"];
            request.Status = (int) RequestStatusEnum.Active;
            //request.RequesTime = Request["date-time"] == string.Empty
            //    ? DateTime.Now
            //    : DateTime.Parse(Request["date-time"]);
            request.RequesTime = DateTime.Now;

            _userBl.CreateRequest(request);
            return RedirectToAction("Index", "Home");
        }

    }
}