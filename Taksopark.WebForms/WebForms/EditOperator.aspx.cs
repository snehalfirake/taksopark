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
    public partial class EditOperator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminBl adminBl = new AdminBl();
                var user = adminBl.GetUserById(Convert.ToInt32(Request.QueryString["id"]));
                EditOperators.OperatorIdText = user.Id.ToString();
                EditOperators.OperatorNameText = user.UserName;
                EditOperators.LastNameText = user.LastName;
                EditOperators.LoginText = user.Login;
                EditOperators.PhoneNumberText = user.PhoneNumber;
                EditOperators.EmailText = user.Email;
                EditOperators.PasswordText = user.Password;
                EditOperators.StatusText = user.Status;
            }
        }
    }
}