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

            detailsView1.DataSource = new List<Request>() { request };
            detailsView1.DataBind();

            //orderInfo.DataSource = new List<Request>() { request };
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
}