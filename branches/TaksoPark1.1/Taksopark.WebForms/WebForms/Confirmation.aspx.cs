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
        private Request request;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetRequest(!IsPostBack);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            bool driversAvaliable = GetDrivers();

            UpdateOrderButtons(driversAvaliable);
            SetRequest(true);

            rptMarkers.DataSource = GetAllFreeDrivers();
            rptMarkers.DataBind();
        }

        private void UpdateOrderButtons(bool driversAvaliable)
        {
            if (!driversAvaliable)
            {
                if (request.Status == (int)RequestStatusEnum.Active)
                {
                    confirmButton.Enabled = false;
                    rejectButton.Enabled = true;
                    closeButton.Enabled = false;

                    confirmButton.CssClass = "btn btn-s-md btn-disabled";
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
                    confirmButton.Enabled = false;
                    rejectButton.Enabled = false;
                    closeButton.Enabled = false;

                    confirmButton.CssClass = "btn btn-s-md btn-white disabled";
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
                //confirmButton.Enabled = false;
                //rejectButton.Enabled = true;//false
                //closeButton.Enabled = true;//false

                //confirmButton.CssClass = "btn btn-s-md btn-disabled"; //btn-disabled
                //rejectButton.CssClass = "btn btn-s-md btn-dange";//rbtn-disabled
                //closeButton.CssClass = "btn btn-s-md btn-success";//btn-white disabled
            }
            else
            {
                if (request.Status == (int)RequestStatusEnum.Active)
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
                    confirmButton.Enabled = false;
                    rejectButton.Enabled = false;
                    closeButton.Enabled = false;

                    confirmButton.CssClass = "btn btn-s-md btn-white disabled";
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
        }

        private bool GetDrivers()
        {
            IOperatorBl operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();

            var drivers = operatorBl.GetAllDriversByDriverStatus((int)Enum.Parse(typeof(DriverStatusEnum), "Free"));
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

        

        private void SetRequest(bool bindRequest)
        {
            var operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            request = operatorBl.GetRequestById(Convert.ToInt32(Request.QueryString["id"]));
            if (bindRequest)
            {
                var s = request;
                var info = new RequestModel(request);

                formView.DataSource = new List<Request>() { info };
                formView.DataBind();
            }
        }

        private void UpdateRequestStatus(RequestStatusEnum status)
        {
            request.Status = (int)status;
            request.DriverId = null;
            var operatorBL = HttpContext.Current.Application.GetContainer().Resolve<OperatorBl>();
            operatorBL.UpdateRequest(request);
        }

        private void SubmitRequest(int driverid)
        {
            request.Status = (int)RequestStatusEnum.InProgress;
            request.DriverId = driverid;

            var operatorBL = HttpContext.Current.Application.GetContainer().Resolve<OperatorBl>();
            operatorBL.UpdateRequest(request);
        }

        private void UpdateDriver(int driverId, DriverStatusEnum status)
        {
            //if (request.DriverId == null)
            //    return;

            var operatorBL = HttpContext.Current.Application.GetContainer().Resolve<OperatorBl>();
            var driver = operatorBL.GetUserById(driverId);
            UserBl userBL = HttpContext.Current.Application.GetContainer().Resolve<UserBl>();

            driver.DriverStatus = (int)status;

            userBL.UpdateUser(driver);
            driversDropDownList.DataBind();
        }

        protected void ComfirmButton_Click(object sender, EventArgs e)
        {
            int driverId = Convert.ToInt32(driversDropDownList.SelectedValue);
            SubmitRequest(driverId);
            UpdateDriver(driverId, DriverStatusEnum.Busy);
        }

        protected void rejectButton_Click(object sender, EventArgs e)
        {
            int? driverId = this.request.DriverId;
            UpdateRequestStatus(RequestStatusEnum.Rejected);
            if(driverId.HasValue)
            {
                UpdateDriver(driverId.Value, DriverStatusEnum.Free);
            }
            
        }

        protected void closeButton_Click(object sender, EventArgs e)
        {
            int? driverId = this.request.DriverId;
            UpdateRequestStatus(RequestStatusEnum.Closed);
            if (driverId.HasValue)
            {
                UpdateDriver(driverId.Value, DriverStatusEnum.Free);
            }
        }

        protected void driversDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowDriversOnMap", "alert('qqq');", true);
        }

        private List<Driver> GetAllFreeDrivers()
        {
            IOperatorBl operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            var AllFreeOperators = operatorBl.GetAllDriversByDriverStatus((int)DriverStatusEnum.Free);
            return AllFreeOperators;
        }
    }
}