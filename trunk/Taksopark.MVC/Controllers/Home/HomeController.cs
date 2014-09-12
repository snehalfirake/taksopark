
using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Web.Configuration;
using System.Web.Mvc;
using Taksopark.BL;
using Taksopark.DAL.Models;
using Taksopark.DAL.Repositories;
using Taksopark.DAL.Repositories.Interfases;
using Taksopark.MVC.Models;

namespace Taksopark.MVC.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        private readonly string _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(RegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                var userBl = new UserBl(_connectionString);
                if (!userBl.IsLoginBooked(registrationModel.Login))
                {
                    var user = new User
                    {
                        LastName = registrationModel.LastName,
                        Login = registrationModel.Login,
                        Password = registrationModel.Password,
                        Role = "Client",
                        Status = "Active",
                        UserName = registrationModel.FirstName
                    };
                    userBl.CreateUser(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(registrationModel);
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
            var userBl = new UserBl(_connectionString);
            var request = new Request
            {
                CreatorId = 5,
                FinishPoint = Request["txtFrom"],
                OperatorId = 3,
                PhoneNumber = Request["txtPhone"],
                StartPoint = Request["txtTo"],
                Status = "Active",
                RequesTime = Request["date-time"] == string.Empty ? DateTime.Now : DateTime.Parse(Request["date-time"])
            };
            userBl.CreateRequest(request);
            return RedirectToAction("Index", "Home");
        }

    }
}