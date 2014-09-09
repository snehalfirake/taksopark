using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.DAL;
using Taksopark.DAL.Models;
using Taksopark.DAL.Repositories;

namespace Taksopark.WebForms.UserControls
{
    public partial class AddNewUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            //UserRepository repository = new UserRepository
            //    (new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["TaksoparkDB"].ConnectionString));
            //repository.Create(new User()
            //{
            //    UserName = tbxUserName.Text,
            //    LastName = tbxLastName.Text,
            //    Login = tbxLogin.Text,
            //    Password = tbxPassword.Text,
            //    Role = "Client",
            //    Status = tbxStatus.Text
            //});
            UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["TaksoparkDB"].ConnectionString);
            uow.UserRepository.Create(new User()
            {
                UserName = tbxUserName.Text,
                LastName = tbxLastName.Text,
                Login = tbxLogin.Text,
                Password = tbxPassword.Text,
                Role = "Client",
                Status = tbxStatus.Text
            });
            Response.Redirect("Users.aspx");
        }
    }
}