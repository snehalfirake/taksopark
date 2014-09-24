using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Models;
using Unity.WebForms;
using Microsoft.Practices.Unity;

namespace Taksopark.WebForms.UserControls
{
    public partial class EditOperators : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string OperatorIdText
        {
            get
            {
                return tbxFindOperatorByCategory.Text;
            }
            set
            {
                tbxFindOperatorByCategory.Text = value;
            }
        }
        public string OperatorNameText
        {
            get
            {
                return tbxEditOperatorName.Text;
            }
            set
            {
                tbxEditOperatorName.Text = value;
            }
        }

        public string LastNameText
        {
            get
            {
                return tbxEditLastName.Text;
            }
            set
            {
                tbxEditLastName.Text = value;
            }
        }

        public string LoginText
        {
            get
            {
                return tbxEditLogin.Text;
            }
            set
            {
                tbxEditLogin.Text = value;
            }
        }

        public string PhoneNumberText
        {
            get
            {
                return tbxEditPhoneNumber.Text;
            }
            set
            {
                tbxEditPhoneNumber.Text = value;
            }
        }

        public string EmailText
        {
            get
            {
                return tbxEditEmail.Text;
            }
            set
            {
                tbxEditEmail.Text = value;
            }
        }

        public string PasswordText
        {
            get
            {
                return tbxEditPassword.Text;
            }
            set
            {
                tbxEditPassword.Text = value;
            }
        }

        public string StatusText
        {
            get
            {
                return ddlEditStatus.Text;
            }
            set
            {
                ddlEditStatus.Text = value;
            }
        }

        protected void btnFindOperatorById_Click(object sender, EventArgs e)
        {
            IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();            
            User user;
            if (ddlFindingCategory.SelectedValue == "Id")
            {
                user = adminBl.GetUserById(Convert.ToInt32(tbxFindOperatorByCategory.Text));
            }
            else
            {
                user = adminBl.GetUserByLogin(tbxFindOperatorByCategory.Text);
                hiddenId.Value = user.Id.ToString();
            }
            if ((user != null) && (user.Role == "Operator"))
            {
                tbxEditOperatorName.Text = user.UserName;
                tbxEditLastName.Text = user.LastName;
                tbxEditLogin.Text = user.Login;
                tbxEditPhoneNumber.Text = user.PhoneNumber;
                tbxEditEmail.Text = user.Email;
                tbxEditPassword.Text = user.Password;
                ddlEditStatus.Text = user.Status;
            }
            else
            {
                tbxEditOperatorName.Text = "";
                tbxEditLastName.Text = "";
                tbxEditLogin.Text = "";
                tbxEditPhoneNumber.Text = "";
                tbxEditEmail.Text = "";
                tbxEditPassword.Text = "";
                ddlEditStatus.Text = "";
            }
        }

        protected void btnSaveEdit_Click(object sender, EventArgs e)
        {
            IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
            
            string UserId;
            if (hiddenId.Value != "")
            {
                UserId = hiddenId.Value;
                hiddenId.Value = "";
            }
            else
            {
                UserId = tbxFindOperatorByCategory.Text;
            }

            var updatedUser = new User()
            {
                Id = Convert.ToInt32(UserId),
                UserName = tbxEditOperatorName.Text,
                LastName = tbxEditLastName.Text,
                Login = tbxEditLogin.Text,
                PhoneNumber = tbxEditPhoneNumber.Text,
                Email = tbxEditEmail.Text,
                Password = tbxEditPassword.Text,
                Role = "Operator",
                Status = ddlEditStatus.Text
            };
            if (!adminBl.IsLoginBookedByOtherId(updatedUser.Login, updatedUser.Id))
            {
                adminBl.UpdateUser(updatedUser);
                Response.Redirect("~/WebForms/Operators.aspx");
            }
            else
            {
                loginBooked.InnerText = "Login is booked!";
            }
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/Operators.aspx");
        }
    }
}