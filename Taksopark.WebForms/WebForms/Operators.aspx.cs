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

namespace Taksopark.WebForms.WebForms
{
    public partial class Operators : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static IEnumerable<User> GetAllOperatorsFromRepository()
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var AllOperators = adminBl.GetUserByRole("Operator");
            return AllOperators;
        }

        protected void btnFindOperatorById_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var user = adminBl.GetUserById(Convert.ToInt32(tbxFindOperatorById.Text));
            if (user != null)
            {
                tbxEditOperatorName.ReadOnly = false;
                tbxEditOperatorName.Text = user.UserName;

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
                Id = Convert.ToInt32(tbxFindOperatorById.Text),
                UserName = tbxEditOperatorName.Text,
                LastName = tbxEditLastName.Text,
                Login = tbxEditLogin.Text,
                PhoneNumber = tbxEditPhoneNumber.Text,
                Email = tbxEditEmail.Text,
                Password = tbxEditPassword.Text,
                Role = "Operator",
                Status = tbxEditStatus.Text
            };
            adminBl.UpdateUser(updatedUser);
            Response.Redirect("~/WebForms/Operator.aspx");
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            tbxEditOperatorName.Text = "";
            tbxEditOperatorName.ReadOnly = true;

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