using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Enums;
using Taksopark.DAL.Models;
using Taksopark.MVC.Models;

namespace Taksopark.MVC.Controllers
{
    [Authorize]
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
            var user = _userBl.GetUserByLogin(User.Identity.Name);
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
                    Role = (int) RolesEnum.Client,
                    Status = (int) UserStatusEnum.Active,
                    Password = editProfileModel.Password,
                    DriverStatus = null,
                };
                _userBl.UpdateUser(user);
                //Session["UserFullName"] = user.UserName + " " + user.LastName;
                return RedirectToAction("Index", "Home");   
            }
            return View(editProfileModel);
        }


        public ActionResult GetUserHistory()
        {
            var user = _userBl.GetUserByLogin(User.Identity.Name);
            var requestList = _userBl.GetAllRequestsByCreatorID(user.Id);
            var requestModelList = new List<RequestModel>();
            foreach (var request in requestList)
            {
                var requestModel = new RequestModel
                {
                    RequestId = request.Id,
                    PhoneNumber = request.PhoneNumber,
                    FinishPoint = request.FinishPoint,
                    StartPoint = request.StartPoint,
                    RequesTime = request.RequesTime
                };
                switch (request.Status)
                {
                    case (int) RequestStatusEnum.Active:
                    {
                        requestModel.Status = "Active";
                        break;
                    }
                    case (int)RequestStatusEnum.Closed:
                    {
                        requestModel.Status = "Closed";
                        break;
                    }
                    case (int)RequestStatusEnum.InProgress:
                    {
                        requestModel.Status = "In Progress";
                        break;
                    }
                    case (int)RequestStatusEnum.Rejected:
                    {
                        requestModel.Status = "Rejected";
                        break;
                    }
                }
                requestModelList.Add(requestModel);
            }
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
            };
            switch (request.Status)
            {
                case (int) RequestStatusEnum.Active:
                {
                    requestModel.Status = "Active";
                    break;
                }
                case (int) RequestStatusEnum.Closed:
                {
                    requestModel.Status = "Closed";
                    break;
                }
                case (int) RequestStatusEnum.InProgress:
                {
                    requestModel.Status = "In Progress";
                    break;
                }
                case (int) RequestStatusEnum.Rejected:
                {
                    requestModel.Status = "Rejected";
                    break;
                }
            }
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
            };
            switch (request.Status)
            {
                case (int) RequestStatusEnum.Active:
                {
                    requestModel.Status = "Active";
                    break;
                }
                case (int) RequestStatusEnum.Closed:
                {
                    requestModel.Status = "Closed";
                    break;
                }
                case (int) RequestStatusEnum.InProgress:
                {
                    requestModel.Status = "In Progress";
                    break;
                }
                case (int) RequestStatusEnum.Rejected:
                {
                    requestModel.Status = "Rejected";
                    break;
                }
            }
            return View(requestModel);
        }


        public ActionResult DiscardRequest(int id)
        {
            var request = _userBl.GetRequestById(id);
            request.Status = (int) RequestStatusEnum.Rejected;
            _userBl.UpdateRequest(request);
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
                    Id = requestModel.RequestId
                };
                switch (requestModel.Status)
                {
                    case "Active" :
                    {
                        request.Status = (int)RequestStatusEnum.Active;
                        break;
                    }
                    case "Closed":
                    {
                        request.Status = (int) RequestStatusEnum.Closed;
                        break;
                    }
                    case "In Progress":
                    {
                        request.Status = (int) RequestStatusEnum.InProgress;
                        break;
                    }
                    case "Rejected":
                    {
                        request.Status = (int) RequestStatusEnum.Rejected;
                        break;
                    }
                }
                _userBl.UpdateRequest(request);
                return RedirectToAction("GetUserHistory", "UserProfile");
            }
            return View(requestModel);
        }

        [HttpGet]
        public ActionResult AddComent(int id)
        {
            var user = _userBl.GetUserByLogin(User.Identity.Name);
            var commentModel = new CommentModel()
            {
                CreatorId = user.Id,
                CommentText = null,
                RequestId = id
            };
            return View(commentModel);
        }

        [HttpPost]
        public ActionResult AddComent(CommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    CommentText = commentModel.CommentText,
                    CreatorId = commentModel.CreatorId,
                    RequestId = commentModel.RequestId
                };
                _userBl.CreateComment(comment);
                return RedirectToAction("GetRequestDetails" + "/" + Convert.ToString(commentModel.RequestId), "UserProfile");
            }
            return View(commentModel);
        }

        //[HttpGet]
        public ActionResult GetCommentsList(int requestId)
        {
            var commentList = new List<CommentModel>();
            var comments = _userBl.GetAllCommentsByRequestId(requestId);
            foreach (var comment in comments)
            {
                var commentModel = new CommentModel()
                {
                    Id = comment.Id,
                    CommentText = comment.CommentText,
                    RequestId = comment.RequestId,
                    CreatorId = comment.CreatorId
                };
                commentList.Add(commentModel);
            }
            return View(commentList);
        }
    }
}