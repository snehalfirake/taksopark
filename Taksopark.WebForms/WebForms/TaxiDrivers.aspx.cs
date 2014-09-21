using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.DAL;
using Taksopark.DAL.Models;
using Taksopark.WebForms.Classes;

namespace Taksopark.WebForms.WebForms
{
    public partial class TaxiDrivers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static IEnumerable<User> GetAllTaxiDriversFromRepository()
        {
            AdminBl adminBl = new AdminBl();
            var AllDrivers = adminBl.GetUserByRole("Driver");
            return AllDrivers;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/AddTaxiDriver.aspx");
        }

        protected void TaxiDriversTable1_GridViewClicked(object sender, GridViewEventArgs e)
        {
            //EditUsers.UserIdText = e.UserId;
            //EditUsers.UserNameText = e.UserName;
            //EditUsers.LastNameText = e.LastName;
            //EditUsers.LoginText = e.Login;
            //EditUsers.PhoneNumberText = e.PhoneNumber;
            //EditUsers.EmailText = e.Email;
            //EditUsers.PasswordText = e.Password;
            //EditUsers.StatusText = e.Status;
            //Response.Redirect("~/WebForms/Users.aspx#editing");
            Response.Redirect(String.Format("~/WebForms/EditTaxiDriver.aspx?id={0}", e.UserId));
        }
    }
}