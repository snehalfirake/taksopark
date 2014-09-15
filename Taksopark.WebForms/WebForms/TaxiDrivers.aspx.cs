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
    public partial class TaxiDrivers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static IEnumerable<User> GetAllTaxiDriversFromRepository()
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var AllDrivers = adminBl.GetUserByRole("Driver");
            return AllDrivers;
        }

        protected void btnFindTaxiDriverById_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var user = adminBl.GetUserById(Convert.ToInt32(tbxFindTaxiDriverById.Text));
            if (user != null)
            {
                tbxEditTaxiDriverName.ReadOnly = false;
                tbxEditTaxiDriverName.Text = user.UserName;

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
                Id = Convert.ToInt32(tbxFindTaxiDriverById.Text),
                UserName = tbxEditTaxiDriverName.Text,
                LastName = tbxEditLastName.Text,
                Login = tbxEditLogin.Text,
                PhoneNumber = tbxEditPhoneNumber.Text,
                Email = tbxEditEmail.Text,
                Password = tbxEditPassword.Text,
                Role = "Driver",
                Status = tbxEditStatus.Text
            };
            adminBl.UpdateUser(updatedUser);
            Response.Redirect("~/WebForms/TaxiDrivers.aspx");
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            tbxEditTaxiDriverName.Text = "";
            tbxEditTaxiDriverName.ReadOnly = true;

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