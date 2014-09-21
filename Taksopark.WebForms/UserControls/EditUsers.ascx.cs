using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.DAL.Models;

namespace Taksopark.WebForms.UserControls
{
    public partial class EditUsers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string UserIdText
        {
            get
            {
                return tbxFindUserByCategory.Text;
            }
            set
            {
                tbxFindUserByCategory.Text = value;
            }
        }
        public string UserNameText
        {
            get
            {
                return tbxEditUserName.Text;
            }
            set
            {
                tbxEditUserName.Text = value;
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

        protected void btnFindUserByCategory_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl();
            User user;
            if (ddlFindingCategory.SelectedValue == "Id")
            {
                user = adminBl.GetUserById(Convert.ToInt32(tbxFindUserByCategory.Text));
            }
            else
            {
                user = adminBl.GetUserByLogin(tbxFindUserByCategory.Text);
                hiddenId.Value = user.Id.ToString();
            }
            if ((user != null) && (user.Role == "Client"))
            {
                tbxEditUserName.Text = user.UserName;
                tbxEditLastName.Text = user.LastName;
                tbxEditLogin.Text = user.Login;
                tbxEditPhoneNumber.Text = user.PhoneNumber;
                tbxEditEmail.Text = user.Email;
                tbxEditPassword.Text = user.Password;
                ddlEditStatus.Text = user.Status;
            }
            else
            {
                tbxEditUserName.Text = "";
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
            AdminBl adminBl = new AdminBl();

            string UserId;
            if (hiddenId.Value != "")
            {
                UserId = hiddenId.Value;
                hiddenId.Value = "";
            }
            else
            {
                UserId = tbxFindUserByCategory.Text;
            }

            var updatedUser = new User()
            {
                Id = Convert.ToInt32(UserId),
                UserName = tbxEditUserName.Text,
                LastName = tbxEditLastName.Text,
                Login = tbxEditLogin.Text,
                PhoneNumber = tbxEditPhoneNumber.Text,
                Email = tbxEditEmail.Text,
                Password = tbxEditPassword.Text,
                Role = "Client",
                Status = ddlEditStatus.Text
            };
            adminBl.UpdateUser(updatedUser);
            Response.Redirect("~/WebForms/Users.aspx");
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/Users.aspx");
        }
    }
}