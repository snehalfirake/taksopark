using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Models;
using Taksopark.MVC.Models;

namespace Taksopark.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserBl _userBl;

        public AccountController(IUserBl userBl)
        {
            _userBl = userBl;
        }
        public ActionResult LogOff()
        {
            Session["UserFullName"] = null;
            Session["UserLogin"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInModel logInModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userBl.GetUserByLoginAndPassword(logInModel.Login, logInModel.Password);
                if (user.UserName != null)
                {
                    Session["UserFullName"] = user.UserName + " " + user.LastName;
                    Session["UserLogin"] = user.Login;
                    System.Web.Security.FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Provided login or password is incorect");
                    return View(logInModel);
                }
            }
            return View(logInModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(RegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                if (!_userBl.IsLoginBooked(registrationModel.Login))
                {
                    var user = new User
                    {
                        LastName = registrationModel.LastName,
                        Login = registrationModel.Login,
                        PhoneNumber = registrationModel.PhoneNumber,
                        Email = registrationModel.Email,
                        Password = registrationModel.Password,
                        Role = "Client",
                        Status = "Active",
                        UserName = registrationModel.FirstName
                    };
                    _userBl.CreateUser(user);
                    Session["UserFullName"] = user.UserName + " " + user.LastName;
                    Session["UserLogin"] = user.Login;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Such login already exists");
                }
            }
            return View(registrationModel);
        }
    }
}