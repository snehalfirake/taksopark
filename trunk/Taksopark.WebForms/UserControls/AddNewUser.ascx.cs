﻿using System;
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

namespace Taksopark.WebForms.UserControls
{
    public partial class AddNewUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            AdminBl adminBl = new AdminBl();
            if (!adminBl.IsLoginBooked(tbxLogin.Text))
            {
                adminBl.CreateUser(new User()
                {
                    UserName = tbxUserName.Text,
                    LastName = tbxLastName.Text,
                    Login = tbxLogin.Text,
                    PhoneNumber = tbxPhoneNumber.Text,
                    Email = tbxEmail.Text,
                    Password = tbxPassword.Text,
                    Role = "Client",
                    Status = ddlStatus.Text
                });
                Response.Redirect("~/WebForms/Users.aspx");
            }
            else
            {
                loginBooked.InnerText = "Login is booked!";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/Users.aspx");
        }
    }
}