using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.DAL;

namespace Taksopark.WebForms.UserControls
{
    public partial class DeleteTaxiDriver : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDeleteTaxiDriver_Click(object sender, EventArgs e)
        {
            UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["TaksoparkDB"].ConnectionString);
            uow.UserRepository.DeleteUser(Convert.ToInt32(tbxDeleteTaxiDriver.Text));
            Response.Redirect("TaxiDrivers.aspx");
        }
    }
}