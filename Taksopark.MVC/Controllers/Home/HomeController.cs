
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
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
        public JsonResult OrderTaxi(string from, string to, string phone, string date, string service)
        {
            if (IsOrderValid(from, to, phone))
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
                request.FinishPoint = to;
                request.PhoneNumber = phone;
                request.StartPoint = from;
                request.Status = (int) RequestStatusEnum.Active;
                if (date == "")
                {
                    request.RequesTime = DateTime.Now;
                }
                else
                {
                    request.RequesTime = DateTime.Parse(date);
                }
                request.Additional = service;
                int requestId = _userBl.CreateRequest(request);
                return Json(new
                {
                    RequestId = requestId
                });
            }
            else
            {
                return Json(new
                {
                    ValidationError = "The spacified order is invalid"
                });
            }
        }

        [HttpPost]
        public ActionResult CalcEstimatedCost(decimal distance, bool isTracking, decimal? animalWeight, bool isHaulage)
        {
            decimal cost = this._userBl.GetEstimatedCost(distance, isTracking, animalWeight, isHaulage);
            return Json(new
                {
                    EstimatedCost = cost
                });
        }

        private bool IsOrderValid(string @from, string to, string phone)
        {
            var placeFromToReg =
                new Regex(
                    @"^[A-Za-zА-ЯЄІЇҐа-яєіїґ-]{3,30}[\ \]{0,1}[A-Za-zА-ЯЄІЇҐа-яєіїґ-]{0,30}[\ \]{0,1}[A-Za-zА-ЯЄІЇҐа-яєіїґ-]{0,30}[\ \]{0,1}[0-9]{0,4}[\ \]{0,1}[A-Za-zА-ЯЄІЇҐа-яєіїґ-]{0,1}$");
            var phoneReg = new Regex(@"^[(]{0,1}[0-9]{3}[)]{0,1}[-\ \.]{0,1}[0-9]{3}[-\ \.]{0,1}[0-9]{4}$");

            var placeFromMatch = placeFromToReg.Match(@from);
            Match placeToMatch = placeFromToReg.Match(to);
            Match phoneMatch = phoneReg.Match(phone);
            
            return placeFromMatch.Success && placeToMatch.Success && phoneMatch.Success;
        }
    }
}