using System;
using System.Collections;
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
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public static Request GetRequest(object id)
        {
            OperatorBl operatoerBl = new OperatorBl(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var orders = operatoerBl.GetActiveRequests();
            return orders.Where(e => e.Id == Convert.ToInt32(id)).FirstOrDefault();
        }
  
        protected void dropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }
    }
}