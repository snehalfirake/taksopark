using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.DAL.Models;

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
            OperatorBl operatorBI = new OperatorBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            drivers = operatorBI.GetAllDrivers();
            
            dropDownList.DataSource = drivers;
            dropDownList.DataValueField = "Id";
            dropDownList.DataTextField = "LastName";
            dropDownList.DataBind();
        }

        public Request GetRequest(object id)
        {
            OperatorBl operatorBI = new OperatorBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var orders = operatorBI.GetAllRequests();
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
            OperatorBl operatorBI = new OperatorBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            request.Status = status;            
            operatorBI.UpdateRequest(request);
        }

        protected void statusDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRequestStatus(statusDropdownList.SelectedValue);
        }
    }
}