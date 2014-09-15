using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.BL;
using Taksopark.DAL.Models;

namespace Taksopark.WebForms.Dispatcher
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static IEnumerable<Request> GetAllRequests()
        {
            OperatorBl operatoerBl = new OperatorBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var orders = operatoerBl.GetActiveRequests();
            return orders;
        }
    }
}