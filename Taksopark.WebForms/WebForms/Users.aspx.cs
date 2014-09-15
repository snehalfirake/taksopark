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
using Taksopark.MVC;

namespace Taksopark.WebForms.WebForms
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static IEnumerable<User> GetAllUsersFromRepository()
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var AllClients = adminBl.GetUserByRole("Client");
            return AllClients;
        }

        protected void btnFindUserById_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var user = adminBl.GetUserById(Convert.ToInt32(tbxFindUserById.Text));
            if (user != null)
            {
                tbxEditUserName.ReadOnly = false;
                tbxEditUserName.Text = user.UserName;

                tbxEditLastName.ReadOnly = false;
                tbxEditLastName.Text = user.LastName;

                tbxEditLogin.ReadOnly = false;
                tbxEditLogin.Text = user.Login;

                tbxEditPhoneNumber.ReadOnly = false;
                tbxEditPhoneNumber.Text = user.PhoneNumber;

                tbxEditEmail.ReadOnly = false;
                tbxEditEmail.Text = user.Email;

                tbxEditPassword.ReadOnly = false;
                tbxEditPassword.Text = user.Password;

                tbxEditStatus.ReadOnly = false;
                tbxEditStatus.Text = user.Status;
            }
        }

        protected void btnSaveEdit_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var updatedUser = new User()
            {
                Id = Convert.ToInt32(tbxFindUserById.Text),
                UserName = tbxEditUserName.Text,
                LastName = tbxEditLastName.Text,
                Login = tbxEditLogin.Text,
                PhoneNumber = tbxEditPhoneNumber.Text,
                Email = tbxEditEmail.Text,
                Password = tbxEditPassword.Text,
                Role = "Client",
                Status = tbxEditStatus.Text
            };
            adminBl.UpdateUser(updatedUser);
            Response.Redirect("~/WebForms/Users.aspx");
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            tbxEditUserName.Text = "";
            tbxEditUserName.ReadOnly = true;

            tbxEditLastName.Text = "";
            tbxEditLastName.ReadOnly = true;

            tbxEditLogin.Text = "";
            tbxEditLogin.ReadOnly = true;

            tbxEditPhoneNumber.Text = "";
            tbxEditPhoneNumber.ReadOnly = true;

            tbxEditEmail.Text = "";
            tbxEditEmail.ReadOnly = true;

            tbxEditPassword.Text = "";
            tbxEditPassword.ReadOnly = true;

            tbxEditStatus.Text = "";
            tbxEditStatus.ReadOnly = true;
        }
    }
}