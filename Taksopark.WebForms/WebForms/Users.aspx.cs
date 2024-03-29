﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Enums;
using Taksopark.DAL.Models;
using Taksopark.DAL.Repositories;
using Taksopark.MVC;
using Taksopark.WebForms.Classes;
using Taksopark.WebForms.UserControls;
using Unity.WebForms;
using Microsoft.Practices.Unity;

namespace Taksopark.WebForms.WebForms
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<User> GetAllUsersFromRepository(string status)
        {
            if (status == "All")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllClients = adminBl.GetUserByRole((int) RolesEnum.Client);
                return AllClients;
            }
            else if (status == UserStatusEnum.Active.ToString())
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllClientsByStatus = adminBl.GetAllUsersByStatus((int)UserStatusEnum.Active);
                return AllClientsByStatus;
            }
            else if (status == UserStatusEnum.Inactive.ToString())
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllClientsByStatus = adminBl.GetAllUsersByStatus((int)UserStatusEnum.Inactive);
                return AllClientsByStatus;
            }
            return new List<User>();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/AddUser.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/EditUser.aspx");
        }
    }
}