﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Enums;
using Taksopark.DAL.Models;
using Taksopark.WebForms.Classes;
using Unity.WebForms;

namespace Taksopark.WebForms.WebForms
{
    public partial class Operators : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public IEnumerable<User> GetAllOperatorsFromRepository(string status)
        {
            if (status == "All")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllOperators = adminBl.GetUserByRole((int) RolesEnum.Operator);
                return AllOperators;
            }
            else if (status == UserStatusEnum.Active.ToString())
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllOperatorsByStatus = adminBl.GetAllOperatorsByStatus((int)UserStatusEnum.Active);
                return AllOperatorsByStatus;
            }
            else if (status == UserStatusEnum.Inactive.ToString())
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllOperatorsByStatus = adminBl.GetAllOperatorsByStatus((int)UserStatusEnum.Inactive);
                return AllOperatorsByStatus;
            }
            return new List<User>();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/AddOperator.aspx");
        }
    }
}