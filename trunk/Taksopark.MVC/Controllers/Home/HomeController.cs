
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
        private readonly string _connection = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
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
                var userBl = new UserBl(_connection);
                var user = new User {LastName = registrationModel.LastName, 
                    Login = registrationModel.Login, 
                    Password = registrationModel.Password, 
                    Role = "Client", Status = "Active",
                    UserName = registrationModel.FirstName};
                userBl.CreateUser(user);
            }
            return View(registrationModel);
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

        [HttpGet]
        public ActionResult OrderTaxi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderTaxi(FormCollection form)
        {
            var sqlConnection = new SqlConnection(_connection);
            var request = new RequestRepository(sqlConnection);
            request.Create(new Request
            {
                CreatorId = 1,
                FinishPoint = form["txtFrom"],
                OperatorId = 1,
                PhoneNumber = form["txtPhone"],
                StartPoint = form["txtTo"],
                RequesTime = DateTime.Parse(form["date-time"]),
                Status = "Active"
            });

            return View();
        }

    }
}