using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Models;
using Unity.WebForms;
using Taksopark.DAL.Repositories;

namespace Taksopark.WebForms.Dispatcher
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDrivers();
                SetRequest();
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            if (request.Status == "Active")
            {
                confirmButton.Enabled = true;
                rejectButton.Enabled = true;
                closeButton.Enabled = false;

                confirmButton.CssClass = "btn btn-s-md btn-info";
                rejectButton.CssClass = "btn btn-s-md btn-danger";
                closeButton.CssClass = "btn btn-s-md btn-white disabled";
            }
            else if (request.Status == "InProgress")
            {
                confirmButton.Enabled = false;
                rejectButton.Enabled = true;
                closeButton.Enabled = true;

                confirmButton.CssClass = "btn btn-s-md btn-white disabled";
                rejectButton.CssClass = "btn btn-s-md btn-danger";
                closeButton.CssClass = "btn btn-s-md btn-success";
            }
            else if (request.Status == "Rejected")
            {
                confirmButton.Enabled = true;
                rejectButton.Enabled = false;
                closeButton.Enabled = false;

                confirmButton.CssClass = "btn btn-s-md btn-info";
                rejectButton.CssClass = "btn btn-s-md btn-white disabled";
                closeButton.CssClass = "btn btn-s-md btn-white disabled";
            }
            else if (request.Status == "Closed")
            {
                confirmButton.Enabled = false;
                rejectButton.Enabled = false;
                closeButton.Enabled = false;

                confirmButton.CssClass = "btn btn-s-md btn-white disabled";
                rejectButton.CssClass = "btn btn-s-md btn-white disabled";
                closeButton.CssClass = "btn btn-s-md btn-white disabled";
            }
            else
            {
                throw new Exception("Wrong status data " + request.Status);
            }
        }

        private void GetDrivers()
        {
            IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();

            driversDropDownList.DataSource = adminBl.GetAllDrivers();
            driversDropDownList.DataValueField = "Id";
            driversDropDownList.DataTextField = "DriverInfo";
            driversDropDownList.DataBind();
        }

        private static Request request;

        private void SetRequest()
        {
            var operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            request = operatorBl.GetRequestById(Convert.ToInt32(Request.QueryString["id"]));

            //detailsView1.DataSource = new List<Request>() { request };
            //detailsView1.DataBind();

            RequestInfo info = new RequestInfo(request);

            formView.DataSource = new List<Request>() { info };
            formView.DataBind();

            //orderInfo.DataSource1 = new List<Request>() { request };
            //orderInfo.DataBind();
        }

        public Request GetRequest(object id)
        {
            //var operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            //request = operatorBl.GetRequestById(Convert.ToInt32(id));

            //return request;

            return null;
        }

        private void UpdateRequestStatus(string status)
        {
            request.Status = status;
            request.DriverId = null;
            var operatorBL = HttpContext.Current.Application.GetContainer().Resolve<OperatorBl>();
            operatorBL.UpdateRequest(request);
        }

        private void UpdateRequestStatus(string status, int driverid, bool submiting)
        {
            request.Status = status;

            if (request.DriverId == null)
            {
                request.DriverId = driverid;
            }
            else if (submiting)
            {
                request.DriverId = driverid;
            }

            var operatorBL = HttpContext.Current.Application.GetContainer().Resolve<OperatorBl>();
            operatorBL.UpdateRequest(request);
        }

        private void UpdateDriver(string status)
        {
            if (request.DriverId == null)
                return;

            var operatorBL = HttpContext.Current.Application.GetContainer().Resolve<OperatorBl>();
            var driver = operatorBL.GetUserById((int)request.DriverId);
            UserBl userBL = HttpContext.Current.Application.GetContainer().Resolve<UserBl>();

            driver.Status = status;

            userBL.UpdateUser(driver);
        }

        protected void ComfirmButton_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus("InProgress", Convert.ToInt32(driversDropDownList.SelectedValue), true);

            UpdateDriver("Busy");
        }

        protected void rejectButton_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus("Rejected");

            UpdateDriver("Free");
        }

        protected void closeButton_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus("Closed", Convert.ToInt32(driversDropDownList.SelectedValue), false);
            UpdateDriver("Free");
        }
    }

    public class RequestInfo : Request
    {
        public RequestInfo(Request request)
        {
            this.Id = request.Id;
            this.CreatorId = request.CreatorId;
            this.OperatorId = request.OperatorId;
            this.DriverId = request.DriverId;
            this.PhoneNumber = request.PhoneNumber;
            this.Price = request.Price;
            this.RequesTime = request.RequesTime;
            this.StartPoint = request.StartPoint;
            this.FinishPoint = request.FinishPoint;
            this.Status = request.Status;
        }

        private string _status = "Active";

        public new string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;

                if (_status == "Active")
                {
                    _status = "~/Images/StatusImages/Active.png";
                }
                else if (_status == "InProgress")
                {
                    _status = "~/Images/StatusImages/InProgress.png";
                }
                else if (_status == "Rejected")
                {
                    _status = "~/Images/StatusImages/Rejected.png";
                }
                else if (_status == "Closed")
                {
                    _status = "~/Images/StatusImages/Closed.png";
                }
            }
        }

        private string _created = string.Empty;
        public string CreatedAt
        {
            get
            {
                return GetDate();
            }
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }

        protected String GetDate()
        {

            var subtract = DateTime.Now.Subtract(RequesTime);

            string timeAgo;
            if (subtract.Days == 0)
            {
                if (subtract.Hours > 0)
                {
                    switch (subtract.Hours)
                    {
                        case 1:
                            timeAgo = "hour";
                            break;
                        default:
                            timeAgo = "hours";
                            break;
                    }

                    return String.Format("{0} {1} ago", subtract.Hours, timeAgo);
                }
                if (subtract.Minutes > 0)
                {
                    switch (subtract.Minutes)
                    {
                        case 1:
                            timeAgo = "minute";
                            break;
                        default:
                            timeAgo = "minutes";
                            break;
                    }

                    return String.Format("{0} {1} ago", subtract.Minutes, timeAgo);
                }

                return String.Format("{0} sec ago", subtract.Seconds);
            }

            return String.Format("{0} {1} {2}", RequesTime.Day, months[RequesTime.Month - 1], RequesTime.Year, subtract.Days);
        }

        private string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    }
}