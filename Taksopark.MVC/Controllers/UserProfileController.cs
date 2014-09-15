using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Taksopark.BL;
using Taksopark.DAL.Models;
using Taksopark.MVC.Models;

namespace Taksopark.MVC.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly string _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        [HttpGet]
        public ActionResult GetUserProfile()
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userBl = new UserBl(_connectionString);
            var user = userBl.GetUserByLogin((string) Session["UserLogin"]);
            var editProfileModel = new EditProfileModel
            {
                Id = user.Id,
                FirstName = user.UserName,
                LastName = user.LastName,
                Login = user.Login,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.Password
            };
            return View(editProfileModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetUserProfile(EditProfileModel editProfileModel)
        {
            if (ModelState.IsValid)
            {
                var userBl = new UserBl(_connectionString);
                var user = new User
                {
                    LastName = editProfileModel.LastName,
                    UserName = editProfileModel.FirstName,
                    PhoneNumber = editProfileModel.PhoneNumber,
                    Email = editProfileModel.Email,
                    Id = editProfileModel.Id,
                    Login = editProfileModel.Login,
                    Role = "Client",
                    Status = "Active",
                    Password = editProfileModel.Password
                };
                userBl.UpdateUser(user);
                Session["UserFullName"] = user.UserName + " " + user.LastName;
                return RedirectToAction("Index", "Home");   
            }
            return View(editProfileModel);
        }

        public ActionResult GetUserHistory()
        {
            return View();
        }
    }
}