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
        public static IEnumerable<User> GetAllOperatorsFromRepository(string status)
        {
            var emptyResult = new List<User>();
            emptyResult.Add(new User()
            {
                Id = -1
            });
            if (status == "All")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                //var AllDrivers = adminBl.GetUserByRole("Driver");
                var AllOperators = adminBl.GetUserByRole("Operator");
                if (AllOperators.Count > 0)
                {
                    return AllOperators;
                }
                else
                {
                    return emptyResult;
                }
            }
            else if (status == "Active")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllOperatorsByStatus = adminBl.GetAllOperatorsByStatus("Active");
                if (AllOperatorsByStatus.Count > 0)
                {
                    return AllOperatorsByStatus;
                }
                else
                {
                    return emptyResult;
                }
            }
            else if (status == "Inactive")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllOperatorsByStatus = adminBl.GetAllOperatorsByStatus("Inactive");
                if (AllOperatorsByStatus.Count > 0)
                {
                    return AllOperatorsByStatus;
                }
                else
                {
                    return emptyResult;
                }
            }
            return emptyResult;
        }

        protected void OperatorsTable_GridViewClicked(object sender, GridViewEventArgs e)
        {
            Response.Redirect(String.Format("~/WebForms/EditOperator.aspx?id={0}", e.UserId));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/AddOperator.aspx");
        }
    }
}