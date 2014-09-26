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
using Taksopark.DAL.Enums;
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
        public IEnumerable<Driver> GetAllTaxiDriversFromRepository (int status)
        {
            if (status == (int) RolesEnum.Driver)
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllDrivers = adminBl.GetAllDrivers();
                return AllDrivers;
            }
            else
            {
                IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var AllDriversByStatus = adminBl.GetAllDriversByStatus(status);
                return AllDriversByStatus;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/AddTaxiDriver.aspx");
        }
    }
}