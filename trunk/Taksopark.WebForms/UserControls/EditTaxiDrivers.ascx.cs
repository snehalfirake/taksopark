using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Models;
using Unity.WebForms;
using Microsoft.Practices.Unity;

namespace Taksopark.WebForms.UserControls
{
    public partial class EditTaxiDrivers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string TaxiDriverIdText
        {
            get
            {
                return tbxFindTaxiDriverByCategory.Text;
            }
            set
            {
                tbxFindTaxiDriverByCategory.Text = value;
            }
        }
        public string TaxiDriverNameText
        {
            get
            {
                return tbxEditTaxiDriverName.Text;
            }
            set
            {
                tbxEditTaxiDriverName.Text = value;
            }
        }

        public string LastNameText
        {
            get
            {
                return tbxEditLastName.Text;
            }
            set
            {
                tbxEditLastName.Text = value;
            }
        }

        public string LoginText
        {
            get
            {
                return tbxEditLogin.Text;
            }
            set
            {
                tbxEditLogin.Text = value;
            }
        }

        public string PhoneNumberText
        {
            get
            {
                return tbxEditPhoneNumber.Text;
            }
            set
            {
                tbxEditPhoneNumber.Text = value;
            }
        }

        public string EmailText
        {
            get
            {
                return tbxEditEmail.Text;
            }
            set
            {
                tbxEditEmail.Text = value;
            }
        }

        public string PasswordText
        {
            get
            {
                return tbxEditPassword.Text;
            }
            set
            {
                tbxEditPassword.Text = value;
            }
        }

        public string StatusText
        {
            get
            {
                return ddlEditStatus.Text;
            }
            set
            {
                ddlEditStatus.Text = value;
            }
        }
        public string CarBrand
        {
            get
            {
                return tbxCarBrand.Text;
            }
            set
            {
                tbxCarBrand.Text = value;
            }
        }
        public string CarYear
        {
            get
            {
                return tbxCarYear.Text;
            }
            set
            {
                tbxCarYear.Text = value;
            }
        }
        public string CarStartWorkTime
        {
            get
            {
                return tbxCarStartWorkTime.Text;
            }
            set
            {
                tbxCarStartWorkTime.Text = value;
            }
        }
        public string CarFinishWorkTime
        {
            get
            {
                return tbxCarFinishWorkTime.Text;
            }
            set
            {
                tbxCarFinishWorkTime.Text = value;
            }
        }
        public string CarLatitude
        {
            get
            {
                return tbxCarLatitude.Text;
            }
            set
            {
                tbxCarLatitude.Text = value;
            }
        }
        public string CarLongitude
        {
            get
            {
                return tbxCarLongitude.Text;
            }
            set
            {
                tbxCarLongitude.Text = value;
            }
        }

        protected void btnFindTaxiDriverById_Click(object sender, EventArgs e)
        {
            IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
            User user;
            if (ddlFindingCategory.SelectedValue == "Id")
            {
                user = adminBl.GetUserById(Convert.ToInt32(tbxFindTaxiDriverByCategory.Text));
            }
            else
            {
                user = adminBl.GetUserByLogin(tbxFindTaxiDriverByCategory.Text);
                hiddenId.Value = user.Id.ToString();
            }
            if ((user != null) && (user.Role == "Driver"))
            {
                tbxEditTaxiDriverName.Text = user.UserName;
                tbxEditLastName.Text = user.LastName;
                tbxEditLogin.Text = user.Login;
                tbxEditPhoneNumber.Text = user.PhoneNumber;
                tbxEditEmail.Text = user.Email;
                tbxEditPassword.Text = user.Password;
                ddlEditStatus.Text = user.Status;

                var car = adminBl.GetCarById(user.Id);
                if (car.CarYear != car.CarBrand)
                {
                    tbxCarBrand.Text = car.CarBrand;
                    tbxCarYear.Text = car.CarYear;
                    tbxCarStartWorkTime.Text = car.StartWorkTime.ToString();
                    tbxCarFinishWorkTime.Text = car.FinishWorkTime.ToString();
                    tbxCarLatitude.Text = car.Latitude;
                    tbxCarLongitude.Text = car.Longitude;
                }
                else
                {
                    tbxCarBrand.Text = "";
                    tbxCarYear.Text = "";
                    tbxCarStartWorkTime.Text = "";
                    tbxCarFinishWorkTime.Text = "";
                    tbxCarLatitude.Text = "";
                    tbxCarLongitude.Text = "";
                }
            }
            else
            {
                tbxEditTaxiDriverName.Text = "";
                tbxEditLastName.Text = "";
                tbxEditLogin.Text = "";
                tbxEditPhoneNumber.Text = "";
                tbxEditEmail.Text = "";
                tbxEditPassword.Text = "";
                ddlEditStatus.Text = "";

                tbxCarBrand.Text = "";
                tbxCarYear.Text = "";
                tbxCarStartWorkTime.Text = "";
                tbxCarFinishWorkTime.Text = "";
                tbxCarLatitude.Text = "";
                tbxCarLongitude.Text = "";
            }
        }

        protected void btnSaveEdit_Click(object sender, EventArgs e)
        {
            IAdminBl adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
            
            string UserId;
            if (hiddenId.Value != "")
            {
                UserId = hiddenId.Value;
                hiddenId.Value = "";
            }
            else
            {
                UserId = tbxFindTaxiDriverByCategory.Text;
            }

            var updatedUser = new User()
            {
                Id = Convert.ToInt32(UserId),
                UserName = tbxEditTaxiDriverName.Text,
                LastName = tbxEditLastName.Text,
                Login = tbxEditLogin.Text,
                PhoneNumber = tbxEditPhoneNumber.Text,
                Email = tbxEditEmail.Text,
                Password = tbxEditPassword.Text,
                Role = "Driver",
                Status = ddlEditStatus.Text
            };

            if (!adminBl.IsLoginBookedByOtherId(updatedUser.Login, updatedUser.Id))
            {
                adminBl.UpdateUser(updatedUser);

                var updatedCar = new Car()
                {
                    Id = updatedUser.Id,
                    CarBrand = tbxCarBrand.Text,
                    CarYear = tbxCarYear.Text,
                    StartWorkTime = DateTime.Parse(tbxCarStartWorkTime.Text),
                    FinishWorkTime = DateTime.Parse(tbxCarFinishWorkTime.Text),
                    Latitude = tbxCarLatitude.Text,
                    Longitude = tbxCarLongitude.Text
                };
                if (adminBl.IsCarIdBooked(updatedCar.Id))
                {
                    adminBl.UpdateCar(updatedCar);
                }
                else
                {
                    adminBl.CreateCar(updatedCar);
                }

                Response.Redirect("~/WebForms/TaxiDrivers.aspx");
            }
            else
            {
                loginBooked.InnerText = "Login is booked!";
            }
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/TaxiDrivers.aspx");
        }
    }
}