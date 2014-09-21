using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;

namespace Taksopark.WebForms.WebForms
{
    public partial class EditTaxiDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminBl adminBl = new AdminBl();
                var user = adminBl.GetUserById(Convert.ToInt32(Request.QueryString["id"]));
                EditTaxiDrivers.TaxiDriverIdText = user.Id.ToString();
                EditTaxiDrivers.TaxiDriverNameText = user.UserName;
                EditTaxiDrivers.LastNameText = user.LastName;
                EditTaxiDrivers.LoginText = user.Login;
                EditTaxiDrivers.PhoneNumberText = user.PhoneNumber;
                EditTaxiDrivers.EmailText = user.Email;
                EditTaxiDrivers.PasswordText = user.Password;
                EditTaxiDrivers.StatusText = user.Status;

                var car = adminBl.GetCarById(Convert.ToInt32(Request.QueryString["id"]));
                if (car.CarYear!=car.CarBrand)
                {
                    EditTaxiDrivers.CarBrand = car.CarBrand;
                    EditTaxiDrivers.CarYear = car.CarYear;
                    EditTaxiDrivers.CarStartWorkTime = car.StartWorkTime.ToString();
                    EditTaxiDrivers.CarFinishWorkTime = car.FinishWorkTime.ToString();
                    EditTaxiDrivers.CarLatitude = car.Latitude;
                    EditTaxiDrivers.CarLongitude = car.Longitude;
                }
                else
                {
                    EditTaxiDrivers.CarBrand = "";
                    EditTaxiDrivers.CarYear = "";
                    EditTaxiDrivers.CarStartWorkTime = "";
                    EditTaxiDrivers.CarFinishWorkTime = "";
                    EditTaxiDrivers.CarLatitude = "";
                    EditTaxiDrivers.CarLongitude = "";
                }
            }
        }
    }
}