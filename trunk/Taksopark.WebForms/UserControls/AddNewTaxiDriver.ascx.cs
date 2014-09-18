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

namespace Taksopark.WebForms.UserControls
{
    public partial class AddNewTaxiDriver : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewTaxiDriver_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            adminBl.CreateUser(new User()
            {
                UserName = tbxTaxiDriverName.Text,
                LastName = tbxLastName.Text,
                Login = tbxLogin.Text,
                PhoneNumber = tbxPhoneNumber.Text,
                Email = tbxEmail.Text,
                Password = tbxPassword.Text,
                Role = "Driver",
                Status = tbxStatus.Text
            });
            Response.Redirect("~/WebForms/TaxiDrivers.aspx");
        }

        protected void btnAddNewTaxiDriver_Click1(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            adminBl.CreateUser(new User()
            {
                UserName = tbxTaxiDriverName.Text,
                LastName = tbxLastName.Text,
                Login = tbxLogin.Text,
                PhoneNumber = tbxPhoneNumber.Text,
                Email = tbxEmail.Text,
                Password = tbxPassword.Text,
                Role = "Driver",
                Status = tbxStatus.Text
            });
            Response.Redirect("~/WebForms/TaxiDrivers.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/TaxiDrivers.aspx");
        }
    }
}