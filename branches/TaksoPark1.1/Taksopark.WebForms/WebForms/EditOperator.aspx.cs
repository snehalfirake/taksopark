using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Unity.WebForms;
using Microsoft.Practices.Unity;

namespace Taksopark.WebForms.WebForms
{
    public partial class EditOperator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var user = adminBl.GetUserById(Convert.ToInt32(Request.QueryString["id"]));
                EditOperators.OperatorIdText = user.Id.ToString();
                EditOperators.OperatorNameText = user.UserName;
                EditOperators.LastNameText = user.LastName;
                EditOperators.LoginText = user.Login;
                EditOperators.PhoneNumberText = user.PhoneNumber;
                EditOperators.EmailText = user.Email;
                EditOperators.PasswordText = user.Password;
                EditOperators.StatusText = ((Taksopark.DAL.Enums.UserStatusEnum)(user.Status)).ToString();
            }
        }
    }
}