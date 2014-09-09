using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            //UserRepository repo = new UserRepository(new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["TaksoparkDB"].ConnectionString));
            //return repo.GetUsersByRole("Client");
            UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["TaksoparkDB"].ConnectionString);
            return uow.UserRepository.GetUsersByRole("Operator");
        }

        protected void btnFindOperatorById_Click(object sender, EventArgs e)
        {
            UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["TaksoparkDB"].ConnectionString);
            var user = uow.UserRepository.GetUserById(Convert.ToInt32(tbxFindOperatorById.Text));
            if (user != null)
            {
                tbxEditOperatorName.ReadOnly = false;
                tbxEditOperatorName.Text = user.UserName;

                tbxEditLastName.ReadOnly = false;
                tbxEditLastName.Text = user.LastName;

                tbxEditLogin.ReadOnly = false;
                tbxEditLogin.Text = user.Login;

                tbxEditPassword.ReadOnly = false;
                tbxEditPassword.Text = user.Password;

                tbxEditStatus.ReadOnly = false;
                tbxEditStatus.Text = user.Status;
            }
        }

        protected void btnSaveEdit_Click(object sender, EventArgs e)
        {
            UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["TaksoparkDB"].ConnectionString);
            var updatedUser = new User()
            {
                Id = Convert.ToInt32(tbxFindOperatorById.Text),
                UserName = tbxEditOperatorName.Text,
                LastName = tbxEditLastName.Text,
                Login = tbxEditLogin.Text,
                Password = tbxEditPassword.Text,
                Role = "Operator",
                Status = tbxEditStatus.Text
            };
            uow.UserRepository.Update(updatedUser);
            Response.Redirect("Operator.aspx");
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            tbxEditOperatorName.Text = "";
            tbxEditOperatorName.ReadOnly = true;

            tbxEditLastName.Text = "";
            tbxEditLastName.ReadOnly = true;

            tbxEditLogin.Text = "";
            tbxEditLogin.ReadOnly = true;

            tbxEditPassword.Text = "";
            tbxEditPassword.ReadOnly = true;

            tbxEditStatus.Text = "";
            tbxEditStatus.ReadOnly = true;
        }
    }
}