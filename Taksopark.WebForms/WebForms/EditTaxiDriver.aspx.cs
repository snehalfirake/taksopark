using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;

namespace Taksopark.WebForms.WebForms
{
    public partial class EditTaxiDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminBl adminBl = new AdminBl();
                var user = adminBl.GetUserById(Convert.ToInt32(Request.QueryString["id"]));
                EditTaxiDrivers.TaxiDriverIdText = user.Id.ToString();
                EditTaxiDrivers.TaxiDriverNameText = user.UserName;
                EditTaxiDrivers.LastNameText = user.LastName;
                EditTaxiDrivers.LoginText = user.Login;
                EditTaxiDrivers.PhoneNumberText = user.PhoneNumber;
                EditTaxiDrivers.EmailText = user.Email;
                EditTaxiDrivers.PasswordText = user.Password;
                EditTaxiDrivers.StatusText = user.Status;
            }
        }
    }
}