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
    public partial class EditTaxiDrivers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string TaxiDriverIdText
        {
            get
            {
                return tbxFindTaxiDriverById.Text;
            }
            set
            {
                tbxFindTaxiDriverById.Text = value;
            }
        }
        public string TaxiDriverNameText
        {
            get
            {
                return tbxEditTaxiDriverName.Text;
            }
            set
            {
                tbxEditTaxiDriverName.Text = value;
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
                return tbxEditStatus.Text;
            }
            set
            {
                tbxEditStatus.Text = value;
            }
        }

        protected void btnFindTaxiDriverById_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var user = adminBl.GetUserById(Convert.ToInt32(tbxFindTaxiDriverById.Text));
            if (user != null)
            {
                tbxEditTaxiDriverName.Text = user.UserName;
                tbxEditLastName.Text = user.LastName;
                tbxEditLogin.Text = user.Login;
                tbxEditPhoneNumber.Text = user.PhoneNumber;
                tbxEditEmail.Text = user.Email;
                tbxEditPassword.Text = user.Password;
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
            Response.Redirect("~/WebForms/TaxiDrivers.aspx");
        }
    }
}