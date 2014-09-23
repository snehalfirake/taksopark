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

namespace Taksopark.WebForms.Dispatcher
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDrivers();
            }
        }

        private void GetDrivers()
        {
            var operatorBL = HttpContext.Current.Application.GetContainer().Resolve<OperatorBl>();
            driversDropDownList.DataSource = operatorBL.GetAllDrivers();
            driversDropDownList.DataValueField = "Id";
            driversDropDownList.DataTextField = "LastName";
            driversDropDownList.DataTextField = "Id";
            driversDropDownList.DataBind();
        }

        private static Request request;

        public Request GetRequest(object id)
        {
            var operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            request = operatorBl.GetRequestById(Convert.ToInt32(id));

            return request;
        }

        private void UpdateRequestStatus(string status)
        {
            request.Status = status;
            
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