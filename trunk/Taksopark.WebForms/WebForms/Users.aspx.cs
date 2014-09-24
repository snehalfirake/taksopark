using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
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

        public static IEnumerable<User> GetAllUsersFromRepository(string status)
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
                var AllClients = adminBl.GetUserByRole("Client");
                if (AllClients.Count > 0)
                {
                    return AllClients;
                }
                else
                {
                    return emptyResult;
                }
            }
            else if (status == "Active")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllClientsByStatus = adminBl.GetAllUsersByStatus("Active");
                if (AllClientsByStatus.Count > 0)
                {
                    return AllClientsByStatus;
                }
                else
                {
                    return emptyResult;
                }
            }
            else if (status == "Inactive")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllClientsByStatus = adminBl.GetAllUsersByStatus("Inactive");
                if (AllClientsByStatus.Count > 0)
                {
                    return AllClientsByStatus;
                }
                else
                {
                    return emptyResult;
                }
            }
            return emptyResult;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/AddUser.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/EditUser.aspx");
        }

        protected void UsersTable_GridViewClicked(object sender, GridViewEventArgs e)
        {
            Response.Redirect(String.Format("~/WebForms/EditUser.aspx?id={0}", e.UserId));
        }
    }
}