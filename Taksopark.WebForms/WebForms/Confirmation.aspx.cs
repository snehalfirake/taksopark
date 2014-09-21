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
        private IOperatorBl _operatorBl;

        protected void Page_Init(object sender, EventArgs e)
        {
            this._operatorBl = Application.GetContainer().Resolve<IOperatorBl>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDrivers();
            }
        }

        private void GetDrivers()
        {
            //var operatorBI = Application.GetContainer().Resolve<IOperatorBl>();
            drivers = _operatorBl.GetAllDrivers();
            
            dropDownList.DataSource = drivers;
            dropDownList.DataValueField = "Id";
            dropDownList.DataTextField = "LastName";
            dropDownList.DataBind();
        }

        public Request GetRequest(object id)
        {
            //var orders = this._operatorBl.GetAllRequests();
            var operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            var orders = operatorBl.GetAllRequests();
            request = orders.Where(e => e.Id == Convert.ToInt32(id)).FirstOrDefault();
            
            return request;
        }

        private static Request request;
        private static List<User> drivers;

        protected void dropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //UserBl userBI = new UserBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //userBI.CreateRequest
            //userBI.UpdateUser();
        }

        protected void ComfirmButton_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus("InProgress");
        }

        private void UpdateRequestStatus(string status)
        {
            request.Status = status;            
            this._operatorBl.UpdateRequest(request);
        }

        protected void statusDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRequestStatus(statusDropdownList.SelectedValue);
        }
    }
}