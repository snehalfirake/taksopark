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
using Unity.WebForms;
using Microsoft.Practices.Unity;

namespace Taksopark.WebForms.UserControls
{
    public partial class AddNewTaxiDriver : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewTaxiDriver_Click(object sender, EventArgs e)
        {
            IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
            if (!adminBl.IsLoginBooked(tbxLogin.Text))
            {
                adminBl.CreateUser(new User()
                {
                    UserName = tbxTaxiDriverName.Text,
                    LastName = tbxLastName.Text,
                    Login = tbxLogin.Text,
                    PhoneNumber = tbxPhoneNumber.Text,
                    Email = tbxEmail.Text,
                    Password = tbxPassword.Text,
                    Role = (int) RolesEnum.Driver,
                    Status = Convert.ToInt32(ddlStatus.Text),
                    DriverStatus = (int?) DriverStatusEnum.Free
                });

                int CarId = adminBl.GetUserByLogin(tbxLogin.Text).Id;
                adminBl.CreateCar(new Car()
                {
                    Id = CarId,
                    CarBrand = tbxCarBrand.Text,
                    CarYear = tbxCarYear.Text,
                    StartWorkTime = DateTime.Parse(tbxCarStartWorkTime.Text),
                    FinishWorkTime = DateTime.Parse(tbxCarFinishWorkTime.Text),
                    Latitude = tbxCarLatitude.Text,
                    Longitude = tbxCarLongitude.Text
                });

                Response.Redirect("~/WebForms/TaxiDrivers.aspx");
            }
            else
            {
                loginBooked.InnerText = "Login is booked!";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/TaxiDrivers.aspx");
        }
    }
}