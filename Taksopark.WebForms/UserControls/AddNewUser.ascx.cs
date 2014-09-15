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
using Taksopark.DAL.Repositories;

namespace Taksopark.WebForms.UserControls
{
    public partial class AddNewUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            adminBl.CreateUser(new User()
                {
                    UserName = tbxUserName.Text,
                    LastName = tbxLastName.Text,
                    Login = tbxLogin.Text,
                    PhoneNumber = tbxPhoneNumber.Text,
                    Email = tbxEmail.Text,
                    Password = tbxPassword.Text,
                    Role = "Client",
                    Status = tbxStatus.Text
                });
            Response.Redirect("~/WebForms/Users.aspx");
        }
    }
}