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
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var user = adminBl.GetUserById(Convert.ToInt32(Request.QueryString["id"]));
                EditUsers.UserIdText = user.Id.ToString();
                EditUsers.UserNameText = user.UserName;
                EditUsers.LastNameText = user.LastName;
                EditUsers.LoginText = user.Login;
                EditUsers.PhoneNumberText = user.PhoneNumber;
                EditUsers.EmailText = user.Email;
                EditUsers.PasswordText = user.Password;
                EditUsers.StatusText = user.Status.ToString();
            }
        }
    }
}