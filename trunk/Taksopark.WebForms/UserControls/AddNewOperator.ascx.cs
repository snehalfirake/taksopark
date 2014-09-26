using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Enums;
using Taksopark.DAL.Models;
using Unity.WebForms;
using Microsoft.Practices.Unity;

namespace Taksopark.WebForms.UserControls
{
    public partial class AddNewOperator : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewOperator_Click(object sender, EventArgs e)
        {
            IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
            if (!adminBl.IsLoginBooked(tbxLogin.Text))
            {
                adminBl.CreateUser(new User()
                {
                    UserName = tbxOperatorName.Text,
                    LastName = tbxLastName.Text,
                    Login = tbxLogin.Text,
                    PhoneNumber = tbxPhoneNumber.Text,
                    Email = tbxEmail.Text,
                    Password = tbxPassword.Text,
                    Role = (int) RolesEnum.Operator,
                    Status = Convert.ToInt32(ddlStatus.Text),
                    DriverStatus = null
                });
                Response.Redirect("~/WebForms/Operators.aspx");
            }
            else
            {
                loginBooked.InnerText = "Login is booked!";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/Operators.aspx");
        }
    }
}