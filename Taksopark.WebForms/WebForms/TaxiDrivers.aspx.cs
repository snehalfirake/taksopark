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
using Taksopark.WebForms.Classes;
using Unity.WebForms;
using Microsoft.Practices.Unity;

namespace Taksopark.WebForms.WebForms
{
    public partial class TaxiDrivers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public static IEnumerable<Driver> GetAllTaxiDriversFromRepository (string status)
        {
            var emptyResult = new List<Driver>();
            emptyResult.Add(new Driver()
            {
                Id = -1,
                Car = new Car()
                {
                    Id = -1
                }
            });
            if (status == "All")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                //var AllDrivers = adminBl.GetUserByRole("Driver");
                var AllDrivers = adminBl.GetAllDrivers();
                if (AllDrivers.Count > 0)
                {
                    return AllDrivers;
                }
                else
                {
                    return emptyResult;
                }
            }
            else if(status=="Active")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllDriversByStatus = adminBl.GetAllDriversByStatus("Active");
                if (AllDriversByStatus.Count > 0)
                {
                    return AllDriversByStatus;
                }
                else
                {
                    return emptyResult;
                }
            }
            else if(status=="Inactive")
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllDriversByStatus = adminBl.GetAllDriversByStatus("Inactive");
                if (AllDriversByStatus.Count > 0)
                {
                    return AllDriversByStatus;
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
            Response.Redirect("~/WebForms/AddTaxiDriver.aspx");
        }

        protected void TaxiDriversTable1_GridViewClicked(object sender, GridViewEventArgs e)
        {
            Response.Redirect(String.Format("~/WebForms/EditTaxiDriver.aspx?id={0}", e.UserId));
        }
    }
}