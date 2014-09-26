using System;
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
        public IEnumerable<User> GetAllOperatorsFromRepository(int status)
        {
            if (status == (int) RolesEnum.Operator)
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllOperators = adminBl.GetUserByRole((int) RolesEnum.Operator);
                return AllOperators;
            }
            else
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllOperatorsByStatus = adminBl.GetAllOperatorsByStatus(status);
                return AllOperatorsByStatus;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/AddOperator.aspx");
        }
    }
}