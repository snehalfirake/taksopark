using System.Linq;
using System.Web.Mvc;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Models;
using Taksopark.MVC.Models;

namespace Taksopark.MVC.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserBl _userBl;

        public UserProfileController(IUserBl userBl)
        {
            _userBl = userBl;
        }

        [HttpGet]
        public ActionResult GetUserProfile()
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user = _userBl.GetUserByLogin((string)Session["UserLogin"]);
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
                _userBl.UpdateUser(user);
                Session["UserFullName"] = user.UserName + " " + user.LastName;
                return RedirectToAction("Index", "Home");   
            }
            return View(editProfileModel);
        }

        public ActionResult GetUserHistory()
        {
            var userBl = new UserBl();
            var user = userBl.GetUserByLogin((string) Session["UserLogin"]);
            var requestList = userBl.GetAllRequestsByCreatorID(user.Id);
            var requestModelList = requestList.Select(request => new RequestModel
            {
                RequestId = request.Id, PhoneNumber = request.PhoneNumber, FinishPoint = request.FinishPoint, StartPoint = request.StartPoint, RequesTime = request.RequesTime, Status = request.Status
            }).ToList();
            return View(requestModelList);
        }


        public ActionResult GetRequestDetails(int id)
        {
            var request = _userBl.GetRequestById(id);
            var requestModel = new RequestModel
            {
                RequestId = request.Id,
                FinishPoint = request.FinishPoint,
                StartPoint = request.StartPoint,
                PhoneNumber = request.PhoneNumber,
                RequesTime = request.RequesTime,
                Status = request.Status
            };

            return View(requestModel);
        }

        public ActionResult EditRequest(int id)
        {
            var request = _userBl.GetRequestById(id);
            var requestModel = new RequestModel
            {
                RequestId = request.Id,
                FinishPoint = request.FinishPoint,
                StartPoint = request.StartPoint,
                PhoneNumber = request.PhoneNumber,
                RequesTime = request.RequesTime,
                Status = request.Status
            };
            return View(requestModel);
        }

        public ActionResult DiscardRequest(int id)
        {
            var userBl = new UserBl();
            var request = userBl.GetRequestById(id);
            request.Status = "Discard";
            userBl.UpdateRequest(request);
            return RedirectToAction("GetUserHistory", "UserProfile");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRequest(RequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var request = new Request
                {
                    FinishPoint = requestModel.FinishPoint,
                    StartPoint = requestModel.StartPoint,
                    PhoneNumber = requestModel.PhoneNumber,
                    RequesTime = requestModel.RequesTime,
                    Status = requestModel.Status,
                    Id = requestModel.RequestId
                };
                _userBl.UpdateRequest(request);
                return RedirectToAction("GetUserHistory", "UserProfile");
            }
            return View(requestModel);
        }
    }
}