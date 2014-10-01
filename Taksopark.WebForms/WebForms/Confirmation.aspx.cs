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
using Taksopark.DAL.Enums;
using Taksopark.DAL.Models;
using Unity.WebForms;
using Taksopark.DAL.Repositories;
using Taksopark.WebForms.Models;

namespace Taksopark.WebForms.Dispatcher
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetRequest();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            bool driversAvaliable = GetDrivers();

            UpdateOrderButtons(driversAvaliable);
            SetRequest();
        }

        private void UpdateOrderButtons(bool driversAvaliable)
        {
            if (!driversAvaliable)
            {
                confirmButton.Enabled = false;
                rejectButton.Enabled = false;
                closeButton.Enabled = false;

                confirmButton.CssClass = "btn btn-s-md btn-disabled";
                rejectButton.CssClass = "btn btn-s-md btn-disabled";
                closeButton.CssClass = "btn btn-s-md btn-white disabled";
            }
            else if (request.Status == (int)RequestStatusEnum.Active)
            {
                confirmButton.Enabled = true;
                rejectButton.Enabled = true;
                closeButton.Enabled = false;

                confirmButton.CssClass = "btn btn-s-md btn-info";
                rejectButton.CssClass = "btn btn-s-md btn-danger";
                closeButton.CssClass = "btn btn-s-md btn-white disabled";
            }
            else if (request.Status == (int)RequestStatusEnum.InProgress)
            {
                confirmButton.Enabled = false;
                rejectButton.Enabled = true;
                closeButton.Enabled = true;

                confirmButton.CssClass = "btn btn-s-md btn-white disabled";
                rejectButton.CssClass = "btn btn-s-md btn-danger";
                closeButton.CssClass = "btn btn-s-md btn-success";
            }
            else if (request.Status == (int)RequestStatusEnum.Rejected)
            {
                confirmButton.Enabled = true;
                rejectButton.Enabled = false;
                closeButton.Enabled = false;

                confirmButton.CssClass = "btn btn-s-md btn-info";
                rejectButton.CssClass = "btn btn-s-md btn-white disabled";
                closeButton.CssClass = "btn btn-s-md btn-white disabled";
            }
            else if (request.Status == (int)RequestStatusEnum.Closed)
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

        private bool GetDrivers()
        {
            IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();

            var drivers = adminBl.GetAllDriversByStatus((int)Enum.Parse(typeof(DriverStatusEnum), "Free"));
            driversDropDownList.DataSource = drivers;
            driversDropDownList.DataValueField = "Id";
            driversDropDownList.DataTextField = "DriverInfo";
            driversDropDownList.DataBind();

            if (drivers.Count < 1)
            {
                return false;
            }

            return true;
        }

        private static Request request;

        private void SetRequest()
        {
            var operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            request = operatorBl.GetRequestById(Convert.ToInt32(Request.QueryString["id"]));

            var info = new RequestModel(request);

            formView.DataSource = new List<Request>() { info };
            formView.DataBind();
        }

        public Request GetRequest(object id)
        {
            //var operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            //request = operatorBl.GetRequestById(Convert.ToInt32(id));

            //return request;

            return null;
        }

        private void UpdateRequestStatus(int status)
        {
            request.Status = status;
            request.DriverId = null;
            var operatorBL = HttpContext.Current.Application.GetContainer().Resolve<OperatorBl>();
            operatorBL.UpdateRequest(request);
        }

        private void UpdateRequestStatus(int status, int driverid, bool submiting)
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

            driver.Status = (int)Enum.Parse(typeof(DriverStatusEnum), status);//Convert.ToInt32(status);

            userBL.UpdateUser(driver);
        }

        protected void ComfirmButton_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus((int) RequestStatusEnum.InProgress, Convert.ToInt32(driversDropDownList.SelectedValue), true);

            UpdateDriver("Busy");
        }

        protected void rejectButton_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus((int) RequestStatusEnum.Rejected);

            UpdateDriver("Free");
        }

        protected void closeButton_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus((int) RequestStatusEnum.Closed, Convert.ToInt32(driversDropDownList.SelectedValue), false);
            UpdateDriver("Free");
        }
    }
}